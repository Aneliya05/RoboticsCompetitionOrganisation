namespace Data.Models
{
    public class Participant
    {
        private string name;
        private string surname;
        private int age;
        private string country;
        private string city;
        private long telNumber;
        private string email;

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public string Surname
        {
            get { return this.surname; }
            set { this.surname = value; }
        }
        public int Age
        {
            get { return this.age; }
            set { this.age = value; }
        }
        public string Country
        {
            get { return this.country; }
            set { this.country = value; }
        }
        public string City
        {
            get { return this.city; }
            set { this.city = value; }
        }
        public long TelNumber
        {
            get { return this.telNumber; }
            set { this.telNumber = value; }
        }
        public string Email
        {
            get { return this.email; }
            set { this.email = value; }
        }
    }
}
