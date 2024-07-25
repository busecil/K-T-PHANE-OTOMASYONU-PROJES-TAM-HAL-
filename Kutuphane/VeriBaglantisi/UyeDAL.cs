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
    public class UyeDAL : VtIslemleriI<Uye>
    {
        public void Ekle(Uye kayit)
        {
            using (KutuphaneContext vt = new KutuphaneContext())
            {
                var eklenecekKayit = vt.Entry(kayit);
                eklenecekKayit.State = EntityState.Added;
                vt.SaveChanges();
            }
        }

        public void Guncelle(Uye kayit)
        {
            using (KutuphaneContext vt = new KutuphaneContext())
            {
                var guncellenecekKayit = vt.Entry(kayit);
                guncellenecekKayit.State = EntityState.Modified;
                vt.SaveChanges();
            }
        }

        public void Sil(Uye kayit)
        {
            using (KutuphaneContext vt = new KutuphaneContext())
            {
                var silinecekKayit = vt.Entry(kayit);
                silinecekKayit.State = EntityState.Deleted;
                vt.SaveChanges();
            }
        }

        public List<Uye> sorgula(Func<Uye, bool> filtre = null)
        {
            using (KutuphaneContext vt = new KutuphaneContext())
            {
                return filtre == null ? vt.Set<Uye>().ToList() : vt.Set<Uye>().Where(filtre).ToList();
            }
        }

        public List<Uye> tamaminiGetir()
        {
            using (KutuphaneContext vt = new KutuphaneContext())
            {
                return vt.Set<Uye>().ToList();
            }
        }

        public Uye tekilGetir(Func<Uye, bool> filtre)
        {
            using (KutuphaneContext vt = new KutuphaneContext())
            {
                return vt.Set<Uye>().SingleOrDefault(filtre);
            }
        }

        public Uye tekilGetir(int ID)
        {
            using (KutuphaneContext vt = new KutuphaneContext())
            {
                return vt.Set<Uye>().SingleOrDefault(o => o.ID == ID);
            }
        }

        public void TopluEkle(List<Uye> eklenecekListe)
        {
            using (KutuphaneContext vt = new KutuphaneContext())
            {
                foreach (Uye Eleman in eklenecekListe)
                {
                    vt.Entry(Eleman).State = EntityState.Added;
                }

                vt.SaveChanges();
            }
        }

        public void TopluSil(List<Uye> silinecekListe)
        {
            using (KutuphaneContext vt = new KutuphaneContext())
            {
                foreach (Uye Eleman in silinecekListe)
                {
                    vt.Entry(Eleman).State = EntityState.Deleted;
                }

                vt.SaveChanges();
            }
        }
    }
}
