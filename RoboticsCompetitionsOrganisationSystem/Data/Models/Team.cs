namespace Data.Models
{
    public class Team : Participant
    {
        private string teamName;
        private string description;
        private Robot teamRobot;

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
