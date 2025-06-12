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


        public void insertANewPerson(string query,persons person ,MySqlConnection sqlcon)
        {
            try
            {
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


        public bool checkIfPersonExist(string query, string[] name, MySqlConnection sqlcon)
        {
           // this.connactionToDatabase(strcon)
            //using (MySqlConnection sqlcon = connactionToDatabase(strcon)) 
            try
            {
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


        public List<persons> getPersonFromSql(string query,string[] name, MySqlConnection sqlcon )
        {
            List<persons> listOfPepole = new List<persons>();
            try
            {
                
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
        public void updatePerson(string query, string[]theChaing,MySqlConnection sqlcon)
        {
            try
            {
                MySqlCommand common = commonToSql(query, sqlcon);
                common.Parameters.AddWithValue(theChaing[0], theChaing[1]);
                common.ExecuteNonQuery();
               
            }catch(Exception ex) { Console.WriteLine(ex.Message,ex.GetType());
            }
            
        }
        public void insertareport(string query, report report, MySqlConnection sqlcon)
        {
            try
            {
                MySqlCommand common = commonToSql(query, sqlcon);
                common.Parameters.AddWithValue("@text", report.text);
                common.Parameters.AddWithValue("@reporterId", report.reporterId);
                common.Parameters.AddWithValue("@targetId", report.targetId);
                common.ExecuteNonQuery();
            }catch(Exception ex) { Console.WriteLine(ex.Message,ex.GetType()); }
        }
        public int getIdByName()
        {

        }
    }
}
//"@name", "%" + name + "%"
