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
    public partial class pinjaman : Form
    {
        CRUD crud = new CRUD();

        public pinjaman()
        {
            InitializeComponent();
            cbanggota();
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

        private void tb_pinjam_Leave(object sender, EventArgs e)
        {
            Double value;
            if (Double.TryParse(tb_pinjam.Text, out value))
                tb_pinjam.Text = String.Format("{0:#,#}", value);
            else
                tb_pinjam.Text = String.Empty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cbAnggota.SelectedIndex == -1)
            {
                MessageBox.Show("Anggota Tidak Boleh Kosong");
            }
            else if (cbt1.SelectedIndex == -1)
            {
                MessageBox.Show("Tenor Tidak Boleh Kosong");
            }
            else if (String.IsNullOrEmpty(tb_pinjam.Text))
            {
                MessageBox.Show("Jumlah Tidak Boleh Kosong");
            }
            else if (String.IsNullOrEmpty(tb_keperluan.Text))
            {
                MessageBox.Show("Keperluan Tidak Boleh Kosong");
            }
            else
            {
                //labelJumlahSimpan.Text = double.Parse(textBox1.Text).ToString("F2");
                string pTggl = dtpt1.Value.ToString("yyyy-MM-dd");
                var dat = dtpt1.Value;
                string pTgglend = dat.AddMonths(Convert.ToInt32(cbt1.SelectedItem)).ToString("yyyy-MM-15");

                double P, T, Apokok, A, B, TK;
                P = double.Parse(tb_pinjam.Text, System.Globalization.CultureInfo.InvariantCulture);
                T = Int32.Parse(cbt1.SelectedItem.ToString());
                Apokok = P / T;
                B = Apokok * 1 / 100;
                A = Apokok + B;
                TK = A * T;

                string pTenor = T.ToString();
                string pPokok = P.ToString("F2");
                string pCicilanPokok = Math.Round(Apokok).ToString("F2");
                string pCicilanBunga = Math.Round(B).ToString("F2");
                string pCicilanTotal = Math.Round(A).ToString("F2");
                string pTotalAngsuran = TK.ToString();

                using (OdbcConnection con = new OdbcConnection(@"Dsn=sisi;uid=root"))
                {
                    try
                    {

                        using (var cmd2 = new OdbcCommand("INSERT INTO tm_pinjaman (pjm_no, pjm_id, pjm_tggl, pjm_tenor, pjm_tgglend, pjm_pokok, pjm_keperluan, cicilan_pokok, cicilan_bunga, cicilan_total, pjm_total, pjm_stat, userid)" +
                            " VALUES (" +
                            "getpinjamanno()," +
                            "'" + cbAnggota.SelectedValue + "'," +
                            "'" + pTggl + "'," +
                            "'" + pTenor + "'," +
                            "'" + pTgglend + "'," +
                            "'" + pPokok + "'," +
                            "'" + tb_keperluan.Text + "'," +
                            "'" + pCicilanPokok + "'," +
                            "'" + pCicilanBunga + "'," +
                            "'" + pCicilanTotal + "'," +
                            "'" + pTotalAngsuran + "'," +
                            "1," +
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
                tb_pinjam.Text = "";
                tb_keperluan.Text = "";
                cbt1.SelectedIndex = -1;
                cbAnggota.SelectedIndex = -1;
                //dd();
            }
        }
    }
}
