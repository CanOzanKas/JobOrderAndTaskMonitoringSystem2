using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Entities {
    public class Notification {
        public int Id { get; set; }
        public string Message { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int TaskId { get; set; }
        public UserTask Task { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
