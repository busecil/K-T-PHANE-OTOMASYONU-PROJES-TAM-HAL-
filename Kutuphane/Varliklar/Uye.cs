using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Varliklar
{
    [Table("Uyeler")]
    public class Uye
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int ID { get; set; }
        [MaxLength(50)]
        public string Ad { get; set; }
        [MaxLength(50)]
        public string Soyad { get; set; }
        [MaxLength(11)]
        public string OgrenciNo { get; set; }

        public string BolumKodu { get; set; }
        public string Sinif { get; set; }
        public string Eposta { get; set; }

        public string TelefonNo { get; set; }

        public byte[] resim { get; set; }
        public virtual List<EmanetKitaplar> EmanetKitaplars { get; set; }
    }
}
