#region ▶ Description & History
/* 
 * 프로그램명 : I/F Item Management
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2017-10-24      배명희      신규 개발
*/
#endregion
using System;
using System.Data;
using System.ServiceModel;
using System.Windows.Forms;
using Ax.DEV.Utility.Controls;
using Ax.DEV.Utility.Library;
using Ax.SIS.CM.UI;
using HE.Framework.Core;
using HE.Framework.ServiceModel;
using TheOne.Windows.Forms;
using System.Text;
using System.Text.RegularExpressions;

namespace Ax.SIS.XM.UI
{
    /// <summary>
    /// I/F Item Management
    /// </summary>
    public partial class XM21010 : AxCommonBaseControl
    {
        private AxClientProxy _WSCOM;        
        private string PAKAGE_NAME = "IF11.APG_XM21010";
        
        public XM21010()
        {
            InitializeComponent();

            _WSCOM = new AxClientProxy();
        }
        
        #region [초기화 작업 정의]

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.grd01.AllowEditing = false;
                this.grd01.Initialize();
                //this.grd01.Cols.RemoveRange(1, this.grd01.Cols.Count - 1);
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "I/F TABLE", "IF_TABLE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 240, "I/F DESCRIPTION", "IF_DESCRIPTION");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "I/F DIRECTION", "IF_DIRECTION");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 090, "I/F USE AREA", "IF_USE_AREA");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 090, "I/F USE Y/N", "IF_USE_YN");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 110, "I/F STATUS FIELD", "IF_STATUS_FIELD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "I/F TIME FIELD", "IF_TIME_FIELD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "I/F MONITOR Y/N", "IF_MONITOR_YN");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "I/F METHOD", "IF_METHOD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 090, "I/F PERIOD", "IF_PERIOD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "I/F MSG FIELD", "IF_MSG_FIELD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "I/F CHARGE NAME", "IF_CHARGENM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "I/F REMARK", "IF_REMARK");

                DataSet source = AxFlexGrid.GetDataSourceSchema("CODE", "TEXT");
                
                //I/F DIRECTION 콤보상자
                DataTable dtIF_DIRECTION = source.Tables[0].Copy();
                dtIF_DIRECTION.Rows.Add("SEND", "SEND");
                dtIF_DIRECTION.Rows.Add("RECEIVE", "RECEIVE");
                this.cbo01_IF_DIRECTION.DataBind(dtIF_DIRECTION, true);
                this.cbo02_IF_DIRECTION.DataBind(dtIF_DIRECTION, true);

                //I/F USE AREA 콤보상자
                DataTable dtIF_USE_AREA = source.Tables[0].Copy();
                dtIF_USE_AREA.Rows.Add("PUBLIC", "PUBLIC");
                dtIF_USE_AREA.Rows.Add("OVERSEAS", "OVERSEAS");
                dtIF_USE_AREA.Rows.Add("DOMESTIC", "DOMESTIC");
                this.cbo01_IF_USE_AREA.DataBind(dtIF_USE_AREA, true);
                this.cbo02_IF_USE_AREA.DataBind(dtIF_USE_AREA, true);

                //I/F USE YN 콤보상자
                DataTable dtIF_USE_YN = source.Tables[0].Copy();
                dtIF_USE_YN.Rows.Add("USE", "USE");
                dtIF_USE_YN.Rows.Add("NOT USE", "NOT USE");
                this.cbo01_IF_USE_YN.DataBind(dtIF_USE_YN, true);
                this.cbo02_IF_USE_YN.DataBind(dtIF_USE_YN, true);

                //I/F STATUS FIELD 콤보상자
                DataTable dtIF_STATUS_FIELD = source.Tables[0].Copy();
                dtIF_STATUS_FIELD.Rows.Add("ZRSLT_SAP", "ZRSLT_SAP");
                dtIF_STATUS_FIELD.Rows.Add("ZRSLT_LEGACY", "ZRSLT_LEGACY");
                this.cbo02_IF_STATUS_FIELD.DataBind(dtIF_STATUS_FIELD, true);

                //I/F TIME FIELD 콤보상자
                DataTable dtIF_TIME_FIELD = source.Tables[0].Copy();
                dtIF_TIME_FIELD.Rows.Add("ZDATE_PO", "ZDATE_PO");
                this.cbo02_IF_TIME_FIELD.DataBind(dtIF_TIME_FIELD, true);

                //I/F MONITOR YN 콤보상자
                DataTable dtIF_MONITOR_YN = source.Tables[0].Copy();
                dtIF_MONITOR_YN.Rows.Add("MONITORING", "MONITORING");
                dtIF_MONITOR_YN.Rows.Add("NO", "NO");
                this.cbo01_IF_MONITOR_YN.DataBind(dtIF_MONITOR_YN, true);
                this.cbo02_IF_MONITOR_YN.DataBind(dtIF_MONITOR_YN, true);

                //I/F METHOD 콤보상자
                DataTable dtIF_METHOD = source.Tables[0].Copy();
                dtIF_METHOD.Rows.Add("PROGRAM", "PROGRAM");
                dtIF_METHOD.Rows.Add("DBJOB", "DBJOB");
                dtIF_METHOD.Rows.Add("TRIGGER", "TRIGGER");
                this.cbo02_IF_METHOD.DataBind(dtIF_METHOD, true);

                //I/F PERIOD 콤보상자
                DataTable dtIF_PERIOD = this.getIF_PERIOD();
                this.cbo02_IF_PERIOD.DataBind(dtIF_PERIOD, true);
                this.cbo02_IF_PERIOD.DropDownStyle = ComboBoxStyle.DropDown;


                //I/F MSG FIELD 콤보상자
                DataTable dtIF_MSG_FIELD = source.Tables[0].Copy();
                dtIF_MSG_FIELD.Rows.Add("ZMSG_SAP", "ZMSG_SAP");
                dtIF_MSG_FIELD.Rows.Add("ZMSG_LEGACY", "ZMSG_LEGACY");
                this.cbo02_IF_MSG_FIELD.DataBind(dtIF_MSG_FIELD, true);

                
                this.SetRequired(this.lbl02_IF_TABLE, this.lbl02_IF_DESCRIPTION, this.lbl02_IF_DIRECTION, this.lbl02_IF_USE_AREA,
                                    this.lbl02_IF_USE_YN, this.lbl02_IF_STATUS_FIELD, this.lbl02_IF_TIME_FIELD, this.lbl02_IF_MONITOR_YN);


                this.BtnReset_Click(null, null);
                this.BtnQuery_Click(null, null);
                
                
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        #region [ 공통 버튼에 대한 이벤트 정의 ]

        protected override void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet source = this.GetDataSourceSchema(
                    "IF_TABLE", "IF_DESCRIPTION", "IF_DIRECTION", "IF_USE_AREA", "IF_USE_YN", "IF_STATUS_FIELD",
                    "IF_TIME_FIELD", "IF_MONITOR_YN", "IF_METHOD", "IF_PERIOD", "IF_CHARGENM", "IF_REMARK", "IF_MSG_FIELD");

                source.Tables[0].Rows.Add(
                    this.txt02_IF_TABLE.GetValue(),
                    this.txt02_IF_DESCRIPTION.GetValue(),
                    this.cbo02_IF_DIRECTION.GetValue(),
                    this.cbo02_IF_USE_AREA.GetValue(),
                    this.cbo02_IF_USE_YN.GetValue(),
                    this.cbo02_IF_STATUS_FIELD.GetValue(),
                    this.cbo02_IF_TIME_FIELD.GetValue(),
                    this.cbo02_IF_MONITOR_YN.GetValue(),
                    this.cbo02_IF_METHOD.GetValue(),
                    this.cbo02_IF_PERIOD.GetText(),
                    this.txt02_IF_CHARGENM.GetValue(),
                    this.txt02_IF_REMARK.GetValue(),
                    this.cbo02_IF_MSG_FIELD.GetValue()
                    );

                if (!this.IsSaveValid(source)) return;

                this.BeforeInvokeServer(true);
                //_WSCOM.SAVE(source);
                _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "SAVE"), source);
                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);
                
                //MsgBox.Show("입력하신 사용자 정보를 저장하였습니다.");
                MsgCodeBox.Show("XM00-0081");
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
            finally
            {
                this.AfterInvokeServer();
            }
        }

        protected override void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string IF_TABLE = this.txt02_IF_TABLE.GetValue().ToString();
                HEParameterSet set = new HEParameterSet();
                set.Add("IF_TABLE", IF_TABLE);

                if (!this.IsDeleteValid()) return;

                this.BeforeInvokeServer(true);                
                _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "REMOVE"), set);
                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);

                //MsgBox.Show("삭제되었습니다.");
                MsgCodeBox.Show("CD00-0072");


            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
            finally
            {
                this.AfterInvokeServer();
            }
        }

        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                string IF_TABLE = this.txt01_IF_TABLE.GetValue().ToString();
                string IF_DESCRIPTION = this.txt01_IF_DESCRIPTION.GetValue().ToString();
                string IF_DIRECTION = this.cbo01_IF_DIRECTION.GetValue().ToString();
                string IF_USE_AREA = this.cbo01_IF_USE_AREA.GetValue().ToString();
                string IF_USE_YN = this.cbo01_IF_USE_YN.GetValue().ToString();
                string IF_MONITOR_YN = this.cbo01_IF_MONITOR_YN.GetValue().ToString();
                HEParameterSet set = new HEParameterSet();
                set.Add("IF_TABLE", IF_TABLE);
                set.Add("IF_DESCRIPTION", IF_DESCRIPTION);
                set.Add("IF_DIRECTION", IF_DIRECTION);
                set.Add("IF_USE_AREA", IF_USE_AREA);
                set.Add("IF_USE_YN", IF_USE_YN);
                set.Add("IF_MONITOR_YN", IF_MONITOR_YN);
                this.BeforeInvokeServer(true);
                //DataSet source = _WSCOM.INQUERY(set);
                DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY"), set);
                this.AfterInvokeServer();

                this.grd01.SetValue(source.Tables[0]);

                this.BtnReset_Click(null, null);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
            finally
            {
                this.AfterInvokeServer();
            }
        }

        protected override void BtnReset_Click(object sender, EventArgs e)
        {
            try
            {

                this.txt02_IF_TABLE.Initialize();
                this.txt02_IF_TABLE.SetReadOnly(false);
                this.txt02_IF_DESCRIPTION.Initialize();
                this.cbo02_IF_DIRECTION.Initialize();
                this.cbo02_IF_USE_AREA.SetValue("PUBLIC");                
                this.cbo02_IF_USE_YN.SetValue("USE");
                this.cbo02_IF_STATUS_FIELD.SetValue("ZRSLT_SAP");
                this.cbo02_IF_TIME_FIELD.SetValue("ZDATE_PO");
                this.cbo02_IF_MONITOR_YN.SetValue("MONITORING");
                this.cbo02_IF_METHOD.Initialize();

                //I/F PERIOD 콤보는 다시 바인딩 필요함. 
                this.cbo02_IF_PERIOD.DataBind(this.getIF_PERIOD(), true);
                this.cbo02_IF_PERIOD.Initialize();

                this.txt02_IF_CHARGENM.Initialize();
                this.txt02_IF_REMARK.Initialize();

                this.cbo02_IF_MSG_FIELD.Initialize();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        #region [기타 이벤트에 대한 정의]

        private void grd01_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                int row = this.grd01.SelectedRowIndex;
                if (row < this.grd01.Rows.Fixed) return;
                string IF_TABLE = this.grd01.GetValue(row, "IF_TABLE").ToString();

                this.BtnQuery_Click(IF_TABLE);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        //i/f period는 숫자만 입력되도록..
        private void cbo02_IF_PERIOD_TextChanged(object sender, EventArgs e)
        {

            StringBuilder builder = new StringBuilder();
            Regex regex = new Regex(@"[0-9]");
            string inputText = this.cbo02_IF_PERIOD.Text;

            for (int i = 0; i < inputText.Length; i++)
            {
                string charText = inputText[i].ToString();

                if (regex.IsMatch(charText))
                    builder.Append(charText);
            }

            this.cbo02_IF_PERIOD.Text = builder.ToString();
        }

        #endregion

        #region [유효성 검사]

        private bool IsSaveValid(DataSet source)
        {
            try
            {
                //--I/F TABLE
                if (this.txt02_IF_TABLE.IsEmpty)
                {
                    //MsgBox.Show("I/F TABLE 입력하세요.");
                    MsgCodeBox.ShowFormat("XM00-0001", this.lbl02_IF_TABLE.Text);
                    return false;
                }
                if (this.GetByteCount(this.txt02_IF_TABLE.GetValue().ToString()) > 30)
                {
                    //MsgBox.Show("{0}은 {1}bytes 이상 입력할 수 없습니다.");
                    MsgCodeBox.ShowFormat("CD00-0116", this.lbl02_IF_TABLE.Text, 30);
                    return false;
                }

                //--I/F DESCRIPTION
                if (this.txt02_IF_DESCRIPTION.IsEmpty)
                {
                    //MsgBox.Show("I/F DESCRIPTION 입력하세요.");
                    MsgCodeBox.ShowFormat("XM00-0001", this.lbl02_IF_DESCRIPTION.Text);
                    return false;
                }
                if (this.GetByteCount(this.txt02_IF_DESCRIPTION.GetValue().ToString()) > 300)
                {
                    //MsgBox.Show("{0}은 {1}bytes 이상 입력할 수 없습니다.");
                    MsgCodeBox.ShowFormat("CD00-0116", this.lbl02_IF_DESCRIPTION.Text, 300);
                    return false;
                }


                //--I/F DIRECTION
                if (this.cbo02_IF_DIRECTION.IsEmpty)
                {
                    //MsgBox.Show("I/F DIRECTION를 입력하세요.");
                    MsgCodeBox.ShowFormat("XM00-0001", this.lbl02_IF_DIRECTION.Text);
                    return false;
                }


                //--I/F USE AREA
                if (this.cbo02_IF_USE_AREA.IsEmpty)
                {
                    //MsgBox.Show("I/F USE AREA을 입력하세요.");
                    MsgCodeBox.ShowFormat("XM00-0001", this.lbl02_IF_USE_AREA.Text);
                    return false;
                }

                //--I/F USE_YN
                if (this.cbo02_IF_USE_YN.IsEmpty)
                {
                    //MsgBox.Show("I/F USE_YN를 입력하세요.");
                    MsgCodeBox.ShowFormat("XM00-0001", this.lbl02_IF_USE_YN.Text);
                    return false;
                }

                //--I/F STATUS FIELD
                if (this.cbo02_IF_STATUS_FIELD.IsEmpty)
                {
                    //MsgBox.Show("I/F STATUS FIELD를 입력하세요.");
                    MsgCodeBox.ShowFormat("XM00-0001", this.lbl02_IF_STATUS_FIELD.Text);
                    return false;
                }

                //--I/F TIME FIELD
                if (this.cbo02_IF_TIME_FIELD.IsEmpty)
                {
                    //MsgBox.Show("I/F TIME FIELD를 입력하세요.");
                    MsgCodeBox.ShowFormat("XM00-0001", this.lbl02_IF_TIME_FIELD.Text);
                    return false;
                }

                //I/F MONITOR YN
                if (this.cbo02_IF_MONITOR_YN.IsEmpty)
                {
                    //MsgBox.Show("I/F MONITOR Y/N를 입력하세요.");
                    MsgCodeBox.ShowFormat("XM00-0001", this.lbl02_IF_MONITOR_YN.Text);
                    return false;
                }

                //IF_METHOD - DBJOB 선택시 I/F 주기는 필수 입력임.
                if (!this.cbo02_IF_METHOD.IsEmpty && this.cbo02_IF_METHOD.GetValue().ToString().Equals("DBJOB"))
                {
                    if (this.cbo02_IF_PERIOD.GetText().Equals(string.Empty))
                    {
                        //MsgBox.Show("I/F PRRIOD을 입력하세요.");
                        MsgCodeBox.ShowFormat("XM00-0001", this.lbl02_IF_PERIOD.Text);
                        return false;
                    }

                    //I/F주기는 반드시 숫자만 입력되어야함.
                    string IF_PERIOD = this.cbo02_IF_PERIOD.GetText();
                    decimal result = 0;
                    if (!Decimal.TryParse(IF_PERIOD,out result))
                    {
                        //{0}는 숫자만 입력하여아 합니다.
                        MsgCodeBox.ShowFormat("CD00-0117", this.lbl02_IF_PERIOD.Text);
                        return false;
                    }
                }

                //--I/F CHARGE NAME
                if (this.GetByteCount(this.txt02_IF_CHARGENM.GetValue().ToString()) > 50)
                {
                    //MsgBox.Show("{0}은 {1}bytes 이상 입력할 수 없습니다.");
                    MsgCodeBox.ShowFormat("CD00-0116", this.lbl02_IF_CHARGENM.Text, 50);
                    return false;
                }

                //--I/F REMARK
                if (this.GetByteCount(this.txt02_IF_REMARK.GetValue().ToString()) > 4000)
                {
                    //MsgBox.Show("{0}은 {1}bytes 이상 입력할 수 없습니다.");
                    MsgCodeBox.ShowFormat("CD00-0116", this.lbl02_IF_REMARK.Text, 4000);
                    return false;
                }

                //데이터를 저장하시겠습니까?
                if (MsgCodeBox.Show("CD00-0017", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return false;

                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }

            return false;
        }

        private bool IsDeleteValid()
        {
            try
            {
                if (!this.txt02_IF_TABLE.ReadOnly)
                {
                    //MsgBox.Show("삭제할 {0} 항목이 선택되지 않았습니다.");
                    MsgCodeBox.ShowFormat("CD00-0118", this.lbl02_IF_TABLE.Text);
                    return false;
                }

                //if (MsgBox.Show("삭제하시겠습니까?", "경고", MessageBoxButtons.OKCancel) != DialogResult.OK)
                if (MsgCodeBox.Show("CD00-0077", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return false;

                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }

            return false;
        }

        #endregion

        #region [사용자 정의 메서드]

        private void BtnQuery_Click(string IF_TABLE)
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("IF_TABLE", IF_TABLE);

                this.BeforeInvokeServer(true);
                //DataSet source = _WSCOM.INQUERY_DETAIL(set);
                DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_DETAIL"), set);
                this.AfterInvokeServer();

                if (source.Tables[0].Rows.Count == 0) return;

                this.txt02_IF_TABLE.SetValue(IF_TABLE);
                this.txt02_IF_TABLE.SetReadOnly(true);
                DataRow row = source.Tables[0].Rows[0];

                this.txt02_IF_DESCRIPTION.SetValue(row["IF_DESCRIPTION"].ToString());
                this.cbo02_IF_DIRECTION.SetValue(row["IF_DIRECTION"].ToString());
                this.cbo02_IF_USE_AREA.SetValue(row["IF_USE_AREA"].ToString());
                this.cbo02_IF_USE_YN.SetValue(row["IF_USE_YN"].ToString());
                this.cbo02_IF_STATUS_FIELD.SetValue(row["IF_STATUS_FIELD"].ToString());
                this.cbo02_IF_TIME_FIELD.SetValue(row["IF_TIME_FIELD"].ToString());
                this.cbo02_IF_MONITOR_YN.SetValue(row["IF_MONITOR_YN"].ToString());
                this.cbo02_IF_METHOD.SetValue(row["IF_METHOD"].ToString());
                this.txt02_IF_CHARGENM.SetValue(row["IF_CHARGENM"].ToString());
                this.txt02_IF_REMARK.SetValue(row["IF_REMARK"].ToString());
                this.cbo02_IF_PERIOD.SetValue(row["IF_PERIOD"].ToString());
                this.cbo02_IF_MSG_FIELD.SetValue(row["IF_MSG_FIELD"].ToString());
                
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
            finally
            {
                this.AfterInvokeServer();
            }
        }

        private DataTable getIF_PERIOD()
        {
            try
            {
                

                DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_IF_PERIOD"));
                                
                return source.Tables[0];
            }
            catch (FaultException<ExceptionDetail> ex)
            {

                MsgBox.Show(ex.ToString());
            }

            return null;
        }

        #endregion        

        
        
    }
}
