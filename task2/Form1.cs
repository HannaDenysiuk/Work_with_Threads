using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task2
{
    public partial class Form1 : Form
    {
        static string from, dest;
        static int seek=0;
        static int th=1;
        public Form1()
        {
            InitializeComponent();
        }
        static void MyThreadCopy(object obj)
        {
            byte[] content;
            using (FileStream fstreamR = new FileStream(from, FileMode.Open, FileAccess.Read))
            {
                content = new byte[fstreamR.Length / th];

                seek = seek * content.Length;
                fstreamR.Seek(seek, SeekOrigin.Begin);
                fstreamR.Read(content, 0, content.Length);
            }
            using (FileStream fstreamW = new FileStream(dest, FileMode.OpenOrCreate, FileAccess.Write))
            {
                fstreamW.Seek(seek, SeekOrigin.Begin);
                fstreamW.Write(content, 0, content.Length);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            th = Convert.ToInt32(textBox1.Text);
            Thread[] t = new Thread[th];
            for (int i = 0; i < th; i++)
            {
                seek = i;
                t[i] = new Thread(MyThreadCopy);
                t[i].IsBackground = true;
                t[i].Start();

                t[i].Join();
            }
            MessageBox.Show("file was sved");
        }
        private void open_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
               from = openFileDialog1.FileName;
        }
        private void save_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
               dest = saveFileDialog1.FileName;
        }
    }
}
