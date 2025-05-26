using CRUDAppUsingADO.Models;
using System.Data;
using Microsoft.Data.SqlClient;

namespace CRUDAppUsingADO
{
    public class EmployeeDataAccessLayer
    {
        //firstly we get connection string...
        string cs = ConnectionString.dbcs;

        //creating a method for geting all employees from the database table...(READ)
        public List<Employees> getAllEmployees()
        {
            List<Employees> empList = new List<Employees>();

            //using block which automatically closes the connection later
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spGetAllEmployees",con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();

                //SqlDataReader reads rows one by one from the result.
                SqlDataReader reader = cmd.ExecuteReader();


                //Create a new Employees object for each row,Fill its properties using values from the database.
                while (reader.Read())
                {
                    Employees emp = new Employees();
                    emp.Id = Convert.ToInt32(reader["Id"]);
                    emp.Name = reader["Name"].ToString() ?? "";
                    emp.Gender = reader["Gender"].ToString() ?? "";
                    emp.Age = Convert.ToInt32(reader["Age"]);
                    emp.Designation = reader["Designation"].ToString() ?? "";
                    emp.Salary = Convert.ToDecimal(reader["Salary"]);
                    emp.City = reader["City"].ToString() ?? "";
                    empList.Add(emp);
                }
            }
            return empList;
        }

        // create a method for get employee by id..
        public Employees getEmployeeByID(int? Id)
        {
            Employees emp = new Employees();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("select * from employees where Id = @Id", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Id", Id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    emp.Id = Convert.ToInt32(reader["Id"]);
                    emp.Name = reader["Name"].ToString() ?? "";
                    emp.Gender = reader["Gender"].ToString() ?? "";
                    emp.Age = Convert.ToInt32(reader["Age"]);
                    emp.Designation = reader["Designation"].ToString() ?? "";
                    emp.Salary = Convert.ToDecimal(reader["Salary"]);
                    emp.City = reader["City"].ToString() ?? "";
                }
            }
            return emp;
        }


        //Add employess using ADO.NET...(CREATE)
        public void AddEmployee(Employees emp)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spAddEmployees", con);
                cmd.CommandType = CommandType.StoredProcedure;
                //provide value parameter..
                cmd.Parameters.AddWithValue("@Name", emp.Name);
                cmd.Parameters.AddWithValue("@Gender", emp.Gender);
                cmd.Parameters.AddWithValue("@Age", emp.Age);
                cmd.Parameters.AddWithValue("@Designation", emp.Designation);
                cmd.Parameters.AddWithValue("@Salary", emp.Salary);
                cmd.Parameters.AddWithValue("@City", emp.City);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }


        // create a method for UPDATE Employees.....
        public void UpdateEmployee(Employees emp)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spUpdateEmployees", con);
                cmd.CommandType = CommandType.StoredProcedure;
                //provide value parameter..
                cmd.Parameters.AddWithValue("@Id", emp.Id);
                cmd.Parameters.AddWithValue("@Name", emp.Name);
                cmd.Parameters.AddWithValue("@Gender", emp.Gender);
                cmd.Parameters.AddWithValue("@Age", emp.Age);
                cmd.Parameters.AddWithValue("@Designation", emp.Designation);
                cmd.Parameters.AddWithValue("@Salary", emp.Salary);
                cmd.Parameters.AddWithValue("@City", emp.City);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }


        // create a method for DELETE EMPLOYEE.....

        public void DeleteEmployee(int? Id)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spDeleteEmployes", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", Id);
                con.Open();
                cmd.ExecuteNonQuery();
            }

        }
    }
}
