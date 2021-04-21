using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Odbc;
using simpanpinjam.myclass;

namespace simpanpinjam
{
    public partial class RefDep : Form
    {
        CRUD crud = new CRUD();
        public RefDep()
        {
            InitializeComponent();
            READ();
        }

        public void READ()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
            crud.read_RefDep();
            dataGridView1.DataSource = crud.dtRefDep;

            dataGridView1.Columns[0].HeaderText = "Dept ID";
            dataGridView1.Columns[1].HeaderText = "Unit Kerja";

            // Resize the master DataGridView columns to fit the newly loaded data.
            dataGridView1.AutoResizeColumns();

            // Configure the details DataGridView so that its columns automatically
            // adjust their widths when the data changes.
            dataGridView1.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //CREATE
            if (String.IsNullOrEmpty(tb_depID.Text))
            {
                MessageBox.Show("ID Tidak Boleh Kosong");
            }
            else if (String.IsNullOrEmpty(tb_depNAME.Text))
            {
                MessageBox.Show("Unit Kerja Tidak Boleh Kosong");
            }
            else
            {
                crud.depID = tb_depID.Text;
                crud.depNAME = tb_depNAME.Text;
                crud.create_RefDep();
                READ();
                tb_depID.Text = "";
                tb_depNAME.Text = "";
            }
        }
        private void btn_update_Click(object sender, EventArgs e)
        {
            crud.depID = tb_depID2.Text;
            crud.depNAME = tb_depNAME2.Text;
            crud.update_RefDep();
            READ();
        }
        private void btn_delete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Apakah anda yakin akan menghapus data ini ?", "Hapus Data", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                crud.depID = tb_depID2.Text;
                crud.depNAME = tb_depNAME2.Text;
                crud.delete_RefDep();
                READ();
                tb_depID2.Text = "";
                tb_depNAME2.Text = "";
            }
            else if (dialogResult == DialogResult.No)
            {
                tb_depID2.Text = "";
                tb_depNAME2.Text = "";
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //GET DATA
            DataGridView senderGrid = (DataGridView)sender;
            try
            {
                if(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    tb_depID2.Text = (dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                    tb_depNAME2.Text = (dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                }
            }
            catch
            {
                MessageBox.Show("Don't click the header!");
            }
        }
    }
}
