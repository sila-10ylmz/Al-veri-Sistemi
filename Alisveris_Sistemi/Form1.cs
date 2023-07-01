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
    public partial class Form1 : Form
    {
       public MySqlConnection bag = new MySqlConnection("Server=localhost;Database=mobilya;Uid=root;Pwd=;");
       public static Form1 frm;
       public int kullanici_id;
        public Form1()
        {
            InitializeComponent();
            label10.Hide();
            button1.Visible = false;


            gizleme_giris(0);
            frm = this;
        }





        #region Gereksiz Kodlar


        void gizleme_giris(int x)
        {
            if (x==0)// Gizle
            {

                label9.Visible = false;
                label11.Visible = false;
                label12.Visible = false;
                label13.Visible = false;
                label14.Visible = false;
                label15.Visible = false;
                label16.Visible = false;
            }
            else if (x == 1)
            {
                label9.Visible = true;
                label11.Visible = true;
                label12.Visible = true;
                label13.Visible = true;
                label14.Visible = true;
                label15.Visible = true;
                label16.Visible = true;

            }

        }

        private void pictureBox6_Click(object sender, EventArgs e) //kayıt butonu kayıt sayfası aç
        {
            panel2.Controls.Clear();
            kayit f1 = new kayit();
            f1.TopLevel = false;
            panel2.Controls.Add(f1);
            f1.Show();
            f1.Dock = DockStyle.Fill;
            f1.BringToFront();
        }
        //bu kısım büyüme küçülme efekti için
        private void pictureBox2_MouseHover(object sender, EventArgs e) //büyüme küçülme etkilerini normale döndürüyoruz
        {
            pictureBox6.Width = 33;
            pictureBox6.Height = 50;

            label11.Font = new Font("Sitka Heading", 9);

            label12.Font = new Font("Sitka Heading", 9);

            label13.Font = new Font("Sitka Heading", 9);

            label14.Font = new Font("Sitka Heading", 9);

            label15.Font = new Font("Sitka Heading", 9);

            label16.Font = new Font("Sitka Heading", 9);
        }

        private void pictureBox15_MouseHover(object sender, EventArgs e)
        {
            pictureBox6.Width = 33;
            pictureBox6.Height = 50;

            label11.Font = new Font("Sitka Heading", 9);

            label12.Font = new Font("Sitka Heading", 9);

            label13.Font = new Font("Sitka Heading", 9);

            label14.Font = new Font("Sitka Heading", 9);

            label15.Font = new Font("Sitka Heading", 9);

            label16.Font = new Font("Sitka Heading", 9);
        }

        private void pictureBox6_MouseHover(object sender, EventArgs e)//kayıt butonunu büyütme 3 birim
        {
            pictureBox6.Width = 36;
            pictureBox6.Height = 53;
        }

        private void label11_MouseHover(object sender, EventArgs e)
        {
            label11.Font = new Font("Sitka Heading", 11);
        }

        private void label12_MouseHover(object sender, EventArgs e)
        {
            label12.Font = new Font("Sitka Heading", 11);
        }

        private void label13_MouseHover(object sender, EventArgs e)
        {
            label13.Font = new Font("Sitka Heading", 11);
        }

        private void label14_MouseHover(object sender, EventArgs e)
        {
            label14.Font = new Font("Sitka Heading", 11);
        }

        private void label15_MouseHover(object sender, EventArgs e)
        {
            label15.Font = new Font("Sitka Heading", 11);
        }

        private void label16_MouseHover(object sender, EventArgs e)
        {
            label16.Font = new Font("Sitka Heading", 11);
        }

        private void label9_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            panel_ana_sayfa f1 = new panel_ana_sayfa();
            f1.TopLevel = false;
            panel2.Controls.Add(f1);
            f1.Show();
            f1.Dock = DockStyle.Fill;
            f1.BringToFront();
        }

        void start_panel()
        {


            panel2.Controls.Clear();
            panel_ana_sayfa f1 = new panel_ana_sayfa();
            f1.TopLevel = false;
            panel2.Controls.Add(f1);
            f1.Show();
            f1.Dock = DockStyle.Fill;
            f1.BringToFront();


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            start_panel();
 
        }

        private void label11_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            sepet f1 = new sepet();
            f1.TopLevel = false;
            panel2.Controls.Add(f1);
            f1.Show();
            f1.Dock = DockStyle.Fill;
            f1.BringToFront();
        }

        private void label12_Click(object sender, EventArgs e)
        {

            panel2.Controls.Clear();
            trendler f1 = new trendler();
            f1.TopLevel = false;
            panel2.Controls.Add(f1);
            f1.Show();
            f1.Dock = DockStyle.Fill;
            f1.BringToFront();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            favoriler f1 = new favoriler();
            f1.TopLevel = false;
            panel2.Controls.Add(f1);
            f1.Show();
            f1.Dock = DockStyle.Fill;
            f1.BringToFront();
        }

        private void label14_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            siparislerim f1 = new siparislerim();
            f1.TopLevel = false;
            panel2.Controls.Add(f1);
            f1.Show();
            f1.Dock = DockStyle.Fill;
            f1.BringToFront();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            kesfet f1 = new kesfet();
            f1.TopLevel = false;
            panel2.Controls.Add(f1);
            f1.Show();
            f1.Dock = DockStyle.Fill;
            f1.BringToFront();
        }


        private void label16_Click(object sender, EventArgs e)
        {

            panel2.Controls.Clear();
            profilim f1 = new profilim();
            f1.TopLevel = false;
            panel2.Controls.Add(f1);
            f1.Show();
            f1.Dock = DockStyle.Fill;
            f1.BringToFront();

            bag.Open();
            MySqlCommand komut = new MySqlCommand("select * from uyeler where kadi='" + textBoxkullaniciadi.Text + "' and sifre='" + textBoxsifre.Text + "' ", bag);
            MySqlDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {

                f1.textBox1.Text = (oku["adi"]).ToString();
                f1.textBox2.Text = (oku["soyadi"]).ToString();
                f1.textBox3.Text = (oku["kadi"]).ToString();
                f1.textBox4.Text = (oku["tel"]).ToString();
                f1.textBox5.Text = (oku["mail"]).ToString();
                f1.textBox6.Text = (oku["adres"]).ToString();

                f1.label7.Text = (oku["id"]).ToString();

            }
            bag.Close();
        }
        #endregion


        private void pictureBoxgiris_Click(object sender, EventArgs e)
        {



            bag.Open();
            MySqlCommand komut = new MySqlCommand("select * from uyeler where kadi='" + textBoxkullaniciadi.Text + "' and sifre='" + textBoxsifre.Text + "' ", bag);
            MySqlDataReader oku = komut.ExecuteReader();
            if (oku.Read()) // Giriş Başarılıysa döngü çalışır
            {
                kullanici_id = (int)oku["id"];
                pictureBox6.Visible = false;
                gizleme_giris(1);
                panel1.Visible = true;
                label5.Text = oku["adi"].ToString();
                label7.Text = oku["soyadi"].ToString();
                label6.Text = oku["kadi"].ToString();
                label8.Text = oku["mail"].ToString();

                int yetki = (int)oku["yetki"];
                if (yetki == 1)// Admin Girişi 
                {

                    button1.Visible = true; 

                    panel2.Controls.Clear();
                    admin_anasayfa f1 = new admin_anasayfa();
                    f1.TopLevel = false;
                    panel2.Controls.Add(f1);
                    f1.Show();
                    f1.Dock = DockStyle.Fill;
                    f1.BringToFront();
                }
                else
                {
                    button1.Visible = false;
                    panel2.Controls.Clear();
                    kesfet f1 = new kesfet();
                    f1.TopLevel = false;
                    panel2.Controls.Add(f1);
                    f1.Show();
                    f1.Dock = DockStyle.Fill;
                    f1.BringToFront();
                }
                label10.Show();

            }
            else
            {

                MessageBox.Show("Kullanıcı adı veya şifrenizi kontrol edil!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

         

            bag.Close();


        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

            gizleme_giris(0);
            label10.Visible = false;
            panel2.Controls.Clear();
            panel_ana_sayfa f12 = new panel_ana_sayfa();
            f12.TopLevel = false;
            panel2.Controls.Add(f12);
            f12.Show();
            f12.Dock = DockStyle.Fill;
            f12.BringToFront();

            button1.Visible = false;
            panel1.Visible = false;
            pictureBox6.Visible = true;
            label5.Text = " ";
            label6.Text = " ";
            label7.Text = " ";
            label8.Text = " ";

            profilim f1 = new profilim();
            f1.textBox1.Text = "";
            f1.textBox2.Text = " ";
            f1.textBox3.Text = " ";
            f1.textBox4.Text = " ";
            f1.textBox5.Text = " ";
            f1.textBox6.Text = " ";

            textBoxkullaniciadi.Text = "";
                textBoxsifre.Text="";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            admin_anasayfa f1 = new admin_anasayfa();
            f1.TopLevel = false;
            panel2.Controls.Add(f1);
            f1.Show();
            f1.Dock = DockStyle.Fill;
            f1.BringToFront();

        }




    }
}
