using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.OleDb;
using System.Data;
using System.Web.Configuration;

namespace 허혜민_인사관리
{
    public class DBConn
    {
        //string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=c:\temp\학사2019.accdb";
        // string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=데이터.mdb";

        // for ASP.NET
        string connectionString = WebConfigurationManager.ConnectionStrings["webdb"].ConnectionString; 

        public OleDbConnection conn;

        public DBConn()
        {
            conn = new OleDbConnection(connectionString);
            conn.Open();
        }

        public void Close()
        {
            conn.Close();
        }

        public OleDbConnection GetConn()
        {
            return conn;
        }

        public void ExecuteNonQuery(string sql)
        {
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            cmd.ExecuteNonQuery();
        }

        public OleDbDataReader ExecuteReader(string sql)
        {
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            return cmd.ExecuteReader();
        }

        public object ExecuteScalar(string sql)
        {
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            return cmd.ExecuteScalar();
        }

        public DataSet GetDataSet(string sql)
        {
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            adapter.SelectCommand = new OleDbCommand(sql, conn);

            DataSet ds = new DataSet();
            adapter.Fill(ds);
            return ds;
        }
    }
}