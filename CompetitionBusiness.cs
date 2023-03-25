using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using Data;
using Data.Models;

namespace Business
{
    public class CompetitionBusiness
    {
        private RoboContext roboContext;

        public List<Competition> GetAll()
        {
            using (roboContext = new RoboContext())
            {
                return roboContext.Competitions.ToList();
            }
        }
        public Competition Get(int id)
        {
            using (roboContext = new RoboContext())
            {
                return roboContext.Competitions.Find(id);
            }
        }

        //public static void FillTable()
        //{
        //    using (RoboContext roboContext = new RoboContext())
        //    {
        //        Competition something = new Competition
        //        {
        //            Name = "Metal Mayhem",
        //            City = "New York City",
        //            Country = "USA",
        //            Place = "Madison Square Garden",
        //            DateTime = DateTime.ParseExact("23.06.2023 12:00", "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture)
        //        };
        //        roboContext.Competitions.Add(something);
        //        roboContext.SaveChanges();
        //    }
        //}
        public void AddParticipantsInCompetiton(Competition competition, Participant participant)
        {
            Dictionary<Competition, Participant> competitionParticipants = new Dictionary<Competition, Participant>();
            competitionParticipants.Add(competition, participant);
        }
        public void ParticipantsInCompetition(Dictionary<Competition,Participant> competitionParticipants, Competition competition)
        {
            List<Participant> participantsInCompetition = new List<Participant>();
            foreach (KeyValuePair<Competition, Participant> pair in competitionParticipants)
            {
                if (pair.Key == competition)
                {
                    participantsInCompetition.Add(pair.Value);
                }
            }

            Console.WriteLine("Participants in competition {0}:", competition.Name);
            foreach (Participant p in participantsInCompetition)
            {
                Console.WriteLine("- {0} {1} {2}", p.FirstName, p.MiddleName, p.Surname);
            }
        }

        public void AddRobotInCompetiton(Competition competition, Robot robot)
        {
            Dictionary<Competition, Robot> competitionRobots = new Dictionary<Competition, Robot>();
            competitionRobots.Add(competition, robot);
        }

        public void RobotsInCompetition(Dictionary<Competition, Robot> competitionRobots, Competition competition)
        {
            List<Robot> robotsInCompetition = new List<Robot>();
            foreach (KeyValuePair<Competition, Robot> pair in competitionRobots)
            {
                if (pair.Key == competition)
                {
                    robotsInCompetition.Add(pair.Value);
                }
            }

            Console.WriteLine("Robots in competition {0}:", competition.Name);
            foreach (Robot r in robotsInCompetition)
            {
                Console.WriteLine("- {0} {1} {2}", r.RobotName, r.Points);
            }
        }
    }
}
