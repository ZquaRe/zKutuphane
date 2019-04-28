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
    public partial class NewBook : Form
    {
        public NewBook()
        {
            InitializeComponent();
        }

        private void KaydetBtn_Click(object sender, EventArgs e)
        {
            if(BarkodTxt.Text == "" || KitapAdiTxt.Text == "" || KitapYazarTxt.Text == "" || YayinEviTxt.Text == "" || BasimTarihiTxt.Text == "" || BasimSayisiTxt.Text == "")
            {
                MessageBox.Show("Alanları doldurunuz.");
            }
            else
            {
                KitapKaydet();
            }
        }

        private void NewBook_Load(object sender, EventArgs e)
        {
            AcceptButton = KaydetBtn;
        }

        private void KitapKaydet()
        {


            MainForm.Baglan.Close();
            MainForm.Baglan.Open();
            SqlCommand komut = new SqlCommand("INSERT INTO Kitaplar(Barkod, KitapAd, KitapYazar, KitapYayin, KitapCikisTarihi, KitapBasim) VALUES(@Barkod, @KitapAd, @KitapYazar, @KitapYayin, @KitapCikisTarihi, @KitapBasim)", MainForm.Baglan);
            komut.Parameters.AddWithValue("@Barkod", BarkodTxt.Text);
            komut.Parameters.AddWithValue("@KitapAd", KitapAdiTxt.Text);
            komut.Parameters.AddWithValue("@KitapYazar", KitapYazarTxt.Text);
            komut.Parameters.AddWithValue("@KitapYayin", YayinEviTxt.Text);
            komut.Parameters.AddWithValue("@KitapCikisTarihi", BasimTarihiTxt.Text);
            komut.Parameters.AddWithValue("@KitapBasim", BasimSayisiTxt.Text);

            try
            {
                int Kayit = komut.ExecuteNonQuery();
                MessageBox.Show("Kayıt başarılı", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.None);
                this.Close();
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.ToString());
            }

            MainForm.Baglan.Close();
        }
    }
}
