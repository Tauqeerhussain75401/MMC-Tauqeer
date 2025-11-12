using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ERP
{
    class Variable
    {
        //static string _UserId;

        //public static string UserId
        //{
        //    get { return _UserId; }
        //    set { _UserId = value; }
        //}
        //static string _User;
        //public static string User
        //{
        //    get
        //    {
        //        return _User;
        //    }
        //    set
        //    {
        //        _User = value;
        //    }
        //}
        static DateTime _LogInDate;

        public static DateTime LogInDate
        {
            get { return _LogInDate;}
            set { _LogInDate = value;}
        }
        static string _FKsecuritylevel;

        public static string FKsecuritylevel
        {
            get { return _FKsecuritylevel; }
            set { _FKsecuritylevel = value; }
        }
        static string FanancialYear;
    

        public static string _FanancialYear
        {
          get { return FanancialYear; }
          set { FanancialYear = value; }
        }
        static string _CompanyName;

        public static string CompanyName
        {
            get { return Variable._CompanyName; }
            set { Variable._CompanyName = value; }
        }

        static string _Owner;

        public static string Owner
        {
            get { return Variable._Owner; }
            set { Variable._Owner = value; }
        }
        //////////////////////


        public static Int64 tmp = 0;

        public static string[] HRName = new string[1000];
        public static string[] FHName = new string[1000];
        public static string[] HRDID = new string[1000];
        public static string[] HRID = new string[1000];
        public static string[] FKDesignationID = new string[1000];
        public static string[] FKDepartmentId = new string[1000];
        public static bool  iniDateNow { get; set; }


        static System.Drawing.Color _ButtonStartColor;
        public static System.Drawing.Color ButtonStartColor
        {
            get
            {
                return _ButtonStartColor;
            }
            set
            {
                _ButtonStartColor = value;
            }
        }
        static System.Drawing.Color _ButtonEndColor;
        public static System.Drawing.Color ButtonEndColor
        {
            get
            {
                return _ButtonEndColor;
            }
            set
            {
                _ButtonEndColor = value;
            }
        }
        static System.Drawing.Color _ButtonMStartColor;
        public static System.Drawing.Color ButtonMStartColor
        {
            get
            {
                return _ButtonMStartColor;
            }
            set
            {
                _ButtonMStartColor = value;
            }
        }
        static System.Drawing.Color _ButtonMEndColor;
        public static System.Drawing.Color ButtonMEndColor
        {
            get
            {
                return _ButtonMEndColor;
            }
            set
            {
                _ButtonMEndColor = value;
            }
        }
        static string _Version;
        public static string Version
        {
            get
            {
                return _Version;
            }
            set
            {
                _Version = value;
            }
        }

        static string _User;
        public static string User
        {
            get
            {
                return _User;
            }
            set
            {
                _User = value;
            }
        }
        static string _Pass;
        public static string Pass
        {
            get
            {
                return _Pass;
            }
            set
            {
                _Pass = value;
            }
        }
        static string _UserId;
        public static string UserId
        {
            get
            {
                return _UserId;
            }
            set
            {
                _UserId = value;
            }
        }
        static string _UserDateTime;
        public static string UserDateTime
        {
            get
            {
                return _UserDateTime;
            }
            set
            {
                _UserDateTime = value;
            }
        }
        static string _Privillages;
        public static string Privillages
        {
            get
            {
                return _Privillages;
            }
            set
            {
                _Privillages = value;
            }
        }

        static string _FinancialYear;
        public static string FinancialYear
        {
            get
            {
                return _FinancialYear;
            }
            set
            {
                _FinancialYear = value;
            }
        }
        static DateTime _FinancialYearFrom;
        public static DateTime FinancialYearFrom
        {
            get
            {
                return _FinancialYearFrom;
            }
            set
            {
                _FinancialYearFrom = value;
            }
        }
        static DateTime _FinancialYearTo;
        public static DateTime FinancialYearTo
        {
            get
            {
                return _FinancialYearTo;
            }
            set
            {
                _FinancialYearTo = value;
            }
        }
        static bool _CreateFile;
        public static bool CreateFile
        {
            get
            {
                return _CreateFile;
            }
            set
            {
                _CreateFile = value;
            }
        }
        //static DataTable _UMRights;
        //public static DataTable UMRights
        //{
        //    get
        //    {
        //        return _UMRights;
        //    }
        //    set
        //    {
        //        _UMRights = value;
        //    }
        //}

        //static DataTable _UserData;
        //public static DataTable UserData
        //{
        //    get
        //    {
        //        return _UserData;
        //    }
        //    set
        //    {
        //        _UserData = value;
        //    }
        //}
        static string _Software;
        public static string Software
        {
            get
            {
                return _Software;
            }
            set
            {
                _Software = value;
            }
        }


        static string _FormRights;
        public static string FormRights
        {
            get
            {
                return _FormRights;
            }
            set
            {
                _FormRights = value;
            }
        }
        static string _TerminalId;
        public static string TerminalId
        {
            get
            {
                return _TerminalId;
            }
            set
            {
                _TerminalId = value;
            }
        }
        static string _BranchLocation;
        public static string BranchLocation
        {
            get
            {
                return _BranchLocation;
            }
            set
            {
                _BranchLocation = value;
            }
        }

        static string _BranchCode;
        public static string BranchCode
        {
            get
            {
                return _BranchCode;
            }
            set
            {
                _BranchCode = value;
            }
        }
        static string _BranchType;
        public static string BranchType
        {
            get
            {
                return _BranchType;
            }
            set
            {
                _BranchType = value;
            }
        }

        static string _BranchAddress;
        public static string BranchAddress
        {
            get
            {
                return _BranchAddress;
            }
            set
            {
                _BranchAddress = value;
            }
        }

        static string _BranchTelephone;
        public static string BranchTelephone
        {
            get
            {
                return _BranchTelephone;
            }
            set
            {
                _BranchTelephone = value;
            }
        }

        static int _flags;
        public static int flags
        {
            get
            {
                return _flags;
            }
            set
            {
                _flags = value;
            }
        }
        static int _animationTime;
        public static int animationTime
        {
            get
            {
                return _animationTime;
            }
            set
            {
                _animationTime = value;
            }
        }

        //static DataTable _UserSecurityLevel;
        //public static DataTable UserSecurityLevel
        //{
        //    get
        //    {
        //        return _UserSecurityLevel;
        //    }
        //    set
        //    {
        //        _UserSecurityLevel = value;
        //    }
        //}
        //static DataTable _BranchTypeSecurityLevel;
        //public static DataTable BranchTypeSecurityLevel
        //{
        //    get
        //    {
        //        return _BranchTypeSecurityLevel;
        //    }
        //    set
        //    {
        //        _BranchTypeSecurityLevel = value;
        //    }
        //}
        static decimal _USDRate;
        public static decimal USDRate
        {
            get
            {
                return _USDRate;
            }
            set
            {
                _USDRate = value;
            }
        }
        static int _imageno;
        public static int imageno
        {
            get
            {
                return _imageno;
            }
            set
            {
                _imageno = value;
            }
        }
        static DateTime _ServerDate;
        public static DateTime ServerDate
        {
            get
            {
                return _ServerDate;
            }
            set
            {
                _ServerDate = value;
            }
        }
    }
}
