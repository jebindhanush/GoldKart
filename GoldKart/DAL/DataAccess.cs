using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Configuration;
using BMSAddressChange.BLL;

namespace BMSAddressChange.DAL
{
    public class DataAccess : IDataAccess
    {
        public SqlConnection SqlCon; //For FI_Finance Connection
        public SqlConnection SqlConF; //For RDS_FINAL Connection
        public SqlConnection SqlConR; //For FI_MIS Connection
        OleDbConnection OledbCon;
        //Connection to a regular database working
        #region SqlConnection to RDS_Final_Finance Database
        public SqlConnection OpenSqlConnectionRDS_Finance_Final()
        {
            try
            {
                String StrCon = ConfigurationManager.ConnectionStrings["GoldKart_Connection"].ToString();
                SqlCon = new SqlConnection(StrCon);
                SqlCon.Open();
                return SqlCon;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public SqlConnection OpenSqlConnectionRDS_Finance_Final1()
        {
            try
            {
                String StrCon = ConfigurationManager.ConnectionStrings["ReportConnectionString"].ToString();
                SqlCon = new SqlConnection(StrCon);
                SqlCon.Open();
                return SqlCon;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public SqlConnection CloseSqlConnection()
        {
            //if (SqlCon.State == System.Data.ConnectionState.Open)
            //{
            SqlCon.Close();
            SqlCon.Dispose();
            // }
            return SqlCon;
        }
        #endregion
        //Connection for geting RDS data to the current database
        #region SqlConnection to RDS_Final Database
        public SqlConnection OpenSqlConnectionRDSFinal()
        {
            try
            {
                String StrCon = ConfigurationManager.ConnectionStrings["SqlConStrRDS"].ToString();
                SqlConF = new SqlConnection(StrCon);
                SqlConF.Open();
                return SqlConF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public SqlConnection CloseSqlConnection2()
        {
            SqlConF.Close();
            SqlConF.Dispose();
            return SqlConF;
        }

        #endregion

        //Connection to connect to the remote server
        #region SqlConnection to Remote server
        public SqlConnection OpenSqlConnectionRemote()
        {
            try
            {
                String StrCon = ConfigurationManager.ConnectionStrings["SqlConStrRemote"].ToString();
                SqlConR = new SqlConnection(StrCon);
                SqlConR.Open();
                return SqlConR;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public SqlConnection CloseSqlConnection3()
        {
            SqlConR.Close();
            SqlConR.Dispose();
            return SqlConR;
        }
        #endregion

        #region Access Connection
        public OleDbConnection OpenCon()
        {

            try
            {
                String StrCon = ConfigurationManager.ConnectionStrings["AccessConStr"].ToString();
                OledbCon = new OleDbConnection(StrCon);
                OledbCon.Open();
                return OledbCon;
            }
            catch (Exception ex)
            {
                //throw new Exception("Error while connecting database.");
                throw ex;
            }

        }
        public OleDbConnection CloseCon()
        {
            OledbCon.Close();
            OledbCon.Dispose();
            return OledbCon;
        }
        #endregion
    }
}