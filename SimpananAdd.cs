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

namespace simpanpinjam
{
    public partial class SimpananAdd : Form
    {
        public SimpananAdd()
        {
            InitializeComponent();
            cbanggota();
            cbJsimpanan();
            dd();

        }
        OdbcConnection koneksi = new OdbcConnection(@"Dsn=sisi;uid=root");

        private void dd()
        {
            DataTable dt = new DataTable();

            OdbcDataAdapter da = new OdbcDataAdapter("select * from v_simpanan", koneksi);
            da.Fill(dt);

            foreach (DataRow row in dt.Rows)
            {
                ListViewItem item = new ListViewItem(row[0].ToString());
                for (int i = 1; i < dt.Columns.Count; i++)
                {
                    item.SubItems.Add(row[i].ToString());
                }
                listView1.Items.Add(item);
            }
            listView1.Columns[0].Width = -2;
            listView1.Columns[1].Width = -2;
            listView1.Columns[2].Width = -2;
            listView1.Columns[3].Width = -2;
            listView1.Columns[4].Width = -2;
            listView1.Columns[5].Width = -2;
            listView1.Columns[6].Width = -2;
            listView1.Columns[7].Width = -1;
        }
        private void cbanggota()
        {
            DataTable temp = new DataTable();
            DataTable bank = new DataTable();
            cbAnggota.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbAnggota.AutoCompleteSource = AutoCompleteSource.ListItems;

            OdbcCommand cmd = new OdbcCommand("select anggota_no, anggota_nama from tm_anggota", koneksi);
            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
            da.SelectCommand = cmd;
            da.Fill(temp);
            DataView dtvw = new DataView(temp);
            bank = dtvw.ToTable();
            cbAnggota.DataSource = bank;
            cbAnggota.ValueMember = "anggota_no";
            cbAnggota.DisplayMember = "anggota_nama";

            cbAnggota.SelectedIndex = -1;
        }
        private void cbJsimpanan()
        {
            DataTable temp = new DataTable();
            DataTable bank = new DataTable();
            cbJSimpanan.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbJSimpanan.AutoCompleteSource = AutoCompleteSource.ListItems;

            OdbcCommand cmd = new OdbcCommand("select js_id, js_nama from tr_simpanan", koneksi);
            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
            da.SelectCommand = cmd;
            da.Fill(temp);
            DataView dtvw = new DataView(temp);
            bank = dtvw.ToTable();
            cbJSimpanan.DataSource = bank;
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
                listView1.Items.Clear();
                dd();
            }
        }
    }
}
