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
    public class Participant
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        private int participantId;

        private string firstName;
        private string middleName;
        private string surname;
        private int age;
        private string telNumber;
        private string email;
        private string country;
        private string city;
        private int teamId;
        private int robotId;
        private int competitionId;

        public int ParticipantId
        {
            get { return this.participantId; }
            set { this.participantId = value; }
        }
        public string FirstName
        {
            get { return this.firstName; }
            set { this.firstName = value; }
        }
        public string MiddleName
        {
            get { return this.middleName; }
            set { this.middleName = value; }
        }
        public string Surname
        {
            get { return this.surname; }
            set { this.surname = value; }
        }
        public int Age
        {
            get { return this.age; }
            set
            {
                if (value <= 10)
                    throw new ArgumentException("Sorry, but you are too young to participate. May be you should try some years later. :)");
                this.age = value;
            }
        }
        public string TelNumber
        {
            get { return this.telNumber; }
            set
            {
                if (value.Length > 15) //real facts
                {
                    throw new ArgumentException("Phone number cannot be longer than 15 digits");
                }
                this.telNumber = value;
            }
        }
        public string Email
        {
            get { return this.email; }
            set
            {
                if (!value.Contains("@") && !value.Contains("."))
                {
                    throw new ArgumentException("Invalid email!");
                }
                this.email = value;
            }
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

        public int TeamId
        {
            get { return this.teamId; }
            set { this.teamId = value; }
        }

        public int RobotId
        {
            get { return this.robotId; }
            set { this.robotId = value; }
        }
        public int CompetitionId
        {
            get { return this.competitionId; }
            set { this.competitionId = value; }
        }
    }
}
