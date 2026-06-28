using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using Oracle.DataAccess.Client; 
namespace ERP 
{
    class ReportQuery
    {
        internal  static DataTable OPDReceipt(string ReceiptNo)
        {
            string sql = "SELECT tokenno,vdate,get_OPDCatagory(catagoryid) CatagoryTitle  ,get_opdcatagoryReportType(catagoryid) ReportType , consultantid, get_ConsultantName(consultantid) ConsultantName,memberid,gender,patienttitle || patientname  patientname,age||' '||ageunit age,netamount,contactno,get_patienttype(patienttype) patienttype,get_ReferenceName(referenceid) ReferenceName,remarks,grossamount,discount,netamount,partialamount,netbalance,ispartial,createdby,createdtime,electricitycharges,get_ConsultantName(laboratoryConsultantid) laboratoryConsultantName,noofPrint  FROM opdreceipt WHERE receiptno = '" + ReceiptNo + "'";
            DataTable dt = Query.getData(sql);
            return dt;
        }
        internal static DataTable LabReportResult(string SlipNo,string DepartmentId)
        {

            ///AND Trunc(createdtime) > '22 july 2020 ' -- Tauqeer 
            string sql = "SELECT res.title test, res.result, res.unit, res.approxresult NormalRange,res.ipdopd as IO FROM labreportresult res WHERE res.reportno = '" + SlipNo + "' AND res.departmentid = '" + DepartmentId + "' and status = 0 AND Trunc(createdtime) > '22 july 2020 ' order by To_number(testid)";
            DataTable dt = Query.getData(sql);
            return dt;
        }

        internal static DataTable OPDTestReceipt(string ReceiptNo)
        {

            string sql = "SELECT get_TestTitle(fktestid) TestName,amount FROM opdreceipttestdetail WHERE status = 0 and fkreceiptid = '" + ReceiptNo + "'";
            DataTable dt = Query.getData(sql);
            return dt;
        }
        internal static DataTable ClosingSummarySessionWise(string SessionId)
        {
            DataTable dt = new DataTable();
            OracleCommand comm = new OracleCommand("rep_closingsummarys_voucher", clsConnection .con );
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add("VSessionId", OracleDbType.Varchar2).Value = SessionId;
            comm.Parameters.Add("retval", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            //comm.Parameters["retval"].Direction = ParameterDirection.Output;


            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = comm;// new OracleCommand(sql, Connection.Conn_ecyear);
            adapter.Fill(dt);
            adapter.Dispose();
            return dt;
      
        }
        internal static DataTable get_session_IPDrefundInfo(string SessionId)
        {
            DataTable dt = new DataTable();
            OracleCommand comm = new OracleCommand("session_IPDrefundInfo", clsConnection.con);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add("VSessionId", OracleDbType.Varchar2).Value = SessionId;
            comm.Parameters.Add("retval", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            //comm.Parameters["retval"].Direction = ParameterDirection.Output;


            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = comm;// new OracleCommand(sql, Connection.Conn_ecyear);
            adapter.Fill(dt);
            adapter.Dispose();
            return dt;

        }
        internal static DataTable allUserClosingSummary(DateTime VFDate, DateTime VTDate)
        {
            DataTable dt = new DataTable();
            OracleCommand comm = new OracleCommand("rep_allUserClosingSummary1", clsConnection.con);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add("VFdate", OracleDbType.Date).Value = VFDate ;
            comm.Parameters.Add("VTdate", OracleDbType.Date).Value = VTDate;
            comm.Parameters.Add("retval", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            //comm.Parameters["retval"].Direction = ParameterDirection.Output;


            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = comm;// new OracleCommand(sql, Connection.Conn_ecyear);
            adapter.Fill(dt);
            adapter.Dispose();
            return dt;

        }
        internal static DataTable MemberInvoiceDetail(DateTime FDate, DateTime TDate,string MemberId,string status,string Vgender)
        {
            DataTable dt = new DataTable();
            OracleCommand comm = new OracleCommand("rep_MemberInvoices", clsConnection.con);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add("VFdate", OracleDbType.Date).Value = FDate ;
            comm.Parameters.Add("VTdate", OracleDbType.Date).Value = TDate ;
            comm.Parameters.Add("VMemberId", OracleDbType.Varchar2).Value = MemberId;
            comm.Parameters.Add("VStatus", OracleDbType.Varchar2).Value = status ;
            comm.Parameters.Add("Vgender", OracleDbType.Varchar2).Value = Vgender;

            comm.Parameters.Add("retval", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            //comm.Parameters["retval"].Direction = ParameterDirection.Output;


            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = comm;// new OracleCommand(sql, Connection.Conn_ecyear);
            adapter.Fill(dt);
            adapter.Dispose();
            return dt;

        }


        internal static DataTable ReferenceInvoiceDetail(DateTime FDate, DateTime TDate,string ReferenceId)
        {
            DataTable dt = new DataTable();
            OracleCommand comm = new OracleCommand("rep_referenceinvoices1", clsConnection.con);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add("VFdate", OracleDbType.Date).Value = FDate;
            comm.Parameters.Add("VTdate", OracleDbType.Date).Value = TDate;
            comm.Parameters.Add("VReferenceId", OracleDbType.Varchar2).Value = ReferenceId;
            comm.Parameters.Add("retval", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = comm;
            adapter.Fill(dt);
            adapter.Dispose();
            return dt;
        }

        internal static DataTable rep_referenceinvoices1_Same(DateTime FDate, DateTime TDate, string ReferenceId)
        {
            DataTable dt = new DataTable();
            OracleCommand comm = new OracleCommand("rep_referenceinvoices1_Same", clsConnection.con);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add("VFdate", OracleDbType.Date).Value = FDate;
            comm.Parameters.Add("VTdate", OracleDbType.Date).Value = TDate;
            comm.Parameters.Add("VReferenceId", OracleDbType.Varchar2).Value = ReferenceId;
            comm.Parameters.Add("retval", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = comm;
            adapter.Fill(dt);
            adapter.Dispose();
            return dt;
        }
        internal static DataTable IPD_OPD_IncomeSummary(DateTime FDate, DateTime TDate)
        {
            DataTable dt = new DataTable();
            OracleCommand comm = new OracleCommand("rep_IPD_OPD_IncomeSummary1", clsConnection.con);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add("VFdate", OracleDbType.Date).Value = FDate;
            comm.Parameters.Add("VTdate", OracleDbType.Date).Value = TDate;
            comm.Parameters.Add("retval", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = comm;
            adapter.Fill(dt);
            adapter.Dispose();
            return dt;
        }

        internal static DataTable Ipd_opd_LessUnPaidsummary(DateTime FDate, DateTime TDate)
        {
            DataTable dt = new DataTable();
            OracleCommand comm = new OracleCommand("ipd_opd_LessUnPaidsummary", clsConnection.con);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add("VFdate", OracleDbType.Date).Value = FDate;
            comm.Parameters.Add("VTdate", OracleDbType.Date).Value = TDate;
            comm.Parameters.Add("retval", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = comm;
            adapter.Fill(dt);
            adapter.Dispose();
            return dt;
        }

        internal static DataTable rep_consultantShareDetail(DateTime FDate, DateTime TDate)
        {
            DataTable dt = new DataTable();
            OracleCommand comm = new OracleCommand("inp_con_sur_hospitalshare", clsConnection.con);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add("VFDate", OracleDbType.Date).Value = FDate;
            comm.Parameters.Add("VTdate", OracleDbType.Date).Value = TDate;
            comm.Parameters.Add("retval", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = comm;// new OracleCommand(sql, Connection.Conn_ecyear);
            adapter.Fill(dt);
            adapter.Dispose();
            return dt;
        }
        internal static DataTable pr_surgerygroup_report(DateTime FDate, DateTime TDate)
        {
            DataTable dt = new DataTable();
            OracleCommand comm = new OracleCommand("pr_surgerygroup_report", clsConnection.con);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add("vfromdate", OracleDbType.Date).Value = FDate;
            comm.Parameters.Add("vtodate", OracleDbType.Date).Value = TDate;
            comm.Parameters.Add("retval", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = comm;// new OracleCommand(sql, Connection.Conn_ecyear);
            adapter.Fill(dt);
            adapter.Dispose();
            return dt;
        }
        internal static DataTable pr_doctorWise_sugeryreport(DateTime FDate, DateTime TDate,string package)
        {
            DataTable dt = new DataTable();
            OracleCommand comm = new OracleCommand("pr_doctorWise_sugeryreport", clsConnection.con);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add("vfromdate", OracleDbType.Date).Value = FDate;
            comm.Parameters.Add("vtodate", OracleDbType.Date).Value = TDate;
            comm.Parameters.Add("vpackageid", OracleDbType.Varchar2).Value = package == "All" ? "0" : package;
            comm.Parameters.Add("retval", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = comm;// new OracleCommand(sql, Connection.Conn_ecyear);
            adapter.Fill(dt);
            adapter.Dispose();
            return dt;
        }
        internal static DataTable OPD_FundUtilization(DateTime FDate, DateTime TDate, string gender)
        {
            DataTable dt = new DataTable();
            OracleCommand comm = new OracleCommand("opd_fundutilization1", clsConnection.con);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add("vfromdate", OracleDbType.Date).Value = FDate;
            comm.Parameters.Add("vtodate", OracleDbType.Date).Value = TDate;
            comm.Parameters.Add("VGender", OracleDbType.Varchar2).Value = gender;
            comm.Parameters.Add("retval", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = comm;// new OracleCommand(sql, Connection.Conn_ecyear);
            adapter.Fill(dt);
            adapter.Dispose();
            return dt;
        }
        internal static DataTable IPD_FundUtilization(DateTime FDate, DateTime TDate, string gender)
        {
            DataTable dt = new DataTable();
            OracleCommand comm = new OracleCommand("ipd_fundutilization1", clsConnection.con);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add("vfromdate", OracleDbType.Date).Value = FDate;
            comm.Parameters.Add("vtodate", OracleDbType.Date).Value = TDate;
            comm.Parameters.Add("VGender", OracleDbType.Varchar2).Value = gender;
            comm.Parameters.Add("retval", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = comm;// new OracleCommand(sql, Connection.Conn_ecyear);
            adapter.Fill(dt);
            adapter.Dispose();
            return dt;
        }

        internal static DataTable OPD_CashInHand(DateTime FDate, DateTime TDate)
        {
            DataTable dt = new DataTable();
            OracleCommand comm = new OracleCommand("opd_cashinhand", clsConnection.con);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add("vfromdate", OracleDbType.Date).Value = FDate;
            comm.Parameters.Add("vtodate", OracleDbType.Date).Value = TDate;
            comm.Parameters.Add("retval", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = comm;// new OracleCommand(sql, Connection.Conn_ecyear);
            adapter.Fill(dt);
            adapter.Dispose();
            return dt;
        }

        internal static DataTable Ipd_Opd_ClosingSummary(DateTime FDate, DateTime TDate)
        {
            DataTable dt = new DataTable();
            OracleCommand comm = new OracleCommand("Ipd_Opd_ClosingSummary", clsConnection.con);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add("vfromdate", OracleDbType.Date).Value = FDate;
            comm.Parameters.Add("vtodate", OracleDbType.Date).Value = TDate;
            comm.Parameters.Add("retval", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = comm;// new OracleCommand(sql, Connection.Conn_ecyear);
            adapter.Fill(dt);
            adapter.Dispose();
            return dt;
        }

        internal static DataTable IPD_CashInHand(DateTime FDate, DateTime TDate)
        {
            DataTable dt = new DataTable();
            OracleCommand comm = new OracleCommand("ipd_cashinhand", clsConnection.con);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add("vfromdate", OracleDbType.Date).Value = FDate;
            comm.Parameters.Add("vtodate", OracleDbType.Date).Value = TDate;
            comm.Parameters.Add("retval", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = comm;// new OracleCommand(sql, Connection.Conn_ecyear);
            adapter.Fill(dt);
            adapter.Dispose();
            return dt;
        }

        internal static DataTable Discrepancies_Voucher()
        {
            DataTable dt = new DataTable();
            OracleCommand comm = new OracleCommand("rep_voucherdes", clsConnection.con);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add("retval", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = comm;// new OracleCommand(sql, Connection.Conn_ecyear);
            adapter.Fill(dt);
            adapter.Dispose();
            return dt;
        }
        internal static DataTable OPD_ConsultantSummary(DateTime FDate, DateTime TDate)
        {
            DataTable dt = new DataTable();
            OracleCommand comm = new OracleCommand("rep_opdconsultantwiseSummary", clsConnection.con);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add("VFdate", OracleDbType.Date).Value = FDate;
            comm.Parameters.Add("VTdate", OracleDbType.Date).Value = TDate;
            comm.Parameters.Add("retval", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            //comm.Parameters["retval"].Direction = ParameterDirection.Output;


            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = comm;// new OracleCommand(sql, Connection.Conn_ecyear);
            adapter.Fill(dt);
            adapter.Dispose();
            return dt;

        }
        internal static DataTable OPD_ConsultantLedger(DateTime FDate, DateTime TDate, string Consultant)
        {
            DataTable dt = new DataTable();
            OracleCommand comm = new OracleCommand("rep_opdconsultantLedger", clsConnection.con);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add("VFdate", OracleDbType.Date).Value = FDate;
            comm.Parameters.Add("VTdate", OracleDbType.Date).Value = TDate;
            comm.Parameters.Add("Vconsultantid", OracleDbType.Varchar2).Value = Consultant == "All" ? "" : Consultant;            
            comm.Parameters.Add("retval", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            //comm.Parameters["retval"].Direction = ParameterDirection.Output;


            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = comm;// new OracleCommand(sql, Connection.Conn_ecyear);
            adapter.Fill(dt);
            adapter.Dispose();
            return dt;

        }
        internal static DataTable Net_IncomeSummary(DateTime FDate, DateTime TDate)
        {
            DataTable dt = new DataTable();
            OracleCommand comm = new OracleCommand("rep_NetIncomeSummary", clsConnection.con);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add("VFdate", OracleDbType.Date).Value = FDate;
            comm.Parameters.Add("VTdate", OracleDbType.Date).Value = TDate;
            comm.Parameters.Add("retval", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            //comm.Parameters["retval"].Direction = ParameterDirection.Output;


            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = comm;// new OracleCommand(sql, Connection.Conn_ecyear);
            adapter.Fill(dt);
            adapter.Dispose();
            return dt;

        }
        internal static DataTable Gross_IncomeSummary(DateTime FDate, DateTime TDate)
        {
            DataTable dt = new DataTable();
            OracleCommand comm = new OracleCommand("rep_GrossIncomeSummary", clsConnection.con);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add("VFdate", OracleDbType.Date).Value = FDate;
            comm.Parameters.Add("VTdate", OracleDbType.Date).Value = TDate;
            comm.Parameters.Add("retval", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            //comm.Parameters["retval"].Direction = ParameterDirection.Output;


            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = comm;// new OracleCommand(sql, Connection.Conn_ecyear);
            adapter.Fill(dt);
            adapter.Dispose();
            return dt;

        }
        internal static DataTable OPDCatagoryWiseDetail(DateTime FDate, DateTime TDate,string Catagory,string Vgender)
        {
            DataTable dt = new DataTable();
            OracleCommand comm = new OracleCommand("rep_opdCatagorywisedetail", clsConnection.con);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add("VFdate", OracleDbType.Date).Value = FDate;
            comm.Parameters.Add("VTdate", OracleDbType.Date).Value = TDate;
            comm.Parameters.Add("VCatagory", OracleDbType.Varchar2).Value = Catagory ;
            comm.Parameters.Add("Vgender", OracleDbType.Varchar2).Value = Vgender;
            comm.Parameters.Add("retval", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            //comm.Parameters["retval"].Direction = ParameterDirection.Output;


            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = comm;// new OracleCommand(sql, Connection.Conn_ecyear);
            adapter.Fill(dt);
            adapter.Dispose();
            return dt;

        }
        internal static DataTable AddmissionForm(string RegNo)
        {
            DataTable dt = new DataTable();
            OracleCommand comm = new OracleCommand("rep_AddmissionForm", clsConnection.con);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add("VRegNo", OracleDbType.Varchar2).Value = RegNo;
            comm.Parameters.Add("retval", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            //comm.Parameters["retval"].Direction = ParameterDirection.Output;


            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = comm;// new OracleCommand(sql, Connection.Conn_ecyear);
            adapter.Fill(dt);
            adapter.Dispose();
            return dt;

        }
        internal static DataTable OPDConsultantWiseDetail(DateTime FDate, DateTime TDate, string Consultant)
        {
            DataTable dt = new DataTable();
            OracleCommand comm = new OracleCommand("rep_opdconsultantwisedetail", clsConnection.con);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add("VFdate", OracleDbType.Date).Value = FDate;
            comm.Parameters.Add("VTdate", OracleDbType.Date).Value = TDate;
            comm.Parameters.Add("Vconsultantid", OracleDbType.Varchar2).Value = Consultant == "All" ? "" : Consultant;
            comm.Parameters.Add("retval", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            //comm.Parameters["retval"].Direction = ParameterDirection.Output;


            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = comm;// new OracleCommand(sql, Connection.Conn_ecyear);
            adapter.Fill(dt);
            adapter.Dispose();
            return dt;

        }
        internal static DataTable consultantsurgerydetail(DateTime FDate, DateTime TDate, string Consultant,string package)
        {
            DataTable dt = new DataTable();
            OracleCommand comm = new OracleCommand("rep_consultantsurgery", clsConnection.con);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add("Vfrom", OracleDbType.Date).Value = FDate;
            comm.Parameters.Add("Vto", OracleDbType.Date).Value = TDate;
            comm.Parameters.Add("Vconsid", OracleDbType.Varchar2).Value = Consultant == "All" ? "" : Consultant;
            comm.Parameters.Add("Vpackage", OracleDbType.Varchar2).Value = package == "All" ? "" : package;
            comm.Parameters.Add("retval", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            //comm.Parameters["retval"].Direction = ParameterDirection.Output;


            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = comm;// new OracleCommand(sql, Connection.Conn_ecyear);
            adapter.Fill(dt);
            adapter.Dispose();
            return dt;

        }

        internal static DataTable rep_allpatientDetial(string columns,string Consultant,string patient)
        {
            DataTable dt = new DataTable();
            OracleCommand comm = new OracleCommand("rep_allPatientDetail", clsConnection.con);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add("Vcols", OracleDbType.Varchar2).Value = columns;
            comm.Parameters.Add("Vconsid", OracleDbType.Varchar2).Value = Consultant == "All" ? "" : Consultant;
            comm.Parameters.Add("Vpatient", OracleDbType.Varchar2).Value = patient == "All" ? "" : patient;

            comm.Parameters.Add("retval", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            //comm.Parameters["retval"].Direction = ParameterDirection.Output;


            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = comm;// new OracleCommand(sql, Connection.Conn_ecyear);
            adapter.Fill(dt);
            adapter.Dispose();
            return dt;

        }


        internal static DataTable SubAddLessDetail(string SessionId)
        {
            DataTable dt = new DataTable();
            OracleCommand comm = new OracleCommand("rep_SubAddLessDetail_1", clsConnection.con);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add("VSessionId", OracleDbType.Varchar2).Value = SessionId;
            comm.Parameters.Add("retval", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            //comm.Parameters["retval"].Direction = ParameterDirection.Output;


            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = comm;// new OracleCommand(sql, Connection.Conn_ecyear);
            adapter.Fill(dt);
            adapter.Dispose();
            return dt;

        }
        internal static DataTable ClosingSummarySessionIPD(string SessionId)
        {
            DataTable dt = new DataTable();
            OracleCommand comm = new OracleCommand("teller_ipd_amount", clsConnection.con);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add("VSessionId", OracleDbType.Varchar2).Value = SessionId;
            comm.Parameters.Add("retval", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            //comm.Parameters["retval"].Direction = ParameterDirection.Output;


            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = comm;// new OracleCommand(sql, Connection.Conn_ecyear);
            adapter.Fill(dt);
            adapter.Dispose();
            return dt;

        }
        internal static DataTable SubCancelDetail(string SessionId)
        {
            DataTable dt = new DataTable();
            OracleCommand comm = new OracleCommand("rep_subCanceldetail", clsConnection.con);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add("VSessionId", OracleDbType.Varchar2).Value = SessionId;
            comm.Parameters.Add("retval", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            //comm.Parameters["retval"].Direction = ParameterDirection.Output;


            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = comm;// new OracleCommand(sql, Connection.Conn_ecyear);
            adapter.Fill(dt);
            adapter.Dispose();
            return dt;

        }
        internal static DataTable SubSupicios(string SessionId)
        {
            DataTable dt = new DataTable();
            OracleCommand comm = new OracleCommand("rep_subsupiciosTrans", clsConnection.con);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add("VSessionId", OracleDbType.Varchar2).Value = SessionId;
            comm.Parameters.Add("retval", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            //comm.Parameters["retval"].Direction = ParameterDirection.Output;


            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = comm;// new OracleCommand(sql, Connection.Conn_ecyear);
            adapter.Fill(dt);
            adapter.Dispose();
            return dt;

        }
         
        //basit 03-07-2020
        //13-01-2020 basit
        internal static DataTable InPatientBill(DateTime datefrom, DateTime dateto)
        {
            DataTable dt = new DataTable();
            OracleCommand comm = new OracleCommand("rep_PatientBill", clsConnection.con);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add("DateFrom", OracleDbType.Date).Value = datefrom;
            comm.Parameters.Add("DateTo", OracleDbType.Date).Value = dateto;
            comm.Parameters.Add("retval", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
 

            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = comm;// new OracleCommand(sql, Connection.Conn_ecyear);
            adapter.Fill(dt);
            adapter.Dispose();
            return dt;

        }

        //13-01-2020 basit
        internal static DataTable DischargedPatient(DateTime datefrom, DateTime dateto)
        {
            DataTable dt = new DataTable();

            OracleCommand comm = new OracleCommand("rep_dischargedpatient", clsConnection.con);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add("DateFrom", OracleDbType.Date).Value = datefrom;
            comm.Parameters.Add("DateTo", OracleDbType.Date).Value = dateto;
            comm.Parameters.Add("retval", OracleDbType.RefCursor).Direction = ParameterDirection.Output;


            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = comm;// new OracleCommand(sql, Connection.Conn_ecyear);
            adapter.Fill(dt);
            adapter.Dispose();
            return dt;
        }

        //13-01-2020 basit
        internal static DataTable patientduescharges(DateTime datefrom, DateTime dateto)
        {

            DataTable dt = new DataTable();
            OracleCommand comm = new OracleCommand("rep_dues_pending_amount", clsConnection.con);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add("DateFrom", OracleDbType.Date).Value = datefrom;
            comm.Parameters.Add("DateTo", OracleDbType.Date).Value = dateto;
            comm.Parameters.Add("retval", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
          


            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = comm;// new OracleCommand(sql, Connection.Conn_ecyear);
            adapter.Fill(dt);
            adapter.Dispose();
            return dt;


        }

        //13-01-2020 basit
        internal static DataTable ConsultantIPDSummary(DateTime datefrom, DateTime dateto)
        {
            DataTable dt = new DataTable();
            OracleCommand comm = new OracleCommand("rep_ConsultanIPDSummary", clsConnection.con);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add("DateFrom", OracleDbType.Date).Value = datefrom;
            comm.Parameters.Add("DateTo", OracleDbType.Date).Value = dateto;
            comm.Parameters.Add("retval", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            //comm.Parameters["retval"].Direction = ParameterDirection.Output;


            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = comm;// new OracleCommand(sql, Connection.Conn_ecyear);
            adapter.Fill(dt);
            adapter.Dispose();
            return dt;


        }

        

        //13-01-2020 basit
        internal static DataTable  DetailIPDDischargeSummary(DateTime datefrom, DateTime dateto)
        {
            DataTable dt = new DataTable();
            OracleCommand comm = new OracleCommand("rep_DetailInpatientBill", clsConnection.con);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add("DateFrom", OracleDbType.Date).Value = datefrom;
            comm.Parameters.Add("DateTo", OracleDbType.Date).Value = dateto;
            comm.Parameters.Add("retval", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            //comm.Parameters["retval"].Direction = ParameterDirection.Output;


            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = comm;// new OracleCommand(sql, Connection.Conn_ecyear);
            adapter.Fill(dt);
            adapter.Dispose();
            return dt;


        }

        //BASIT 04-07-2020
        //internal static DataSet InPBillMasterPackage(string RegAlpha, string RegNo)
        internal static DataSet InPBillMasterPackage(string SerailNo)
        {
            
            DataSet ds = new DataSet();
            OracleCommand comm = new OracleCommand("rep_inpbillmaster", clsConnection.con);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add("VSerailNo", OracleDbType.Varchar2).Value = SerailNo;
            comm.Parameters.Add("retval", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            


            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = comm;// new OracleCommand(sql, Connection.Conn_ecyear);
            adapter.Fill(ds);
            adapter.Dispose();
            return ds;


        }



        //basit 14-07-2020
        internal static DataTable InPBirthCret(string Vserialno,string Vbirthid)
        {
            DataTable dt = new DataTable();
            try
            {
                OracleCommand comm = new OracleCommand("rep_BirthCert", clsConnection.con);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add("Vserialno", OracleDbType.Varchar2).Value = Vserialno;
                comm.Parameters.Add("Vbirthid", OracleDbType.Varchar2).Value = Vbirthid;
                comm.Parameters.Add("retval", OracleDbType.RefCursor).Direction = ParameterDirection.Output;



                OracleDataAdapter adapter = new OracleDataAdapter();
                adapter.SelectCommand = comm;// new OracleCommand(sql, Connection.Conn_ecyear);
                adapter.Fill(dt);
                adapter.Dispose();
                return dt;
            }
            catch (Exception ex)
            {
                return dt;
            }
              
        }

        //basit 17-07-2020
        internal static DataSet ClosingSummaryInpatientSessionWise(string SessionId)
        {
            DataSet ds = new DataSet();
            OracleCommand comm = new OracleCommand("rep_dailychasestament", clsConnection.con);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add("VSessionId", OracleDbType.Varchar2).Value = SessionId;
            comm.Parameters.Add("retval", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            comm.Parameters.Add("retval1", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            //comm.Parameters["retval"].Direction = ParameterDirection.Output;


            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = comm;// new OracleCommand(sql, Connection.Conn_ecyear);
            adapter.Fill(ds);
            adapter.Dispose();
            return ds;

        }

        //30-07-2020 basit
        internal static DataTable DetailOPDReceipt(DateTime datefrom, DateTime dateto,string cmbCatagory,string cmbtest,string Vgender)
        {
            DataTable dt = new DataTable("opdtestreceippt");
            OracleCommand comm = new OracleCommand("rep_opdtestreport_New", clsConnection.con);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add("VDateFrom", OracleDbType.Date).Value = datefrom;
            comm.Parameters.Add("VDateTo", OracleDbType.Date).Value = dateto;
            comm.Parameters.Add("Vcatagoryid", OracleDbType.Varchar2).Value = cmbCatagory;
            comm.Parameters.Add("Vtestid", OracleDbType.Varchar2).Value = cmbtest;
            comm.Parameters.Add("Vgender", OracleDbType.Varchar2).Value = Vgender;
            comm.Parameters.Add("retval", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = comm;
            adapter.Fill(dt);
            adapter.Dispose();
            return dt;


        }


        internal static DataTable IPDRefundAmount(string regAlpha, string regNo)
        {
            DataTable dt = new DataTable();
            OracleCommand comm = new OracleCommand("rep_ipdrefundbillid1", clsConnection.con);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add("VregAlpha", OracleDbType.Varchar2).Value = regAlpha;
            comm.Parameters.Add("VregNo", OracleDbType.Varchar2).Value = regNo;
            comm.Parameters.Add("retval", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = comm;
            adapter.Fill(dt);
            adapter.Dispose();
            return dt;
        }


        //24-11-2020 basit
        internal static DataTable DetailLabIncomeStatement(DateTime datefrom, DateTime dateto)
        {
            DataTable dt = new DataTable("LaboratoryStatement");
            OracleCommand comm = new OracleCommand("rep_LaboratoryStatement", clsConnection.con);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add("VDateFrom", OracleDbType.Date).Value = datefrom;
            comm.Parameters.Add("VDateTo", OracleDbType.Date).Value = dateto;
            comm.Parameters.Add("retval", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            
            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = comm;
            adapter.Fill(dt);
            adapter.Dispose();
            return dt;

        }



        internal static DataTable GetZAkatRecipient(string PatientNewNo)
        {
            DataTable dt = new DataTable("rptZakatRecipient");
            OracleCommand comm = new OracleCommand("GETZakatRecipient", clsConnection.con);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add("VReferenceID", OracleDbType.Varchar2).Value = PatientNewNo;
            comm.Parameters.Add("retval", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = comm;
            adapter.Fill(dt);
            adapter.Dispose();
            return dt;
        }


        internal static DataTable GetBMJMember(string BMJMemberNo,string Active_UnActive,string Wfamily,string Vgender)
        {
            DataTable dt = new DataTable("rptMBJMember");
            OracleCommand comm = new OracleCommand("rep_bmjmember_n", clsConnection.con);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add("Vbmjnumber", OracleDbType.Varchar2).Value = BMJMemberNo;
            comm.Parameters.Add("VWfamily", OracleDbType.Varchar2).Value = Wfamily;
            comm.Parameters.Add("VActiveUnActive", OracleDbType.Varchar2).Value = Active_UnActive;
            comm.Parameters.Add("Vgender", OracleDbType.Varchar2).Value = Vgender;

            comm.Parameters.Add("retval", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = comm;
            adapter.Fill(dt);
            adapter.Dispose();
            return dt;
        }

        internal static DataTable rep_dailycashstatament(string FDate, string TDate,string VUser)
        {
            DataTable dt = new DataTable("daily_cash_statement");
            OracleCommand comm = new OracleCommand("rep_dailycashstatament1", clsConnection.con);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add("VFDate", OracleDbType.Date).Value = FDate;
            comm.Parameters.Add("VTDate", OracleDbType.Date).Value = TDate;
            comm.Parameters.Add("VUser", OracleDbType.Varchar2).Value = VUser;

            comm.Parameters.Add("retval", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = comm;
            adapter.Fill(dt);
            adapter.Dispose();
            return dt;
        }
        internal static DataTable rep_dailycashstatament_userwise(string Vsessionid)
        {
            DataTable dt = new DataTable("daily_cash_statement");
            OracleCommand comm = new OracleCommand("rep_dailystatament_userWise", clsConnection.con);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add("Vsessionid", OracleDbType.Varchar2).Value = Vsessionid;
           
           


            comm.Parameters.Add("retval", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = comm;
            adapter.Fill(dt);
            adapter.Dispose();
            return dt;
        }

        internal static DataTable ZakatMemberInvoiceDetail(DateTime FDate, DateTime TDate, string MemberId, string status)
        {
            DataTable dt = new DataTable();
            OracleCommand comm = new OracleCommand("rep_ZakatMemberInvoices", clsConnection.con);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add("VFdate", OracleDbType.Date).Value = FDate;
            comm.Parameters.Add("VTdate", OracleDbType.Date).Value = TDate;
            comm.Parameters.Add("VMemberId", OracleDbType.Varchar2).Value = MemberId;
            comm.Parameters.Add("VStatus", OracleDbType.Varchar2).Value = status;
           
            comm.Parameters.Add("retval", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            //comm.Parameters["retval"].Direction = ParameterDirection.Output;


            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = comm;// new OracleCommand(sql, Connection.Conn_ecyear);
            adapter.Fill(dt);
            adapter.Dispose();
            return dt;

        }

        internal static DataTable IPDreference(DateTime FDate, DateTime TDate, string ReferenceId)
        {
            DataTable dt = new DataTable();
            OracleCommand comm = new OracleCommand("rep_ipdrefreport", clsConnection.con);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add("Vfrom", OracleDbType.Date).Value = FDate;
            comm.Parameters.Add("Vtodate", OracleDbType.Date).Value = TDate;
            comm.Parameters.Add("VrefID", OracleDbType.Varchar2).Value = ReferenceId;
            comm.Parameters.Add("retval", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            //comm.Parameters["retval"].Direction = ParameterDirection.Output;


            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = comm;// new OracleCommand(sql, Connection.Conn_ecyear);
            adapter.Fill(dt);
            adapter.Dispose();
            return dt;

        }
        internal static DataTable RoomWisePatientInfo(string VToDate)
        {
            DataTable dt = new DataTable();
            OracleCommand comm = new OracleCommand("roomwise_patient_detail", clsConnection.con);
            comm.CommandType = CommandType.StoredProcedure;
           
            comm.Parameters.Add("VToDate", OracleDbType.Varchar2).Value = VToDate;
            
            comm.Parameters.Add("retval", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            //comm.Parameters["retval"].Direction = ParameterDirection.Output;


            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = comm;// new OracleCommand(sql, Connection.Conn_ecyear);
            adapter.Fill(dt);
            adapter.Dispose();
            return dt;

        }
        internal static DataTable AdvanceCollectionUserWise(string VFDate,string TDate,string VUser)
        {
            DataTable dt = new DataTable();
            OracleCommand comm = new OracleCommand("advancecollectionuserwise", clsConnection.con);
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.Add("VFDate", OracleDbType.Varchar2).Value = VFDate;
            comm.Parameters.Add("VTDate", OracleDbType.Varchar2).Value = TDate;
            comm.Parameters.Add("VUser", OracleDbType.Varchar2).Value = VUser;

            comm.Parameters.Add("retval", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            //comm.Parameters["retval"].Direction = ParameterDirection.Output;


            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = comm;// new OracleCommand(sql, Connection.Conn_ecyear);
            adapter.Fill(dt);
            adapter.Dispose();
            return dt;

        }
        internal static DataTable rep_ipd_consultant_detail(string VFromDate, string VToDate)
        {
            DataTable dt = new DataTable();
            OracleCommand comm = new OracleCommand("rep_ipd_consultant_detail", clsConnection.con);
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.Add("VFromDate", OracleDbType.Varchar2).Value = VFromDate;
            comm.Parameters.Add("VTDate", OracleDbType.Varchar2).Value = VToDate;
          

            comm.Parameters.Add("retval", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            //comm.Parameters["retval"].Direction = ParameterDirection.Output;


            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = comm;// new OracleCommand(sql, Connection.Conn_ecyear);
            adapter.Fill(dt);
            adapter.Dispose();
            return dt;

        }

        internal static DataTable rep_ipd_bmj_discharged(string VFromDate, string VToDate)
        {
            DataTable dt = new DataTable();
            OracleCommand comm = new OracleCommand("ipd_bmj_patient", clsConnection.con);
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.Add("VFromDate", OracleDbType.Varchar2).Value = VFromDate;
            comm.Parameters.Add("VTDate", OracleDbType.Varchar2).Value = VToDate;


            comm.Parameters.Add("retval", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            //comm.Parameters["retval"].Direction = ParameterDirection.Output;


            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = comm;// new OracleCommand(sql, Connection.Conn_ecyear);
            adapter.Fill(dt);
            adapter.Dispose();
            return dt;

        }


        internal static DataTable rep_ipd_testSummary(string VFromDate, string VToDate,string Vdepartment,string Vtest,string Vgender)
        {
            DataTable dt = new DataTable();
            OracleCommand comm = new OracleCommand("rep_testsummary_New", clsConnection.con);
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.Add("Vfrom", OracleDbType.Varchar2).Value = VFromDate;
            comm.Parameters.Add("Vtodate", OracleDbType.Varchar2).Value = VToDate;
            comm.Parameters.Add("Vdepartment", OracleDbType.Varchar2).Value = Vdepartment;
            comm.Parameters.Add("Vtest", OracleDbType.Varchar2).Value = Vtest;
            comm.Parameters.Add("Vgender", OracleDbType.Varchar2).Value = Vgender;


            comm.Parameters.Add("retval", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            //comm.Parameters["retval"].Direction = ParameterDirection.Output;


            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = comm;// new OracleCommand(sql, Connection.Conn_ecyear);
            adapter.Fill(dt);
            adapter.Dispose();
            return dt;

        }

        internal static DataTable rep_ipd_refundSummary(string VFromDate, string VToDate)
        {
            DataTable dt = new DataTable();
            OracleCommand comm = new OracleCommand("rep_refundSummary", clsConnection.con);
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.Add("Vfrom", OracleDbType.Varchar2).Value = VFromDate;
            comm.Parameters.Add("Vtodate", OracleDbType.Varchar2).Value = VToDate;


            comm.Parameters.Add("retval", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            //comm.Parameters["retval"].Direction = ParameterDirection.Output;


            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = comm;// new OracleCommand(sql, Connection.Conn_ecyear);
            adapter.Fill(dt);
            adapter.Dispose();
            return dt;

        }
        internal static DataTable rep_ipd_admittedPatient(string VFromDate, string VToDate)
        {
            DataTable dt = new DataTable();
            OracleCommand comm = new OracleCommand("rep_admittedPatient", clsConnection.con);
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.Add("Vfrom", OracleDbType.Varchar2).Value = VFromDate;
            comm.Parameters.Add("Vtodate", OracleDbType.Varchar2).Value = VToDate;


            comm.Parameters.Add("retval", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            //comm.Parameters["retval"].Direction = ParameterDirection.Output;


            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = comm;// new OracleCommand(sql, Connection.Conn_ecyear);
            adapter.Fill(dt);
            adapter.Dispose();
            return dt;

        }
        internal static DataTable rep_ipd_ConsultantVisits(DateTime FDate, DateTime TDate, string Consultant)
        {
            DataTable dt = new DataTable();
            OracleCommand comm = new OracleCommand("rep_consVisits", clsConnection.con);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add("Vfrom", OracleDbType.Date).Value = FDate;
            comm.Parameters.Add("Vto", OracleDbType.Date).Value = TDate;
            comm.Parameters.Add("vconsid", OracleDbType.Varchar2).Value = Consultant == "All" ? "" : Consultant;
             comm.Parameters.Add("retval", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            //comm.Parameters["retval"].Direction = ParameterDirection.Output;


            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = comm;// new OracleCommand(sql, Connection.Conn_ecyear);
            adapter.Fill(dt);
            adapter.Dispose();
            return dt;

        }

        internal static DataTable GetSPD_ZF(string FDate, string TDate)
        {
            string fdate = Convert.ToDateTime(FDate).ToString("dd MMM yyyy");
            string tdate = Convert.ToDateTime(TDate).ToString("dd MMM yyyy");
            DataTable dt = new DataTable();
            OracleCommand comm = new OracleCommand("getspd_zf", clsConnection.con);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add("fdate", OracleDbType.Varchar2).Value = fdate;
            comm.Parameters.Add("tdate", OracleDbType.Varchar2).Value = tdate;
            comm.Parameters.Add("retval", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = comm;
            adapter.Fill(dt);
            adapter.Dispose();
            return dt;

        }

        internal static DataTable getTrailBalance(string FDate, string TDate)
        {
            string fdate = Convert.ToDateTime(FDate).ToString("dd MMM yyyy");
            string tdate = Convert.ToDateTime(TDate).ToString("dd MMM yyyy");
            DataTable dt = new DataTable();
            OracleCommand comm = new OracleCommand("getTrailBalance", clsConnection.con);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add("fdate", OracleDbType.Varchar2).Value = fdate;
            comm.Parameters.Add("tdate", OracleDbType.Varchar2).Value = tdate;
            comm.Parameters.Add("retval", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = comm;
            adapter.Fill(dt);
            adapter.Dispose();
            return dt;

        }

        internal static DataTable rep_sessionpatient(string fdate,string tdate, string regno)
        {           
            DataTable dt = new DataTable();
            OracleCommand comm = new OracleCommand("GetSessionpatient", clsConnection.con);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add("Vfdate", OracleDbType.Varchar2).Value = fdate;
            comm.Parameters.Add("Vtdate", OracleDbType.Varchar2).Value = tdate;
            comm.Parameters.Add("Vregno", OracleDbType.Varchar2).Value = regno;
            comm.Parameters.Add("retval", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = comm;
            adapter.Fill(dt);
            adapter.Dispose();
            return dt;
        }

        internal static DataTable rep_PartialyPayment(DateTime fdate, DateTime tdate, string regno)
        {
            DataTable dt = new DataTable();
            OracleCommand comm = new OracleCommand("getpartiallypayment", clsConnection.con);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add("Vfdate", OracleDbType.Varchar2).Value = fdate;
            comm.Parameters.Add("Vtdate", OracleDbType.Varchar2).Value = tdate;
            comm.Parameters.Add("VOPDno", OracleDbType.Varchar2).Value = regno;
            comm.Parameters.Add("retval", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = comm;
            adapter.Fill(dt);
            adapter.Dispose();
            return dt;
        }

        internal static DataTable rep_PackageInfo()
        {
            DataTable dt = new DataTable();
            OracleCommand comm = new OracleCommand("rep_package_index", clsConnection.con);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add("retval", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            //comm.Parameters["retval"].Direction = ParameterDirection.Output;


            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = comm;// new OracleCommand(sql, Connection.Conn_ecyear);
            adapter.Fill(dt);
            adapter.Dispose();
            return dt;
        }
        internal static DataTable rep_ipd_packageDetail(string VFromDate, string VToDate)
        {
            DataTable dt = new DataTable();
            OracleCommand comm = new OracleCommand("rep_detailPatientbill", clsConnection.con);
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.Add("Vfrom", OracleDbType.Varchar2).Value = VFromDate;
            comm.Parameters.Add("Vtodate", OracleDbType.Varchar2).Value = VToDate;


            comm.Parameters.Add("retval", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            //comm.Parameters["retval"].Direction = ParameterDirection.Output;


            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = comm;// new OracleCommand(sql, Connection.Conn_ecyear);
            adapter.Fill(dt);
            adapter.Dispose();
            return dt;

        }
    }
}
