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

namespace threads_characters
{
    public partial class Form1 : Form
    {
        static void MyThreadNum(object n)
        {
            TextBox t=n as TextBox;

            while (true)
            {
                Thread.Sleep(500);
                t.Text = new Random().Next(0, 9).ToString();
            }
        }
        public Form1()
        {
            InitializeComponent();
        }
        Thread t;
        private void start_Click(object sender, EventArgs e)
        {
            t = new Thread(MyThreadNum);
            t.IsBackground = true;
            t.Start(textBox1);

           
           
        }

        private void stop_Click(object sender, EventArgs e)
        {
           
        }
    }
}
