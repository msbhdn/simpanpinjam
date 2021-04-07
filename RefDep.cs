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
            dd();
        }

        private void dd()
        {
            dataGridView1.DataSource = null;
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
    }
}
