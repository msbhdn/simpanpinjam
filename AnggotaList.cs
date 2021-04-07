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
    public partial class AnggotaList : Form
    {
        CRUD crud = new CRUD();

        public AnggotaList()
        {
            InitializeComponent();
            dd();
            cbDept();
        }
 
        private void dd()
        {
            dataGridView1.DataSource = null;
            crud.read_dataAnggota();
            dataGridView1.DataSource = crud.dtAnggota;

            dataGridView1.Columns[0].HeaderText = "No Anggota";
            dataGridView1.Columns[1].HeaderText = "NIPP";
            dataGridView1.Columns[2].HeaderText = "Nama";
            dataGridView1.Columns[3].HeaderText = "Jabatan";
            dataGridView1.Columns[4].HeaderText = "Unit Kerja";

            // Resize the master DataGridView columns to fit the newly loaded data.
            dataGridView1.AutoResizeColumns();

            // Configure the details DataGridView so that its columns automatically
            // adjust their widths when the data changes.
            dataGridView1.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void cbDept()
        {
            cb_dept.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cb_dept.AutoCompleteSource = AutoCompleteSource.ListItems;

            crud.read_cbDept();

            cb_dept.DataSource = crud.bankcbDept;
            cb_dept.ValueMember = "dept_id";
            cb_dept.DisplayMember = "dept_nama";
            cb_dept.SelectedIndex = -1;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tb_nipp.Text))
            {
                MessageBox.Show("NIPP Tidak Boleh Kosong");
            }
            else if (String.IsNullOrEmpty(tb_nama.Text))
            {
                MessageBox.Show("Nama Tidak Boleh Kosong");
            }
            else if (String.IsNullOrEmpty(tb_jab.Text))
            {
                MessageBox.Show("Jabatan Tidak Boleh Kosong");
            }
            else if (cb_dept.SelectedIndex == -1)
            {
                MessageBox.Show("Unit Kerja Tidak Boleh Kosong");
            }
            else
            {
                using (OdbcConnection con = new OdbcConnection(@"Dsn=sisi;uid=root"))
                {
                    try
                    {

                        using (var cmd2 = new OdbcCommand("INSERT INTO tm_anggota (anggota_no, anggota_nipp, anggota_nama, anggota_jab, anggota_dept, userid)" +
                            " VALUES (" +
                            "getanggotano()," +
                            "'" + this.tb_nipp.Text + "'," +
                            "'" + this.tb_nama.Text + "'," +
                            "'" + this.tb_jab.Text + "'," +
                            "'" + this.cb_dept.SelectedValue + "'," +
                            "'" + global.userid + "'" +
                            ")"))
                        {

                            cmd2.Connection = con;

                            con.Open();
                            if (cmd2.ExecuteNonQuery() > 0)
                            {
                                MessageBox.Show("Record inserted");
                            }
                            else
                            {
                                MessageBox.Show("Record failed");
                            }
                        }
                    }
                    catch (Exception c)
                    {
                        MessageBox.Show("Error during insert: " + c.Message);
                    }
                }
                tb_nipp.Text = "";
                tb_nama.Text = "";
                tb_jab.Text = "";
                cb_dept.SelectedIndex = -1;
                dataGridView1.DataSource = null;
                dataGridView1.Refresh();
                dd();
            }
        }

        private void tb_cari_TextChanged(object sender, EventArgs e)
        {
            crud.read_SdataAnggota(tb_cari.Text);
            dataGridView1.DataSource = crud.dtSanggota;
            crud.conClose();
        }
    }
}
