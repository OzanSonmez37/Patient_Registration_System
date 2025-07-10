using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace hastaTakipSistemi
{
    public partial class frmIstatistic : Form
    {
        public frmIstatistic()
        {
            InitializeComponent();
        }
        frmSqlBaglanti bgl = new frmSqlBaglanti();

        private void frmIstatistic_Load(object sender, EventArgs e)
        {
            toplamHasta();
            yasOrtalama();
            erkekSayi();
            kadinSayi();
            exSayi();
        }

        private void toplamHasta()
        {
            SqlCommand toplam = new SqlCommand("select COUNT(*) from tbl_HastaBilgi", bgl.baglan());
            SqlDataReader dr = toplam.ExecuteReader();
            while(dr.Read())
            {
                lblToplamHasta.Text = dr[0].ToString();
            }
        }

        private void yasOrtalama()
        {
            SqlCommand ortalama = new SqlCommand("select AVG(hyas) from tbl_HastaBilgi", bgl.baglan());
            SqlDataReader dr = ortalama.ExecuteReader();
            while (dr.Read())
            {
                lblYasOrtalama.Text = dr[0].ToString();
            }
        }

        private void erkekSayi()
        {
            SqlCommand erkekSayi = new SqlCommand("select COUNT(*) from tbl_HastaBilgi where hCinsiyet = 'Erkek'", bgl.baglan());
            SqlDataReader dr = erkekSayi.ExecuteReader();
            while (dr.Read())
            {
                lblErkekSayi.Text = dr[0].ToString();
            }
        }

        private void kadinSayi()
        {
            SqlCommand kadinSayi = new SqlCommand("select COUNT(*) from tbl_HastaBilgi where hCinsiyet = 'Kadın'", bgl.baglan());
            SqlDataReader dr = kadinSayi.ExecuteReader();
            while (dr.Read())
            {
                lblKadinSayi.Text = dr[0].ToString();
            }
        }

        private void exSayi()
        {
            SqlCommand exSayi = new SqlCommand("select COUNT(*) from tbl_HastaBilgi where hExMi = 1", bgl.baglan());
            SqlDataReader dr = exSayi.ExecuteReader();
            while (dr.Read())
            {
                lblExSayi.Text = dr[0].ToString();
            }
        }
    }
}
