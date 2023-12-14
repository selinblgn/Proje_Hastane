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
    public partial class FrmBilgiDüzenle : Form
    {

        sqlbaglantisi bgl=new sqlbaglantisi();
        public FrmBilgiDüzenle()
        {
            InitializeComponent();
        }

        public string TCno;
        private void FrmBilgiDüzenle_Load(object sender, EventArgs e)
        {
            MskTc.Text = TCno;
            SqlCommand komut6 = new SqlCommand("Select * from Tbl_Hastalar where HastaTC=@p1",bgl.baglanti());
            komut6.Parameters.AddWithValue("@p1", MskTc.Text);
            SqlDataReader dr = komut6.ExecuteReader();
            while (dr.Read())
            {
                TxtAd.Text = dr[1].ToString(); 
                TxtSoyad.Text = dr[2].ToString();   
                MskTel.Text = dr[4].ToString();
                TxtSifre.Text = dr[5].ToString();
                CmbCinsiyet.Text = dr[6].ToString();    




            }

         bgl.baglanti().Close();

        }

        private void BtnBilgiGüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut7 = new SqlCommand("update Tbl_Hastalar set HastaAd=@p1 , HastaSoyad=@p2, HastaTelefon=@p3,HastaSifre=@p4,HastaCinsiyet=@p5 where HastaTc=@p6 ", bgl.baglanti() );
            komut7.Parameters.AddWithValue("@p1", TxtAd.Text);
            komut7.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            komut7.Parameters.AddWithValue("@p3",MskTel.Text);
            komut7.Parameters.AddWithValue("@p4",TxtSifre.Text);
            komut7.Parameters.AddWithValue("@p5", CmbCinsiyet.Text);
            komut7.Parameters.AddWithValue("@p6", MskTc.Text);
            komut7.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Bilgileriniz Güncellendi","Bilgi", MessageBoxButtons.OK,MessageBoxIcon.Warning);
     



        }
    }
}
