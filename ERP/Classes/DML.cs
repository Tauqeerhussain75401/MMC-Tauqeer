using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using Oracle.DataAccess.Client;

namespace ERP
{
    class DML
    {


        public static bool Load_SoftwareFile(byte[] File, string Version)
        {
            bool Saved = false;

            OracleCommand com = new OracleCommand("insert into softwareupdates values(sysdate,:VVersion,:VFile,'')", clsConnection.con);
            com.CommandType = CommandType.Text;
            com.Parameters.Add("VVersion", OracleDbType.Varchar2, 50).Value = Version;
            com.Parameters.Add("VFile", OracleDbType.Blob).Value = File;
            com.ExecuteNonQuery();
            Saved = true;

            return Saved;
        }
        public static bool Change_Password(string UserId, string Password)
        {
            bool Saved = false;

            OracleCommand com = new OracleCommand("update users set password = :VPassword where userid = '" + UserInfo.UserId + "'", clsConnection.con);
            com.CommandType = CommandType.Text;
            com.Parameters.Add("VPassword", OracleDbType.Varchar2).Value = Password;
            com.ExecuteNonQuery();
            Saved = true;

            return Saved;
        }
        public static bool ChartOfAccAdd_Edit(string account, string title, string parentid, string AccType, string AccLevel)
        {
            bool Saved = false;

            OracleCommand com = new OracleCommand("ChartOfAccAdd_Edit", clsConnection.con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add("@account", OracleDbType.Varchar2).Value = account;
            com.Parameters.Add("@title", OracleDbType.NVarchar2).Value = title;
            com.Parameters.Add("@parentid", OracleDbType.Varchar2).Value = parentid;
            com.Parameters.Add("@AccType", OracleDbType.Varchar2).Value = AccType;
            com.Parameters.Add("@AccLevel", OracleDbType.Varchar2).Value = AccLevel;
            com.Parameters.Add("@user", OracleDbType.Varchar2).Value = UserInfo.UserId;
            com.Parameters.Add("@VTerminalID", OracleDbType.Varchar2).Value = SoftwareInfo.Terminal;
            com.ExecuteNonQuery();
            Saved = true;

            return Saved;
        }
        public static bool OpenningBal_Add_Edit(string Account, string DrAmount, string CrAmount)
        {
            bool Saved = false;
            OracleCommand com = new OracleCommand("OpenningBal_Add_Edit", clsConnection.con);
            //com = new OracleCommand("Sale_AddEdit", clsConnection.con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add("@Account", OracleDbType.Varchar2).Value = Account;
            com.Parameters.Add("@DrAmount", OracleDbType.Varchar2).Value = Validation.NullToDBNull(DrAmount);
            com.Parameters.Add("@CrAmount", OracleDbType.Varchar2).Value = Validation.NullToDBNull(CrAmount);
            com.Parameters.Add("@user", OracleDbType.Varchar2).Value = UserInfo.UserId;
            com.ExecuteNonQuery();

            Saved = true;
            return Saved;
        }

        public static bool NarrationAdd_Edit(string Code, string title, string Status)
        {
            bool Saved = false;

            string name = title.Substring(0, 3);
            string chec = name + "-" + Code;
            OracleCommand com = new OracleCommand("narrration_add_edit", clsConnection.con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add("@Vnarrationcode", OracleDbType.Varchar2).Value = chec;
            com.Parameters.Add("@Vnarrationtitle", OracleDbType.Varchar2).Value = title;
            com.Parameters.Add("@Vstatus", OracleDbType.Varchar2).Value = Status;
            //com.Parameters.Add("@ReturnValue", OracleDbType.Varchar2, 50).Direction = System.Data.ParameterDirection.Output;
            com.ExecuteNonQuery();
            Saved = true;

            return Saved;
        }

        public static bool NarrationAdd_delete(string Code, string title, string Status)
        {
            bool Saved = false;

            OracleCommand com = new OracleCommand("narrration_delete", clsConnection.con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add("@Vnarrationcode", OracleDbType.Varchar2).Value = Code;
            com.Parameters.Add("@Vnarrationtitle", OracleDbType.Varchar2).Value = title;
            com.Parameters.Add("@Vstatus", OracleDbType.Varchar2).Value = Status;
            com.ExecuteNonQuery();
            Saved = true;

            return Saved;
        }

        public static bool MemberInfo_Add_Edit(string Vid, string Vnewno, string Vnewno1, string Vbtmwcoldno, string Voldno, string Vmembershipnumber, string Vtitle, string Vname, string Vfather, string Vgrandfather,
                   string Vhusband, string Vcaste, string Vmaritalstatus, string Vdob, string Vqualification, string Vwork, string Vcontact, string Vcnic, string Vaddress, string Vvoternumber, string Visdeactivate,
                   string Vmobilenumberforsms, string Vstatus, String Vpaidbyzakat, string ReferenceId,int memberValidity,DateTime? validityDate)
        {
            bool Saved = false;

            OracleCommand com = new OracleCommand("MemberInfo_Add_Edit", clsConnection.con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add("Vid", OracleDbType.Varchar2).Value = Vid;
            com.Parameters.Add("Vnewno", OracleDbType.Varchar2).Value = Vnewno;
            com.Parameters.Add("Vnewno1", OracleDbType.Varchar2).Value = Vnewno1;
            com.Parameters.Add("Vbtmwcoldno", OracleDbType.Varchar2).Value = Vbtmwcoldno;
            com.Parameters.Add("Voldno", OracleDbType.Varchar2).Value = Voldno;
            com.Parameters.Add("Vmembershipnumber", OracleDbType.Varchar2).Value = Vmembershipnumber;
            com.Parameters.Add("Vtitle", OracleDbType.Varchar2).Value = Vtitle;
            com.Parameters.Add("Vname", OracleDbType.Varchar2).Value = Vname;
            com.Parameters.Add("Vfather", OracleDbType.Varchar2).Value = Vfather;
            com.Parameters.Add("Vgrandfather", OracleDbType.Varchar2).Value = Vgrandfather;
            com.Parameters.Add("Vhusband", OracleDbType.Varchar2).Value = Vhusband;
            com.Parameters.Add("Vcaste", OracleDbType.Varchar2).Value = Vcaste;
            com.Parameters.Add("Vmaritalstatus", OracleDbType.Varchar2).Value = Vmaritalstatus;
            com.Parameters.Add("Vdob", OracleDbType.Varchar2).Value = Vdob;

            com.Parameters.Add("Vqualification", OracleDbType.Varchar2).Value = Vqualification;
            com.Parameters.Add("Vwork", OracleDbType.Varchar2).Value = Vwork;
            com.Parameters.Add("Vcontact", OracleDbType.Varchar2).Value = Vcontact;
            com.Parameters.Add("Vcnic", OracleDbType.Varchar2).Value = Vcnic;
            com.Parameters.Add("Vaddress", OracleDbType.Varchar2).Value = Vaddress;
            com.Parameters.Add("Vvoternumber", OracleDbType.Varchar2).Value = Vvoternumber;
            com.Parameters.Add("Visdeactivate", OracleDbType.Varchar2).Value = Visdeactivate;
            com.Parameters.Add("Vmobilenumberforsms", OracleDbType.Varchar2).Value = Vmobilenumberforsms;
            com.Parameters.Add("VUser", OracleDbType.Varchar2).Value = UserInfo.UserId;
            com.Parameters.Add("Vstatus", OracleDbType.Varchar2).Value = Vstatus;
            com.Parameters.Add("Vpaidbyzakat", OracleDbType.Varchar2).Value = Vpaidbyzakat;
            com.Parameters.Add("Vreferenceid", OracleDbType.Varchar2).Value = ReferenceId;
            com.Parameters.Add("VMemberValidity", OracleDbType.Varchar2).Value = memberValidity;
            com.Parameters.Add("VValidityDate", OracleDbType.Date).Value = validityDate;

            //com.Parameters.Add("VmemberPic", OracleDbType.Blob).Value = VmemberPic;
            //com.Parameters.Add("Vsignature", OracleDbType.Blob).Value = Vsignature;


            OracleParameter Retparam = com.Parameters.Add("RetVal", OracleDbType.Varchar2, 10);

            Retparam.Direction = ParameterDirection.Output;
            com.ExecuteNonQuery();
            string Retval = Retparam.Value.ToString();
            Saved = true;

            return Saved;
        }
        public static bool FamilyInfo_add_edit(string Vid, string Vfamilymember, string Vdob, string Vnewno, string Vrelation, string Vcnic, string visdeactivate)
        {
            bool Saved = false;

            OracleCommand com = new OracleCommand("memberdependent_addedit", clsConnection.con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add("Vid", OracleDbType.Varchar2).Value = Vid;
            com.Parameters.Add("Vfamilymember", OracleDbType.Varchar2).Value = Vfamilymember;
            com.Parameters.Add("Vdob", OracleDbType.Date).Value = Vdob;
            com.Parameters.Add("Vbmjno", OracleDbType.Varchar2).Value = Vnewno;
            com.Parameters.Add("Vrelation", OracleDbType.Varchar2).Value = Vrelation;
            com.Parameters.Add("Vcnic", OracleDbType.Varchar2).Value = Vcnic;
            com.Parameters.Add("visdeactivate", OracleDbType.Varchar2).Value = visdeactivate;



            com.ExecuteNonQuery();

            Saved = true;

            return Saved;
        }


        public static bool ChartOfAcc_delete(string account)
        {
            bool Saved = false;

            OracleCommand com = new OracleCommand("ChartOFAccount_delete", clsConnection.con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add("@account", OracleDbType.Varchar2).Value = account;
            com.Parameters.Add("@user", OracleDbType.Varchar2).Value = UserInfo.UserId;
            com.ExecuteNonQuery();
            Saved = true;

            return Saved;
        }
        public static bool GL_Add_Edit(DateTime VDate, string VoucherNo, string Vtype, string Vseq, string DrAccount,
            string Amount, string CrAccount, string Narration, string Remarks, string CheckNum, object CheckDate, string CheckStatus
            , string Clear, string status, ref string voucher)
        {
            bool Saved = false;
            OracleCommand com = new OracleCommand("GLAdd_Edit1", clsConnection.con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add("@VDate", OracleDbType.Date).Value = VDate;
            com.Parameters.Add("@VoucherNo", OracleDbType.Varchar2).Value = VoucherNo == null ? DBNull.Value : (object)VoucherNo;
            com.Parameters.Add("@Vtype", OracleDbType.Varchar2).Value = Vtype;
            com.Parameters.Add("@Vseq", OracleDbType.Varchar2).Value = Vseq;
            com.Parameters.Add("@DRAccount", OracleDbType.Varchar2).Value = DrAccount;
            com.Parameters.Add("@Amount", OracleDbType.Varchar2).Value = Amount;
            com.Parameters.Add("@CRAccount", OracleDbType.Varchar2).Value = CrAccount;
            com.Parameters.Add("@Narration", OracleDbType.Varchar2).Value = Narration == null ? DBNull.Value : (object)Narration;
            com.Parameters.Add("@Remarks", OracleDbType.NVarchar2).Value = Remarks == null ? DBNull.Value : (object)Remarks;
            com.Parameters.Add("@CheckNum", OracleDbType.Varchar2).Value = CheckNum == null ? DBNull.Value : (object)CheckNum;
            com.Parameters.Add("@CheckDate", OracleDbType.Varchar2).Value = CheckDate == null ? DBNull.Value : CheckDate;
            com.Parameters.Add("@CheckStatus", OracleDbType.Varchar2).Value = CheckStatus == null ? DBNull.Value : (object)CheckStatus;
            com.Parameters.Add("@Clear", OracleDbType.Varchar2).Value = Clear;
            com.Parameters.Add("@status", OracleDbType.Varchar2).Value = status;
            com.Parameters.Add("@user", OracleDbType.Varchar2).Value = UserInfo.UserId;
            OracleParameter Retparam = com.Parameters.Add("@RetVoucherNo", OracleDbType.Varchar2, 8);

            Retparam.Direction = ParameterDirection.Output;
            com.ExecuteNonQuery();
            voucher = Retparam.Value.ToString();
            //voucher = com.Parameters["@RetVoucherNo"].Value.ToString ();
            Saved = true;
            return Saved;
        }
        public static bool ReportDocument_Add_Edit(string Vreportno,
        string Vslipno,
        DateTime Vissuedate,
        string Vslipdate,
        string VPatientName,
        string Age,
        string VGender,
        string VContact,
        string Vclinicaldiagnosis,
        string Vrefphysician,
        string Vdocument,
        string Vdocument1,
        string Vdocument2,
        string Vpara,
        string VLMP,
        string VCO,
        string Vstatus, string VOPD, ref string voucher)
        {
            bool Saved = false;
            OracleCommand com = new OracleCommand("testreportdoc_add_edit1", clsConnection.con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add("Vreportno", OracleDbType.Varchar2).Value = Vreportno;
            com.Parameters.Add("Vslipno", OracleDbType.Varchar2).Value = Vslipno;
            com.Parameters.Add("Vissuedate", OracleDbType.Date).Value = Vissuedate;
            com.Parameters.Add("Vslipdate", OracleDbType.Varchar2).Value = Vslipdate;
            com.Parameters.Add("VPatientName", OracleDbType.Varchar2).Value = VPatientName;
            com.Parameters.Add("Age", OracleDbType.Varchar2).Value = Age;
            com.Parameters.Add("VGender", OracleDbType.Varchar2).Value = VGender;
            com.Parameters.Add("VContact", OracleDbType.Varchar2).Value = VContact;
            com.Parameters.Add("Vclinicaldiagnosis", OracleDbType.Varchar2).Value = Vclinicaldiagnosis;
            com.Parameters.Add("Vrefphysician", OracleDbType.Varchar2).Value = Vrefphysician;
            com.Parameters.Add("Vdocument", OracleDbType.Clob).Value = Vdocument;
            com.Parameters.Add("Vdocument1", OracleDbType.Clob).Value = Vdocument1;
            com.Parameters.Add("Vdocument2", OracleDbType.Clob).Value = Vdocument2;
            com.Parameters.Add("Vpara", OracleDbType.Varchar2).Value = Vpara;
            com.Parameters.Add("VLMP", OracleDbType.Varchar2).Value = VLMP;
            com.Parameters.Add("VCO", OracleDbType.Varchar2).Value = VCO;
            com.Parameters.Add("VUser", OracleDbType.Varchar2).Value = UserInfo.UserId;
            com.Parameters.Add("Vstatus", OracleDbType.Varchar2).Value = Vstatus;
            com.Parameters.Add("VIPD_OPD", OracleDbType.Varchar2).Value = VOPD;

            OracleParameter Retparam = com.Parameters.Add("RetReportNo", OracleDbType.Varchar2, 10);
            Retparam.Direction = ParameterDirection.Output;
            com.ExecuteNonQuery();
            voucher = Retparam.Value.ToString();
            Saved = true;
            return Saved;
        }
        public static bool LabReportMaster_Add_Edit(string Vreportno,
string Vslipno,
DateTime Vissuedate,
string Vslipdate,
string VPatientName,
string Age,
string VGender,
string VContact,
string VDepartment,
string VRefBy,
string VLocation,
    string VRemarks,
string Vstatus,
string Vipdopd,/*string hexUser,*/ ref string voucher)
        {
            bool Saved = false;
            OracleCommand com = new OracleCommand("reportmaster_add_edit2", clsConnection.con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add("Vreportno", OracleDbType.Varchar2).Value = Vreportno;
            com.Parameters.Add("Vslipno", OracleDbType.Varchar2).Value = Vslipno;
            com.Parameters.Add("Vissuedate", OracleDbType.Date).Value = Vissuedate;
            com.Parameters.Add("Vslipdate", OracleDbType.Varchar2).Value = Vslipdate;
            com.Parameters.Add("VPatientName", OracleDbType.Varchar2).Value = VPatientName;
            com.Parameters.Add("Vage", OracleDbType.Varchar2).Value = Age;// Age
            com.Parameters.Add("VGender", OracleDbType.Varchar2).Value = VGender;
            com.Parameters.Add("VContact", OracleDbType.Varchar2).Value = VContact;
            com.Parameters.Add("VDepartment", OracleDbType.Varchar2).Value = VDepartment;
            com.Parameters.Add("VRefBy", OracleDbType.Varchar2).Value = VRefBy;
            com.Parameters.Add("VLocation", OracleDbType.Varchar2).Value = VLocation;
            com.Parameters.Add("VRemarks", OracleDbType.Varchar2).Value = VRemarks;
            com.Parameters.Add("VUser", OracleDbType.Varchar2).Value = UserInfo.UserId;
            com.Parameters.Add("Vstatus", OracleDbType.Varchar2).Value = Vstatus;
            com.Parameters.Add("Vipdopd", OracleDbType.Varchar2).Value = Vipdopd;
            //      com.Parameters.Add("Vhexuser", OracleDbType.Varchar2).Value = hexUser;

            //com.Parameters.Add("Vipdopd", OracleDbType.Varchar2).Value = Vipdopd;

            OracleParameter Retparam = com.Parameters.Add("RetReportNo", OracleDbType.Varchar2, 10);

            Retparam.Direction = ParameterDirection.Output;
            com.ExecuteNonQuery();
            voucher = Retparam.Value.ToString();
            Saved = true;
            return Saved;
        }
        public static bool LabReportResult_Add_Edit(string Vreportno,
string Vdepartmentid,
string Vtestid,
string Vtitle,
string Vresult,
string Vunit,
string VRemarks,
string Vapproxresult,
string Vstatus,
string Vipdopd)
        {
            bool Saved = false;
            OracleCommand com = new OracleCommand("reportResult_add_edit2", clsConnection.con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add("Vreportno", OracleDbType.Varchar2).Value = Vreportno;
            com.Parameters.Add("Vdepartmentid", OracleDbType.Varchar2).Value = Vdepartmentid;
            com.Parameters.Add("Vtestid", OracleDbType.Varchar2).Value = Vtestid;
            com.Parameters.Add("Vtitle", OracleDbType.Varchar2).Value = Vtitle;
            com.Parameters.Add("Vresult", OracleDbType.Varchar2).Value = Vresult;
            com.Parameters.Add("Vunit", OracleDbType.Varchar2).Value = Vunit;
            com.Parameters.Add("VRemarks", OracleDbType.Varchar2).Value = VRemarks;
            com.Parameters.Add("Vapproxresult", OracleDbType.Varchar2).Value = Vapproxresult;
            com.Parameters.Add("VUser", OracleDbType.Varchar2).Value = UserInfo.UserId;
            com.Parameters.Add("Vipdopd", OracleDbType.Varchar2).Value = Vipdopd;
            com.Parameters.Add("Vstatus", OracleDbType.Varchar2).Value = Vstatus;

            //com.Parameters.Add("Vipdopd", OracleDbType.Varchar2).Value = Vipdopd;
            //OracleParameter Retparam = com.Parameters.Add("RetReportNo", OracleDbType.Varchar2, 10);

            //Retparam.Direction = ParameterDirection.Output;
            com.ExecuteNonQuery();
            Saved = true;
            return Saved;
        }
        public static bool inptestcharges_add_edit(string VReceiptNo, string VVSeq, string Vserialno, DateTime Vreceiptdate,
            string Vtesttypeid, string Vtestid, string Vcharges, string Vconsultantid, string Vstatus, ref string RetReceiptNo)
        {

            bool Saved = false;
            OracleCommand com = new OracleCommand("inptestcharges_add_edit", clsConnection.con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add("VReceiptNo", OracleDbType.Varchar2).Value = VReceiptNo;
            com.Parameters.Add("VVSeq", OracleDbType.Varchar2).Value = VVSeq;
            com.Parameters.Add("Vserialno", OracleDbType.Varchar2).Value = Vserialno;
            com.Parameters.Add("Vreceiptdate", OracleDbType.Date).Value = Vreceiptdate;
            com.Parameters.Add("Vtesttypeid", OracleDbType.Varchar2).Value = Vtesttypeid;
            com.Parameters.Add("Vtestid", OracleDbType.Varchar2).Value = Vtestid;
            com.Parameters.Add("Vcharges", OracleDbType.Varchar2).Value = Vcharges;
            com.Parameters.Add("Vconsultantid", OracleDbType.Varchar2).Value = Vconsultantid;
            com.Parameters.Add("Vuser", OracleDbType.Varchar2).Value = UserInfo.UserId;
            com.Parameters.Add("Vstatus", OracleDbType.Varchar2).Value = Vstatus;
            com.Parameters.Add("Vterminalid", OracleDbType.Varchar2).Value = SoftwareInfo.Terminal;

            com.Parameters.Add("RetReceiptNo", OracleDbType.Varchar2, 50).Direction = ParameterDirection.Output;

            com.ExecuteNonQuery();

            RetReceiptNo = com.Parameters["RetReceiptNo"].Value.ToString();

            Saved = true;
            return Saved;
        }
        public static bool Test_add_Edit(string Vid, string Vtitle, string Vhospitalrate, string Vtesttypeid, string Vconsultantshare, string Vhospitalshare, string Vtestheadid, string Vlocation, string Visdeactivated)
        {
            bool Saved = false;
            OracleCommand com = new OracleCommand("Test_add_Edit", clsConnection.con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add("Vid", OracleDbType.Varchar2).Value = Vid;
            com.Parameters.Add("Vtitle", OracleDbType.Varchar2).Value = Vtitle;
            com.Parameters.Add("Vhospitalrate", OracleDbType.Varchar2).Value = Vhospitalrate;
            com.Parameters.Add("Vtesttypeid", OracleDbType.Varchar2).Value = Vtesttypeid;
            com.Parameters.Add("Vconsultantshare", OracleDbType.Varchar2).Value = Vconsultantshare;
            com.Parameters.Add("Vhospitalshare", OracleDbType.Varchar2).Value = Vhospitalshare;
            com.Parameters.Add("Vtestheadid", OracleDbType.Varchar2).Value = Vtestheadid;
            com.Parameters.Add("Vlocation", OracleDbType.Varchar2).Value = Vlocation;
            com.Parameters.Add("Visdeactivated", OracleDbType.Varchar2).Value = Visdeactivated;
            com.Parameters.Add("VUser", OracleDbType.Varchar2).Value = UserInfo.UserId;

            //OracleParameter Retparam = com.Parameters.Add("RetReportNo", OracleDbType.Varchar2, 10); location

            //Retparam.Direction = ParameterDirection.Output;
            com.ExecuteNonQuery();
            Saved = true;
            return Saved;
        }

        public static bool docTemplate_add_edit(string Vid, string VTemplatename, string Vdocument,string IsEcho)
        {
            bool Saved = false;
            OracleCommand com = new OracleCommand("docTemplate_add_edit", clsConnection.con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add("Vid", OracleDbType.Varchar2).Value = Validation.NullToDBNull(Vid);
            com.Parameters.Add("VTemplatename", OracleDbType.Varchar2).Value = VTemplatename;
            com.Parameters.Add("Vdocument", OracleDbType.Clob).Value = Vdocument;
            com.Parameters.Add("VUser", OracleDbType.Varchar2).Value = UserInfo.UserId;
            com.Parameters.Add("VStatus", OracleDbType.Varchar2).Value = "0";
            com.Parameters.Add("VIsEcho", OracleDbType.Varchar2).Value = IsEcho;
            //OracleParameter Retparam = com.Parameters.Add("RetReportNo", OracleDbType.Varchar2, 10);

            //Retparam.Direction = ParameterDirection.Output;
            com.ExecuteNonQuery();
            Saved = true;
            return Saved;
        }

        public static bool addmissionInfo_add_edit(string Vadmissionid, string Vserialno, string Vregnoalpha, string Vregnonumeric, DateTime Vadmdate, DateTime Vadmtime, string Vroomid, string Vpatienttype,
            string Vbmjnewno, string Vtitle, string Vpatientname, string Vrelationname, string Vrelation, string Vage, string Vgender, string Vymd, string Vconsultantid, string Vreferenceid, string Vreferencename,
            string Vreferenceeffectdate, string Vadmittedfor, string Vcityid, string Vareaid, string Vaddress, string Vemergency, string Vmobile, string Vothercontact, string Vemail, string Vremarks,
            string Vdischargeyn, string Vstatus, string VCNIC, string VcnicRelation, string VCNICPerson)
        {


            bool Saved = false;
            /// OracleCommand com = new OracleCommand("addmissionInfo_add_edit", clsConnection.con);
            OracleCommand com = new OracleCommand("addmissioninfo_add_edit_U", clsConnection.con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add("Vadmissionid", OracleDbType.Varchar2).Value = Vadmissionid;
            com.Parameters.Add("Vserialno", OracleDbType.Varchar2).Value = Vserialno;
            com.Parameters.Add("Vregnoalpha", OracleDbType.Varchar2).Value = Vregnoalpha;
            com.Parameters.Add("Vregnonumeric", OracleDbType.Varchar2).Value = Vregnonumeric;
            //com.Parameters.Add("Vadmdate", OracleDbType.Varchar2).Value = Vadmdate;
            //com.Parameters.Add("Vadmtime", OracleDbType.Varchar2).Value = Vadmtime;


            com.Parameters.Add("Vadmdate", OracleDbType.Date).Value = Vadmdate;
            com.Parameters.Add("Vadmtime", OracleDbType.Date).Value = Vadmtime;

            com.Parameters.Add("Vroomid", OracleDbType.Varchar2).Value = Vroomid;
            com.Parameters.Add("Vpatienttype", OracleDbType.Varchar2).Value = Vpatienttype;
            com.Parameters.Add("Vbmjnewno", OracleDbType.Varchar2).Value = Vbmjnewno;
            com.Parameters.Add("Vtitle", OracleDbType.Varchar2).Value = Vtitle;
            com.Parameters.Add("Vpatientname", OracleDbType.Varchar2).Value = Vpatientname;
            com.Parameters.Add("Vrelation", OracleDbType.Varchar2).Value = Vrelation;
            com.Parameters.Add("Vrelationname", OracleDbType.Varchar2).Value = Vrelationname;
            com.Parameters.Add("Vage", OracleDbType.Varchar2).Value = Vage;
            com.Parameters.Add("Vgender", OracleDbType.Varchar2).Value = Vgender;
            com.Parameters.Add("Vymd", OracleDbType.Varchar2).Value = Vymd;
            com.Parameters.Add("Vconsultantid", OracleDbType.Varchar2).Value = Vconsultantid;
            com.Parameters.Add("Vreferenceid", OracleDbType.Varchar2).Value = Vreferenceid;
            com.Parameters.Add("Vreferencename", OracleDbType.Varchar2).Value = Vreferencename;
            com.Parameters.Add("Vreferenceeffectdate", OracleDbType.Varchar2).Value = Vreferenceeffectdate;
            com.Parameters.Add("Vadmittedfor", OracleDbType.Varchar2).Value = Vadmittedfor;
            com.Parameters.Add("Vcityid", OracleDbType.Varchar2).Value = Vcityid;
            com.Parameters.Add("Vareaid", OracleDbType.Varchar2).Value = Vareaid;
            com.Parameters.Add("Vaddress", OracleDbType.Varchar2).Value = Vaddress;
            com.Parameters.Add("Vemergency", OracleDbType.Varchar2).Value = Vemergency;
            com.Parameters.Add("Vmobile", OracleDbType.Varchar2).Value = Vmobile;
            com.Parameters.Add("Vothercontact", OracleDbType.Varchar2).Value = Vothercontact;
            com.Parameters.Add("Vemail", OracleDbType.Varchar2).Value = Vemail;
            com.Parameters.Add("Vremarks", OracleDbType.Varchar2).Value = Vremarks;
            com.Parameters.Add("Vdischargeyn", OracleDbType.Varchar2).Value = Vdischargeyn;
            com.Parameters.Add("VUser", OracleDbType.Varchar2).Value = UserInfo.UserId;
            com.Parameters.Add("Vstatus", OracleDbType.Varchar2).Value = Vstatus;
            com.Parameters.Add("VCNIC", OracleDbType.Varchar2).Value = VCNIC;
            com.Parameters.Add("VcnicRelation", OracleDbType.Varchar2).Value = VcnicRelation;
            com.Parameters.Add("VCNICPerson", OracleDbType.Varchar2).Value = VCNICPerson;
            com.Parameters.Add("Vsessionid", OracleDbType.Varchar2).Value = "0";
            //OracleParameter Retparam = com.Parameters.Add("RetReportNo", OracleDbType.Varchar2, 10);

            //Retparam.Direction = ParameterDirection.Output;
            com.ExecuteNonQuery();
            Saved = true;
            return Saved;
        }

        public static bool OPDReceipt_Add_Edit(string VReceiptNo,
            Decimal VtokenNo,
            DateTime VVdate,
            string VCatagoryId,
            object VConsultantID,
            object VPatientType,
            object VMemberID,
            object VPatientId,
            string VPatientTitle,
            string VPatientName,
            object VGender,
            string VContactNo,
            string VAge,
            object VAgeUnit,
            string VReferenceId,
            string VRemarks,
            decimal VGrossAmount,
            decimal VDiscount,
            decimal VNetAmount,
            string Vstatus,
            string VisPartial,
            decimal VpartialAmount,
            decimal Vnetbalance,
            decimal Velectricitycharges,
            ref string voucher)

        {
            bool Saved = false;
            OracleCommand com = new OracleCommand("opdreceipt_add_edit_TEST_new", clsConnection.con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add("VReceiptNo", OracleDbType.Varchar2).Value = VReceiptNo;
            com.Parameters.Add("VtokenNo", OracleDbType.Decimal).Value = VtokenNo;
            com.Parameters.Add("VVdate", OracleDbType.Date).Value = VVdate;
            com.Parameters.Add("VCatagoryId", OracleDbType.Varchar2).Value = VCatagoryId;
            com.Parameters.Add("VConsultantID", OracleDbType.Varchar2).Value = VCatagoryId == "2" ? null : VConsultantID;
            com.Parameters.Add("VPatientType", OracleDbType.Varchar2).Value = VPatientType;
            com.Parameters.Add("VMemberID", OracleDbType.Varchar2).Value = VMemberID;
            com.Parameters.Add("VPatientId", OracleDbType.Varchar2).Value = VPatientId;
            com.Parameters.Add("VPatientTitle", OracleDbType.Varchar2).Value = VPatientTitle;
            com.Parameters.Add("VPatientName", OracleDbType.Varchar2).Value = VPatientName;
            com.Parameters.Add("VGender", OracleDbType.Varchar2).Value = VGender;
            com.Parameters.Add("VContactNo", OracleDbType.Varchar2).Value = VContactNo;
            com.Parameters.Add("VAge", OracleDbType.Varchar2).Value = VAge;
            com.Parameters.Add("VAgeUnit", OracleDbType.Varchar2).Value = VAgeUnit;
            com.Parameters.Add("VReferenceId", OracleDbType.Varchar2).Value = VReferenceId;
            com.Parameters.Add("VRemarks", OracleDbType.Varchar2).Value = VRemarks;
            com.Parameters.Add("VGrossAmount", OracleDbType.Decimal).Value = VGrossAmount;
            com.Parameters.Add("VDiscount", OracleDbType.Decimal).Value = VDiscount;
            com.Parameters.Add("VNetAmount", OracleDbType.Decimal).Value = VNetAmount;
            com.Parameters.Add("VUser", OracleDbType.Varchar2).Value = UserInfo.UserId;
            com.Parameters.Add("VTerminalId", OracleDbType.Varchar2).Value = SoftwareInfo.Terminal;
            com.Parameters.Add("Vstatus", OracleDbType.Varchar2).Value = Vstatus;
            com.Parameters.Add("VisPartial", OracleDbType.Varchar2).Value = VisPartial;
            com.Parameters.Add("VpartialAmount", OracleDbType.Decimal).Value = VisPartial == "1" ? VpartialAmount : 0;
            com.Parameters.Add("Vnetbalance", OracleDbType.Decimal).Value = Vnetbalance;
            com.Parameters.Add("Velectricitycharges", OracleDbType.Decimal).Value = Velectricitycharges;
            com.Parameters.Add("VlaboratoryConsultantid", OracleDbType.Varchar2).Value = VCatagoryId == "2" ? VConsultantID : null;
            OracleParameter Retparam = com.Parameters.Add("RetVoucherNo", OracleDbType.Varchar2, 10);

            Retparam.Direction = ParameterDirection.Output;
            com.ExecuteNonQuery();
            voucher = Retparam.Value.ToString();
            Saved = true;
            return Saved;
        }
        public static bool OPDReceiptTestDetail_Add_Edit(int BindCount,
            string[] VReceiptNo,
        string[] VfkTestId,
        decimal[] VAmount,
        string[] Vstatus,
            string[] VRowId)



        {
            bool Saved = false;
            OracleCommand com = new OracleCommand("opdTestreceipt_add_edit1_new", clsConnection.con);
            com.CommandType = CommandType.StoredProcedure;
            com.ArrayBindCount = BindCount;
            com.Parameters.Add("VReceiptNo", OracleDbType.Varchar2).Value = VReceiptNo;
            com.Parameters.Add("VfkTestId", OracleDbType.Varchar2).Value = VfkTestId;
            com.Parameters.Add("VRowId", OracleDbType.Varchar2).Value = VRowId;
            com.Parameters.Add("VAmount", OracleDbType.Varchar2).Value = VAmount;
            com.Parameters.Add("VUser", OracleDbType.Varchar2).Value = Enumerable.Repeat(UserInfo.UserId, BindCount).ToArray();
            com.Parameters.Add("Vstatus", OracleDbType.Varchar2).Value = Vstatus;

            com.ExecuteNonQuery();

            Saved = true;
            return Saved;
        }
        public static bool consultant_add_edit(string Vid, string Vname, string Vaddress,
                                               string Vtel, string Vfax, string Vmobile,
                                               string Vemail, string Vhospitalrate, string Vdegrees,
                                               string Vtimings, string Vfaculty, string Vtesttypeid,
                                               string Vhospitalshareoutdoor, string Vconsultantshareoutdoor,
            string Vconsultantshareindoor, string Vhospitalshareindoor, string Visdeactivate, ref string RetID)
        {
            bool Saved = false;
            OracleCommand com = new OracleCommand("consultant_add_edit", clsConnection.con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add("Vid", OracleDbType.Varchar2).Value = Vid;
            com.Parameters.Add("Vname", OracleDbType.Varchar2).Value = Vname;
            com.Parameters.Add("Vaddress", OracleDbType.Varchar2).Value = Vaddress;
            com.Parameters.Add("Vtel", OracleDbType.Varchar2).Value = Vtel;
            com.Parameters.Add("Vfax", OracleDbType.Varchar2).Value = Vfax;
            com.Parameters.Add("Vmobile", OracleDbType.Varchar2).Value = Vmobile;
            com.Parameters.Add("Vemail", OracleDbType.Varchar2).Value = Vemail;
            com.Parameters.Add("Vhospitalrate", OracleDbType.Varchar2).Value = Vhospitalrate;
            com.Parameters.Add("Vdegrees", OracleDbType.Varchar2).Value = Vdegrees;
            com.Parameters.Add("Vtimings", OracleDbType.Varchar2).Value = Vtimings;
            com.Parameters.Add("Vfaculty", OracleDbType.Varchar2).Value = Vfaculty;
            com.Parameters.Add("Vtesttypeid", OracleDbType.Varchar2).Value = Vtesttypeid;
            com.Parameters.Add("Vconsultantshareoutdoor", OracleDbType.Varchar2).Value = Vconsultantshareoutdoor;
            com.Parameters.Add("Vhospitalshareoutdoor", OracleDbType.Varchar2).Value = Vhospitalshareoutdoor;
            com.Parameters.Add("Vconsultantshareindoor", OracleDbType.Varchar2).Value = Vconsultantshareindoor;
            com.Parameters.Add("Vhospitalshareindoor", OracleDbType.Varchar2).Value = Vhospitalshareindoor;

            com.Parameters.Add("Visdeactivate", OracleDbType.Varchar2).Value = Visdeactivate;


            OracleParameter Retparam = com.Parameters.Add("IVRetId", OracleDbType.Varchar2, 10);

            Retparam.Direction = ParameterDirection.Output;
            com.ExecuteNonQuery();
            RetID = com.Parameters["IVRetId"].Value.ToString();
            Saved = true;
            return Saved;
        }


        public static bool UserSession_Closed(string SessionId)
        {
            bool Saved = false;

            OracleCommand com = new OracleCommand("UserSession_Closed", clsConnection.con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add("@VSessionId", OracleDbType.Varchar2).Value = SessionId;
            com.ExecuteNonQuery();
            Saved = true;

            return Saved;
        }
        public static bool UpdateBankReconcile(string Vno, string Clear, object ClearDate)
        {
            bool Saved = false;
            string sql = "Update Gl1 set clear = @clear ,cleardate = @cleardate where voucherno = @vno and vtype = @vtype and status = 0";
            OracleCommand com = new OracleCommand(sql, clsConnection.con);
            com.CommandType = CommandType.Text;
            com.Parameters.Add("@clear", OracleDbType.Varchar2).Value = Clear;
            com.Parameters.Add("@ClearDate", OracleDbType.Date).Value = Validation.NullToDBNull(ClearDate);
            com.Parameters.Add("@Vtype", OracleDbType.Varchar2).Value = Vno.Substring(0, 2);
            com.Parameters.Add("@vno", OracleDbType.Varchar2).Value = Vno.Substring(3);
            com.ExecuteNonQuery();
            Saved = true;

            return Saved;
        }


        public static bool Change_OPDReceipt_Status(string Vno, string status, string RefundBy, DateTime? RefundDate)
        {
            bool Saved = false;
            OracleCommand com = new OracleCommand("Change_OPDReceipt_Status", clsConnection.con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add("VReceiptNo", OracleDbType.Varchar2).Value = Vno;
            com.Parameters.Add("VStatus", OracleDbType.Varchar2).Value = status;
            com.Parameters.Add("VUser", OracleDbType.Varchar2).Value = UserInfo.UserId;
            com.Parameters.Add("VTerminalId", OracleDbType.Varchar2).Value = SoftwareInfo.Terminal;
            com.Parameters.Add("VRemarks", OracleDbType.Varchar2).Value = "";

            com.Parameters.Add("VRefundBy", OracleDbType.Varchar2).Value = Validation.NullToDBNull(RefundBy);
            com.Parameters.Add("VRefunddate", OracleDbType.Date).Value = RefundDate;
            com.ExecuteNonQuery();

            Saved = true;
            return Saved;
        }
        public static bool addSurgeryDetails(string fkConsultant, string fkpkgID, string consultantShare, string hospShare)
        {
            bool Saved = false;
            OracleCommand com = new OracleCommand("consultantSurgeryAdd_edit", clsConnection.con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add("VfkConsID", OracleDbType.Varchar2).Value = fkConsultant;
            com.Parameters.Add("VfkPkgID", OracleDbType.Varchar2).Value = fkpkgID;
            com.Parameters.Add("VconsulShare", OracleDbType.Varchar2).Value = consultantShare;
            com.Parameters.Add("VhospShare", OracleDbType.Varchar2).Value = hospShare;

            com.ExecuteNonQuery();

            Saved = true;
            return Saved;
        }

        public static bool Change_GL_Status(string Vno, string Vtype, string Vseq, string status)
        {
            bool Saved = false;
            OracleCommand com = new OracleCommand("Change_GL_Status", clsConnection.con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add("@Vno", OracleDbType.Varchar2).Value = Vno;
            com.Parameters.Add("@Vtype", OracleDbType.Varchar2).Value = Vtype;
            com.Parameters.Add("@Vseq", OracleDbType.Varchar2).Value = Validation.NullToDBNull(Vseq);
            com.Parameters.Add("@status", OracleDbType.Varchar2).Value = status;
            com.ExecuteNonQuery();

            Saved = true;
            return Saved;
        }
        public static bool LabMasterReg_StatusChanged(string ReceiptNo, string Status, string IO)
        {
            bool Saved = false;
            OracleCommand com = new OracleCommand("LabMasterReg_StatusChanged1", clsConnection.con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add("VReceiptNo", OracleDbType.Varchar2).Value = ReceiptNo;
            com.Parameters.Add("VIO", OracleDbType.Varchar2).Value = IO;
            com.Parameters.Add("VStatus", OracleDbType.Varchar2).Value = Status;
            com.Parameters.Add("VUser", OracleDbType.Varchar2).Value = UserInfo.UserId;
            com.ExecuteNonQuery();

            Saved = true;
            return Saved;
        }
        public static bool LabMasterReg_SentStatusChanged(string ReceiptNo, string Status)
        {
            bool Saved = false;
            OracleCommand com = new OracleCommand("LabMasterReg_SentStatusChanged", clsConnection.con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add("VReceiptNo", OracleDbType.Varchar2).Value = ReceiptNo;
            com.Parameters.Add("VStatus", OracleDbType.Varchar2).Value = Status;
            com.Parameters.Add("VUser", OracleDbType.Varchar2).Value = UserInfo.UserId;
            com.ExecuteNonQuery();

            Saved = true;
            return Saved;
        }
        public static bool userinfo_add_edit(string Vid, string Vname, string Vpassword, string Vuserlevel, string Vislock, string Vmultilogin, string Vstatus)
        {
            bool Saved = false;
            OracleCommand com = new OracleCommand("userinfo_add_edit", clsConnection.con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add("Vid", OracleDbType.Varchar2).Value = Vid;
            com.Parameters.Add("Vname", OracleDbType.Varchar2).Value = Vname;
            com.Parameters.Add("Vpassword", OracleDbType.Varchar2).Value = Vpassword;
            com.Parameters.Add("Vuserlevel", OracleDbType.Varchar2).Value = Vuserlevel;
            com.Parameters.Add("Vislock", OracleDbType.Varchar2).Value = Vislock;
            com.Parameters.Add("Vmultilogin", OracleDbType.Varchar2).Value = Vmultilogin;
            com.Parameters.Add("Vuser", OracleDbType.Varchar2).Value = UserInfo.UserId;
            com.Parameters.Add("Vstatus", OracleDbType.Varchar2).Value = Vstatus;
            com.Parameters.Add("VTerminalid", OracleDbType.Varchar2).Value = SoftwareInfo.Terminal;
            com.Parameters.Add("VSoftwareModule", OracleDbType.Varchar2).Value = "ERP";
            com.Parameters.Add("VEpassword", OracleDbType.Varchar2).Value = Vpassword;
            com.ExecuteNonQuery();

            Saved = true;
            return Saved;
        }
        public static bool receiptinfo_add_edit(string id, string Vserialno, DateTime Vvdate, string Vamount, string mode_of_payment, ref string RetBillNo)
        {
            bool Saved = false;
            OracleCommand com = new OracleCommand("receiptinfo_add_edit", clsConnection.con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add("id", OracleDbType.Varchar2).Value = id;
            com.Parameters.Add("Vserialno", OracleDbType.Varchar2).Value = Vserialno;
            com.Parameters.Add("Vvdate", OracleDbType.Date).Value = Vvdate;
            com.Parameters.Add("Vamount", OracleDbType.Varchar2).Value = Vamount;
            com.Parameters.Add("Vreceiptmode", OracleDbType.Varchar2).Value = mode_of_payment;
            com.Parameters.Add("Vuser", OracleDbType.Varchar2).Value = UserInfo.UserId;
            com.Parameters.Add("vstatus", OracleDbType.Varchar2).Value = "0";
            com.Parameters.Add("vterminalid", OracleDbType.Varchar2).Value = SoftwareInfo.Terminal;
            //com.Parameters.Add("Vreceiptmode", OracleDbType.Varchar2).Value = Vreceiptmode;
            OracleParameter Retparam = com.Parameters.Add("ReceiptNo", OracleDbType.Varchar2, 8);
            Retparam.Direction = ParameterDirection.Output;
            com.ExecuteNonQuery();
            RetBillNo = Retparam.Value.ToString();

            //OracleParameter Retparam = com.Parameters.Add("RetReportNo", OracleDbType.Varchar2, 10);

            //Retparam.Direction = ParameterDirection.Output;

            Saved = true;
            return Saved;
        }

        public static bool Partialreceiptinfo_add_edit(string id, string Receiptno, DateTime Vvdate, string Vpartialamount, string Vbalanceamount, string mode_of_payment)
        {
            bool Saved = false;
            OracleCommand com = new OracleCommand("Partialreceiptinfo_add_edit", clsConnection.con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add("id", OracleDbType.Varchar2).Value = id;
            com.Parameters.Add("VreceiptNo", OracleDbType.Varchar2).Value = Receiptno;
            com.Parameters.Add("Vvdate", OracleDbType.Date).Value = Vvdate;
            com.Parameters.Add("Vpartialamount", OracleDbType.Varchar2).Value = Vpartialamount;
            com.Parameters.Add("Vbalanceamount", OracleDbType.Varchar2).Value = Vbalanceamount;
            com.Parameters.Add("Vreceiptmode", OracleDbType.Varchar2).Value = mode_of_payment;
            com.Parameters.Add("Vuser", OracleDbType.Varchar2).Value = UserInfo.UserId;
            com.Parameters.Add("vstatus", OracleDbType.Varchar2).Value = "0";
            com.Parameters.Add("vterminalid", OracleDbType.Varchar2).Value = SoftwareInfo.Terminal;
            com.ExecuteNonQuery();
            Saved = true;
            return Saved;
        }
        public static bool packageinfo_add_edit(string Vid, string Vname, string Vamount, string Surgery, string Visactive, string Vstatus, out string ret_id)
        {
            bool Saved = false;
            OracleCommand com = new OracleCommand("packageinfo_add_edit", clsConnection.con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add("Vid", OracleDbType.Varchar2).Value = Vid;
            com.Parameters.Add("Vname", OracleDbType.Varchar2).Value = Vname;
            com.Parameters.Add("Vamount", OracleDbType.Varchar2).Value = Vamount;
            com.Parameters.Add("Visactive", OracleDbType.Varchar2).Value = Visactive;
            com.Parameters.Add("Vcreatedby", OracleDbType.Varchar2).Value = UserInfo.UserId;
            com.Parameters.Add("Vstatus", OracleDbType.Varchar2).Value = Vstatus;
            com.Parameters.Add("Vterminalid", OracleDbType.Varchar2).Value = SoftwareInfo.Terminal;
            com.Parameters.Add("Vsurgery", OracleDbType.Varchar2).Value = Surgery;
            OracleParameter Retparam = com.Parameters.Add("ret_id", OracleDbType.Varchar2, 10);
            Retparam.Direction = ParameterDirection.Output;




            //OracleParameter Retparam = com.Parameters.Add("RetReportNo", OracleDbType.Varchar2, 10);

            //Retparam.Direction = ParameterDirection.Output;
            com.ExecuteNonQuery();
            ret_id = com.Parameters["ret_id"].Value.ToString();
            Saved = true;
            return Saved;
        }
        public static bool birthinfo_add_edit(string VSerialno, string Vbirthid, DateTime Vbirthdate, DateTime Vbirthtime, string Vgender, string Vmothername, string Vfathername, string Vgrandfmname, string Vaddress, string Vconsult, string Vweightkg, string Vweightlbs, string Vnote, string Vrecperson, DateTime Vrecdate, DateTime Vrectime, string Vrecralation, string Vrecvyn, string Vrecremarks, string Vstatus)
        {
            bool Saved = false;
            OracleCommand com = new OracleCommand("birthinfo_add_edit", clsConnection.con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add("VSerialno", OracleDbType.Varchar2).Value = VSerialno;
            com.Parameters.Add("Vbirthid", OracleDbType.Varchar2).Value = Vbirthid;
            com.Parameters.Add("Vbirthdate", OracleDbType.Date).Value = Vbirthdate;
            com.Parameters.Add("Vbirthtime", OracleDbType.Date).Value = Vbirthtime;
            com.Parameters.Add("Vgender", OracleDbType.Varchar2).Value = Vgender;
            com.Parameters.Add("Vmothername", OracleDbType.Varchar2).Value = Vmothername;
            com.Parameters.Add("Vfathername", OracleDbType.Varchar2).Value = Vfathername;
            com.Parameters.Add("Vgrandfmname", OracleDbType.Varchar2).Value = Vgrandfmname;
            com.Parameters.Add("Vaddress", OracleDbType.Varchar2).Value = Vaddress;
            com.Parameters.Add("Vconsult", OracleDbType.Varchar2).Value = Vconsult;
            com.Parameters.Add("Vweightkg", OracleDbType.Varchar2).Value = Vweightkg;
            com.Parameters.Add("Vweightlbs", OracleDbType.Varchar2).Value = Vweightlbs;
            com.Parameters.Add("Vnote", OracleDbType.Varchar2).Value = Vnote;
            com.Parameters.Add("Vrecperson", OracleDbType.Varchar2).Value = Vrecperson;
            com.Parameters.Add("Vrecdate", OracleDbType.Date).Value = Vrecdate;
            com.Parameters.Add("Vrectime", OracleDbType.Date).Value = Vrectime;
            com.Parameters.Add("Vrecralation", OracleDbType.Varchar2).Value = Vrecralation;
            com.Parameters.Add("Vrecvyn", OracleDbType.Varchar2).Value = Vrecvyn;
            com.Parameters.Add("Vrecremarks", OracleDbType.Varchar2).Value = Vrecremarks;
            com.Parameters.Add("Vuser", OracleDbType.Varchar2).Value = UserInfo.UserId;
            com.Parameters.Add("Vstatus", OracleDbType.Varchar2).Value = Vstatus;
            com.Parameters.Add("Vterminalid", OracleDbType.Varchar2).Value = SoftwareInfo.Terminal;

            //com.Parameters.Add("Vterminalid", OracleDbType.Varchar2).Value = Vterminalid;


            //com.Parameters.Add("Vreceiptmode", OracleDbType.Varchar2).Value = Vreceiptmode;




            //OracleParameter Retparam = com.Parameters.Add("RetReportNo", OracleDbType.Varchar2, 10);

            //Retparam.Direction = ParameterDirection.Output;
            com.ExecuteNonQuery();
            Saved = true;
            return Saved;
        }
        public static string GL_Add_Edit(string VVdate, string Vfkaccountid, string Vvtype, string Vvno, string Vdescription,
         string Vfkbankid, string Vchequeno, string Vdr, string Vcr, string Vfcdr,
         string Vfccr, string Vrate, string Vstatus, string Vvseq, string Vfkfccode, string Vcontrafkbrcode,
         string Vddttid, string Vfktransactionid, string Vclearentry, string Vreconciledate, string Vreconcileby,
         string Vrperiodsfrom, string Vrperiodsto, string Vfkimageid,
 string Vfkclientcode, string Vfkdirectorid, string Vfkhrid, string Vbanificiary, string VDocumentChanged, string Vfkdocumentid, byte[] VDocuments, string VSlipNo, string VClientBank, string VClientAcNo)
        {
            string tf = "";
            try
            {
                OracleCommand DbCommand = new OracleCommand("glVNo_add_edit1", clsConnection.con);
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
                DbCommand.Parameters.Add("Vstatus", OracleDbType.Varchar2).Value = "0";
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
                DbCommand.Parameters.Add("VUser", OracleDbType.Varchar2).Value = UserInfo.UserId; //Variable.User;
                DbCommand.Parameters.Add("Vfkimageid", OracleDbType.Varchar2).Value = Vfkimageid;
                DbCommand.Parameters.Add("Vfkclientcode", OracleDbType.Varchar2).Value = Vfkclientcode;
                DbCommand.Parameters.Add("Vfkdirectorid", OracleDbType.Varchar2).Value = Vfkdirectorid;
                DbCommand.Parameters.Add("Vfkhrid", OracleDbType.Varchar2).Value = Vfkhrid;
                DbCommand.Parameters.Add("Vbanificiary", OracleDbType.Varchar2).Value = Vbanificiary;
                DbCommand.Parameters.Add("VTerminalID", OracleDbType.Varchar2).Value = SoftwareInfo.Terminal; //Variable.TerminalId;
                DbCommand.Parameters.Add("VDocumentChanged", OracleDbType.Varchar2, 1).Value = VDocumentChanged;
                DbCommand.Parameters.Add("Vfkdocumentid", OracleDbType.Varchar2, 5).Value = Vfkdocumentid;
                DbCommand.Parameters.Add("VDocuments", OracleDbType.Blob).Value = VDocuments;
                DbCommand.Parameters.Add("VSlipNo", OracleDbType.Varchar2, 25).Value = VSlipNo;
                //DbCommand.Parameters.Add("VClientBank", OracleDbType.Varchar2, 25).Value = VClientBank;
                //DbCommand.Parameters.Add("VClientAcNo", OracleDbType.Varchar2, 25).Value = VClientAcNo;
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
        public static DataTable VoucherFilter(string[] Filter)
        {
            DataTable dt = new DataTable();
            try
            {
                string Condition = String.Join(" And ", Filter);
                Condition = " And" + Condition;
                OracleDataAdapter adapter = new OracleDataAdapter();
                string sql = @"select VDate,VNO,(select narrationtitle from narration where narrationcode = fktransactionid) as Narration,
                dr + cr as Amount from Voucherdetail where status != 1 AND Vseq = 1 " + Condition;
                adapter.SelectCommand = new OracleCommand(sql, clsConnection.con);
                adapter.Fill(dt);
                adapter.Dispose();
                return dt;
            }
            catch (Exception ee)
            {
                Errors.writeline(ee.Message, "Query_ JournalFilter");
                string result = MyMessageBox.ShowBox(ee.Message, Variable.Version, 1);


                return dt;
            }
        }
        public static DataTable Voucher(string VNo, string Fkbrcode, string Vtype, string Narration)
        {
            DataTable dt = new DataTable();
            try
            {

                OracleDataAdapter adapter = new OracleDataAdapter();
                //string sql = "select VDate,VNO,(select narrationtitle from narration where narrationcode = fktransactionid) as Narration,cr as Amount from Voucherdetail where ( VDate between '" + From + "' and '" + To + "') and FK_Narration = " + Narration + " and VNO = " + VNO + "  and Vtype = 'PV' and status = 0 AND Vseq = 1";
                string sql = @"select vd.*,Nvl(get_Directortitle(fkdirectorid),Nvl(get_hrtitle(fkhrid),
                    Nvl(get_banktitle(fkbankid),(SELECT accounttitle FROM chartofaccounts WHERE accountid = vd.fkaccountid) ))) AS title,
                   (CASE WHEN  To_Date(vdate,'dd Mon yyyy') = To_Date(SYSDATE,'dd Mon yyyy') THEN 1 ELSE 0 END  )  AS editable from Voucherdetail vd 
                    where VNO = '" + VNo + "' AND  fkbrcode = '" + Fkbrcode + "'   AND  vtype = '" + Vtype + "' and status <> 1 and fktransactionid =  '" + Narration + "'  ORDER BY vseq asc";
                adapter.SelectCommand = new OracleCommand(sql, clsConnection.con);
                adapter.Fill(dt);
                adapter.Dispose();
                return dt;
            }
            catch (Exception ee)
            {
                Errors.writeline(ee.Message, "Query_ PaymentFilter");
                string result = MyMessageBox.ShowBox(ee.Message, Variable.Version, 1);


                return dt;
            }
        }
        public static string NextCheque(string bankcode)
        {
            DataTable dt = new DataTable();
            string ChequeNum = null;
            try
            {
                OracleDataAdapter adapter = new OracleDataAdapter();
                string sql = "SELECT TO_NUMBER(CHEQUESTARTING)+(CHEQUELEAVES - 1) AS A FROM CHEQUEBOOKREG   WHERE FKBANKCODE = '" + bankcode + "' AND ISSUEDATE =   (SELECT MIN(ISSUEDATE) FROM   CHEQUEBOOKREG  WHERE  FKBANKCODE = '" + bankcode + "'  AND (TO_NUMBER(CHEQUESTARTING)+CHEQUELEAVES) < TO_NUMBER(NVL(LASTCHEQUENO,0)))";
                adapter.SelectCommand = new OracleCommand(sql, clsConnection.con);
                adapter.Fill(dt);
                adapter.Dispose();
                if (dt.Rows.Count > 0) ChequeNum = dt.Rows[0][0].ToString();
                return ChequeNum;
            }
            catch (Exception ee)
            {
                Errors.writeline(ee.Message, "Query_ NextCheque");
                string result = MyMessageBox.ShowBox(ee.Message, Variable.Version, 1);


                return ChequeNum;
            }
        }
        public static bool roominfo_add_edit(string Vroomid, string Vfullname, string Vdescription, string Vfloornumber, string Vhospitalrate)
        {
            bool Saved = false;
            OracleCommand com = new OracleCommand("roominfo_add_edit", clsConnection.con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add("Vroomid", OracleDbType.Varchar2).Value = Vroomid;
            com.Parameters.Add("Vfullname", OracleDbType.Varchar2).Value = Vfullname;
            com.Parameters.Add("Vdescription", OracleDbType.Varchar2).Value = Vdescription;
            com.Parameters.Add("Vfloornumber", OracleDbType.Varchar2).Value = Vfloornumber;
            com.Parameters.Add("Vhospitalrate", OracleDbType.Varchar2).Value = Vhospitalrate;
            com.Parameters.Add("VaddedBy", OracleDbType.Varchar2).Value = UserInfo.UserId;
            com.Parameters.Add("VaddedDate", OracleDbType.Varchar2).Value = DateTime.Now.ToString("dd-MMM-yyyy");

            com.ExecuteNonQuery();

            Saved = true;
            return Saved;
        }
        public static bool userinfo_add_edit(string Vreceipt, DateTime Vadmdate, string Vtestid, string Vcharges, string Vconsultantid, string Vvisits, string Vdelievery, string Vrecovery, string Vlrfixed, string Vdatefrom, string Vmiscdescription, string Vanaescharges, string Vroomtype, string Vdays, string Votherconsultantid, string Vsurgery, string Votfixed, string Vnitrousoxide, string Vanaesthetist, string Vstatus)
        {

            bool Saved = false;
            OracleCommand com = new OracleCommand("admissioncharges_add_edit", clsConnection.con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add("Vreceipt", OracleDbType.Varchar2).Value = Vreceipt;
            com.Parameters.Add("Vadmdate", OracleDbType.Date).Value = Vadmdate;
            com.Parameters.Add("Vtestid", OracleDbType.Varchar2).Value = Vtestid;
            com.Parameters.Add("Vcharges", OracleDbType.Varchar2).Value = Vcharges;
            com.Parameters.Add("Vconsultantid", OracleDbType.Varchar2).Value = Vconsultantid;
            com.Parameters.Add("Vvisits", OracleDbType.Varchar2).Value = Vvisits;
            com.Parameters.Add("Vdelievery", OracleDbType.Varchar2).Value = Vdelievery;
            com.Parameters.Add("Vrecovery", OracleDbType.Varchar2).Value = Vrecovery;
            com.Parameters.Add("Vlrfixed", OracleDbType.Varchar2).Value = Vlrfixed;
            com.Parameters.Add("Vdatefrom", OracleDbType.Date).Value = Vdatefrom;
            com.Parameters.Add("Vmiscdescription", OracleDbType.Varchar2).Value = Vmiscdescription;
            com.Parameters.Add("Vanaescharges", OracleDbType.Varchar2).Value = Vanaescharges;
            com.Parameters.Add("Vroomtype", OracleDbType.Varchar2).Value = Vroomtype;
            com.Parameters.Add("Vdays", OracleDbType.Varchar2).Value = Vdays;
            com.Parameters.Add("Votherconsultantid", OracleDbType.Varchar2).Value = Votherconsultantid;
            com.Parameters.Add("Vsurgery", OracleDbType.Varchar2).Value = Vsurgery;
            com.Parameters.Add("Votfixed", OracleDbType.Varchar2).Value = Votfixed;
            com.Parameters.Add("Vnitrousoxide", OracleDbType.Varchar2).Value = Vnitrousoxide;
            com.Parameters.Add("Vanaesthetist", OracleDbType.Varchar2).Value = Vanaesthetist;
            com.Parameters.Add("Vuser", OracleDbType.Varchar2).Value = UserInfo.UserId;
            com.Parameters.Add("Vstatus", OracleDbType.Varchar2).Value = Vstatus;
            com.Parameters.Add("Vterminalid", OracleDbType.Varchar2).Value = SoftwareInfo.Terminal;


            com.ExecuteNonQuery();

            Saved = true;
            return Saved;
        }
        public static bool reference_add_edit(string Vid, string Vreferencename, string Vinreport, string Visactive)
        {

            bool Saved = false;
            OracleCommand com = new OracleCommand("reference_add_edit", clsConnection.con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add("Vid", OracleDbType.Varchar2).Value = Vid;
            com.Parameters.Add("Vreferencename", OracleDbType.Varchar2).Value = Vreferencename;
            com.Parameters.Add("Vinreport", OracleDbType.Varchar2).Value = Vinreport;
            com.Parameters.Add("Visactive", OracleDbType.Varchar2).Value = Visactive;



            com.ExecuteNonQuery();

            Saved = true;
            return Saved;
        }
        public static bool inpcurrentroom_Add_edit(int Vroomid, string Vfkserialno, string Ventrytime)
        {

            bool Saved = false;
            OracleCommand com = new OracleCommand("inpcurrentroom_Add_edit", clsConnection.con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add("Vroomid", OracleDbType.Varchar2).Value = Vroomid.ToString();
            com.Parameters.Add("VFKSERIALNO", OracleDbType.Varchar2).Value = Vfkserialno;
            com.Parameters.Add("VENTRYTIME", OracleDbType.Varchar2).Value = Ventrytime;


            com.ExecuteNonQuery();
            Saved = true;
            return Saved;

        }
        public static bool deliverycharges_add_edit(string Vinpbillid, string Vserialno, string Vconsultantid, string Vtestid, string Vcharges, string Vlramount, string Vrecoveryamount, string Vstatus, string Vdelivery)
        {

            bool Saved = false;
            OracleCommand com = new OracleCommand("deliverycharges_add_edit", clsConnection.con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add("Vinpbillid", OracleDbType.Varchar2).Value = Vinpbillid;
            com.Parameters.Add("Vserialno", OracleDbType.Varchar2).Value = Vserialno;
            com.Parameters.Add("Vconsultantid", OracleDbType.Varchar2).Value = Vconsultantid;
            com.Parameters.Add("Vtestid", OracleDbType.Varchar2).Value = Vtestid;
            com.Parameters.Add("Vcharges", OracleDbType.Varchar2).Value = Vcharges;
            com.Parameters.Add("Vlramount", OracleDbType.Varchar2).Value = Vlramount;
            com.Parameters.Add("Vrecoveryamount", OracleDbType.Varchar2).Value = Vrecoveryamount;
            com.Parameters.Add("Vuser", OracleDbType.Varchar2).Value = UserInfo.UserId;
            com.Parameters.Add("Vterminalid", OracleDbType.Varchar2).Value = SoftwareInfo.Terminal;
            com.Parameters.Add("Vstatus", OracleDbType.Varchar2).Value = Vstatus;
            com.Parameters.Add("Vdelivery", OracleDbType.Varchar2).Value = Vdelivery;
            com.ExecuteNonQuery();

            Saved = true;
            return Saved;
        }
        public static bool roomcharges_add_edit(string Vinpbillid, string Vserialno, string Vroomtypeid, string Vcharges, DateTime Vdatefrom, DateTime Vdateto, string Vdays, string Vstatus)
        {

            bool Saved = false;
            OracleCommand com = new OracleCommand("roomcharges_add_edit", clsConnection.con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add("Vinpbillid", OracleDbType.Varchar2).Value = Vinpbillid;
            com.Parameters.Add("Vserialno", OracleDbType.Varchar2).Value = Vserialno;
            com.Parameters.Add("Vroomtypeid", OracleDbType.Varchar2).Value = Vroomtypeid;
            com.Parameters.Add("Vcharges", OracleDbType.Varchar2).Value = Vcharges;
            com.Parameters.Add("Vdatefrom", OracleDbType.Date).Value = Vdatefrom;
            com.Parameters.Add("Vdateto", OracleDbType.Date).Value = Vdateto;
            com.Parameters.Add("Vdays", OracleDbType.Varchar2).Value = Vdays;
            com.Parameters.Add("Vuser", OracleDbType.Varchar2).Value = UserInfo.UserId;
            com.Parameters.Add("Vterminalid", OracleDbType.Varchar2).Value = SoftwareInfo.Terminal;
            com.Parameters.Add("Vstatus", OracleDbType.Varchar2).Value = Vstatus;
            com.ExecuteNonQuery();
            Saved = true;
            return Saved;
        }
        public static bool misccharges_add_edit(string Vinpbillid, string Vserialno, string Vmiscdesc, string Vcharges, string Vstatus)
        {

            bool Saved = false;
            OracleCommand com = new OracleCommand("misccharges_add_edit", clsConnection.con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add("Vinpbillid", OracleDbType.Varchar2).Value = Vinpbillid;
            com.Parameters.Add("Vserialno", OracleDbType.Varchar2).Value = Vserialno;
            com.Parameters.Add("Vmiscdesc", OracleDbType.Varchar2).Value = Vmiscdesc;
            com.Parameters.Add("Vcharges", OracleDbType.Varchar2).Value = Vcharges;
            com.Parameters.Add("Vuser", OracleDbType.Varchar2).Value = UserInfo.UserId;
            com.Parameters.Add("Vterminalid", OracleDbType.Varchar2).Value = SoftwareInfo.Terminal;
            com.Parameters.Add("Vstatus", OracleDbType.Varchar2).Value = Vstatus;
            com.ExecuteNonQuery();

            Saved = true;
            return Saved;
        }
        public static bool surgerycharges_add_edit(string Vinpbillid, string Vserialno, string Vconsultantid, string Vtestid, string Vcharges, string Vstatus, string Vconsultantid2, string Vsurgery, string Vanaesthetist, string Votfixed, string Vrecovery, string Vnitrous)
        {

            bool Saved = false;
            OracleCommand com = new OracleCommand("surgerycharges_add_edit", clsConnection.con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add("Vinpbillid", OracleDbType.Varchar2).Value = Vinpbillid;
            com.Parameters.Add("Vserialno", OracleDbType.Varchar2).Value = Vserialno;
            com.Parameters.Add("Vconsultantid", OracleDbType.Varchar2).Value = Vconsultantid;
            com.Parameters.Add("Vtestid", OracleDbType.Varchar2).Value = Vtestid;
            com.Parameters.Add("Vcharges", OracleDbType.Varchar2).Value = Vcharges;
            com.Parameters.Add("Vuser", OracleDbType.Varchar2).Value = UserInfo.UserId;
            com.Parameters.Add("Vterimnalid", OracleDbType.Varchar2).Value = SoftwareInfo.Terminal;
            com.Parameters.Add("Vstatus", OracleDbType.Varchar2).Value = Vstatus;
            com.Parameters.Add("Vconsultantid2", OracleDbType.Varchar2).Value = Vconsultantid2;
            com.Parameters.Add("Vsurgery", OracleDbType.Varchar2).Value = Vsurgery;
            com.Parameters.Add("Vanaesthetist", OracleDbType.Varchar2).Value = Vanaesthetist;
            com.Parameters.Add("Votfixed", OracleDbType.Varchar2).Value = Votfixed;
            com.Parameters.Add("Vrecovery", OracleDbType.Varchar2).Value = Vrecovery;
            com.Parameters.Add("Vnitrous", OracleDbType.Varchar2).Value = Vnitrous;

            com.ExecuteNonQuery();

            Saved = true;
            return Saved;
        }
        public static bool consultantcharges_add_edit(string Vinpbillid, string Vserialno, string Vconsname, string Vcharges, string Vvisits, string Vstatus)

        {

            bool Saved = false;
            OracleCommand com = new OracleCommand("consultantcharges_add_edit", clsConnection.con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add("Vinpbillid", OracleDbType.Varchar2).Value = Vinpbillid;
            com.Parameters.Add("Vserialno", OracleDbType.Varchar2).Value = Vserialno;
            com.Parameters.Add("Vconsname", OracleDbType.Varchar2).Value = Vconsname;
            com.Parameters.Add("Vcharges", OracleDbType.Varchar2).Value = Vcharges;
            com.Parameters.Add("Vvisits", OracleDbType.Varchar2).Value = Vvisits;
            com.Parameters.Add("Vuser", OracleDbType.Varchar2).Value = UserInfo.UserId;
            com.Parameters.Add("Vterimnalid", OracleDbType.Varchar2).Value = SoftwareInfo.Terminal;
            com.Parameters.Add("Vstatus", OracleDbType.Varchar2).Value = Vstatus;
            com.ExecuteNonQuery();

            Saved = true;
            return Saved;
        }
        public static bool ipdbilling_add_edit(string Vserialno, string Vpharmacy, string Vdiscount, string Vdischarge, string Vremarks,
            string Vtotdiscount, DateTime Vdischargedate, string Vispackage, string Vpackageid, string Vpackageamount, string Vstatus,
            string zktDate, string zktaddedby, DateTime Vnextappointmentdate, string discount2, string discount3)
        {

            string zktaddedby2 = discount2 == "0" ? null : UserInfo.UserId;
            string zktaddedby3 = discount3 == "0" ? null : UserInfo.UserId;

            bool Saved = false;
            OracleCommand com = new OracleCommand("ipdbilling_add_edit_New", clsConnection.con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add("Vserialno", OracleDbType.Varchar2).Value = Vserialno;
            com.Parameters.Add("Vpharmacy", OracleDbType.Varchar2).Value = Vpharmacy;
            com.Parameters.Add("Vdiscount", OracleDbType.Varchar2).Value = Vdiscount;
            com.Parameters.Add("Vdischarge", OracleDbType.Varchar2).Value = Vdischarge;
            com.Parameters.Add("Vremarks", OracleDbType.Varchar2).Value = Vremarks;
            com.Parameters.Add("Vtotdiscount", OracleDbType.Varchar2).Value = Vtotdiscount;
            com.Parameters.Add("Vdischargedate", OracleDbType.Date).Value = Vdischargedate;
            com.Parameters.Add("Vispackage", OracleDbType.Varchar2).Value = Vispackage;
            com.Parameters.Add("Vpackageid", OracleDbType.Varchar2).Value = Vpackageid;
            com.Parameters.Add("Vpackageamount", OracleDbType.Varchar2).Value = Vpackageamount;
            com.Parameters.Add("Vuser", OracleDbType.Varchar2).Value = UserInfo.UserId;
            com.Parameters.Add("Vterminalid", OracleDbType.Varchar2).Value = SoftwareInfo.Terminal;
            com.Parameters.Add("Vstatus", OracleDbType.Varchar2).Value = Vstatus;
            com.Parameters.Add("VzakatAddDate", OracleDbType.Varchar2).Value = zktDate;
            com.Parameters.Add("VzakatAddBy", OracleDbType.Varchar2).Value = zktaddedby;
            com.Parameters.Add("Vnextappointmentdate", OracleDbType.Date).Value = Vnextappointmentdate;

            com.Parameters.Add("VZakatdiscount2", OracleDbType.Varchar2).Value = discount2;
            com.Parameters.Add("VZakatdate2", OracleDbType.Date).Value = discount2 == "0" ? DBNull.Value : (object)DateTime.Now;
            com.Parameters.Add("VZakatby2", OracleDbType.Varchar2).Value = zktaddedby2;

            com.Parameters.Add("VZakatdiscount3", OracleDbType.Varchar2).Value = discount3;
            com.Parameters.Add("VZakatdate3", OracleDbType.Date).Value = discount3 == "0" ? DBNull.Value : (object)DateTime.Now;
            com.Parameters.Add("VZakatby3", OracleDbType.Varchar2).Value = zktaddedby3;

            com.ExecuteNonQuery();
            Saved = true;
            return Saved;
        }
        public static bool testreportparameter_add_edit(string Vid, string Vtitle, string Vapproxresult, string Vrangenewborn, string Vrange1mto1y, string Vrange1yto14y, string Vrange14yabove, string Vunit, string Vremarks, string Vtestid, string Vtestparametercustomheading, string Visheading, string Vuser, string Vstatus)
        {

            bool Saved = false;
            OracleCommand com = new OracleCommand("testreportparameter_add_edit", clsConnection.con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add("Vid", OracleDbType.Varchar2).Value = Vid;
            com.Parameters.Add("Vtitle", OracleDbType.Varchar2).Value = Vtitle;
            com.Parameters.Add("Vapproxresult", OracleDbType.Varchar2).Value = Vapproxresult;
            com.Parameters.Add("Vrangenewborn", OracleDbType.Varchar2).Value = Vrangenewborn;
            com.Parameters.Add("Vrange1mto1y", OracleDbType.Varchar2).Value = Vrange1mto1y;
            com.Parameters.Add("Vrange1yto14y", OracleDbType.Varchar2).Value = Vrange1yto14y;
            com.Parameters.Add("Vrange14yabove", OracleDbType.Varchar2).Value = Vrange14yabove;
            com.Parameters.Add("Vunit", OracleDbType.Varchar2).Value = Vunit;
            com.Parameters.Add("Vremarks", OracleDbType.Varchar2).Value = Vremarks;
            com.Parameters.Add("Vtestid", OracleDbType.Varchar2).Value = Vtestid;
            com.Parameters.Add("Vtestparametercustomheading", OracleDbType.Varchar2).Value = Vtestparametercustomheading;
            com.Parameters.Add("Visheading", OracleDbType.Varchar2).Value = Visheading;
            com.Parameters.Add("Vuser", OracleDbType.Varchar2).Value = UserInfo.UserId;
            com.Parameters.Add("Vstatus", OracleDbType.Varchar2).Value = Vstatus;
            com.ExecuteNonQuery();

            Saved = true;
            return Saved;
        }
        public static bool LabTestremarks_add_edit(string Vid, string Vdepartmentid, string Vremarks)
        {

            bool Saved = false;
            OracleCommand com = new OracleCommand("LabTestremarks_add_edit", clsConnection.con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add("Vid", OracleDbType.Varchar2).Value = Vid;
            com.Parameters.Add("Vdepartmentid", OracleDbType.Varchar2).Value = Vdepartmentid;
            com.Parameters.Add("Vremarks", OracleDbType.Varchar2).Value = Vremarks;

            com.ExecuteNonQuery();

            Saved = true;
            return Saved;
        }
        public static bool updatetestcatagory(string VID, string VTITLE, string VISACTIVE, string VFIXEDRATE, string VAUTOTOKEN, string VCONTACTREQUIRED, string VAgeRequired, string VResForDupToken)
        {
            bool Saved = false;
            OracleCommand com = new OracleCommand("updatetestcatagory1", clsConnection.con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add("VID", OracleDbType.Varchar2).Value = VID;
            com.Parameters.Add("VTITLE", OracleDbType.Varchar2).Value = VTITLE;
            com.Parameters.Add("VISACTIVE", OracleDbType.Varchar2).Value = VISACTIVE;
            com.Parameters.Add("VFIXEDRATE", OracleDbType.Varchar2).Value = VFIXEDRATE;
            com.Parameters.Add("VAUTOTOKEN", OracleDbType.Varchar2).Value = VAUTOTOKEN;
            com.Parameters.Add("VCONTACTREQUIRED", OracleDbType.Varchar2).Value = VCONTACTREQUIRED;
            com.Parameters.Add("VAgeRequired", OracleDbType.Varchar2).Value = VAgeRequired;
            com.Parameters.Add("VResForDupToken", OracleDbType.Varchar2).Value = VResForDupToken;


            com.ExecuteNonQuery();
            Saved = true;
            return Saved;
        }

        public static DataTable RefundInfo(string regAlpha, string regNum)
        {

            DataTable dt = new DataTable();
            try
            {
                /// OracleCommand DbCommand = new OracleCommand("Load_ipdrefundinfo1", clsConnection.con);
                OracleCommand DbCommand = new OracleCommand("load_ipdrefundinfo1_U", clsConnection.con);
                DbCommand.CommandType = CommandType.StoredProcedure;
                DbCommand.Parameters.Add("VregAlpha", OracleDbType.Varchar2).Value = regAlpha;
                DbCommand.Parameters.Add("VregNum", OracleDbType.Varchar2).Value = regNum;
                DbCommand.Parameters.Add("retval", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                OracleDataAdapter Adapter = new OracleDataAdapter(DbCommand);
                Adapter.Fill(dt);
                Adapter.Dispose();


                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Rep_IPDRefundAmount");
                return dt;
            }

        }



        public static bool UpdateIPDRefundAmount(string refVNo, string Vregnoalpha,
            string RefundStatus, DateTime dtpRrfundDate, DateTime dtpRefundTime, string RefundAmount,
            string RecePersonName, string Relation, string ContactNumber, string Remarks, string AddmissionRegNo)
        {
            try
            {
                bool Saved = false;
                OracleCommand com = new OracleCommand("updateinpatientrefundamount1_u", clsConnection.con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("VrefVNo", OracleDbType.Varchar2).Value = refVNo;
                com.Parameters.Add("Vregnoalpha", OracleDbType.Varchar2).Value = Vregnoalpha;
                com.Parameters.Add("Vadmissionid", OracleDbType.Varchar2).Value = AddmissionRegNo;
                com.Parameters.Add("Vremarks", OracleDbType.Varchar2).Value = Remarks;
                com.Parameters.Add("Vrefunddate", OracleDbType.Date).Value = dtpRrfundDate;
                com.Parameters.Add("Vrefundtime", OracleDbType.Date).Value = dtpRefundTime;
                com.Parameters.Add("Vrefundamount", OracleDbType.Int32).Value = RefundAmount;
                com.Parameters.Add("Vrefundperson", OracleDbType.Varchar2).Value = RecePersonName;
                com.Parameters.Add("Vrelationwithpatient", OracleDbType.Varchar2).Value = Relation;
                com.Parameters.Add("Vcontactnumber", OracleDbType.Varchar2).Value = ContactNumber;
                com.Parameters.Add("VrefundAmount_Yes_No", OracleDbType.Varchar2).Value = RefundStatus;
                com.Parameters.Add("Vrefunduser", OracleDbType.Varchar2).Value = UserInfo.UserId;


                int a = com.ExecuteNonQuery();

                Saved = true;
                return Saved;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public static bool packagesdetail_Add_Edit(string VID, string VPACKAGEDESCRIPTION, string VAMOUNT, string VSTATUS, string Vpackage_id)
        {
            bool Saved = false;
            OracleCommand com = new OracleCommand("packagesdetail_Add_Edit", clsConnection.con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add("VID", OracleDbType.Varchar2).Value = VID;
            com.Parameters.Add("VPACKAGEDESCRIPTION", OracleDbType.Varchar2).Value = VPACKAGEDESCRIPTION;
            com.Parameters.Add("VAMOUNT", OracleDbType.Varchar2).Value = VAMOUNT;
            com.Parameters.Add("VSTATUS", OracleDbType.Varchar2).Value = VSTATUS;
            com.Parameters.Add("VUSER", OracleDbType.Varchar2).Value = UserInfo.UserId;
            com.Parameters.Add("VTERMINALID", OracleDbType.Varchar2).Value = SoftwareInfo.Terminal;
            com.Parameters.Add("Vpackage_id", OracleDbType.Varchar2).Value = Vpackage_id;

            com.ExecuteNonQuery();
            Saved = true;
            return Saved;
        }

        //basit 
        public static DataTable Rep_AdvanceReceipt1(string Vadmissionid, string VID)
        {
            DataTable dt = new DataTable();

            try
            {

                OracleCommand DbCommand = new OracleCommand("rep_inpbillAdvancRecpt1", clsConnection.con);
                DbCommand.CommandType = CommandType.StoredProcedure;



                DbCommand.Parameters.Add("Vadmissionid", OracleDbType.Varchar2).Value = Vadmissionid;
                DbCommand.Parameters.Add("VID", OracleDbType.Varchar2).Value = VID;
                DbCommand.Parameters.Add("retval", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                OracleDataAdapter Adapter = new OracleDataAdapter(DbCommand);
                Adapter.Fill(dt);
                Adapter.Dispose();

                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Rep_AdvanceReceipt");
                return dt;
            }
        }
        //BASIT TEST WAIT
        public static DataTable Rep_AdvanceReceipt(string Vadmissionid, string VadvancId)
        {
            DataTable dt = new DataTable();

            try
            {

                OracleCommand DbCommand = new OracleCommand("rep_inpbillAdvancRecpt", clsConnection.con);
                DbCommand.CommandType = CommandType.StoredProcedure;
                DbCommand.Parameters.Add("Vadmissionid", OracleDbType.Varchar2).Value = Vadmissionid;
                DbCommand.Parameters.Add("VadvancId", OracleDbType.Varchar2).Value = VadvancId;
                DbCommand.Parameters.Add("retval", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                OracleDataAdapter Adapter = new OracleDataAdapter(DbCommand);
                Adapter.Fill(dt);
                Adapter.Dispose();

                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Rep_AdvanceReceipt");
                return dt;
            }
        }







        //basit 
        public static bool ipdbilling_Update(string Vserialno)
        {

            bool Saved = false;
            OracleCommand com = new OracleCommand("ipdbilling_update", clsConnection.con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add("Vserialno", OracleDbType.Varchar2).Value = Vserialno;
            //OracleParameter Retparam = com.Parameters.Add("RetBillNo", OracleDbType.Varchar2, 8);
            //Retparam.Direction = ParameterDirection.Output;

            com.ExecuteNonQuery();

            Saved = true;
            return Saved;

        }

        //Load_CurrentCashStatus
        public static DataTable Load_CurrentCashStatus(string VUserSession)
        {
            DataTable dt = new DataTable();
            try
            {
                OracleCommand DbCommand = new OracleCommand("sp_CurrentCashStatus", clsConnection.con);
                DbCommand.CommandType = CommandType.StoredProcedure;
                DbCommand.Parameters.Add("VUserSesion", OracleDbType.Varchar2).Value = VUserSession;
                DbCommand.Parameters.Add("retval", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                OracleDataAdapter Adapter = new OracleDataAdapter(DbCommand);
                Adapter.Fill(dt);
                Adapter.Dispose();
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Rep_CurrentCashStatus");
                return dt;
            }
        }



        public static bool cardiography_add_edit(
            ref int? p_id,
            DateTime vdate,
            int type,
            string patientname,
            string age,
            string slipNo,
            string echoNo,
            string tapeNo,
            decimal? height,
            decimal? weight,
            string clinicalDiagnosis,
            string refPhysician,
            decimal? lvSystolic,
            decimal? lvDiastolic,
            decimal? lvSeptalThickness,
            decimal? leftAtrium,
            decimal? rightVentricle,
            decimal? ef,
            decimal? postWallThickness,
            decimal? aortic,
            decimal? aorticValveOpening,
            string description,
            string createdBy,
            DateTime createdTime,
            int status,
            string sessionId,
            string description1,
            string description2
            )
        {
            bool saved = false;

            using (OracleCommand com = new OracleCommand("cardiography_add_edit", clsConnection.con))
            {
                com.CommandType = CommandType.StoredProcedure;
                OracleParameter pIdParam = new OracleParameter("p_id", OracleDbType.Int32);
                pIdParam.Direction = ParameterDirection.InputOutput;
                if (p_id.HasValue)
                    pIdParam.Value = p_id.Value;
                else
                    pIdParam.Value = DBNull.Value;
                com.Parameters.Add(pIdParam);

                com.Parameters.Add("p_vdate", OracleDbType.Date).Value = vdate;
                com.Parameters.Add("p_type", OracleDbType.Int32).Value = type;
                com.Parameters.Add("p_patientName", OracleDbType.Varchar2).Value = patientname;
                com.Parameters.Add("p_age", OracleDbType.Varchar2).Value = age;
                com.Parameters.Add("p_slipno", OracleDbType.Varchar2).Value = slipNo;
                com.Parameters.Add("p_echono", OracleDbType.Varchar2).Value = echoNo;
                com.Parameters.Add("p_tapeno", OracleDbType.Varchar2).Value = tapeNo;
                com.Parameters.Add("p_height", OracleDbType.Decimal).Value = (object)height ?? DBNull.Value;
                com.Parameters.Add("p_weight", OracleDbType.Decimal).Value = (object)weight ?? DBNull.Value;
                com.Parameters.Add("p_clinical_diagnosis", OracleDbType.Varchar2).Value = clinicalDiagnosis;
                com.Parameters.Add("p_ref_physician", OracleDbType.Varchar2).Value = refPhysician;
                com.Parameters.Add("p_lv_systolic", OracleDbType.Decimal).Value = (object)lvSystolic ?? DBNull.Value;
                com.Parameters.Add("p_lv_diastolic", OracleDbType.Decimal).Value = (object)lvDiastolic ?? DBNull.Value;
                com.Parameters.Add("p_lv_spetal_thickness", OracleDbType.Decimal).Value = (object)lvSeptalThickness ?? DBNull.Value;
                com.Parameters.Add("p_left_atrium", OracleDbType.Decimal).Value = (object)leftAtrium ?? DBNull.Value;
                com.Parameters.Add("p_right_ventricle", OracleDbType.Decimal).Value = (object)rightVentricle ?? DBNull.Value;
                com.Parameters.Add("p_ef", OracleDbType.Decimal).Value = (object)ef ?? DBNull.Value;
                com.Parameters.Add("p_post_wall_thickness", OracleDbType.Decimal).Value = (object)postWallThickness ?? DBNull.Value;
                com.Parameters.Add("p_aortic", OracleDbType.Decimal).Value = (object)aortic ?? DBNull.Value;
                com.Parameters.Add("p_aortic_valve_opening", OracleDbType.Decimal).Value = (object)aorticValveOpening ?? DBNull.Value;
                com.Parameters.Add("p_description", OracleDbType.Clob).Value = description ?? string.Empty;
                com.Parameters.Add("p_createdby", OracleDbType.Varchar2).Value = createdBy;
                com.Parameters.Add("p_createdtime", OracleDbType.Date).Value = createdTime;
                com.Parameters.Add("p_status", OracleDbType.Int32).Value = status;
                com.Parameters.Add("p_sessionid", OracleDbType.Varchar2).Value = sessionId;
                com.Parameters.Add("p_description1", OracleDbType.Clob).Value = description1 ?? string.Empty;
                com.Parameters.Add("p_description2", OracleDbType.Clob).Value = description2 ?? string.Empty;

                com.ExecuteNonQuery();
                saved = true;
            }

            return saved;
        }


    }
}
