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
    public partial class kayit : Form
    {
        MySqlConnection bag = new MySqlConnection("Server=localhost;Database=mobilya;Uid=root;Pwd=;");

        public kayit()
        {
            InitializeComponent();
        }

        #region gereksiz kodlar
        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void pictureBoxsepet_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBoxsifre_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxkullaniciadi_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBoxgiris_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        #endregion

        private void button2_Click(object sender, EventArgs e)
    {
           
        bag.Open();
        MySqlCommand komut = new MySqlCommand("insert into uyeler(adi,soyadi,tel,mail,adres,kadi,sifre)values ('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox4.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + textBox6.Text.ToString() + "','" + textBox5.Text.ToString() + "','" + textBox7.Text.ToString() + "')", bag);
            komut.ExecuteNonQuery();




            bag.Close();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            MessageBox.Show("Kayıt Başarılı");
    }
      

        
      
    }
}
