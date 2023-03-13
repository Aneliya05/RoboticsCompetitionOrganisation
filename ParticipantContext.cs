using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Data.Model;
namespace Data.Contexts
{
    public class ParticipantContext : DbContext
    {
        public ParticipantContext() : base("name = ParticipantContext")
        {

        }
        public DbSet<Participant> Participants { get; set; }
    }
}
