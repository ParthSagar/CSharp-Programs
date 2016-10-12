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

namespace Threading
{
    public partial class Form1 : Form
    {
        private Thread th;
        private Thread th1;
        private Random rdm;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            th=new Thread(doTimeConsumingWork); 
            th.Start();
        }

        private void doTimeConsumingWork()
        {
            for (int i = 0; i < 100; i++)
            {
                this.CreateGraphics().DrawRectangle(new Pen(Brushes.Red,4), new Rectangle(rdm.Next(0,this.Width),rdm.Next(0,this.Height), 20,20 ));
                Thread.Sleep(100);    
            }
            
        }
        private void thread2()
        {
            for (int i = 0; i < 100; i++)
            {
                this.CreateGraphics().DrawRectangle(new Pen(Brushes.Blue, 4), new Rectangle(rdm.Next(0, this.Width), rdm.Next(0, this.Height), 20, 20));
                Thread.Sleep(100);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            th1=new Thread(thread2);
            th1.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            rdm=new Random();
        }

    }
}
