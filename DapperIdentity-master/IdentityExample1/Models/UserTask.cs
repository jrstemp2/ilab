using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityExample1.Models
{
    public class UserTask
    {
        private int id;
        private int userId;
        private string taskDescription;
        private DateTime dueDate;
        private int taskStatus;// 0 for incomplete/open and 1 for complete

        public int Id { get => id; set => id = value; }
        public int UserId { get => userId; set => userId = value; }
        public string TaskDescription { get => taskDescription; set => taskDescription = value; }
        public DateTime DueDate { get => dueDate; set => dueDate = value; }
        public int TaskStatus { get => taskStatus; set => taskStatus = value; }
    }
}
