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
    public partial class Kiralanan : Form
    {
        Class1 class1 = new Class1();
        public Kiralanan()
        {
            InitializeComponent();
        }

        void datacek()
        {
            dataGridView1.DataSource = class1.GetAllList_Rental();
        }

        private void plakacek()
        {
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=RentACar;Integrated Security=True");
            SqlCommand komut = new SqlCommand();
            komut.CommandText = "SELECT * FROM Cars WHERE Available='Boş'";
            komut.Connection = con;
            komut.CommandType = CommandType.Text;
            SqlDataReader dr;
            con.Open();
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cbx_plaka.Items.Add(dr["ReqNo"]);
            }
            con.Close();
        }

        private void fillmusteri()
        {
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=RentACar;Integrated Security=True");
            con.Open();
            string query = "SELECT CustID FROM Customers";
            SqlCommand com = new SqlCommand(query, con);
            SqlDataReader dr;
            dr = com.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("CustID", typeof(int));
            dt.Load(dr);
            cbx_musteri.ValueMember = "CustID";
            cbx_musteri.DataSource = dt;
            con.Close();
        }
        private void mustericek()
        {
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=RentACar;Integrated Security=True");
            con.Open();
            string query = "SELECT * FROM Customers WHERE CustID=" + cbx_musteri.SelectedValue.ToString() + "";
            SqlCommand com = new SqlCommand(query, con);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(com);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                tbx_isim.Text = dr["CustName"].ToString();
                tbx_soyisim.Text = dr["CustSurName"].ToString();
            }
            con.Close();
        }





        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_geri_donus_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Kiralanan_Load(object sender, EventArgs e)
        {
            datacek();
            plakacek();
            fillmusteri();                    
        }

        private void btn_ekle_Click(object sender, EventArgs e)
        {
            if (cbx_plaka.Text == "" || cbx_musteri.Text == "" || tbx_ucret.Text == "")
            {
                MessageBox.Show("Eksik Bilgi Girdiniz!");
            }
            else
            {
                class1.ADD_Rental(new Codes
                {
                    RentID = Convert.ToInt32(tbx_id.Text),
                    ReqNo = Convert.ToString(cbx_plaka.Text),
                    CustName = Convert.ToString(tbx_isim.Text),
                    Rent_Date = Convert.ToDateTime(date_alis.Value),
                    Return_Date = Convert.ToDateTime(date_teslim.Value),
                    Fee = Convert.ToString(tbx_ucret.Text),
                });
                datacek();

                MessageBox.Show("Araç Başarılı Bir Şekilde Eklendi.");
            }
        }

        private void btn_duzenle_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seçilen Aracı Güncellemek İstiyor Musunuz?", "Güncelle", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                class1.UPDATE_Rental(new Codes
                {
                    ReqNo = Convert.ToString(cbx_plaka.Text),
                    CustName = Convert.ToString(tbx_isim.Text),
                    Rent_Date = Convert.ToDateTime(date_alis.Value),
                    Return_Date = Convert.ToDateTime(date_teslim.Value),
                    Fee = Convert.ToString(tbx_ucret.Text),
                    RentID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value),
                });
                datacek();

                MessageBox.Show("Araç Başarılı Bir Şekilde Güncellendi.");
            }
        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Aracı silmek istiyor musunuz?", "SİL", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                class1.DELETE_Rental(new Codes
                {
                    RentID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value),
                });
                datacek();

                MessageBox.Show("Aracı Başarılı Bir Şekilde Silindi.");
            }
        }

        private void cbx_musteri_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tbx_soyisim_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbx_isim_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbx_id.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            cbx_plaka.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            cbx_musteri.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            date_alis.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            date_teslim.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            tbx_ucret.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            
        }

        private void cbx_musteri_SelectionChangeCommitted(object sender, EventArgs e)
        {
            mustericek();
        }
    }
}
