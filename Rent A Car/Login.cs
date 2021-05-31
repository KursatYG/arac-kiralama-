using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Rent_A_Car
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {
            Password.PasswordChar = '*';
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=RentACar;Integrated Security=True");
            string query = "SELECT count(*) from Users WHERE UserName='" + User.Text +"' and Password='" + Password.Text +"'";
            SqlDataAdapter data = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            data.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                Main main = new Main();
                main.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Yanlış Kullanıcı Adı Veya Şifre");
            }
            
        }
    }
}
