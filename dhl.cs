using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


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


        public void insertANewPerson(person person, string name)
        {
            public void insertName(string strcon, person person)
        {
            MySqlConnection sqlcon = connactionToDatabase(strcon);
            try
            {
                string query = "INSERT INTO agants(firstName,lastName,secretCode,type,numReports,numMentions) VALUES(@firstName,@lastName,@secretCode,@type,@numReports,@numMentions ); "; MySqlCommand common = commonToSql(query, sqlcon);
                common.Parameters.AddWithValue("@Id", person.firstName);
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
    }
}

