using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace school.dashboard.Model
{
    public class Student
    {
        public string Id { get; set; }
        public string regID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public string phoneNumber { get; set; }
        public string roleId { get; set; }
        public string std { get; set; }
        public string sec { get; set; }
        public string image { get; set; }



    }
}
