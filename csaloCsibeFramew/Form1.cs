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
      
        CancellationTokenSource cts;
        CancellationToken ctoken;
        public Form1()
        {
            InitializeComponent();
            btnStop.Enabled = false;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            int shift = 20;
            void moveLeft()
            {
                Cursor.Position = new Point(MousePosition.X + shift * -1, MousePosition.Y);
            }
            void moveRight()
            {
                Cursor.Position = new Point(MousePosition.X + shift, MousePosition.Y);
            }

            cts = new CancellationTokenSource();
            ctoken = cts.Token;
           
            Task.Run(async () =>
            {
                int rep = 12;
                do
                {
                    for (int i = 0; i < rep; i++)
                    {
                        moveRight();
                        await Task.Delay(15);
                    }
                    await Task.Delay(1500);
                    for (int i = 0; i < rep; i++)
                    {
                        moveLeft();
                        await Task.Delay(15);
                    }
                    await Task.Delay(5000);

                } while (!ctoken.IsCancellationRequested);
            }
            );

        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            btnStop.Enabled = false;
            btnStart.Enabled = true;
            
            Task.Run(() => {
                cts.Cancel();
            });
            
        }
    }
}
