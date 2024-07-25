using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Interception;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Varliklar;

namespace VeriBaglantisi
{
    
    public class KutuphaneContext : DbContext
    {
      
        DbSet<Yazar> Yazarlar { get; set; }
        DbSet<Kitap> Kitaplar  { get; set; }
        DbSet<KitapTuru> KitapTurler { get; set; }
        DbSet<Kullanicilar> Kullanicilars { get; set; }
        DbSet<EmanetKitaplar> EmanetKitaplars { get; set; }
        DbSet<Uye> Uyeler { get; set; }

    }
}
