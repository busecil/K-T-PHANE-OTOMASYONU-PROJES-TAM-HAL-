using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Varliklar
{
    [Table("EmanetKitaplar")]
    public class EmanetKitaplar
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
      
        public DateTime AlimTarihi { get; set; }
        public DateTime TeslimTarihi { get; set; }
        [MaxLength(50)]
        public string GorevliAdi { get; set; }
        public bool TeslimEdildiMi { get; set; }
        public int? KitapID { get; set; }
        public virtual Kitap Kitap { get; set; }
        public int? UyeID { get; set; }
        public virtual Uye Uye { get; set; }
        public int? YazarID { get; set; }
        public virtual Yazar Yazar { get; set; }
    }
}
