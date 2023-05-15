using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCIFSA_HFT_2022232.Models
{
    public class Platform
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [StringLength(240)]
        public string PName { get; set; }
        public int Users { get; set; }
        public virtual ICollection<Series> series { get; set; }
        public Platform(string PName )
        {
            this.PName = PName;
        }
    }
}
