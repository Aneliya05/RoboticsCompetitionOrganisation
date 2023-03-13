using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class Participant
    {
        [Key]
        public int Id;
        public string Name;
        public string Surname;
        public int Age;
        public string Country;
        public string City;
        public string TelNumber;
        public string Email;

        
        //public int Age_Group(int age) 
        //{
            
        //}
    }
}

