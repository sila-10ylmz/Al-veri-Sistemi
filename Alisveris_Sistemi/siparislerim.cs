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
    public partial class siparislerim : Form
    {
        public siparislerim()
        {
            InitializeComponent();

            listView1.GridLines = true;
            listView1.AllowColumnReorder = true;
            listView1.LabelEdit = true;
            listView1.FullRowSelect = true;
            listView1.Sorting = SortOrder.Ascending;
            listView1.View = View.Details;
        }
        Veritabani vtn = new Veritabani();


        void liste()
        {

            ListBox arr = new ListBox();
            arr.Items.Clear();
            vtn.bag.Open();
            MySqlCommand islem = new MySqlCommand("select * from siparisler where k_id='" + Form1.frm.kullanici_id.ToString() + "'", vtn.bag);
            MySqlDataReader oku = islem.ExecuteReader();
            while (oku.Read()) // Giriş Başarılıysa döngü çalışır
            {
             arr.Items.Add(oku["u_id"]);

            }

            vtn.bag.Close();


  
            for (int i = 0; i < arr.Items.Count; i++)
            {
                
                    vtn.bag.Open();
                    string sql = "Select * from urunler where id='" + arr.Items[i] + "'";
                    MySqlCommand cmd = new MySqlCommand(sql, vtn.bag);
                    MySqlDataReader Reader = cmd.ExecuteReader();

                    while (Reader.Read())
                    {


                        ListViewItem lv = new ListViewItem(Reader["urun_adi"].ToString());
                        lv.SubItems.Add(Reader["urun_kat"].ToString());
                        lv.SubItems.Add(Reader["urun_fiyat"].ToString()+" TL");
                        lv.SubItems.Add(Reader["aciklama"].ToString());
                        lv.SubItems.Add(Reader["id"].ToString());
                        listView1.Items.Add(lv);
                    }
                    Reader.Close();
                    cmd.Dispose();
                    vtn.bag.Close();


                
              
            }
        


        }

        private void siparislerim_Load(object sender, EventArgs e)
        {
            liste();
        }

    }
}
