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
    public class TeamBusiness
    {
        private RoboContext roboContext;

        //public void AddParticipant(Participant participant)
        //{
        //    using (var context = new RoboContext())
        //    {
        //        roboContext.Entry(participant);
        //        roboContext.SaveChanges();
        //    }
        //}
        // remove from teamContext

        //public void AddRobot(Robot robot)
        //{
        //    using (var context = new RoboContext())
        //    {
        //        roboContext.Entry(robot);
        //        roboContext.SaveChanges();
        //    }
        //}

        public List<Team> GetAll()
        {
            using (roboContext = new RoboContext())
            {
                return roboContext.Teams.ToList();
            }
        }
        public Team Get(int id)
        {
            using (roboContext = new RoboContext())
            {
                return roboContext.Teams.Find(id);
            }
        }
        public void Add(Team team)
        {
            using (roboContext = new RoboContext())
            {
                roboContext.Teams.Add(team);
                roboContext.SaveChanges();
            }
        }
        public void Update(Team team)
        {
            using (roboContext = new RoboContext())
            {
                var item = roboContext.Teams.Find(team.TeamId);
                if (item != null)
                {
                    roboContext.Entry(item).CurrentValues.SetValues(team);
                    roboContext.SaveChanges();
                }
            }
        }
        public void Delete(int id)
        {
            using (roboContext = new RoboContext())
            {
                var team = roboContext.Teams.Find(id);
                if (team != null)
                {
                    roboContext.Teams.Remove(team);
                    roboContext.SaveChanges();
                }
            }
        }
        public void UpdateRobotPoints(int robotId, int points)
        {
            using (roboContext = new RoboContext())
            {
                var robot = roboContext.Teams.Find(robotId);
                if (robot != null)
                {
                    robot.Points = points;
                    roboContext.SaveChanges();
                }
            }
        }
    }
}
