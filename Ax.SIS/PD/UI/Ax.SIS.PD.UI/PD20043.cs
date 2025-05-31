#region ▶ Description & History
/* 
 * 프로그램명 : PD20043 설비호기별 금형관리
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 * 
 *              날짜          작성자     이슈
 *              ---------------------------------------------------------------------------------------------
 *              2014-07-23      배명희     cdx01_LINECD, cdx02_LINECD 연결 팝업 변경 (CM20020P1 -> CM30030P1)
 *              2017-07~09   배명희      SIS 이관(구.PM20043)
 * 
 */
#endregion

using System;
using System.Data;
using System.ServiceModel;


using HE.Framework.Core;
using TheOne.ServiceModel;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using Ax.DEV.Utility.Controls;
using System.Windows.Forms;
using HE.Framework.ServiceModel;
using Ax.SIS.CM.UI;
namespace Ax.SIS.PD.UI
{
    
    /// <summary>
    /// <b>설비호기별 금형관리</b>    
    /// </summary>
    public partial class PD20043 : AxCommonBaseControl
    {
        //private IPD20043 _WSCOM;
        private AxClientProxy _WSCOM;
		private string PACKAGE_NAME = "APG_PD20043";

        private string _CORCD = "";
        private string _BIZCD = "";
        //mod test
        public PD20043()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IPD20043>("PM00", "PD20043.svc", "CustomBinding");
            _WSCOM = new AxClientProxy();
        }

        #region [ 초기화 작업 정의 ]

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.grd01.AllowEditing = false;
                this.grd01.Initialize();
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 090, "라인코드", "LINECD", "LINECD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 230, "라인명", "LINENM", "LINENM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 090, "금형번호", "MOLDNO", "MOLDNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 230, "금형명", "MOLDNM", "MOLDNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 140, "인원", "PERSON", "PERSON");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "UPH", "UPH", "UPH");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "작업순서", "WORK_SEQ", "WORK_SEQ");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 150, "최소LOT수량", "MIN_LOT_QTY", "MIN_LOT_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 080, "준비교체시간", "PREP_TIME", "PREP_TIME");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "사용유무", "USE_YN", "USE_YN");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 200, "기준생산수량", "STD_PROD_QTY", "STD_PROD_QTY");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 200, "SH_DESC", "SH_DESC", "SH_DESC");

                this.grd01.AddHiddenColumn("CORCD");
                this.grd01.AddHiddenColumn("BIZCD");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "PERSON");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "UPH");
                this.grd01.Cols["PERSON"].Format = "###,###,##0";
                this.grd01.Cols["UPH"].Format    = "###,##0.00";

                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                if (this.UserInfo.IsAdmin.Equals("Y"))
                    this.cbo01_BIZCD.SetReadOnly(false);
                else
                    this.cbo01_BIZCD.SetReadOnly(true);

                DataSet ds01 = this.GetDataSourceSchema("Code", "CodeValue");
                ds01.Tables[0].Rows.Add("N", this.GetLabel("NOT_EXIST")); //"무");
                ds01.Tables[0].Rows.Add("Y", this.GetLabel("EXIST")); //"유");
                this.cbo01_USE_YN.DataBind(ds01.Tables[0], true);

                this.cdx01_MOLDNO.HEPopupHelper     = new PD20042P1();
                this.cdx01_MOLDNO.PopupTitle        = this.GetLabel("MOLDNO");
                this.cdx01_MOLDNO.CodeParameterName = "MOLDNO";
                this.cdx01_MOLDNO.NameParameterName = "MOLDNM";
                this.cdx01_MOLDNO.HEUserParameterSetValue("CORCD", this.UserInfo.CorporationCode);
                this.cdx01_MOLDNO.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue());
                this.cdx01_MOLDNO.CodeTextBoxWidth = 10000;

                this.cdx01_LINECD.HEPopupHelper = new CM30030P1(this.GetLabel("LINECD"));//new PD20043P1();
                this.cdx01_LINECD.CodeParameterName = "LINECD";
                this.cdx01_LINECD.NameParameterName = "LINENM";
                this.cdx01_LINECD.HEUserParameterSetValue("CORCD", this.UserInfo.CorporationCode);
                this.cdx01_LINECD.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue());
                this.cdx01_LINECD.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                this.cdx01_LINECD.HEUserParameterSetValue("PRDT_DIV", "A0S");
                this.cdx01_LINECD.HEUserParameterSetValue("DATE", "");
                this.cdx01_LINECD.HEUserParameterSetValue("PLANT_DIV", this.UserInfo.PlantDiv); //2013.03.20 공장구분 추가(배명희)
                this.cdx01_LINECD.HEUserParameterSetValue("LINECD_DIV", "AD4");

                //this.cdx01_LINECD.HEPopupHelper     = new CM20020P1();//new PD20043P1();
                //this.cdx01_LINECD.PopupTitle        = "반제품 대표 라인코드";
                //this.cdx01_LINECD.CodeParameterName = "LINECD";
                //this.cdx01_LINECD.NameParameterName = "LINENM";
                //this.cdx01_LINECD.HEUserParameterSetValue("CORCD",    this.UserInfo.CorporationCode);
                //this.cdx01_LINECD.HEUserParameterSetValue("BIZCD",    this.cbo01_BIZCD.GetValue());
                //this.cdx01_LINECD.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                //this.cdx01_LINECD.HEUserParameterSetValue("PRDT_DIV", "A0S");
                //this.cdx01_LINECD.HEUserParameterSetValue("DATE", "");
                //this.cdx01_LINECD.HEUserParameterSetValue("PLANT_DIV", this.UserInfo.PlantDiv); //2013.03.20 공장구분 추가(배명희)


                this.cdx02_LINECD.HEPopupHelper = new CM30030P1(this.GetLabel("LINECD"));//new PD20043P1();
                this.cdx02_LINECD.CodeParameterName = "LINECD";
                this.cdx02_LINECD.NameParameterName = "LINENM";
                this.cdx02_LINECD.HEUserParameterSetValue("CORCD", this.UserInfo.CorporationCode);
                this.cdx02_LINECD.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue());
                this.cdx02_LINECD.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                this.cdx02_LINECD.HEUserParameterSetValue("PRDT_DIV", "A0S");
                this.cdx02_LINECD.HEUserParameterSetValue("DATE", "");
                this.cdx02_LINECD.HEUserParameterSetValue("PLANT_DIV", this.UserInfo.PlantDiv);
                this.cdx02_LINECD.HEUserParameterSetValue("LINECD_DIV", "AD4");

                //this.cdx02_LINECD.HEPopupHelper     = new CM20020P1();//new PD20043P1();
                //this.cdx02_LINECD.PopupTitle        = "반제품 대표 라인코드";
                //this.cdx02_LINECD.CodeParameterName = "LINECD";
                //this.cdx02_LINECD.NameParameterName = "LINENM";
                //this.cdx02_LINECD.HEUserParameterSetValue("CORCD",    this.UserInfo.CorporationCode);
                //this.cdx02_LINECD.HEUserParameterSetValue("BIZCD",    this.cbo01_BIZCD.GetValue());
                //this.cdx02_LINECD.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                //this.cdx02_LINECD.HEUserParameterSetValue("PRDT_DIV", "A0S");
                //this.cdx02_LINECD.HEUserParameterSetValue("DATE", "");
                //this.cdx02_LINECD.HEUserParameterSetValue("PLANT_DIV", this.UserInfo.PlantDiv); //2013.03.20 공장구분 추가(배명희)

                this.nme01_PERSON.Initialize();
                this.nme01_UPH.Initialize();

                this.SetRequired(this.lbl02_LINECD, this.lbl01_MOLDNO, this.lbl01_PERSON);
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
                DataSet source = this.GetDataSourceSchema("CORCD", "BIZCD", "LINECD", "MOLDNO", "PERSON", "UPH",
                                                "WORK_SEQ", "MIN_LOT_QTY","PREP_TIME","USE_YN","STD_PROD_QTY","LANG_SET","USERID","SH_DESC");

                if (_CORCD.Length == 0 || _BIZCD.Length == 0)
                {
                    _CORCD = this.UserInfo.CorporationCode;
                    _BIZCD = this.cbo01_BIZCD.GetValue().ToString();
                }

                source.Tables[0].Rows.Add
                (
                    _CORCD,
                    _BIZCD,
                    this.cdx02_LINECD.GetValue(),
                    this.cdx01_MOLDNO.GetValue(),
                    this.nme01_PERSON.GetDBValue(),
                    this.nme01_UPH.GetDBValue(),
                    this.nme01_WORK_SEQ.GetDBValue(),
                    this.nme01_MIN_LOT_QTY.GetDBValue(),
                    this.nme01_PREP_TIME.GetDBValue(),
                    this.cbo01_USE_YN.GetValue(),
                    this.nme01_STD_PROD_QTY.GetDBValue(),
                    this.UserInfo.Language,
                    this.UserInfo.UserID,
                    this.axTextBox1.GetValue()
                );

                if (!this.IsSaveValid(source)) return;

                this.BeforeInvokeServer(true);
                //_WSCOM.Save(source);
                _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "SAVE"), source);
                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);

                //MsgBox.Show("입력하신 설비호기 별 금형 관리 정보가 저장되었습니다");
                // 저장되었습니다.
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

        protected override void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet source = AxFlexGrid.GetDataSourceSchema("CORCD", "BIZCD", "LINECD", "MOLDNO", "PERSON");
                source.Tables[0].Rows.Add
                (
                    _CORCD,
                    _BIZCD,
                    this.cdx02_LINECD.GetValue(),
                    this.cdx01_MOLDNO.GetValue(),
                    this.nme01_PERSON.GetDBValue()
                );

                if (!this.IsDeleteValid(source)) return;

                this.BeforeInvokeServer(true);
                //_WSCOM.Remove(source);
                _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "REMOVE"), source);
                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);

                //MsgBox.Show("선택하신 설비호기 별 금형 관리 정보가 삭제되었습니다");
                // 삭제되었습니다.
                MsgCodeBox.Show("CD00-0072");
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
                
                set.Add("CORCD",    this.UserInfo.CorporationCode);
                set.Add("BIZCD",    this.cbo01_BIZCD.GetValue());
                set.Add("LINECD",   this.cdx01_LINECD.GetValue());
                set.Add("MOLDNO",   this.txt00_MOLDNO.GetValue());
                set.Add("LANG_SET", this.UserInfo.Language);

                this.BeforeInvokeServer(true);
                //DataSet dsInquery = _WSCOM.Inquery(set);
                DataSet dsInquery = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY"), set);
                this.grd01.SetValue(dsInquery);
                ShowDataCount(dsInquery);

                this.BtnReset_Click(null, null);
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
                _CORCD = "";
                _BIZCD = "";
                this.cdx02_LINECD.Initialize();
                this.cdx01_MOLDNO.Initialize();
                this.nme01_PERSON.Initialize();
                this.nme01_UPH.Initialize();
                this.nme01_WORK_SEQ.Initialize();
                this.nme01_MIN_LOT_QTY.Initialize();
                this.nme01_PREP_TIME.Initialize();
                this.cbo01_USE_YN.Initialize();
                this.nme01_STD_PROD_QTY.Initialize();
                this.cdx02_LINECD.SetReadOnly(false);
                this.cdx01_MOLDNO.SetReadOnly(false);
                this.nme01_PERSON.SetReadOnly(false);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
            }
        }

        #endregion

        #region [ 기타 컨트롤에 대한 이벤트 정의 ]

        private void grd01_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int row = this.grd01.SelectedRowIndex;
                if (row < 1) return;

                _CORCD = this.grd01.GetValue(row, "CORCD").ToString();
                _BIZCD = this.grd01.GetValue(row, "BIZCD").ToString();

                this.cdx02_LINECD.SetValue(this.grd01.GetValue(row, "LINECD"));
                this.cdx01_MOLDNO.SetValue(this.grd01.GetValue(row, "MOLDNO"));
                this.nme01_PERSON.SetValue(this.grd01.GetValue(row, "PERSON"));
                this.nme01_UPH.SetValue(this.grd01.GetValue(row, "UPH"));
                this.nme01_WORK_SEQ.SetValue(this.grd01.GetValue(row, "WORK_SEQ"));
                this.nme01_MIN_LOT_QTY.SetValue(this.grd01.GetValue(row, "MIN_LOT_QTy"));
                this.nme01_PREP_TIME.SetValue(this.grd01.GetValue(row, "PREP_TIME"));
                this.cbo01_USE_YN.SetValue(this.grd01.GetValue(row, "USE_YN"));
                this.nme01_STD_PROD_QTY.SetValue(this.grd01.GetValue(row, "STD_PROD_QTY"));
                axTextBox1.SetValue(this.grd01.GetValue(row, "SH_DESC"));
                this.cdx02_LINECD.SetReadOnly(true);
                this.cdx01_MOLDNO.SetReadOnly(true);
                this.nme01_PERSON.SetReadOnly(true);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
            }
        }

        private void cbo01_SAUP_SelectedValueChanged(object sender, EventArgs e)
        {
            this.cdx01_LINECD.SetValue("");
            this.cdx01_LINECD.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue());
            this.cdx02_LINECD.SetValue("");
            this.cdx02_LINECD.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue());

            this.cdx01_MOLDNO.SetValue("");
            this.cdx01_MOLDNO.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue());
        }

        #endregion

        #region [ 유효성 검사 ]

        private bool IsSaveValid(DataSet source)
        {
            try
            {
                DataRow row    = source.Tables[0].Rows[0];
                string  LINECD = row["LINECD"].ToString();
                string  MOLDNO = row["MOLDNO"].ToString();
                string  PERSON = row["PERSON"].ToString();
                string  UPH    = row["UPH"].ToString();
                string work_seq = row["WORK_SEQ"].ToString();
                string min_lot_qty = row["MIN_LOT_QTY"].ToString();
                string prep_time = row["PREP_TIME"].ToString();
                

                int iPERSON = 0;
                double dUPH    = 0;
                if(PERSON.Length > 0) iPERSON = Int32.Parse(PERSON);
                if(UPH.Length > 0) dUPH = Double.Parse(UPH);

                if (this.GetByteCount(LINECD) == 0)
                {
                    //MsgBox.Show("라인코드가 입력되지 않았습니다.");
                    // {0}가(이) 입력되지 않았습니다.
                    MsgCodeBox.ShowFormat("CD00-0079", this.GetLabel("LINECD"));
                    return false;
                }

                if (this.GetByteCount(MOLDNO) == 0)
                {
                    //MsgBox.Show("금형번호가 입력되지 않았습니다.");
                    // {0}가(이) 입력되지 않았습니다.
                    MsgCodeBox.ShowFormat("CD00-0079", this.GetLabel("MOLDNO"));
                    return false;
                }

                if (iPERSON < 0)
                {
                    //MsgBox.Show("인원은 음수가 될 수 없습니다.");
                    MsgCodeBox.Show("PD00-0062");
                    return false;
                }

                if (iPERSON < 1)
                {
                    //MsgBox.Show("인원은 한 명이상 입력해야 합니다.");
                    MsgCodeBox.Show("PD00-0063");
                    return false;
                }

                if (dUPH < 0)
                {
                    //MsgBox.Show("UPH 는 음수가 될 수 없습니다.");
                    MsgCodeBox.Show("PD00-0064");
                    return false;
                }

                //if (MsgBox.Show("입력하신 설비호기별 금형관리 정보를 저장하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
                // 저장하시겠습니까?
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

        private bool IsDeleteValid(DataSet source)
        {
            try
            {
                if (!this.cdx02_LINECD.ReadOnly || !this.cdx01_MOLDNO.ReadOnly || !this.nme01_PERSON.ReadOnly)
                {
                    //MsgBox.Show("데이터 입력 대기 상태에서는 삭제 기능을 사용할 수 없습니다.");
                    MsgCodeBox.Show("PD00-0059");
                    return false;
                }

                //string message = "삭제할 설비호기 별 금형 관리 정보가 존재하지 않습니다.";

                if (source.Tables[0].Rows.Count == 0)
                {
                    //MsgBox.Show(message);
                    // 삭제할 {0}가 존재하지 않습니다.
                    MsgCodeBox.ShowFormat("PD00-0061", this.GetLabel("PD20043"));
                    return false;
                }

                DataRow row = source.Tables[0].Rows[0];

                string LINECD = row["LINECD"].ToString();
                string MOLDNO = row["MOLDNO"].ToString();
                string PERSON = row["PERSON"].ToString();

                if (this.GetByteCount(LINECD) == 0)
                {
                    //MsgBox.Show(message);
                    // 삭제할 {0}가 존재하지 않습니다.
                    MsgCodeBox.ShowFormat("PD00-0061", this.lbl01_LINECD.Text);
                    return false;
                }

                if (this.GetByteCount(MOLDNO) == 0)
                {
                    //MsgBox.Show(message);
                    // 삭제할 {0}가 존재하지 않습니다.
                    MsgCodeBox.ShowFormat("PD00-0061", this.lbl01_MOLDNO.Text);
                    return false;
                }

                if (this.GetByteCount(PERSON) == 0)
                {
                    //MsgBox.Show(message);
                    // 삭제할 {0}가 존재하지 않습니다.
                    MsgCodeBox.ShowFormat("PD00-0061", this.lbl01_PERSON.Text);
                    return false;
                }

                //if (MsgBox.Show("선택하신 설비호기 별 금형 관리 정보를 삭제하시겠습니까?", "경고", MessageBoxButtons.OKCancel) != DialogResult.OK)
                // 삭제하시겠습니까?
                if (MsgCodeBox.Show("CD00-0077", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return false;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
                return false;
            }

            return true;
        }

        #endregion

        

    }
}
