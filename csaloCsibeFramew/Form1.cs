using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csaloCsibeFramew
{
    public partial class Form1 : Form
    {
        bool run;
        Random rnd;
        public Form1()
        {
            InitializeComponent();
            btnStop.Enabled = false;
            rnd = new Random();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            run = true;

            void mouseMove(int x, int y, int millisecs)
            {
                int wait = 50;
                millisecs = millisecs > wait ? millisecs : 1000;
                int iteration = millisecs / wait;

                for (int i = 0; i < iteration; i++)
                {
                    Cursor.Position = new Point(MousePosition.X + x / iteration, MousePosition.Y + y / iteration);
                    Thread.Sleep(iteration);
                }
            }

            Task.Run(() =>
            {
                while (run)
                {
                    int dist = 300;
                    int time = rnd.Next(500, 2000);
                    for (int i = 0; i < 5; i++)
                    {
                        mouseMove(rnd.Next(dist * -1, dist), rnd.Next(dist * -1, dist), time);

                    }
                    Thread.Sleep(5000);
                }
            });

        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            btnStop.Enabled = false;
            btnStart.Enabled = true;

            run = false;

        }
    }
}
