﻿using System;
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
    public partial class FrmHastaDetay2 : Form
    {
        public FrmHastaDetay2()
        {
            InitializeComponent();
        }
        public string tc;
        sqlbaglantisi bgl=new sqlbaglantisi();
        private void FrmHastaDetay2_Load(object sender, EventArgs e)
        {
           LblTc.Text= tc;
            //AdSoyad Çekme
            SqlCommand komut = new SqlCommand("Select HastaAd,HastaSoyad from Tbl_Hastalar where HastaTC=@p1",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",LblTc.Text);
            SqlDataReader dr= komut.ExecuteReader();
            while(dr.Read())
            {
                LblAdSoyad.Text = dr[0] + " " + dr[1];


            }

            bgl.baglanti().Close();

            //Randevu Geçmişi
            DataTable dt= new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Randevular where HastaTC= '" + LblTc.Text + "' ", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource= dt;



            //Branşları Çekme

            SqlCommand komut2 = new SqlCommand("Select BransAd From Tbl_Branslar ", bgl.baglanti());
            SqlDataReader dr2=komut2.ExecuteReader();
            while (dr2.Read())
            {

                CmbBrans.Items.Add(dr2[0]);

            }
            bgl.baglanti().Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CmbBrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbDoktor.Items.Clear();
            SqlCommand komut3 = new SqlCommand("Select DoktorAd,DoktorSoyad From Tbl_Doktorlar where DoktorBrans=@p1",bgl.baglanti());
            komut3.Parameters.AddWithValue("@p1", CmbBrans.Text);
            SqlDataReader dr3=komut3.ExecuteReader();
            while(dr3.Read())
            {

                CmbDoktor.Items.Add(dr3[0]+ " "+ dr3[1]) ;
            }
            bgl.baglanti().Close() ;

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           int secilen = dataGridView2.SelectedCells[0].RowIndex;
            TxtId.Text = dataGridView2.Rows[secilen].Cells[0].Value.ToString();

        }

        private void CmbDoktor_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Randevular where RandevuBrans='" + CmbBrans.Text + "' and RandevuDoktor='" + CmbDoktor.Text + "' and  RandevuDurum=0 ", bgl.baglanti());
            da.Fill(dt);

            dataGridView2.DataSource = dt;


        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmBilgiDüzenle fr = new FrmBilgiDüzenle();
            fr.TCno = LblTc.Text;
            fr.Show();


        }

        
        private void BtnRandevuAl_Click(object sender, EventArgs e)
        {
          SqlCommand sqlCommand = new SqlCommand("update Tbl_Randevular set RandevuDurum=1,HastaTC=@p1,HastaSikayet=@p2 where RandevuId=@p3 ",bgl.baglanti());
          sqlCommand.Parameters.AddWithValue("@p1", LblTc.Text);
          sqlCommand.Parameters.AddWithValue("@p2", RtbSikayet.Text);
          sqlCommand.Parameters.AddWithValue("@p3", TxtId.Text);
          sqlCommand.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Randevu Alındı", "Uyarı",  MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        
        } 
    }
}
