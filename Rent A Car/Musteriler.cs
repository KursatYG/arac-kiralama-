using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rent_A_Car
{
    public partial class Musteriler : Form
    {
        Class1 class1 = new Class1();
        public Musteriler()
        {
            InitializeComponent();
        }

        void datacek()
        {
            dataGridView1.DataSource = class1.GetAllList_Customer();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_geri_donus_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Musteriler_Load(object sender, EventArgs e)
        {
            datacek();
        }

        private void btn_arac_Click(object sender, EventArgs e)
        {
            if (tbx_CustID.Text == "" || tbx_TC.Text == "" || tbx_name.Text == "" || tbx_surname.Text == "" || tbx_adres.Text == "" || tbx_telefon.Text == "")
            {
                MessageBox.Show("Eksik Bilgi Girdiniz!");
            }
            else
            {
                class1.ADD_Customer(new Codes
                {
                    CustID = Convert.ToInt32(tbx_CustID.Text),
                    Cust_TC = Convert.ToString(tbx_TC.Text),
                    CustName = Convert.ToString(tbx_name.Text),
                    CustSurName = Convert.ToString(tbx_surname.Text),
                    Adress = Convert.ToString(tbx_adres.Text),
                    Phone = Convert.ToString(tbx_telefon.Text),
                });
                datacek();

                MessageBox.Show("Müşteri Başarılı Bir Şekilde Eklendi.");
            }
        }

        private void btn_duzenle_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seçilen Müşteriyi Güncellemek İstiyor Musunuz?", "Güncelle", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                class1.UPDATE_Customer(new Codes
                {
                    Cust_TC = Convert.ToString(tbx_TC.Text),
                    CustName = Convert.ToString(tbx_name.Text),
                    CustSurName = Convert.ToString(tbx_surname.Text),
                    Adress = Convert.ToString(tbx_adres.Text),
                    Phone = Convert.ToString(tbx_telefon.Text),
                    CustID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value),
                });
                datacek();

                MessageBox.Show("Müşteri Başarılı Bir Şekilde Güncellendi.");
            }
        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Müşteriyi silmek istiyor musunuz?", "SİL", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                class1.DELETE_Customer(new Codes
                {
                    CustID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value),
                });
                datacek();

                MessageBox.Show("Müşteri Başarılı Bir Şekilde Silindi.");
            }
        }

      

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            tbx_CustID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            tbx_TC.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            tbx_name.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            tbx_surname.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            tbx_adres.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            tbx_telefon.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }
    }
}
