using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bocceBallLeague.Context;
using bocceBallLeague.Models;

namespace bocceBallLeague
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new DataContext();


            var team = new Teams
            {
                Mascot = "Bulldog",
                Color = "White"
            };
            db.Teams.Add(team);
            db.SaveChanges();

            var team2 = new Teams
            {
                Mascot = "Eagle",
                Color = "Black"
            };
            db.Teams.Add(team2);
            db.SaveChanges();

            var team3 = new Teams
            {
                Mascot = "Mongoose",
                Color = "Brown"
            };
            db.Teams.Add(team3);
            db.SaveChanges();

            var team4 = new Teams
            {
                Mascot = "Bronco",
                Color = "Grey"
            };
            db.Teams.Add(team4);
            db.SaveChanges();


            var game = new Games
            {
                HomeTeam = "Red Team",
                AwayTeam = "Blue Team",
                AwayScore = 16,
                DateHappened = DateTime.Now,
                Notes = "Away Game"
            };
            db.Games.Add(game);
            db.SaveChanges();

            var game2 = new Games
            {
                HomeTeam = "Blue Team",
                AwayTeam = "Red Team",
                AwayScore = 10,
                DateHappened = DateTime.Now,
                Notes = "Home Game"
            };
            db.Games.Add(game2);
            db.SaveChanges();

            var player = new Players
            {
                FullName = "Mike Thompson",
                NickName = "Rocky",
                Number = 21,
                ThrowingArm = "Left Arm",
            };
            db.Players.Add(player);
            db.SaveChanges();

            var player2 = new Players
            {
                FullName = "Rick Bear",
                NickName = "Sweet",
                Number = 11,
                ThrowingArm = "Right Arm",
            };
            db.Players.Add(player2);
            db.SaveChanges();

            var player3 = new Players
            {
                FullName = "Jeff Tape",
                NickName = "Sparky",
                Number = 2,
                ThrowingArm = "Left Arm",
            };
            db.Players.Add(player3);
            db.SaveChanges();

            var player4 = new Players
            {
                FullName = "Chris Griffin",
                NickName = "Slippery",
                Number = 50,
                ThrowingArm = "Left Arm",
            };
            db.Players.Add(player4);
            db.SaveChanges();


                Console.WriteLine("Printing all teams with their records, all players and their current teams, all upcoming games and past games.");
            Console.Read();
        }
    }
}
