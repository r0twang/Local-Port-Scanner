using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;

namespace LocalPortScanner
{
    public partial class Form1 : Form
    {
        private TcpListener server;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //progressBar1.Value = 0;

            if (numericUpDown1.Value > numericUpDown2.Value)
            {
                MessageBox.Show("Incorrect ports range");
                return;
            }

            //progressBar1.Maximum = (int)numericUpDown2.Value - 1;

            listBox1.Items.Add("Begin scanning...");
            for (int i = (int)numericUpDown1.Value; i < (int)numericUpDown2.Value; i++)
            {
                this.Refresh();
                label3.Text = "Scanned port: " + i;
                try
                {
                    server = new TcpListener(IPAddress.Loopback, i);
                    server.Start();
                    server.Stop();
                }
                catch
                {
                    listBox1.Items.Add("Port: " + i + "is busy");
                }
                //progressBar1.PerformStep();
            }
            listBox1.Items.Add("Scanning ended");
        }

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    server.Stop();
        //    listBox1.Items.Add("Server shut down");
        //}
    }
}
