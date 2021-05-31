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
    public partial class GeriDonus : Form
    {
        Class1 class1 = new Class1();
        public GeriDonus()
        {
            InitializeComponent();
        }

        void datacek()
        {
            dataGridView1.DataSource = class1.GetAllList_Rental();
            dataGridView2.DataSource = class1.GetAllList_Return();
        }

        private void btn_geri_donus_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void GeriDonus_Load(object sender, EventArgs e)
        {
            datacek();
        }

        private void btn_ekle_Click(object sender, EventArgs e)
        {
            if (tbx_isim.Text == "" || tbx_plaka.Text == "")
            {
                MessageBox.Show("Eksik Bilgi Girdiniz!");
            }
            else
            {
                class1.ADD_Return(new Codes
                {
                    ReturnID = Convert.ToInt32(tbx_id.Text),
                    ReqNo = Convert.ToString(tbx_plaka.Text),
                    CustName = Convert.ToString(tbx_isim.Text),
                    Return_Date = Convert.ToDateTime(date_teslim.Value),
                    Delay = Convert.ToInt32(tbx_gecikme.Text),
                    Fine = Convert.ToInt32(tbx_faiz.Text),
                });
                datacek();

                MessageBox.Show("Araç Başarılı Bir Şekilde Eklendi.");
            }
        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Aracı silmek istiyor musunuz?", "SİL", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                class1.DELETE_Return(new Codes
                {
                    ReturnID = Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value),
                });
                datacek();

                MessageBox.Show("Aracı Başarılı Bir Şekilde Silindi.");
            }
        }

        private void btn_duzenle_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seçilen Aracı Güncellemek İstiyor Musunuz?", "Güncelle", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                class1.UPDATE_Return(new Codes
                {
                    ReqNo = Convert.ToString(tbx_plaka.Text),
                    CustName = Convert.ToString(tbx_isim.Text),
                    Return_Date = Convert.ToDateTime(date_teslim.Value),
                    Delay = Convert.ToInt32(tbx_gecikme.Text),
                    Fine = Convert.ToInt32(tbx_faiz.Text),
                    ReturnID = Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value),
                });
                datacek();

                MessageBox.Show("Araç Başarılı Bir Şekilde Güncellendi.");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbx_id.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            tbx_plaka.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            tbx_isim.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            date_teslim.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();

            DateTime d1 = date_teslim.Value.Date;
            DateTime d2 = DateTime.Now;
            TimeSpan t = d2 - d1;
            int gecikme = Convert.ToInt32(t.TotalDays);
            if (gecikme <= 0)
            {
                tbx_gecikme.Text = "Gecikme Yok";
                tbx_faiz.Text = "Faiz Yok";
            }
            else
            {
                tbx_gecikme.Text = "" + gecikme;
                tbx_faiz.Text = "" + (gecikme * 250);
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbx_id.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            tbx_plaka.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            tbx_isim.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            date_teslim.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            tbx_gecikme.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
            tbx_faiz.Text = dataGridView2.CurrentRow.Cells[5].Value.ToString();
        }
    }
}
