using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Varliklar
{
    [Table("Kullanicilar")]
    public class Kullanicilar
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int ID { get; set; }
        [MaxLength(100)]
        public string KullaniciAdi { get; set; }
        [MaxLength(200)]
        public string EPosta { get; set; }

        public string Sifre { get; set; }
    }
}
