using DemoMVC.Models;
using Microsoft.Data.SqlClient;

namespace DemoMVC.OMLayer
{
    public class OMEmp
    {
        public List<Emp> GetEmps()
        {

            List<Emp> emps = new List<Emp>();

            SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=KentDB;Integrated Security=True;");

            SqlCommand command = new SqlCommand("select * from Emp", connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Emp emp = new Emp();
                emp.No = Convert.ToInt32(reader["No"]);
                emp.Name = reader["Name"].ToString();
                emp.Address = reader["Address"].ToString();

                emps.Add(emp);
            }

            connection.Close();

            return emps;

        }

        public Emp GetEmp(int? No)
        {
            var emps = GetEmps();
            Emp empFound =  emps.Find((emp) => { return emp.No == No; }) ;
            return empFound;
        }

        public int AddEmp(Emp emp)
        {
            string queryFormat = "insert into Emp(Name, Address) values('{0}', '{1}')";
            string query = string.Format(queryFormat, emp.Name, emp.Address);
            SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=KentDB;Integrated Security=True;");

            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            int rowsAffected =  command.ExecuteNonQuery();
            connection.Close();
            return rowsAffected;
        }

        public int UpdateEmp(Emp emp)
        {
            string queryFormat = "update Emp set Name = '{0}', Address= '{1}' where No = {2}";
            string query = string.Format(queryFormat, emp.Name, emp.Address,emp.No);
            SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=KentDB;Integrated Security=True;");

            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            int rowsAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowsAffected;
        }

        public int RemoveEmp(int? No)
        {
            string queryFormat = "delete from Emp where No = {0}";
            string query = string.Format(queryFormat, No);
            SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=KentDB;Integrated Security=True;");

            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            int rowsAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowsAffected;
        }
    }
}
