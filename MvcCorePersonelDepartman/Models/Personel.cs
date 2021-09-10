using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCorePersonelDepartman.Models
{
    public class Personel
    {
        [Key]
        public int PersonelID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public int BirimID { get; set; }
        public Birim Birim { get; set; }
    }
}
