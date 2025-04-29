using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    internal class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime UpdateTime => DateTime.Now;
    }
}
