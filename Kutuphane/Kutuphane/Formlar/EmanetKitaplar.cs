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
    public partial class EmanetKitaplar : Form
    {
        private UyeIslemler uye;
        private List<Uye> uyelist;
        private Islemler.KitapIslemleri kitap;
        private List<Kitap> kitaplist;
        private Islemler.EmanetKitapIslemler emanetkitap;
        private List<Varliklar.EmanetKitaplar> emanetkitaplist;
        public EmanetKitaplar()
        {
            if (uyelist == null) uyelist = new List<Uye>();
            if (uye == null) uye = new UyeIslemler();
            if (kitaplist == null) kitaplist = new List<Kitap>();
            if (kitap == null) kitap = new Islemler.KitapIslemleri();
            if (emanetkitaplist == null) emanetkitaplist = new List<Varliklar.EmanetKitaplar>();
            if (emanetkitap == null) emanetkitap = new Islemler.EmanetKitapIslemler();
            InitializeComponent();
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            UyeEkle uye = new UyeEkle();
            uye.Show();
            this.Hide();
        }

        private void EmanetKitaplar_Load(object sender, EventArgs e)
        {
            yukle();
            uyelist = uye.tamaminiGetir();
            kitaplist = kitap.tamaminiGetir();

        }
        //ekle
        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void temizle()
        {

            
            textBox5.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            

            
        }
        private void yukle()
        {
            emanetkitaplist = emanetkitap.tamaminiGetir();

            var sonuc = emanetkitaplist
            .Select(k => new {
                ID = k.ID,
                UyeAdSoyad = k.Uye.Ad + " " + k.Uye.Soyad,
                KitapAdi = k.Kitap.KitapAdi,
                YazarAdSoyad = k.Yazar.YazarAdSoyad,
                GorevliAdi = k.GorevliAdi,  
                AlimTarihi = k.AlimTarihi,
                TeslimTarihi = k.TeslimTarihi,
                TeslimEdildiMi = k.TeslimEdildiMi == true ? "Evet": "Hayır",
                UyeID = k.UyeID,
                KitapID = k.KitapID,
                YazarID = k.YazarID
            }).OrderBy(p => p.KitapAdi).ToList();
            dataGridView1.DataSource = sonuc;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[9].Visible = false;
            dataGridView1.Columns[10].Visible = false;

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (i >= 0 && i < dataGridView1.Rows.Count)
            {
                DataGridViewRow secilen = dataGridView1.Rows[i];


                object[] veri = secilen.Cells.Cast<DataGridViewCell>().Select(x => x.Value).ToArray();
                textBox1.Text = veri[1].ToString();
                textBox2.Text = veri[2].ToString();
                textBox3.Text = veri[3].ToString();
                textBox5.Text = veri[4].ToString(); 
                dateTimePicker1.Value = Convert.ToDateTime(veri[5]);    
                dateTimePicker2.Value = Convert.ToDateTime(veri[6]);
                checkBox1.Checked = veri[7] == "Hayır" ?  false : true;
                label12.Text = veri[10].ToString();  
                label4.Text = veri[8].ToString();  
                label5.Text = veri[9].ToString();  
                
             
            }
        }
        // sil
        private void button2_Click(object sender, EventArgs e)
        {

        }

        

        //iade al
        private void button3_Click(object sender, EventArgs e)
        {
          
        }

        //Ara
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (textBox6.Text.Length == 0)
            {
                yukle();
            }
            else
            {
                List<Varliklar.EmanetKitaplar> gl = emanetkitap.sorgula(o => o.GorevliAdi.ToLower().Contains(textBox6.Text.ToLower())
                || o.Uye.Ad.ToLower().Contains(textBox6.Text.ToLower())
                || o.Kitap.KitapAdi.ToLower().Contains(textBox6.Text.ToLower()));

                var sonuc = gl
             .Select(k => new
             {
               
                 KitapAdi = k.Kitap.KitapAdi,
                 UyeAdSoyad = k.Uye.Ad + " " + k.Uye.Soyad,
                 GorevliAdi = k.GorevliAdi,
                 AlimTarihi = k.AlimTarihi,
                 TeslimTarihi = k.TeslimTarihi,
                 TeslimEdildiMi = k.TeslimEdildiMi,
              

             }).ToList();
                dataGridView1.DataSource = sonuc;
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click_2(object sender, EventArgs e)
        {
            YazarSayfası yazarSayfasi = new YazarSayfası();
            yazarSayfasi.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            KitapIslemleri kitapIslemleri = new KitapIslemleri();
            kitapIslemleri.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            UyeEkle uyeEkle = new UyeEkle();
            uyeEkle.ShowDialog();   
        }

        private void button10_Click(object sender, EventArgs e)
        {

            if (textBox5.Text == "")
            {
                MessageBox.Show("Boş Kayıt Eklenemez");
                return;
            }

            Varliklar.EmanetKitaplar o = new Varliklar.EmanetKitaplar();


            o.AlimTarihi = dateTimePicker1.Value;
            o.TeslimTarihi = dateTimePicker2.Value;
            o.GorevliAdi = textBox5.Text;
            o.KitapID = Convert.ToInt32(label5.Text);
            o.UyeID = Convert.ToInt32(label4.Text);
            o.YazarID = Convert.ToInt32(label12.Text);
            o.TeslimEdildiMi = false;
            emanetkitaplist.Add(o);
            emanetkitap.Ekle(o);
            yukle();
            temizle();
        }

        private void button9_Click(object sender, EventArgs e)
        {

            DataGridViewRow secilenSatir = dataGridView1.SelectedRows[0];
            if (secilenSatir != null)
            {
                DialogResult dialogResult = MessageBox.Show("Emanet Verilen kaydı silmek istediğinizden emin misiniz?", "Emanet Kitap Silme İşlemi", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(secilenSatir.Cells[0].Value);
                    Varliklar.EmanetKitaplar so = emanetkitaplist.Where(o => o.ID == id).FirstOrDefault();
                    if (so != null)
                    {

                        emanetkitap.Sil(so);
                        emanetkitaplist.Remove(so);
                        yukle();
                        temizle();
                    }
                    else
                    {
                        MessageBox.Show("Emanet Kitap Bulunamadığından Silinemedi");
                    }
                }
                else if (dialogResult == DialogResult.No)
                {

                }

            }
            else
            {

                MessageBox.Show("Önce Silinecek Kaydı Seçiniz");

            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox5.Text == ""
             )
            {
                MessageBox.Show("Boş Kayıt Güncellenemez!");
                return;
            }
            DataGridViewRow secilenSatir = dataGridView1.SelectedRows[0];
            if (secilenSatir != null)
            {
                int id = Convert.ToInt32(secilenSatir.Cells[0].Value);
                Varliklar.EmanetKitaplar go = emanetkitap.tekilGetir(id);

                if (go != null)
                {
                    go.AlimTarihi = dateTimePicker1.Value;
                    go.TeslimTarihi = dateTimePicker2.Value;
                    go.GorevliAdi = textBox5.Text;
                    go.KitapID = Convert.ToInt32(label5.Text);
                    go.UyeID = Convert.ToInt32(label4.Text);
                    go.YazarID = Convert.ToInt32(label12.Text);
                    go.TeslimEdildiMi = checkBox1.Checked;

                    emanetkitap.Guncelle(go);
                    yukle();
                    temizle();
                }
                else
                {
                    MessageBox.Show("Emanet Kitap Bulunamadığından Güncellenemedi");
                }
            }
            else
            {
                MessageBox.Show("Veriler Hatalı Formatta Olduğundan Güncellenemedi");
            }

            temizle();
        }

        private void EmanetKitaplar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox5.Clear();
          
               
            }

        }
    }
}
