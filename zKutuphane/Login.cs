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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            AcceptButton = LoginBtn;
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            MainForm.Baglan.Close();
            SqlCommand komut = new SqlCommand("SELECT * FROM Kullanicilar WHERE KullaniciAdi = @Kullanici", MainForm.Baglan);
            komut.Parameters.AddWithValue("@Kullanici", UsernameTxt.Text);
            MainForm.Baglan.Open();

            SqlDataReader dr = komut.ExecuteReader(); //Data Reader tekli veri çekmeye yarar

            if (dr.Read()) //Veri var mı kontrolü yapıyoruz
            {
                if (PasswordTxt.Text == dr["KullaniciSifre"].ToString())
                {
                    MainForm frm = new MainForm();
                    frm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Şifre Yanlış","Hata",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }



            }
            else
            {
                MessageBox.Show("Kullanıcı bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

            dr.Close();
            MainForm.Baglan.Close();

        }
    }
}
