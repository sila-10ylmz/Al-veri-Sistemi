using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alisveris_Sistemi
{
    public partial class admin_anasayfa : Form
    {

        public static admin_anasayfa anf;

        Veritabani vtn = new Veritabani();

        public admin_anasayfa()
        {
            InitializeComponent();
            yukle_kategori();
            yukle_urun();
            yukle_siparis();
            yukle_kullanici();
            anf = this;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            kategori_ekle ktn = new kategori_ekle();

            ktn.ShowDialog();
        }


        void yukle_siparis()
        {
            listBox3.Items.Clear();
            ArrayList arr = new ArrayList();
            arr.Clear();
            vtn.bag.Open();
            MySqlCommand islem = new MySqlCommand("select * from siparisler ", vtn.bag);
            MySqlDataReader oku = islem.ExecuteReader();
            while (oku.Read()) // Giriş Başarılıysa döngü çalışır
            {
                if (!arr.Contains(oku["u_id"]))
                    arr.Add(oku["u_id"]);

            }

            vtn.bag.Close();


            for (int i = 0; i < arr.Count; i++)
            {

                vtn.bag.Open();
                MySqlCommand islem2 = new MySqlCommand("select * from urunler  where id='" + arr[i].ToString() + "'", vtn.bag);
                MySqlDataReader oku2 = islem2.ExecuteReader();
                if (oku2.Read())
                {
                    int x = (int)oku2["urun_resm_id"];
                    listBox3.Items.Add(oku2["urun_adi"].ToString() + " / " + oku2["id"]);

                }

                vtn.bag.Close();




            }
            label6.Text = "Toplam Siparis = " + listBox3.Items.Count.ToString();

        }
        public void yukle_urun()
        {
            listBox2.Items.Clear();
            vtn.bag.Open();
            MySqlCommand islem = new MySqlCommand("select * from urunler", vtn.bag);
            MySqlDataReader oku = islem.ExecuteReader();
            while (oku.Read()) // Giriş Başarılıysa döngü çalışır
            {
                listBox2.Items.Add(oku["urun_adi"]+" / "+oku["id"]);

            }

            vtn.bag.Close();
            label5.Text = "Toplam urun = "+listBox2.Items.Count.ToString();

        }


        public void yukle_kategori()
        {
            listBox1.Items.Clear();
            vtn.bag.Open();
            MySqlCommand islem = new MySqlCommand("select * from kategori", vtn.bag);
            MySqlDataReader oku = islem.ExecuteReader();
            while (oku.Read()) // Giriş Başarılıysa döngü çalışır
            {
                listBox1.Items.Add(oku["kadi"]);

            }

            vtn.bag.Close();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                if (vtn.kategori_silme(listBox1.SelectedItem.ToString()) == 1)
                {
                    listBox1.Items.Remove(listBox1.SelectedItem);

                }

                

            }
            catch (Exception ex)
            {

            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedItems.Count != 0)
            {

                string[] trim = listBox2.SelectedItems[0].ToString().Split('/');
                int s_id = Convert.ToInt32(trim[1].Trim());

                if (vtn.urun_cikar(s_id) == 1)
                {
                    yukle_urun();
                    MessageBox.Show("Ürünlerden Çıkarıldı");

                }

            }
        }


        public void yukle_kullanici()
        {
            listBox4.Items.Clear();
            vtn.bag.Open();
            MySqlCommand islem = new MySqlCommand("select * from uyeler", vtn.bag);
            MySqlDataReader oku = islem.ExecuteReader();
            while (oku.Read()) // Giriş Başarılıysa döngü çalışır
            {
                listBox4.Items.Add(oku["adi"] + "  " + oku["soyadi"]);

            }

            vtn.bag.Close();
            label7.Text = "Toplam kullanıcı = " + listBox4.Items.Count.ToString();

        }

        private void button4_Click(object sender, EventArgs e)
        {

            
        }


    }
}
