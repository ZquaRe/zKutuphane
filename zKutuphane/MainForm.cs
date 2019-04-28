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
    public partial class MainForm : Form
    {
        public static SqlConnection Baglan = new SqlConnection("Server=.;Database=zKutuphane;Trusted_Connection=True;");
        public MainForm()
        {
            InitializeComponent();
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            BarkodGrid.Visible = false;
            AcceptButton = AraBtn;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void AraBtn_Click(object sender, EventArgs e)
        {
            if (AraTxt.Text == "")
            {
                BarkodGrid.Visible = false;
                MessageBox.Show("Boş geçilemez.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                KayitGetir(AraTxt.Text);
                BarkodGrid.Visible = true;

            }
        }


        public static int SatirSayisi = 0;
        private void KayitGetir(string Barkod)
        {
            Baglan.Close();
            Baglan.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM Kitaplar WHERE Barkod=@Barkod ",Baglan);
            komut.Parameters.AddWithValue("@Barkod", AraTxt.Text);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            BarkodGrid.DataSource = dt;
            try
            {
                SatirSayisi = Convert.ToInt32(BarkodGrid.CurrentCell.Value);
            }
            catch (Exception)
            {

            }
            Baglan.Close();

            
        }

        private void BarkodGrid_DoubleClick(object sender, EventArgs e)
        {
            Books book = new Books();
            book.ShowDialog();


        }

        private void kitaplarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            BookList book = new BookList();
            book.ShowDialog();
        }

        private void yeniKitapKaydıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewBook book = new NewBook();
            book.ShowDialog();
        }
    }
}
