using Islemler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Varliklar;
using VeriBaglantisi;

namespace Kutuphane.Formlar
{
    public partial class KayitOl : Form
    {
        private KullaniciIslemleri ki;
        private List<Kullanicilar> al;
        public KayitOl()
        {
            ki = new KullaniciIslemleri();
            al = new List<Kullanicilar>();
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Kullanicilar k = new Kullanicilar();
            if (textBox1.Text != "" || textBox2.Text != "" || textBox3.Text != "")
            {
                k.KullaniciAdi = textBox3.Text;
                k.EPosta = textBox1.Text;
                k.Sifre = textBox2.Text;
                ki.Ekle(k);
                temizle();
                label5.Text = "Kayıt Başarılı";


            }
            else
            {
                label5.Text = "Boş Bırakılamaz";
            }
        }
        private void temizle()
        {
            label5.Text = "";
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void KayitOl_Load(object sender, EventArgs e)
        {

        }
    }
}
