using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace CrudTest.Models
{
    public class Repository
    {
        private string connectionString = "Data Source = localhost;Initial Catalog = ExpressDB;User ID = sa;Password = zxczxc";

        public List<Employee> ListAll()
        {
            using (var con = new SqlConnection(connectionString))
            {
                con.Open();
                return con.Query<Employee>("select * from M_Employee").ToList();
            }
        }

        public int Add(Employee emp)
        {
            using (var db = new SqlConnection(connectionString))
            {
                db.Open();
                db.Execute("insert into M_Employee values (@Name, @Age)", new { Name = emp.Name, Age = emp.Age });
            }
            return 1;
        }

        public int Update(Employee emp)
        {
            using (var db = new SqlConnection(connectionString))
            {
                db.Open();
                db.Execute("update M_Employee set Name = @Name, Age = @Age where EmpId = @EmpId", new { EmpId = emp.EmpId, Name = emp.Name, Age = emp.Age });
            }
            return 1;
        }
        public int Delete(int id)
        {
            using (var db = new SqlConnection(connectionString))
            {
                db.Open();
                db.Execute("delete M_Employee where EmpId = @EmpId", new { EmpId = id});
            }
            return 1;
        }
    }
}
