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
    public class ParticipantBusiness
    {
        private RoboContext roboContext;

        public List<Participant> GetAll()
        {
            using (roboContext = new RoboContext())
            {
                return roboContext.Participants.ToList();
            }
        }
        public Participant Get(int id)
        {
            using (roboContext = new RoboContext())
            {
                return roboContext.Participants.Find(id);
            }
        }
        public void Add(Participant participant)
        {
            using (roboContext = new RoboContext())
            {
                roboContext.Participants.Add(participant);
                roboContext.SaveChanges();
            }
        }
        public void Update(Participant participant)
        {
            using (roboContext = new RoboContext())
            {
                var item = roboContext.Participants.Find(participant.ParticipantId);
                if (item != null)
                {
                    roboContext.Entry(item).CurrentValues.SetValues(participant);
                    roboContext.SaveChanges();
                }
            }
        }
        public void Delete(int id)
        {
            using (roboContext = new RoboContext())
            {
                var participant = roboContext.Participants.Find(id);
                if (participant != null)
                {
                    roboContext.Participants.Remove(participant);
                    roboContext.SaveChanges();
                }
            }
        }
    }
}