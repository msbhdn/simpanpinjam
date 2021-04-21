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
    public partial class RefDepAdd : Form
    {
        CRUD crud = new CRUD();

        public RefDepAdd()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OdbcConnection con = new OdbcConnection(@"Dsn=sisi;uid=root"))
            {
                try
                {

                    using (var cmd = new OdbcCommand("INSERT INTO tr_dept (dept_id, dept_nama) VALUES ('" + this.textBox1.Text + "','" + this.textBox2.Text + "')"))
                    {

                        cmd.Connection = con;

                        con.Open();
                        if (cmd.ExecuteNonQuery() > 0)
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
        }
    }
}
