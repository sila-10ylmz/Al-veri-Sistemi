using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Alisveris_Sistemi
{
    public partial class kesfet : Form
    {
        public kesfet()
        {
            InitializeComponent();
        }

        Veritabani vtn = new Veritabani();
        void yukle_kategori()
        {
            vtn.bag.Open();
            MySqlCommand islem = new MySqlCommand("select * from kategori", vtn.bag);
            MySqlDataReader oku = islem.ExecuteReader();
            comboBox1.Items.Add("Tümü");
            while (oku.Read()) // Giriş Başarılıysa döngü çalışır
            {
                comboBox1.Items.Add(oku["kadi"]);

            }


            vtn.bag.Close();


        }



        void urunler()
        {
            listView1.Clear();
            vtn.bag.Open();
            MySqlCommand islem = new MySqlCommand("select * from urunler order by RAND()", vtn.bag);
            MySqlDataReader oku = islem.ExecuteReader();
            while (oku.Read()) // Giriş Başarılıysa döngü çalışır
            {
                int x = (int)oku["urun_resm_id"];
                listView1.Items.Add(new ListViewItem { ImageIndex = x, Text = oku["urun_adi"].ToString() + " / " + oku["id"] });



            }

            vtn.bag.Close();

            comboBox1.Text = comboBox1.Items[0].ToString();
        }


        void urunler_kategori_sec()
        {
            if (comboBox1.Text == "Tümü")
            {
                urunler();


            }
            else
            {
                listView1.Clear();
                vtn.bag.Open();
                MySqlCommand islem = new MySqlCommand("select * from urunler where urun_kat='" + comboBox1.Text + "'", vtn.bag);
                MySqlDataReader oku = islem.ExecuteReader();
                while (oku.Read()) // Giriş Başarılıysa döngü çalışır
                {
                    int x = (int)oku["urun_resm_id"];
                    listView1.Items.Add(new ListViewItem { ImageIndex = x, Text = oku["urun_adi"].ToString() + " / " + oku["id"] });



                }

                vtn.bag.Close();
            }


        }
        private void kesfet_Load(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            yukle_kategori();
            urunler();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            urunler_kategori_sec();
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {




            listView1.Clear();
            vtn.bag.Open();
            MySqlCommand islem = new MySqlCommand("select * from urunler where urun_adi LIKE'%" + textBox1.Text + "%'", vtn.bag);
            MySqlDataReader oku = islem.ExecuteReader();
            while (oku.Read()) // Giriş Başarılıysa döngü çalışır
            {
                int x = (int)oku["urun_resm_id"];
                listView1.Items.Add(new ListViewItem { ImageIndex = x, Text = oku["urun_adi"].ToString()+" / "+oku["id"] });


            }

            vtn.bag.Close();


        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                // Sağ tık olayı yapımı
                if (listView1.FocusedItem.Bounds.Contains(e.Location) == true & listView1.FocusedItem.Bounds.Contains(e.Location) != null)
                {
                    contextMenuStrip1.Show(Cursor.Position);
                }
            }
        }

        private void fAVORİLEREEKLEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fav_ekle();
        }

        private void sEPETEEKLEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sepet();
        }

       void fav_ekle(){

             
            if (listView1.SelectedItems.Count != 0)
            {
  
            

        string[] trim =   listView1.SelectedItems[0].Text.Split('/');
                int s_id=Convert.ToInt32(trim[1].Trim());

                if (vtn.fav_ekle(Form1.frm.kullanici_id, s_id) == 1)
            {

                MessageBox.Show("Favorilere eklendi.");
            }

           }
        }
        void sepet()
        {

            if (listView1.SelectedItems.Count != 0)
            {

                string[] trim = listView1.SelectedItems[0].Text.Split('/');
                int s_id = Convert.ToInt32(trim[1].Trim());

                if (vtn.sepet_ekle(Form1.frm.kullanici_id, s_id) == 1)
                {

                    MessageBox.Show("Ürün Sepete eklendi.");
                }

            }
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 0)
            {
                groupBox1.Visible = true;
                string[] trim = listView1.SelectedItems[0].Text.Split('/');
                int s_id = Convert.ToInt32(trim[1].Trim());
                vtn.bag.Open();
                MySqlCommand islem = new MySqlCommand("select * from urunler where id='" + s_id + "'", vtn.bag);
                MySqlDataReader oku = islem.ExecuteReader();
                if (oku.Read()) // Giriş Başarılıysa döngü çalışır
                {
                    label1.Text = oku["urun_adi"].ToString();
                    label2.Text = oku["urun_kat"].ToString();
                    label3.Text = oku["aciklama"].ToString();
                    label4.Text = oku["urun_fiyat"].ToString() + " TL";




                }

                vtn.bag.Close();
            }
            else
            {
                groupBox1.Visible = false;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            sepet();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fav_ekle();
        }

    }
}
