#region ▶ Description & History
/* 
 * 프로그램명 : PD20202 ALC 상세 사양관리 일괄 등록
 * 설      명 : 
 * 최초작성자 : 오세민
 * 최초작성일 : 2011-05-24 
 * 최종수정자 : 
 * 최종수정일 : 
 * 수정  내용 : 
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2010-05-24		오세민         최초 개발
 *				2014-07-23      배명희         cdx01_LINECD, cdx02_LINECD 연결 팝업 변경 (CM20020P1 -> CM30030P1)
 *				2017-07~09      배명희         SIS 이관
*/
#endregion

using System;
using System.Data;
using System.ServiceModel;
using System.Windows.Forms;

using HE.Framework.Core;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using Ax.DEV.Utility.Controls;
using Ax.SIS.CM.UI;
using HE.Framework.ServiceModel;

namespace Ax.SIS.PD.UI
{
    /// <summary>
    /// ALC 상세 사양컴럼 관리 프로그램
    /// </summary>
    public partial class PD20202 : AxCommonBaseControl
    {
        //private IPM20037 _WSCOM;
        private AxClientProxy _WSCOM;
		private string PACKAGE_NAME = "APG_PD20202";
        private DataRow _SelectedRow;

        public PD20202()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IPM20037>("PM00", "PM20037.svc", "CustomBinding");
            _WSCOM = new AxClientProxy();	

            this._buttonsControl.BtnDownload.Visible = false;
        }

        #region [ 초기화 작업 정의 ]

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                if (this.UserInfo.IsAdmin.Equals("Y"))
                    this.cbo01_BIZCD.SetReadOnly(false);
                else
                    this.cbo01_BIZCD.SetReadOnly(true);

                //DataSet source = this.GetTypeCode("A3", "CA");

                this.grd01.AllowEditing = true;
                this.grd01.Initialize(false);
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 070, "라인코드", "LINECD", "LINECD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 090, "장착위치", "INSTALL_POS", "POSTITLE");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 040, "ROWNO", "ROWNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 040, "순서", "SEQ", "SEQ");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "컬럼ID", "COLUMN_ID", "COLUMNID");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 040, "넓이", "WIDTH", "WIDTH");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 040, "정렬", "ALIGN", "ALIGN");
                

                DataSet dsALIGN = this.GetDataSourceSchema("Code", "CodeValue");
                dsALIGN.Tables[0].Rows.Add("L", "LEFT");
                dsALIGN.Tables[0].Rows.Add("C", "CENTER");
                dsALIGN.Tables[0].Rows.Add("R", "RIGHT");
                this.cbo01_ALIGN.DisplayMember = "CodeValue";
                this.cbo01_ALIGN.ValueMember = "Code";
                this.cbo01_ALIGN.DataSource = dsALIGN.Tables[0];
                //this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, dsALIGN.Tables[0], "ALIGN");

                this.SetRequired(this.lbl01_LINECD, this.lbl01_INSTALL_POS, this.lbl01_COLUMNID, this.lbl02_LINECD, this.lbl02_POSTITLE, this.lbl01_SEQ);

                this.cdx01_LINECD.HEPopupHelper = new CM30030P1(this.GetLabel("LINECD"));
                this.cdx01_LINECD.CodeParameterName = "LINECD";
                this.cdx01_LINECD.NameParameterName = "LINENM";
                this.cdx01_LINECD.HEUserParameterSetValue("CORCD", this.UserInfo.CorporationCode);
                this.cdx01_LINECD.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue());
                this.cdx01_LINECD.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                this.cdx01_LINECD.HEUserParameterSetValue("PRDT_DIV", "");
                this.cdx01_LINECD.HEUserParameterSetValue("DATE", "");
                this.cdx01_LINECD.HEUserParameterSetValue("PLANT_DIV", "");
                this.cdx01_LINECD.HEUserParameterSetValue("LINECD_DIV", "AD4");
                //this.cdx01_LINECD.HEPopupHelper = new CM20020P1();
                //this.cdx01_LINECD.PopupTitle = "라인코드";
                //this.cdx01_LINECD.CodeParameterName = "LINECD";
                //this.cdx01_LINECD.NameParameterName = "LINENM";
                //this.cdx01_LINECD.HEUserParameterSetValue("CORCD", this.UserInfo.CorporationCode);
                //this.cdx01_LINECD.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue());
                //this.cdx01_LINECD.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                //this.cdx01_LINECD.HEUserParameterSetValue("PRDT_DIV", "");
                //this.cdx01_LINECD.HEUserParameterSetValue("DATE", "");

                this.cbo01_INSTALL_POS.DataBind("A7");
                this.cdx01_LINECD.SetCodePixedLength();


                this.cdx02_LINECD.HEPopupHelper = new CM30030P1(this.GetLabel("LINECD"));//"라인코드");
                this.cdx02_LINECD.CodeParameterName = "LINECD";
                this.cdx02_LINECD.NameParameterName = "LINENM";
                this.cdx02_LINECD.HEUserParameterSetValue("CORCD", this.UserInfo.CorporationCode);
                this.cdx02_LINECD.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue());
                this.cdx02_LINECD.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                this.cdx02_LINECD.HEUserParameterSetValue("PRDT_DIV", "");
                this.cdx02_LINECD.HEUserParameterSetValue("DATE", "");
                this.cdx02_LINECD.HEUserParameterSetValue("PLANT_DIV", "");
                this.cdx02_LINECD.HEUserParameterSetValue("LINECD_DIV", "AD4");

                //this.cdx02_LINECD.HEPopupHelper = new CM20020P1();
                //this.cdx02_LINECD.PopupTitle = "라인코드";
                //this.cdx02_LINECD.CodeParameterName = "LINECD";
                //this.cdx02_LINECD.NameParameterName = "LINENM";
                //this.cdx02_LINECD.HEUserParameterSetValue("CORCD", this.UserInfo.CorporationCode);
                //this.cdx02_LINECD.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue());
                //this.cdx02_LINECD.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                //this.cdx02_LINECD.HEUserParameterSetValue("PRDT_DIV", "");
                //this.cdx02_LINECD.HEUserParameterSetValue("DATE", "");
                
                this.cbo02_INSTALL_POS.DataBind("A7");
                this.cdx02_LINECD.SetCodePixedLength();
                
                
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
            }
        }

        #endregion

        #region [ 공통 버튼에 대한 이벤트 정의 ]

        protected override void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet source = this.GetDataSourceSchema(                
                    "LINECD", "INSTALL_POS", "COLUMN_ID", "WIDTH", "ALIGN", "SEQ"
                );

                source.Tables[0].Rows.Add(
                    this.cdx02_LINECD.GetValue().ToString(), this.cbo02_INSTALL_POS.GetValue().ToString(),
                    this.txt01_COLUMN_ID.Text.Trim(), this.nme01_WIDTH.Text.Trim(), cbo01_ALIGN.GetValue().ToString(),
                    this.txt01_SEQ.Text.Trim()
                    );                

                if (!this.IsSaveValid(source)) return;

                this.BeforeInvokeServer(true);
                //_WSCOM.Save(source);
                _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "SAVE"), source);
                this.AfterInvokeServer();

                //this.BtnQuery_Click(null, null);

                //MsgBox.Show("입력하신 컬럼 정보가 저장되었습니다.");
                MsgCodeBox.Show("CD00-0071");
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

        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                HEParameterSet set = new HEParameterSet();                
                set.Add("LINECD",        this.cdx01_LINECD.GetValue().ToString());
                set.Add("INSTALL_POS", this.cbo01_INSTALL_POS.GetValue().ToString());

                this.BeforeInvokeServer(true);
                //DataSet dsInquery = _WSCOM.Inquery(set);
                DataSet dsInquery = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY"), set);
                this.grd01.SetValue(dsInquery);
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

        protected override void BtnReset_Click(object sender, EventArgs e)
        {
            try
            {
                //this.grd01.InitializeDataSource();                
                //this.cdx01_LINECD.Initialize();                
                //this.cbo01_INSTALL_POS.Initialize();
                this.cdx02_LINECD.Initialize();
                this.cbo02_INSTALL_POS.Initialize();
                this.txt01_COLUMN_ID.Initialize();
                this.nme01_WIDTH.Initialize();
                this.cbo01_ALIGN.Initialize();
                this.txt01_SEQ.SetValue(DBNull.Value);
                this.cdx02_LINECD.Enabled = true;
                this.cbo02_INSTALL_POS.Enabled = true;
                this.txt01_COLUMN_ID.SetReadOnly(false);

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
            }
        }

        protected override void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("LINECD", this.cdx02_LINECD.GetValue());
                paramSet.Add("INSTALL_POS", this.cbo02_INSTALL_POS.GetValue());
                paramSet.Add("COLUMN_ID", this.txt01_COLUMN_ID.GetValue());

                if (!IsRemoveValidate(paramSet)) return;

                this.BeforeInvokeServer(true);
                //_WSCOM.Remove(paramSet);
                _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "REMOVE"), paramSet);
                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);
                this.BtnReset_Click(null, null);

                //MsgBox.Show("선택하신 컬럼 정보가 삭제되었습니다");
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

        #endregion

        #region [ 기타 컨트롤에 대한 이벤트 정의 ]

        private void cdx01_LINECD_ButtonClickBefore(object sender, EventArgs args)
        {
            try
            {
                this.cdx01_LINECD.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue());
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }
        
        private void cdx02_LINECD_ButtonClickBefore(object sender, EventArgs args)
        {
            try
            {
                this.cdx02_LINECD.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue());
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void grd01_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {                

                if (e.Button != MouseButtons.Left) return;
                if (this.grd01.Row < this.grd01.Rows.Fixed) return;
                if (this.grd01.SelectedRowIndex < 1) return;
                this._SelectedRow = this.grd01.SelectedDataRow;
                
                this.cdx02_LINECD.CodeValidationEnabled = true;

                this.cdx02_LINECD.SetValue(this.grd01.SelectedDataRow["LINECD"].ToString());
                this.cbo02_INSTALL_POS.SetValue("A7"+this.grd01.SelectedDataRow["INSTALL_POS"].ToString());
                this.txt01_COLUMN_ID.SetValue(this.grd01.SelectedDataRow["COLUMN_ID"]);
                this.nme01_WIDTH.SetValue(this.grd01.SelectedDataRow["WIDTH"]);
                if (this.grd01.SelectedDataRow["ALIGN"].ToString().Length < 1)
                    this.cbo01_ALIGN.SetValue("L");
                else
                    this.cbo01_ALIGN.SetValue(this.grd01.SelectedDataRow["ALIGN"].ToString().Substring(0,1));
                
                this.txt01_SEQ.SetValue(this.grd01.SelectedDataRow["SEQ"]);

                this.cdx02_LINECD.CodeValidationEnabled = false;
                //HEComboBox cbo = this.grd01.SelectedDataRow["ALIGN"] as HEComboBox;
                //this.cbo01_ALIGN.SetValue(cbo);

                //this.cdx02_LINECD.ReadOnly = true;
                this.cdx02_LINECD.Enabled = false;
                this.cbo02_INSTALL_POS.Enabled = false;
                this.txt01_COLUMN_ID.ReadOnly = true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }
        
        private void cbo01_SAUP_SelectedIndexChanged(object sender, EventArgs e)
        {
            //this.cdx01_LINECD.SetValue("");
            this.cdx01_LINECD.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue());
            this.cdx02_LINECD.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue());
        }

        #endregion

        #region [ 유효성 검사 ]

        public bool IsSaveValid(DataSet source)
        {
            try
            {
                if (source.Tables[0].Rows.Count == 0)
                {
                    //MsgBox.Show("저장할 라인코드 정보가 존재하지 않습니다.");
                    MsgCodeBox.ShowFormat("PD00-0078", this.GetLabel("LINECD"));
                    return false;
                }

                if (this.cbo01_BIZCD.ByteCount == 0)
                {
                    //MsgBox.Show("사업장코드가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("CD00-0079", this.GetLabel("BIZCD"));
                    return false;
                }

                if (this.txt01_SEQ.Text == "")
                {
                    //MsgBox.Show("SEQ가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("CD00-0079", this.lbl01_SEQ.Text);
                    return false;
                }


                //if (MsgBox.Show("입력하신 컬럼 정보를 저장하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
                if (MsgCodeBox.Show("CD00-0076", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return false;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
                return false;
            }

            return true;
        }

        private bool IsRemoveValidate(HEParameterSet set)
        {
            if (set["LINECD"].Equals(""))
            {
                //MsgBox.Show("라인을 선택해주세요!");
                MsgCodeBox.ShowFormat("CD00-0080", this.GetLabel("LINECD"));
                return false;
            }

            if (set["INSTALL_POS"].Equals(""))
            {
                //MsgBox.Show("장착위치 입력해주세요!");
                MsgCodeBox.ShowFormat("CD00-0079", this.GetLabel("POSTITLE"));
                return false;
            }

            if (set["COLUMN_ID"].Equals(""))
            {
                //MsgBox.Show("컬럼명을 입력해주세요!");
                MsgCodeBox.ShowFormat("CD00-0079", this.GetLabel("COLUMNNM"));
                return false;
            }

            //if (MsgBox.Show("선택하신 공정 정보를 삭제하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
            if (MsgCodeBox.Show("CD00-0077", MessageBoxButtons.OKCancel) != DialogResult.OK)
                return false;

            return true;
        }

        #endregion
        
    }
}
