using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCorePersonelDepartman.Models
{
    public class Birim
    {
        [Key]
        public int BirimID { get; set; }
        public string BirimName { get; set; }
        public IList<Personel> Personels { get; set; }
    }
}
