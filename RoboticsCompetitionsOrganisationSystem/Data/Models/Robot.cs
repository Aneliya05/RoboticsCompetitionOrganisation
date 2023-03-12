namespace Data.Models
{
    internal class Robot
    {
        private string name;
        private double speed;
        private int strength;
        private int intelligence; //iq

        public string Name
        {
            get { return this.name; }
            set { this.name = value;}
        }
        public double Speed
        {
            get { return this.speed;}
            set { this.speed = value;}
        }
        public int Strength
        { 
            get { return this.strength;}
            set { this.strength = value;}
        }
        public int Intelligence
        {
            get { return this.intelligence; }
            set { this.intelligence = value; }
        }
        public Robot()
        {

        }
    }
}
