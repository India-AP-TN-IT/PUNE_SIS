#region ▶ Description & History
/* 
 * 프로그램명 : I/F Item Monitoring Result
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
using C1.Win.C1FlexGrid;
using System.Drawing;

namespace Ax.SIS.XM.UI
{
    /// <summary>
    /// I/F Item Management
    /// </summary>
    public partial class XM31010 : AxCommonBaseControl
    {
        private AxClientProxy _WSCOM;        
        private string PAKAGE_NAME = "IF11.APG_XM31010";
        
        public XM31010()
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
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 250, "I/F DESCRIPTION", "IF_DESCRIPTION");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "I/F DIRECTION", "IF_DIRECTION");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "I/F USE AREA", "IF_USE_AREA");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "I/F METHOD", "IF_METHOD");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 150, "LAST INSPECT TIME", "LAST_INSPECT_TIME");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 120, "I/F CONDITION", "IF_CONDITION");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 000, "COLOR", "COLOR");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "STOP", "STOP_CNT");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "WAIT", "WAIT_CNT");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "DELAY", "DELAY_CNT");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "ERROR", "ERROR_CNT");                
                
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 120, "I/F CHARGE NAME", "IF_CHARGENM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "I/F REMARK", "IF_REMARK");

                this.grd01.Cols["STOP_CNT"].Format = "#,###,###,###,###,###,##0";
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "STOP_CNT");
                this.grd01.Cols["WAIT_CNT"].Format = "#,###,###,###,###,###,##0";
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "WAIT_CNT");
                this.grd01.Cols["DELAY_CNT"].Format = "#,###,###,###,###,###,##0";
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "DELAY_CNT");
                this.grd01.Cols["ERROR_CNT"].Format = "#,###,###,###,###,###,##0";
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "ERROR_CNT");


                CellStyle csBlue = this.grd01.Styles.Add("BLUE");
                csBlue.ForeColor = Color.Blue;
                csBlue = this.grd01.Styles.Add("bgBLUE");
                csBlue.BackColor = Color.Blue;
                csBlue.ForeColor = Color.White;
                this.lbl01_WAIT.BackColor = Color.Blue;
                this.lbl01_WAIT.ForeColor = Color.White;
                this.lbl01_WAIT.SetValue("WAIT (TOP 100)");

                CellStyle csBlack= this.grd01.Styles.Add("BLACK");
                csBlack.ForeColor = Color.Black;              

                CellStyle csOrange= this.grd01.Styles.Add("ORANGE");
                csOrange.ForeColor = Color.Orange;
                csOrange = this.grd01.Styles.Add("bgORANGE");
                csOrange.BackColor = Color.Orange;
                this.lbl01_DELAY.BackColor = Color.Orange;
                this.lbl01_DELAY.SetValue("DELAY (TOP 100)");


                CellStyle csPink= this.grd01.Styles.Add("PINK");
                csPink.ForeColor = Color.HotPink;
                csPink = this.grd01.Styles.Add("bgPINK");
                csPink.BackColor = Color.HotPink;
                this.lbl01_STOP.BackColor = Color.HotPink;
                this.lbl01_STOP.SetValue("STOP (TOP 100)");


                CellStyle csRed= this.grd01.Styles.Add("RED");
                csRed.ForeColor = Color.Red;
                csRed = this.grd01.Styles.Add("bgRED");
                csRed.BackColor = Color.Red;
                this.lbl01_ERROR.BackColor = Color.Red;
                this.lbl01_ERROR.SetValue("ERROR (TOP 100)");

                this.grd01.SetCellStyle(0, this.grd01.Cols["WAIT_CNT"].Index, "bgBLUE");
                this.grd01.SetCellStyle(0, this.grd01.Cols["DELAY_CNT"].Index, "bgORANGE");
                this.grd01.SetCellStyle(0, this.grd01.Cols["ERROR_CNT"].Index, "bgRED");
                this.grd01.SetCellStyle(0, this.grd01.Cols["STOP_CNT"].Index, "bgPINK");



                #region grid "stop"

                this.grd01_STOP.AllowEditing = false;
                this.grd01_STOP.Initialize();
                this.grd01_STOP.Cols.Count = this.grd01_STOP.Cols.Fixed;

                #endregion

                #region grid "wait"

                this.grd01_WAIT.AllowEditing = false;
                this.grd01_WAIT.Initialize();
                this.grd01_WAIT.Cols.Count = this.grd01_WAIT.Cols.Fixed;

                #endregion


                #region grid "delay"
                this.grd01_DELAY.AllowEditing = false;
                this.grd01_DELAY.Initialize();
                this.grd01_DELAY.Cols.Count = this.grd01_DELAY.Cols.Fixed;

                #endregion

                #region grid "error"
                this.grd01_ERROR.AllowEditing = false;
                this.grd01_ERROR.Initialize();
                this.grd01_ERROR.Cols.Count = this.grd01_ERROR.Cols.Fixed;
                #endregion

                DataSet source = AxFlexGrid.GetDataSourceSchema("CODE", "TEXT");
                
                //I/F DIRECTION 콤보상자
                DataTable dtIF_DIRECTION = source.Tables[0].Copy();
                dtIF_DIRECTION.Rows.Add("SEND", "SEND");
                dtIF_DIRECTION.Rows.Add("RECEIVE", "RECEIVE");
                this.cbo01_IF_DIRECTION.DataBind(dtIF_DIRECTION, true);

                //I/F USE AREA 콤보상자
                DataTable dtIF_USE_AREA = source.Tables[0].Copy();
                dtIF_USE_AREA.Rows.Add("PUBLIC", "PUBLIC");
                dtIF_USE_AREA.Rows.Add("OVERSEAS", "OVERSEAS");
                dtIF_USE_AREA.Rows.Add("DOMESTIC", "DOMESTIC");
                this.cbo01_IF_USE_AREA.DataBind(dtIF_USE_AREA, true);

                //I/F USE YN 콤보상자
                DataTable dtIF_CONDITION = source.Tables[0].Copy();
                dtIF_CONDITION.Rows.Add("WAIT", "WAIT");
                dtIF_CONDITION.Rows.Add("OK", "OK");
                dtIF_CONDITION.Rows.Add("STOP", "STOP");
                dtIF_CONDITION.Rows.Add("ERROR", "ERROR");
                dtIF_CONDITION.Rows.Add("DELAY", "DELAY");
                this.cbo01_IF_CONDITION.DataBind(dtIF_CONDITION, true);

              
             

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

        
        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                string IF_TABLE = this.txt01_IF_TABLE.GetValue().ToString();
                string IF_DESCRIPTION = this.txt01_IF_DESCRIPTION.GetValue().ToString();
                string IF_DIRECTION = this.cbo01_IF_DIRECTION.GetValue().ToString();
                string IF_USE_AREA = this.cbo01_IF_USE_AREA.GetValue().ToString();
                string IF_CONDITION = this.cbo01_IF_CONDITION.GetValue().ToString();
                string REALTIME_YN = this.chk01REALTIME_YN.Checked ? "Y" : "N";
                HEParameterSet set = new HEParameterSet();
                set.Add("IF_TABLE", IF_TABLE);
                set.Add("IF_DESCRIPTION", IF_DESCRIPTION);
                set.Add("IF_DIRECTION", IF_DIRECTION);
                set.Add("IF_USE_AREA", IF_USE_AREA);
                set.Add("IF_CONDITION", IF_CONDITION);
                set.Add("REALTIME_YN", REALTIME_YN);
                this.BeforeInvokeServer(true);
                //DataSet source = _WSCOM.INQUERY(set);
                DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY"), set);
                this.AfterInvokeServer();

                this.grd01.SetValue(source.Tables[0]);
                for (int i = this.grd01.Rows.Fixed; i < this.grd01.Rows.Count; i++)
                {
                    string color = this.grd01.GetValue(i, "COLOR").ToString();
                    this.grd01.SetCellStyle(i, this.grd01.Cols["IF_CONDITION"].Index, color);
                }

                
                this.SetGridValue(this.grd01_DELAY, null);
                this.SetGridValue(this.grd01_STOP, null);
                this.SetGridValue(this.grd01_WAIT, null);
                this.SetGridValue(this.grd01_ERROR, null);
                
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

        private void groupBox3_Resize(object sender, EventArgs e)
        {
            int height = (groupBox3.Height - 20 - 3)/ 2;
            this.pnlUp.Height = height;
            this.pnlDown.Height = (groupBox3.Height - 20 - 3) - height;

            int width = (this.pnlUp.Width - 3) / 2;
            this.pnlSTOP.Width = width;
            this.pnlWAIT.Width = (this.pnlUp.Width - 3) - width;
            this.pnlDELAY.Width = width;
            this.pnlERROR.Width = (this.pnlUp.Width - 3) - width;
        }

        #endregion

        #region [유효성 검사]

       

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
                DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_DETAIL"), set, "OUT_CURSOR", "OUT_CURSOR2", "OUT_CURSOR3", "OUT_CURSOR4");
                this.AfterInvokeServer();

                this.SetGridValue(this.grd01_STOP, source.Tables[0]);
                this.SetGridValue(this.grd01_WAIT, source.Tables[1]);
                this.SetGridValue(this.grd01_DELAY, source.Tables[2]);
                this.SetGridValue(this.grd01_ERROR, source.Tables[3]);
               
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

        private void SetGridValue(AxFlexGrid grd, DataTable source)
        {
            try
            {

                grd.BeginUpdate();
                //컬럼 정보 초기화
                for (int i = grd.Cols.Count - 1; i >= grd.Cols.Fixed; i-- )
                {
                    grd.RemoveColumn(i);
                }
                grd.Cols.Count = grd.Cols.Fixed;

                if (source != null)
                {
                    for (int i = 0; i < source.Columns.Count; i++)
                    {
                        grd.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 80, source.Columns[i].ColumnName, source.Columns[i].ColumnName);
                    }

                    if (grd.Cols.Count > grd.Cols.Fixed)
                        grd.SetValue(source);
                }
                else
                {   //source가 NULL인 경우 그리드 초기화 
                    grd.InitializeDataSource();
                }
                grd.EndUpdate();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                
                MsgBox.Show(ex.ToString());
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
