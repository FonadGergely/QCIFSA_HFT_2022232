using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCIFSA_HFT_2022232.Models
{
    public class Series
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [StringLength(240)]
        public string title { get; set; }
        public int Rating { get; set; }

        List<Actors> actorList;
        public Platform platform { get; set; }
        public Series(string title, int rating)
        {
            this.title = title;
            Rating = rating;

        }
    }
}
