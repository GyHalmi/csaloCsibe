using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csaloCsibeFramew
{
    public partial class Form1 : Form
    {
        Action action = () => { };
        Task taskMoveMouse;

        public Form1()
        {
            InitializeComponent();
            taskMoveMouse = new Task(action);


        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            int shift = 20;
            void moveLeft()
            {
                Cursor.Position = new Point(MousePosition.X + shift * -1, MousePosition.Y);
            }
            void moveRight()
            {
                Cursor.Position = new Point(MousePosition.X + shift, MousePosition.Y);
            }

            taskMoveMouse = Task.Run(async () =>
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

                } while (true);

            }
            );


        }
    }
}
