using InterFaceler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Varliklar;
using VeriBaglantisi;

namespace Islemler
{
    public class KullaniciIslemleri : VtIslemleriI<Kullanicilar>
    {
        private KullaniciDAL kullaniciDAL;
        public KullaniciIslemleri()
        {
            if (kullaniciDAL == null)
            {
                kullaniciDAL = new KullaniciDAL();
            }
        }
        public void Ekle(Kullanicilar kayit)
        {
            kullaniciDAL.Ekle(kayit);
        }

        public void Guncelle(Kullanicilar kayit)
        {
            kullaniciDAL.Guncelle(kayit);
        }

        public void Sil(Kullanicilar kayit)
        {
            kullaniciDAL.Sil(kayit);
        }

        public List<Kullanicilar> sorgula(Func<Kullanicilar, bool> filtre)
        {
            return kullaniciDAL.sorgula(filtre);
        }

        public List<Kullanicilar> tamaminiGetir()
        {
            return kullaniciDAL.tamaminiGetir();
        }

        public Kullanicilar tekilGetir(Func<Kullanicilar, bool> filtre = null)
        {
            return kullaniciDAL.tekilGetir(filtre);
        }

        public Kullanicilar tekilGetir(int ID)
        {
            return kullaniciDAL.tekilGetir(ID);
        }

        public void TopluEkle(List<Kullanicilar> eklenecekListe)
        {
            kullaniciDAL.TopluEkle(eklenecekListe);
        }

        public void TopluSil(List<Kullanicilar> silinecekListe)
        {
            kullaniciDAL.TopluSil(silinecekListe);
        }
    }
}
