using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserDashboard.BL.Models
{
    public class UserListModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public DateTime Enrollmentdate { get; set; }
    }
}
