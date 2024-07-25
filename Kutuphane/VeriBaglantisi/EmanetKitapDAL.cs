using InterFaceler;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Varliklar;

namespace VeriBaglantisi
{
    public class EmanetKitapDAL : VtIslemleriI<EmanetKitaplar>
    {
        public void Ekle(EmanetKitaplar kayit)
        {
            using (KutuphaneContext vt = new KutuphaneContext())
            {
                var eklenecekKayit = vt.Entry(kayit);
                eklenecekKayit.State = EntityState.Added;
                vt.SaveChanges();
            }
        }

        public void Guncelle(EmanetKitaplar kayit)
        {
            using (KutuphaneContext vt = new KutuphaneContext())
            {
                var guncellenecekKayit = vt.Entry(kayit);
                guncellenecekKayit.State = EntityState.Modified;
                vt.SaveChanges();
            }
        }

        public void Sil(EmanetKitaplar kayit)
        {
            using (KutuphaneContext vt = new KutuphaneContext())
            {
                var silinecekKayit = vt.Entry(kayit);
                silinecekKayit.State = EntityState.Deleted;
                vt.SaveChanges();
            }
        }

        public List<EmanetKitaplar> sorgula(Func<EmanetKitaplar, bool> filtre = null)
        {
            using (KutuphaneContext vt = new KutuphaneContext())
            {
                return filtre == null ? vt.Set<EmanetKitaplar>()
                    .Include(k => k.Kitap)
                    .Include(k => k.Yazar)
                        .Include(k => k.Uye).ToList() : vt.Set<EmanetKitaplar>()
                        .Include(k => k.Kitap)
                        .Include(k => k.Uye)
                        .Include(k => k.Yazar)
                    .Where(filtre).ToList();
            }
        }

        public List<EmanetKitaplar> tamaminiGetir()
        {
            using (KutuphaneContext vt = new KutuphaneContext())
            {
               var emanetKitaplar = vt.Set<EmanetKitaplar>()
                     .Include(k => k.Kitap)
                     .Include(k => k.Uye)
                     .Include(k=>k.Yazar)
                        .ToList();
                return emanetKitaplar;
            }
        }

        public EmanetKitaplar tekilGetir(Func<EmanetKitaplar, bool> filtre)
        {
            using (KutuphaneContext vt = new KutuphaneContext())
            {
                return vt.Set<EmanetKitaplar>().SingleOrDefault(filtre);
            }
        }

        public EmanetKitaplar tekilGetir(int ID)
        {
            using (KutuphaneContext vt = new KutuphaneContext())
            {
                return vt.Set<EmanetKitaplar>().SingleOrDefault(o => o.ID == ID);
            }
        }

        public void TopluEkle(List<EmanetKitaplar> eklenecekListe)
        {
            using (KutuphaneContext vt = new KutuphaneContext())
            {
                foreach (EmanetKitaplar Eleman in eklenecekListe)
                {
                    vt.Entry(Eleman).State = EntityState.Added;
                }

                vt.SaveChanges();
            }
        }

        public void TopluSil(List<EmanetKitaplar> silinecekListe)
        {
            using (KutuphaneContext vt = new KutuphaneContext())
            {
                foreach (EmanetKitaplar Eleman in silinecekListe)
                {
                    vt.Entry(Eleman).State = EntityState.Deleted;
                }

                vt.SaveChanges();
            }
        }
    }
}
