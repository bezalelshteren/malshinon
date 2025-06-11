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
        public string strcon = "server=localhost;username=root;password=;database=design;";

        //public dhl()
        //{

        //}
        public MySqlConnection connactionToDatabase(string strcon)
        {
            MySqlConnection sqlcon = new MySqlConnection(strcon);
            Console.WriteLine("is open");
            sqlcon.Open();
            return sqlcon;
        }

        public MySqlCommand commonToSql(string query, MySqlConnection sqlcon)
        {
            MySqlCommand common = new MySqlCommand(query, sqlcon);
            Console.WriteLine("is conect");
            return common;
        }


        public void insertANewPerson(persons person ,MySqlConnection sqlcon)
        {
            try
            {

                string query = "INSERT INTO people(firstName, lastName, secretCode, type, numReports, numMentions) VALUES(@firstName, @lastName, @secretCode, @type, @numReports, @numMentions)";
                MySqlCommand common = commonToSql(query, sqlcon);
                Console.WriteLine("send the common");
                common.Parameters.AddWithValue("@firstName", person.firstName);
                common.Parameters.AddWithValue("@lastName", person.lastName);
                string fullName = $"{person.firstName} {person.lastName}";
                string code = malshinonOptions.createSecretCode(fullName);
                common.Parameters.AddWithValue("@secretCode", code);
                common.Parameters.AddWithValue("@type", person.type);
                common.Parameters.AddWithValue("@numReports", person.numReports);
                common.Parameters.AddWithValue("@numMentions", person.numMentions);
                common.ExecuteNonQuery();
            }

            catch (Exception e) { Console.WriteLine(e.Message); }
            finally { sqlcon.Close(); }
        }


        public bool checkIfPersonExist(string query1, string[] name, MySqlConnection sqlcon)
        {

            //using (MySqlConnection sqlcon = connactionToDatabase(strcon)) 
            try
            {
                string query = query1;

                //string query = "SELECT * FROM people WHERE CONCAT(firstName, ' ', lastName) LIKE @name;";
                MySqlCommand common = commonToSql(query, sqlcon);
                Console.WriteLine("send the common");
                common.Parameters.AddWithValue(name[0], name[1]);

                int count = Convert.ToInt32(common.ExecuteScalar());
                Console.WriteLine("is retoren enything");
                return count > 0;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message, ex.GetType()); }
            Console.WriteLine("ccccccccc");
            return false;
        }


        public List<persons> getPersonFromSql(string query1,string[] name, MySqlConnection sqlcon,persons persons )
        {
            List<persons> listOfPepole = new List<persons>();
            try
            {
                string query = query1;
                MySqlCommand common = commonToSql(query, sqlcon);
                common.Parameters.AddWithValue(name[0], name[1]);
                var reader = common.ExecuteReader();
                Console.WriteLine("is read ");

                while (reader.Read())
                {
                    Console.WriteLine("readdd wwwoww");
                    //var typeString = reader.GetString(reader.GetOrdinal("type"));
                    //type type = (type)Enum.Parse(typeof(type), typeString, true);
                    persons person = new persons();

                    person.id = reader.GetInt32("id");
                    person.firstName = reader.GetString(reader.GetOrdinal("firstName"));
                    person.lastName = reader.GetString(reader.GetOrdinal("lastName"));
                    person.secretCode = reader.GetString(reader.GetOrdinal("secretCode"));
                    person.type = reader.GetString(reader.GetOrdinal("type"));
                    person.numReports = reader.GetInt32(reader.GetOrdinal("numReports"));
                    person.numMentions = reader.GetInt32(reader.GetOrdinal("numMentions"));
                    
                    listOfPepole.Add(person);
                    Console.WriteLine("is working");
                }
                return listOfPepole;
            }

            catch (Exception ex) { Console.WriteLine(ex.Message, ex.GetType()); }
            return listOfPepole;
        }


        //public bool IsSecretCodeExist(string cecretCode, MySqlConnection conn)
        //{
        //    string query = "SELECT COUNT(*) FROM people WHERE secretCode = @code;";
        //    MySqlCommand cmd = new MySqlCommand(query, conn);
        //    cmd.Parameters.AddWithValue("@code", cecretCode);
        //    int count = Convert.ToInt32(cmd.ExecuteScalar());
        //    return count > 0;
        //}

    }
}
//"@name", "%" + name + "%"
