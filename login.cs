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
using System.Security.Cryptography;

namespace simpanpinjam
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
            textBox2.PasswordChar = '*';
            this.AcceptButton = button1;
        }


        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null) activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel2.Controls.Add(childForm);
            panel2.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        private void label3_Click(object sender, EventArgs e)
        {
            openChildForm(new ForgotPassword());
        }

        public string encryption(String password)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] encrypt;
            UTF8Encoding encode = new UTF8Encoding();
            //encrypt the given password string into Encrypted data  
            encrypt = md5.ComputeHash(encode.GetBytes(password));
            StringBuilder encryptdata = new StringBuilder();
            //Create a new string by using the encrypted data  
            for (int i = 0; i < encrypt.Length; i++)
            {
                encryptdata.Append(encrypt[i].ToString());
            }
            return encryptdata.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string pass = encryption(textBox2.Text);
            OdbcConnection con = new OdbcConnection(@"Dsn=sisi;uid=root");
            OdbcDataAdapter sda = new OdbcDataAdapter("select * from user where userid='" + textBox1.Text + "' and pwd='" + pass + "'", con);

            con.Open();
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                global.username = dt.Rows[0]["name"].ToString();
                global.userid = dt.Rows[0]["userid"].ToString();

                this.Hide();
                new sisi().Show();
            }
            else
            {
                MessageBox.Show("Invalid userid and password");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
