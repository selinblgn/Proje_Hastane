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
    public partial class FrmDuyurular : Form
    {
        public FrmDuyurular()
        {
            InitializeComponent();
        }
        sqlbaglantisi sqlbaglantisi = new sqlbaglantisi();
        private void FrmDuyurular_Load(object sender, EventArgs e)
        {   DataTable dt = new DataTable();
            SqlDataAdapter sqlCommand = new SqlDataAdapter("Select * from Tbl_Duyurular ", sqlbaglantisi.baglanti());
           sqlCommand.Fill(dt); 
            dataGridView1.DataSource = dt;
        }
    }
}
