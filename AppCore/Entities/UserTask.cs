using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Entities {
    public class UserTask {
        public int Id { get; set; }
        public int JobOrderId { get; set; }
        public JobOrder JobOrder { get; set; }
        
        public string Title { get; set; }
        public string Description { get; set; }

        public int AssignedTo { get; set; }
        public User AssignedUser { get; set; }

        public DateTime DueDate { get; set; }
        public TaskStatusEnum Status { get; set; }

    }
}
