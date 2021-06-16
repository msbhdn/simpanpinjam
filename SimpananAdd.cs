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
    public partial class SimpananAdd : Form
    {
        CRUD crud = new CRUD();

        public SimpananAdd()
        {
            InitializeComponent();
            cbanggota();
            cbJsimpanan();
            dd();

        }

        private void dd()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
            crud.read_dataSimpanan();
            dataGridView1.DataSource = crud.dtSimpanan;

            dataGridView1.Columns[0].HeaderText = "No Anggota";
            dataGridView1.Columns[1].HeaderText = "NIPP";
            dataGridView1.Columns[2].HeaderText = "Nama";
            dataGridView1.Columns[3].HeaderText = "Jenis Simpan";
            dataGridView1.Columns[4].HeaderText = "Jumlah Simpan";
            dataGridView1.Columns[5].HeaderText = "Tanggal Simpan";

            dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // Resize the master DataGridView columns to fit the newly loaded data.
            dataGridView1.AutoResizeColumns();

            // Configure the details DataGridView so that its columns automatically
            // adjust their widths when the data changes.
            dataGridView1.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void cbanggota()
        {
            cbAnggota.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbAnggota.AutoCompleteSource = AutoCompleteSource.ListItems;

            crud.read_cbAnggota();

            cbAnggota.DataSource = crud.bankcbAnggota;
            cbAnggota.ValueMember = "anggota_no";
            cbAnggota.DisplayMember = "anggota_nama";

            cbAnggota.SelectedIndex = -1;
        }
        private void cbJsimpanan()
        {
            cbJSimpanan.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbJSimpanan.AutoCompleteSource = AutoCompleteSource.ListItems;

            crud.read_cbJsimpanan();

            cbJSimpanan.DataSource = crud.bankcbJsimpanan;
            cbJSimpanan.ValueMember = "js_id";
            cbJSimpanan.DisplayMember = "js_nama";

            cbJSimpanan.SelectedIndex = -1;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            Double value;
            if (Double.TryParse(textBox1.Text, out value))
                textBox1.Text = String.Format("{0:0,0.00}", value);
            else
                textBox1.Text = String.Empty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cbAnggota.SelectedIndex == -1)
            {
                MessageBox.Show("Anggota Tidak Boleh Kosong");
            }
            else if (cbJSimpanan.SelectedIndex == -1)
            {
                MessageBox.Show("Jenis Tidak Boleh Kosong");
            }
            else if (String.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Jumlah Tidak Boleh Kosong");
            }
            else
            {
                labelJumlahSimpan.Text = double.Parse(textBox1.Text).ToString("F2");
                using (OdbcConnection con = new OdbcConnection(@"Dsn=sisi;uid=root"))
                {
                    try
                    {

                        using (var cmd2 = new OdbcCommand("INSERT INTO tm_simpanan (simpanan_id, simpanan_tipe, simpanan_jumlah, simpanan_tggl, uuid, userid)" +
                            " VALUES (" +
                            "'" + this.cbAnggota.SelectedValue + "'," +
                            "'" + this.cbJSimpanan.SelectedValue + "'," +
                            "'" + this.labelJumlahSimpan.Text + "'," +
                            "'" + this.dateTimePicker1.Text + "'," +
                            "UUID()," +
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
                textBox1.Text = "";
                cbJSimpanan.SelectedIndex = -1;
                cbAnggota.SelectedIndex = -1;
                dd();
            }
        }
    }
}
