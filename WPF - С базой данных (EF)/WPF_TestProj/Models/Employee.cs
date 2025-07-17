using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_TestProj.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int WorkshopId { get; set; }
        public Workshop Workshop { get; set; } = null!;
    }
}
