using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace simpanpinjam
{
    public partial class dashboard : Form
    {
        public dashboard()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pinjaman.Text = textBox1.Text;
            tenor.Text = comboBox1.SelectedItem.ToString()+" bulan";
            bunga.Text = "1%";

            double P, T, Apokok, A, TK;
            P = double.Parse(textBox1.Text, System.Globalization.CultureInfo.InvariantCulture);
            T = Int32.Parse(comboBox1.SelectedItem.ToString());
            Apokok = P / T;
            A = Apokok + (Apokok * 1 / 100);
            TK = A * T;

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
