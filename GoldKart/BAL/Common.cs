using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BMSAddressChange.DAL;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.Web.Security;
using System.Text;
using System.Text.RegularExpressions;

namespace GoldKart.BLL
{
    public abstract class Common : DataAccess
    {
        DataAccess DA = new DataAccess();
        //Method to populate the District's
        public void GetDistrict_List(int iDistrictCode, ref DropDownList ddlName)
        {

            DataSet SqlDS = new DataSet();
            try
            {
                SqlDS = SqlHelper.ExecuteDataset(DA.OpenSqlConnectionRDS_Finance_Final(), "USP_COMMON_GetDistricts", new object[] { iDistrictCode });
                FillDropDownList(ref SqlDS, ref ddlName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                SqlDS.Dispose();
                DA.CloseSqlConnection();
            }
            //return SqlDS;
        }

        public void GetDistrict_List1(int iDistrictCode, ref DropDownList ddlName)
        {

            DataSet SqlDS = new DataSet();
            try
            {
                SqlDS = SqlHelper.ExecuteDataset(DA.OpenSqlConnectionRDS_Finance_Final(), "USP_COMMON_GetDistricts", new object[] { iDistrictCode });
                FillDropDownList1(ref SqlDS, ref ddlName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                SqlDS.Dispose();
                DA.CloseSqlConnection();
            }
            //return SqlDS;
        }

        //Method to populate the Taluk's
        public void GetTalukList(int iTalukCode, int iDistrictCode, ref DropDownList ddlName)
        {
            DataSet SqlDS = new DataSet();

            try
            {
                SqlDS = SqlHelper.ExecuteDataset(DA.OpenSqlConnectionRDS_Finance_Final(), "USP_COMMON_GetTaluk", new object[] { iDistrictCode, iTalukCode });
                FillDropDownList(ref SqlDS, ref ddlName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                SqlDS.Dispose();
                DA.CloseSqlConnection();
            }
            //return SqlDS;
        }

        public void GetHobliList1(char RU, int iTalukCode, int iDistrictCode, ref DropDownList ddlName)
        {
            DataSet SqlDS = new DataSet();

            try
            {
                SqlDS = SqlHelper.ExecuteDataset(DA.OpenSqlConnectionRDS_Finance_Final(), "USP_COMMON_GetHoblis_For_Address", new object[] {RU, iDistrictCode, iTalukCode });
                //Commneted following 1 line by PGG on 26/4/2014
                //FillDropDownList(SqlDS, ddlName);
                FillDropDownList1(ref SqlDS, ref ddlName);
                ListItem li = new ListItem();
                li.Value = "255";

                if (ddlName.Items.Contains(li))
                {
                    ddlName.Items.RemoveAt(ddlName.Items.IndexOf(ddlName.Items.FindByValue("255")));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                SqlDS.Dispose();
                DA.CloseSqlConnection();

            }
            //return SqlDS;
        }

        public string VerifyFingerPrint(string EnroledFingerPrint, string UserFingerPrint, string LoginId)
        {
            return "Success";
        }

        //Mehod to populate Scheme //24042019 //jebin
        public void GetSchemList(ref DropDownList ddlScheme)
        {
            DataSet SqlDS = new DataSet();

            try
            {
                SqlDS = SqlHelper.ExecuteDataset(DA.OpenSqlConnectionRDS_Finance_Final(), "USP_COMMON_GetAllScheme");
                //Commneted following 1 line by PGG on 26/4/2014, commented by winston on 8/10/2015
                FillDropDownListScheme(ref SqlDS, ref ddlScheme);
                //FillDropDownList1(SqlDS, ddlName);
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                SqlDS.Dispose();
                DA.CloseSqlConnection();

            }
            //return SqlDS;
        }

        //Method to populate the Hobli's
        public void GetHobliList(int iTalukCode, int iDistrictCode, ref DropDownList ddlName)
        {
            DataSet SqlDS = new DataSet();

            try
            {
                SqlDS = SqlHelper.ExecuteDataset(DA.OpenSqlConnectionRDS_Finance_Final(), "USP_COMMON_GetRDSHoblis", new object[] { iDistrictCode, iTalukCode });
                //Commneted following 1 line by PGG on 26/4/2014, commented by winston on 8/10/2015
                FillDropDownList1(ref SqlDS, ref ddlName);
                //FillDropDownList1(SqlDS, ddlName);
                ListItem li = new ListItem();
                li.Value = "Sel";

                if (ddlName.Items.Contains(li))
                {
                    ddlName.Items.RemoveAt(ddlName.Items.IndexOf(ddlName.Items.FindByValue("Sel")));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                SqlDS.Dispose();
                DA.CloseSqlConnection();

            }
            //return SqlDS;
        }

        public void GetVillageList(int iTalukCode, int iDistrictCode, string iHoblicode, ref DropDownList ddlName)
        {
            DataSet SqlDS = new DataSet();

            try
            {
                SqlDS = SqlHelper.ExecuteDataset(DA.OpenSqlConnectionRDS_Finance_Final(), "USP_GET_VILLAGE_SELECT", new object[] { iDistrictCode, iTalukCode, iHoblicode });
                FillDropDownList1(ref SqlDS, ref ddlName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                SqlDS.Dispose();
                DA.CloseSqlConnection();
            }
            //return SqlDS;
        }
        
        //Method to populate the Village's
        public void GetVillageListSelect(int iDistrictCode, int iTalukCode, int iHoblicode, ref DropDownList ddlName)
        {
            DataSet SqlDS = new DataSet();

            try
            {
                SqlDS = SqlHelper.ExecuteDataset(DA.OpenSqlConnectionRDS_Finance_Final(), "USP_GET_VILLAGE_SELECT", new object[] { iDistrictCode, iTalukCode, iHoblicode });
                FillDropDownListNew(ref SqlDS, ref ddlName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                SqlDS.Dispose();
                DA.CloseSqlConnection();
            }
            //return SqlDS;
        }

        //21 Sept 2015 - Winston Added
        public void GetVAcircle(int Dist, int Taluk, String Hobli, ref DropDownList ddlName, char rural_urban_flag)
        {
            try
            {
                ddlName.Items.Clear();
                DataSet SqlDS = new DataSet();
                SqlDS = SqlHelper.ExecuteDataset(DA.OpenSqlConnectionRDS_Finance_Final(), "USP_COMMON_GetVAcircle", new object[] { Dist, Taluk, Hobli, rural_urban_flag });
                FillDropDownList1(ref SqlDS, ref ddlName);

            }
            catch (SqlException ex)
            {

                throw ex;
            }
            finally
            {
                DA.CloseSqlConnection();
            }
        }

        //Method to populate the Town's.
        public void GetTownList(int iTalukCode, int iDistrictCode, ref DropDownList ddlName)
        {
            DataSet SqlDS = new DataSet();

            try
            {
                SqlDS = SqlHelper.ExecuteDataset(DA.OpenSqlConnectionRDS_Finance_Final(), "USP_COMMON_GetTown", new object[] { iDistrictCode, iTalukCode });               
                FillDropDownList1(ref SqlDS, ref ddlName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                SqlDS.Dispose();
                DA.CloseSqlConnection();
            }
            //return SqlDS;
        }



        //Method to populate the Hobli's.
        public void GetHobli(int iTalukCode, int iDistrictCode, ref DropDownList ddlName)
        {
            DataSet SqlDS = new DataSet();

            try
            {
                SqlDS = SqlHelper.ExecuteDataset(DA.OpenSqlConnectionRDS_Finance_Final(), "USP_COMMON_GetHobli", new object[] { iDistrictCode, iTalukCode });
                FillDropDownList1(ref SqlDS, ref ddlName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                SqlDS.Dispose();
                DA.CloseSqlConnection();
            }
            //return SqlDS;
        }

        public void GetHobliSelect(int iDistrictCode, int iTalukCode, ref DropDownList ddlName)
        {
            DataSet SqlDS = new DataSet();

            try
            {
                SqlDS = SqlHelper.ExecuteDataset(DA.OpenSqlConnectionRDS_Finance_Final(), "USP_GET_HOBLI_SELECT", new object[] { iDistrictCode, iTalukCode });
                FillDropDownListNew(ref SqlDS, ref ddlName);
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                SqlDS.Dispose();
                DA.CloseSqlConnection();
            }
            //return SqlDS;
        }
        public void GetHobliSelect1(int iDistrictCode, int iTalukCode, ref DropDownList ddlName)
        {
            DataSet SqlDS = new DataSet();

            try
            {
                SqlDS = SqlHelper.ExecuteDataset(DA.OpenSqlConnectionRDS_Finance_Final(), "USP_GET_HOBLI_SELECT_SOECIAL_TALUK", new object[] { iDistrictCode, iTalukCode, });
                FillDropDownListNew(ref SqlDS, ref ddlName);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                SqlDS.Dispose();
                DA.CloseSqlConnection();
            }
            //return SqlDS;
        }

        //Method to populate the Cast's
        public void GetCastList(ref DropDownList ddlName)
        {
            DataSet SqlDS = new DataSet();

            try
            {
                SqlDS = SqlHelper.ExecuteDataset(DA.OpenSqlConnectionRDS_Finance_Final(), "USP_COMMON_GetCastes", new object[] { });
                FillDropDownList(ref SqlDS, ref ddlName);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                SqlDS.Dispose();
                DA.CloseSqlConnection();
            }
            //return SqlDS;
        }

        //Method to populate the Cast's. For Age DOB Edit
        public DataSet GetCastList1()
        {
            DataSet SqlDS = new DataSet();

            try
            {
                SqlDS = SqlHelper.ExecuteDataset(DA.OpenSqlConnectionRDS_Finance_Final(), "USP_COMMON_GetCastes", new object[] { });
                //FillDropDownList(SqlDS, ddlName);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                SqlDS.Dispose();
                DA.CloseSqlConnection();
            }
            return SqlDS;
        }

        public void GetCastList(byte castcode, byte? catcode, ref DropDownList ddlName)
        {
            DataSet SqlDS = new DataSet();

            try
            {
                SqlDS = SqlHelper.ExecuteDataset(DA.OpenSqlConnectionRDS_Finance_Final(), "USP_COMMON_GetCastsByCategory", new object[] { castcode, catcode });
                FillDropDownList(ref SqlDS, ref ddlName);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                SqlDS.Dispose();
                DA.CloseSqlConnection();
            }
            //return SqlDS;
        }

        //Method to populate the Religion
        public void GetReligionList(ref DropDownList ddlName)
        {
            DataSet SqlDS = new DataSet();

            try
            {
                SqlDS = SqlHelper.ExecuteDataset(DA.OpenSqlConnectionRDS_Finance_Final(), "USP_COMMON_GetReligion", new object[] { });
                FillDropDownList(ref SqlDS, ref ddlName);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                SqlDS.Dispose();
                DA.CloseSqlConnection();
            }
            // return SqlDS;
        }

        public void GetSalutationList(ref DropDownList ddlName)
        {
            DataSet SqlDS = new DataSet();

            try
            {
                SqlDS = SqlHelper.ExecuteDataset(DA.OpenSqlConnectionRDS_Finance_Final(), "USP_COMMON_GetSalutation", new object[] { });
                FillDropDownList(ref SqlDS, ref ddlName);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                SqlDS.Dispose();
                DA.CloseSqlConnection();
            }
            // return SqlDS;
        }

        //Method to populate Bincom
        public void GetBinComList(ref DropDownList ddlName)
        {
            DataSet SqlDS = new DataSet();

            try
            {
                SqlDS = SqlHelper.ExecuteDataset(DA.OpenSqlConnectionRDS_Finance_Final(), "USP_GetBinCom", new object[] { });
                FillDropDownList(ref SqlDS, ref ddlName);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                SqlDS.Dispose();
                DA.CloseSqlConnection();
            }
            //return SqlDS;
        }

        //Method to populate the Reserve category list.
        public void GetReserveCatList(int icatcode, ref DropDownList ddlName)
        {
            DataSet SqlDS = new DataSet();

            try
            {
                SqlDS = SqlHelper.ExecuteDataset(DA.OpenSqlConnectionRDS_Finance_Final(), "USP_COMMON_GetReservationCategoryMaster", new object[] { icatcode });
                FillDropDownList(ref SqlDS, ref ddlName);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                SqlDS.Dispose();
                DA.CloseSqlConnection();
            }
            //return SqlDS;
        }

        //Method to populate the Reserve category list.For Age DOB Edit
        public DataSet GetReserveCatList1(int icatcode)
        {
            DataSet SqlDS = new DataSet();

            try
            {
                SqlDS = SqlHelper.ExecuteDataset(DA.OpenSqlConnectionRDS_Finance_Final(), "USP_COMMON_GetReservationCategoryMaster", new object[] { icatcode });
                //FillDropDownList(SqlDS, ddlName);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                SqlDS.Dispose();
                DA.CloseSqlConnection();
            }
            return SqlDS;
        }

        //Method to populate the Death reason  list
        public void GetDeathReason(ref DropDownList ddlName)
        {
            DataSet SqlDS = new DataSet();

            try
            {
                SqlDS = SqlHelper.ExecuteDataset(DA.OpenSqlConnectionRDS_Finance_Final(), "USP_COMMON_GetDeathReason", new object[] { });
                FillDropDownList(ref SqlDS, ref ddlName);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                SqlDS.Dispose();
                DA.CloseSqlConnection();
            }
            //return SqlDS;
        }

        public DataSet gfPopulateDataSetNoEncrypt(SqlDataReader oReader)
        {
            DataSet newDataset = new DataSet();
        lblNextResult:
            DataTable newTable = new DataTable();
            //DataRow newRow = default(DataRow);
            int iColumnCount = 0;
            for (iColumnCount = 0; iColumnCount <= oReader.FieldCount - 1; iColumnCount++)
            {
                newTable.Columns.Add(new DataColumn(oReader.GetName(iColumnCount)));
            }
            while (oReader.Read())
            {
                DataRow newRow;
                newRow = newTable.NewRow();
                //newRow = newTable.Rows.Add();
                for (iColumnCount = 0; iColumnCount <= oReader.FieldCount - 1; iColumnCount++)
                {
                    if (object.ReferenceEquals(oReader.GetDataTypeName(iColumnCount), "varchar"))
                    {
                        if (oReader[iColumnCount] == System.DBNull.Value)
                        {
                            newRow[iColumnCount] = "";
                        }
                        else
                        {
                            newRow[iColumnCount] = oReader[iColumnCount];
                        }
                    }
                    else if (object.ReferenceEquals(oReader.GetDataTypeName(iColumnCount), "nvarchar"))
                    {
                        if (oReader[iColumnCount] == System.DBNull.Value)
                        {
                            newRow[iColumnCount] = "";
                        }
                        else
                        {
                            newRow[iColumnCount] = oReader[iColumnCount];
                        }
                    }
                    else
                    {
                        if (oReader[iColumnCount] == System.DBNull.Value)
                        {
                            newRow[iColumnCount] = "";
                        }
                        else
                        {
                            newRow[iColumnCount] = oReader[iColumnCount];
                        }
                    }
                }
                newTable.Rows.Add(newRow);
            }
            newDataset.Tables.Add(newTable);
            try
            {
                if (oReader.NextResult())
                {
                    goto lblNextResult;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return newDataset;
        }

        //Method to Populate Shcemes list
        public void GetSchemeList(ref DropDownList ddlName)
        {
            DataSet SqlDS = new DataSet();

            try
            {
                SqlDS = SqlHelper.ExecuteDataset(DA.OpenSqlConnectionRDS_Finance_Final(), "USP_COMMON_GetScheme", new object[] { });
                FillDropDownList(ref SqlDS, ref ddlName);
                //ddlName.Items.RemoveAt(ddlName.Items.IndexOf(ddlName.Items.FindByValue("05")));

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                SqlDS.Dispose();
                DA.CloseSqlConnection();
            }
            //return SqlDS;
        }

        public void GetSpecialTalukSelect(int DistrictCode, int TalukCode, ref DropDownList ddlName)
        {
            DataSet SqlDS = new DataSet();

            try
            {
                SqlDS = SqlHelper.ExecuteDataset(DA.OpenSqlConnectionRDS_Finance_Final(), "USP_GET_SPECIAL_TALUK", new object[] { DistrictCode, TalukCode,});
                FillDropDownList(ref SqlDS, ref ddlName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                SqlDS.Dispose();
                DA.CloseSqlConnection();
            }
           // return SqlDS;
        }

        public void GetSpecialHobli(int DistrictCode, int TalukCode, int TalukCode1, ref DropDownList ddlName)
        {
            DataSet SqlDS = new DataSet();

            try
            {
                SqlDS = SqlHelper.ExecuteDataset(DA.OpenSqlConnectionRDS_Finance_Final(), "USP_GET_SPECIAL_HOBLI", new object[] { DistrictCode, TalukCode, TalukCode1 });
                FillDropDownListNew(ref SqlDS, ref ddlName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                SqlDS.Dispose();
                DA.CloseSqlConnection();
            }
            // return SqlDS;
        }

        public void GetHabitationSelect(int VillageCode, ref DropDownList ddlName)
        {
            DataSet SqlDS = new DataSet();

            try
            {
                SqlDS = SqlHelper.ExecuteDataset(DA.OpenSqlConnectionRDS_Finance_Final(), "USP_GET_HABITATION", new object[] { VillageCode });
                FillDropDownListNew(ref SqlDS, ref ddlName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                SqlDS.Dispose();
                DA.CloseSqlConnection();
            }
            // return SqlDS;
        }

        



        public void GetTalukSelect(int distcode, ref DropDownList ddlName)
        {
            DataSet SqlDS = new DataSet();

            try
            {
                SqlDS = SqlHelper.ExecuteDataset(DA.OpenSqlConnectionRDS_Finance_Final(), "USP_GET_TALUK_SELECT", new object[] { });
                FillDropDownList(ref SqlDS, ref ddlName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                SqlDS.Dispose();
                DA.CloseSqlConnection();
            }
            // return SqlDS;
        }

        //Method to Populate Shcemes list along with --ALL-- option.
        public void GetSchemeList1(ref DropDownList ddlName)
        {
            DataSet SqlDS = new DataSet();

            try
            {
                SqlDS = SqlHelper.ExecuteDataset(DA.OpenSqlConnectionRDS_Finance_Final(), "USP_COMMON_GetSchemeList", new object[] { });
                //Following line commented on 26/04/2014 by PGG to add --ALL-- in the scheme combo.
                //FillDropDownList(SqlDS, ddlName);
                //FillDropDownList1(SqlDS, ddlName);



                ddlName.DataSource = SqlDS;
                ddlName.DataBind();
                ListItem li = new ListItem();
                li.Text = "--Select--";
                li.Value = "Sel";
                ListItem li1 = new ListItem();
                li1.Text = "--All--";
                li1.Value = "0";
                ddlName.Items.Insert(0, li1);
                ddlName.Items.Insert(0, li);


                //ddlName.Items.RemoveAt(ddlName.Items.IndexOf(ddlName.Items.FindByValue("05")));

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                SqlDS.Dispose();
                DA.CloseSqlConnection();
            }
            //return SqlDS;
        }

        //Method to poulate the Disability type
        public void GetDisability(ref DropDownList ddlName)
        {
            DataSet SqlDS = new DataSet();

            try
            {
                SqlDS = SqlHelper.ExecuteDataset(DA.OpenSqlConnectionRDS_Finance_Final(), "USP_COMMON_GetDisability", new object[] { });
                FillDropDownList(ref SqlDS, ref ddlName);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                SqlDS.Dispose();
                DA.CloseSqlConnection();
            }
            //return SqlDS;
        }

        //Method to poulate the Status of beneficiary
        public void GetStatus(ref DropDownList ddlName)
        {
            DataSet SqlDS = new DataSet();

            try
            {
                SqlDS = SqlHelper.ExecuteDataset(DA.OpenSqlConnectionRDS_Finance_Final(), "USP_COMMON_GetStatus", new object[] { });
                FillDropDownList(ref SqlDS, ref ddlName);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                SqlDS.Dispose();
                DA.CloseSqlConnection();
            }
            //return SqlDS;
        }

        //Method to poulate the months
        public void GetMyMonthList(ref DropDownList MyddlMonthList, bool SetCurruntMonth)
        {
            DateTime month = Convert.ToDateTime("1/1/2000");
            for (int i = 0; i < 12; i++)
            {

                DateTime NextMont = month.AddMonths(i);
                ListItem list = new ListItem();
                list.Text = NextMont.ToString("MMMM");
                list.Value = NextMont.Month.ToString();
                MyddlMonthList.Items.Add(list);
            }
            if (SetCurruntMonth == true)
            {
                MyddlMonthList.Items.FindByValue(DateTime.Now.Month.ToString()).Selected = true;
            }


        }

        //Method to poulate the year's.
        public void Populate_YearList(ref DropDownList ddlname)
        {
            int intYear = 0;

            //Year list can be changed by changing the lower and upper 
            //limits of the For statement 
            for (intYear = DateTime.Now.Year - 1; intYear <= DateTime.Now.Year; intYear++)
            {
                ListItem list = new ListItem();
                list.Text = intYear.ToString();
                list.Value = intYear.ToString();
                ddlname.Items.Add(list);
            }

            //Make the current year selected item in the list
            ddlname.Items.FindByValue(DateTime.Now.Year.ToString()).Selected = true;
        }

        public void GetTalukListNew(int iTalukCode, int iDistrictCode, ref DropDownList ddlName)
        {
            DataSet SqlDS = new DataSet();

            try
            {
                SqlDS = SqlHelper.ExecuteDataset(DA.OpenSqlConnectionRDS_Finance_Final(), "USP_COMMON_GetTaluk", new object[] { iDistrictCode, iTalukCode });
                FillDropDownList2(ref SqlDS, ref ddlName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                SqlDS.Dispose();
                DA.CloseSqlConnection();
            }
            //return SqlDS;
        }
        internal DataSet GetIFSC_List(int BM_District_Code, int BM_Taluk_Code, string bb_bankcode, string bb_bankbranchcode, ref DataSet ds)
        {
            try
            {
                ds = SqlHelper.ExecuteDataset(DA.OpenSqlConnectionRDS_Finance_Final(), "USP_COMMON_GetBankIFSC", new object[] { BM_District_Code, BM_Taluk_Code, bb_bankcode, bb_bankbranchcode });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                DA.CloseSqlConnection();
            }
            return ds;
        }

        //checking bank acount no
        public DataSet CheckBankAccountNo_ForGeneric_Integration(string AccountNo, string benid)
        {
            DataSet ds = new DataSet();
            int cnt;
            try
            {
                SqlConnection con = new SqlConnection();
                con = DA.OpenSqlConnectionRDS_Finance_Final();

                using (SqlCommand cmd = new SqlCommand("Check_Bank_AccountNo_New", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BM_Bank_Account_No", AccountNo.Trim());
                    cmd.Parameters.AddWithValue("@benid", benid);
                    SqlDataAdapter ad = new SqlDataAdapter(cmd);
                    ad.Fill(ds);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                DA.CloseSqlConnection();
            }
            return ds;
        }

        //Method to populate Bank's.
        public DataSet GetBank_List(string BankCode, ref DropDownList ddlName)
        {
            DataSet SqlDS = new DataSet();

            try
            {
                SqlDS = SqlHelper.ExecuteDataset(DA.OpenSqlConnectionRDS_Finance_Final(), "USP_COMMON_GetBanks_new", new object[] { BankCode });
                FillDropDownList(ref SqlDS, ref ddlName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                DA.CloseSqlConnection();
            }
            return SqlDS;
        }

        //Method to populate Bank Branch's.
        public void GetBankBranch_List(int districtCode, int talukCode, string BankBranchCode, string BankCode, ref DropDownList ddlName)
        {
            DataSet SqlDS = new DataSet();

            try
            {
                SqlDS = SqlHelper.ExecuteDataset(DA.OpenSqlConnectionRDS_Finance_Final(), "USP_COMMON_GetBankBranchs_new", new object[] { BankBranchCode, BankCode, districtCode, talukCode });
                FillDropDownList(ref SqlDS, ref ddlName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                DA.CloseSqlConnection();
            }
            //return SqlDS;
        }

        //Method to populate Bank Branch's.
        //public DataSet GetBankBranch_List(string BankBranchCode, string BankCode, int DistCode, int TalukCode)
        //{
        //    DataSet SqlDS = new DataSet();

        //    try
        //    {
        //        SqlDS = SqlHelper.ExecuteDataset(DA.OpenSqlConnectionRDS_Finance_Final(), "USP_COMMON_GetBankBranchs", new object[] { BankBranchCode, BankCode, DistCode, TalukCode });
        //        //FillDropDownList(SqlDS, ddlName);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        DA.CloseSqlConnection();

        //    }
        //    return SqlDS;
        //}

        public void GetDepartmentList(int iDepartmentCode, ref DropDownList ddlName)
        {
            DataSet SqlDS = new DataSet();
            try
            {
                SqlDS = SqlHelper.ExecuteDataset(DA.OpenSqlConnectionRDS_Finance_Final(), "USP_COMMON_GetDepartments", new object[] { iDepartmentCode });
                FillDropDownList(ref SqlDS, ref ddlName);


            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                SqlDS.Dispose();
                DA.CloseSqlConnection();
            }

        }

        public void GetDesignationList(int iDesignationCode, ref  DropDownList ddlName)
        {
            DataSet SqlDS = new DataSet();
            try
            {
                SqlDS = SqlHelper.ExecuteDataset(DA.OpenSqlConnectionRDS_Finance_Final(), "USP_COMMON_GetDesignation", new object[] { iDesignationCode });
                FillDropDownList(ref SqlDS, ref ddlName);


            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                SqlDS.Dispose();
                DA.CloseSqlConnection();
            }
        }

        public void GetTownList1(int iTalukCode, int iDistrictCode, ref DropDownList ddlName)
        {
            DataSet SqlDS = new DataSet();

            try
            {
                SqlDS = SqlHelper.ExecuteDataset(DA.OpenSqlConnectionRDS_Finance_Final(), "USP_COMMON_GetTown", new object[] { iDistrictCode, iTalukCode });
                //Commented the following 1 line by PGG on 26/4/2014
                FillDropDownList1(ref SqlDS, ref ddlName);
                //FillDropDownList1(SqlDS, ddlName);commented by winston on 8/10/2015
                ListItem li = new ListItem();
                li.Value = "Sel";

                if (ddlName.Items.Contains(li))
                {
                    ddlName.Items.RemoveAt(ddlName.Items.IndexOf(ddlName.Items.FindByValue("Sel")));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                SqlDS.Dispose();
                DA.CloseSqlConnection();
            }
            //return SqlDS;
        }

        //Method to poulate the Town's.
        public void GetWardList(int iDistrictCode, int iTalukCode, int iTownCode, ref DropDownList ddlName)
        {
            DataSet SqlDS = new DataSet();

            try
            {
                SqlDS = SqlHelper.ExecuteDataset(DA.OpenSqlConnectionRDS_Finance_Final(), "USP_COMMON_GetWard", new object[] { iDistrictCode, iTalukCode, iTownCode });
                FillDropDownList1(ref SqlDS, ref ddlName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                SqlDS.Dispose();
                DA.CloseSqlConnection();
            }
            //return SqlDS;
        }

        //Method to Populate Uploaded Date
        public void GetUploadedDate(int DistrictCode, int TalukCode, string RuralUrban, int HobliTown, int VillageWard, string SchemeCode, ref DropDownList ddlName, ref DropDownList ddlName1)
        {
            DataSet SqlDS = new DataSet();

            try
            {
                SqlDS = SqlHelper.ExecuteDataset(DA.OpenSqlConnectionRDS_Finance_Final(), "USP_COMMON_GetUploadedDate", new object[] { DistrictCode, TalukCode, RuralUrban, HobliTown, VillageWard, SchemeCode });
                FillDropDownList(ref SqlDS, ref ddlName);
                FillDropDownList(ref SqlDS, ref ddlName1);
                //ddlName.Items.RemoveAt(ddlName.Items.IndexOf(ddlName.Items.FindByValue("05")));

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                SqlDS.Dispose();
                DA.CloseSqlConnection();
            }
            //return SqlDS;
        }

        //Method to poulate the Gridview.
        public void FillGridview(ref GridView gvName, ref DataSet SqlDS)
        {

            try
            {
                gvName.DataSource = SqlDS;
                gvName.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        // To find a record in gridview and returning the page index
        public int FindGridviewPage(DataTable DT, string SearchField, string SearchValue)
        {

            try
            {
                DataTable mDT = new DataTable();
                mDT = DT.Copy();
                DataSet SqlDS = new DataSet();
                SqlDS.Tables.Add(mDT);
                int rowPOS = -1;

                string filterExp = SearchField.Trim() + "='" + SearchValue + "'";

                DataRow[] rows = SqlDS.Tables[0].Select(filterExp);
                if (rows.Length == 0)
                {
                    return -1;
                }
                else
                {
                    for (int i = 0; i < SqlDS.Tables[0].Rows.Count; i++)
                    {
                        if (string.Compare(SqlDS.Tables[0].Rows[i][SearchField.Trim()].ToString().Trim(), SearchValue.Trim()) == 0)
                        //if(SqlDS.Tables[0].Rows[i][SearchField].ToString()==SearchValue)
                        {
                            rowPOS = i;
                            break;
                        }
                    }
                }
                return rowPOS;

            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        //private int findColumnIndex(GridView gridView, string accessibleHeaderText)
        //{
        //    for (int index = 0; index < gridView.Columns.Count; index++)
        //    {
        //        if (String.Compare(gridView.Columns[index].AccessibleHeaderText, accessibleHeaderText, true) == 0)
        //        {
        //            return index;
        //        }
        //    }
        //    return -1;
        //}

        //Method to poulate the dropdownlist.

        public void FillDropDownList(ref DataSet DS, ref DropDownList ddlName)
        {
            try
            {
                ddlName.Items.Clear();
                ddlName.DataSource = DS;
                ddlName.DataBind();
                ListItem li = new ListItem();
                li.Text = "--Select--";
                li.Value = "0";
                ddlName.Items.Insert(0, li);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void FillDropDownList1(ref DataSet DS, ref DropDownList ddlName)
        {
            try
            {
                ddlName.Items.Clear();
                ddlName.DataSource = DS;
                ddlName.DataBind();
                ListItem li = new ListItem();
                li.Text = "--Select--";
                li.Value = "Sel";
                ListItem li1 = new ListItem();
                li1.Text = "--All--";
                li1.Value = "0";
                ddlName.Items.Insert(0, li1);
                ddlName.Items.Insert(0, li);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void FillDropDownListScheme(ref DataSet DS, ref DropDownList ddlScheme)
        {
            try
            {
                ddlScheme.Items.Clear();
                ddlScheme.DataSource = DS;
                ddlScheme.DataBind();               
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        //for Beneficiary Reports
        public void FillDropDownList2(ref DataSet DS, ref DropDownList ddlName)
        {
            try
            {
                ddlName.Items.Clear();
                ddlName.DataSource = DS;
                ddlName.DataBind();
                ListItem li = new ListItem();
                li.Text = "--Select--";
                li.Value = "Sel";
                ddlName.Items.Insert(0, li);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        //for habitation and ward
        public void FillDropDownListNew(ref DataSet DS, ref DropDownList ddlName)
        {
            try
            {
                ddlName.DataSource = DS;
                ddlName.DataBind();
                ListItem li = new ListItem();
                li.Text = "--Select--";
                li.Value = "-1";
                ddlName.Items.Insert(0, li);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public void EnableControls(Control parent)
        {
            foreach (Control _ChildControl in parent.Controls)
            {
                if ((_ChildControl.Controls.Count > 0))
                {
                    EnableControls(_ChildControl);
                }
                else
                {
                    if (_ChildControl is TextBox)
                    {
                        ((TextBox)_ChildControl).Enabled = true;
                    }
                    else if (_ChildControl is CheckBox)
                    {
                        ((CheckBox)_ChildControl).Enabled = true;
                    }
                    else if (_ChildControl is DropDownList)
                    {
                        ((DropDownList)_ChildControl).Enabled = true;
                    }
                    else if (_ChildControl is RadioButtonList)
                    {
                        //RadioButtonList rdoList = new RadioButtonList();
                        //foreach (ListItem Li in rdoList.Items)
                        //{
                        //    Li.Enabled = true;
                        //}
                        ((RadioButtonList)_ChildControl).Enabled = true;
                    }
                    else if (_ChildControl is ListBox)
                    {
                        ((ListBox)_ChildControl).Enabled = true;
                    }
                    else if (_ChildControl is ImageButton)
                    {
                        ((ImageButton)_ChildControl).Enabled = true;
                    }
                }
            }
        }

        // Method to Clear controls on the page
        public void ClearControls(Control parent)
        {
            foreach (Control _ChildControl in parent.Controls)
            {
                if ((_ChildControl.Controls.Count > 0))
                {
                    ClearControls(_ChildControl);
                }
                else
                {
                    if (_ChildControl is TextBox)
                    {
                        ((TextBox)_ChildControl).Text = string.Empty;
                    }
                    else if (_ChildControl is CheckBox)
                    {
                        ((CheckBox)_ChildControl).Checked = false;
                    }
                    else if (_ChildControl is DropDownList)
                    {
                        ((DropDownList)_ChildControl).SelectedIndex = 0;
                    }
                    else if (_ChildControl is RadioButtonList)
                    {
                        RadioButtonList rdoList = new RadioButtonList();
                        foreach (ListItem Li in rdoList.Items)
                        {
                            Li.Selected = false;
                        }
                    }
                }
            }
        }

        public void ClearControls1(Control parent)
        {
            foreach (Control _ChildControl in parent.Controls)
            {
                if ((_ChildControl.Controls.Count > 0))
                {
                    ClearControls1(_ChildControl);
                }
                else
                {
                    if (_ChildControl is TextBox)
                    {
                        ((TextBox)_ChildControl).Text = string.Empty;
                    }
                    else if (_ChildControl is CheckBox)
                    {
                        ((CheckBox)_ChildControl).Checked = false;
                    }
                    else if (_ChildControl is RadioButtonList)
                    {
                        RadioButtonList rdoList = new RadioButtonList();
                        foreach (ListItem Li in rdoList.Items)
                        {
                            Li.Selected = false;
                        }
                    }
                }
            }
        }

        public void MessageBox(string msg, UpdatePanel updpnl)
        {
            System.Web.UI.ScriptManager.RegisterStartupScript(updpnl, updpnl.GetType(), "popupScriptRecordCheck"+Guid.NewGuid().ToString(), "<script type='text/javascript'>" + "alert('" + msg + "');" + "</script>", false);
        }
        
        //Village Update
        public void GetVillageListNew(int iTalukCode, int iDistrictCode, byte iHoblicode, ref DropDownList ddlName)
        {
            DataSet SqlDS = new DataSet();

            try
            {
                SqlDS = SqlHelper.ExecuteDataset(DA.OpenSqlConnectionRDS_Finance_Final(), "USP_COMMON_GetVillage", new object[] { iDistrictCode, iTalukCode, iHoblicode });
                FillDropDownListNew(ref SqlDS, ref ddlName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                SqlDS.Dispose();
                DA.CloseSqlConnection();
            }
        }

        public void GetHabitationListNew(int iTalukCode, int iDistrictCode, string iHobliCode, int iVillageCode, ref DropDownList ddlName)
        {
            DataSet SqlDS = new DataSet();

            try
            {
                SqlDS = SqlHelper.ExecuteDataset(DA.OpenSqlConnectionRDS_Finance_Final(), "USP_COMMON_GetHabitation", new object[] { iDistrictCode, iTalukCode, iHobliCode, iVillageCode });
                FillDropDownListNew(ref SqlDS, ref ddlName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                SqlDS.Dispose();
                DA.CloseSqlConnection();
            }
            //return SqlDS;
        }

        public void GetWardListNew(int iDistrictCode, int iTalukCode, int iTownCode, ref DropDownList ddlName)
        {
            DataSet SqlDS = new DataSet();

            try
            {
                SqlDS = SqlHelper.ExecuteDataset(DA.OpenSqlConnectionRDS_Finance_Final(), "USP_COMMON_GetWard", new object[] { iDistrictCode, iTalukCode, iTownCode });
                FillDropDownListNew(ref SqlDS, ref ddlName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                SqlDS.Dispose();
                DA.CloseSqlConnection();
            }
            //return SqlDS;
        }

        public void GetTreasuryCode(int iDistrictCode, int iTalukCode, ref DropDownList ddlName)
        {
            DataSet SqlDS = new DataSet();

            try
            {
                SqlDS = SqlHelper.ExecuteDataset(DA.OpenSqlConnectionRDS_Finance_Final(), "USP_COMMON_FETCH_TREASURY_CODE", new object[] { iDistrictCode, iTalukCode });
                FillDropDownList(ref SqlDS, ref ddlName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                SqlDS.Dispose();
                DA.CloseSqlConnection();
            }
            //return SqlDS;
        }

        public DataSet GetBenDetailsOnTreasuryCode(int iDistrictCode, int iTalukCode, string TreasuryCode, string TreasuryUniqueID)
        {
            DataSet SqlDS = new DataSet();

            try
            {
                SqlDS = SqlHelper.ExecuteDataset(DA.OpenSqlConnectionRDS_Finance_Final(), "USP_GET_DETAILS_ON_PPO", new object[] { iDistrictCode, iTalukCode, TreasuryCode, TreasuryUniqueID });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                SqlDS.Dispose();
                DA.CloseSqlConnection();
            }
            return SqlDS;
        }

        public void GetSubSchemeList( ref DropDownList ddlName, ref string schemecode)
        {
            DataSet SqlDS = new DataSet();

            try
            {
                SqlDS = SqlHelper.ExecuteDataset(DA.OpenSqlConnectionRDS_Finance_Final(), "USP_COMMON_GETSUBCAT", new object[] { schemecode });
                FillDropDownList(ref SqlDS, ref ddlName);
                //ddlName.Items.RemoveAt(ddlName.Items.IndexOf(ddlName.Items.FindByValue("05")));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                SqlDS.Dispose();
                DA.CloseSqlConnection();
            }
            //return SqlDS;
        }

        //Method to populate the Taluk's
        //public void GetTalukListNew(int iTalukCode, int iDistrictCode, ref DropDownList ddlName)
        //{
        //    DataSet SqlDS = new DataSet();

        //    try
        //    {
        //        SqlDS = SqlHelper.ExecuteDataset(DA.OpenSqlConnectionRDS_Finance_Final(), "USP_COMMON_GetTaluk", new object[] { iDistrictCode, iTalukCode });
        //        FillDropDownList2(ref SqlDS, ref ddlName);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        SqlDS.Dispose();
        //        DA.CloseSqlConnection();
        //    }
        //    //return SqlDS;
        //}

        public string GetGPCode(int iTalukCode, int iDistrictCode, int iHobliCode, int iVillageCode)
        {
            DataSet SqlDS = new DataSet();
            string tempGPCode = "";
            try
            {
                SqlDS = SqlHelper.ExecuteDataset(DA.OpenSqlConnectionRDS_Finance_Final(), "USP_COMMON_GetGPCode", new object[] { iDistrictCode, iTalukCode, iHobliCode, iVillageCode });
                tempGPCode = SqlDS.Tables[0].Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                SqlDS.Dispose();
                DA.CloseSqlConnection();
            }
            return tempGPCode;
        }

        public string getHobaliCode(int iTalukCode, int iDistrictCode, int iTownCode, int iWardCode)
        {
            DataSet SqlDS = new DataSet();
            string tempHobaliCode = "";
            try
            {
                SqlDS = SqlHelper.ExecuteDataset(DA.OpenSqlConnectionRDS_Finance_Final(), "USP_COMMON_GetHobalicode_villageEdit", new object[] { iDistrictCode, iTalukCode, iTownCode, iWardCode });

                if (SqlDS.Tables[0].Rows.Count > 0)
                {
                    tempHobaliCode = SqlDS.Tables[0].Rows[0][0].ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                SqlDS.Dispose();
                DA.CloseSqlConnection();
            }
            return tempHobaliCode;
        }

        public DataSet GetSigningDetails(string loginID, ref DataSet DS)
        {
            try
            {
                DS = SqlHelper.ExecuteDataset(DA.OpenSqlConnectionRDS_Finance_Final(), "USP_COMMON_GetLogin", new object[] { loginID });
                return DS;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                DA.CloseSqlConnection();
            }
        }

        public DataSet GetBeneficiaryInfo(int dist, int taluk, string benID, ref DataSet ds)
        {
            try
            {
                ds = SqlHelper.ExecuteDataset(DA.OpenSqlConnectionRDS_Finance_Final(), "USP_COMMON_GetBeneficiaryInfo", new object[] { benID, dist, taluk });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                DA.CloseSqlConnection();
            }
            return ds; 
        }
        //public DataSet GetBeneficiaryUpdateVillageTown(int pflg,ref DataSet ds)
        //{
        //    try
        //    {
        //        ds = SqlHelper.ExecuteDataset(DA.OpenSqlConnectionRDS_Finance_Final(), "USP_Display_Ben_Details_new_bank", new object[] {  pflg });
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        DA.CloseSqlConnection();
        //    }
        //    return ds;

        //}

        public DataSet GetBeneficiaryUpdateVillageTown(int distcode, int talukcode,string Ppoid, ref DataSet ds)
        {
            try
            {
                ds = SqlHelper.ExecuteDataset(DA.OpenSqlConnectionRDS_Finance_Final1(), "USP_Display_Ben_Details_new", new object[] { distcode, talukcode, Ppoid });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                DA.CloseSqlConnection();
            }
            return ds; 

        }

        public int CheckBankAccountNobenid(string AccountNo)
        {
            DataAccess da = new DataAccess();
            int cnt;
            try
            {
                //SqlParameter[] spParameter = new SqlParameter[2];

                //spParameter[0] = new SqlParameter("@a", SqlDbType.VarChar, 100);
                //spParameter[0].Direction = ParameterDirection.Input;
                //spParameter[0].Value = AccountNo;

                //spParameter[1] = new SqlParameter("@b", SqlDbType.Int, 1);
                //spParameter[1].Direction = ParameterDirection.Output;
                ////spParameter[1].Value = 0;            

                //SqlHelper.ExecuteNonQuery(da.OpenSqlConnectionRDS_Finance_Final(), "Check_Bank_AccountNo", spParameter);

                //cnt = Convert.ToInt16(spParameter[1].Value);
                //   string con = "";
                SqlConnection con = new SqlConnection();
                
                con = da.OpenSqlConnectionRDS_Finance_Final();

                using (SqlCommand cmd = new SqlCommand("Check_Bank_AccountNo", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BM_Bank_Account_No", AccountNo.Trim());
                    //   cmd.Parameters.AddWithValue("@benid", benid);
                    cmd.Parameters.Add("@cnt", SqlDbType.Int, 3);
                    cmd.Parameters["@cnt"].Direction = ParameterDirection.Output;
                    //   con.Open();
                    cmd.ExecuteNonQuery();
                    //  con.Close();
                    cnt = Convert.ToInt16(cmd.Parameters["@cnt"].Value);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                da.CloseSqlConnection();
            }
            return cnt;
        }

        //public DataSet CheckBnakAccountNo( string Bm_Bank_Account_No,ref DataSet ds)
        //{
        //    try
        //    {
        //        ds = SqlHelper.ExecuteDataset(DA.OpenSqlConnectionRDS_Finance_Final(), "Check_Bank_AccountNo_New_ForVillageAndTown", new object[] { Bm_Bank_Account_No, benid });
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        DA.CloseSqlConnection();
        //    }
        //    return ds;

        //}

        

        public DataSet GetBeneficiaryInfoCtoR(int dist, int taluk, string benID, ref DataSet ds)
        {
            try
            {
                ds = SqlHelper.ExecuteDataset(DA.OpenSqlConnectionRDS_Finance_Final(), "USP_COMMON_GetBeneficiaryInfo_CtoR", new object[] { benID, dist, taluk });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                DA.CloseSqlConnection();
            }
            return ds;
        }
        public DataSet GetBeneficiaryInforejectedCtoR(int dist, int taluk, string benID, ref DataSet ds)
        {
            try
            {
                ds = SqlHelper.ExecuteDataset(DA.OpenSqlConnectionRDS_Finance_Final(), "USP_COMMON_GetBeneficiaryInforejected_CtoR", new object[] { benID, dist, taluk });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                DA.CloseSqlConnection();
            }
            return ds;
        }


        public DataSet GetBeneficiaryInfoStoR(int dist, int taluk, string benID, ref DataSet ds)
        {
            try
            {
                ds = SqlHelper.ExecuteDataset(DA.OpenSqlConnectionRDS_Finance_Final(), "USP_COMMON_GetBeneficiaryInfo_StoR", new object[] { benID, dist, taluk });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                DA.CloseSqlConnection();
            }
            return ds;
        }
        public DataSet GetBeneficiaryInfoforRtoS(int dist, int taluk, string benID, string RdsId,string Pppoid, ref DataSet ds)
        {
            try
            {
                ds = SqlHelper.ExecuteDataset(DA.OpenSqlConnectionRDS_Finance_Final(), "USP_COMMON_GetBeneficiaryInfoRtoS", new object[] { benID, RdsId, Pppoid,dist, taluk });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                DA.CloseSqlConnection();
            }
            return ds;
        }

        public DataSet GetBeneficiaryInfoforRtoS_dir( string benID, string RdsId, ref DataSet ds)
        {
            try
            {
                ds = SqlHelper.ExecuteDataset(DA.OpenSqlConnectionRDS_Finance_Final(), "USP_COMMON_GetBeneficiaryInfoRtoS_dir", new object[] { benID, RdsId });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                DA.CloseSqlConnection();
            }
            return ds;
        }


        public void Insert_Beneficiary_Master_History(string BenId, string formName, string loginName, string remarks)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(DA.OpenSqlConnectionRDS_Finance_Final(), "USP_Insert_Beneficiary_Master_History1", new object[] { BenId, formName, loginName, remarks });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                DA.CloseSqlConnection();
            }
        }

        //Method to clear all cookies and clear the session values
        public void ClearCookies()
        {
            // Clean Auth Cookie
            HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, string.Empty);
            authCookie.Expires = DateTime.Now.AddDays(-1);
            HttpContext.Current.Response.Cookies.Add(authCookie);

            // clean Session Cookie
            HttpCookie sessionCookie = new HttpCookie("ASP.NET_SessionId", string.Empty);
            sessionCookie.Expires = DateTime.Now.AddYears(-30);
            HttpContext.Current.Response.Cookies.Add(sessionCookie);
        }

        public string FilterForXSS(string inputValue)
        {

            int pos;
            int pos1;
            string filteredValue = "";
            string remainingValue = "";
            string outputValue = "";

            //pos = inputValue.search("<script");
            pos = inputValue.IndexOf("<script", StringComparison.OrdinalIgnoreCase);

            if (pos >= 0)
            {

                filteredValue = inputValue.Substring(0, pos);       // Checking at the beginning of the string

                if (filteredValue == "")
                {
                    pos1 = inputValue.IndexOf(">");

                    if (pos1 > pos)
                    {
                        outputValue = inputValue.Substring((pos1 + 1), inputValue.Length);
                    }
                }
                remainingValue = inputValue.Substring(pos, inputValue.Length);

                if (remainingValue != "")
                {                     // Checking at the end or middle of the string
                    pos1 = remainingValue.IndexOf(">");

                    if (pos1 < pos)
                    {
                        remainingValue = remainingValue.Substring((pos1 + 1), remainingValue.Length);
                        outputValue = (filteredValue + remainingValue);
                    }
                }
            }

            if (outputValue != "")
            {
                inputValue = outputValue;
            }
            pos = inputValue.IndexOf("<embed");

            if (pos >= 0)
            {

                filteredValue = inputValue.Substring(0, pos);       // Checking at the beginning of the string

                if (filteredValue == "")
                {
                    pos1 = inputValue.IndexOf(">");

                    if (pos1 > pos)
                    {
                        outputValue = inputValue.Substring((pos1 + 1), inputValue.Length);
                    }
                }
                remainingValue = inputValue.Substring(pos, inputValue.Length);

                if (remainingValue != "")
                {                     // Checking at the end or middle of the string
                    pos1 = remainingValue.IndexOf(">");

                    if (pos1 < pos)
                    {
                        remainingValue = remainingValue.Substring((pos1 + 1), remainingValue.Length);
                        outputValue = (filteredValue + remainingValue);
                    }
                }
            }

            if (outputValue == "")
            {
                outputValue = inputValue;
            }

            return removeSpecialChars(outputValue);
        }

        private string removeSpecialChars(string inputValue)
        {
            inputValue = inputValue.Replace("</script>", "");
            inputValue = inputValue.Replace("</embed>", "");
            inputValue = inputValue.Replace("'", "");
            inputValue = inputValue.Replace("\"", "");
            inputValue = inputValue.Replace(";", "");
            //inputValue = inputValue.Replace("=", "");
            inputValue = inputValue.Replace("DELETE", "");
            inputValue = inputValue.Replace("SELECT", "");
            inputValue = inputValue.Replace(" OR ", "");
            inputValue = inputValue.Replace(" AND ", "");
            inputValue = inputValue.Replace(" DROP ", "");
            inputValue = inputValue.Replace("+OR+", "");
            inputValue = inputValue.Replace("+AND+", "");
            inputValue = inputValue.Replace("+DROP+", "");

            return inputValue;
        }

        public string Create16DigitString()
        {
            var builder = new StringBuilder();
            Random RNG = new Random();
            while (builder.Length < 16)
            {
                builder.Append(RNG.Next(10).ToString());
            }
            return builder.ToString();
        }

        //Winston 11 NOV 2015
        public bool CheckSpecialChars(Control ctl)
        {
            TextBox ctl1;
            ctl1 = (TextBox)ctl;
            if (Regex.IsMatch(ctl1.Text, "[@='!$%&*()_;:<>?,/{}~|\\`]") | Regex.IsMatch(ctl1.Text, "[0-9]"))
            {
                return true;
            }
            return false;
        }

        public void InsertErrorLog(string message)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(DA.OpenSqlConnectionRDS_Finance_Final(), "USP_Insert_ErrorLog", new object[] { message });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                DA.CloseSqlConnection();
            }
        }

        public bool CheckAddress(Control Ctl)
        {
            TextBox ctl1;
            ctl1 = (TextBox)Ctl;
            if (Regex.IsMatch(ctl1.Text, "[@=!$%&*()_;:<>?~|]"))
            {
                return true;
            }
            return false;
        }
        //----

        // ML
        public bool CheckForPdf(Byte[] filesize, string contentType)
        {
            bool ReturnValue = false;

            //  Stream str = FU.FileContent;
            //  StreamReader sr = new StreamReader(str);
            //  string contentText = sr.ReadToEnd();

            //  byte[] buffer = null;
            ////  FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
            //  //StreamReader sr = new StreamReader(System.IO.Path.GetFileName(FU.PostedFile.FileName));
            //  char[] buf = new char[5];
            //  sr.Read(buf, 0, 4);
            //  sr.Close();
            //  String Hdr = buf[0].ToString()
            //      + buf[1].ToString()
            //      + buf[2].ToString()
            //      + buf[3].ToString()
            //      + buf[4].ToString();

            //Stream fs = FU.PostedFile.InputStream;

            //BinaryReader br = new BinaryReader(fs);

            Byte[] bytes = filesize;
            Byte[] newbytes = new Byte[4];
            for (int i = 0; i < 4; i++)
            {
                newbytes[i] = bytes[i];
            }

            if (contentType.ToLower() == "application/pdf")
            {

                for (int j = 0; j < 1; j++)
                {
                    if (newbytes[j] != 0x25)
                    {

                    }
                    else if (newbytes[j + 1] != 0x50)
                    {

                    }
                    else if (newbytes[j + 2] != 0x44)
                    {

                    }
                    else if (newbytes[j + 3] != 0x46)
                    {

                    }
                    else
                    {
                        ReturnValue = true;
                    }

                }

            }



            return ReturnValue;

        }

        public string FingerReport1 { get; set; }

        public string FingerReport2 { get; set; }

        public string LoginID { get; set; }
    }
}