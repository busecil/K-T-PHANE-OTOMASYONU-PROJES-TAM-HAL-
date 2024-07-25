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
    public class UyeIslemler : VtIslemleriI<Uye>
    {
        private UyeDAL uyeDAL;
        public UyeIslemler()
        {
            if (uyeDAL == null)
            {
                uyeDAL = new UyeDAL();
            }
        }
        public void Ekle(Uye kayit)
        {
            uyeDAL.Ekle(kayit);
        }

        public void Guncelle(Uye kayit)
        {
            uyeDAL.Guncelle(kayit);
        }

        public void Sil(Uye kayit)
        {
            uyeDAL.Sil(kayit);
        }

        public List<Uye> sorgula(Func<Uye, bool> filtre)
        {
            return uyeDAL.sorgula(filtre);
        }

        public List<Uye> tamaminiGetir()
        {
            return uyeDAL.tamaminiGetir();
        }

        public Uye tekilGetir(Func<Uye, bool> filtre = null)
        {
            return uyeDAL.tekilGetir(filtre);
        }

        public Uye tekilGetir(int ID)
        {
            return uyeDAL.tekilGetir(ID);
        }

        public void TopluEkle(List<Uye> eklenecekListe)
        {
            uyeDAL.TopluEkle(eklenecekListe);
        }

        public void TopluSil(List<Uye> silinecekListe)
        {
            uyeDAL.TopluSil(silinecekListe);
        }
    }
}
