using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class Team : Participant
    {
        //count
        private int team_id;
        private string teamName;
        private string description;
        private Robot teamRobot;

        private int Team_id
        {
            get { return this.team_id; }
            set { this.team_id = value; }
        }
        public string TeamName
        {
            get { return this.teamName; }
            set { this.teamName = value; }
        }

        public string Description
        {
            get { return this.description; }
            set { this.description = value; }
        }
        //public Robot TeamRobot
        //{
        //    get { return this.teamRobot; }
        //    set { this.teamRobot = value; }
        //}
    }
}
