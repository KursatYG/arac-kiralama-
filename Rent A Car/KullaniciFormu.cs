using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient ;

namespace Rent_A_Car
{
    public partial class KullaniciFormu : Form
    {
        public KullaniciFormu()
        {
            InitializeComponent();
        }
        public void kullanicibilgi()
        {
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=AracKiralama;Integrated Security=True");
            SqlCommand komut = new SqlCommand();
            komut.CommandText = "SELECT * FROM Customers ";
            komut.Connection = con;
            komut.CommandType = CommandType.Text;
            SqlDataReader dr;
            con.Open();
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                label17.Text = dr["Cust_TC"].ToString();
                label19.Text = dr["CustName"].ToString();
                label18.Text = dr["CustSurName"].ToString();
                label16.Text = dr["Adress"].ToString();
                label15.Text = dr["Phone"].ToString();
            }
            con.Close();
        }

        public void aracbilgi()
        {
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=AracKiralama;Integrated Security=True");
            SqlCommand komut = new SqlCommand();
            komut.CommandText = "SELECT Customers.CustName, Customers.CustSurName, Customers.Adress, Customers.Cust_TC, Customers.Phone, Cars.Model, Cars.Brand, Cars.ReqNo, Cars.Price FROM Cars INNER JOIN Customers on Customers.UserID = Cars.UserID";
            komut.Connection = con;
            komut.CommandType = CommandType.Text;
            SqlDataReader dr;
            con.Open();
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                label8.Text = dr["Brand"].ToString();
                label9.Text = dr["Model"].ToString();
                label10.Text = dr["ReqNo"].ToString();
                label11.Text = dr["Price"].ToString();
                label17.Text = dr["Cust_TC"].ToString();
                label19.Text = dr["CustName"].ToString();
                label18.Text = dr["CustSurName"].ToString();
                label16.Text = dr["Adress"].ToString();
                label15.Text = dr["Phone"].ToString();

            }
            con.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {
          
        }

        private void panel6_Click(object sender, EventArgs e)
        {
            Kayit kayit = new Kayit();
            kayit.Show();
        }

        private void label14_Click(object sender, EventArgs e)
        {
            Kayit kayit = new Kayit();
            kayit.Show();
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void KullaniciFormu_Load(object sender, EventArgs e)
        {

            
            aracbilgi();
        }
    }
}
