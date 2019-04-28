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
    public partial class BookList : Form
    {
        public BookList()
        {
            InitializeComponent();
        }

        private void BookList_Load(object sender, EventArgs e)
        {

            MainForm.Baglan.Close();
            MainForm.Baglan.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM Kitaplar", MainForm.Baglan);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            KitapListesi.DataSource = dt;
            MainForm.Baglan.Close();

        }
    }
}
