using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Diplom_Maksim
{
    public partial class Zasttavka : Form
    {
        public Zasttavka()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
                Opacity += 0.1d;
        }
    }
}
