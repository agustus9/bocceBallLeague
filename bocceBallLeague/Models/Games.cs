using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bocceBallLeague.Models
{
    public class Games
    {
        public int Id { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public int AwayScore { get; set; }
        public DateTime DateHappened { get; set; }
        public string Notes { get; set; }


        public int? HomeTeamId { get; set; }
        public Teams HomeTeams { get; set; }

        public int? AwayTeamId { get; set; }
        public Teams AwayTeams { get; set; }

        public ICollection<Teams> Teams { get; set; } = new HashSet<Teams>();
    }
}
