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
    public partial class trendler : Form
    {
        public trendler()
        {
            InitializeComponent();
        }

        Veritabani vtn = new Veritabani();

        void yukle_trend()
        {
            listView1.Items.Clear();
            ArrayList arr = new ArrayList();
            arr.Clear();
            vtn.bag.Open();
            MySqlCommand islem = new MySqlCommand("select * from fav ", vtn.bag);
            MySqlDataReader oku = islem.ExecuteReader();
            while (oku.Read()) // Giriş Başarılıysa döngü çalışır
            {
                if (!arr.Contains(oku["s_id"]))
                    arr.Add(oku["s_id"]);

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
                    listView1.Items.Add(new ListViewItem { ImageIndex = x, Text = oku2["urun_adi"].ToString() + " / " + oku2["id"] });

                }

                vtn.bag.Close();




            }

        }

        private void trendler_Load(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            yukle_trend();
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 0)
            {



                string[] trim = listView1.SelectedItems[0].Text.Split('/');
                int s_id = Convert.ToInt32(trim[1].Trim());

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

        private void button1_Click(object sender, EventArgs e)
        {
            sepet();
        }




    }
}
