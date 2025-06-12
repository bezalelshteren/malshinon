using Google.Protobuf.Compiler;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace malshinon
{
    public class dhl
    {
        public string strcon = "server=localhost;username=root;password=;database=murder;";

        //public dhl()
        //{

        //}
        public MySqlConnection connactionToDatabase(string strcon)
        {
            MySqlConnection sqlcon = new MySqlConnection(strcon);
            sqlcon.Open();
            return sqlcon;
        }

        public MySqlCommand commonToSql(string query, MySqlConnection sqlcon)
        {
            MySqlCommand common = new MySqlCommand(query, sqlcon);
            return common;
        }


        public void insertANewPerson(persons person, MySqlConnection sqlcon)
        {
            try
            {
                string query = "INSERT INTO agants(firstName,lastName,secretCode,type,numReports,numMentions) VALUES(@firstName,@lastName,@secretCode,@type,@numReports,@numMentions ); ";
                MySqlCommand common = commonToSql(query, sqlcon);
                //common.Parameters.AddWithValue("@Id", person.firstName);
                common.Parameters.AddWithValue("@CodeName", person.lastName);
                common.Parameters.AddWithValue("@RealName", person.secretCode);
                common.Parameters.AddWithValue("@Location", person.type);
                common.Parameters.AddWithValue("@Status", person.numReports);
                common.Parameters.AddWithValue("@MissionsCompleted", person.numMentions);
                common.ExecuteNonQuery();
            }

            catch (Exception e) { Console.WriteLine(e.Message); }
            finally { sqlcon.Close(); }
        }


        public bool checkIfPersonExist(string name, MySqlConnection sqlcon)
        {

            //using (MySqlConnection sqlcon = connactionToDatabase(strcon)) 
            try
            {
                string query = "SELECT * FROM people WHERE CONCAT(firstName, ' ', lastName) LIKE @name;";
                MySqlCommand common = commonToSql(query, sqlcon);

                common.Parameters.AddWithValue("@name", "%" + name + "%");
                int count = Convert.ToInt32(common.ExecuteScalar());
                return count > 0;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message, ex.GetType()); }
            return false;
        }


        public List<persons> getPersonFromSql(string name, MySqlConnection sqlcon, persons persons)
        {
            List<persons> listOfPepole = new List<persons>();
            try
            {
                string query = "SELECT * FROM people WHERE CONCAT(firstName, ' ', lastName) LIKE @name;";
                MySqlCommand common = commonToSql(query, sqlcon);
                common.Parameters.AddWithValue("@name", name);
                var reader = common.ExecuteReader();

                while (reader.Read())
                {

                    var typeString = reader.GetString(reader.GetOrdinal("type"));
                    type type = (type)Enum.Parse(typeof(type), typeString, true);
                    persons person = new persons
                    {
                        //id = reader.GetInt32("id"),
                        firstName = reader.GetString(reader.GetOrdinal("firstName")),
                        lastName = reader.GetString(reader.GetOrdinal("lastName")),
                        secretCode = reader.GetString(reader.GetOrdinal("secretCode")),
                        type = type,
                        numReports = reader.GetInt32(reader.GetOrdinal("numReports")),
                        numMentions = reader.GetInt32(reader.GetOrdinal("numMentions"))
                    };
                    listOfPepole.Add(person);
                }
                return listOfPepole;
            }

            catch (Exception ex) { Console.WriteLine(ex.Message, ex.GetType()); }
            return listOfPepole;
        }
    }
}

