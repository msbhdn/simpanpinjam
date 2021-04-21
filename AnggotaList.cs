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
            dataGridView1.Refresh();
            crud.read_dataAnggota();
            dataGridView1.DataSource = crud.dtAnggota;

            dataGridView1.Columns[0].HeaderText = "No Anggota";
            dataGridView1.Columns[1].HeaderText = "NIPP";
            dataGridView1.Columns[2].HeaderText = "Nama";
            dataGridView1.Columns[3].HeaderText = "Jabatan";
            dataGridView1.Columns[4].HeaderText = "Unit Kerja";

            dataGridView1.Columns[5].Visible = false;

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
            if (String.IsNullOrEmpty(crud.AID))
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
                    crud.Anipp = tb_nipp.Text;
                    crud.Anama = tb_nama.Text;
                    crud.Ajab = tb_jab.Text;
                    crud.Adept = cb_dept.SelectedValue;
                    crud.create_dataAnggota();
                    dd();
                    tb_nipp.Text = "";
                    tb_nama.Text = "";
                    tb_jab.Text = "";
                    cb_dept.SelectedIndex = -1;
                }
            }
            else
            {
                //MessageBox.Show(crud.AID);
                crud.Anipp = tb_nipp.Text;
                crud.Anama = tb_nama.Text;
                crud.Ajab = tb_jab.Text;
                crud.Adept = cb_dept.SelectedValue;
                crud.update_dataAnggota();
                dd();
            }
        }

        private void tb_cari_TextChanged(object sender, EventArgs e)
        {
            crud.read_SdataAnggota(tb_cari.Text);
            dataGridView1.DataSource = crud.dtSanggota;
            crud.conClose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(crud.AID);
            //new AnggotaAdd().Show();
            crud.AID = "";
            tb_nipp.Text = "";
            tb_nama.Text = "";
            tb_jab.Text = "";
            cb_dept.SelectedIndex = -1;
            btn_add.Text = "Simpan";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    crud.AID = (dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                    tb_nipp.Text = (dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                    tb_nama.Text = (dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                    tb_jab.Text = (dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
                    cb_dept.SelectedValue = (dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString());

                    btn_add.Text = "Update";
                }
            }
            catch
            {
                MessageBox.Show("Don't click the header!");
            }
        }
    }
}
