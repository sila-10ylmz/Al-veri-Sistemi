using System;
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
    public partial class kategori_ekle : Form
    {
        public kategori_ekle()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Veritabani vtn = new Veritabani();
            if (vtn.kategori_ekle(textBox1.Text) == 1)
            {

                admin_anasayfa.anf.yukle_kategori();
                MessageBox.Show("Kategori Eklenmiştir.");
                this.Close();

            }
            else
            {

                MessageBox.Show("Kategori eklenmedi.");
            }
        }
    }
}
