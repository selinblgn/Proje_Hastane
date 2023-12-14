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
    public partial class FrmBrans : Form
    {
        public FrmBrans()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();

        private void FrmBrans_Load(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from Tbl_Branslar", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;


        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("insert into Tbl_Branslar (BransAd) values (@b1)", bgl.baglanti());
            cmd.Parameters.AddWithValue("@b1", TxtBransAd.Text);
            cmd.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Branş Eklendi", "Bigi", MessageBoxButtons.OK, MessageBoxIcon.Information);



        }

        private void BtnSil_Click(object sender, EventArgs e)
        {

            SqlCommand sqlCommand = new SqlCommand( "delete from Tbl_Branslar where BransId=@b1 ",bgl.baglanti());
            sqlCommand.Parameters.AddWithValue("@b1", TxtBransId.Text);
            sqlCommand.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Branş Silindi");



        }
        /*
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
         {
          int secilen = dataGridView1.SelectedCells[0].RowIndex;
          TxtBransId = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
          TxtBransAd = dataGridView1.Rows[secilen].Cells[1].Value.ToString();



         }
        */

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the clicked cell is not in the header row
            if (e.RowIndex >= 0)
            {
                int secilen = e.RowIndex;
                TxtBransId.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
                TxtBransAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            }





        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int secilen = e.RowIndex;
                TxtBransId.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
                TxtBransAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            }


        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand sqlCommand = new SqlCommand("update Tbl_Branslar set BransAd=@b1 where BransId=@b2 ",bgl.baglanti());
            sqlCommand.Parameters.AddWithValue("@b1", TxtBransAd.Text);
            sqlCommand.Parameters.AddWithValue("@b2", TxtBransId.Text);
            sqlCommand.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Branş Güncellendi");



        }
    }
}
