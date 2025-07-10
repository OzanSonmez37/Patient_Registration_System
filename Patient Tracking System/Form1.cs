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

namespace hastaTakipSistemi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        frmSqlBaglanti bgl = new frmSqlBaglanti();

        private void btnKayit2_Click(object sender, EventArgs e)
        {
            frmKayit frm = new frmKayit();
            frm.Show();
        }

        private void btnGiris2_Click(object sender, EventArgs e)
        {
            if(txtKulAdi2.Text != "" && txtSifre2.Text != "")
            {
                SqlCommand giris = new SqlCommand("girisYap",bgl.baglan());
                giris.CommandType = CommandType.StoredProcedure;
                giris.Parameters.AddWithValue("kulAdi", txtKulAdi2.Text);
                giris.Parameters.AddWithValue("sifre", txtSifre2.Text);
                SqlDataReader dr = giris.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show("Giris islemi basarili", "Giris islemi basarili", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmAnaSayfa fr = new frmAnaSayfa();
                    this.Hide();
                    fr.Show();
                }
                else
                {
                    MessageBox.Show("Giris islemi basarisiz", "Giris islemi basarisiz", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Lutfen Tum Alanlari Doldurunuz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
