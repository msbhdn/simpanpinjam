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
    public partial class dashboard : Form
    {
        CRUD crud = new CRUD();
        public dashboard()
        {
            InitializeComponent();
            dd();
        }

        private void dd()
        {
            crud.read_dashboard();
            //DATASET
            org.Text = crud.dtDash.Rows[0].Field<string>("jmlh_anggota");
            spn.Text = crud.dtDash.Rows[0].Field<double>("jmlh_simpanan").ToString("N2");
            pjm.Text = crud.dtDash.Rows[0].Field<double>("jmlh_pinjaman").ToString("N2");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            pinjaman.Text = textBox1.Text;
            tenor.Text = comboBox1.SelectedItem.ToString()+" bulan";
            bunga.Text = "1%";

            double P, T, B, A, TK;
            P = double.Parse(textBox1.Text, System.Globalization.CultureInfo.InvariantCulture);
            T = Int32.Parse(comboBox1.SelectedItem.ToString());
            B = (P * T) / 100;
            A = (P + B) / T;
            TK = P + B;

            angsuran.Text = Math.Round(A).ToString("0,0")+" per Bulan";
            total.Text = TK.ToString("0,0");
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            Double value;
            if (Double.TryParse(textBox1.Text, out value))
                textBox1.Text = String.Format("{0:#,#}", value);
            else
                textBox1.Text = String.Empty;
        }
    }
}
