using System;
using HE.Framework.Core.Security;

namespace Ax.DEV.Utility.Library
{
    /// <summary>
    /// base userinfo 기본 클래스에서 사용자 정보를 추가 확장 할 수 있는 클래스
    /// </summary>
    public static class StaticUserInfoContext
    {
        public static string _AuthSvr;
        public static string _BusinessCode;
        public static string _MP_BusinessCode;
        public static string _CorporationCode;
        public static string _DeptID;
        public static string _DeptName;
        public static string _EmailAddress;
        public static string _EmpNo;
        public static string _Language;
        public static string _Password;
        public static string _PhoneNo;
        public static string _SystemCode;
        public static string _TelNo;
        public static string _UserIP;
        public static string _UserID;
        public static string _UserName;
        public static string _IsAdmin;
        public static string _PlantDiv;
        public static string _UserDiv;
        public static string _Vendcd;
        public static string _Custcd;

        static StaticUserInfoContext()
        {
            _AuthSvr            = "";
            _BusinessCode       = "";
            _MP_BusinessCode    = "";
            _CorporationCode    = "";
            _DeptID             = "";
            _DeptName           = "";
            _EmailAddress       = "";
            _EmpNo              = "";
            _Language           = "";
            _Password           = "";
            _PhoneNo            = "";
            _SystemCode         = "";
            _TelNo              = "";
            _UserIP             = "";
            _UserID             = "";
            _UserName           = "";
            _IsAdmin            = "";
            _PlantDiv           = "";
            _UserDiv = "";
            _Vendcd = "";
            _Custcd = "";
        }

        /// <summary>
        /// AxUserInfoContext 인스턴스를 받아 클래스 멤버를 설정합니다.
        /// </summary>
        public static HEUserInfoContext UserInfoContext
        {
            set 
            {
                if (value == null || _CorporationCode.Length > 0)
                    return;

                _AuthSvr            = value.AuthSvr;
                _BusinessCode       = value.BusinessCode;
                _CorporationCode    = value.CorporationCode;
                _DeptID             = value.DeptID;
                _DeptName           = value.DeptName;
                _EmailAddress       = value.EmailAddress;
                _EmpNo              = value.EmpNo;
                _Language           = value.Language;
                _Password           = value.Password;
                _PhoneNo            = value.PhoneNo;
                _SystemCode         = value.SystemCode;
                _TelNo              = value.TelNo;
                _UserIP             = value.UserIP;
                _UserID             = value.UserID;
                _UserName           = value.UserName;
                _IsAdmin            = value.IsAdmin;

                if (_MP_BusinessCode.Length == 0)
                    _MP_BusinessCode = value.BusinessCode;
            }
        }

        public static string Custcd
        {
            get
            {
                UserInfo_SettingCheck();
                return _Custcd;
            }
            set
            {
                if (value.Length > 0)
                    _Custcd = value;
            }
        }

        public static string Vendcd
        {
            get
            {
                UserInfo_SettingCheck();
                return _Vendcd;
            }
            set
            {
                if (value.Length > 0)
                    _Vendcd = value;
            }
        }
        public static string UserDiv
        {
            get
            {
                UserInfo_SettingCheck();
                return _UserDiv;
            }
            set
            {
                if (value.Length > 0)
                    _UserDiv = value;
            }
        }

        public static string PlantDiv
        {
            get
            {
                UserInfo_SettingCheck();

                return _PlantDiv;
            }
            set
            {
                if (value.Length > 0)
                    _PlantDiv = value;
            }
        }


        public static string AuthSvr 
        { 
            get
            {
                UserInfo_SettingCheck();

                return _AuthSvr; 
            } 
        }

        public static string BusinessCode 
        {
            get
            {
                UserInfo_SettingCheck();

                return _BusinessCode; 
            }
            set
            {
                if (value.Length > 0)
                    _MP_BusinessCode = value;
            }
        }

        public static string CorporationCode
        {
            get
            {
                UserInfo_SettingCheck();

                return _CorporationCode; 
            }
        }

        public static string DeptID
        {
            get
            {
                UserInfo_SettingCheck();

                return _DeptID; 
            }
        }

        public static string DeptName
        {
            get
            {
                UserInfo_SettingCheck();

                return _DeptName; 
            }
        }

        public static string EmailAddress
        {
            get
            {
                UserInfo_SettingCheck();

                return _EmailAddress; 
            }
        }

        public static string EmpNo
        {
            get
            {
                UserInfo_SettingCheck();

                return _EmpNo; 
            }
        }

        public static string Language
        {
            get
            {
                UserInfo_SettingCheck();

                return _Language; 
            }
        }

        public static string Password
        {
            get
            {
                UserInfo_SettingCheck();

                return _Password; 
            }
        }

        public static string PhoneNo
        {
            get
            {
                UserInfo_SettingCheck();

                return _PhoneNo; 
            }
        }

        public static string SystemCode
        {
            get
            {
                UserInfo_SettingCheck();

                return _SystemCode; 
            }
        }

        public static string TelNo
        {
            get
            {
                UserInfo_SettingCheck();

                return _TelNo; 
            }
        }

        public static string UserIP
        {
            get
            {
                UserInfo_SettingCheck();

                return _UserIP; 
            }
        }

        public static string UserID
        {
            get
            {
                UserInfo_SettingCheck();

                return _UserID; 
            }
        }

        public static string UserName
        {
            get
            {
                UserInfo_SettingCheck();

                return _UserName; 
            }
        }

        public static string IsAdmin
        {
            get
            {
                UserInfo_SettingCheck();

                return _IsAdmin; 
            }
        }

        public static AxUserInfo GetUserInfo(int mp_type)
        {
            UserInfo_SettingCheck();

            return new AxUserInfo(
                _AuthSvr,
                (mp_type < 0) ? _BusinessCode : _MP_BusinessCode,
                _CorporationCode,
                _DeptID,
                _DeptName,
                _EmailAddress,
                _EmpNo,
                _Language,
                _Password,
                _PhoneNo,
                _SystemCode,
                _TelNo,
                _UserIP,
                _UserID,
                _UserName,
                _IsAdmin,
                _PlantDiv,
                _UserDiv,
                _Vendcd,
                _Custcd);
        }

        private static void UserInfo_SettingCheck()
        {
            if (_CorporationCode.Length == 0 || _BusinessCode.Length == 0)
            {
                string message = 
                    String.Format(@"
                        AuthSvr : {0}
                        BusinessCode : {1}
                        CorporationCode : {2}
                        DeptID : {3}
                        DeptName : {4}
                        EmailAddress : {5}
                        EmpNo : {6}
                        Language : {7}
                        Password : {8}
                        PhoneNo : {9}
                        SystemCode : {10}
                        TelNo : {11}
                        UserIP : {12}
                        UserID : {13}
                        UserName : {14}
                        IsAdmin : {15}
                        PlantDiv : {16}
                        UserDiv : {17}
                        Vendcd : {18}
                        Custcd : {19}",

                            _AuthSvr,
                            _BusinessCode,
                            _CorporationCode,
                            _DeptID,
                            _DeptName,
                            _EmailAddress,
                            _EmpNo,
                            _Language,
                            _Password,
                            _PhoneNo,
                            _SystemCode,
                            _TelNo,
                            _UserIP,
                            _UserID,
                            _UserName,
                            _IsAdmin,
                            _PlantDiv,
                            _UserDiv,
                            _Vendcd,
                            _Custcd
                );
                System.Windows.Forms.MessageBox.Show(message);
                throw new Exception("현재 사용자 정보가 설정되지 않았습니다.");
            }
        }
    }

    /// <summary>
    /// 한일이화에서 사용하는 최종 사용자 정보 클래스입니다.
    /// </summary>
    public class AxUserInfo
    {
        public readonly string AuthSvr;
        public readonly string BusinessCode;
        public readonly string CorporationCode;
        public readonly string DeptID;
        public readonly string DeptName;
        public readonly string EmailAddress;
        public readonly string EmpNo;
        public readonly string Language;
        public readonly string Password;
        public readonly string PhoneNo;
        public readonly string SystemCode;
        public readonly string TelNo;
        public readonly string UserIP;
        public readonly string UserID;
        public readonly string UserName;
        public readonly string IsAdmin;
        public readonly string PlantDiv;
        public readonly string UserDiv;
        public readonly string Vendcd;
        public readonly string Custcd;

        public AxUserInfo(
            string authsvr,
            string businesscode,
            string corporationcode,
            string deptid,
            string deptname,
            string emailaddress,
            string empno,
            string language,
            string password,
            string phoneno,
            string systemcode,
            string telno,
            string userip,
            string userid,
            string username,
            string isadmin,
            string plantdiv,
            string userdiv,
            string vendcd,
            string custcd             
            )
        {
            AuthSvr            = authsvr;
            BusinessCode       = businesscode;
            CorporationCode    = corporationcode;
            DeptID             = deptid;
            DeptName           = deptname;
            EmailAddress       = emailaddress;
            EmpNo              = empno;
            Language           = language;
            Password           = password;
            PhoneNo            = phoneno;
            SystemCode         = systemcode;
            TelNo              = telno;
            UserIP             = userip;
            UserID             = userid;
            UserName           = username;
            IsAdmin            = isadmin;
            PlantDiv           = plantdiv;
            UserDiv            = userdiv;
            Vendcd             = vendcd;
            Custcd             = custcd;
        }
    }
}
