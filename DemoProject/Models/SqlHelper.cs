using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Net.Http;
using System.Configuration;

namespace DemoProject.Models
{
    public static class SqlHelper
    {
        public static string Strcon = ConfigurationManager.ConnectionStrings["con"].ToString();
        public static int ExecuteNonQuery(string Query)
        {
            int Result = 0;
            try
            {
                SqlConnection con = new SqlConnection(Strcon);
                SqlCommand cmd = new SqlCommand(Query, con);
                if (con.State == ConnectionState.Closed)
                    con.Open();
                Result = cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return Result;
        }

        public static DataTable ExecuteDataTable(string Query)
        {
            DataTable dtdata = new DataTable();
            try
            {
                SqlConnection con = new SqlConnection(Strcon);
                SqlCommand cmd = new SqlCommand(Query, con);
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dtdata);
                con.Close();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return dtdata;
        }
    }
}