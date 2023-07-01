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
    public partial class magaza : Form
    {
        public magaza()
        {
            InitializeComponent();
        }

        private void magaza_Load(object sender, EventArgs e)
        {
          
            
        }
        int a = 50;


        private void button1_Click(object sender, EventArgs e)
        {
            var lblnew = new Label
            {
                Location = new Point(40, a),
                Text = "My Label", //Text can be dynamically assigned e.g From some text box
                AutoSize = true,
                BackColor = Color.LightGray,
                Font = new Font("Microsoft JhengHei UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, (byte)0)
            };
            a = a + 40;

            //this refers to current form you can use your container according to requirement
            panel2.Controls.Add(lblnew);
        }
    }
}
