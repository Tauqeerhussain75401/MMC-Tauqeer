using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.IO;
using System.Windows;
using ERP;
using System.Drawing;

namespace ERP
{
    class Query
    {
        #region Queries of hussaini lab report
        public static DataTable getpateintinfo(string status)
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = @"Select * from mmc_result where {status}";
            }
            catch(Exception ex)
            {

            }
            return dt;
        }
        #endregion
        public static DataTable GenerateQRCode(string Vno,string QRimagePath)
        {
            // Create QR code
            QRCoder.QRCodeGenerator gen = new QRCoder.QRCodeGenerator();
            var qrdata = gen.CreateQrCode(Vno, QRCoder.QRCodeGenerator.ECCLevel.H);
            var qrcode = new QRCoder.QRCode(qrdata);
            string hexColorCode = "#000000"; ///"#2D5D94" Blue
            Color qrCodeColor = ColorTranslator.FromHtml(hexColorCode);
            var image = qrcode.GetGraphic(150, qrCodeColor, Color.White, GetLogo(QRimagePath));
            //var image = qrcode.GetGraphic(150, qrCodeColor, Color.White, false);
            // Convert the Bitmap to a byte array
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            byte[] imageBytes = ms.ToArray();

            // Create a DataTable and add a column for the image
            DataTable dtQr = new DataTable();
            dtQr.Columns.Add("Qrcode", typeof(byte[]));

            // Add the image data to the DataTable
            DataRow row = dtQr.NewRow();
            row["Qrcode"] = imageBytes;
            dtQr.Rows.Add(row);

            // Return the DataTable
            return dtQr;
        }
        public static DataTable FinancialYear()
        {
            DataTable dt = new DataTable();
            try
            {
                OracleDataAdapter adapter = new OracleDataAdapter();
                adapter.SelectCommand = new OracleCommand("select * from FinancialYear order by FinancialYear", clsConnection.con);
                adapter.Fill(dt);
                adapter.Dispose();
                return dt;
            }
            catch (Exception ee)
            {
                Errors.writeline(ee.Message, "Query_FinancialYear");
                string result = MyMessageBox.ShowBox(ee.Message, Variable.Version, 1);


                return dt;
            }
        }
         internal static DataTable GetOPDDetailsByContactNo(string VContactno)
        {
            string sql = "select * from OPDReceipt where contactno = '" + VContactno + "'";
            DataTable dt = getData(sql);
            return dt;
        }
        internal static DataTable GetMaxMRno()
        {
            string sql = "SELECT Max(MRNo) as MRno FROM  opdreceipt";
            DataTable dt = getData(sql);
            return dt;
        }   
        private static Bitmap GetLogo(string QRimagePath)
        {
            Bitmap logo = new Bitmap(QRimagePath);
            int logoSize = 30;
            return new Bitmap(logo, new System.Drawing.Size(logoSize, logoSize));
        }
        internal static void getUpdateFile(string Version, string path)
        {
            //Byte[] Buffer;
            try
            {
                string connection = System.Configuration.ConfigurationManager.ConnectionStrings["OracleConnection"].ToString().Replace("MyIP", clsConnection.Host);
                string sql = "select files from softwareupdates where version != '" + Version + "'";

                using (OracleCommand cmd = new OracleCommand(sql, clsConnection.con))
                {
                    using (IDataReader dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            byte[] byteArray = (Byte[])dataReader["files"];
                            using (FileStream fs = new FileStream
                           (path, FileMode.CreateNew, FileAccess.Write))
                            {
                                fs.Write(byteArray, 0, byteArray.Length);
                            }
                        }
                    }
                    //}
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            // return Buffer;
        }
        internal static void Execute(string sql)
        {
            OracleCommand com = new OracleCommand(sql, clsConnection.con);
            com.ExecuteNonQuery();
        }
        public static DataTable Get_dataTable(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                OracleDataAdapter adapter = new OracleDataAdapter();
                adapter.SelectCommand = new OracleCommand(sql, clsConnection.con);
                adapter.Fill(dt);
                adapter.Dispose();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
            return dt;
        }
        internal static DataTable getData(string sql)
        {
            DataTable dt = new DataTable();
            OracleDataAdapter adap = new OracleDataAdapter(sql, clsConnection.con);
            adap.Fill(dt);
            adap.Dispose();
            return dt;
        }
        internal static DataTable getData(OracleCommand com)
        {
            DataTable dt = new DataTable();
            com.Connection = clsConnection.con;
            OracleDataAdapter adap = new OracleDataAdapter(com);
            adap.Fill(dt);
            adap.Dispose();
            return dt;
        }
        internal static DataSet getDataSet(string sql)
        {
            DataSet ds = new DataSet();
            // SqlConnection con = conOpen();            
            OracleDataAdapter adap = new OracleDataAdapter(sql, clsConnection.con);
            OracleCommandBuilder comBuild = new OracleCommandBuilder();

            adap.Fill(ds);
            adap.Dispose();
            return ds;
        }
        public static DataTable get_ChartOfAcc()
        {

            DataTable dt = new DataTable();
            try
            {
                OracleDataAdapter adapter = new OracleDataAdapter();
                adapter.SelectCommand = new OracleCommand("select status, accountid Account, accounttitle Title, parentaccountid parentid, control Acctype, createdby, editby, aclevel AccLevel,withheld, currency, approvedby,per,segregation,netcapital,liquidcapital from ChartofAccounts where status = 0 order by to_number(Account)", clsConnection.con);
                adapter.Fill(dt);
                adapter.Dispose();
                return dt;
            }
            catch (Exception ee)
            {
                Errors.writeline(ee.Message, "Query_ get_ChartOfAcc");
                string result = MyMessageBox.ShowBox(ee.Message, Variable.Version, 1);


                return dt;
            }
        }
        public static DataTable get_Patients(
            string PatientTitle,
            string PatientName,
            string ContactNo,
            string DOB,
            string Gender
            )
        {
            DataTable dt = new DataTable();
            try
            {

                OracleCommand DbCommand = new OracleCommand("rep_get_patients", clsConnection.con);
                DbCommand.CommandType = CommandType.StoredProcedure;
               
                object VPatientTitle = string.IsNullOrWhiteSpace(PatientTitle) ? (object)DBNull.Value : PatientTitle;
                object VPatientName = string.IsNullOrWhiteSpace(PatientName) ? (object)DBNull.Value : PatientName;
                object VContactNo = string.IsNullOrWhiteSpace(ContactNo) ? (object)DBNull.Value : ContactNo;
                object VDOB = string.IsNullOrWhiteSpace(DOB) ? (object)DBNull.Value : DOB;
                object VGender = string.IsNullOrWhiteSpace(Gender) ? (object)DBNull.Value : Gender;


                DbCommand.Parameters.Add("VPatientTitle", OracleDbType.Varchar2, 10).Value = VPatientTitle;
                DbCommand.Parameters.Add("VPatientName", OracleDbType.Varchar2, 20).Value = VPatientName;
                DbCommand.Parameters.Add("VContactNo", OracleDbType.Varchar2, 20).Value = VContactNo;
                DbCommand.Parameters.Add("VDOB", OracleDbType.Date).Value = VDOB;
                DbCommand.Parameters.Add("VGender", OracleDbType.Date).Value = Gender;
                DbCommand.Parameters.Add("VUser", OracleDbType.Varchar2).Value = Variable.User;
                DbCommand.Parameters.Add("VTerminalID", OracleDbType.Varchar2).Value = Variable.TerminalId;
                DbCommand.Parameters.Add("retval", OracleDbType.RefCursor).Direction = ParameterDirection.Output;


                OracleDataAdapter adapter = new OracleDataAdapter();
                adapter.SelectCommand = DbCommand;
                adapter.Fill(dt);
                adapter.Dispose();
                return dt;
            }
            catch (Exception ee)
            {
                MyMessageBox.ShowBox(ee.Message);
                Errors.writeline(ee.Message, "MSP_search patient");
                //string result = MessageBox.Show(ee.Message, Variable.Version, 1);
                return dt;
            }
        }

        public static DataTable save_Patient(
            string Id,
            string PatientTitle,
            string PatientName,
            string ContactNo,
            string DOB,
            string Gender
            )
        {
            DataTable dt = new DataTable();
            try
            {

                OracleCommand DbCommand = new OracleCommand("rep_save_patients", clsConnection.con);
                DbCommand.CommandType = CommandType.StoredProcedure;

                object VPatientTitle = string.IsNullOrWhiteSpace(PatientTitle) ? (object)DBNull.Value : PatientTitle;
                object VPatientName = string.IsNullOrWhiteSpace(PatientName) ? (object)DBNull.Value : PatientName;
                object VContactNo = string.IsNullOrWhiteSpace(ContactNo) ? (object)DBNull.Value : ContactNo;
                object VDOB = string.IsNullOrWhiteSpace(DOB) ? (object)DBNull.Value : DOB;
                object VGender = string.IsNullOrWhiteSpace(Gender) ? (object)DBNull.Value : Gender;

                DbCommand.Parameters.Add("VId", OracleDbType.Varchar2, 10).Value = Id;
                DbCommand.Parameters.Add("VPatientTitle", OracleDbType.Varchar2, 10).Value = VPatientTitle;
                DbCommand.Parameters.Add("VPatientName", OracleDbType.Varchar2, 20).Value = VPatientName;
                DbCommand.Parameters.Add("VContactNo", OracleDbType.Varchar2, 20).Value = VContactNo;
                DbCommand.Parameters.Add("VDOB", OracleDbType.Date).Value = VDOB;
                DbCommand.Parameters.Add("VGender", OracleDbType.Date).Value = Gender;
                DbCommand.Parameters.Add("VUser", OracleDbType.Varchar2).Value = Variable.User;
                DbCommand.Parameters.Add("VTerminalID", OracleDbType.Varchar2).Value = Variable.TerminalId;
                DbCommand.Parameters.Add("ReturnValue", OracleDbType.Varchar2).Direction = ParameterDirection.Output;


                DbCommand.ExecuteNonQuery();
                //ReturnValue = DbCommand.Parameters["RefVno"].Value.ToString();

                DbCommand.Dispose();

                return dt;
            }
            catch (Exception ee)
            {
                MyMessageBox.ShowBox(ee.Message);
                Errors.writeline(ee.Message, "MSP_search patient");
                //string result = MessageBox.Show(ee.Message, Variable.Version, 1);
                return dt;
            }
        }
        internal static string get_TerminalId(string proccessorid, string hddid, string ComputerName)
        {
            string TerminalId = "";

            OracleCommand com = new OracleCommand("get_Add_TerminalId", clsConnection.con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add("Vproccessorid", OracleDbType.Varchar2).Value = proccessorid;
            com.Parameters.Add("Vhddid", OracleDbType.Varchar2).Value = hddid;
            com.Parameters.Add("Vboardmaker", OracleDbType.Varchar2).Value = "";
            com.Parameters.Add("Vbiosmaker", OracleDbType.Varchar2).Value = "";
            com.Parameters.Add("Vcpumaker", OracleDbType.Varchar2).Value = "";
            com.Parameters.Add("Vnoramslots", OracleDbType.Varchar2).Value = "";
            com.Parameters.Add("Vcomputername", OracleDbType.Varchar2).Value = ComputerName;
            com.Parameters.Add("IVTerminalId", OracleDbType.Varchar2, 200).Direction = ParameterDirection.Output;

            com.ExecuteNonQuery();
            TerminalId = com.Parameters["IVTerminalId"].Value.ToString();
            if (TerminalId != "")
            {
                TerminalId =  TerminalId;
            }

            return TerminalId;
        }
        internal static DataTable get_CompanyInfo()
        {
            DataTable dt = new DataTable();
            // SqlConnection con = conOpen();
            string sql = "select cd.*, sysdate from companydetail cd";
            OracleDataAdapter adap = new OracleDataAdapter(sql, clsConnection.con);
            adap.Fill(dt);
            adap.Dispose();
            return dt;
        }
        internal static DataTable GetPartialltPaymentReport(string fdate, string tdate, string regno)
        {
            string sql = @"SELECT --* 
                            get_consultantname(consultantid) consultant_name,op.receiptno opd_no,To_Char(Min(op.vdate),'DD-Mon-YY') firstvisit_date,
                            To_Char(Max(CASE WHEN op.vdate > Nvl(pr.vdate,op.vdate) THEN op.vdate ELSE Nvl(pr.vdate,op.vdate) END),'DD-Mon-YY') lastvisit_date,
                            patientname patient_name,gender,age,contactno mobile_no,
                              Sum(Nvl(netamount,0)) total_payment, Sum(Nvl(pr.partialamount,0)) paid,Sum(Nvl(netamount,0)-Nvl(pr.partialamount,0)) balance
                             FROM opdreceipt op
                            left JOIN partialreceipt pr ON pr.receiptno = op.receiptno
                            WHERE netbalance > 0  AND op.status = 0 AND op.vdate BETWEEN '"+ fdate +@"' AND '"+tdate +@"'
                            GROUP BY patientname,op.receiptno,gender,age,contactno,consultantid
                            HAVING Sum(Nvl(netbalance,0)-Nvl(pr.partialamount,0)) != 0 AND Sum(Nvl(netamount,0)-Nvl(pr.partialamount,0)) > 0 
                            ORDER BY patientname";
            DataTable dt = getData(sql);
            return dt;
        }
        internal static DataTable NarrationIndex()
        {

            string sql = "select * from Narration  where status = 0";

            DataTable dt = getData(sql);
            return dt;

        }
        internal static DataTable NarrationIndex_TellerVoucher()
        {
            DataTable dt = new DataTable();
            try
            {

                OracleCommand comm = new OracleCommand("Get_Narration_Teller_Voucher", clsConnection.con);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add("retval", OracleDbType.RefCursor);
                comm.Parameters["retval"].Direction = ParameterDirection.Output;

                OracleDataAdapter adapter = new OracleDataAdapter();
                adapter.SelectCommand = comm;
                adapter.Fill(dt);
                return dt;
            }
            catch (Exception ee)
            {
                Errors.writeline(ee.Message, "rep_Get_Narration_Receipt_Voucher");
                MessageBox.Show(ee.Message);
                return dt;
            }

            ////string sql = "select * from Narration  where status = 0 and ";

            ////DataTable dt = getData(sql);
            ////return dt;
        }
        internal static DataTable TestRemarksIndex(string departmentid)
        {
            string sql = "select * from testheadremarks where departmentid='" + departmentid + "'";
            DataTable dt = getData(sql);
            return dt;
        }
        internal static DataTable getMemberIndex(string name, string contact, string cnic)
        {
            String Sql = " Select * From v_member where status=0";
            if (name != "")
            {
                Sql += " and lower(name) like '%" + name.ToLower() + "%'";
            }
            if (contact != "")
            {
                Sql += " and replace(contact,'-')=replace('" + contact + "','-')";

            }
            if (cnic != "")
            {
                Sql += " and replace(cnic,'-')=replace('" + cnic + "','-')";
            }


            DataTable dt = getData(Sql);
            return dt;
        }
        internal static DataTable getAreaIndex()
        {
            String Sql = " Select * From AreaIndex ";
            DataTable dt = getData(Sql);
            return dt;
        }
        internal static DataTable getrefunddata(string serialno)
        {
            String Sql = " SELECT refundamount FROM  ipdbilling WHERE admissionid= '"+ serialno + "'";
            DataTable dt = getData(Sql);
            return dt;
        }
        internal static DataTable getMemberDetail(string Id, string bmjCard, string Filter)
        {
            String Sql = " Select * From v_member where  id = '" + Id + "' ";
            if (Filter == "BMJ")
                Sql = " Select * From v_member where newno = '" + bmjCard + "'";
            DataTable dt = getData(Sql);
            return dt;
        }
        public static DataTable getmemberdependent(string bmjcardno)
        {
            DataTable dt = new DataTable();
            String Sql = "Select * From v_memberdependent where newno='" + bmjcardno + "' and status!=1";
            OracleDataAdapter adp = new OracleDataAdapter(Sql, clsConnection.con);
            adp.Fill(dt);
            return dt;
        }
        internal static DataTable getMemberFamilyDetail(string Id)
        {
            String Sql = "Select * From memberdependent where id = '" + Id + "' ";
            DataTable dt = getData(Sql);
            return dt;
        }
        internal static DataTable Accounts()
        {
            string sql = "select accountid,accounttitle   from ChartOfAccounts  where control = 'Detail' and status = 0";
            DataTable dt = getData(sql);
            return dt;
        }
        internal static DataTable UserList()
        {
            string sql = "Select * from Users";
            DataTable dt = getData(sql);
            return dt;
        }
        internal static DataTable ReferenceIndex()
        {
            string sql = "SELECT id,name FROM Reference where isactive=1 ORDER BY lower(name)";
            DataTable dt = getData(sql);
            return dt;
        }
        internal static DataTable packageIndex(string pkgid)
        {
            string sql = "SELECT pi.packagename_name,pi.package_id FROM consultantsurgery cs left JOIN packageindex pi ON pi.package_id = cs.fkpkgid WHERE pi.isdeactivate= '1' " + (pkgid == "All" ? "" : "AND cs.fkconsid = '" + pkgid + "'") + "";
            DataTable dt = getData(sql);
            return dt;
        }
        internal static DataTable ConsultantIndex()
        {
            string sql = "SELECT to_char(id) id,name,testtypeid,hospitalrate FROM consultant where isdeactivate = 0 ORDER BY lower(name)";
            DataTable dt = getData(sql);
            return dt;
        }
        internal static DataTable ConsultantIndex_opd()
        {
            DataTable dt = new DataTable();
            try
            {
                OracleCommand comm = new OracleCommand("get_ConsultantIndex_opd", clsConnection.con);
                comm.CommandType = CommandType.StoredProcedure;

                comm.Parameters.Add("retval", OracleDbType.RefCursor);
                comm.Parameters["retval"].Direction = ParameterDirection.Output;

                OracleDataAdapter adapter = new OracleDataAdapter();
                adapter.SelectCommand = comm;
                adapter.Fill(dt);
                adapter.Dispose();
                return dt;
            }
            catch (Exception ee)
            {
                Errors.writeline(ee.Message, "MSP_get_ConsultantIndex_opd");
                string result = MyMessageBox.ShowBox(ee.Message, Variable.Version, 1);
                string err = MyMessageBox.ShowBox("Do you want to Exit ?", Variable.Version, 2);
                //if (err == "1") Application.Exit();
                return dt;
            }
        }
        internal static DataTable PatientIndex()
        {
            string sql = "SELECT regnoalpha||'-'||regnonumeric||' '||patientname as patient,serialno  FROM admissioninfo ORDER BY Lower(patient)";
            DataTable dt = getData(sql);
            return dt;
        }
        internal static DataTable roomAll()
        {
            string sql = "SELECT * FROM roomindex ORDER BY fullname";
            DataTable dt = getData(sql);
            return dt;
        }
        internal static DataTable TestCatagoryIndex()
        {
            string sql = "SELECT * FROM testCatagory WHERE isactive = 1  ORDER BY Title";
            DataTable dt = getData(sql);
            return dt;
        }
        internal static DataTable IPDTestCatagoryIndex()
        {
            string sql = "SELECT * FROM testCatagory WHERE isactive = 1 and id!=8 and id!=1 ORDER BY Title";
            DataTable dt = getData(sql);
            return dt;
        }
        internal static DataTable TestCatagoryIndexForOPD()
        {
            string sql = "SELECT * FROM testCatagory WHERE isactive = 1 and showinopd = 1  ORDER BY Title";
            DataTable dt = getData(sql);
            return dt;
        }
        internal static DataTable TestIndex()
        {
            string sql = "SELECT to_char(id) id,title,hospitalrate,testtypeid FROM test  WHERE isdeactivated = 0 ORDER BY lower(Title)";
            DataTable dt = getData(sql);
            return dt;
        }
        internal static DataTable ValidateTestAmount(string id)
        {
            string sql = "SELECT to_char(id) id,title,hospitalrate,testtypeid FROM test  WHERE isdeactivated = 0 and id='" + id + "' and hospitalrate !=0 ORDER BY lower(Title)";
            DataTable dt = getData(sql);
            return dt;
        }
        internal static DataTable TestIndex(string Catagory, string Status) 
        {
            string sql = "SELECT * FROM test  WHERE (" + Catagory + " = 0 OR testtypeid = '" + Catagory + "') AND isdeactivated = " + (Status == "Active" ? "0" : Status == "Deactive" ? "1" : "isdeactivated") + " ORDER BY Title";
            DataTable dt = getData(sql);
            return dt;
        }
        internal static DataTable TestDetail(string ID)
        {
            string sql = "SELECT * FROM test  WHERE ID = '" + ID + "' ";
            DataTable dt = getData(sql);
            return dt;
        }
        internal static DataTable PatientCatagory()
        {
            string sql = "SELECT id,Title,hasmembership,allowdiscount,hasReferences FROM patientcatagory WHERE status = 0 ORDER BY id";
            DataTable dt = getData(sql);
            return dt;
        }
        internal static DataTable LabTest()
        {
            string sql = "SELECT id,title,location,testheadid,get_DepartmentTitle(testheadid) HeadTitle FROM test WHERE testtypeid = 2 AND isdeactivated = 0 ORDER BY title";
            DataTable dt = getData(sql);
            return dt;
        }
        internal static DataTable DepartmentIndex()
        {
            string sql = "SELECT * FROM departments WHERE title != 'General' ORDER BY title";
            DataTable dt = getData(sql);
            return dt;
        }
        internal static DataTable DepartmentIndexAll()
        {
            string sql = "SELECT * FROM departments ORDER BY title";
            DataTable dt = getData(sql);
            return dt;
        }
        internal static DataTable TemplateIndex()
        {
            string sql = "";
            if (UserInfo.UserLevel == "Admin")
            {
                sql  = "SELECT id,templatename FROM DocTemplate  WHERE isecho =0  ORDER BY templatename ";
            }
            else
            {
                sql = "SELECT id,templatename FROM DocTemplate where isecho =0 and lower(userid) = lower('" + UserInfo.UserId + "') ORDER BY templatename ";
            }

            DataTable dt = getData(sql);
            return dt;
        }
        internal static DataTable TemplateIndexEcho()
        {
            string sql = "";
            if (UserInfo.UserLevel == "Admin")
            {
                sql = "SELECT id,templatename FROM DocTemplate  WHERE isecho =1  ORDER BY templatename ";
            }
            else
            {
                sql = "SELECT id,templatename FROM DocTemplate where isecho =1 and lower(userid) = lower('" + UserInfo.UserId + "') ORDER BY templatename ";
            }

            DataTable dt = getData(sql);
            return dt;
        }
        internal static DataTable MemberIndex()
        {
            string sql = "SELECT newno,newno || ' | ' || name name,caste FROM member WHERE isdeactivate = 0 ORDER BY newno,name,caste";
            DataTable dt = getData(sql);
            return dt;
        }
        internal static DataTable MemberDependentIndex()
        {
            string sql = "SELECT id,newno,name name FROM memberdependent m WHERE isdeactivated = 0 and status <> '1' order by name";
            DataTable dt = getData(sql);
            return dt;
        }
        internal static DataTable UserIndex()
        {
            string sql = "SELECT UserId,UserName FROM users  WHERE status = 0 and islock!=1 ORDER BY UserId";
            DataTable dt = getData(sql);
            return dt;
        }
        internal static DataTable FacultyIndex()
        {
            string sql = "SELECT ID,NAME FROM FACULTY  WHERE status = 0 and ISBLOCK = 0 ORDER BY ID";
            DataTable dt = getData(sql);
            return dt;
        }
        /*//string sql = @"SELECT id,fullname room,floornumber,wm_concat(regnoalpha||'-'|| regnonumeric) regno  FROM roomindex  ri 
        //                    left JOIN admissioninfo ad
        //                    ON ri.id = ad.roomid  AND dischargeyn = '0'
        //                    GROUP BY id,fullname,floornumber
        //                    ORDER BY floornumber,fullname,id ";*/
        internal static DataTable RoomIndex()
        {
            string sql = @"SELECT id,fullname room,floornumber,regnoalpha||'-'|| regnonumeric regno  FROM roomindex  ri 
                            left JOIN admissioninfo ad
                            ON ri.id = ad.roomid  AND dischargeyn = '0'
                            GROUP BY id,fullname,floornumber,regnoalpha,regnonumeric
                            ORDER BY floornumber,fullname,id ";
            DataTable dt = getData(sql);
            return dt;
        }
        internal static DataTable AccountsLvl4Head()
        {
            string sql = "select Account, Title  from ChartofAccount where AccLevel = 4 group by Account, Title ";
            DataTable dt = getData(sql);
            return dt;
        }
        internal static DataTable OpenningAccounts()
        {
            string sql = "select lvl4 as ParentCode,lvl5 as Code,lvl5title as Title ,isnull(dbo.OpenningBal(lvl5),0) Bal from vu_ChartofAccount  ";
            DataTable dt = getData(sql);
            return dt;
        }
        internal static DataTable OpenningAccounts(string ParentAcc)
        {
            string sql = "select lvl4 as ParentCode,lvl5 as Code,lvl5title as Title ,isnull(dbo.OpenningBal(lvl5),0) Bal from vu_ChartofAccount  where lvl4  like '" + ParentAcc + "'";
            DataTable dt = getData(sql);
            return dt;
        }
        public static DataTable DetailAccounts()
        {
            DataTable dt = new DataTable();
            try
            {
                OracleDataAdapter adapter = new OracleDataAdapter();
                adapter.SelectCommand = new OracleCommand("select accountid,accounttitle from ChartofAccounts WHERE status = 0 AND control = 'Detail' AND accountid NOT IN ( '001001005001001','001001005002001') order by accounttitle", clsConnection.con);
                adapter.Fill(dt);
                adapter.Dispose();
                return dt;
            }
            catch (Exception ee)
            {
                Errors.writeline(ee.Message, "Query_ChartofAccounts");
                string result = MyMessageBox.ShowBox(ee.Message, Variable.Version, 1);
                string err = MyMessageBox.ShowBox("Do you want to Exit ?", Variable.Version, 2);
                //  if (err == "1") Application.Exit();
                return dt;
            }
        }
        internal static DataTable OPDReceiptQuery(string Vno)
        {
            string sql = "SELECT receiptno,tokenNo, vdate, get_OPDcatagory(catagoryid) CatagoryTitle, Get_consultantName(consultantid) ConsultantName, get_PatientType(patienttype) patienttype, memberid, patientid, patienttitle, patientname, gender, contactno, age, ageunit, netamount, createdby, createdtime, editby, edittime,status,noofprint FROM OPDReceipt where status = 0 and ReceiptNo = '" + Vno + "'   order by ReceiptNo desc";
            DataTable dt = getData(sql);
            return dt;
        }
        internal static DataTable OPDReceiptQuery(string[] filter, string catagoryid)
        {
            string Filter = filter.Count() > 0 ? string.Join(" ", filter) : "";
            string sql = @"SELECT tokenNo,'OP-' || receiptno AS receiptno,vdate, 
                           get_OPDcatagory(catagoryid) CatagoryTitle, 
                           nvl(Get_consultantName(consultantid),' ') ConsultantName, 
                           get_PatientType(patienttype) patienttype, " +
                           "patientname," + 
                           "netamount + electricitycharges AS netamount, " +
                           @"createdby || '|' || To_Char(createdtime,'dd-Mon-yyyy HH:mm:ss am') AS createdby, Decode(editby, NULL, ' ', editby || '|' || To_Char(edittime,'dd-Mon-yyyy HH:mm:ss am')) AS editby,
                           status,noofprint FROM OPDReceipt opdr
                           LEFT JOIN (select userid,sessionid from usersession where status = 2) us ON us.sessionid = opdr.sessionid 
                           WHERE ( '" + UserInfo.UserLevel + "'= 'Admin' " + Filter + @") 
                           or (catagoryid = '" + catagoryid + "' AND status = 0 AND us.userid = '" + UserInfo.UserId + @"')  
                           order by ReceiptNo DESC";
            DataTable dt = getData(sql);
            return dt;
        }
        internal static DataTable OPDReceiptQuery(string[] filter)
        {
            string Filter = filter.Count() > 0 ? string.Join(" ", filter) : "";
            //string sql = "SELECT receiptno,tokenNo, vdate, get_OPDcatagory(catagoryid) CatagoryTitle, Get_consultantName(consultantid) ConsultantName, get_PatientType(patienttype) patienttype, memberid, patientid, patienttitle, patientname, gender, contactno, age, ageunit,grossamount,discount, netamount, createdby, createdtime, editby, edittime,status,noofprint FROM OPDReceipt where  status = 0 " + Filter + "  order by ReceiptNo desc";
            string sql = "SELECT receiptno,tokenNo, vdate, get_OPDcatagory(catagoryid) CatagoryTitle, Get_consultantName(consultantid) ConsultantName,get_PatientType(patienttype) patienttype, memberid, patientid, patienttitle, patientname, gender, contactno, age,ageunit,grossamount,discount, netamount, createdby, createdtime, editby, edittime,status,noofprint,consultantid FROM OPDReceipt pr where status = 0 " + Filter + "UNION ALL SELECT op.receiptno,tokenNo, pr.vdate, get_OPDcatagory(catagoryid) CatagoryTitle, Get_consultantName(consultantid) ConsultantName,get_PatientType(patienttype) patienttype, memberid, patientid, patienttitle, patientname, gender, contactno, age,ageunit,grossamount,discount, pr.partialamount, op.createdby, op.createdtime, op.editby, op.edittime,op.status,noofprint,consultantid FROM partialreceipt pr left JOIN opdreceipt op ON op.receiptno = pr.receiptno where op.status = 0 " + Filter + " ORDER by ReceiptNo desc";
            DataTable dt = getData(sql);
            return dt;
        }
        internal static DataTable IPDReceiptQuery(string[] filter)
        {
            string Filter = filter.Count() > 0 ? string.Join(" ", filter) : "";
            string sql = @"SELECT adm.serialno,receiptno,receiptdate,get_opdcatagory(testtypeid) AS CatagoryTitle,get_testtitle(testid) AS test, Get_consultantName(inp.consultantid) AS  
                            ConsultantName,get_PatientType(patienttype) patienttype, bmjnewno,
                            regnoalpha||'-'||regnonumeric AS  patientid,patientname, gender,
                            emergency,ymd,charges,inp.createdby, inp.createdtime, inp.editby, 
                            inp.edittime,inp.status,inp.isprinted  FROM admissioninfo adm
                            left JOIN inptestcharges inp
                            ON inp.serialno  =adm.serialno AND adm.status=0 where  inp.status=0 " + Filter + @"  order by ReceiptNo desc";
            DataTable dt = getData(sql);
            return dt;
        }
        internal static DataTable TestIndex(int typeid)
        {
            string sql = "SELECT id,upper(title) as title,hospitalrate FROM test WHERE testtypeid = " + typeid + " AND isdeactivated = 0 ORDER BY title";
            DataTable dt = getData(sql);
            return dt;
        }
        internal static DataTable ConsultantIndexAll()
        {
            string sql = "SELECT * FROM CONSULTANT order by name asc";
            DataTable dt = getData(sql);
            return dt;
        }
        internal static DataTable ConsultantSetup(string[] filter)
        {
            string Filter = filter.Count() > 0 ? string.Join(" ", filter) : "";
            string sql = "SELECT id, name,degrees, timings, faculty, get_opdcatagory(testtypeid) Department, isdeactivate FROM consultant";
            DataTable dt = getData(sql);
            return dt;
        }
        internal static DataTable ConsultantDetail(string ID)
        {
           /* //string sql = @"SELECT 1 As surExist,ct.*,cts.consulshare AS consulShare ,cts.hospshare hospShare,pi.amount AS amount,pi.packagename_name,
            //             pi.package_id AS package_id FROM consultant ct left JOIN consultantsurgery  cts ON ct.id = cts.fkconsid
            //             left JOIN packageindex pi ON pi.package_id = fkpkgid where ct.isdeactivate = 0 AND cts.status = 0 and ct.id = '" + ID + "'";
            //DataTable dt = getData(sql);
            //return dt;*/
            string sql = @"SELECT 1 As surExist,ct.*,cts.consulshare AS consulShare ,cts.hospshare hospShare,pi.amount AS amount,pi.packagename_name,
                         pi.package_id AS package_id,facultyid FROM consultant ct left JOIN consultantsurgery  cts ON ct.id = cts.fkconsid
                         left JOIN packageindex pi ON pi.package_id = fkpkgid where ct.id = '" + ID + "'";
            DataTable dt = getData(sql);
            return dt;
        }
        internal static DataTable VoucherQuery(string vtype, string[] filter)
        {
            string filterCondition = "";
            for (int i = 0; i < filter.Count(); i++)
            {
                filterCondition += filter[i] + " ";
            }
            string sql = "select max(Vdate) Vdate,vtype,voucherno ,sum(case when  Amount  > 0 then  amount else -amount end) amount,dbo.Get_NarrationTitle(narration) narration ,min(createdby ) createdby,min(createdtime) createdtime,max(editby) editby,max(edittime ) edittime from gl1 where status = 0 and Vtype = '" + vtype + "' " + filterCondition + " group by vtype,VoucherNo ,narration  order by vtype,VoucherNo desc";
            DataTable dt = getData(sql);
            return dt;
        }
        internal static DataTable VoucherQuery(string vtype, string Vno)
        {
            string sql = "select max(Vdate) Vdate,vtype,voucherno ,sum(case when  Amount  > 0 then  amount else -amount end) amount,dbo.Get_NarrationTitle(narration) narration ,min(createdby ) createdby,min(createdtime) createdtime,max(editby) editby,max(edittime ) edittime from gl1 where status = 0 and Vtype = '" + vtype + "' and VoucherNo  = '" + Vno + "'  group by vtype,VoucherNo ,narration  order by vtype,VoucherNo desc";
            DataTable dt = getData(sql);
            return dt;
        }
        internal static DataTable OPDReceiptDetail(string Vno)
        {
            string sql = "select * from OPDReceipt where ReceiptNo = '" + Vno + "'";
            DataTable dt = getData(sql);
            return dt;
        }
        internal static DataTable OPDReceiptDetail(string Vno, string TestCatagory)
        {
            string sql = "select * from OPDReceipt where ReceiptNo = '" + Vno + "' and catagoryid = '" + TestCatagory + "'";
            DataTable dt = getData(sql);
            return dt;
        }
        internal static DataTable IPDReceiptDetail(string receiptno, string testtypeid)
        {
            string sql = " SELECT regnoalpha||'-'|| regnonumeric AS regno,adm.*,get_roomtitle(roomid) AS roomName FROM admissioninfo adm WHERE serialno IN (SELECT serialno FROM inptestcharges WHERE receiptno='" + receiptno + "' and testtypeid='" + testtypeid + "' AND status!=1)";

            DataTable dt = getData(sql);
            return dt;
        }
        internal static DataTable OPDReceiptTestDepartmentIndex(string Vno)
        {
            string sql = "select DISTINCT  departmentid, departmenttitle from OPDReceiptTestepartments WHERE receiptno = '" + Vno + "'";
            DataTable dt = getData(sql);
            return dt;
        }
        internal static DataTable OPDReceiptTestIndex(string Vno)
        {
            string sql = "select id,title from OPDReceiptTestDetail td left JOIN test t ON t.id = td.fktestid WHERE status = 0 AND fkreceiptid = '" + Vno + "'";
            DataTable dt = getData(sql);
            return dt;
        }
        internal static DataTable OPDTestReceiptDetail(string Vno)
        {
            string sql = "SELECT d.*,rowid rid from OPDReceiptTestDetail d WHERE status = 0 AND fkreceiptid = '" + Vno + "'";
            DataTable dt = getData(sql);
            return dt;
        }
        internal static DataTable VoucherDetail(string vtype, string Vno)
        {
            string sql = "select * from GL1 where status = 0 and Vtype = '" + vtype + "' and voucherno = '" + Vno + "'";
            DataTable dt = getData(sql);
            return dt;
        }
        internal static DataTable VoucherDetail(string vtype, string Vno, string Account)
        {
            string sql = "select * from GL1 where status = 0 and Vtype = '" + vtype + "' and voucherno = '" + Vno + "' and '" + Account + "' in (CrAccount,drAccount)";
            DataTable dt = getData(sql);
            return dt;
        }
        public static DataTable VoucherDetailbankReconci(string fkbankCode, DateTime TDate, string clear)
        {
            DataTable dt = new DataTable();
            try
            {
                OracleDataAdapter adapter = new OracleDataAdapter();
                //string sql = "select VDate,VNO,(select narrationtitle from narration where narrationcode = fktransactionid) as Narration,cr as Amount from Voucherdetail where ( VDate between '" + From + "' and '" + To + "') and FK_Narration = " + Narration + " and VNO = " + VNO + "  and Vtype = 'PV' and status = 0 AND Vseq = 1";
                //string sql = "SELECT *  FROM voucherdetail WHERE clearentry = " + (clear == "All" ? "clearentry" : clear) + " and fkaccountid = '"+Accountinfo.CashInBank+"' and  fkbankid = '" + fkbankCode + "' AND Trunc(reconciledate) <=  '" + TDate.ToString("dd-MMM-yyyy") + "' AND Trunc(Vdate) <=  '" + TDate.ToString("dd-MMM-yyyy") + "' and status = 0";

                //string sql = "SELECT *  FROM voucherdetail WHERE clearentry = " + (clear == "All" ? "clearentry" : clear) + " and fkaccountid = '"+Accountinfo.CashInBank+"' and  fkbankid = '" + fkbankCode + "'  AND Trunc(Vdate) <=  '" + TDate.ToString("dd-MMM-yyyy") + "' and status = 0";
                string sql = "SELECT vd.*,'0' AS IsHighLight  FROM voucherdetail vd WHERE clearentry = " + (clear == "All" ? "clearentry" : clear) + " and fkaccountid = '" + AccountHead.CashInBank + "' and  fkbankid = '" + fkbankCode + "'  AND Trunc(Vdate) <=  '" + TDate.ToString("dd-MMM-yyyy") + "' and status = 0";
                adapter.SelectCommand = new OracleCommand(sql, clsConnection.con);
                adapter.Fill(dt);
                adapter.Dispose();
                return dt;
            }
            catch (Exception ee)
            {
                Errors.writeline(ee.Message, "Query_ VoucherDetail");
                string result = MyMessageBox.ShowBox(ee.Message, Variable.Version, 1);


                return dt;
            }
        }
        internal static DataTable BankReconcilation(string Account, DateTime Fdate, DateTime Tdate)
        {
            string sql = "select clear,vdate,vtype +'-'+ VoucherNo Vno,vseq,CheckNum,CheckDate,ClearDate  ,dbo.Get_Title(particular) title,dr,cr   from GL_Detail  where status = 0 and checknum is not null and account = '" + Account + "' and vdate between '" + Fdate.ToString("MM/dd/yyyy") + "' and '" + Tdate.ToString("MM/dd/yyyy") + "'";
            DataTable dt = getData(sql);
            return dt;
        }
        internal static DataTable CashBanks()
        {
            string sql = "select   lvl5 Account,lvl5Title Title  from vu_ChartofAccount where lvl3 = '001002002'";
            DataTable dt = getData(sql);
            return dt;
        }
        internal static DataTable UserDetail(string UserId)
        {
            string sql = "select *,sysdate LogIndate from users where userid = '" + UserId + "' and status = '0' and softwaremodule='ERP'";
            DataTable dt = getData(sql);
            return dt;
        }
        internal static DataTable SessionBalance(string UserId)
        {
            string sql = "SELECT nvl(Sum(CASE WHEN memberid IS NOT NULL THEN 0 ELSE  netamount END ),0) netamount FROM opdreceipt WHERE status = 0 AND sessionid = (SELECT sessionid FROM usersession WHERE USERid = '" + UserId + "' AND status = 2)";
            DataTable dt = getData(sql);
            return dt;
        }
        internal static DataTable SessionBalanceAddPartialPayment(string UserId)
        {
            string sql = @"
                    SELECT
                        netamount,
                        partial_amount,
                        netamount + partial_amount AS total_amount
                    FROM (
                        SELECT
                            NVL(SUM(CASE WHEN memberid IS NOT NULL THEN 0 ELSE netamount + electricitycharges END), 0) AS netamount
                        FROM
                            opdreceipt
                        WHERE
                            status = 0
                            AND sessionid = (
                                SELECT sessionid
                                FROM usersession
                                WHERE userid = '" + UserId + @"'
                                AND status = 2
                            )
                    ) t1
                    CROSS JOIN (
                        SELECT
                            NVL(SUM(partialamount), 0) AS partial_amount
                        FROM
                            Partialreceipt p
                        WHERE
                            p.status = 0
                            AND p.sessionid = (
                                SELECT sessionid
                                FROM usersession
                                WHERE userid = '" + UserId + @"'
                                AND status = 2
                            )
                    ) t2
                    ";

            DataTable dt = getData(sql);
            return dt;
        }
        internal static decimal Balance(string Account)
        {
            decimal bal = 0;
            string sql = "select isnull(sum(dr - CR),0) from GL_Detail where status = 0  and account = '" + Account + "'";
            DataTable dt = getData(sql);
            if (dt.Rows.Count > 0) bal = decimal.Parse(dt.Rows[0][0].ToString());
            return bal;
        }
        internal static decimal Balance(DateTime VDate, string Account)
        {
            decimal bal = 0;
            string sql = "select isnull(sum(dr - CR),0) from GL_Detail where status = 0 and vdate <= '" + VDate.ToString("MM/dd/yyyy") + "'  and account = '" + Account + "'";
            DataTable dt = getData(sql);
            if (dt.Rows.Count > 0) bal = decimal.Parse(dt.Rows[0][0].ToString());
            return bal;
        }
        internal static decimal Balance(DateTime VDate, string Account, string clear)
        {
            decimal bal = 0;
            string sql = "select isnull(sum(dr - CR),0) from GL_Detail where status = 0 and vdate <= '" + VDate.ToString("MM/dd/yyyy") + "'  and clear = " + clear + " and account = '" + Account + "'";
            DataTable dt = getData(sql);
            if (dt.Rows.Count > 0) bal = decimal.Parse(dt.Rows[0][0].ToString());
            return bal;
        }
        internal static DataTable UserInformation()
        {
            string sql = @"select * from users WHERE softwaremodule='ERP'";
            DataTable dt = getData(sql);
            return dt;
        }
        internal static DataTable UserSearh(string id)
        {
            string sql = @"select * from users where userid='" + id + "'";
            DataTable dt = getData(sql);
            return dt;
        }
        internal static DataTable AdmInfo(string regAlpha, string regNum, string billno)
        {
            //string sql = @"SELECT regnoalpha, regnonumeric,admissionid, admdate, admtime, get_roomtitle(adm.roomid) roomTitle,get_patienttype( patienttype) patienttype,get_consultantname(consultantid) ConsultantName,
            //                title || patientname patientname ,get_roomtitle(inpr.roomid) AS currentRoom,
            //                gender, to_char(To_Number(age)) || ' ' || SubStr(ymd,1,1) age,remarks,dischargeyn as discyn,dischargedate as discdate , referencename FROM  admissioninfo adm
            //                left JOIN inpcurrentroom inpr ON adm.serialno= inpr.fkserialno  WHERE regnoAlpha = '" + regAlpha + "' AND regnonumeric = '" + regNum + "' AND adm.status = 0  ORDER BY admdate DESC ";
            string abc = "AND ipdbillid = " + billno;

            if (billno == "")
            {
                abc = "OR ipdbillid = ''";
            }

            string sql = $" SELECT ipdbillid,regnoalpha,regnonumeric,adm.admissionid, admdate, admtime, get_roomtitle(adm.roomid) roomTitle,get_patienttype( patienttype) patienttype,get_consultantname(consultantid) ConsultantName,title || patientname patientname ,get_roomtitle(inpr.roomid) AS currentRoom, gender, to_char(To_Number(age)) || ' ' || SubStr(ymd,1,1) age,adm.remarks,dischargeyn as discyn,adm.dischargedate as discdate , referencename FROM  admissioninfo adm left JOIN inpcurrentroom inpr ON adm.serialno= inpr.fkserialno left JOIN   ipdbilling pl ON pl.admissionid = adm.admissionid WHERE regnoAlpha =  '{regAlpha}' AND regnonumeric = '{regNum}' AND adm.status = 0 {abc} ORDER BY admdate DESC";
            DataTable dt = getData(sql);
            return dt;
        }
        internal static DataTable OPDreceptInfo(string ReceptNo)
        {
            string sql = $"SELECT * FROM opdRECEIPT  o JOIN consultant c ON c.id = o.consultantid WHERE status = 0 and  receiptno = '" + ReceptNo + "'";
            DataTable dt = getData(sql);
            return dt;
        }
        internal static DataTable AdmInfo1(string regAlpha, string regNum)
        {
            string q = @" SELECT * FROM (   
                        SELECT nextappointmentdate FROM ipdbilling WHERE   admissionid =(SELECT * FROM ((SELECT admissionid FROM admissioninfo
                         WHERE regnoalpha = '" + regAlpha + "' AND regnonumeric = '" + regNum + "' AND dischargedate IS NOT NULL ORDER  BY admissionid DESC))WHERE ROWNUM = 1 ))";
            DataTable dtt = getData(q);
            return dtt;

        }
        internal static DataTable checkCurrentRoom(string regAlpha, string regNum)
        {
            string sql = @"SELECT regnoalpha, regnonumeric,admissionid, admdate, admtime, get_roomtitle(adm.roomid) roomTitle,get_patienttype( patienttype) patienttype,get_consultantname(consultantid) ConsultantName,
                            title || patientname patientname ,get_roomtitle(inpr.roomid) AS currentRoom,
                            gender, to_char(To_Number(age)) || ' ' || SubStr(ymd,1,1) age,remarks,dischargeyn as discyn,dischargedate as discdate , referencename FROM  admissioninfo adm
                            left JOIN inpcurrentroom inpr ON adm.serialno= inpr.fkserialno  WHERE regnoAlpha = '" + regAlpha + "' AND regnonumeric = '" + regNum + "' AND adm.status = 0 ";
            DataTable dt = getData(sql);

            return dt;

        }
        internal static DataTable RecInfo(string serialNo)
        {
            string sql = @"SELECT id,admissionid,vdate,receiptmode,amount,createdby,createdtime,editby,edittime,terminalid,status FROM ADVANCERECEIPT WHERE admissionid ='" + serialNo + "' order by To_Number(id) desc ";
            DataTable dt = getData(sql);
            return dt;

        }
        internal static DataTable PartiallyDetail(string RegNo)
        {     
            string sql = "";
            sql = "SELECT  receiptno AS id,receiptno,vdate,grossamount,netamount,createdby,createdtime,editby,edittime,terminalid,status FROM opdRECEIPT WHERE status = 0 and  receiptno = '" + RegNo+"' ";
            sql += " UNION ALL ";
            sql += "SELECT  id,receiptno,vdate,0,partialamount,createdby,createdtime,editby,edittime,terminalid,status FROM Partialreceipt WHERE   receiptno = '"+ RegNo + "' ORDER BY vdate ASC";
            DataTable dt = getData(sql);
            return dt;

        }
        internal static DataTable PartiallyDetailForReport(string RegNo,string ID)
        {
            string sql = "";
            sql = "SELECT  receiptno AS id,receiptno,vdate,grossamount,netamount,createdby,createdtime,editby,edittime,terminalid,status FROM opdRECEIPT WHERE status = 0 and  receiptno = '" + RegNo + "' ";
            sql += " UNION ALL ";
            sql += "SELECT  id,receiptno,vdate,0,partialamount,createdby,createdtime,editby,edittime,terminalid,status FROM Partialreceipt WHERE   receiptno = '" + RegNo + "'  AND id !='"+ ID +"' ORDER BY vdate ASC";
            DataTable dt = getData(sql);
            return dt;

        }
        internal static DataTable PayInfo(string recinfo)
        {
            string sql = "SELECT id,vdate,amount,receiptmode FROM ADVANCERECEIPT WHERE id='" + recinfo + "'";
            DataTable dt = getData(sql);
            return dt;
        }
        internal static DataTable PartialInfo(string receiptNo, string ID)
        {
            string sql = "";
            if (receiptNo != "" && ID != "")
            {
                sql = "SELECT id,receiptno,vdate,partialamount,receiptmode FROM Partialreceipt WHERE receiptno='" + receiptNo + "' AND id ='"+ID+"'";
            }
            else
            {
                sql = "SELECT * FROM (SELECT * FROM Partialreceipt WHERE receiptno = '"+ receiptNo + "' ORDER BY vdate DESC) WHERE ROWNUM = 1";
            }
            
            DataTable dt = getData(sql);
            return dt;
        }
        internal static DataTable PackageInfo()
        {
            string sql = "SELECT * FROM PACKAGEINDEX order by to_number(package_id)";
            DataTable dt = getData(sql);
            return dt;
        }
        internal static DataTable PackageIndex()
        {
            string sql = @"select package_id,packagename_name ||  lpad( ' ',50 -length(packagename_name)  ,' ') || ' |   ' || Nvl(amount,0) packagename_name,Nvl(amount,0) as amount from packageindex where isdeactivate=0 order by to_number(package_id)";
            DataTable dt = getData(sql);
            return dt;
        }
        internal static DataTable PackageIndexAll()
        {
            string sql = @"select package_id,packagename_name ||  lpad( ' ',50 -length(packagename_name)  ,' ') || ' |   ' || Nvl(amount,0) packagename_name,Nvl(amount,0) as amount from packageindex  order by to_number(package_id)";
            DataTable dt = getData(sql);
            return dt;
        }
        internal static DataTable PackageInformation(string id)
        {
            string sql = @"SELECT package_id,packagename_name,amount,isdeactivate,surgeryid FROM PACKAGEINDEX WHERE package_id='" + id + "'order by package_id";
            DataTable dt = getData(sql);
            return dt;
        }
        internal static DataTable RoomInfo()
        {
            string sql = @"SELECT * FROM ROOMINDEX order by id";
            DataTable dt = getData(sql);
            return dt;
        }
        internal static DataTable RoomSearch(string id)
        {
            string sql = @"SELECT id,fullname,description,floornumber,hospitalrate FROM ROOMINDEX where id='" + id + "' order by id ";
            DataTable dt = getData(sql);
            return dt;
        }
        internal static DataTable RoomCharges()
        {
            string sql = @"select id,fullname,hospitalrate from roomindex";
            DataTable dt = getData(sql);
            return dt;
        }
        internal static DataTable ReferenceInfo()
        {
            string sql = @"select * from reference";
            DataTable dt = getData(sql);
            return dt;
        }
        internal static DataTable ReferenceSearch(string id)
        {
            string sql = @"select * from reference where id='" + id + "'";
            DataTable dt = getData(sql);
            return dt;
        }
        internal static DataTable InpatientTestSearch(string Seq)
        {
            string sql = @"select * from inptestcharges where Vseq='" + Seq + "'";
            DataTable dt = getData(sql);
            return dt;
        }
        internal static DataTable InPatientTestInfo(string serialno, string billno, string testtypeid, string ReceiptNo)
        {
            //string sql = @"SELECT receiptno,VSeq,get_consultantname(consultantid)AS Consultant,charges,get_testtitle(testid)AS Test ,receiptdate,createdby FROM inptestcharges WHERE status = '0' AND  serialno='" + serialno + "' AND billno='" + billno + "' AND testtypeid='" + testtypeid + "' and receiptno = Nvl('" + ReceiptNo + "',receiptno) ";
            string sql = @"SELECT receiptno,VSeq,get_consultantname(consultantid)AS Consultant,charges,get_testtitle(testid)AS Test ,receiptdate,createdby FROM inptestcharges WHERE status = '0' AND  serialno='" + serialno + "' AND billno='" + billno + "' AND testtypeid='" + testtypeid + "' and receiptno = Nvl('" + ReceiptNo + "',receiptno) ";

            DataTable dt = getData(sql);
            return dt;
        }
        internal static DataTable InPatientTestInfo(string testtypeid, string ReceiptNo, string serialno)
        {
            //string sql = @"SELECT receiptno,VSeq,get_consultantname(consultantid)AS Consultant,charges,get_testtitle(testid)AS Test ,receiptdate,createdby FROM inptestcharges WHERE status = '0' AND  serialno='" + serialno + "' AND billno='" + billno + "' AND testtypeid='" + testtypeid + "' and receiptno = Nvl('" + ReceiptNo + "',receiptno) ";

            //basit commit this code 19-08-2020
            /*
            string sql = @"SELECT receiptno,VSeq,get_consultantname(consultantid)AS Consultant,charges,get_testtitle(testid)AS Test ,receiptdate,createdby FROM inptestcharges WHERE status = '0' AND testtypeid='" + testtypeid + "' and receiptno = Nvl('" + ReceiptNo + "',receiptno) and serialno =  '" + serialno + "'";
            */

            //basit write this code 19-08-2020
            string sql = @"SELECT receiptno,VSeq,get_consultantname(consultantid)AS Consultant,charges,get_testtitle(testid)AS Test ,receiptdate,createdby,editby,edittime,status,testid FROM inptestcharges WHERE testtypeid='" + testtypeid + "' and receiptno = Nvl('" + ReceiptNo + "',receiptno) and serialno =  '" + serialno + "' order by status,receiptno desc";

            DataTable dt = getData(sql);
            return dt;
        }
        internal static DataTable BillDetail(string AddmissionId)
        {
            DataTable dt;
            string sql = @"SELECT admiss.regnoalpha,admiss.regnonumeric,ipdbillid,dischargeyn,dischargesessionid,ipd.*,ipd.zakatadddate AS zakatadddatenew from ipdbilling ipd
                            INNER JOIN admissioninfo admiss ON  admiss.admissionid = ipd.admissionid 
                            where ipd.admissionid = '" + AddmissionId + "'";

            dt = getData(sql);
            return dt;
        }
        internal static DataTable RoomChargesSeacrh(string serialno)
        {
            string sql = @"SELECT vseq,get_roomtitle(roomtypeid) as room ,datefrom,dateto,days,To_Number(get_roomcharges(roomtypeid)) AS charges,charges AS total,edittime,editby,createdby,createtime,status FROM inproomcharges WHERE  serialno='" + serialno + "' order by status,vseq desc ";
            DataTable dt = getData(sql);
            return dt;
        }
        //basit 09-07-2020 start 
        internal static DataTable RoomChargesDay(string serialno, string billno)
        {
            string sql = @" SELECT To_Number( Trunc(SYSDATE) - Trunc(admdate)) AS Days , admdate as AddmissionDate FROM admissioninfo WHERE  serialno='" + serialno + "'";
            DataTable dt = getData(sql);
            return dt;
        }
        //basit 09-07-2020 end 
        internal static DataTable DepositAmount(string serialno)
        {
            string sql = @"SELECT Nvl(Sum(amount),0) as amount from advancereceipt where status = 0 and admissionid='" + serialno + "'";
            DataTable dt = getData(sql);
            return dt;
        }
        internal static DataTable SurgerySearch(string serialno)
        {
            string sql = @"SELECT vseq,get_consultantname(consultantid) AS consultant ,get_packagename(surgery) surgery,charges,Otfixed,nitrous,recovery,get_consultantname(anaesthetist) anaesthetist,anaescharges,get_consultantname(consultantid2) AS Consultant_2,status,createdby,createtime,editby,edittime FROM 
                  inpsurgerycharges WHERE serialno='" + serialno + "' order by status,vseq desc ";
            DataTable dt = getData(sql);
            return dt;
        }
        internal static DataTable DeliverySearch(string serialno)
        {
            string sql = @"SELECT vseq,get_consultantname(consultantid)AS consultant,get_testtitle(delivery) as Test,charges,lramount,recoveryamount,createdby,createtime,edittime,editby,status FROM inpdeliverycharges where serialno='" + serialno + "' order by status,vseq desc";
            DataTable dt = getData(sql);
            return dt;
        }
        internal static DataTable ConsultantSearch(string serialno)
        {
            string sql = @"SELECT vseq As vseq,get_consultantname(consname) AS consultant,charges,visits,visits*charges AS total,createdby,createtime,status,editby,edittime,get_consultantCategory(consname) AS Category FROM inpconsultantcharges where serialno='" + serialno + "'  order by status,vseq desc";
            DataTable dt = getData(sql);
            return dt;
        }
        internal static DataTable MiscSearch(string serialno)
        {
            string sql = @"SELECT vseq As vseq,miscdesc,charges,status,createdby,createtime,editby,edittime FROM inpmisccharges where serialno='" + serialno + "'  order by status,vseq desc ";
            DataTable dt = getData(sql);
            return dt;
        }
        internal static DataTable IPDAdmissioninfo(string serialno)
        {
            string sql = @"SELECT testid,receiptdate,patientname,ymd,age,gender,mobile,title FROM inptestcharges left JOIN  admissioninfo ON inptestcharges.serialno=admissioninfo.serialno  WHERE testtypeid='5' AND inptestcharges.receiptno='" + serialno + "'";
            DataTable dt = getData(sql);
            return dt;
        }
        internal static DataTable UserlevelIndex()
        {
            string sql = @"select * from userlevel";
            DataTable dt = getData(sql);
            return dt;
        }
        internal static DataTable UserLoginIndex()
        {
            string sql = @"SELECT userid FROM users WHERE status=0 AND islock=0";
            DataTable dt = getData(sql);
            return dt;
        }
        internal static DataTable InPSearch(string[] filter)
        {
            string Filter = filter.Count() > 0 ? string.Join(" ", filter) : "";
            string sql = @"select regnoalpha ||'-' ||regnonumeric as regno,patientname,relationname,get_roomtitle( roomid) as room,get_consultantname(consultantid)as consultant,admdate,admissionid,To_number(dischargeyn) as dischargeyn,emergency from admissioninfo where  status = 0  " + Filter + " ";
            DataTable dt = getData(sql);
            return dt;
        }
        //basit 14-07-2020
        internal static DataTable BirthDate(string serialno)
        {
            string sql = @" SELECT get_consultantname(b.consult) AS consultants,b.*  FROM  birthinfo b  WHERE b.serialno= '" + serialno + "' and status=0";
            DataTable dt = getData(sql);
            return dt;
        }
        //basit 21-07-2020
        internal static DataTable IPDReceiptTestDepartmentIndex(string Vno)
        {
            string sql = @"select DISTINCT  iptc.receiptno,t.id,t.title,d.id departmentid ,d.title departmentTitle
                           FROM ADMISSIONINFO  ad
                           left JOIN inptestcharges iptc ON  iptc.serialno = ad.serialno
                           left JOIN test t ON t.id = iptc.testid
                           left JOIN departments d ON d.id = t.testheadid
                           WHERE  iptc.receiptno = '" + Vno + "' AND iptc.testtypeid = '2'";
            DataTable dt = getData(sql);
            return dt;
        }
        //BASIT 28-07-2020
        /*//internal static DataTable CatagoryTestIndex()
        //{
        //    string sql = "SELECT to_char(id) id,title,hospitalrate,testtypeid FROM test where isdeactivated = 0 ORDER BY title";
        //    DataTable dt = getData(sql);
        //    return dt;
        //}*/
        internal static DataTable TestTypeId(string typeid)
        {
            //string sql = "SELECT to_char(id) id,title,hospitalrate,testtypeid FROM test where testtypeid = " + typeid + " AND isdeactivated = 0 ORDER BY title";
            string sql = "SELECT to_char(id) id,title,hospitalrate,testtypeid FROM test where testtypeid = '" + typeid + "' AND isdeactivated = 0 ORDER BY title";

            DataTable dt = getData(sql);
            return dt;
        }
        internal static DataTable TwoMonthCount(string CurrentDate, string admitDate, string regNo)
        {
            //            string sql = @" SELECT
            //                           (EXTRACT( MONTH FROM TO_DATE( '" + CurrentDate + "','dd/Mon/yyyy') ))  - (EXTRACT( MONTH FROM TO_DATE( '" + CurrentDate + "','dd/Mon/yyyy') )  - 2) AS  Month FROM DUAL";
            string sql = @" select EXTRACT( MONTH FROM TO_DATE( '" + CurrentDate + "' ,'dd/Mon/yyyy'))  - EXTRACT( MONTH FROM TO_DATE('" + admitDate + "','dd/Mon/yyyy')) AS  Month FROM admissioninfo WHERE regnonumeric ='" + regNo + "'";
            DataTable dt = getData(sql);
            return dt;
        }
        internal static DataTable IPDbillingAmount(string serialNo)
        {
            string sql = @" SELECT totalcharges AS totalcharges,nvl(adv.amount,0) AS depositeAmount, totdiscount AS discount,                                    
                            CASE WHEN nvl(to_number(ipdbill.refundamount) , 0 ) > 0 THEN                                                                         
                            CASE WHEN totdiscount > 0 THEN  nvl(to_number(ipdbill.refundamount),0) ELSE nvl(to_number(ipdbill.refundamount),0) END ELSE          
                            Nvl( to_number( totalcharges + nvl(to_number(ipdbill.refundamount) , 0 ) - nvl(adv.amount,0)),0) - totdiscount END  AS toberefunded, 
                            totalcharges + nvl(to_number(ipdbill.refundamount) , 0 ) - nvl(adv.amount,0) - totdiscount  AS netbalance,                           
                            nvl(to_number(ipdbill.refundamount) , 0 ) + totalcharges -nvl(adv.amount,0) - totdiscount AS RefundAmount                            
                            FROM IPDBilling  ipdbill                                                                                                             
                            left  JOIN (SELECT admissionid,Sum(amount) amount FROM advancereceipt                                                                
                            where status = 0 GROUP BY admissionid) adv ON adv.admissionid =   ipdbill.admissionid                                                
                            WHERE ipdbill.admissionid ='" + serialNo + "'";

            DataTable dt = getData(sql);
            return dt;
        }
        internal static DataTable LocationIndex()
        {
            string sql = "SELECT DISTINCT t.location as Location FROM test t WHERE t.location IN('MMC','ESSA','BEH') GROUP BY t.location";
            DataTable dt = getData(sql);
            return dt;
        }
        internal static DataTable cmbTestIndex()
        {
            string sql = "SELECT to_char(id) id,title,hospitalrate,testtypeid FROM test  WHERE isdeactivated = 0 ORDER BY Title";
            DataTable dt = getData(sql);
            return dt;
        }
        internal static DataTable cmbTestIndexFilter(string testid)
        {
            string sql = "SELECT to_char(id) id,title,hospitalrate,testtypeid FROM test  WHERE isdeactivated = 0 " + (testid == "All" ? "" : "AND testtypeid = '" + testid + "'") + " ORDER BY Title";
            DataTable dt = getData(sql);
            return dt;
        }
        internal static DataTable ZakatRecipient()
        {
            string sql = "SELECT id,name FROM Reference where isactive=1 ORDER BY lower(name)";
            DataTable dt = getData(sql);
            return dt;
        }
        internal static DataTable MBGMember()
        {
            string SQL = "SELECT To_Char(newno) newno,newno || '   ' || name  as name FROM member";
            DataTable DT = getData(SQL);
            return DT;
        }
        //-------------------------------------------//
        internal static DataTable searchbirth(string from, string to, string father, string mother)
        {

            string sql = @" SELECT To_Char(bth.birthdate, 'dd-MON-yyyy') AS birthdate, fathername,mothername , adm.regnoalpha || '-' || adm.regnonumeric AS fileNo FROM birthinfo bth
                            left JOIN admissioninfo adm ON adm.serialno = bth.serialno  where (trunc(birthdate)   
                            between TO_DATE('" + from + "', 'dd MON yyyy')  and TO_DATE('" + to + "', 'dd MON yyyy') ) " +
                            "" + mother + " " + father + " and bth.status=0";


            DataTable dt = getData(sql);

            return dt;
        }
        public static DataTable BankIndex()
        {
            DataTable dt = new DataTable();
            try
            {
                OracleDataAdapter adapter = new OracleDataAdapter();
                adapter.SelectCommand = new OracleCommand("select bankcode,branchname,BankName,iban from BankDetail Where Status=0", clsConnection.con);
                adapter.Fill(dt);
                adapter.Dispose();
                return dt;
            }
            catch (Exception ee)
            {
                //Errors.writeline(ee.Message, "Query_BankIndex");
                //string result = MyMessageBox.ShowBox(ee.Message, Variable.Version, 1);
                //string err = MyMessageBox.ShowBox("Do you want to Exit ?", Variable.Version, 2);
                //if (err == "1")
                //     Application.Exit();
                return dt;
            }
        }
        public static DataTable Voucher(string VNo, string Fkbrcode, string Vtype)
        {
            DataTable dt = new DataTable();
            try
            {
                OracleDataAdapter adapter = new OracleDataAdapter();
                //string sql = "select VDate,VNO,(select narrationtitle from narration where narrationcode = fktransactionid) as Narration,cr as Amount from Voucherdetail where ( VDate between '" + From + "' and '" + To + "') and FK_Narration = " + Narration + " and VNO = " + VNO + "  and Vtype = 'PV' and status = 0 AND Vseq = 1";
                string sql = @"select vd.*,Nvl(get_Clienttitle(fkclientcode),Nvl(get_banktitle(fkbankid),(SELECT accounttitle FROM chartofaccounts WHERE accountid = vd.fkaccountid) )) AS title,
                   (CASE WHEN  trunc(To_Date(vdate,'dd Mon yyyy')) = trunc(To_Date(SYSDATE,'dd Mon yyyy')) THEN 1 ELSE 0 END)  AS editable from Voucherdetail vd 
                    where VNO = '" + VNo + "' AND  fkbrcode = '" + Fkbrcode + "'   AND  vtype = '" + Vtype + "' and status <> 1 ORDER BY vseq asc";
                adapter.SelectCommand = new OracleCommand(sql, clsConnection.con);
                adapter.Fill(dt);
                adapter.Dispose();
                return dt;
            }
            catch (Exception ee)
            {
                Errors.writeline(ee.Message, "Query_ PaymentFilter");
                string result = MyMessageBox.ShowBox(ee.Message, Variable.Version, 1);
                string err = MyMessageBox.ShowBox("Do you want to Exit ?", Variable.Version, 2);
                //if (err == "1") Application.Exit();
                return dt;
            }
        }
        public static DataTable getVoucher_TellerClosing(string VSession, string Fkbrcode)
        {
            DataTable dt = new DataTable();
            try
            {
                OracleCommand comm = new OracleCommand("get_voucher_teller_closing", clsConnection.con);
                comm.CommandType = CommandType.StoredProcedure;
                
                comm.Parameters.Add("VSession", OracleDbType.Varchar2).Value = VSession;
                comm.Parameters.Add("Vtype", OracleDbType.Varchar2).Value = "";
                comm.Parameters.Add("Vfkbrcode", OracleDbType.Varchar2).Value = Fkbrcode;
                comm.Parameters.Add("retval", OracleDbType.RefCursor);
                comm.Parameters["retval"].Direction = ParameterDirection.Output;

                OracleDataAdapter adapter = new OracleDataAdapter();
                adapter.SelectCommand = comm;
                adapter.Fill(dt);
                adapter.Dispose();
                return dt;
            }
            catch (Exception ee)
            {
                Errors.writeline(ee.Message, "Query_ PaymentFilter");
                string result = MyMessageBox.ShowBox(ee.Message, Variable.Version, 1);
                string err = MyMessageBox.ShowBox("Do you want to Exit ?", Variable.Version, 2);
                //if (err == "1") Application.Exit();
                return dt;
            }
        }
        public static DataTable GetDocTimings(string consultantId)
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT id, days, start_time, end_time, status FROM doc_schedule_time WHERE consultantId = :VDocId ORDER BY ID";
                OracleDataAdapter adapter = new OracleDataAdapter();
                adapter.SelectCommand = new OracleCommand(sql, clsConnection.con);
                adapter.SelectCommand.Parameters.Add("VDocId", OracleDbType.Varchar2).Value = consultantId;
                adapter.Fill(dt);
                adapter.Dispose();
                return dt;
            }
            catch (Exception ee)
            {
                Errors.writeline(ee.Message, "Query_GetDocTimings");
                string result = MyMessageBox.ShowBox(ee.Message, Variable.Version, 1);
                return dt;
            }
        }

        public static DataTable save_docTimings(string id, string timingid, string docid, DateTime starttime, DateTime endtime)
        {
            DataTable dt = new DataTable();
            try
            {
                OracleCommand comm = new OracleCommand("save_doctor_timings", clsConnection.con);
                comm.CommandType = CommandType.StoredProcedure;

                comm.Parameters.Add("VDayId", OracleDbType.Varchar2).Value = id;
                comm.Parameters.Add("VtimingId", OracleDbType.Varchar2).Value = timingid;
                comm.Parameters.Add("VDocId", OracleDbType.Varchar2).Value = docid;
                comm.Parameters.Add("VStarttime", OracleDbType.TimeStamp).Value = starttime;
                comm.Parameters.Add("VEndTime", OracleDbType.TimeStamp).Value = endtime;

                comm.ExecuteNonQuery();
                
                return dt;
            }
            catch (Exception ee)
            {
                Errors.writeline(ee.Message, "Query_ PaymentFilter");
                string result = MyMessageBox.ShowBox(ee.Message, Variable.Version, 1);
                string err = MyMessageBox.ShowBox("Do you want to Exit ?", Variable.Version, 2);
                //if (err == "1") Application.Exit();
                return dt;
            }
        }
        public static decimal BankBal(string bankcode)
        {
            DataTable dt = new DataTable();
            decimal bal = 0;
            try
            {
                OracleDataAdapter adapter = new OracleDataAdapter();
                string sql = "select nvl(sum(dr-cr),0) AS balance from voucherdetail where fkaccountid = '001001005002001' and fkbankid = '" + bankcode + "'";
                adapter.SelectCommand = new OracleCommand(sql, clsConnection.con);
                adapter.Fill(dt);
                adapter.Dispose();
                if (dt.Rows.Count > 0)
                    bal = decimal.Parse(dt.Rows[0][0].ToString());
                return bal;
            }
            catch (Exception ee)
            {
                Errors.writeline(ee.Message, "Query_ BankBal");
                string result = MyMessageBox.ShowBox(ee.Message, Variable.Version, 1);
                string err = MyMessageBox.ShowBox("Do you want to Exit ?", Variable.Version, 2);
                //   if (err == "1") Application.Exit();
                return bal;
            }
        }
        public static decimal CashBal()
        {
            DataTable dt = new DataTable();
            decimal bal = 0;
            try
            {
                OracleDataAdapter adapter = new OracleDataAdapter();
                string sql = "select nvl(sum(dr-cr),0) AS balance from voucherdetail where fkaccountid = '001001005001001'";
                adapter.SelectCommand = new OracleCommand(sql, clsConnection.con);
                adapter.Fill(dt);
                adapter.Dispose();
                if (dt.Rows.Count > 0)
                    bal = decimal.Parse(dt.Rows[0][0].ToString());
                return bal;
            }
            catch (Exception ee)
            {
                Errors.writeline(ee.Message, "Query_ CashBal");
                string result = MyMessageBox.ShowBox(ee.Message, Variable.Version, 1);
                string err = MyMessageBox.ShowBox("Do you want to Exit ?", Variable.Version, 2);
                // if (err == "1") Application.Exit();
                return bal;
            }
        }
        public static DataTable ClientIndex()
        {
            DataTable dt = new DataTable();
            try
            {
                OracleDataAdapter adapter = new OracleDataAdapter();
                adapter.SelectCommand = new OracleCommand("SELECT clientid,clienttitle FROM clients WHERE status  != 1 order by clienttitle", clsConnection.con);
                adapter.Fill(dt);
                adapter.Dispose();
                return dt;
            }
            catch (Exception ee)
            {
                Errors.writeline(ee.Message, "Query_ ClientIndex2");
                string result = MyMessageBox.ShowBox(ee.Message, Variable.Version, 1);
                string err = MyMessageBox.ShowBox("Do you want to Exit ?", Variable.Version, 2);
                //   if (err == "1") Application.Exit();
                return dt;
            }
        }
        /*//string sql = "select VDate,VNO,(select narrationtitle from narration where narrationcode = fktransactionid) as Narration,cr as Amount from Voucherdetail where ( VDate between '" + From + "' and '" + To + "') and FK_Narration = " + Narration + " and VNO = " + VNO + "  and Vtype = 'PV' and status = 0 AND Vseq = 1";
        //@"select VDate,VNO,(select narrationtitle from narration where narrationcode = fktransactionid) as Narration,
        //cr as Amount from Voucherdetail 
        //where ( trunc(VDate)   between TO_DATE('" + From + "', 'dd MON yyyy')  and TO_DATE('" + To + "', 'dd MON yyyy') ) " +
        //Narration + "  " + VNO + "  and Vtype = 'PV' and status != 1 AND Vseq = 1";

        //public static DataTable PaymentFilter1New(string From, string To, string Narration, string VNO, string filter)
        //{
        //    DataTable dt = new DataTable();
        //    try
        //    {
        //        OracleDataAdapter adapter = new OracleDataAdapter();
        //        string sql = @"select VDate,VNO,(select narrationtitle from narration where narrationcode = fktransactionid) as Narration,
        //        Sum(cr) as Amount from Voucherdetail 
        //        where ( trunc(VDate)   between TO_DATE('" + From + "', 'dd MON yyyy')  and TO_DATE('" + To + "', 'dd MON yyyy') ) " +
        //        "and Vtype = 'PV' and status != 1 AND status = CASE WHEN '" + filter + "'='ALL' THEN status ELSE CASE WHEN '" + filter + "' = 'Pending' THEN 2 ELSE 0 END END GROUP BY VDate,VNO,fktransactionid";
        //        adapter.SelectCommand = new OracleCommand(sql, clsConnection.con);
        //        adapter.Fill(dt);
        //        adapter.Dispose();
        //        return dt;
        //    }
        //    catch (Exception ee)
        //    {
        //        Errors.writeline(ee.Message, "Query_ PaymentFilter");
        //        string result = MyMessageBox.ShowBox(ee.Message, Variable.Version, 1);
        //        return dt;
        //    }
        //}*/
        public static DataTable PaymentFilter1New(string From, string To, string Narration, string VNO, string filter)
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = @"
                    SELECT VDate, VNO,
                           (SELECT narrationtitle FROM narration WHERE narrationcode = fktransactionid) AS Narration,
                           SUM(cr) AS Amount
                    FROM Voucherdetail
                    WHERE Vtype = 'PV'
                      AND status != 1";

                // Only apply date filter if VNO is empty
                if (string.IsNullOrWhiteSpace(VNO))
                {
                    sql += @" AND TRUNC(VDate) BETWEEN TO_DATE('" + From + @"', 'dd MON yyyy') 
                                       AND TO_DATE('" + To + @"', 'dd MON yyyy')";
                }

                // Add narration filter
                if (Narration != "ALL")
                {
                    sql += " AND fktransactionid = '" + Narration + "'";
                }

                // Add VNO filter
                if (!string.IsNullOrWhiteSpace(VNO))
                {
                    sql += " AND VNO = " + VNO;
                }

                // Add status filter
                if (filter != "ALL")
                {
                    if (filter == "Pending")
                        sql += " AND status = 2";
                    else
                        sql += " AND status = 0";
                }

                sql += " GROUP BY VDate, VNO, fktransactionid";

                OracleDataAdapter adapter = new OracleDataAdapter(sql, clsConnection.con);
                adapter.Fill(dt);
                adapter.Dispose();
                return dt;
            }
            catch (Exception ee)
            {
                Errors.writeline(ee.Message, "Query_ PaymentFilter");
                MyMessageBox.ShowBox(ee.Message, Variable.Version, 1);
                return dt;
            }
        }
        public static DataTable CallInvDoucment(string doucmentno)
        {
            DataTable dt = new DataTable();
            try
            {
                OracleDataAdapter adapter = new OracleDataAdapter();
                adapter.SelectCommand = new OracleCommand("select documents From documents Where documentid='" + doucmentno + "'", clsConnection.con);
                adapter.Fill(dt);
                adapter.Dispose();
                return dt;
            }
            catch (Exception ee)
            {
                Errors.writeline(ee.Message, "Query_CallInvDoucment");
                string result = MyMessageBox.ShowBox(ee.Message, Variable.Version, 1);
                string err = MyMessageBox.ShowBox("Do you want to Exit ?", Variable.Version, 2);
                // if (err == "1") Application.Exit();
                return dt;
            }
        }
        public static DataTable MasterQueryEC(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                OracleDataAdapter adapter = new OracleDataAdapter();
                adapter.SelectCommand = new OracleCommand(sql, clsConnection.con);
                adapter.Fill(dt);
                adapter.Dispose();
                return dt;
            }
            catch (Exception ee)
            {
                Errors.writeline(ee.Message, "Query_MasterQueryEC");
                return dt;
            }
        }
       /* //public static DataTable JournalFilter(string From, string To, string Narration, string VNO)
        //{
        //    DataTable dt = new DataTable();
        //    try
        //    {
        //        OracleDataAdapter adapter = new OracleDataAdapter();
        //        string sql = @"select VDate,VNO,(select narrationtitle from narration where narrationcode = fktransactionid) as Narration,
        //        dr as Amount from Voucherdetail where 
        //          ( trunc(VDate) between TO_DATE('" + From + "', 'dd MON yyyy')  and TO_DATE('" + To + "', 'dd MON yyyy')) " +
        //                 Narration + "  " + VNO + "  and Vtype = 'JV' and status != 1 AND Vseq = 1";
        //        adapter.SelectCommand = new OracleCommand(sql, clsConnection.con);
        //        adapter.Fill(dt);
        //        adapter.Dispose();
        //        return dt;
        //    }
        //    catch (Exception ee)
        //    {
        //        Errors.writeline(ee.Message, "Query_ JournalFilter");
        //        string result = MyMessageBox.ShowBox(ee.Message, Variable.Version, 1);
        //        string err = MyMessageBox.ShowBox("Do you want to Exit ?", Variable.Version, 2);
        //        return dt;
        //    }
        //}*/
        public static DataTable JournalFilter(string From, string To, string Narration, string VNO)
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = @"
            SELECT VDate, VNO,
                   (SELECT narrationtitle FROM narration WHERE narrationcode = fktransactionid) AS Narration,
                   dr AS Amount
            FROM Voucherdetail
            WHERE Vtype = 'JV'
              AND status != 1
              AND Vseq = 1";

                // ✅ Date filter only when VNO is empty
                if (string.IsNullOrWhiteSpace(VNO))
                {
                    sql += @" AND TRUNC(VDate) BETWEEN TO_DATE('" + From + @"', 'dd MON yyyy')
                                          AND TO_DATE('" + To + @"', 'dd MON yyyy')";
                }

                // ✅ Narration filter
                if (Narration != "ALL")
                {
                    sql += " AND fktransactionid = '" + Narration + "'";
                }

                // ✅ VNO filter
                if (!string.IsNullOrWhiteSpace(VNO))
                {
                    sql += " AND VNO = " + VNO;
                }

                OracleDataAdapter adapter = new OracleDataAdapter(sql, clsConnection.con);
                adapter.Fill(dt);
                adapter.Dispose();
                return dt;
            }
            catch (Exception ee)
            {
                Errors.writeline(ee.Message, "Query_ JournalFilter");
                MyMessageBox.ShowBox(ee.Message, Variable.Version, 1);
                MyMessageBox.ShowBox("Do you want to Exit ?", Variable.Version, 2);
                return dt;
            }
        }
        public static DataTable ClientIndex2()
        {
            DataTable dt = new DataTable();
            try
            {
                OracleDataAdapter adapter = new OracleDataAdapter();
                adapter.SelectCommand = new OracleCommand("SELECT * FROM clients WHERE status=0 ORDER BY clienttitle", clsConnection.con);
                adapter.Fill(dt);
                adapter.Dispose();
                return dt;
            }
            catch (Exception ee)
            {
                Errors.writeline(ee.Message, "Query_ ClientIndex2");
                string result = MyMessageBox.ShowBox(ee.Message, Variable.Version, 1);
                string err = MyMessageBox.ShowBox("Do you want to Exit ?", Variable.Version, 2);
                //  if (err == "1") Application.Exit();
                return dt;
            }
        }
        public static DataTable HRindex4()
        {
            DataTable dt = new DataTable();
            try
            {
                OracleDataAdapter adapter = new OracleDataAdapter();
                adapter.SelectCommand = new OracleCommand("SELECT  hrid,hrname,father_husbandtitle,(SELECT branchlocation FROM branchesdetail WHERE branchcode = fkbranchid) AS branch  FROM hr  WHERE status != 1", clsConnection.con);
                adapter.Fill(dt);
                adapter.Dispose();
                return dt;
            }
            catch (Exception ee)
            {
                Errors.writeline(ee.Message, "Query_ HRindex4");
                string result = MyMessageBox.ShowBox(ee.Message, Variable.Version, 1);
                string err = MyMessageBox.ShowBox("Do you want to Exit ?", Variable.Version, 2);
                //  if (err == "1") Application.Exit();
                return dt;
            }
        }
        public static DataTable DirectorIndex()
        {
            DataTable dt = new DataTable();
            try
            {
                OracleDataAdapter adapter = new OracleDataAdapter();
                adapter.SelectCommand = new OracleCommand("SELECT directorid ,directorname FROM director", clsConnection.con);
                adapter.Fill(dt);
                adapter.Dispose();
                return dt;
            }
            catch (Exception ee)
            {
                Errors.writeline(ee.Message, "Query_ DirectorIndex");
                string result = MyMessageBox.ShowBox(ee.Message, Variable.Version, 1);
                string err = MyMessageBox.ShowBox("Do you want to Exit ?", Variable.Version, 2);
                // if (err == "1") Application.Exit();
                return dt;
            }
        }
        public static DataTable DealerInfo()
        {
            DataTable dt = new DataTable();
            try
            {
                //string sysbit = String.Format("{0}", OSVersionInfo.OSBits);//Bit32//Bit64
                string sql = "SELECT code,title FROM dealersinfo where status=0 ORDER BY title";
                OracleDataAdapter adapter = new OracleDataAdapter();
                adapter.SelectCommand = new OracleCommand(sql, clsConnection.con);
                adapter.Fill(dt);
                //MessageBox.Show (  ds.Tables[0].Rows.Count.ToString());
                adapter.Dispose();
                return dt;
            }
            catch (Exception ee)
            {
                Errors.writeline(ee.Message, "Query_Rep_DealerInfo");
                string result = MyMessageBox.ShowBox(ee.Message, Variable.Version, 1);


                return dt;
            }
        }
        public static DataTable ReceiptFilterWithPendingApr(string From, string To, string Narration, string VNO, string filter)
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = @"
                     SELECT v.VDate, v.VNO, narrationtitle AS Narration,
                   SUM(dr) AS Amount
                    FROM Voucherdetail v
                    JOIN narration n ON n.narrationcode = v.fktransactionid
                    WHERE v.Vtype = 'RV'
                      AND v.status != 1";

                // ✅ Apply date filter only if VNO is not given
                if (string.IsNullOrWhiteSpace(VNO))
                {
                    sql += @" AND TRUNC(VDate) BETWEEN TO_DATE('" + From + @"', 'dd MON yyyy') 
                                          AND TO_DATE('" + To + @"', 'dd MON yyyy')";
                }

                // ✅ Narration filter
                if (Narration != "ALL")
                {
                    sql += " AND v.fktransactionid = '" + Narration + "'";
                }

                // ✅ VNO filter
                if (!string.IsNullOrWhiteSpace(VNO))
                {
                    sql += " AND v.VNO = " + VNO;
                }

                // ✅ Status filter
                if (filter != "ALL")
                {
                    if (filter == "Pending")
                        sql += " AND v.status = 2";
                    else
                        sql += " AND v.status = 0";
                }

                sql += " GROUP BY v.VDate, v.VNO, narrationtitle";

                OracleDataAdapter adapter = new OracleDataAdapter(sql, clsConnection.con);
                adapter.Fill(dt);
                adapter.Dispose();
                return dt;
            }
            catch (Exception ee)
            {
                Errors.writeline(ee.Message, "Query_ ReceiptFilter");
                MyMessageBox.ShowBox(ee.Message, Variable.Version, 1);
                return dt;
            }
        }
        public static DataTable TellerReceiptFilterWithPendingApr(string From, string To, string Narration, string VNO, string filter)
        {
            DataTable dt = new DataTable();
            try
            {
                OracleCommand comm = new OracleCommand("search_voucher_teller_closing", clsConnection.con);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add("VSessionId", OracleDbType.Varchar2).Value = Narration;
                comm.Parameters.Add("VFromDate", OracleDbType.Varchar2).Value = From;
                comm.Parameters.Add("VToDate", OracleDbType.Varchar2).Value = To;
                comm.Parameters.Add("VNO", OracleDbType.Varchar2).Value = VNO;
                comm.Parameters.Add("VFilter", OracleDbType.Varchar2).Value = filter;

                comm.Parameters.Add("retval", OracleDbType.RefCursor);
                comm.Parameters["retval"].Direction = ParameterDirection.Output;

                OracleDataAdapter adapter = new OracleDataAdapter();
                adapter.SelectCommand = comm;
                adapter.Fill(dt);
                adapter.Dispose();
                return dt;
            }
            catch (Exception ee)
            {
                Errors.writeline(ee.Message, "Query_Rep_Voucher");
                string result = MyMessageBox.ShowBox(ee.Message, Variable.Version, 1);


                return dt;
            }
        }
        /*//public static DataTable ReceiptFilterWithPendingApr(string From, string To, string Narration, string VNO, string filter)
        //{
        //    DataTable dt = new DataTable();
        //    try
        //    {
        //        OracleDataAdapter adapter = new OracleDataAdapter();
        //        string sql = @"select v.VDate,v.VNO,narrationtitle as Narration,
        //       sum(dr) as Amount from Voucherdetail v JOIN narration n ON n.narrationcode = v.fktransactionid
        //     where (trunc(VDate) between TO_DATE('" + From + "', 'dd MON yyyy')  and TO_DATE('" + To + "', 'dd MON yyyy')) " + Narration + "  " + VNO +
        //                                      "  and v.Vtype = 'RV' and v.status != 1 AND v.status = CASE WHEN '" + filter + "'='ALL' THEN v.status ELSE CASE WHEN '" + filter + "' = 'Pending' THEN 2 ELSE 0 END END GROUP BY vdate,vno ,narrationtitle";
        //        adapter.SelectCommand = new OracleCommand(sql, clsConnection.con);
        //        adapter.Fill(dt);
        //        adapter.Dispose();
        //        return dt;
        //    }
        //    catch (Exception ee)
        //    {
        //        Errors.writeline(ee.Message, "Query_ ReceiptFilter");
        //        string result = MyMessageBox.ShowBox(ee.Message, Variable.Version, 1);
        //        return dt;
        //    }
        //}*/
        public static DataTable ChartofAccounts()
        {

            DataTable dt = new DataTable();
            try
            {
                OracleDataAdapter adapter = new OracleDataAdapter();
                adapter.SelectCommand = new OracleCommand("select * from ChartofAccounts order by to_number(AccountId)", clsConnection.con);
                adapter.Fill(dt);
                adapter.Dispose();
                return dt;
            }
            catch (Exception ee)
            {
                Errors.writeline(ee.Message, "Query_ChartofAccounts");
                string result = MyMessageBox.ShowBox(ee.Message, Variable.Version, 1);
                string err = MyMessageBox.ShowBox("Do you want to Exit ?", Variable.Version, 2);
                //    if (err == "1") Application.Exit();
                return dt;
            }
        }
        public static DataTable AccountCodes(string accounts)
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = "select AccountId,AccountTitle,Currency from ChartofAccounts Where ";

                if (accounts.Length > 0)
                {
                    string[] words = accounts.Split(';');
                    int linecount = 0;
                    foreach (string word in words)
                    {
                        if (word.Length > 0)
                        {
                            if (linecount > 0) sql += " OR ";
                            sql += " Status=0 and control='Detail' and accountid like '" + word + "%'";
                        }
                        linecount++; ;
                    }
                }
                else
                {
                    sql += " Status=0 and control='Detail'";
                }
                OracleDataAdapter adapter = new OracleDataAdapter();
                adapter.SelectCommand = new OracleCommand(sql + " order by AccountTitle", clsConnection.con);
                adapter.Fill(dt);
                adapter.Dispose();
                return dt;
            }
            catch (Exception ee)
            {
                Errors.writeline(ee.Message, "Query_AccountCodes");
                string result = MyMessageBox.ShowBox(ee.Message, Variable.Version, 1);
                string err = MyMessageBox.ShowBox("Do you want to Exit ?", Variable.Version, 2);
                //      if (err == "1") Application.Exit();
                return dt;
            }

        }
        public static DataSet Rep_AccountStatement(string AcCode, string dtFrom, string dtTo, string ClientCode,string bankcode)
        {
            DataSet ds = new DataSet();
            try
            {
                //Tauqeer comments change vdate
                //string addsql = "";
                //if (AcCode == "001001005002001")
                //     addsql = "and fkbankid='"+bankcode+"' ";

                //string appendsqlcond = "";// AcCode == "001001002001001" ? " AND  fkclientcode  = '" + ClientCode + "' " : (AcCode == "001001005002001" ? " AND fkbankid = '" + ClientCode + "'" : "");
                //string sql = "";
                //sql = "SELECT ";
                //sql += "null FKVNo,NULL AS refno,Max(regexp_substr(createdby,'[^|]+',1,2)) AS VDate,null AS FKTransactionID,null AS FCDR,(case when (Sum(dr) - Sum(cr)) > 0 then (Sum(dr) - Sum(cr)) else 0 end) AS DR,null AS FCCR,(case when (Sum(dr) - Sum(cr)) < 0 then -(Sum(dr) - Sum(cr)) else 0 end) AS CR,'B/F' AS Description ";
                //sql += "FROM voucherdetail WHERE status = 0 and  fkaccountid = '" + AcCode + "' AND Trunc(vdate) < '" + dtFrom + "' " +addsql+ appendsqlcond;
                //sql += "GROUP BY fkaccountid";
                //sql += " UNION ALL ";
                //sql += "SELECT  ";
                //sql += "vtype || '-' || vno AS FKVNo,nvl(refrmk || case when refno is not null then '-' else null end  ||  refno,chequeno ||'/'||slipno),regexp_substr(createdby,'[^|]+',1,2) AS VDate,fktransactionid AS FKTransactionID,fcdr AS FCDR,dr AS DR,fccr AS FCCR,cr AS CR,description AS Description ";
                //sql += "FROM voucherdetail WHERE status = 0 and fkaccountid = '" + AcCode + "' AND Trunc(vdate) BETWEEN '" + dtFrom + "'  AND '" + dtTo + "' " +addsql+ appendsqlcond + " ORDER BY vdate,FKVNo,cr";


                string addsql = "";
                if (AcCode == "001001005002001")
                    addsql = "and fkbankid='" + bankcode + "' ";

                string appendsqlcond = ""; // AcCode == "001001002001001" ? " AND  fkclientcode  = '" + ClientCode + "' " : (AcCode == "001001005002001" ? " AND fkbankid = '" + ClientCode + "'" : "");    ORDER BY vdate,FKVNo,cr
                string sql = "";
                sql = "Select * from ( ";
                sql += "SELECT ";
                sql += "NULL vseq,null FKVNo,NULL AS refno,Max(vdate) AS VDate,null AS FKTransactionID,null AS FCDR,(case when (Sum(dr) - Sum(cr)) > 0 then (Sum(dr) - Sum(cr)) else 0 end) AS DR,null AS FCCR,(case when (Sum(dr) - Sum(cr)) < 0 then -(Sum(dr) - Sum(cr)) else 0 end) AS CR,'B/F' AS Description ";
                sql += "FROM voucherdetail WHERE status = 0 and  fkaccountid = '" + AcCode + "' AND Trunc(vdate) < '" + dtFrom + "' " + addsql + appendsqlcond;
                sql += "GROUP BY fkaccountid";
                sql += " UNION ALL ";
                sql += "SELECT  ";
                sql += "vseq,vtype || '-' || vno AS FKVNo,nvl(refrmk || case when refno is not null then '-' else null end  ||  refno,chequeno ||'/'||slipno),vdate AS VDate,fktransactionid AS FKTransactionID,fcdr AS FCDR,dr AS DR,fccr AS FCCR,cr AS CR,description AS Description ";
                sql += "FROM voucherdetail WHERE status = 0 and fkaccountid = '" + AcCode + "' AND Trunc(vdate) BETWEEN '" + dtFrom + "'  AND '" + dtTo + "' " + addsql + appendsqlcond + " ) ORDER BY CASE WHEN FKVNo IS NULL THEN 0 ELSE 1 END,vdate,FKVNo,vseq,cr";
                OracleDataAdapter adapter = new OracleDataAdapter();
                adapter.SelectCommand = new OracleCommand(sql, clsConnection.con);
                adapter.Fill(ds, "AccountStatement");
                adapter.Dispose();
                return ds;
            }
            catch (Exception ee)
            {
                Errors.writeline(ee.Message, "Query_Rep_AccountStatement");
                string result = MyMessageBox.ShowBox(ee.Message, Variable.Version, 1);
                string err = MyMessageBox.ShowBox("Do you want to Exit ?", Variable.Version, 2);
                //if (err == "1") Application.Exit();
                return ds;
            }
        }
        public static DataTable PaymentFilter1withdate(string From, string To, string Narration, string VNO, string vtype, string Post)
        {
            DataTable dt = new DataTable();
            try
            {
                OracleDataAdapter adapter = new OracleDataAdapter();
                //string sql = "select VDate,VNO,(select narrationtitle from narration where narrationcode = fktransactionid) as Narration,cr as Amount from Voucherdetail where ( VDate between '" + From + "' and '" + To + "') and FK_Narration = " + Narration + " and VNO = " + VNO + "  and Vtype = 'PV' and status = 0 AND Vseq = 1";

                string sql1 = @"select vdate,vd.vtype,vd.vno,(select Max(narrationtitle) from narration where narrationcode = fktransactionid) as Narration,listagg(chdr.draccount,',') within GROUP (ORDER BY chdr.draccount) AS draccount,
                              Sum(dr) AS dr,listagg(chcr.craccount,',') within GROUP (ORDER BY chcr.craccount) AS craccount,
                              Sum(cr) AS cr , Max(description) as description, max(get_banktitle(fkbankid)) AS BankTitle FROM voucherdetail vd 
                              left JOIN(SELECT accountid, accounttitle AS draccount FROM chartofaccounts WHERE control = 'Detail' AND aclevel = 5 
                              AND status = 0) chdr ON chdr.accountid = vd.fkaccountid AND dr > 0 
                              left JOIN(SELECT accountid, accounttitle AS 
                              craccount FROM chartofaccounts WHERE control = 'Detail' AND aclevel = 5 AND status = 0) chcr ON chcr.accountid = 
                              vd.fkaccountid AND cr > 0 
                              WHERE ( trunc(VDate)   between TO_DATE('" + From + "', 'dd MON yyyy')  and TO_DATE('" + To + "', 'dd MON yyyy') ) " +
                "and  vtype IN ('PV','JV','RV','BT') and vtype=case when '" + vtype + "'='ALL' then vtype else '" + vtype + "' end and status =case when '" + Post + "'='Post' then 0 else 2 end   " + VNO + "  " + Narration + " GROUP BY VDate,VNO,vtype,fktransactionid order by vdate DESC";

                string sql = @"select vtype,VDate,VNO,(select narrationtitle from narration where narrationcode = fktransactionid) as Narration,
                Sum(cr) as Amount from Voucherdetail 
                where ( trunc(VDate)   between TO_DATE('" + From + "', 'dd MON yyyy')  and TO_DATE('" + To + "', 'dd MON yyyy') ) " +
                "and  vtype IN ('PV','JV','RV','BT') and vtype=case when '" + vtype + "'='ALL' then vtype else '" + vtype + "' end and status =case when '" + Post + "'='Post' then 0 else 2 end   " + VNO + "  " + Narration + "GROUP BY vtype,VDate,VNO,fktransactionid order by vdate desc";
                //@"select VDate,VNO,(select narrationtitle from narration where narrationcode = fktransactionid) as Narration,
                //cr as Amount from Voucherdetail 
                //where ( trunc(VDate)   between TO_DATE('" + From + "', 'dd MON yyyy')  and TO_DATE('" + To + "', 'dd MON yyyy') ) " +
                //Narration + "  " + VNO + "  and Vtype = 'PV' and status != 1 AND Vseq = 1";
                adapter.SelectCommand = new OracleCommand(sql1, clsConnection.con);
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
        public static DataTable PaymentFilterAll(string Narration, string VNO, string Post)
        {
            DataTable dt = new DataTable();
            try
            {
                OracleDataAdapter adapter = new OracleDataAdapter();
                string sql1 = @"select vdate,vd.vtype,vd.vno,(select Max(narrationtitle) from narration where narrationcode = fktransactionid) as Narration,listagg(chdr.draccount,',') within GROUP (ORDER BY chdr.draccount) AS draccount,
                              Sum(dr) AS dr,listagg(chcr.craccount,',') within GROUP (ORDER BY chcr.craccount) AS craccount,
                              Sum(cr) AS cr , Max(description) as description, max(get_banktitle(fkbankid)) AS BankTitle FROM voucherdetail vd 
                              left JOIN(SELECT accountid, accounttitle AS draccount FROM chartofaccounts WHERE control = 'Detail' AND aclevel = 5 
                              AND status = 0) chdr ON chdr.accountid = vd.fkaccountid AND dr > 0 
                              left JOIN(SELECT accountid, accounttitle AS 
                              craccount FROM chartofaccounts WHERE control = 'Detail' AND aclevel = 5 AND status = 0) chcr ON chcr.accountid = 
                              vd.fkaccountid AND cr > 0 
                              WHERE  Vtype in ('PV','JV','RV','BT') and status != 1 and status = case when '" + Post + @"'='Post' then 0 else 2 end 
                              GROUP BY VDate,VNO,vtype,fktransactionid order by vdate DESC";

                string sql = @"SELECT vd.vno,wm_concat(chdr.draccount) AS draccount,Sum(dr) AS dr,wm_concat(chcr.craccount) AS craccount,
                              Sum(cr) AS cr , Max(description), max(get_banktitle(fkbankid)) FROM voucherdetail vd 
                              left JOIN(SELECT accountid, accounttitle AS draccount FROM chartofaccounts WHERE control = 'Detail' AND aclevel = 5 
                              AND status = 0) chdr ON chdr.accountid = vd.fkaccountid AND dr > 0 left JOIN(SELECT accountid, accounttitle AS 
                              craccount FROM chartofaccounts WHERE control = 'Detail' AND aclevel = 5 AND status = 0) chcr ON chcr.accountid = 
                              vd.fkaccountid AND cr < 0 WHERE  Vtype in ('PV','JV','RV') and status != 1 and status = case when '" + Post + "'='Post' then 0 else 2 end  GROUP BY VDate,VNO,vtype,fktransactionid order by vdate desc";

                //string sql = "select VDate,VNO,(select narrationtitle from narration where narrationcode = fktransactionid) as Narration,cr as Amount from Voucherdetail where ( VDate between '" + From + "' and '" + To + "') and FK_Narration = " + Narration + " and VNO = " + VNO + "  and Vtype = 'PV' and status = 0 AND Vseq = 1";
                //string sql = @"select VDate,VNO,vtype,description,(select narrationtitle from narration where narrationcode = fktransactionid) as Narration,
                //Sum(cr) as Amount from Voucherdetail 
                //where Vtype in ('PV','JV','RV') and status != 1 and status = case when '" + Post + "'='Post' then 0 else 2 end  GROUP BY VDate,VNO,vtype,fktransactionid,description order by vdate desc";
                ////@"select VDate,VNO,(select narrationtitle from narration where narrationcode = fktransactionid) as Narration,
                //cr as Amount from Voucherdetail 
                //where ( trunc(VDate)   between TO_DATE('" + From + "', 'dd MON yyyy')  and TO_DATE('" + To + "', 'dd MON yyyy') ) " +
                //Narration + "  " + VNO + "  and Vtype = 'PV' and status != 1 AND Vseq = 1";
                adapter.SelectCommand = new OracleCommand(sql1, clsConnection.con);
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
        public static DataTable bankdetail()
        {
            DataTable dt = new DataTable();
            try
            {
                OracleDataAdapter adapter = new OracleDataAdapter();
                string sql = "SELECT bankcode,bban,bankname,branchname,currency FROM bankdetail";
                adapter.SelectCommand = new OracleCommand(sql, clsConnection.con);
                adapter.Fill(dt);
                adapter.Dispose();
                return dt;
            }
            catch (Exception ee)
            {
                Errors.writeline(ee.Message, "Query_ bankdetail");
                string result = MyMessageBox.ShowBox(ee.Message, Variable.Version, 1);


                return dt;
            }
        }
        public static DataTable CountryIndex()
        {
            DataTable dt = new DataTable();
            try
            {
                OracleDataAdapter adapter = new OracleDataAdapter();
                string sql = "SELECT countrycode,countryname FROM countrydetail";
                adapter.SelectCommand = new OracleCommand(sql, clsConnection.con);
                adapter.Fill(dt);
                adapter.Dispose();
                return dt;
            }
            catch (Exception ee)
            {
                Errors.writeline(ee.Message, "Query_CountryIndex");
                string result = MyMessageBox.ShowBox(ee.Message, Variable.Version, 1);


                return dt;
            }
        }
        public static DataTable isocountryIndex()
        {
            DataTable dt = new DataTable();
            try
            {
                OracleDataAdapter adapter = new OracleDataAdapter();
                string sql = "SELECT countrycode,isocountrycode FROM    countrydetail";
                adapter.SelectCommand = new OracleCommand(sql, clsConnection.con);
                adapter.Fill(dt);
                adapter.Dispose();
                return dt;
            }
            catch (Exception ee)
            {
                Errors.writeline(ee.Message, "Query_CountryIndex");
                string result = MyMessageBox.ShowBox(ee.Message, Variable.Version, 1);


                return dt;
            }
        }
        public static DataTable CityIndex()
        {
            DataTable dt = new DataTable();
            try
            {
                OracleDataAdapter adapter = new OracleDataAdapter();
                string sql = "SELECT citycode,fkcountrycode,cityname FROM citydetail order by citycode";
                adapter.SelectCommand = new OracleCommand(sql, clsConnection.con);
                adapter.Fill(dt);
                adapter.Dispose();
                return dt;
            }
            catch (Exception ee)
            {
                Errors.writeline(ee.Message, "Query_CityIndex");
                string result = MyMessageBox.ShowBox(ee.Message, Variable.Version, 1);


                return dt;
            }
        }
        public static DataTable BankDetail(string bankcode)
        {
            DataTable dt = new DataTable();
            try
            {
                OracleDataAdapter adapter = new OracleDataAdapter();
                adapter.SelectCommand = new OracleCommand("select * from BankDetail  WHERE bankcode = '" + bankcode + "' and status = 0", clsConnection.con);
                adapter.Fill(dt);
                adapter.Dispose();
                return dt;
            }
            catch (Exception ee)
            {
                Errors.writeline(ee.Message, "Query_BankDetail");
                string result = MyMessageBox.ShowBox(ee.Message, Variable.Version, 1);


                return dt;
            }
        }
        public static DataTable BankFacilities(string bankcode)
        {
            DataTable dt = new DataTable();
            try
            {
                OracleDataAdapter adapter = new OracleDataAdapter();
                adapter.SelectCommand = new OracleCommand("select * from bankfacilities  WHERE fkbankcode = '" + bankcode + "' ", clsConnection.con);
                adapter.Fill(dt);
                adapter.Dispose();
                return dt;
            }
            catch (Exception ee)
            {
                Errors.writeline(ee.Message, "Query_ BankFacilities");
                string result = MyMessageBox.ShowBox(ee.Message, Variable.Version, 1);


                return dt;
            }
        }
        public static DataTable BankMargin(string bankcode)
        {
            DataTable dt = new DataTable();
            try
            {
                OracleDataAdapter adapter = new OracleDataAdapter();
                adapter.SelectCommand = new OracleCommand("select * from bankmargindetail  WHERE fkbankcode = '" + bankcode + "' ", clsConnection.con);
                adapter.Fill(dt);
                adapter.Dispose();
                return dt;
            }
            catch (Exception ee)
            {
                Errors.writeline(ee.Message, "Query_ BankMargin");
                string result = MyMessageBox.ShowBox(ee.Message, Variable.Version, 1);


                return dt;
            }
        }
        internal static DataTable surgeryAll()
        {
            string sql = "SELECT pi.*,'' AS consulshare,'' AS hospshare,0 AS SCheck FROM packageindex pi";
            DataTable dt = getData(sql);
            return dt;
        }
        internal static DataTable get_doctor_timings(string docId)
        {
            DataTable dt = new DataTable();
            try
            {
                OracleCommand comm = new OracleCommand("get_doctor_timings", clsConnection.con);
                comm.CommandType = CommandType.StoredProcedure;

                comm.Parameters.Add("VDocId", OracleDbType.Varchar2).Value = docId;
                
                comm.Parameters.Add("retval", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                comm.Parameters["retval"].Direction = ParameterDirection.Output;


                OracleDataAdapter adapter = new OracleDataAdapter();
                adapter.SelectCommand = comm;// new OracleCommand(sql, Connection.Conn_ecyear);
                adapter.Fill(dt);
                adapter.Dispose();
                return dt;
            }
            catch (Exception ee)
            {
                Errors.writeline(ee.Message, "get_doctor_timings");
                MessageBox.Show(ee.ToString());
                return dt;
            }
        }
        internal static DataTable ConsultantFacultyAll()
        {
            string sql = "SELECT distinct faculty FROM consultant";
            DataTable dt = getData(sql);
            return dt;
        }
        internal static DataTable Rep_TrialBalanceERP(string From, string To)
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = @" SELECT ch.lvl1Title lvl1,ch.lvl2Title lvl2,ch.lvl3Title lvl3,ch.lvl4Title lvl4,fkbankid,title ||' '|| get_banktitle(fkbankid) ||' '||  get_clienttitle(fkclientcode)  title,
                            Sum(opn) opn, Sum(dr) dr, Sum(cr) cr, Sum(curr) curr,fkaccountid accountid FROM
                           (SELECT CASE 
                            WHEN fkaccountid IN ('001001002001001','002001001001001') THEN ( CASE WHEN  curr > 0 THEN '001001002001001' ELSE '002001001001001' END )   --client
                            WHEN fkaccountid IN ('001001005002001','002001004001001') THEN ( CASE WHEN  curr > 0 THEN '001001005002001' ELSE '002001004001001' END )       --bank
                            WHEN fkaccountid IN ('001001002001002','002001001001005') THEN ( CASE WHEN  curr > 0 THEN '001001002001002' ELSE '002001001001005' END )    --  director
                            WHEN fkaccountid IN ('001001003002001','002001001001003') THEN ( CASE WHEN  curr > 0 THEN '001001003002001' ELSE '002001001001003' END )    -- hr
                           ELSE fkaccountid END fkaccountid ,fkclientcode,
                           fkbankid, fkdirectorid, fkhrid, opn, dr, cr, curr FROM 
                           (SELECT fkaccountid,fkclientcode,fkbankid,fkdirectorid,fkhrid,
                           Sum(opn) opn,Sum(dr) dr,Sum(cr) cr,Sum(curr) curr,fkaccountid accountid FROM
                           (SELECT  fkaccountid ,
                           CASE WHEN fkaccountid IN ('001001002001001','002001001001001') THEN fkclientcode ELSE NULL END fkclientcode,
                           CASE WHEN fkaccountid IN ('001001005002001','002001004001001')  THEN  fkbankid ELSE NULL END fkbankid,
                           CASE WHEN fkaccountid IN ('001001002001002','002001001001005')  THEN fkdirectorid ELSE NULL END fkdirectorid,
                           CASE WHEN fkaccountid IN ('001001003002001','002001001001003')  THEN  fkhrid ELSE NULL END fkhrid,Sum(opn) opn,Sum(dr) dr,Sum(cr) cr,Sum(curr) curr FROM ( ";
                sql += " SELECT  fkaccountid,fkclientcode,fkbankid,fkdirectorid,fkhrid,sum(dr - cr) as opn,0 dr,0 cr,0 as curr FROM voucherdetail WHERE  vdate  < '" + From + "' AND status = 0 GROUP BY fkaccountid,fkclientcode,fkbankid,fkdirectorid,fkhrid  ";
                sql += " UNION ALL ";
                sql += " SELECT fkaccountid,fkclientcode,fkbankid,fkdirectorid,fkhrid,0,Sum(dr) dr ,Sum(cr) cr,0 FROM voucherdetail WHERE  vdate between '" + From + "' and '" + To + "' AND status = 0  GROUP BY fkaccountid,fkclientcode,fkbankid,fkdirectorid,fkhrid  ";
                sql += " UNION ALL ";
                sql += " SELECT fkaccountid,fkclientcode,fkbankid,fkdirectorid,fkhrid,0 as opn,0 dr,0 cr,sum(dr - cr) as curr FROM voucherdetail WHERE  vdate  <= '" + To + "' AND status = 0  GROUP BY fkaccountid,fkclientcode,fkbankid,fkdirectorid,fkhrid ";
                sql += " ) tr ";
                sql += " GROUP BY fkaccountid,fkclientcode,fkbankid,fkdirectorid,fkhrid  HAVING  Sum(curr) <> 0)Tr ";
                sql += " GROUP BY fkaccountid,fkclientcode,fkbankid,fkdirectorid,fkhrid   ";
                sql += " ORDER BY fkaccountid))  tr  ";
                sql += " left JOIN vu_chartOfAcc ch ON tr.fkaccountid = ch.account  ";
                sql += " GROUP BY fkaccountid,fkclientcode,fkbankid,fkdirectorid,fkhrid ,ch.lvl1Title ,ch.lvl2Title ,ch.lvl3Title ,ch.lvl4Title ,title  ";
                sql += " ORDER BY fkaccountid ,ch.lvl1Title ,ch.lvl2Title ,ch.lvl3Title ,ch.lvl4Title ,title ";
                OracleDataAdapter adapter = new OracleDataAdapter();
                adapter.SelectCommand = new OracleCommand(sql, clsConnection.con);
                adapter.Fill(dt);
                adapter.Dispose();
                return dt;
            }
            catch (Exception ee)
            {
                Errors.writeline(ee.Message, "Query_ Rep_TrialBalance");
                string result = MyMessageBox.ShowBox(ee.Message, Variable.Version, 1);
                string err = MyMessageBox.ShowBox("Do you want to Exit ?", Variable.Version, 2);
                //if (err == "1")
                //    Application.Exit();
                return dt;
            }
        }
        internal static DataTable Rep_TrialBalance(string dtFromDate, string dtToDate, string AcCode)
        {
           
            DataTable dt = new DataTable();
            try
            {
                string sql = @" SELECT ch.lvl1Title lvl1,ch.lvl2Title lvl2,ch.lvl3Title lvl3,ch.lvl4Title lvl4,fkbankid,title ||' '|| get_banktitle(fkbankid) ||' '||  get_clienttitle(fkclientcode)  title,
                            Sum(opn) opn, Sum(dr) dr, Sum(cr) cr, Sum(curr) curr,fkaccountid accountid FROM
                           (SELECT CASE 
                            WHEN fkaccountid IN ('001001002001001','002001001001001') THEN ( CASE WHEN  curr > 0 THEN '001001002001001' ELSE '002001001001001' END )   --client
                            WHEN fkaccountid IN ('001001005002001','002001004001001') THEN ( CASE WHEN  curr > 0 THEN '001001005002001' ELSE '002001004001001' END )       --bank
                            WHEN fkaccountid IN ('001001002001002','002001001001005') THEN ( CASE WHEN  curr > 0 THEN '001001002001002' ELSE '002001001001005' END )    --  director
                            WHEN fkaccountid IN ('001001003002001','002001001001003') THEN ( CASE WHEN  curr > 0 THEN '001001003002001' ELSE '002001001001003' END )    -- hr
                           ELSE fkaccountid END fkaccountid ,fkclientcode,
                           fkbankid, fkdirectorid, fkhrid, opn, dr, cr, curr FROM 
                           (SELECT fkaccountid,fkclientcode,fkbankid,fkdirectorid,fkhrid,
                           Sum(opn) opn,Sum(dr) dr,Sum(cr) cr,Sum(curr) curr,fkaccountid accountid FROM
                           (SELECT  fkaccountid ,
                           CASE WHEN fkaccountid IN ('001001002001001','002001001001001') THEN fkclientcode ELSE NULL END fkclientcode,
                           CASE WHEN fkaccountid IN ('001001005002001','002001004001001')  THEN  fkbankid ELSE NULL END fkbankid,
                           CASE WHEN fkaccountid IN ('001001002001002','002001001001005')  THEN fkdirectorid ELSE NULL END fkdirectorid,
                           CASE WHEN fkaccountid IN ('001001003002001','002001001001003')  THEN  fkhrid ELSE NULL END fkhrid,Sum(opn) opn,Sum(dr) dr,Sum(cr) cr,Sum(curr) curr FROM ( ";
                sql += " SELECT  fkaccountid,fkclientcode,fkbankid,fkdirectorid,fkhrid,sum(dr - cr) as opn,0 dr,0 cr,0 as curr FROM voucherdetail WHERE  vdate  < '" + dtFromDate + "' AND status = 0 GROUP BY fkaccountid,fkclientcode,fkbankid,fkdirectorid,fkhrid  ";
                sql += " UNION ALL ";
                sql += " SELECT fkaccountid,fkclientcode,fkbankid,fkdirectorid,fkhrid,0,Sum(dr) dr ,Sum(cr) cr,0 FROM voucherdetail WHERE  vdate between '" + dtFromDate + "' and '" + dtToDate + "' AND status = 0  GROUP BY fkaccountid,fkclientcode,fkbankid,fkdirectorid,fkhrid  ";
                sql += " UNION ALL ";
                sql += " SELECT fkaccountid,fkclientcode,fkbankid,fkdirectorid,fkhrid,0 as opn,0 dr,0 cr,sum(dr - cr) as curr FROM voucherdetail WHERE  vdate  <= '" + dtToDate + "' AND status = 0  GROUP BY fkaccountid,fkclientcode,fkbankid,fkdirectorid,fkhrid ";
                sql += " ) tr ";
                sql += " GROUP BY fkaccountid,fkclientcode,fkbankid,fkdirectorid,fkhrid  HAVING  Sum(curr) <> 0)Tr ";
                sql += " GROUP BY fkaccountid,fkclientcode,fkbankid,fkdirectorid,fkhrid   ";
                sql += " ORDER BY fkaccountid))  tr  ";
                sql += " left JOIN vu_chartOfAcc ch ON tr.fkaccountid = ch.account  ";
                sql += " GROUP BY fkaccountid,fkclientcode,fkbankid,fkdirectorid,fkhrid ,ch.lvl1Title ,ch.lvl2Title ,ch.lvl3Title ,ch.lvl4Title ,title  ";
                sql += " ORDER BY fkaccountid ,ch.lvl1Title ,ch.lvl2Title ,ch.lvl3Title ,ch.lvl4Title ,title ";
                OracleDataAdapter adapter = new OracleDataAdapter();
                adapter.SelectCommand = new OracleCommand(sql, clsConnection.con);
                adapter.Fill(dt);
                adapter.Dispose();
                return dt;

                //OracleCommand comm = new OracleCommand("HMS.rep_trialbalance", clsConnection.con);
                //comm.CommandType = CommandType.StoredProcedure;
                //comm.Parameters.Add("VFromDate", OracleDbType.Varchar2).Value = dtFromDate;
                //comm.Parameters.Add("VToDate", OracleDbType.Varchar2).Value = dtToDate;
                //comm.Parameters.Add("VAcCode", OracleDbType.Varchar2).Value = AcCode;
                //comm.Parameters.Add("retval", OracleDbType.RefCursor);
                //comm.Parameters["retval"].Direction = ParameterDirection.Output;

                //OracleDataAdapter adapter = new OracleDataAdapter();
                //adapter.SelectCommand = comm;
                //adapter.Fill(dt);
                //return dt;
            }
            catch (Exception ee)
            {
                Errors.writeline(ee.Message, "Query_Rep_TrialBalance");
                MessageBox.Show(ee.Message);
                return dt;
            }

            //DataTable dt = new DataTable(); 
            //OracleCommand comm = new OracleCommand("trialbalance", clsConnection.con);               
            //comm.CommandType = CommandType.StoredProcedure;
            //comm.Parameters.Add("VFromDate", OracleDbType.Varchar2).Value = dtFromDate;
            //comm.Parameters.Add("dtToDate", OracleDbType.Varchar2).Value = dtToDate;
            //comm.Parameters.Add("VAcCode", OracleDbType.Varchar2).Value = AcCode;
            //comm.Parameters.Add("retval", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            //comm.Parameters["retval"].Direction = ParameterDirection.Output;


            //OracleDataAdapter adapter = new OracleDataAdapter();
            //adapter.SelectCommand = comm;// new OracleCommand(sql, Connection.Conn_ecyear);
            //adapter.Fill(dt);
            //adapter.Dispose();
            //return dt;
        }
        public static DataSet Rep_Voucher(string ason, string type, string vno)
        {
            DataSet ds = new DataSet();
            try
            {
                //string sql = "SELECT vd.vtype AS VType,vd.Vno AS Vno,vd.vdate AS Vdate,vd.description AS Description,chequeno slip_chequeNo,vd.dr AS Dr,vd.cr AS Cr,createdby AS CreatedBy,approvedby AS ApprovedBy,Nvl(get_tradeacctitle(fkclientcode,'',''),Nvl(get_Directortitle(fkdirectorid),Nvl(get_hrtitle(fkhrid),Nvl(get_banktitle(fkbankid),(SELECT accounttitle FROM chartofaccounts WHERE accountid = vd.fkaccountid))))) AS TitleOfAccount,(CASE WHEN  To_Date(vdate,'dd Mon yyyy') = To_Date(SYSDATE,'dd Mon yyyy') THEN 1 ELSE 0 END) AS editable,(SELECT branchlocation FROM branchesdetail WHERE branchcode = vd.fkbrcode) AS Branch ";
                //sql += "FROM voucherdetail vd WHERE vno = '" + vno + "' AND vtype = '" + type + "'  ORDER BY vseq asc";
                //OracleDataAdapter adapter = new OracleDataAdapter();
                //adapter.SelectCommand = new OracleCommand(sql, Connection.Conn_ecyear);
                //adapter.Fill(ds, "Voucher");
                //adapter.Dispose();
                //return ds;

                //PKG_REP_ACCOUNTS.rep_VoucherDetail // 31-03-2021
                OracleCommand comm = new OracleCommand("rep_voucherdetail1", clsConnection.con);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add("VAsOn", OracleDbType.Varchar2).Value = ason;
                comm.Parameters.Add("VVtype", OracleDbType.Varchar2).Value = type;
                comm.Parameters.Add("VVno", OracleDbType.Varchar2).Value = vno;
                comm.Parameters.Add("VStatus", OracleDbType.Varchar2).Value = "0";

                comm.Parameters.Add("retval", OracleDbType.RefCursor);
                comm.Parameters["retval"].Direction = ParameterDirection.Output;

                OracleDataAdapter adapter = new OracleDataAdapter();
                adapter.SelectCommand = comm;
                adapter.Fill(ds, "Voucher");
                adapter.Dispose();
                return ds;
            }
            catch (Exception ee)
            {
                Errors.writeline(ee.Message, "Query_Rep_Voucher");
                string result = MyMessageBox.ShowBox(ee.Message, Variable.Version, 1);


                return ds;
            }
        }
        public static string Rep_ClientExposureReturn(string AsOnDate, string nccplcode, ref string clientExposure)
        {

            try
            {
                OracleCommand comm = new OracleCommand("Rep_ClientExposureReturn", clsConnection.con);
                comm.CommandType = CommandType.StoredProcedure;

                comm.Parameters.Add("VAsOn", OracleDbType.Varchar2).Value = AsOnDate;
                comm.Parameters.Add("VnccplCode", OracleDbType.Varchar2).Value = nccplcode;
                comm.Parameters.Add("VCurrentExposure", OracleDbType.Varchar2, 50);
                comm.Parameters["VCurrentExposure"].Direction = ParameterDirection.Output;
                comm.ExecuteNonQuery();
                string cExposure = "0";
                clientExposure = comm.Parameters["VCurrentExposure"].Value.ToString();

                return cExposure;
            }
            catch (Exception ee)
            {
                Errors.writeline(ee.Message, "Return_Rep_ClientExposureReturn");
                MessageBox.Show(ee.ToString());
                return "0";
            }
        }
        public static DataTable FillCheckBoxList()
        {
            DataTable dt = new DataTable();
            try
            {
                OracleDataAdapter adapter = new OracleDataAdapter();
                adapter.SelectCommand = new OracleCommand("SELECT column_name,column_id FROM user_tab_columns WHERE table_name = 'IPDBILLING'  AND column_name IN('LABORATORY', 'PHARMACY', 'XRAY')", clsConnection.con);
                adapter.Fill(dt);
                adapter.Dispose();
                return dt;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
                return dt;
            }
        }
    }
}
