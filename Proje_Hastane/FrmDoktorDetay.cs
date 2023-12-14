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

namespace Proje_Hastane
{
    public partial class FrmDoktorDetay : Form
    {
        public FrmDoktorDetay()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl=new sqlbaglantisi();
        public string TC;


        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void FrmDoktorDetay_Load(object sender, EventArgs e)
        {
          
            LblTC.Text = TC;

            //Doktor AdSoyad Çekme

            SqlCommand kmt = new SqlCommand("select DoktorAd,DoktorSoyad from Tbl_Doktorlar where DoktorTC='"+LblTC.Text+"' ",bgl.baglanti());
            SqlDataReader dr= kmt.ExecuteReader();
            while (dr.Read())
            {
                LblAdsoyad.Text = dr[0]+" " + dr[1];

            }
            bgl.baglanti().Close();

            //Randevular
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from Tbl_Randevular where RandevuDoktor='"+LblAdsoyad.Text+"'", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            bgl.baglanti().Close();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void BTnBilgiDüzenle_Click(object sender, EventArgs e)
        {
            FrmDoktorBilgiDüzenle fr=new FrmDoktorBilgiDüzenle();
            fr.TCNO=LblTC.Text;
            fr.Show();

        }

        private void BtnDuyurular_Click(object sender, EventArgs e)
        {
            FrmDuyurular dy=new FrmDuyurular();
            dy.Show();

        }

        private void BtnCıkıs_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            RbSikayet.Text =dataGridView1.Rows[secilen].Cells[7].Value.ToString();



        }
    }
}
