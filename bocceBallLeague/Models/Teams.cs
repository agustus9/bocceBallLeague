using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bocceBallLeague.Models
{
    public class Teams
    { 
    public int Id { get; set; }
    public string Mascot { get; set; }
    public string Color { get; set; }

    public ICollection<Games> Games { get; set; } = new HashSet<Games>();
    }
}
