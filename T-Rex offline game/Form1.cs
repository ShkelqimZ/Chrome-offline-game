using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace T_Rex_offline_game
{
    public partial class Form1 : Form
    {
        Rex rex = new Rex();
        List<Cactus> cactuses = new List<Cactus>();
        List<Cloud> clouds = new List<Cloud>();
        int n = 1;
        int points = 0;
        public Form1()
        {
            InitializeComponent();
            rex.x = 20;
            rex.y = ClientSize.Height - 150;
            cactuses.Add(new Cactus(ClientSize.Width,ClientSize.Height - 130));
            clouds.Add(new Cloud(ClientSize.Width, 70));
            
        }

        private void tmrUpdate_Tick(object sender, EventArgs e)
        {
            Random rnd = new Random();

            int random = rnd.Next(20, 25);
            if (rex.jump == true)
            {
                rex.y -= rex.force;
                rex.force -= 40;
            }

            if (rex.y >= ClientSize.Height - 150 )
            {
                rex.y = ClientSize.Height - 150;
                rex.jump = false;
            }

            if (n % random == 0)
            {
                cactuses.Add(new Cactus(ClientSize.Width, ClientSize.Height - 130));
                if (random % 4 == 0)
                {
                    clouds.Add(new Cloud(ClientSize.Width, 70));
                }
                
            }

            for (int i = 0; i < cactuses.Count; i++)
            {
                cactuses[i].update();
            }

            for (int i = 0; i < clouds.Count; i++)
            {
                clouds[i].update();
            }

            lblPoint.Text = "";
            lblPoint.Text += points;
            n++;
            points++;
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            Brush brush = Brushes.Gray;
            Brush brushOver = Brushes.Red;
            Brush brushCloud = Brushes.LightGray;
            Pen pen = Pens.Gray;
            Rectangle trex = new Rectangle(rex.x, rex.y, 30, 60);
            g.FillRectangle(brush, trex);
            g.DrawLine(pen, 0, ClientSize.Height - 110, ClientSize.Width, ClientSize.Height - 110);
            
            for (int i = 0; i < cactuses.Count; i++)
            {
                Rectangle rectangle = new Rectangle(cactuses[i].x, cactuses[i].y, 20, 40);
                if (rectangle.IntersectsWith(trex))
                {
                    g.FillRectangle(brushOver, rectangle);
                    points = 0;
                }
                else
                {
                    g.FillRectangle(brush, rectangle);
                }
                
            }

            for (int i = 0; i < clouds.Count; i++)
            {
                g.FillEllipse(brushCloud, clouds[i].x, clouds[i].y, 100, 40);
                g.FillEllipse(brushCloud, clouds[i].x + 25, clouds[i].y - 10, 50, 50);
            }

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                rex.Jump();
                //this.Invalidate();
            }
        }
    }
}
