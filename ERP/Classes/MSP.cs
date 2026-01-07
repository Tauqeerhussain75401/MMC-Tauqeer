using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Globalization;
using System.Drawing;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace ERP
{
    class MSP
    {
        public static int Check_LastSession(string userid)
        {
            int sessionopen = 0;
            try
            {
                OracleCommand oc = new OracleCommand("lastsession", clsConnection.con);
                oc.CommandType = CommandType.StoredProcedure;
                oc.Parameters.Add("vUserid", OracleDbType.Varchar2, 30).Value = userid;
                oc.Parameters.Add("vReturn", OracleDbType.Int32).Direction = ParameterDirection.Output;
                oc.ExecuteNonQuery();
                sessionopen = ((OracleDecimal)oc.Parameters["vReturn"].Value).ToInt32();
                return sessionopen;
            }
            catch (Exception e)
            {
                Errors.writeline(e.Message, "MSP_LastSession");
                string result = MyMessageBox.ShowBox(e.Message, Variable.Version, 1);
                return sessionopen;
            }
        }

        public static string GL_Add_Edit(string VVdate, string Vfkaccountid, string Vvtype, string Vvno, string Vdescription,
         string Vfkbankid, string Vchequeno, string Vdr, string Vcr, string Vfcdr,
         string Vfccr, string Vrate, string Vstatus, string Vvseq, string Vfkfccode, string Vcontrafkbrcode,
         string Vddttid, string Vfktransactionid, string Vclearentry, string Vreconciledate, string Vreconcileby,
         string Vrperiodsfrom, string Vrperiodsto, string Vfkimageid,
 string Vfkclientcode, string Vfkdirectorid, string Vfkhrid, string Vbanificiary, string VDocumentChanged, string Vfkdocumentid, byte[] VDocuments, string VSlipNo)
        {
            string tf = "";
            try
            {
                OracleCommand DbCommand = new OracleCommand("glVNo_add_edit1",clsConnection.con /*clsConnection.co*/);
                DbCommand.CommandType = CommandType.StoredProcedure;
                DbCommand.Parameters.Add("VVdate", OracleDbType.Varchar2).Value = VVdate;
                DbCommand.Parameters.Add("Vfkaccountid", OracleDbType.Varchar2).Value = Vfkaccountid;
                DbCommand.Parameters.Add("Vvtype", OracleDbType.Varchar2).Value = Vvtype;
                DbCommand.Parameters.Add("Vvno", OracleDbType.Varchar2).Value = Vvno;
                // DbCommand.Parameters.Add("Vvdate", OracleDbType.Varchar2).Value = Vvdate;
                DbCommand.Parameters.Add("Vdescription", OracleDbType.Varchar2, 1000).Value = Vdescription;
                DbCommand.Parameters.Add("Vfkbrcode", OracleDbType.Varchar2).Value = Variable.BranchCode;
                DbCommand.Parameters.Add("Vfkbankid", OracleDbType.Varchar2).Value = Vfkbankid;
                DbCommand.Parameters.Add("Vchequeno", OracleDbType.Varchar2).Value = Vchequeno;
                DbCommand.Parameters.Add("Vdr", OracleDbType.Varchar2).Value = Vdr;
                DbCommand.Parameters.Add("Vcr", OracleDbType.Varchar2).Value = Vcr;
                DbCommand.Parameters.Add("Vfcdr", OracleDbType.Varchar2).Value = Vfcdr;
                DbCommand.Parameters.Add("Vfccr", OracleDbType.Varchar2).Value = Vfccr;
                DbCommand.Parameters.Add("Vrate", OracleDbType.Varchar2).Value = Vrate;
                DbCommand.Parameters.Add("Vstatus", OracleDbType.Varchar2).Value = Vstatus;
                DbCommand.Parameters.Add("Vvseq", OracleDbType.Varchar2).Value = Vvseq;
                DbCommand.Parameters.Add("Vfkfccode", OracleDbType.Varchar2).Value = Vfkfccode;
                DbCommand.Parameters.Add("Vcontrafkbrcode", OracleDbType.Varchar2).Value = Vcontrafkbrcode;
                DbCommand.Parameters.Add("Vddttid", OracleDbType.Varchar2).Value = Vddttid;
                DbCommand.Parameters.Add("Vfktransactionid", OracleDbType.Varchar2).Value = Vfktransactionid;
                DbCommand.Parameters.Add("Vclearentry", OracleDbType.Varchar2).Value = Vclearentry;
                DbCommand.Parameters.Add("Vreconciledate", OracleDbType.Varchar2).Value = Vreconciledate;
                DbCommand.Parameters.Add("Vreconcileby", OracleDbType.Varchar2).Value = Vreconcileby;
                DbCommand.Parameters.Add("Vrperiodsfrom", OracleDbType.Varchar2).Value = Vrperiodsfrom;
                DbCommand.Parameters.Add("Vrperiodsto", OracleDbType.Varchar2).Value = Vrperiodsto;
                DbCommand.Parameters.Add("VUser", OracleDbType.Varchar2).Value = Variable.User;
                DbCommand.Parameters.Add("Vfkimageid", OracleDbType.Varchar2).Value = Vfkimageid;
                DbCommand.Parameters.Add("Vfkclientcode", OracleDbType.Varchar2).Value = Vfkclientcode;
                DbCommand.Parameters.Add("Vfkdirectorid", OracleDbType.Varchar2).Value = Vfkdirectorid;
                DbCommand.Parameters.Add("Vfkhrid", OracleDbType.Varchar2).Value = Vfkhrid;
                DbCommand.Parameters.Add("Vbanificiary", OracleDbType.Varchar2).Value = Vbanificiary;
                DbCommand.Parameters.Add("VTerminalID", OracleDbType.Varchar2).Value = Variable.TerminalId;
                DbCommand.Parameters.Add("VDocumentChanged", OracleDbType.Varchar2, 1).Value = VDocumentChanged;
                DbCommand.Parameters.Add("Vfkdocumentid", OracleDbType.Varchar2, 5).Value = Vfkdocumentid;
                DbCommand.Parameters.Add("VDocuments", OracleDbType.Blob).Value = VDocuments;
                DbCommand.Parameters.Add("VSlipNo", OracleDbType.Varchar2, 25).Value = VSlipNo;
                //DbCommand.Parameters.Add("VDepositBy", OracleDbType.Varchar2, 100).Value = VDepositBy;
                DbCommand.Parameters.Add("ReturnValue", OracleDbType.Varchar2, 20);
                DbCommand.Parameters["ReturnValue"].Direction = ParameterDirection.Output;
                DbCommand.ExecuteNonQuery();
                tf = DbCommand.Parameters["ReturnValue"].Value.ToString();
                DbCommand.Dispose();
                return tf;

            }
            catch (Exception ee)
            {
                Errors.writeline(ee.Message, "MSP_ GL_Add_Edit");
                string result = MyMessageBox.ShowBox(ee.Message, Variable.Version, 1);
                return tf;
            }
        }

        public static string Change_GL_status(string VVno, string VVtype, string Vstatus)
        {
            string tf = "";
            try
            {

                OracleCommand DbCommand = new OracleCommand("Change_GL_status", clsConnection.con);
                DbCommand.CommandType = CommandType.StoredProcedure;
                DbCommand.Parameters.Add("VVno", OracleDbType.Varchar2, 10).Value = VVno;
                DbCommand.Parameters.Add("VVtype", OracleDbType.Varchar2, 10).Value = VVtype;
                DbCommand.Parameters.Add("VStatus", OracleDbType.Varchar2, 1).Value = Vstatus;
                DbCommand.Parameters.Add("VUser", OracleDbType.Varchar2, 200).Value = Variable.UserId;
                DbCommand.Parameters.Add("VTerminalID", OracleDbType.Varchar2, 200).Value = Variable.TerminalId;

                DbCommand.Parameters.Add("ReturnValue", OracleDbType.Varchar2, 20);
                DbCommand.Parameters["ReturnValue"].Direction = ParameterDirection.Output;
                DbCommand.ExecuteNonQuery();

                tf = DbCommand.Parameters["ReturnValue"].Value.ToString();
                DbCommand.Dispose();

                return tf;

            }
            catch (Exception ee)
            {
                Errors.writeline(ee.Message, "MSP_ Change_GL_status");
                string result = MyMessageBox.ShowBox(ee.Message, Variable.Version, 1);
                return tf;
            }
        }
        public static string ChartofAccounts_Add_Edit(string accountid, string accountitile, string parentaccountid,
                string control, string Level, string status)
        {
            string tf = "";
            try
            {

                OracleCommand DbCommand = new OracleCommand("chartofaccounts_add_edit", clsConnection.con);
                DbCommand.CommandType = CommandType.StoredProcedure;
                DbCommand.Parameters.Add("VAccountID", OracleDbType.Varchar2, 300).Value = accountid;
                DbCommand.Parameters.Add("VAccountTitle", OracleDbType.Varchar2, 200).Value = accountitile;
                DbCommand.Parameters.Add("VStatus", OracleDbType.Varchar2, 1).Value = status;
                DbCommand.Parameters.Add("VParentAccountId", OracleDbType.Varchar2, 300).Value = parentaccountid;
                DbCommand.Parameters.Add("VControl", OracleDbType.Varchar2, 20).Value = control;
                DbCommand.Parameters.Add("VCreatedBy", OracleDbType.Varchar2, 200).Value = Variable.UserId;
                DbCommand.Parameters.Add("VEditBy", OracleDbType.Varchar2, 200).Value = Variable.UserId;
                DbCommand.Parameters.Add("VTerminalID", OracleDbType.Varchar2, 200).Value = Variable.TerminalId;
                DbCommand.Parameters.Add("VacLevel", OracleDbType.Varchar2, 1).Value = Level;

                DbCommand.Parameters.Add("ReturnValue", OracleDbType.Varchar2, 20);
                DbCommand.Parameters["ReturnValue"].Direction = ParameterDirection.Output;
                DbCommand.ExecuteNonQuery();

                tf = DbCommand.Parameters["ReturnValue"].Value.ToString();
                DbCommand.Dispose();

                return tf;

            }
            catch (Exception ee)
            {
                Errors.writeline(ee.Message, "MSP_ChartofAccounts_Add_Edit");
                string result = MyMessageBox.ShowBox(ee.Message, Variable.Version, 1);
                return tf;
            }
        }



        public static string BankAccount_AddEdit(string bankcode, string bankname, string branchname, string branchcode, string city, string country, string currency, string accounttype)
        {
            string tf = "";
            try
            {

                OracleCommand DbCommand = new OracleCommand("bankdetail_add_edit", clsConnection.con);
                DbCommand.CommandType = CommandType.StoredProcedure;
                DbCommand.Parameters.Add("VBankCode", OracleDbType.Varchar2, 200).Value = bankcode;
                DbCommand.Parameters.Add("VBankName", OracleDbType.Varchar2, 200).Value = bankname;
                DbCommand.Parameters.Add("VBranchName", OracleDbType.Varchar2, 200).Value = branchname;
                DbCommand.Parameters.Add("VCountry", OracleDbType.Varchar2, 200).Value = country;
                DbCommand.Parameters.Add("VFkcountryCode", OracleDbType.Varchar2, 200).Value = null;
                DbCommand.Parameters.Add("VCurrency", OracleDbType.Varchar2, 200).Value = currency;
                DbCommand.Parameters.Add("VIban", OracleDbType.Varchar2, 200).Value = null;
                DbCommand.Parameters.Add("VIbancheckDigits", OracleDbType.Varchar2, 200).Value = null;
                DbCommand.Parameters.Add("VBban", OracleDbType.Varchar2, 200).Value = null;
                DbCommand.Parameters.Add("VBankIdentifier", OracleDbType.Varchar2, 200).Value = null;
                DbCommand.Parameters.Add("VSepaMember", OracleDbType.Varchar2, 1).Value = null;
                DbCommand.Parameters.Add("VStatus", OracleDbType.Varchar2, 1).Value = null;
                DbCommand.Parameters.Add("VCreatedBy", OracleDbType.Varchar2, 300).Value = Variable.UserId;
                DbCommand.Parameters.Add("VEditBy", OracleDbType.Varchar2, 200).Value = Variable.UserId;
                DbCommand.Parameters.Add("VApproveBy", OracleDbType.Varchar2, 200).Value = Variable.UserId;
                DbCommand.Parameters.Add("VBranchCode", OracleDbType.Varchar2, 200).Value = branchcode;
                DbCommand.Parameters.Add("VIsoCountryCode", OracleDbType.Varchar2, 200).Value = null;
                DbCommand.Parameters.Add("VAccountType", OracleDbType.Varchar2, 200).Value = accounttype;
                DbCommand.Parameters.Add("VBranch_code", OracleDbType.Varchar2, 200).Value = branchcode;
                DbCommand.Parameters.Add("VCity", OracleDbType.Varchar2, 300).Value = city;
                DbCommand.Parameters.Add("VCountry", OracleDbType.Varchar2, 200).Value = country;


                DbCommand.Parameters.Add("ReturnValue", OracleDbType.Varchar2, 20);
                DbCommand.Parameters["ReturnValue"].Direction = ParameterDirection.Output;
                DbCommand.ExecuteNonQuery();

                tf = DbCommand.Parameters["ReturnValue"].Value.ToString();
                DbCommand.Dispose();

                return tf;

            }
            catch (Exception ex)
            {
                Errors.writeline(ex.Message, "MSP_BankAccount_AddEdit");
                string result = MyMessageBox.ShowBox(ex.Message, Variable.Version, 1);
                return tf;
            }
        }


        public static string Clients_Add_Edit
        (string VClientID, string VAttribute, string VClientTitle, string VContactPerson, string VBusinessNature,
         string VAddress, string VCellNo, string VContactNo, string VEmailAddress, string VSoftware, string VCatagory,
         string VCity, string VCountry, string VNTNNo, string VSSTNo, string VGSTNo, string VStatus, string VSoftCatagory,
         string VSStartDate, string VSBillDate, string VBillType, string VMaintenanceType, string VSeq, string VAmount)
        {
            string tf = "";
            try
            {
                OracleCommand DbCommand = new OracleCommand("Clients_Add_Edit1", clsConnection.con);
                DbCommand.CommandType = CommandType.StoredProcedure;
                DbCommand.Parameters.Add("VClientID", OracleDbType.Varchar2).Value = VClientID;
                DbCommand.Parameters.Add("VAttribute", OracleDbType.Varchar2).Value = VAttribute;
                DbCommand.Parameters.Add("VClientTitle", OracleDbType.Varchar2).Value = VClientTitle;
                DbCommand.Parameters.Add("VContactPerson", OracleDbType.Varchar2).Value = VContactPerson;
                DbCommand.Parameters.Add("VBusinessNature", OracleDbType.Varchar2).Value = VBusinessNature;
                DbCommand.Parameters.Add("VAddress", OracleDbType.Varchar2).Value = VAddress;
                DbCommand.Parameters.Add("VCellNo", OracleDbType.Varchar2).Value = VCellNo;
                DbCommand.Parameters.Add("VContactNo", OracleDbType.Varchar2).Value = VContactNo;
                DbCommand.Parameters.Add("VEmailAddress", OracleDbType.Varchar2).Value = VEmailAddress;
                DbCommand.Parameters.Add("VSoftware", OracleDbType.Varchar2).Value = VSoftware;
                DbCommand.Parameters.Add("VCatagory", OracleDbType.Varchar2).Value = VCatagory;
                DbCommand.Parameters.Add("VCity", OracleDbType.Varchar2).Value = VCity;
                DbCommand.Parameters.Add("VCountry", OracleDbType.Varchar2).Value = VCountry;
                DbCommand.Parameters.Add("VNTNNo", OracleDbType.Varchar2).Value = VNTNNo;
                DbCommand.Parameters.Add("VSSTNo", OracleDbType.Varchar2).Value = VSSTNo;
                DbCommand.Parameters.Add("VGSTNo", OracleDbType.Varchar2).Value = VGSTNo;
                DbCommand.Parameters.Add("VStatus", OracleDbType.Varchar2).Value = VStatus;
                DbCommand.Parameters.Add("VSoftCatagory", OracleDbType.Varchar2).Value = VSoftCatagory;
                DbCommand.Parameters.Add("VSStartDate", OracleDbType.Varchar2).Value = VSStartDate;
                DbCommand.Parameters.Add("VSBillDate", OracleDbType.Varchar2).Value = VSBillDate;
                DbCommand.Parameters.Add("VBillType", OracleDbType.Varchar2).Value = VBillType;
                DbCommand.Parameters.Add("VMaintenanceType", OracleDbType.Varchar2).Value = VMaintenanceType;
                DbCommand.Parameters.Add("VSeq", OracleDbType.Varchar2).Value = VSeq;
                DbCommand.Parameters.Add("VAmount", OracleDbType.Varchar2).Value = VAmount;
                DbCommand.ExecuteNonQuery();

                tf = "True";
                DbCommand.Dispose();

                return tf;
            }
            catch (Exception ee)
            {
                Errors.writeline(ee.Message, "MSP_ Clients_Add_Edit");
                string result = MyMessageBox.ShowBox(ee.Message, Variable.Version, 1);
                return tf;
            }
        }

        public static string Clients_Add_Edit(string VClientID, string VAttribute, string VClientTitle, string VContactPerson, string VBusinessNature,
         string VAddress, string VCellNo, string VContactNo, string VEmailAddress, string VCatagoryType, string VCity, string VCountry,
         string VNTNNo, string VSSTNo, string VGSTNo, string VStatus, List<string> VSoftwareID, List<string> VCatagory, List<string> VSStartDate, List<string> VSBillDate,
         List<string> VBillType, List<string> VMaintenanceType, List<string> VAmount)
        {
            string tf = "";
            try
            {
                OracleCommand DbCommand = new OracleCommand("pkg_clientdetail.clients_add_edit_new", clsConnection.con);
                DbCommand.CommandType = CommandType.StoredProcedure;
                DbCommand.Parameters.Add("VClientID", OracleDbType.Varchar2).Value = VClientID;
                DbCommand.Parameters.Add("VAttribute", OracleDbType.Varchar2).Value = VAttribute;
                DbCommand.Parameters.Add("VClientTitle", OracleDbType.Varchar2).Value = VClientTitle;
                DbCommand.Parameters.Add("VContactPerson", OracleDbType.Varchar2).Value = VContactPerson;
                DbCommand.Parameters.Add("VBusinessNature", OracleDbType.Varchar2).Value = VBusinessNature;
                DbCommand.Parameters.Add("VAddress", OracleDbType.Varchar2).Value = VAddress;
                DbCommand.Parameters.Add("VCellNo", OracleDbType.Varchar2).Value = VCellNo;
                DbCommand.Parameters.Add("VContactNo", OracleDbType.Varchar2).Value = VContactNo;
                DbCommand.Parameters.Add("VEmailAddress", OracleDbType.Varchar2).Value = VEmailAddress;
                DbCommand.Parameters.Add("VCatagoryType", OracleDbType.Varchar2).Value = VCatagoryType;
                DbCommand.Parameters.Add("VCity", OracleDbType.Varchar2).Value = VCity;
                DbCommand.Parameters.Add("VCountry", OracleDbType.Varchar2).Value = VCountry;
                DbCommand.Parameters.Add("VNTNNo", OracleDbType.Varchar2).Value = VNTNNo;
                DbCommand.Parameters.Add("VSSTNo", OracleDbType.Varchar2).Value = VSSTNo;
                DbCommand.Parameters.Add("VGSTNo", OracleDbType.Varchar2).Value = VGSTNo;
                DbCommand.Parameters.Add("VStatus", OracleDbType.Varchar2).Value = VStatus;

                DbCommand.Parameters.Add("VSoftwareID", OracleDbType.Varchar2, VSoftwareID.Count()).Value = VSoftwareID.ToArray();
                DbCommand.Parameters["VSoftwareID"].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                DbCommand.Parameters["VSoftwareID"].ArrayBindSize = VSoftwareID.Select(_ => !string.IsNullOrEmpty(_) ? _.Length : 0).ToArray();

                DbCommand.Parameters.Add("VCatagory", OracleDbType.Varchar2, VCatagory.Count()).Value = VCatagory.ToArray();
                DbCommand.Parameters["VCatagory"].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                DbCommand.Parameters["VCatagory"].ArrayBindSize = VCatagory.Select(_ => !string.IsNullOrEmpty(_) ? _.Length : 0).ToArray();

                DbCommand.Parameters.Add("VSStartDate", OracleDbType.Varchar2, VSStartDate.Count()).Value = VSStartDate.ToArray();
                DbCommand.Parameters["VSStartDate"].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                DbCommand.Parameters["VSStartDate"].ArrayBindSize = VSStartDate.Select(_ => !string.IsNullOrEmpty(_) ? _.Length : 0).ToArray();

                DbCommand.Parameters.Add("VSBillDate", OracleDbType.Varchar2, VSBillDate.Count()).Value = VSBillDate.ToArray();
                DbCommand.Parameters["VSBillDate"].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                DbCommand.Parameters["VSBillDate"].ArrayBindSize = VSBillDate.Select(_ => !string.IsNullOrEmpty(_) ? _.Length : 0).ToArray();

                DbCommand.Parameters.Add("VBillType", OracleDbType.Varchar2, VBillType.Count()).Value = VBillType.ToArray();
                DbCommand.Parameters["VBillType"].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                DbCommand.Parameters["VBillType"].ArrayBindSize = VBillType.Select(_ => !string.IsNullOrEmpty(_) ? _.Length : 0).ToArray();

                DbCommand.Parameters.Add("VMaintenanceType", OracleDbType.Varchar2, VMaintenanceType.Count()).Value = VMaintenanceType.ToArray();
                DbCommand.Parameters["VMaintenanceType"].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                DbCommand.Parameters["VMaintenanceType"].ArrayBindSize = VMaintenanceType.Select(_ => !string.IsNullOrEmpty(_) ? _.Length : 0).ToArray();

                DbCommand.Parameters.Add("VAmount", OracleDbType.Varchar2, VAmount.Count()).Value = VAmount.ToArray();
                DbCommand.Parameters["VAmount"].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                DbCommand.Parameters["VAmount"].ArrayBindSize = VAmount.Select(_ => !string.IsNullOrEmpty(_) ? _.Length : 0).ToArray();
                DbCommand.ExecuteNonQuery();

                tf = "True";
                DbCommand.Dispose();

                return tf;
            }
            catch (Exception ee)
            {
                Errors.writeline(ee.Message, "MSP_ Clients_Add_Edit");
                string result = MyMessageBox.ShowBox(ee.Message, Variable.Version, 1);
                return tf;
            }
        }

        public static string Software_Add_Edit(string VSoftwareID, string VDescription, string VSoftwareName, string VCatagory, string VCreatedBy, string VEditBy, string VApprovedBy)
        {
            string tf = "";
            try
            {
                OracleCommand DbCommand = new OracleCommand("Software_Add_Edit", clsConnection.con);
                DbCommand.CommandType = CommandType.StoredProcedure;
                DbCommand.Parameters.Add("VSoftwareID", OracleDbType.Varchar2).Value = VSoftwareID;
                DbCommand.Parameters.Add("VDescription", OracleDbType.Varchar2).Value = VDescription;
                DbCommand.Parameters.Add("VSoftwareName", OracleDbType.Varchar2).Value = VSoftwareName;
                DbCommand.Parameters.Add("VCatagory", OracleDbType.Varchar2).Value = VCatagory;
                DbCommand.Parameters.Add("VCreatedBy", OracleDbType.Varchar2).Value = VCreatedBy;
                DbCommand.Parameters.Add("VEditBy", OracleDbType.Varchar2).Value = VEditBy;
                DbCommand.Parameters.Add("VApprovedBy", OracleDbType.Varchar2).Value = VApprovedBy;
                DbCommand.Parameters.Add("ReturnValue", OracleDbType.Varchar2, 20).Direction = ParameterDirection.Output;
                DbCommand.ExecuteNonQuery();
                tf = DbCommand.Parameters["ReturnValue"].Value.ToString();
                DbCommand.Dispose();
                return tf;
            }
            catch (Exception ee)
            {
                Errors.writeline(ee.Message, "MSP_ Software_Add_Edit");
                string result = MyMessageBox.ShowBox(ee.Message, Variable.Version, 1);
                return tf;
            }
        }

        public static string Change_GL_status(string VVno, string VVtype, string Vstatus, string Vremarks)
        {
            string tf = "";
            try
            {
                OracleCommand DbCommand = new OracleCommand("Change_GL_status", clsConnection.con);
                DbCommand.CommandType = CommandType.StoredProcedure;
                DbCommand.Parameters.Add("VVno", OracleDbType.Varchar2, 10).Value = VVno;
                DbCommand.Parameters.Add("VVtype", OracleDbType.Varchar2, 10).Value = VVtype;
                DbCommand.Parameters.Add("VStatus", OracleDbType.Varchar2, 1).Value = Vstatus;
                DbCommand.Parameters.Add("Vremarks", OracleDbType.Varchar2, 250).Value = Vremarks;
                DbCommand.Parameters.Add("VUser", OracleDbType.Varchar2, 200).Value = Variable.UserId;
                DbCommand.Parameters.Add("VTerminalID", OracleDbType.Varchar2, 200).Value = Variable.TerminalId;
                DbCommand.Parameters.Add("ReturnValue", OracleDbType.Varchar2, 20);
                DbCommand.Parameters["ReturnValue"].Direction = ParameterDirection.Output;
                DbCommand.ExecuteNonQuery();
                tf = DbCommand.Parameters["ReturnValue"].Value.ToString();
                DbCommand.Dispose();
                return tf;
            }
            catch (Exception ee)
            {
                Errors.writeline(ee.Message, "MSP_ Change_GL_status");
                string result = MyMessageBox.ShowBox(ee.Message, Variable.Version, 1);
                return tf;
            }
        }
        public static string Voucher_post(string vouchertype, string Vno, DateTime Vdate, string VNarration, string User, string branchCode,
            List<int> Seq, List<string> Account, List<string> Descr, List<decimal> dr, List<decimal> cr, List<string> SubAccount, List<int> Status)
        {
            string ReturnValue = "";
            try
            {
                OracleCommand DbCommand = new OracleCommand("pkg_VoucherPost.Voucherpost", clsConnection.con);
                DbCommand.CommandType = CommandType.StoredProcedure;

                DbCommand.Parameters.Add("Vvtype", OracleDbType.Varchar2).Value = vouchertype;
                DbCommand.Parameters.Add("VVno", OracleDbType.Varchar2).Value = Vno;
                DbCommand.Parameters.Add("VVdate", OracleDbType.Date).Value = Vdate;
                DbCommand.Parameters.Add("VNarration", OracleDbType.Varchar2).Value = VNarration;
                DbCommand.Parameters.Add("VUser", OracleDbType.Varchar2).Value = User;
                DbCommand.Parameters.Add("VTerminalID", OracleDbType.Varchar2).Value = Variable.TerminalId;
                DbCommand.Parameters.Add("Vfkbrcode", OracleDbType.Varchar2).Value = branchCode;


                DbCommand.Parameters.Add("Seq", OracleDbType.Int16, Seq.Count()).Value = Seq.ToArray();
                DbCommand.Parameters["Seq"].CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                DbCommand.Parameters.Add("Account", OracleDbType.Varchar2, Account.Count()).Value = Account.ToArray();
                DbCommand.Parameters["Account"].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                DbCommand.Parameters["Account"].ArrayBindSize = Account.Select(_ => _.Length).ToArray();

                DbCommand.Parameters.Add("Descr", OracleDbType.Varchar2, Descr.Count()).Value = Descr.ToArray();
                DbCommand.Parameters["Descr"].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                DbCommand.Parameters["Descr"].ArrayBindSize = Descr.Select(_ => !string.IsNullOrEmpty(_) ? _.Length : 0).ToArray();

                DbCommand.Parameters.Add("dr", OracleDbType.Decimal, dr.Count()).Value = dr.ToArray();
                DbCommand.Parameters["dr"].CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                DbCommand.Parameters.Add("cr", OracleDbType.Decimal, cr.Count()).Value = cr.ToArray();
                DbCommand.Parameters["cr"].CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                DbCommand.Parameters.Add("SubAccount", OracleDbType.Varchar2, SubAccount.Count()).Value = SubAccount.ToArray();
                DbCommand.Parameters["SubAccount"].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                DbCommand.Parameters["SubAccount"].ArrayBindSize = SubAccount.Select(_ => !string.IsNullOrEmpty(_) ? _.Length : 0).ToArray();

                DbCommand.Parameters.Add("Status", OracleDbType.Int16, Status.Count()).Value = Status.ToArray();
                DbCommand.Parameters["Status"].CollectionType = OracleCollectionType.PLSQLAssociativeArray;


                DbCommand.Parameters.Add("RefVno", OracleDbType.Varchar2, 100).Direction = ParameterDirection.Output;

                DbCommand.ExecuteNonQuery();
                ReturnValue = DbCommand.Parameters["RefVno"].Value.ToString();

                DbCommand.Dispose();
                return ReturnValue;
            }
            catch (Exception ee)
            {
                MyMessageBox.ShowBox(ee.Message);
                //// Errors.writeline(ee.Message, "MSP_GenerateKey");
                //string result = MessageBox.Show(ee.Message, Variable.Version, 1);
                return "";
            }
        }
        public static string Voucher_post1(string vouchertype, string Vno, DateTime Vdate, string VNarration, string User, string branchCode, string fkbankid,
            List<int> Seq, List<string> Account, List<string> Descr, List<decimal> dr, List<decimal> cr, List<string> SubAccount, List<int> Status, List<string> ChequeNo, List<string> SlipNo, string VDocumentChanged, string Vfkdocumentid, byte[] VDocuments, string beneficiary)
        {
            string ReturnValue = "";
            try
            {
                OracleCommand DbCommand = new OracleCommand("pkg_VoucherPost2.Voucherpost", clsConnection.con);
                DbCommand.CommandType = CommandType.StoredProcedure;

                DbCommand.Parameters.Add("Vvtype", OracleDbType.Varchar2).Value = vouchertype;
                DbCommand.Parameters.Add("VVno", OracleDbType.Varchar2).Value = Vno;
                DbCommand.Parameters.Add("VVdate", OracleDbType.Date).Value = Vdate;
                DbCommand.Parameters.Add("VNarration", OracleDbType.Varchar2).Value = VNarration;
                DbCommand.Parameters.Add("VUser", OracleDbType.Varchar2).Value = User;
                DbCommand.Parameters.Add("VTerminalID", OracleDbType.Varchar2).Value = SoftwareInfo.Terminal;
                DbCommand.Parameters.Add("Vfkbrcode", OracleDbType.Varchar2).Value = branchCode;
                DbCommand.Parameters.Add("fkbankid", OracleDbType.Varchar2).Value = fkbankid;

                DbCommand.Parameters.Add("Seq", OracleDbType.Int16, Seq.Count()).Value = Seq.ToArray();
                DbCommand.Parameters["Seq"].CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                DbCommand.Parameters.Add("Account", OracleDbType.Varchar2, Account.Count()).Value = Account.ToArray();
                DbCommand.Parameters["Account"].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                DbCommand.Parameters["Account"].ArrayBindSize = Account.Select(_ => _.Length).ToArray();

                DbCommand.Parameters.Add("Descr", OracleDbType.Varchar2, Descr.Count()).Value = Descr.ToArray();
                DbCommand.Parameters["Descr"].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                DbCommand.Parameters["Descr"].ArrayBindSize = Descr.Select(_ => !string.IsNullOrEmpty(_) ? _.Length : 0).ToArray();

                DbCommand.Parameters.Add("dr", OracleDbType.Decimal, dr.Count()).Value = dr.ToArray();
                DbCommand.Parameters["dr"].CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                DbCommand.Parameters.Add("cr", OracleDbType.Decimal, cr.Count()).Value = cr.ToArray();
                DbCommand.Parameters["cr"].CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                DbCommand.Parameters.Add("SubAccount", OracleDbType.Varchar2, SubAccount.Count()).Value = SubAccount.ToArray();
                DbCommand.Parameters["SubAccount"].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                DbCommand.Parameters["SubAccount"].ArrayBindSize = SubAccount.Select(_ => !string.IsNullOrEmpty(_) ? _.Length : 0).ToArray();

                DbCommand.Parameters.Add("Status", OracleDbType.Int16, Status.Count()).Value = Status.ToArray();
                DbCommand.Parameters["Status"].CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                DbCommand.Parameters.Add("ChequeNo", OracleDbType.Varchar2, ChequeNo.Count()).Value = ChequeNo.ToArray();
                DbCommand.Parameters["ChequeNo"].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                DbCommand.Parameters["ChequeNo"].ArrayBindSize = ChequeNo.Select(_ => !string.IsNullOrEmpty(_) ? _.Length : 0).ToArray();

                DbCommand.Parameters.Add("SlipNo", OracleDbType.Varchar2, SlipNo.Count()).Value = SlipNo.ToArray();
                DbCommand.Parameters["SlipNo"].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                DbCommand.Parameters["SlipNo"].ArrayBindSize = SlipNo.Select(_ => !string.IsNullOrEmpty(_) ? _.Length : 0).ToArray();

                DbCommand.Parameters.Add("VDocumentChanged", OracleDbType.Varchar2, 1).Value = VDocumentChanged;
                DbCommand.Parameters.Add("Vfkdocumentid", OracleDbType.Varchar2, 5).Value = Vfkdocumentid;
                DbCommand.Parameters.Add("VDocuments", OracleDbType.Blob).Value = VDocuments;
                DbCommand.Parameters.Add("Vbeneficiary", OracleDbType.Varchar2).Value = beneficiary;


                DbCommand.Parameters.Add("RefVno", OracleDbType.Varchar2, 100).Direction = ParameterDirection.Output;

                DbCommand.ExecuteNonQuery();
                ReturnValue = DbCommand.Parameters["RefVno"].Value.ToString();

                DbCommand.Dispose();
                return ReturnValue;
            }
            catch (Exception ee)
            {
                MyMessageBox.ShowBox(ee.Message);
                //// Errors.writeline(ee.Message, "MSP_GenerateKey");
                //string result = MessageBox.Show(ee.Message, Variable.Version, 1);
                return "";
            }
        }
        public static string Voucher_post2(string vouchertype, string Vno, string sessionid,DateTime Vdate, string VNarration, string User, string branchCode, string fkbankid,
           List<int> Seq, List<string> Account, List<string> Descr, List<decimal> dr, List<decimal> cr, List<string> SubAccount, List<int> Status, List<string> ChequeNo, List<string> SlipNo, string VDocumentChanged, string Vfkdocumentid, byte[] VDocuments, string beneficiary)
        {
            string ReturnValue = "";
            try
            {
                OracleCommand DbCommand = new OracleCommand("pkg_VoucherPost2.Voucherpost1", clsConnection.con);
                DbCommand.CommandType = CommandType.StoredProcedure;

                DbCommand.Parameters.Add("Vvtype", OracleDbType.Varchar2).Value = vouchertype;
                DbCommand.Parameters.Add("VVno", OracleDbType.Varchar2).Value = Vno;
                DbCommand.Parameters.Add("VSessionid", OracleDbType.Varchar2).Value = sessionid;
                DbCommand.Parameters.Add("VVdate", OracleDbType.Date).Value = Vdate;
                DbCommand.Parameters.Add("VNarration", OracleDbType.Varchar2).Value = VNarration;
                DbCommand.Parameters.Add("VUser", OracleDbType.Varchar2).Value = User;
                DbCommand.Parameters.Add("VTerminalID", OracleDbType.Varchar2).Value = SoftwareInfo.Terminal;
                DbCommand.Parameters.Add("Vfkbrcode", OracleDbType.Varchar2).Value = branchCode;
                DbCommand.Parameters.Add("fkbankid", OracleDbType.Varchar2).Value = fkbankid;

                DbCommand.Parameters.Add("Seq", OracleDbType.Int16, Seq.Count()).Value = Seq.ToArray();
                DbCommand.Parameters["Seq"].CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                DbCommand.Parameters.Add("Account", OracleDbType.Varchar2, Account.Count()).Value = Account.ToArray();
                DbCommand.Parameters["Account"].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                DbCommand.Parameters["Account"].ArrayBindSize = Account.Select(_ => _.Length).ToArray();

                DbCommand.Parameters.Add("Descr", OracleDbType.Varchar2, Descr.Count()).Value = Descr.ToArray();
                DbCommand.Parameters["Descr"].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                DbCommand.Parameters["Descr"].ArrayBindSize = Descr.Select(_ => !string.IsNullOrEmpty(_) ? _.Length : 0).ToArray();

                DbCommand.Parameters.Add("dr", OracleDbType.Decimal, dr.Count()).Value = dr.ToArray();
                DbCommand.Parameters["dr"].CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                DbCommand.Parameters.Add("cr", OracleDbType.Decimal, cr.Count()).Value = cr.ToArray();
                DbCommand.Parameters["cr"].CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                DbCommand.Parameters.Add("SubAccount", OracleDbType.Varchar2, SubAccount.Count()).Value = SubAccount.ToArray();
                DbCommand.Parameters["SubAccount"].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                DbCommand.Parameters["SubAccount"].ArrayBindSize = SubAccount.Select(_ => !string.IsNullOrEmpty(_) ? _.Length : 0).ToArray();

                DbCommand.Parameters.Add("Status", OracleDbType.Int16, Status.Count()).Value = Status.ToArray();
                DbCommand.Parameters["Status"].CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                DbCommand.Parameters.Add("ChequeNo", OracleDbType.Varchar2, ChequeNo.Count()).Value = ChequeNo.ToArray();
                DbCommand.Parameters["ChequeNo"].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                DbCommand.Parameters["ChequeNo"].ArrayBindSize = ChequeNo.Select(_ => !string.IsNullOrEmpty(_) ? _.Length : 0).ToArray();

                DbCommand.Parameters.Add("SlipNo", OracleDbType.Varchar2, SlipNo.Count()).Value = SlipNo.ToArray();
                DbCommand.Parameters["SlipNo"].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                DbCommand.Parameters["SlipNo"].ArrayBindSize = SlipNo.Select(_ => !string.IsNullOrEmpty(_) ? _.Length : 0).ToArray();

                DbCommand.Parameters.Add("VDocumentChanged", OracleDbType.Varchar2, 1).Value = VDocumentChanged;
                DbCommand.Parameters.Add("Vfkdocumentid", OracleDbType.Varchar2, 5).Value = Vfkdocumentid;
                DbCommand.Parameters.Add("VDocuments", OracleDbType.Blob).Value = VDocuments;
                DbCommand.Parameters.Add("Vbeneficiary", OracleDbType.Varchar2).Value = beneficiary;


                DbCommand.Parameters.Add("RefVno", OracleDbType.Varchar2, 100).Direction = ParameterDirection.Output;

                DbCommand.ExecuteNonQuery();
                ReturnValue = DbCommand.Parameters["RefVno"].Value.ToString();

                DbCommand.Dispose();
                return ReturnValue;
            }
            catch (Exception ee)
            {
                MyMessageBox.ShowBox(ee.Message);
                //// Errors.writeline(ee.Message, "MSP_GenerateKey");
                //string result = MessageBox.Show(ee.Message, Variable.Version, 1);
                return "";
            }
        }

        public static string BankReconcile_Add_Edit1(string VbankId, string VVtype, string VVno, string VClearentry, string Vreconciledate, string VChequeNo, string VDr, string VCr)
        {
            string tf = "";
            try
            {

                OracleCommand DbCommand = new OracleCommand("bankReconcile_add_edit1", clsConnection.con);
                DbCommand.CommandType = CommandType.StoredProcedure;
                DbCommand.Parameters.Add("VBankId", OracleDbType.Varchar2, 10).Value = VbankId;
                DbCommand.Parameters.Add("VVtype", OracleDbType.Varchar2, 5).Value = VVtype;
                DbCommand.Parameters.Add("VVno", OracleDbType.Varchar2, 10).Value = VVno;
                DbCommand.Parameters.Add("VClearentry", OracleDbType.Varchar2, 1).Value = VClearentry;
                DbCommand.Parameters.Add("Vreconciledate", OracleDbType.Varchar2, 11).Value = Vreconciledate;
                DbCommand.Parameters.Add("VChequeNo", OracleDbType.Varchar2).Value = VChequeNo;
                DbCommand.Parameters.Add("VDr", OracleDbType.Varchar2).Value = VDr;
                DbCommand.Parameters.Add("VCr", OracleDbType.Varchar2).Value = VCr;
                DbCommand.Parameters.Add("VUser", OracleDbType.Varchar2, 50).Value = Variable.UserId;
                DbCommand.Parameters.Add("VTerminalID", OracleDbType.Varchar2, 100).Value = Variable.TerminalId;
                DbCommand.Parameters.Add("ReturnValue", OracleDbType.Varchar2, 20);
                DbCommand.Parameters["ReturnValue"].Direction = ParameterDirection.Output;
                DbCommand.ExecuteNonQuery();

                tf = DbCommand.Parameters["ReturnValue"].Value.ToString();
                DbCommand.Dispose();

                return tf;

            }
            catch (Exception ee)
            {
                Errors.writeline(ee.Message, "MSP_ BankReconcile_Add_Edit");
                string result = MyMessageBox.ShowBox(ee.Message, Variable.Version, 1);
                return tf;
            }

        }
        public static bool ChartOfAccAdd_Edit(string account, string title, string Withheld, string parentid, string AccType, string AccLevel, string Per, string VSegregation, string VNetCapital, string VLiquidCapital)
        {
            bool Saved = false;

            OracleCommand com = new OracleCommand("ChartOfAccAdd_Edit4", clsConnection.con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add("Vaccount", OracleDbType.Varchar2).Value = account;
            com.Parameters.Add("Vtitle", OracleDbType.Varchar2).Value = title;
            com.Parameters.Add("Vwithheld", OracleDbType.Varchar2).Value = Withheld;
            com.Parameters.Add("Vparentid", OracleDbType.Varchar2).Value = parentid;
            com.Parameters.Add("VAccType", OracleDbType.Varchar2).Value = AccType;
            com.Parameters.Add("VAccLevel", OracleDbType.Varchar2).Value = AccLevel;
            com.Parameters.Add("VPer", OracleDbType.Varchar2).Value = Per;
            com.Parameters.Add("VSegregation", OracleDbType.Varchar2).Value = VSegregation;
            com.Parameters.Add("VNetCapital", OracleDbType.Varchar2).Value = VNetCapital;
            com.Parameters.Add("VLiquidCapital", OracleDbType.Varchar2).Value = VLiquidCapital;
            com.Parameters.Add("Vuser", OracleDbType.Varchar2).Value = Variable.UserId;
            com.Parameters.Add("VTerminalID", OracleDbType.Varchar2).Value = Variable.TerminalId;
            com.ExecuteNonQuery();
            Saved = true;

            return Saved;
        }
        public static string Bank_add_edit1(string Vbankcode, string Vbankname, string Vbranchname, string Vbranchcode, string Vfkcitycode,
            string Vfkcountrycode, string Vcurrency, string VAccountType, string Viban, string VisoCountrycode, string Vibancheckdigits, string Vbban, string Vbankidentifier,
            string Vsepamember, string Vstatus, string VSdebit, string VSCredit)
        {
            string tf = "";
            try
            {

                OracleCommand DbCommand = new OracleCommand("bank_add_edit2", clsConnection.con);
                DbCommand.CommandType = CommandType.StoredProcedure;
                DbCommand.Parameters.Add("Vbankcode", OracleDbType.Varchar2, 3).Value = Vbankcode;
                DbCommand.Parameters.Add("Vbankname", OracleDbType.Varchar2, 100).Value = Vbankname;
                DbCommand.Parameters.Add("Vbranchname", OracleDbType.Varchar2, 100).Value = Vbranchname;
                DbCommand.Parameters.Add("Vbranchcode", OracleDbType.Varchar2, 10).Value = Vbranchcode;
                DbCommand.Parameters.Add("Vfkcitycode", OracleDbType.Varchar2, 100).Value = Vfkcitycode;
                DbCommand.Parameters.Add("Vfkcountrycode", OracleDbType.Varchar2, 100).Value = Vfkcountrycode;
                DbCommand.Parameters.Add("Vcurrency", OracleDbType.Varchar2, 100).Value = Vcurrency;
                DbCommand.Parameters.Add("VAccountType", OracleDbType.Varchar2, 60).Value = VAccountType;

                DbCommand.Parameters.Add("Viban", OracleDbType.Varchar2, 100).Value = Viban;
                DbCommand.Parameters.Add("VisoCountrycode", OracleDbType.Varchar2, 3).Value = VisoCountrycode;
                DbCommand.Parameters.Add("Vibancheckdigits", OracleDbType.Varchar2, 100).Value = Vibancheckdigits;
                DbCommand.Parameters.Add("Vbban", OracleDbType.Varchar2, 100).Value = Vbban;
                DbCommand.Parameters.Add("Vbankidentifier", OracleDbType.Varchar2, 100).Value = Vbankidentifier;

                DbCommand.Parameters.Add("Vsepamember", OracleDbType.Varchar2, 100).Value = Vsepamember;
                DbCommand.Parameters.Add("Vstatus", OracleDbType.Varchar2, 1).Value = Vstatus;
                DbCommand.Parameters.Add("VUser", OracleDbType.Varchar2, 50).Value = Variable.User;
                DbCommand.Parameters.Add("VTerminalID", OracleDbType.Varchar2, 100).Value = Variable.TerminalId;
               
                DbCommand.Parameters.Add("VSdebit", OracleDbType.Varchar2, 100).Value = VSdebit;
                DbCommand.Parameters.Add("VScredit", OracleDbType.Varchar2, 100).Value = VSCredit;
                
                DbCommand.Parameters.Add("ReturnValue", OracleDbType.Varchar2, 20);
                DbCommand.Parameters["ReturnValue"].Direction = ParameterDirection.Output;
                DbCommand.ExecuteNonQuery();

                tf = DbCommand.Parameters["ReturnValue"].Value.ToString();
                DbCommand.Dispose();

                return tf;

            }
            catch (Exception ee)
            {
                Errors.writeline(ee.Message, "MSP_City_add_edit");
                string result = MyMessageBox.ShowBox(ee.Message, Variable.Version, 1);
                return tf;
            }
        }
        public static string BankFacilities_add_edit(string Vfkbankcode, string Vnatureoffacilities, string Vcur, string Vlimitamount_millions,
           string Vcommission, string Vreview_date, string Vpurposeoffinancing, string Vstatus, string Vseq)
        {
            string tf = "";
            try
            {

                OracleCommand DbCommand = new OracleCommand("bankfacilities_add_edit1", clsConnection.con);
                DbCommand.CommandType = CommandType.StoredProcedure;
                DbCommand.Parameters.Add("Vfkbankcode", OracleDbType.Varchar2, 3).Value = Vfkbankcode;
                DbCommand.Parameters.Add("Vnatureoffacilities", OracleDbType.Varchar2, 100).Value = Vnatureoffacilities;
                DbCommand.Parameters.Add("Vcur", OracleDbType.Varchar2, 30).Value = Vcur;
                DbCommand.Parameters.Add("Vlimitamount_millions", OracleDbType.Varchar2, 20).Value = Vlimitamount_millions;
                DbCommand.Parameters.Add("Vcommission", OracleDbType.Varchar2, 20).Value = Vcommission;
                DbCommand.Parameters.Add("Vreview_date", OracleDbType.Date).Value = Vreview_date;
                DbCommand.Parameters.Add("Vpurposeoffinancing", OracleDbType.Varchar2, 200).Value = Vpurposeoffinancing;
                DbCommand.Parameters.Add("Vseq", OracleDbType.Varchar2, 3).Value = Vseq;
                DbCommand.Parameters.Add("Vstatus", OracleDbType.Varchar2, 1).Value = Vstatus;
                DbCommand.Parameters.Add("VUser", OracleDbType.Varchar2, 50).Value = Variable.User;
                DbCommand.Parameters.Add("VTerminalID", OracleDbType.Varchar2, 100).Value = Variable.TerminalId;

                DbCommand.Parameters.Add("ReturnValue", OracleDbType.Varchar2, 20);
                DbCommand.Parameters["ReturnValue"].Direction = ParameterDirection.Output;
                DbCommand.ExecuteNonQuery();

                tf = DbCommand.Parameters["ReturnValue"].Value.ToString();
                DbCommand.Dispose();

                return tf;

            }
            catch (Exception ee)
            {
                Errors.writeline(ee.Message, "MSP_City_add_edit");
                string result = MyMessageBox.ShowBox(ee.Message, Variable.Version, 1);
                return tf;
            }
        }
        public static string BankMargin_add_edit(string vfkbankcode, string vfksymbolcode, string Vmargin, string Vcharges, string Vstatus, string Vseq)
        {
            string tf = "";
            try
            {

                OracleCommand DbCommand = new OracleCommand("bankmargin_add_edit", clsConnection.con);
                DbCommand.CommandType = CommandType.StoredProcedure;
                DbCommand.Parameters.Add("vfkbankcode", OracleDbType.Varchar2, 3).Value = vfkbankcode;
                DbCommand.Parameters.Add("vfksymbolcode", OracleDbType.Varchar2, 100).Value = vfksymbolcode;
                DbCommand.Parameters.Add("Vmargin", OracleDbType.Varchar2, 100).Value = Vmargin;
                DbCommand.Parameters.Add("Vcharges", OracleDbType.Varchar2, 100).Value = Vcharges;
                DbCommand.Parameters.Add("Vseq", OracleDbType.Varchar2, 3).Value = Vseq;
                DbCommand.Parameters.Add("Vstatus", OracleDbType.Varchar2, 1).Value = Vstatus;
                DbCommand.Parameters.Add("VUser", OracleDbType.Varchar2, 50).Value = Variable.User;
                DbCommand.Parameters.Add("VTerminalID", OracleDbType.Varchar2, 100).Value = Variable.TerminalId;
                DbCommand.Parameters.Add("ReturnValue", OracleDbType.Varchar2, 20);
                DbCommand.Parameters["ReturnValue"].Direction = ParameterDirection.Output;
                DbCommand.ExecuteNonQuery();

                tf = DbCommand.Parameters["ReturnValue"].Value.ToString();
                DbCommand.Dispose();

                return tf;

            }
            catch (Exception ee)
            {
                Errors.writeline(ee.Message, "MSP_City_add_edit");
                string result = MyMessageBox.ShowBox(ee.Message, Variable.Version, 1);
                return tf;
            }
        }
        public static string Narration_Add_Edit(string Vnarrationcode, string Vnarrationtitle, string Vstatus)
        {
            string tf = "";
            try
            {

                OracleCommand DbCommand = new OracleCommand("Narrration_add_edit", clsConnection.con);
                DbCommand.CommandType = CommandType.StoredProcedure;
                DbCommand.Parameters.Add("Vnarrationcode", OracleDbType.Varchar2, 10).Value = Vnarrationcode;
                DbCommand.Parameters.Add("Vnarrationtitle", OracleDbType.Varchar2, 100).Value = Vnarrationtitle;
                DbCommand.Parameters.Add("Vstatus", OracleDbType.Varchar2, 1).Value = Vstatus;
                DbCommand.Parameters.Add("VUser", OracleDbType.Varchar2, 50).Value = Variable.User;
                DbCommand.Parameters.Add("VTerminalID", OracleDbType.Varchar2, 100).Value = Variable.TerminalId;
                DbCommand.Parameters.Add("ReturnValue", OracleDbType.Varchar2, 20);
                DbCommand.Parameters["ReturnValue"].Direction = ParameterDirection.Output;
                DbCommand.ExecuteNonQuery();

                tf = DbCommand.Parameters["ReturnValue"].Value.ToString();
                DbCommand.Dispose();

                return tf;

            }
            catch (Exception ee)
            {
                Errors.writeline(ee.Message, "MSP_Department_Add_Edit");
                string result = MyMessageBox.ShowBox(ee.Message, Variable.Version, 1);
                return tf;
            }
        }
    }
}
