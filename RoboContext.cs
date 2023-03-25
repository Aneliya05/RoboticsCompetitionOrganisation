using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using Data.Models;

namespace Data
{
    public class RoboContext : DbContext
    {
        public RoboContext() : base("RoboContext")
        {

        }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Robot> Robots { get; set; }
        //public DbSet<Discipline> Disciplines { get; set; }
        public DbSet<Competition> Competitions { get; set; }

    }
}