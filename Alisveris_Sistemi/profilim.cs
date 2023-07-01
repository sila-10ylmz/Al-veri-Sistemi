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
    public partial class profilim : Form
    {

        MySqlConnection bag;

        public profilim()
        {


            bag = new MySqlConnection("Server=localhost;Database=mobilya;Uid=root;Pwd=;");

            InitializeComponent();

            label7.Visible = false;

        }


       
    


        private void profilim_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            magaza mgz = new magaza();
            mgz.TopLevel = false;
            panel2.Controls.Add(mgz);
            mgz.Show();
            mgz.Dock = DockStyle.Fill;
            mgz.BringToFront();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                bag.Open();

                string sql = "UPDATE uyeler SET adi = '"+textBox1.Text+"', soyadi = '"+textBox2.Text+"' WHERE id = " + label7.Text;
                MySqlCommand cmd = new MySqlCommand(sql, bag);
                MySqlDataReader rdr = cmd.ExecuteReader();

                bag.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }

      
    }
}
