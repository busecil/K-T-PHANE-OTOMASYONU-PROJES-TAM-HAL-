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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Kutuphane.Formlar
{
    public partial class FormGiris : Form
    {
        private Islemler.KullaniciIslemleri ki;
        private List<Kullanicilar> al;
        public FormGiris()
        {

            ki = new Islemler.KullaniciIslemleri();
            al = new List<Kullanicilar>();
            InitializeComponent();
        }

        private void FormGiris_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            KayitOl kayitOl = new KayitOl();
            kayitOl.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Kullanicilar k = new Kullanicilar();

            k = ki.tekilGetir(x => x.EPosta.Equals(textBox1.Text) && x.Sifre.Equals(textBox2.Text));
            if (k != null)
            {
                //Giriş Yapınca yapılacak işlem 
                Anasayfa anasayfa = new Anasayfa();
                anasayfa.ShowDialog();  
            }

            else
            {
                MessageBox.Show("Hatalı giriş veya şifre");
            }
        }
    }
}
