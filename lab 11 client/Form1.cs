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
using System.IO;


namespace lab_11_client
{
    public partial class Form1 : Form
    {
        TcpClient client;
        byte[] add;
        IPAddress localadd;

        int port;
        NetworkStream nstream;
        BinaryReader bR;
        BinaryWriter bW;

        public Form1()
        {
            InitializeComponent();
            add = new byte[] { 127, 0, 0, 1 };
            localadd = new IPAddress(add);
            port = 1090;
            client = new TcpClient();
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;




        }

        private void button1_Click(object sender, EventArgs e)
        {
            try { 
            client.Connect(localadd, port);
            nstream = client.GetStream();
                bW = new BinaryWriter(nstream);
                bR = new BinaryReader(nstream);
             button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;}
            catch
            {
                MessageBox.Show("server is not available");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bW.Close();
            bR.Close();
            nstream.Close();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string input;
            input = bR.ReadString();
            listBox1.Items.Add("Server : " + input);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add("Client  :" + textBox1.Text);
            bW.Write(textBox1.Text);
            textBox1.Clear();
        }
    }

}
