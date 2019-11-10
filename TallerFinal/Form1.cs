using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TallerFinal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (pgbCargaInicial.Value < 100)
            {
                pgbCargaInicial.Value++;
                label1.Text = pgbCargaInicial.Value.ToString() + "%";
            }
            else
            {
                timer1.Stop();
                
                Menu menu = new Menu();
                menu.Show();
                this.Hide();

            }
        }

       
    }
}
