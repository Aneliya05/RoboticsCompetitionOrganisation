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
    public class Competition
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        private int competitionId;

        private string competitionName;
        private string country;
        private string city;
        private string place;
        private DateTime dateTime;


        public int Id
        {
            get { return this.competitionId; }
            set { this.competitionId = value; }
        }
        public string Name
        {
            get { return this.competitionName; }
            set { this.competitionName = value; }
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
        public string Place
        {
            get { return this.place; }
            set { this.place = value; }
        }
        public DateTime DateTime
        {
            get { return this.dateTime; }
            set { this.dateTime = value; }
        }
    }
}
