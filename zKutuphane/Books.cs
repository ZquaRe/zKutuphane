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

namespace zKutuphane
{
    public partial class Books : Form
    {
        public Books()
        {
            InitializeComponent();
        }

        private void GuncelleBtn_Click(object sender, EventArgs e)
        {

            KitapGuncelle(Convert.ToInt32(MainForm.SatirSayisi));
        }

        private void Books_Load(object sender, EventArgs e)
        {
            KitapListele(Convert.ToInt32(MainForm.SatirSayisi));
        }


        private void KitapListele(int KutuphaneID)
        {
            MainForm.Baglan.Close();
            SqlCommand komut = new SqlCommand("SELECT * FROM Kitaplar WHERE KutuphaneID = @Kutuphane", MainForm.Baglan);
            komut.Parameters.AddWithValue("@Kutuphane", KutuphaneID);
            MainForm.Baglan.Open();

            SqlDataReader dr = komut.ExecuteReader();


            if (dr.Read())
            {
                BarkodTxt.Text = dr["Barkod"].ToString();
                KitapAdiTxt.Text = dr["KitapAd"].ToString();
                KitapYazarTxt.Text = dr["KitapYazar"].ToString();
                YayinEviTxt.Text = dr["KitapYayin"].ToString();
                BasimTarihiTxt.Text = dr["KitapCikisTarihi"].ToString();
                BasimSayisiTxt.Text = dr["KitapBasim"].ToString();



            }
            else
            {

                this.Hide();
            }

            dr.Close();
            MainForm.Baglan.Close();
        }

        private void KitapGuncelle(int KutuphaneID)
        {
            MainForm.Baglan.Close();
            MainForm.Baglan.Open();
            SqlCommand komut = new SqlCommand("UPDATE Kitaplar set Barkod=@Barkod,KitapAd=@KitapAd,KitapYazar=@KitapYazar,KitapYayin=@KitapYayin,KitapCikisTarihi=@KitapCikisTarihi,KitapBasim=@KitapBasim WHERE KutuphaneID = @ID", MainForm.Baglan);
            komut.Parameters.AddWithValue("@ID", KutuphaneID);
            komut.Parameters.AddWithValue("@Barkod", BarkodTxt.Text);
            komut.Parameters.AddWithValue("@KitapAd", KitapAdiTxt.Text);
            komut.Parameters.AddWithValue("@KitapYazar", KitapYazarTxt.Text);
            komut.Parameters.AddWithValue("@KitapYayin", YayinEviTxt.Text);
            komut.Parameters.AddWithValue("@KitapCikisTarihi", BasimTarihiTxt.Text);
            komut.Parameters.AddWithValue("@KitapBasim", BasimSayisiTxt.Text);

            try
            {
                int Kayit = komut.ExecuteNonQuery();
                MessageBox.Show("Güncelleme başarılı", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message);
            }

            MainForm.Baglan.Close();

        }

        private void KitapSil(int KutuphaneID)
        {
            MainForm.Baglan.Close();
            MainForm.Baglan.Open();
            SqlCommand komut = new SqlCommand("DELETE FROM Kitaplar WHERE KutuphaneID = @ID", MainForm.Baglan);
            komut.Parameters.AddWithValue("@ID", KutuphaneID);

            try
            {
                int Kayit = komut.ExecuteNonQuery();
                MessageBox.Show("Silme başarılı", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.None);
                this.Hide();
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message);
            }

            MainForm.Baglan.Close();
        }

        private void SilBtn_Click(object sender, EventArgs e)
        {
            KitapSil(Convert.ToInt32(MainForm.SatirSayisi));
        }
    }
}
