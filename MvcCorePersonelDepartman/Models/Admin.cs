using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCorePersonelDepartman.Models
{
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }
        [Column(TypeName="Varchar(20)")]
        public string Kullanici { get; set; }
        public string Sifre { get; set; }
    }
}
