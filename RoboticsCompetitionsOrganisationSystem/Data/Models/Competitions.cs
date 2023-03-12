namespace Data.Models
{
    public class Competitions
    {
        private string name;
        private string country;
        private string city;
        private string place;
        private DateTime dateTime;
        private string description;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Country
        {
            get { return country; }
            set { country = value; }
        }
        public string City
        {
            get { return city; }
            set { city = value; }
        }
        public string Place
        {
            get { return place; }
            set { place = value; }
        }
        public DateTime DateTime
        {
            get { return dateTime; }
            set { dateTime = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
    }
}
