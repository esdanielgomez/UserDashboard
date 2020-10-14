using System;
using System.Collections.Generic;

namespace UserDashboard.DAL.Entities
{
    public partial class Person
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int Postalcode { get; set; }
        public string About { get; set; }
        public DateTime Enrollmentdate { get; set; }
    }
}
