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
    public partial class FrmSekreterDetay : Form
    {
        public FrmSekreterDetay()
        {
            InitializeComponent();
        }


        public string TCnumara;
        sqlbaglantisi bgl=new sqlbaglantisi();
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void FrmSekreterDetay_Load(object sender, EventArgs e)
        {
            //Ad Soyad

            LblTC.Text= TCnumara;
            SqlCommand cmd = new SqlCommand("Select SekreterAdsoyad from Tbl_Sekreter where SekreterTC=@p1", bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1", LblTC.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read()) {

                LblAdSoyad.Text = dr[0].ToString();

            }
         bgl.baglanti().Close();  
            

            //Branşları Çekme 
             
            DataTable dt1=new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select BransAd from Tbl_Branslar ", bgl.baglanti());
            da.Fill(dt1);
            dataGridView2.DataSource = dt1;


            //Doktorları listeye aktarma

            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("Select (DoktorAd+' ' +DoktorSoyad) as 'Doktorlar', DoktorBrans from Tbl_Doktorlar ", bgl.baglanti());
            da2.Fill(dt2);
            dataGridView3.DataSource = dt2;


            //Branşı comboboxa aktarma

            SqlCommand cmd2 = new SqlCommand("Select BransAd from  Tbl_Branslar", bgl.baglanti());
            SqlDataReader dr2 = cmd2.ExecuteReader();
            while(dr2.Read())
            {
                CmbBrans.Items.Add(dr2[0]);

            }

              bgl.baglanti().Close();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {

            SqlCommand komut9 = new SqlCommand("insert into Tbl_Randevular(RandevuTarih,RandevuSaat,RandevuBrans,RandevuDoktor) values (@r1,@r2,@r3,@r4) ",bgl.baglanti());
            komut9.Parameters.AddWithValue("@r1", MskTarih.Text);
            komut9.Parameters.AddWithValue("@r2", MskSaat.Text);
            komut9.Parameters.AddWithValue("@r3", CmbBrans.Text);
            komut9.Parameters.AddWithValue("@r4", CmbDoktor.Text);
            komut9.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Randevu Oluşturuldu");



        }

        private void CmbBrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbDoktor.Items.Clear();
            SqlCommand komut9 = new SqlCommand("Select DoktorAd, DoktorSoyad from Tbl_Doktorlar where DoktorBrans=@p1", bgl.baglanti());
            komut9.Parameters.AddWithValue("@p1", CmbBrans.Text);
            SqlDataReader dr= komut9.ExecuteReader();
            while (dr.Read())
            {
                CmbDoktor.Items.Add(dr[0] +" " + dr[1]);
            }
        
          bgl.baglanti().Close();   
        }

        private void RcbDuyuruOLustur_TextChanged(object sender, EventArgs e)
        {
                 
        }

        private void BtnDuyuruOlustur_Click(object sender, EventArgs e)
        {
            SqlCommand komut9 = new SqlCommand("insert into Tbl_Duyurular (duyuru) values (@d1)", bgl.baglanti());
            komut9.Parameters.AddWithValue("@d1", RcbDuyuruOLustur.Text);
            komut9.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Duyuru Oluşturuldu");
        }

        private void BtnDoktorPaneli_Click(object sender, EventArgs e)
        {
            FrmDoktorPaneli drp = new FrmDoktorPaneli();
            drp.Show();
        }

        private void BtnBransPaneli_Click(object sender, EventArgs e)
        {
            FrmBrans frp=new FrmBrans();
            frp.Show();
        }

        private void BtnRandevuListesi_Click(object sender, EventArgs e)
        {
            FrmRandevuListesi rand=new FrmRandevuListesi();
            rand.Show();
        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
          
        }

        private void BtnDuyurular_Click(object sender, EventArgs e)
        {
            FrmDuyurular duyurular = new FrmDuyurular();
            duyurular.Show();
        }
    }
}
