using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace school.dashboard.Model
{
    public class Staff
    {
        public string Id { get; set; }
        public string staffID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public string phoneNumber { get; set; }
        public string roleId { get; set; }
        public string email { get; set; }
        public string image { get; set; }
    }
}
