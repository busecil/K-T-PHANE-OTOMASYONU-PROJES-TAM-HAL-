using Islemler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Varliklar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Kutuphane.Formlar
{
    public partial class UyeEkle : Form
    {
        private UyeIslemler oi;
        private List<Uye> al;
        public UyeEkle()
        {
            if (al == null) al = new List<Uye>();
            if (oi == null) oi = new UyeIslemler();
            InitializeComponent();
            
        }

       

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {

        }

        private void UyeEkle_Load(object sender, EventArgs e)
        {
           
             yukle();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
        private byte[] ImageToByteArray(Image image)
        {
            using (var ms = new MemoryStream())
            {
                Bitmap bmp = new Bitmap(image);
                bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
            
        }
        public static Image ImageFromBytes(byte[] imageByte)
        {
            using (var ms = new MemoryStream(imageByte))
            {
                return Image.FromStream(ms);

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == ""
                || textBox6.Text == "" || maskedTextBox1.Text == "")
            {
                MessageBox.Show("Boş Kayıt Eklenemez");
                return;
            }
            
            Uye uye = new Uye()
            {
                Ad = textBox1.Text,
                Soyad = textBox2.Text,
                OgrenciNo = textBox3.Text,
                BolumKodu = textBox4.Text,
                Sinif = textBox5.Text,
                Eposta = textBox6.Text,
                TelefonNo = maskedTextBox1.Text,
                resim = ImageToByteArray(pictureBox1.Image)
            };
          
            al.Add(uye);
            oi.Ekle(uye);
            yukle();
            temizle();
        }
        void arayuzdenVeriYukle()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = al;
            dataGridView1.Columns[0].Visible = false;
        }

        private void temizle()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            maskedTextBox1.Clear(); 

        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataGridViewRow secilenSatir = dataGridView1.SelectedRows[0];
            if (secilenSatir != null)
            {
                DialogResult dialogResult = MessageBox.Show("Üyeyi silmek istediğinizden emin misiniz?", "Üye Silme İşlemi", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(secilenSatir.Cells[0].Value);
                    Uye so = al.Where(o => o.ID == id).FirstOrDefault();
                    if (so != null)
                    {

                        oi.Sil(so);
                        al.Remove(so);
                        yukle();
                        temizle();
                    }
                    else
                    {
                        MessageBox.Show("Üye Bulunamadığından Silinemedi");
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
        private void resimSutunAyarla()
        {
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[8].Visible = false;
            DataGridViewImageColumn resimSutun = new DataGridViewImageColumn();
            resimSutun.DataPropertyName = "resim";
            resimSutun.Width = 200;
            resimSutun.HeaderText = "Resim";
            resimSutun.ReadOnly = true;
            resimSutun.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridView1.Columns.Insert(8, resimSutun);
        }

        private void yukle()
        {
            al = oi.tamaminiGetir();

            dataGridView1.DataSource = al;
            dataGridView1.Columns[0].Visible = false;

            resimSutunAyarla();




        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == ""
               || textBox6.Text == "" || maskedTextBox1.Text == "")
            {
                MessageBox.Show("Boş Kayıt Güncellenemez!");
                return;
            }
            DataGridViewRow secilenSatir = dataGridView1.SelectedRows[0];
            if (secilenSatir != null)
            {
                int id = Convert.ToInt32(secilenSatir.Cells[0].Value);
                Uye go = oi.tekilGetir(id);

                if (go != null)
                {
                    go.Ad = textBox1.Text;
                    go.Soyad = textBox2.Text;
                    go.OgrenciNo = textBox3.Text;
                    go.BolumKodu = textBox4.Text;
                    go.Sinif = textBox5.Text;
                    go.Eposta = textBox6.Text;
                    go.TelefonNo = maskedTextBox1.Text;
                    go.resim = ImageToByteArray(pictureBox1.Image);
                    oi.Guncelle(go);
                    yukle();
                    temizle();
                  
                }
                else
                {
                    MessageBox.Show("Üye Bulunamadığından Güncellenemedi");
                }
            }
            else
            {
                MessageBox.Show("Veriler Hatalı Formatta Olduğundan Güncellenemedi");
            }

            temizle();
        }
       

       

        //resim ekleme
        private void button3_Click_2(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            openFileDialog1.Title = "Resim Seçiniz";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
            }
            
            
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (textBox7.Text.Length == 0)
            {
                yukle();
            }
            else
            {
                List<Uye> gl = oi.sorgula(o => o.Ad.ToLower().Contains(textBox7.Text.ToLower()) || o.Soyad.ToLower().Contains(textBox7.Text.ToLower()));
                
                dataGridView1.DataSource = gl;
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            EmanetKitaplar emanetKitaplar = (EmanetKitaplar)Application.OpenForms["EmanetKitaplar"];
            emanetKitaplar.label4.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            emanetKitaplar.textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            this.Close();
        }

        private void dataGridView1_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (i >= 0 && i < dataGridView1.Rows.Count)
            {
                DataGridViewRow secilen = dataGridView1.Rows[i];


                object[] veri = secilen.Cells.Cast<DataGridViewCell>().Select(x => x.Value).ToArray();
                textBox1.Text = veri[1].ToString();
                textBox2.Text = veri[2].ToString();
                textBox3.Text = veri[3].ToString();
                textBox4.Text = veri[4].ToString();
                textBox5.Text = veri[5].ToString();
                textBox6.Text = veri[6].ToString();
                maskedTextBox1.Text = veri[7].ToString();
                //pictureBox1.Image = veri[8];
                pictureBox1.Image = ImageFromBytes((byte[])veri[8]);

            }
        }

        private void UyeEkle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                maskedTextBox1.Clear();
            }
        }
    }
}
