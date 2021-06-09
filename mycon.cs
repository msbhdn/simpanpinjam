using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Odbc;
using System.Windows.Forms;

namespace simpanpinjam.myclass
{
    class mycon
    {
        public OdbcConnection con = new OdbcConnection(@"Dsn=sisi;uid=root");
    }

    class CRUD:mycon
    {
        //TOOLS
        public void conOpen()
        {
            con.Open();
        }
        public void conClose()
        {
            con.Close();
        }

        //REFERENSI ANGGOTA ===============================================================================================================================

        //PROPERTIES
        public DataTable bankcbDept = new DataTable();

        public DataTable dtAnggota = new DataTable();
        public DataSet dsAnggota = new DataSet();

        public DataTable dtSanggota = new DataTable();

        public string Anipp { set; get; }
        public string Anama { set; get; }
        public string Ajab { set; get; }
        public object Adept { set; get; }

        public string AID { set; get; }

        //READ FUNCTION
        public void read_cbDept()
        {
            DataTable temp = new DataTable();
            OdbcCommand cmd = new OdbcCommand("select * from tr_dept", con);
            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
            da.SelectCommand = cmd;
            da.Fill(temp);
            DataView dtvw = new DataView(temp);
            bankcbDept = dtvw.ToTable();
        }
        public void read_dataAnggota()
        {
            dtAnggota.Clear();
            string q = "select * from v_anggota";
            OdbcDataAdapter oda = new OdbcDataAdapter(q, con);
            oda.Fill(dsAnggota);
            dtAnggota = dsAnggota.Tables[0];
        }
        public void read_SdataAnggota(string name)
        {
            dtSanggota.Clear();
            con.Open();
            OdbcDataAdapter da = new OdbcDataAdapter("select * from v_anggota where anggota_nama like '%" + name + "%'", con);
            da.Fill(dtSanggota);
        }

        //CREATE
        public void create_dataAnggota()
        {
            using (var cmd = new OdbcCommand("INSERT INTO tm_anggota (anggota_no, anggota_nipp, anggota_nama, anggota_jab, anggota_dept, userid)" +
                " VALUES (" +
                "getanggotano()," +
                "'" + Anipp + "'," +
                "'" + Anama + "'," +
                "'" + Ajab + "'," +
                "'" + Adept + "'," +
                "'" + global.userid + "'" +
                ")"))
            {
                cmd.Connection = con;
                con.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Record Inserted");
                    con.Close();
                }
                else
                {
                    MessageBox.Show("Record Failed");
                    con.Close();
                }
            }
        }

        //UPDATE
        public void update_dataAnggota()
        {
            using (var cmd = new OdbcCommand("UPDATE tm_anggota SET " +
                "anggota_nipp='" + Anipp + "'," +
                "anggota_nama='" + Anama + "'," +
                "anggota_jab='" + Ajab + "'," +
                "anggota_dept='" + Adept + "'," +
                "userid='" + global.userid + "'" +
                "WHERE anggota_no='" + AID + "'" ))
            {
                cmd.Connection = con;
                con.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Record Inserted");
                    con.Close();
                }
                else
                {
                    MessageBox.Show("Record Failed");
                    con.Close();
                }
            }
        }

        //REFERENSI SIMPANAN ==========================================================================================================================

        //PROPERTIES
        public DataTable dtSimpanan = new DataTable();
        public DataSet dsSimpanan = new DataSet();

        public DataTable bankcbAnggota = new DataTable();
        public DataTable bankcbJsimpanan = new DataTable();

        //READ FUNCTION
        public void read_dataSimpanan()
        {
            dtSimpanan.Clear();
            string q = "select * from v_simpanan";
            OdbcDataAdapter oda = new OdbcDataAdapter(q, con);
            oda.Fill(dsSimpanan);
            dtSimpanan = dsSimpanan.Tables[0];
        }
        public void read_cbAnggota()
        {
            DataTable temp = new DataTable();
            OdbcCommand cmd = new OdbcCommand("select anggota_no, anggota_nama from tm_anggota", con);
            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
            da.SelectCommand = cmd;
            da.Fill(temp);
            DataView dtvw = new DataView(temp);
            bankcbAnggota = dtvw.ToTable();
        }
        public void read_cbJsimpanan()
        {
            DataTable temp = new DataTable();
            OdbcCommand cmd = new OdbcCommand("select js_id, js_nama from tr_simpanan", con);
            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
            da.SelectCommand = cmd;
            da.Fill(temp);
            DataView dtvw = new DataView(temp);
            bankcbJsimpanan = dtvw.ToTable();
        }

        //CREATE
        /*public void create_dataSimpanan()
        {
            using (var cmd = new OdbcCommand("INSERT INTO tm_simpanan (simpanan_id, simpanan_tipe, simpanan_jumlah, simpanan_tggl, uuid, userid)"+
                "VALUES ('" + depID + "','" + depNAME + "')"))
            {
                cmd.Connection = con;
                con.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Record Inserted");
                    con.Close();
                }
                else
                {
                    MessageBox.Show("Record Failed");
                    con.Close();
                }
            }
        }*/


        //REFERENSI PINJAMAN ==========================================================================================================================




        //REFERENSI DEPARTEMENT ==========================================================================================================================

        //PROPERTIES
        public DataTable dtRefDep = new DataTable();

        public string depID { set; get; }
        public string depNAME { set; get; }

        //READ
        public void read_RefDep()
        {
            DataSet dsRefDep = new DataSet();

            dtRefDep.Clear();
            string q = "select dept_id, dept_nama from tr_dept";
            OdbcDataAdapter odaDEP = new OdbcDataAdapter(q, con);
            odaDEP.Fill(dsRefDep);
            dtRefDep = dsRefDep.Tables[0];
        }

        //CREATE
        public void create_RefDep()
        {
            using (var cmd = new OdbcCommand("INSERT INTO tr_dept (dept_id, dept_nama) VALUES ('" + depID + "','" + depNAME + "')"))
            {
                cmd.Connection = con;
                con.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Record Inserted");
                    con.Close();
                }
                else
                {
                    MessageBox.Show("Record Failed");
                    con.Close();
                }
            }
                
        }

        //UPDATE
        public void update_RefDep()
        {
            using (var cmd = new OdbcCommand("UPDATE tr_dept SET dept_nama='" + depNAME + "' WHERE dept_id='" + depID + "'"))
            {
                cmd.Connection = con;
                con.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Record Update");
                    con.Close();
                }
                else
                {
                    MessageBox.Show("Record Failed");
                    con.Close();
                }
            }

        }

        //DELETE
        public void delete_RefDep()
        {
            using (var cmd = new OdbcCommand("DELETE FROM tr_dept WHERE dept_id='" + depID + "'"))
            {
                cmd.Connection = con;
                con.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Record Delete");
                    con.Close();
                }
                else
                {
                    MessageBox.Show("Record Failed");
                    con.Close();
                }
            }

        }
    }
}
