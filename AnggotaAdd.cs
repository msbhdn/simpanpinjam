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
    public partial class AnggotaAdd : Form
    {
        OdbcConnection koneksi = new OdbcConnection(@"Dsn=sisi;uid=root");
        public AnggotaAdd()
        {
            InitializeComponent();
            Cbdept();
        }
        private void Cbdept()
        {
            DataTable dta = new DataTable();
            OdbcCommand cmd = new OdbcCommand("select * from tr_dept", koneksi);
            OdbcDataAdapter dadap = new OdbcDataAdapter(cmd);
            dadap.SelectCommand = cmd;
            dadap.Fill(dta);
            comboBox1.DataSource = dta;
            comboBox1.ValueMember = "dept_id";
            comboBox1.DisplayMember = "dept_nama";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("NIPP Tidak Boleh Kosong");
            }
            else if (String.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Nama Tidak Boleh Kosong");
            }
            else if (String.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Jabatan Tidak Boleh Kosong");
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
                            "'" + this.textBox1.Text + "'," +
                            "'" + this.textBox2.Text + "'," +
                            "'" + this.textBox3.Text + "'," +
                            "'" + this.comboBox1.SelectedValue + "'," +
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
                textBox2.Text = "";
                textBox3.Text = "";
                comboBox1.SelectedIndex = -1;
            }
        }
    }
}
