using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_MTT
{
    public partial class Form_fix : Form
    {
        public Form_fix()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add("1", "Sử dụng VPN");
            dataGridView1.Rows.Add("2", "Đến gần bộ định tuyến, modem hơn");
            dataGridView1.Rows.Add("3", "Tắt các trang web và các ứng dụng chạy nền");
            dataGridView1.Rows.Add("4", "Giảm thiểu số thiết bị sử dụng wifi");
            dataGridView1.Rows.Add("5", "Cắm cáp mạng (ethernet) trực tiếp vào máy");
            dataGridView1.Rows.Add("6", "Ưu tiên kết nối máy chủ quốc gia");
            dataGridView1.Rows.Add("7", "Khởi động lại bộ định tuyến, modem");
            dataGridView1.Rows.Add("8", "Liên hệ nhà mạng kiểm tra đường truyền");
            dataGridView1.Rows.Add("9", "Nâng cấp bộ định tuyến");
            dataGridView1.Rows.Add("10", "Nâng cấp gói cước phù hợp");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Rows.Add("1", "Ping địa chỉ khác từ máy tính của bạn");
            dataGridView1.Rows.Add("2", "Ping máy chủ cục bộ");
            dataGridView1.Rows.Add("3", "Tắt Tường lửa và Kiểm tra");
            dataGridView1.Rows.Add("4", "Kiểm tra Modem, Máy tính và Bộ định tuyến");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Rows.Add("1", "Reset Modem");
            dataGridView1.Rows.Add("2", "Kiểu tra dây mạng Lan");

        }
    }
}
