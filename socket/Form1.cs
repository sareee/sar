using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;


namespace socket
{
    public partial class client : Form
    {
        Socket socketclient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        public client()
        {
            InitializeComponent();

            CheckForIllegalCrossThreadCalls = false;

        }

        private void client_Load(object sender, EventArgs e)
        {

        }
        public void getmess() {
            try {
while (true)
                {
                    byte[] arr = new Byte[1024];
                    int c = socketclient.Receive(arr);
                    if (c > 0)
                    {
                        listBox1.Items.Add("server : " + Encoding.Unicode.GetString(arr, 0, c));

                    }

                }


            }
            catch { }

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            IPEndPoint ipend = new IPEndPoint(IPAddress.Parse(textBox1.Text), int.Parse(textBox2.Text));
            try {
                socketclient.Connect(ipend);
                Thread t = new Thread(new ThreadStart(getmess));
                t.Start();
            }
            catch
            {
                MessageBox.Show("not found server");

            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            byte[] arr = new Byte[1024];
            arr = Encoding.Unicode.GetBytes(textBox3.Text);
            socketclient.Send(arr);
            listBox1.Items.Add("me :" + textBox3.Text);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try {
                if (socketclient != null)
                    socketclient.Shutdown(SocketShutdown.Both);
                Environment.Exit(Environment.ExitCode);
                Application.Exit();
            }
            catch
            {
                Environment.Exit(Environment.ExitCode);
                Application.Exit();

            }
        }
    }
}
