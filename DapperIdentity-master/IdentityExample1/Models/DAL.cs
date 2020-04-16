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
    }
}
