#region ▶ Description & History
/* 
 * 프로그램명 : 공통 팝업(사번 및 파트 조회)
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 최종수정자 : ㅂ명희
 * 최종수정일 : 2013-11-12
 * 수정  내용 :
 *  
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2014-07-09      배명희      프로그램 아이디 변경(X60020P1 -> XM30303P1)
 *                                          웹서비스 호출(DB) 로직 변경, 다국어 처리, 공통컨트롤로 전환
 *              2014-07-22      배명희     Ax.SIS.XM.IF 참조 제거        
 *              2014-12-17      배명희     그리드 다국어 처리 방식 변경 (XD1410사용하지 않고 XD1420사용)
 * 
*/
#endregion
using System;
using System.Collections;
using System.Data;
using System.ServiceModel;
using System.Windows.Forms;
using Ax.DEV.Utility.Controls;
using Ax.DEV.Utility.Library;
using HE.Framework.Core;
using HE.Framework.ServiceModel;
using TheOne.Windows.Forms;

namespace Ax.SIS.XM.UI
{
    /// <summary>
    /// <b>사번 헬퍼</b>
    /// - 작 성 자 : 양석원<br />
    /// - 작 성 일 : 2010-08-12<br />
    /// </summary>
    public partial class XM30303P1 : AxCommonPopupControl, IAxPopupHelper
    {
        private AxClientProxy _WSCOM;
        private string PAKAGE_NAME = "APG_XM30303";
        private string type = "";
        private DataTable _dtLang;

        public XM30303P1()
        {
            InitializeComponent();

            _WSCOM = new AxClientProxy();
            _dtLang = new DataTable();
        }

        #region [ 초기화 작업 정의 ]

        protected override void UI_Shown(EventArgs e)
        {
            try
            {                
                if (!this.IsCreated)
                {
                    _dtLang = this.getLang();

                    type = this.CodeBox.HEUserParameterGetValue("TYPE").ToString();

                    if (type.Equals("EMPNO"))
                        this.groupBox1.Height = 40; //사원조회인 경우 사업장 콤보상자 숨김
                    else
                        this.groupBox1.Height = 68; //부서조회인 경우 사업장 콤보상자 표시

                    this.cbo01_BIZCD.DataBind(this.GetBizCD(this.UserInfo.CorporationCode).Tables[0], false);
                    this.cbo01_BIZCD.DropDownStyle = ComboBoxStyle.DropDownList;
                    this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);

                    this.grd01.AllowEditing = false;
                    this.grd01.Initialize();
                    //this.grd01.Cols.RemoveRange(1, this.grd01.Cols.Count - 1);
                    this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "_사번", "XM30303P1_EMP", "XM30303P1_EMP");
                    this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 280, "_사원명", "XM30303P1_EMPNM", "XM30303P1_EMPNM");

                    this.grd02.AllowEditing = false;
                    this.grd02.Initialize();
                    //this.grd02.Cols.RemoveRange(1, this.grd02.Cols.Count - 1);
                    this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "_실", "XM30303P1_TEAM", "XM30303P1_TEAM");
                    this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 280, "_실명", "XM30303P1_TEAMNM", "XM30303P1_TEAMNM");


                    this.grd03.AllowEditing = false;
                    this.grd03.Initialize();
                    //this.grd03.Cols.RemoveRange(1, this.grd03.Cols.Count - 1);
                    this.grd03.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "_파트", "XM30303P1_LINE", "XM30303P1_LINE");
                    this.grd03.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 280, "_파트명", "XM30303P1_LINENM", "XM30303P1_LINENM");
                    
                    if (type == "EMPNO")
                    {
                        this.grd01.Visible = true;
                        this.grd02.Visible = false;
                        this.grd03.Visible = false;
                       
                        DataRow[] drsCode = _dtLang.Select("CODE='XM30303P1_EMP'");
                        DataRow[] drsName = _dtLang.Select("CODE='XM30303P1_EMPNM'");
                        
                        if (drsCode.Length > 0) this.lbl01_TYPECD.SetValue(drsCode[0]["CODENAME"].ToString());
                        else this.lbl01_TYPECD.SetValue("CODE");

                        if (drsName.Length > 0) this.lbl01_TYPENM.SetValue(drsName[0]["CODENAME"].ToString());
                        else this.lbl01_TYPENM.SetValue("NAME");
                    }
                    else if (type == "TEAM")
                    {
                        this.grd01.Visible = false;
                        this.grd02.Visible = true;
                        this.grd03.Visible = false;
                       
                        DataRow[] drsCode = _dtLang.Select("CODE='XM30303P1_TEAM'");
                        DataRow[] drsName = _dtLang.Select("CODE='XM30303P1_TEAMNM'");

                        if (drsCode.Length > 0) this.lbl01_TYPECD.SetValue(drsCode[0]["CODENAME"].ToString());
                        else this.lbl01_TYPECD.SetValue("CODE");

                        if (drsName.Length > 0) this.lbl01_TYPENM.SetValue(drsName[0]["CODENAME"].ToString());
                        else this.lbl01_TYPENM.SetValue("NAME");

                    }
                    else if (type == "LINE")
                    {
                        this.grd01.Visible = false;
                        this.grd02.Visible = false;
                        this.grd03.Visible = true;

                        DataRow[] drsCode = _dtLang.Select("CODE='XM30303P1_LINE'");
                        DataRow[] drsName = _dtLang.Select("CODE='XM30303P1_LINENM'");

                        if (drsCode.Length > 0) this.lbl01_TYPECD.SetValue(drsCode[0]["CODENAME"].ToString());
                        else this.lbl01_TYPECD.SetValue("CODE");

                        if (drsName.Length > 0) this.lbl01_TYPENM.SetValue(drsName[0]["CODENAME"].ToString());
                        else this.lbl01_TYPENM.SetValue("NAME");
                    }
                    
                    this.IsCreated = true;
                }

                if (this.CodeBox != null)
                {
                    this.txt01_TYPECD.SetValue(this.CodeBox.GetValue());
                    this.txt01_TYPENM.SetValue(this.CodeBox.GetText());
                }

                this.btn01_Inquery_Click(null, null);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        #region IHEPopupHelper 멤버

        public object SelectedValue
        {
            get { return this.SelectedData; }
        }

        public void Initialize_Helper(object sender)
        {
            this.CodeBox = (AxCodeBox)sender;
        }

        public DataTable GetDataSource(HEParameterSet set)
        {
            HEParameterSet paramSet = new HEParameterSet();
            paramSet.Add("BIZCD", this.cbo01_BIZCD.GetValue());
            //하나의 쿼리, 하나의 UI로 
            //다국어로 표현되는
            //여러 데이터를 조회하여 그리드에 보여주고, 코드박스와 연결하여 데이터 가져오려다 보니
            //아래와 같은 파라메터 매핑작업이 추가됨.

            //TYPECD, TYPENM은 조회 쿼리 파라메터명과 관련
            //XM30303P1_EMP, XM30303P1_EMPNM등은 다국어용 컬럼명과 관련.

            for (int i = 0; i < set.Items.Count; i++)
            {
                if (set.Items[i].Key.Equals("XM30303P1_EMP"))
                {
                    paramSet.Add("TYPECD", set.Items[i].Value);
                }
                else if (set.Items[i].Key.Equals("XM30303P1_EMPNM"))
                {
                    paramSet.Add("TYPENM", set.Items[i].Value);
                }
                else if (set.Items[i].Key.Equals("XM30303P1_LINE"))
                {
                    paramSet.Add("TYPECD", set.Items[i].Value);
                }
                else if (set.Items[i].Key.Equals("XM30303P1_LINENM"))
                {
                    paramSet.Add("TYPENM", set.Items[i].Value);
                }
                else
                {
                    paramSet.Add(set.Items[i].Key, set.Items[i].Value);
                }
            }

            return _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_SEARCH"), paramSet).Tables[0];
        }

        #endregion

        #region [ 사용자 정의 메서드 ]

        //다국어 데이터 조회
        private DataTable getLang()
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("MENUID", this.Name);
                set.Add("LANG_SET", this.UserInfo.Language);

                DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_AXD1420"), set);

                return source.Tables[0];
            }
            catch (FaultException<ExceptionDetail> ex)
            {

                MsgBox.Show(ex.ToString());
            }

            return null;
        }

        //그리드에서 제공되는 기능인 SelectedDataRow는 다국어 모드에서는 지원되지 않음.
        //동일한 로직을 화면에서 처리함.
        private DataRow SelectedDataRow(AxFlexGrid grd)
        {
            try
            {
                ArrayList values = new ArrayList();
                DataTable source = new DataTable();
                for (int i = grd.Cols.Fixed; i < grd.Cols.Count; i++)
                {
                    source.Columns.Add(grd.Cols[i].Name);
                    values.Add(grd.GetValue(grd.Row, grd.Cols[i].Name));
                }
                source.Rows.Add(values.ToArray());

                return source.Rows[0];
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
            }
            finally
            {
                this.AfterInvokeServer();
            }

            return null;
        }
        
        #endregion

        #region [ 기타 이벤트 정의 ]

        private void btn01_Inquery_Click(object sender, EventArgs e)
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD",    this.CodeBox.HEUserParameterGetValue("CORCD"));
                set.Add("TYPECD",   this.txt01_TYPECD.GetValue());
                set.Add("TYPENM",   this.txt01_TYPENM.GetValue());
                set.Add("LANG_SET", this.CodeBox.HEUserParameterGetValue("LANG_SET"));
                set.Add("TYPE",     this.CodeBox.HEUserParameterGetValue("TYPE"));

                this.BeforeInvokeServer(true);

                DataTable table = this.GetDataSource(set);

                if (this.grd01.Visible) this.grd01.SetValue(table);
                else if (this.grd02.Visible) this.grd02.SetValue(table);
                else if (this.grd03.Visible) this.grd03.SetValue(table);
                
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.Message);
            }
            finally
            {
                this.AfterInvokeServer();
            }
        }

        private void grd01_DoubleClick(object sender, EventArgs e)
        {
            try
            {

                if (this.grd01.Row < this.grd01.Rows.Fixed) return;

                this.SelectedData = this.SelectedDataRow(this.grd01);
                ((Form)this.Parent).Close();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void grd02_DoubleClick(object sender, EventArgs e)
        {
            try
            {

                if (this.grd02.Row < this.grd02.Rows.Fixed) return;

                this.SelectedData = this.SelectedDataRow(this.grd02);
                ((Form)this.Parent).Close();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void grd03_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (this.grd03.Row < this.grd03.Rows.Fixed) return;

                this.SelectedData = this.SelectedDataRow(this.grd03);
                ((Form)this.Parent).Close();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }
        
        #endregion

    }
}
