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
    public partial class FrmSekreterGiris : Form
    {
        public FrmSekreterGiris()
        {
            InitializeComponent();
        }

        private void FrmSekreterGiris_Load(object sender, EventArgs e)
        {

        }
        sqlbaglantisi bgl=new sqlbaglantisi();
        private void BtnGirisYap_Click(object sender, EventArgs e)
        {

            SqlCommand komut8 = new SqlCommand("select * from Tbl_Sekreter where SekreterTC=@p1 and SekreterSifre=@p2",bgl.baglanti());
            komut8.Parameters.AddWithValue("@p1", MskTc.Text);
            komut8.Parameters.AddWithValue("@p2", TxtSifre.Text);
            SqlDataReader dr=komut8.ExecuteReader();
            if (dr.Read())
            {
                FrmSekreterDetay frs=new FrmSekreterDetay();
                frs.TCnumara=MskTc.Text;
                
                frs.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Hatalı TC & Şifre");


            }
            bgl.baglanti().Close();
        }
    }
}
