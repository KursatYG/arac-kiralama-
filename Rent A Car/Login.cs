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
            string ktipi;
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=AracKiralama;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT usertype from Users WHERE UserName='" + User.Text + "' and Password='" + Password.Text + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            
            
            if (dr.Read())
            {
                ktipi = dr[0].ToString();

                if (ktipi == "0")
                {
                    Main main = new Main();
                    main.Show();
                    this.Hide();
                }
                else if (ktipi=="1")
                {
                    KullaniciFormu kullanici = new KullaniciFormu();
                    kullanici.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Yanlış Kullanıcı Adı Veya Şifre");
            }
            con.Close();
            
        }
    }
}
