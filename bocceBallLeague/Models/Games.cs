using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bocceBallLeague.Models
{
    public class Games
    {
        public int ID { get; set; }
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }
        public DateTime DateHappened { get; set; }
        public string Notes { get; set; }


        public int? HomeTeamId { get; set; }
        public int? AwayTeamId { get; set; }
        public virtual Teams HomeTeam { get; set; }
        public virtual Teams AwayTeam { get; set; }

    }
}
