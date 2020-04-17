using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityExample1.Models
{
    public class DAL
    {
        private SqlConnection conn;
        

        public DAL(string connectionString)
        {
            conn = new SqlConnection(connectionString);
        }

        public int AddTask(UserTask u)
        {
            string addQuery = "INSERT INTO IdentityTasks (UserId, TaskDescription, DueDate, TaskStatus) ";
            addQuery += "VALUES(@UserId, @TaskDescription, @DueDate, @TaskStatus)";

            return conn.Execute(addQuery, u);
        }

        public IEnumerable<UserTask> GetTasks(int id)
        {
            string queryString = "SELECT * FROM IdentityTasks WHERE UserId = @val";

            return conn.Query<UserTask>(queryString, new { val = id });
        }

        public int DeleteTaskById(int id)
        {
            string deleteString = "DELETE FROM IdentityTasks WHERE Id = @val";
            return conn.Execute(deleteString, new { val = id });
        }

        public void CompleteTask(int id)
        {

            string queryString = "Update IdentityTasks SET TaskStatus = '1' WHERE id = @id";
            conn.QueryFirstOrDefault<UserTask>(queryString, new { id = id });


        }

        public IEnumerable<UserTask> GetAllTasksById(string userid)
        {

            string queryString = "SELECT * FROM IdentityTasks WHERE UserId = @userid";
            return conn.Query<UserTask>(queryString, new { userid = userid });
        }
    }
}
