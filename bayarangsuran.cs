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
using System.Data.Odbc;

namespace simpanpinjam
{
    public partial class bayarangsuran : Form
    {
        CRUD crud = new CRUD();
        public bayarangsuran()
        {
            InitializeComponent();
            nopinjaman.Text = angsuran.Row["angsurid"].ToString();
            dd();
        }

        private void dd()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
            crud.read_bayarangsur(nopinjaman.Text);
            dataGridView1.DataSource = crud.dtBayar;

            dataGridView1.Columns[0].HeaderText = "No Angsuran";
            dataGridView1.Columns[3].HeaderText = "Angsuran Ke";
            dataGridView1.Columns[2].HeaderText = "Tanggal";
            dataGridView1.Columns[4].HeaderText = "Jumlah Angsuran";

            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[9].Visible = false;
            dataGridView1.Columns[10].Visible = false;
            dataGridView1.Columns[11].Visible = false;
            dataGridView1.Columns[12].Visible = false;
            dataGridView1.Columns[13].Visible = false;

            // Resize the master DataGridView columns to fit the newly loaded data.
            dataGridView1.AutoResizeColumns();

            // Configure the details DataGridView so that its columns automatically
            // adjust their widths when the data changes.
            dataGridView1.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            
                //DATASET
                noanggota.Text = crud.dtBayar.Rows[0].Field<string>("anggota_no");
                nipp.Text = crud.dtBayar.Rows[0].Field<string>("anggota_nipp");
                nama.Text = crud.dtBayar.Rows[0].Field<string>("anggota_nama");
                jabatan.Text = crud.dtBayar.Rows[0].Field<string>("anggota_jab");
                unitkerja.Text = crud.dtBayar.Rows[0].Field<string>("dept_nama");

                crud.read_totalbayar(nopinjaman.Text);
                totalbayar.Text = crud.dtTotal.Rows[0].Field<double>("tmp_bayar").ToString("N2");
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (OdbcConnection con = new OdbcConnection(@"Dsn=sisi;uid=root"))
            {
                try
                {

                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        using (var cmd = new OdbcCommand("UPDATE tm_angsur SET status=1 WHERE angsur_no='" + dataGridView1.Rows[i].Cells[0].Value.ToString().Trim() + "'"))
                        {

                            cmd.Connection = con;

                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                }
                catch (Exception c)
                {
                    MessageBox.Show("Error during insert: " + c.Message);
                }
            }
            //Console.WriteLine(dataGridView1.Rows[i].Cells[0].Value.ToString().Trim());
            
        }
    }
}
