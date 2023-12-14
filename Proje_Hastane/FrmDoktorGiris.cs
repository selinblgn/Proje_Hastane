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
    public partial class FrmDoktorGiris : Form
    {
        public FrmDoktorGiris()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl=new sqlbaglantisi();
        private void BtnGirisYap_Click(object sender, EventArgs e)
        {
            SqlCommand komut12 = new SqlCommand("select * from Tbl_Doktorlar where DoktorTC=@p1 and DoktorSifre=@p2",bgl.baglanti());
            komut12.Parameters.AddWithValue("@p1", MskTc.Text);
            komut12.Parameters.AddWithValue("@p2", TxtSifre.Text);

           SqlDataReader dr= komut12.ExecuteReader();
            if (dr.Read())
            {
                FrmDoktorDetay frmDoktorDetay = new FrmDoktorDetay();  
                frmDoktorDetay.TC=MskTc.Text;
                frmDoktorDetay.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Hatalı Giriş");


            }
        
           bgl.baglanti().Close();
        }
    }
}
