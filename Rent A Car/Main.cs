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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_arac_Click(object sender, EventArgs e)
        {
            Araclar araclar = new Araclar();
            araclar.Show();
        }

        private void btn_musteri_Click(object sender, EventArgs e)
        {
            Musteriler musteriler = new Musteriler();
            musteriler.Show();
        }

        private void btn_kiralanan_Click(object sender, EventArgs e)
        {
            Kiralanan kiralanan = new Kiralanan();
            kiralanan.Show();
        }

        private void btn_geri_donus_Click(object sender, EventArgs e)
        {
            GeriDonus geriDonus = new GeriDonus();
            geriDonus.Show();
        }

        private void btn_kullanicilar_Click(object sender, EventArgs e)
        {
            Users users = new Users();
            users.Show();
        }

        private void btn_cıkıs_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }
    }
}
