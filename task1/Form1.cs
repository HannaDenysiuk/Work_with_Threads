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

namespace task1
{
    public partial class Form1 : Form
    {
        static void MyThreadNum1(object n)
        {
            TextBox t = n as TextBox;

            while (true)
            {
                Thread.Sleep(400);
                t.Text = new Random().Next(0, 10).ToString();
            }
        }
        static void MyThreadNum2(object n)
        {
            TextBox t = n as TextBox;

            while (true)
            {
                Thread.Sleep(400);
                int i = new Random().Next(1, 3) == 1 ? new Random().Next(33, 48) : new Random().Next(58, 65);
                char anyLetter = Convert.ToChar(i);

                t.Text = anyLetter.ToString();
                
            }
        }
        static void MyThreadNum3(object n)
        {
            TextBox t = n as TextBox;
            
            while (true)
            {
                Thread.Sleep(400);

                int i = new Random().Next(1, 3) == 1 ? new Random().Next(65, 91) : new Random().Next(97, 123);
                char anyLetter = Convert.ToChar(i);

                t.Text = anyLetter.ToString();
            }
        }
        
        Thread t1 ;
        Thread t2;
        Thread t3;
       
        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 2;
            comboBox2.SelectedIndex = 2;
            comboBox3.SelectedIndex = 2;
        }

        private void start_Click(object sender, EventArgs e)
        {
            t1 = new Thread(MyThreadNum1);
            t1.IsBackground = true;
            switch (comboBox1.SelectedItem)
            {
                case "Lowest":
                    t1.Priority = ThreadPriority.Lowest;
                    break;
                case "BelowNormal":
                    t1.Priority = ThreadPriority.BelowNormal;
                    break;
                case "Normal":
                    t1.Priority = ThreadPriority.Normal;
                    break;
                case "AboveNormal":
                    t1.Priority = ThreadPriority.AboveNormal;
                    break;
                case "Highest":
                    t1.Priority = ThreadPriority.Highest;
                    break;
                default:
                    break;
            }

            t2 = new Thread(MyThreadNum2);
            t2.IsBackground = true;
            switch (comboBox2.SelectedItem)
            {
                case "Lowest":
                    t2.Priority = ThreadPriority.Lowest;
                    break;
                case "BelowNormal":
                    t2.Priority = ThreadPriority.BelowNormal;
                    break;
                case "Normal":
                    t2.Priority = ThreadPriority.Normal;
                    break;
                case "AboveNormal":
                    t2.Priority = ThreadPriority.AboveNormal;
                    break;
                case "Highest":
                    t2.Priority = ThreadPriority.Highest;
                    break;
                default:
                    break;
            }

            t3 = new Thread(MyThreadNum3);
            t3.IsBackground = true;
            switch (comboBox3.SelectedItem)
            {
                case "Lowest":
                    t3.Priority = ThreadPriority.Lowest;
                    break;
                case "BelowNormal":
                    t3.Priority = ThreadPriority.BelowNormal;
                    break;
                case "Normal":
                    t3.Priority = ThreadPriority.Normal;
                    break;
                case "AboveNormal":
                    t3.Priority = ThreadPriority.AboveNormal;
                    break;
                case "Highest":
                    t3.Priority = ThreadPriority.Highest;
                    break;
                default:
                    break;
            }

            t1.Start(textBox1);
            t2.Start(textBox2);
            t3.Start(textBox3);

        }

        private void stop_Click(object sender, EventArgs e)
        {
            t1.Abort();
            t2.Abort();
            t3.Abort();
        }
    }
}
