using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using simpanpinjam.myclass;

namespace simpanpinjam
{
    public partial class angsuran : Form
    {
        CRUD crud = new CRUD();
        public angsuran()
        {
            InitializeComponent();
        }
        private void dd()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
            crud.read_CekAngsuran(tb_nopinjam.Text);
            dataGridView1.DataSource = crud.dtAngsuran;

            dataGridView1.Columns[0].HeaderText = "No Angsuran";
            dataGridView1.Columns[1].HeaderText = "Angsuran Ke";
            dataGridView1.Columns[2].HeaderText = "Tanggal";
            dataGridView1.Columns[3].HeaderText = "Jumlah Angsuran";
            dataGridView1.Columns[4].HeaderText = "Status";

            dataGridView1.Columns[5].Visible = false;

            // Resize the master DataGridView columns to fit the newly loaded data.
            dataGridView1.AutoResizeColumns();

            // Configure the details DataGridView so that its columns automatically
            // adjust their widths when the data changes.
            dataGridView1.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
        }

        public static DataRow Row { get; set; }
        private void button2_Click(object sender, EventArgs e)
        {
            //crud.angsurid = tb_nopinjam.Text;
            //MessageBox.Show(crud.angsurid);
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("angsurid", typeof(string)));
            DataRow dr = dt.NewRow();
            dr["angsurid"] = tb_nopinjam.Text.Trim();
            dt.Rows.Add(dr);
            Row = dt.Rows[0];

            crud.read_bayarangsur(tb_nopinjam.Text);
            if (crud.dtBayar.Rows.Count == 0)
            {
                MessageBox.Show("Angsuran tidak ditemukan / tidak ada tagihan / sudah lunas");
            }
            else
            {
                new bayarangsuran().Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            crud.conClose();
            dd();
        }
    }
}
