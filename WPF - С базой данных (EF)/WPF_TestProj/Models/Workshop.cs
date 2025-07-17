using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_TestProj.Models
{
    public class Workshop
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int CityId { get; set; }
        public City City { get; set; } = null!;
        public ICollection<Employee> Employees { get; } = new List<Employee>();
    }
}
