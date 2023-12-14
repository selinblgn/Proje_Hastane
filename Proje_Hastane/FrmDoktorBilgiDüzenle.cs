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
    public partial class FrmDoktorBilgiDüzenle : Form
    {
        public FrmDoktorBilgiDüzenle()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl=new sqlbaglantisi();
        public string TCNO;
        private void FrmDoktorBilgiDüzenle_Load(object sender, EventArgs e)
        {

            MskTc.Text = TCNO;
            SqlCommand sql = new SqlCommand("SELECT * FROM Tbl_Doktorlar where DoktorTC='"+MskTc.Text+"'", bgl.baglanti());
            SqlDataReader reader = sql.ExecuteReader(); 
            while (reader.Read())
            {
                TxtAd.Text = reader[1].ToString();
                TxtSoyad.Text = reader[2].ToString();
                CmbBrans.Text= reader[3].ToString();
                TxtSifre.Text = reader[5].ToString();   

            }
        
             bgl.baglanti().Close();
        }

        private void BtnBilgiGüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand sql = new SqlCommand("update Tbl_Doktorlar set DoktorAd=@p1,DoktorSoyad=@p2,DoktorBrans=@p3,DoktorSifre=@p4 where DoktorTC=@p5 ",bgl.baglanti());
            sql.Parameters.AddWithValue("@p1",TxtAd.Text);
            sql.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            sql.Parameters.AddWithValue("@p3", CmbBrans.Text);
            sql.Parameters.AddWithValue("@p4", TxtSifre.Text);
            sql.Parameters.AddWithValue("@p5", MskTc.Text);
            sql.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kayıt Güncellendi");


        }
    }
}
