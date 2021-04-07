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

        //READ PROPERTIES
        public DataTable bankcbDept = new DataTable();

        public DataTable dtAnggota = new DataTable();
        public DataSet dsAnggota = new DataSet();

        public DataTable dtSanggota = new DataTable();

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
            OdbcDataAdapter da = new OdbcDataAdapter("select * from v_anggota where anggota_nama like '" + name + "%'", con);
            da.Fill(dtSanggota);
        }

        //REFERENSI DEPARTEMENT
        public DataTable dtRefDep = new DataTable();
        public DataSet dsRefDep = new DataSet();

        public void read_RefDep()
        {
            dtRefDep.Clear();
            string q = "select dept_id, dept_nama from tr_dept";
            OdbcDataAdapter oda = new OdbcDataAdapter(q, con);
            oda.Fill(dsRefDep);
            dtRefDep = dsRefDep.Tables[0];
        }
    }
}
