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
    public class Robot
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        private int robotId;

        private string robotName;
        private double speed;
        private int strength;
        private int intelligence;
        private int points;
        private int teamId;

        public int RobotId
        {
            get { return this.robotId; }
            set { this.robotId = value; }
        }
        public string RobotName
        {
            get { return this.robotName; }
            set { this.robotName = value; }
        }
        public double Speed
        {
            get { return this.speed; }
            set { this.speed = value; }
        }
        public int Strength
        {
            get { return this.strength; }
            set { this.strength = value; }
        }
        public int Intelligence
        {
            get { return this.intelligence; }
            set { this.intelligence = value; }
        }
        public int Points
        {
            get { return this.points; }
            set { this.points = value; }
        }
        public int TeamId
        {
            get { return this.teamId; }
            set { this.teamId = value; }
        }
    }
}
