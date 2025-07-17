using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_TestProj.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<Workshop> Workshops { get; set; } = new List<Workshop>();
    }
}
