using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;


namespace Data.Models
{
    public class Team
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        private int teamId;

        private string teamName;
        private int number;
        private double points;
        private int robotId;

        public int TeamId
        {
            get { return this.teamId; }
            set { this.teamId = value; }
        }
        public string TeamName
        {
            get { return this.teamName; }
            set { this.teamName = value; }
        }

        public int Number
        {
            get { return this.number; }
            set { this.number = value; }
        }

        public double Points
        {
            get { return this.points; }
            set { this.points = value; }
        }

        public int RobotId
        {
            get { return this.robotId; }
            set { this.robotId = value; }
        }

    }
}
