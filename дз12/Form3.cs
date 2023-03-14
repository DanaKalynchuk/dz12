using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace дз12
{
    public partial class Form3 : Form
    {

        public int size = 50;
        public  bool[,] maze = new bool[7,9] {
         { false,false, false, false, false, false, false, false, false },
         { true, true, true, true, true,false,false, false, false  },
         { false, true, false, false, true, false, true, true, true },
         { false, true, true, false, true, true, true, false, false },
         { false,  false, true, false, false, false,false, false, false },
         { false, false, true, true, true, true,true,true,true, },
         { false,false, false, false, false, false, false, false, false }
        };
        public Form3()
        {
            InitializeComponent();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.LightGreen);
            Pen pen = new Pen(Color.DarkBlue, 4);
            Brush bruch = new SolidBrush(Color.DarkBlue);
            Brush bruch1 = new SolidBrush(Color.LightBlue);
            //малюємо лабіринт 
            for (int i = 0; i < 7; i++)
            {
                for (int J = 0; J < 9; J++)
                {
                    if (!maze[i, J])
                    {
                        Rectangle rect = new Rectangle(J* size, i* size, 50, 50);

                        g.FillRectangle(bruch, rect);
                    }
                    else
                    {
                        Rectangle rect = new Rectangle(J * size, i * size, 50, 50);

                        g.FillRectangle(bruch1, rect);
                    }
                }
            }
           
        }
    }
}
