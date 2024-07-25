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
    public class KullaniciDAL : VtIslemleriI<Kullanicilar>
    {
        public void Ekle(Kullanicilar kayit)
        {
            using (KutuphaneContext vt = new KutuphaneContext())
            {
                var eklenecekKayit = vt.Entry(kayit);
                eklenecekKayit.State = EntityState.Added;
                vt.SaveChanges();
            }
        }

        public void Guncelle(Kullanicilar kayit)
        {
            using (KutuphaneContext vt = new KutuphaneContext())
            {
                var guncellenecekKayit = vt.Entry(kayit);
                guncellenecekKayit.State = EntityState.Modified;
                vt.SaveChanges();
            }
        }

        public void Sil(Kullanicilar kayit)
        {
            using (KutuphaneContext vt = new KutuphaneContext())
            {
                var silinecekKayit = vt.Entry(kayit);
                silinecekKayit.State = EntityState.Deleted;
                vt.SaveChanges();
            }
        }

        public List<Kullanicilar> sorgula(Func<Kullanicilar, bool> filtre = null)
        {
            using (KutuphaneContext vt = new KutuphaneContext())
            {
                return filtre == null ? vt.Set<Kullanicilar>().ToList() : vt.Set<Kullanicilar>().Where(filtre).ToList();
            }
        }

        public List<Kullanicilar> tamaminiGetir()
        {
            using (KutuphaneContext vt = new KutuphaneContext())
            {
                return vt.Set<Kullanicilar>().ToList();
            }
        }

        public Kullanicilar tekilGetir(Func<Kullanicilar, bool> filtre)
        {
            using (KutuphaneContext vt = new KutuphaneContext())
            {
                return vt.Set<Kullanicilar>().SingleOrDefault(filtre);
            }
        }

        public Kullanicilar tekilGetir(int ID)
        {
            using (KutuphaneContext vt = new KutuphaneContext())
            {
                return vt.Set<Kullanicilar>().SingleOrDefault(o => o.ID == ID);
            }
        }

        public void TopluEkle(List<Kullanicilar> eklenecekListe)
        {
            using (KutuphaneContext vt = new KutuphaneContext())
            {
                foreach (Kullanicilar Eleman in eklenecekListe)
                {
                    vt.Entry(Eleman).State = EntityState.Added;
                }

                vt.SaveChanges();
            }
        }

        public void TopluSil(List<Kullanicilar> silinecekListe)
        {
            using (KutuphaneContext vt = new KutuphaneContext())
            {
                foreach (Kullanicilar Eleman in silinecekListe)
                {
                    vt.Entry(Eleman).State = EntityState.Deleted;
                }

                vt.SaveChanges();
            }
        }
    }
}
