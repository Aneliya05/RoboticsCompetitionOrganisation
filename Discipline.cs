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
    public class Discipline
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        private int discipline_id;

        private string type;

        public int Discipline_id
        {
            get { return this.discipline_id; }
            set { this.discipline_id = value; }
        }
        public string Type
        {
            get { return this.type; }
            set { this.type = value; }
        }
    }
}
