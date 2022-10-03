using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;

namespace BTL_MTT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Ping pingSender = new Ping();
            PingOptions options = new PingOptions();
            options.DontFragment = true;

            string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            int timeout = 2000;   // 2 secs

            string host = textBox1.Text;

            try
            {
                PingReply reply = pingSender.Send(host, timeout);

                if (reply.Status == IPStatus.Success)
                {
                    // Ping thành công
                    string pingResults;
                    pingResults = "Status: " + reply.Status.ToString();
                    pingResults = pingResults + "\r\nAddress: " + reply.Address.ToString();
                    pingResults = pingResults + "\r\nTime: " + reply.RoundtripTime;
                    pingResults = pingResults + "\r\nTime to live: " + reply.Options.Ttl;
                    pingResults = pingResults + "\r\nBuffer size: " + reply.Buffer.Length;
                    textBox2.Text = pingResults;
                }
                else
                {
                    // ping không thành công
                    String pingMessage = "Ping command did not work:";
                    pingMessage = pingMessage + "\r\n" + reply.Status.ToString();
                    textBox2.Text = pingMessage;
                }
            }
            catch (Exception ping_error)
            {
                //lỗi khi ping
                String errMessage = "";
                errMessage = ping_error.Message;
                errMessage = errMessage + "\r\n" + ping_error.InnerException.ToString();
                textBox2.Text = errMessage;

                pingSender.Dispose();
                return;
            }
        }
        void Tracert()
        {

            results1.Rows.Clear();

            string host = textBox1.Text;
            int Timeout = 2000;
            int MaxHops = 30;

            PingReply reply;
            Ping pinger = new Ping();
            PingOptions options = new PingOptions();
            options.Ttl = 1;//Time to live
            options.DontFragment = true;
            string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            byte[] buffer = Encoding.ASCII.GetBytes(data);

            try
            {
                do
                {
                    DateTime start = DateTime.Now;
                    reply = pinger.Send(host, Timeout, buffer, options);

                    long thgian = DateTime.Now.Subtract(start).Milliseconds;
                    if (reply.Status == IPStatus.TtlExpired)
                    {
                        results1.Rows.Add(options.Ttl, reply.Address.ToString(), thgian + " ms");
                    }
                    else if (reply.Status == IPStatus.Success)
                    {
                        results1.Rows.Add(options.Ttl, reply.Address.ToString(), thgian + " ms");
                        MessageBox.Show("Lệnh Tracert đã được thực hiện thành công", "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        results1.Rows.Add(options.Ttl, reply.Status.ToString(), "*");
                    }
                    options.Ttl++;

                } while ((reply.Status != IPStatus.Success) && (options.Ttl < MaxHops));
            }

            catch (Exception e)
            {
                MessageBox.Show(Convert.ToString(e));
            }
        }

        private void btnTracert_Click(object sender, EventArgs e)
        {
            Tracert();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form_fix dlg2 = new Form_fix();
            dlg2.ShowDialog();

        }
    }
}