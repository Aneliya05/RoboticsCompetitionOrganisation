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
    public class RobotBusiness
    {
        private RoboContext roboContext;

        public List<Robot> GetAll()
        {
            using (roboContext = new RoboContext())
            {
                return roboContext.Robots.ToList();
            }
        }
        public void Add(Robot robot)
        {
            using (roboContext = new RoboContext())
            {
                roboContext.Robots.Add(robot);
                roboContext.SaveChanges();
            }
        }
        public void Update(Robot robot)
        {
            using (roboContext = new RoboContext())
            {
                var searched = roboContext.Robots.Find(robot.RobotId);
                if (searched != null)
                {
                    roboContext.Entry(searched).CurrentValues.SetValues(robot);
                    roboContext.SaveChanges();
                }

            }
        }
        public Robot Get(int id)
        {
            using (roboContext = new RoboContext())
            {
                return roboContext.Robots.Find(id);
            }
        }
        public void Delete(int id)
        {
            using (roboContext = new RoboContext())
            {
                var searched = roboContext.Robots.Find(id);
                if (searched != null)
                {
                    roboContext.Robots.Remove(searched);
                    roboContext.SaveChanges();
                }
            }
        }

        public void Evaluate(Robot robot) // == update
        {
            using (roboContext = new RoboContext())
            {
                var item = roboContext.Robots.Find(robot.RobotId);
                if (item != null)
                {
                    roboContext.Entry(item).CurrentValues.SetValues(robot);
                    roboContext.SaveChanges();
                }
            }
        }

        public double SumPoints(double speed, int strength, int intelligence)
        {
            int points = (int)speed * strength * intelligence;
            return points;
        }
        public void UpdateRobotPoints(int robotId, int points)
        {
            using (roboContext = new RoboContext())
            {
                var robot = roboContext.Robots.Find(robotId);
                if (robot != null)
                {
                    robot.Points = points;
                    roboContext.SaveChanges();
                }
            }
        }



    }
}
