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
    public class EmanetKitapIslemler : VtIslemleriI<EmanetKitaplar>
    {
        private EmanetKitapDAL emanetKitapDAL;
        public EmanetKitapIslemler()
        {
            if (emanetKitapDAL == null)
            {
                emanetKitapDAL = new EmanetKitapDAL();
            }
        }
        public void Ekle(EmanetKitaplar kayit)
        {
            emanetKitapDAL.Ekle(kayit);
        }

        public void Guncelle(EmanetKitaplar kayit)
        {
            emanetKitapDAL.Guncelle(kayit);
        }

        public void Sil(EmanetKitaplar kayit)
        {
            emanetKitapDAL.Sil(kayit);
        }

        public List<EmanetKitaplar> sorgula(Func<EmanetKitaplar, bool> filtre)
        {
            return emanetKitapDAL.sorgula(filtre);
        }

        public List<EmanetKitaplar> tamaminiGetir()
        {
            return emanetKitapDAL.tamaminiGetir();
        }

        public EmanetKitaplar tekilGetir(Func<EmanetKitaplar, bool> filtre = null)
        {
            return emanetKitapDAL.tekilGetir(filtre);
        }

        public EmanetKitaplar tekilGetir(int ID)
        {
            return emanetKitapDAL.tekilGetir(ID);
        }

        public void TopluEkle(List<EmanetKitaplar> eklenecekListe)
        {
            emanetKitapDAL.TopluEkle(eklenecekListe);
        }

        public void TopluSil(List<EmanetKitaplar> silinecekListe)
        {
            emanetKitapDAL.TopluSil(silinecekListe);
        }
    }
}
