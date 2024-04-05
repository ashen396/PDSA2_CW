using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PDSA_2_CW.Assets;

namespace PDSA_2_CW
{
    public partial class Shortest_Path : Form
    {
        public Shortest_Path()
        {
            InitializeComponent();
        }

        private void pnl_background_Paint(object sender, PaintEventArgs e)
        {
            //e.Graphics.DrawImage(Images.water, 100, 0);
            //e.Graphics.DrawImage(Images.water, 148, 24);
            //e.Graphics.DrawImage(Images.water, 196, 48);
            //e.Graphics.DrawImage(Images.water, 244, 72);
            //int x = 100;
            //int y = 0;
            //for (int counter = 0; counter <= 10; counter++)
            //{
            //    e.Graphics.DrawImage(Images.water, x, y);
            //    x += 48;
            //    y += 24;
            //}

            //7th row
            //e.Graphics.DrawImage(Images.water, 308, 106);

            //6th row
            e.Graphics.DrawImage(Images.water, 260, 130);
            e.Graphics.DrawImage(Images.water, 308, 154);

            //5th row
            e.Graphics.DrawImage(Images.water, 212, 154);
            e.Graphics.DrawImage(Images.water, 356, 178);

            //4th row
            e.Graphics.DrawImage(Images.water, 164, 178);
            e.Graphics.DrawImage(Images.water, 404, 202);

            //3rd row
            e.Graphics.DrawImage(Images.water, 116, 202);
            e.Graphics.DrawImage(Images.water, 452, 226);

            //2nd row
            e.Graphics.DrawImage(Images.water, 68, 226);
            e.Graphics.DrawImage(Images.water, 500, 250);
            e.Graphics.DrawImage(Images.water, 452, 274);
            e.Graphics.DrawImage(Images.water, 404, 298);
            e.Graphics.DrawImage(Images.water, 356, 322);
            e.Graphics.DrawImage(Images.water, 308, 346);

            //1st row
            e.Graphics.DrawImage(Images.water, 20, 250);
            e.Graphics.DrawImage(Images.water, 68, 274);
            e.Graphics.DrawImage(Images.water, 116, 298);
            e.Graphics.DrawImage(Images.water, 164, 322); 
            e.Graphics.DrawImage(Images.water, 212, 346);
            e.Graphics.DrawImage(Images.water, 260, 370);

            ////2nd row
            //e.Graphics.DrawImage(Images.water, 75, 218);
            //e.Graphics.DrawImage(Images.water, 68, 274);
            //e.Graphics.DrawImage(Images.water, 116, 298);
            //e.Graphics.DrawImage(Images.water, 164, 322);
            //e.Graphics.DrawImage(Images.water, 212, 346);
            //e.Graphics.DrawImage(Images.water, 260, 370);
        }
    }
}
