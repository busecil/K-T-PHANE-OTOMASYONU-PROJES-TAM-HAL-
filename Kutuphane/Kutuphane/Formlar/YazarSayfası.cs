
using Islemler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Varliklar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace Kutuphane.Formlar
{
    public partial class YazarSayfası : Form
    {
        private YazarIslemleri oi;
        private List<Yazar> al;
        private Islemler.KitapIslemleri kitap;
        private List<Kitap> kitaplar;
        public YazarSayfası()
        {
            if (al == null) al = new List<Yazar>();
            if (oi == null) oi = new YazarIslemleri();
            if (kitaplar == null) kitaplar = new List<Kitap>();
            if (kitap == null) kitap = new Islemler.KitapIslemleri();
            InitializeComponent();
        }
        
        private void YazarSayfası_Load(object sender, EventArgs e)
        {
           

            yukle();

        }

        private void yukle()
        {
            al = oi.tamaminiGetir().OrderBy(p => p.YazarID).ToList();
            dataGridView1.DataSource = al;
            dataGridView1.Columns[0].Visible = false;
           
        }

        // buradaki metod girddeki kaydın birine  çift tıkladığımızda o kaydın index indeki id yi alarak işlem yapıyor.
        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (i >= 0 && i < dataGridView1.Rows.Count)
            {
                DataGridViewRow secilen = dataGridView1.Rows[i];

                object[] veri = secilen.Cells.Cast<DataGridViewCell>().Select(x => x.Value).ToArray();
                textBox2.Text = veri[1].ToString();  

            }
        }

        
        private void button3_Click(object sender, EventArgs e)
        {
           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
          
        }
        void arayuzdenVeriYukle()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = al;
            dataGridView1.Columns[0].Visible = false;
        }

        private void temizle()
        {
           
                textBox2.Clear();
           
        }

        
        private void button4_Click(object sender, EventArgs e)
        {
            


        }

        private void button5_Click(object sender, EventArgs e)
        {
          
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text.Length == 0)
            {
                yukle();
            }
            else
            {
                List<Yazar> gl = oi.sorgula(o => o.YazarAdSoyad.Contains(textBox3.Text) || o.YazarAdSoyad.ToLower().Contains(textBox3.Text.ToLower())
                || o.YazarAdSoyad.ToLower().Contains(textBox3.Text.ToLower()));
                dataGridView1.DataSource = gl;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("Boş Kayıt Eklenemez");
                return;
            }
            Yazar o = new Yazar();
            o.YazarAdSoyad = textBox2.Text;
            al.Add(o);
            oi.Ekle(o);
            arayuzdenVeriYukle();
            temizle();

        }

        private void button8_Click(object sender, EventArgs e)
        {

            DataGridViewRow secilenSatir = dataGridView1.SelectedRows[0];
            if (secilenSatir != null)
            {
                DialogResult dialogResult = MessageBox.Show("Yazarı silmek istediğinizden emin misiniz?", "Yazar Silme İşlemi", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(secilenSatir.Cells[0].Value);
                    Yazar so = al.Where(o => o.YazarID == id).FirstOrDefault();


                    kitaplar = kitap.tamaminiGetir();

                    var yazarVarMi = kitaplar.Any(k => k.YazarID == id);

                    if (yazarVarMi)
                    {
                        DialogResult dialogResult2 = MessageBox.Show("Silmek istenilen yazara ait kitaplar var yine de silinsin mi ?", "Yazar Silme İşlemi", MessageBoxButtons.YesNo);
                        if (dialogResult2 == DialogResult.Yes)
                        {
                            if (so != null)
                            {

                                oi.Sil(so);
                                al.Remove(so);
                                arayuzdenVeriYukle();
                                temizle();
                            }
                            else
                            {
                                MessageBox.Show("Yazar Bulunamadığından Silinemedi");
                            }
                        }
                        else if (dialogResult == DialogResult.No)
                        {

                        }
                    }
                    else
                    {
                        if (so != null)
                        {
                            oi.Sil(so);
                            al.Remove(so);
                            arayuzdenVeriYukle();
                            temizle();
                        }
                        else
                        {
                            MessageBox.Show("Yazar Bulunamadığından Silinemedi");
                        }
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

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("Boş Kayıt Güncellenemez");
                return;
            }
            DataGridViewRow secilenSatir = dataGridView1.SelectedRows[0];
            if (secilenSatir != null && textBox2.Text != "")
            {
                int id = Convert.ToInt32(secilenSatir.Cells[0].Value);
                Yazar go = al.Where(o => o.YazarID == id).FirstOrDefault();
                if (go != null)
                {
                    go.YazarAdSoyad = textBox2.Text;
                    oi.Guncelle(go);
                    //al.Add(go);
                    arayuzdenVeriYukle();
                    temizle();
                }
                else
                {
                    MessageBox.Show("Yazar Bulunamadığından Güncellenemedi");
                }
            }
            else
            {
                MessageBox.Show("Veriler Hatalı Formatta OLduğundan Güncellenemedi");
            }

            temizle();
        }

        private void button6_Click(object sender, EventArgs e)
        {

            KitapIslemleri kitapIslemleri = (KitapIslemleri)Application.OpenForms["KitapIslemleri"];
            if (kitapIslemleri != null)
            {
                kitapIslemleri.label1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                kitapIslemleri.textBox4.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                this.Close();
            }
            else
            {
                EmanetKitaplar emanetKitaplar = (EmanetKitaplar)Application.OpenForms["EmanetKitaplar"];
                emanetKitaplar.label12.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                emanetKitaplar.textBox3.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                this.Close();
            }


        }

      
        private void YazarSayfası_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                textBox2.Clear();
                textBox3.Clear();


            }
        }
    }
}
