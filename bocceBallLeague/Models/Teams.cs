using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace bocceBallLeague.Models
{
    public class Teams
    {
      

    public int Id { get; set; }
    public string Mascot { get; set; }
    public string Color { get; set; }

   public virtual List<Players> Players { get; set; }
   [ForeignKey("HomeTeamId")]
   public virtual ICollection<Games> HomeGames { get; set; } 
   [ForeignKey("AwayTeamId")]
   public virtual ICollection<Games> AwayGames { get; set; } 

    }
}
