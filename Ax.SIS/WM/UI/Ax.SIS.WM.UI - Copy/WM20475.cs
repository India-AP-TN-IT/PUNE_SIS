#region ▶ Description & History
/* 
 * 프로그램명 : 자재 입하 등록
 * 설      명 : 
 * 최초작성자 : 김민재
 * 최초작성일 : 2015-02-04
 * 최종수정자 : 김민재
 * 최종수정일 : 2015-02-04
 * 수정  내용 : 
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2015-02-04		김민재		최초 개발
*/
#endregion
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.ServiceModel;
using System.Windows.Forms;
using C1.Win.C1FlexGrid;
using Ax.DEV.Utility.Controls;
using HE.Framework.Core;
using HE.Framework.ServiceModel;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;

namespace Ax.SIS.WM.UI
{
    /// <summary>
    /// <b>자재 입하 등록</b>
    /// </summary>    
    public partial class WM20475 : AxCommonBaseControl
    {
        private AxClientProxy _WSCOM;

        private const string _IntFormat = "###,###,###,###,##0";

        public WM20475()
        {
            InitializeComponent();

            _WSCOM = new AxClientProxy();
        }

        #region [ 초기화 작업 정의 ]

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo01_BIZCD.SetReadOnly(true);

                #region [ grd01 ]

                this.grd01.AllowEditing = true;
                this.grd01.AutoClipboard = true;
                this.grd01.AllowDragging = AllowDraggingEnum.None;
                this.grd01.Initialize();
                this.grd01.AllowSorting = AllowSortingEnum.None;
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 070, "법인코드", "CORCD", "CORCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 070, "사업장코드", "BIZCD", "BIZCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 160, "전표번호", "NOTENO", "NOTENO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 070, "SEQ", "SEQ", "SEQ");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "자재유형", "MAT_TYPE", "MAT_TYPE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "PART NO", "PARTNO", "PARTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 220, "PART NAME", "PARTNAME", "PARTNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 130, "규격", "STANDARD", "STANDARD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 070, "단위", "UNIT", "UNIT");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 090, "납품수량", "DELI_QTY", "DELI_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 090, "박스수량", "BOX_COUNT", "BOX_COUNT");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 090, "입고일자", "RCV_DATE", "RCV_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 090, "업체코드", "VENDCD", "VENDCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 220, "업체명", "VENDNM", "VENDNM");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 220, "입고상태", "RCV_STATUS", "RCV_STATUS");

                this.grd01.Cols["RCV_DATE"].Format = "yyyy-MM-dd";
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "RCV_DATE");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "DELI_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "BOX_COUNT");

                this.grd01.Cols["DELI_QTY"].Format = _IntFormat;
                this.grd01.Cols["BOX_COUNT"].Format = _IntFormat;

                this.grd01.CurrentContextMenu.Items[0].Visible = false;
                this.grd01.CurrentContextMenu.Items[1].Visible = false;
                this.grd01.CurrentContextMenu.Items[2].Visible = false;
                this.grd01.CurrentContextMenu.Items[3].Visible = false;

                this.grd01.Styles.Add("ORANGE");
                this.grd01.Styles["ORANGE"].BackColor = System.Drawing.Color.Orange;

                this.grd01.Styles.Add("GREEN");
                this.grd01.Styles["GREEN"].BackColor = System.Drawing.Color.LightGreen;

                #endregion

                this.SetRequired(this.lbl01_BIZNM, this.lbl01_DELIVERY_NOTE);
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
                DataSet source = grd01.GetValue(AxFlexGrid.FActionType.All, "CORCD", "BIZCD", "NOTENO", "USERID","RCV_STATUS");

                if (this.IsSaveValid(source))
                {
                    _WSCOM.ExecuteNonQueryTx("APG_WM20475.SAVE", source);
                    MsgCodeBox.Show("CD00-0071"); //저장되었습니다.

                    this.BtnQuery_Click(null, null);
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
            }
        }

        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                HEParameterSet param = new HEParameterSet();
                param.Add("CORCD", this.UserInfo.CorporationCode);
                param.Add("BIZCD", this.cbo01_BIZCD.GetValue());
                param.Add("DELI_NOTE", this.txt01_BARCODE_NOTE.GetValue());
                param.Add("LANG_SET", this.UserInfo.Language);

                if (this.IsQueryValid(param))
                {
                    using (DataSet source = _WSCOM.ExecuteDataSet("APG_WM20475.INQUERY",  param))
                    {
                        this.grd01.SetValue(source);

                        this.grd01.AutoSizeCols();

                        // 입고되지 않았다면 입고일자 배경을 빨간색으로
                        if (source.Tables[0].Rows.Count > 0)
                        {
                            CellRange cr = new CellRange();

                            cr = grd01.GetCellRange(1, grd01.Cols["RCV_DATE"].Index, grd01.Rows.Count-1, grd01.Cols["RCV_DATE"].Index);

                            if (source.Tables[0].Rows[0]["RCV_STATUS"].ToString().Equals("N"))
                                cr.Style = grd01.Styles["ORANGE"];
                            else
                                cr.Style = grd01.Styles["GREEN"];
                        }
                    }
                }

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
            }
        }

        protected override void BtnReset_Click(object sender, EventArgs e)
        {
            try
            {
                this.txt01_BARCODE_NOTE.Initialize();
                this.grd01.InitializeDataSource();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
            }
        }

        #endregion

        #region [ 유효성 체크 ]

        private bool IsSaveValid(DataSet source)
        {
            try
            {
                if (source == null || source.Tables.Count == 0 || source.Tables[0].Rows.Count == 0)
                {
                    //MsgBox.Show("저장할 자재입고 정보가 없습니다.");
                    MsgCodeBox.Show("CD00-0042"); // 저장할 데이터가 존재하지 않습니다.
                    return false;
                }

                source.Tables[0].Columns["NOTENO"].ColumnName = "DELI_NOTE";
                source.Tables[0].Rows[0]["USERID"] = this.UserInfo.UserID;

                // 첫줄을 제외한 나머지는 삭제
                while (source.Tables[0].Rows.Count > 1) source.Tables[0].Rows[source.Tables[0].Rows.Count - 1].Delete();

                // 이미 처리된 전표인지 체크
                if (source.Tables[0].Rows[0]["RCV_STATUS"].ToString().Equals("Y"))
                {
                    MsgCodeBox.ShowFormat("MES-0520", this.lbl01_DELIVERY_NOTE.Text);
                    return false;
                }

                // 패키지 호출전 RCV_STATUS 컬럼 제거
                source.Tables[0].Columns.Remove("RCV_STATUS");

                if (this.cbo01_BIZCD.IsEmpty)
                {
                    //MsgBox.Show("사업장코드를 선택하세요.");
                    MsgCodeBox.ShowFormat("CD00-0079", this.lbl01_BIZNM.Text);
                    return false;
                }

                if (MsgCodeBox.ShowFormat("CD00-0076", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    return false;
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
                return false;
            }

            return true;
        }

        private bool IsQueryValid(HEParameterSet param)
        {
            try
            {
                if (param["BIZCD"] == null || string.IsNullOrEmpty(Convert.ToString(param["BIZCD"])))
                {
                    //MsgBox.Show("검색할 사업장코드가 없습니다.");
                    MsgCodeBox.ShowFormat("MM02-0003", this.lbl01_BIZNM.Text);
                    return false;
                }

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