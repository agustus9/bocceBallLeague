using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bocceBallLeague.DataContext;
using bocceBallLeague.Models;
using System.Data.Entity;

namespace bocceBallLeague
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new bocceBallLeagueDataContext())

            { 
                db.Players.Add(new Players
            {
                FullName = "Mike Thompson",
                NickName = "Rocky",
                Number = 21,
                ThrowingArm = "Left Arm"
             });
                db.Players.Add(new Players
            {
                    FullName = "Rick Bear",
                    NickName = "Sweet",
                    Number = 11,
                    ThrowingArm = "Right Arm",
             });
                db.SaveChanges();
                db.Teams.Add(new Teams
                {
                    Mascot = "Bulldog",
                    Color = "White"

                });
                db.Teams.Add(new Teams
                {
                    Mascot = "Eagle",
                    Color = "Black"

                });
                db.SaveChanges();
                var bulldog = db.Teams.Include(t => t.Players).First(f => f.Mascot == "Bulldog");
                var player = db.Players.First(p => p.FullName == "Mike Thompson");
                bulldog.Players.Add(player);

                var eagle = db.Teams.Include(c => c.Players).First(v => v.Mascot == "Eagle");
                var player2 = db.Players.First(x => x.FullName == "Rick Bear");
                eagle.Players.Add(player2);
                db.SaveChanges();

                db.Games.Add(new Games
                {
                    HomeTeam = bulldog,
                    AwayTeam = eagle,
                    HomeScore = 14,
                    AwayScore = 7,
                    DateHappened = DateTime.Today,
                    Notes = "go bulldog"
                });
                db.Games.Add(new Games
                {
                    HomeTeam = bulldog,
                    AwayTeam = eagle,
                    DateHappened = DateTime.MaxValue,
                    Notes = "low score"
                });
                db.SaveChanges();


                Console.WriteLine("Printing all teams with their records, all players and their current teams, all upcoming games and past games.");

                var scores = db.Teams.Include(s => s.HomeGames).Include(s => s.AwayGames).Where(w => db.Games.Any(l => l.DateHappened < DateTime.Now));
                foreach (var score in scores)
                {
                    int wins = score.HomeGames.Where(g => g.HomeScore > 0 && g.HomeScore > g.AwayScore).Count();
                    int awayWins = score.AwayGames.Where(g => g.AwayScore > 0 && g.AwayScore > g.HomeScore).Count();
                    int homeCount = score.HomeGames.Where(g => g.DateHappened < DateTime.Now).Count();
                    int awayCount = score.AwayGames.Where(g => g.DateHappened < DateTime.Now).Count();

                    Console.WriteLine("Team {0}: {1} wins, {2} loses", score.Mascot, wins + awayWins, homeCount + awayCount - wins - awayWins);
                }
                var allPlayers = db.Players.Include(f => f.Team);
                foreach (var players in allPlayers)
                {
                    Console.WriteLine("{0}-{1}", player.FullName, player.Team.Mascot);
                }

                var allFutureGames = db.Games.Where(g => g.DateHappened > DateTime.Now);
                foreach (var game in allFutureGames)
                {
                    Console.WriteLine("{0}", game.DateHappened);
                }
                var allPastGames = db.Games.Where(y => y.DateHappened < DateTime.Now);
                foreach (var game in allPastGames)
                {
                    Console.WriteLine("{0}", game.DateHappened);
                }
                db.SaveChanges();
            }
            Console.WriteLine("Bulls Win");
            Console.ReadLine();
        }
    }
}

