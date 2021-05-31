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
    public partial class Users : Form
    {
        Class1 class1 = new Class1();
        public Users()
        {
            InitializeComponent();
        }
        
        void datacek()
        {
            dataGridView2.DataSource = class1.GetAllList();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_ekle_Click(object sender, EventArgs e)
        {
            if (Uid.Text == "" || Uname.Text == "" || Upassword.Text == "" )
            {
                MessageBox.Show("Eksik Bilgi Girdiniz!");
            }
            else {
                class1.ADD(new Codes
                {
                    UserID = Convert.ToInt32(Uid.Text),
                    UserName = Convert.ToString(Uname.Text),
                    Password = Convert.ToString(Upassword.Text),
                    usertype = Convert.ToString(cbx_usertype.SelectedItem),
                });
                datacek();

                MessageBox.Show("Kullanıcı Başarılı Bir Şekilde Eklendi.");
            }

            
        }

        private void Users_Load(object sender, EventArgs e)
        {
            cbx_usertype.Items.Add("0");
            cbx_usertype.Items.Add("1");
            cbx_usertype.SelectedIndex = 1;
            datacek();

        }
            

        private void btn_geri_donus_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btn_duzenle_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seçilen Aracı Güncellemek İstiyor Musunuz?", "Güncelle", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                class1.UPDATE(new Codes
                {
                    UserID = Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value),
                    UserName = Convert.ToString(Uname.Text),
                    Password = Convert.ToString(Upassword.Text),
                    usertype = Convert.ToString(cbx_usertype.SelectedItem),
                    
                });
                datacek();

                MessageBox.Show("Kullanıcı Başarılı Bir Şekilde Güncellendi.");
            }
        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Üyeyi silmek istiyor musunuz?", "SİL", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                class1.DELETE(new Codes
                {
                    UserID = Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value),
                });
                datacek();

                MessageBox.Show("Kullanıcı Başarılı Bir Şekilde Silindi.");
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Uid.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            Uname.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            cbx_usertype.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            Upassword.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
        }
    } 
}
