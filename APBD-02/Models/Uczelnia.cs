using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APBD_02.Models
{
    public class Uczelnia
    {
        public string createdAt { get; set; }
        public string author { get; set; }
        public HashSet<Student> students { get; set; }
    }
}
