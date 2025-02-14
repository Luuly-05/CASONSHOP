using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace DoAn3
{
    public class ConnectDatabase: System.Web.UI.Page
    {
        SqlConnection cn;
        public void layKetNoi()
        {
            cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Admin\source\repos\DoAn3\DoAn3\App_Data\BANHANG1.mdf;Integrated Security=True";
            cn.Open();
        }

        public void dongKetNoi()
        {
            if (cn.State == ConnectionState.Open)
            {
                cn.Close();
            }
        }

        public DataTable docDuLieu(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                layKetNoi();
                SqlDataAdapter da = new SqlDataAdapter(sql, cn);
                da.Fill(dt);
            }
            catch (Exception err)
            {
                Console.Write("err: " + err);
            }
            finally
            {
                dongKetNoi();
            }
            return dt;
        }

        public int capNhat(string sql)
        {
            int ketqua = 0;
            try
            {
                layKetNoi();
                SqlCommand cmd = new SqlCommand(sql, cn);
                ketqua = cmd.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                Console.Write("err: " + err);
            }
            finally
            {
                dongKetNoi();
            }
            return ketqua;
        }

        public double demDuLieu(string sql)
        {
            double ketqua = 0;
            try
            {
                layKetNoi();
                SqlCommand cmd = new SqlCommand(sql, cn);
                ketqua = (double)cmd.ExecuteScalar();
            }
            catch (Exception err)
            {
                Console.Write("err: " + err);
            }
            finally
            {
                dongKetNoi();
            }
            return ketqua;
        }

        public int count(string sql)
        {
            int ketqua = 0;
            try
            {
                layKetNoi();
                SqlCommand cmd = new SqlCommand(sql, cn);
                ketqua = (int)cmd.ExecuteScalar();
            }
            catch (Exception err)
            {
                Console.Write("err: " + err);
            }
            finally
            {
                dongKetNoi();
            }
            return ketqua;
        }

    }
}