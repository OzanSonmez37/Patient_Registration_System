using System.Data.SqlClient;
namespace hastaTakipSistemi
{
    internal class frmSqlBaglanti
    {
        string adres = @"Data Source=OzanSonmez;Initial Catalog=db_HastaneYonetim;Integrated Security=True;Encrypt=False;";
        public SqlConnection baglan()
        {
            SqlConnection baglanti = new SqlConnection(adres);
            baglanti.Open();
            return baglanti;
        }
    }
}
