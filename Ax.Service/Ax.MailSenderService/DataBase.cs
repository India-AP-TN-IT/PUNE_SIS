using System;
using System.Configuration;
using System.Xml;
using System.Data;
using System.Collections;
using Shoveling2010.Server.DataAccessor;
using Shoveling2010.Server.DataAccessor.Internal;

namespace Ax.MailSenderService
{
    /// <summary>
    /// ALC 서비스, 클라이언트 프로그램에서 사용하는 DB Access 클래스입니다.
    /// DbAccessor 클래스는 진정보시스템에서 만들어서 제공하는 발전된 형태의 데이타엑세스 컴포넌트입니다. 
    /// </summary>
    public class JISDbAccessor : DbAccessor
    {
        private const string _PROGRAMID = "DBACCESSOR";
        private const string _PROCEDURENO = "STATIC_QUERY";
        private string _CONNECTTEXT = ConfigurationManager.AppSettings["DB"]; // "USER ID=sis; PASSWORD=sis100; DATA SOURCE=HANILDEV";
        private string _EnvConnect;

        public JISDbAccessor()
            : base()
        {            
            _EnvConnect = _CONNECTTEXT;
        }

        public JISDbAccessor(string connectdb)
            : base()
        {
            try
            {
                _EnvConnect = connectdb;
            }
            catch (Exception e)
            {
                throw e.InnerException;
            }
        }

        /// <summary>
        /// SqlUnitCollection 타입의 명령문 리스트를 가져옵니다.
        /// </summary>
        public new SqlUnitCollection CommandList
        {
            get { return base.CommandList; }
        }

        #region Attach

        /// <summary>
        /// 실행할 명령문과 파라메터를 JISDbAccessor 클래스의 명령문으로 추가합니다.
        /// </summary>
        public void Attach(string commandText, SqlParameters parameters)
        {
            Attach(CommandType.Text, commandText, parameters);
        }

        /// <summary>
        /// 실행할 명령문과 파라메터를 JISDbAccessor 클래스의 명령문으로 추가합니다.
        /// </summary>
        public void Attach(CommandType type, string commandText, SqlParameters parameters)
        {
            string connect = _EnvConnect.Length > 0 ? _EnvConnect : _CONNECTTEXT;
            SqlUnit unit = new SqlUnit(
                _PROGRAMID, _PROCEDURENO, Provider.Oracle, connect, type, commandText);

            for (int i = 0; i < parameters.Count; i++)
            {
                object[] items = (object[])parameters[i];
                string key = items[0].ToString();
                object value = items[1] is ArrayList ? ((ArrayList)items[1]).ToArray() : items[1];

                if (i == 0 && items[1] is ArrayList)
                    unit.ArrayBindCount = ((ArrayList)items[1]).Count;

                if (key.IndexOf("OUT$") > -1)
                {
                    key = key.Replace("OUT$", "");
                    unit.Parameters.Add(new SqlUnit.Parameter(key));
                }
                else
                    unit.Parameters.Add(new SqlUnit.Parameter(key, value));
            }

            base.Attach(unit);
        }

        /// <summary>
        /// DbAccessor 클래스가 제공하는 명령문 첨부 메서드로
        /// 본 프로젝트에는 사용될 수 없는 새로 정의하여 숨겨버렸습니다.
        /// </summary>
        private new void Attach(SqlUnit sqlUnit) { }

        /// <summary>
        /// DbAccessor 클래스가 제공하는 명령문 첨부 메서드로
        /// 본 프로젝트에는 사용될 수 없는 새로 정의하여 숨겨버렸습니다.
        /// </summary>
        private new void Attach(SqlUnitCollection sqlUnits) { }

        #endregion
    }

    /// <summary>
    /// ArrayList를 상속받아 구현된 SqlParameters 입니다. 
    /// 내부 아이템은 키와 값이 쌍으로 이루어져 object[]로 저장되어 있습니다.
    /// </summary>
    public class SqlParameters : ArrayList
    {
        public void Add(string key, object value)
        {
            base.Add(new object[] { key, value });
        }
    }
}
