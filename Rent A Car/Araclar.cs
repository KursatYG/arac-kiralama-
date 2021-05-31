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
    public partial class Araclar : Form
    {
        Class1 class1 = new Class1();
        public Araclar()
        {
            InitializeComponent();
        }

        void datacek()
        {
            dataGridView1.DataSource = class1.GetAllList_Cars();
        }

        private void Araclar_Load(object sender, EventArgs e)
        {
            cbx_durumu.Items.Add("Boş");
            cbx_durumu.Items.Add("Dolu");
            cbx_durumu.SelectedIndex = 0;
            datacek();
        }

        private void btn_geri_donus_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_ekle_Click(object sender, EventArgs e)
        {
            if (tbx_CarsID.Text == ""||tbx_plaka.Text == "" || tbx_marka.Text == "" || tbx_model.Text == "" || tbx_fiyat.Text == "")
            {
                MessageBox.Show("Eksik Bilgi Girdiniz!");
            }
            else
            {
                class1.ADD_Cars(new Codes
                {
                    CarsID = Convert.ToInt32(tbx_CarsID.Text),
                    ReqNo = Convert.ToString(tbx_plaka.Text),
                    Model = Convert.ToString(tbx_model.Text),
                    Brand = Convert.ToString(tbx_marka.Text),
                    Available = Convert.ToString(cbx_durumu.SelectedItem),
                    Price = Convert.ToString(tbx_fiyat.Text),
                });
                datacek();

                MessageBox.Show("Araç Başarılı Bir Şekilde Eklendi.");
            }

            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btn_duzenle_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seçilen Aracı Güncellemek İstiyor Musunuz?", "Güncelle", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                class1.UPDATE_Cars(new Codes
                {
                    ReqNo = Convert.ToString(tbx_plaka.Text),
                    Model = Convert.ToString(tbx_model.Text),
                    Brand = Convert.ToString(tbx_marka.Text),
                    Price = Convert.ToString(tbx_fiyat.Text),
                    Available = Convert.ToString(cbx_durumu.SelectedItem),   
                    CarsID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value),
                });
                datacek();

                MessageBox.Show("Araç Başarılı Bir Şekilde Güncellendi.");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbx_CarsID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            tbx_plaka.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString(); 
            tbx_marka.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString(); 
            tbx_model.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            cbx_durumu.Text= dataGridView1.CurrentRow.Cells[4].Value.ToString();
            tbx_fiyat.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString(); 

            
        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Üyeyi silmek istiyor musunuz?", "SİL", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                class1.DELETE_Cars(new Codes
                {
                    CarsID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value),
                });
                datacek();

                MessageBox.Show("Araç Başarılı Bir Şekilde Silindi.");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
