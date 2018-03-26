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

using System.Reflection;

namespace Quiz_TCPBot {
    public partial class Form1 : Form {
        private TcpClient client;

        private Board board;

        public Form1() {
            InitializeComponent();
        }

        private void MakeMove(bool me, int r, int c)
        {

        }

        private string Read()
        {
            byte[] res = new byte[20];
            NetworkStream stream = client.GetStream();

            stream.Read(res, 0, 20);
            return new string(Encoding.ASCII.GetChars(res));
        }

        private string Respond(string msg)
        {
            NetworkStream stream = client.GetStream();

            stream.Write(Encoding.ASCII.GetBytes(msg), 0, msg.Length);

            byte[] res = new byte[20];

            stream.Read(res, 0, 20);

            string resmsg = new string(Encoding.ASCII.GetChars(res));

            return resmsg;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            client = new TcpClient();

            client.Connect(txtServer.Text, (int)numPort.Value);

            if (!client.Connected)
                MessageBox.Show("Connection failed.");
            else
            {
                byte[] res = new byte[20];
                NetworkStream stream = client.GetStream();
                string msg = "N";
                stream.Write(Encoding.ASCII.GetBytes(msg), 0, msg.Length);

                //while(stream.Read(res, 0, 20) > 0)
                stream.Read(res, 0, 20);
                MessageBox.Show(new string(Encoding.ASCII.GetChars(res)));

                //string resp = Respond("N");

                //if (resp[0] == 'T')
                //  lblStatus.Text = "Your turn";
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            byte[] res = new byte[20];
            NetworkStream stream = client.GetStream();
            
            stream.Read(res, 0, 20);
            MessageBox.Show(new string(Encoding.ASCII.GetChars(res)));
        }
    }
}
