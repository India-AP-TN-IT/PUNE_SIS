using System;
using System.Data;
using System.ServiceModel;
using System.Drawing;
using HE.Framework.Core;
using TheOne.ServiceModel;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Controls;
using System.Windows.Forms;
using HE.Framework.ServiceModel;
using Ax.DEV.Utility.Library;

namespace Ax.SIS.WM.UI
{
    /// <summary>
    /// Zone 마스터
    /// </summary>
    public partial class WM20442 : AxCommonBaseControl
    {
        private AxClientProxy _WSCOM;
        private string _CORCD;
        private string _BIZCD;
        private string _LANG_SET;

        public WM20442()
        {
            InitializeComponent();
            _WSCOM = new AxClientProxy();
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                _CORCD = this.UserInfo.CorporationCode;
                _BIZCD = this.UserInfo.BusinessCode;
                _LANG_SET = this.UserInfo.Language;

                HEParameterSet paramSet_AREACD_UNIT = new HEParameterSet();
                paramSet_AREACD_UNIT.Add("CORCD", _CORCD);
                paramSet_AREACD_UNIT.Add("BIZCD", _BIZCD);
                paramSet_AREACD_UNIT.Add("LANG_SET", _LANG_SET);
                DataSet combo_source_AREACD_UNIT = _WSCOM.ExecuteDataSet("APG_WM20442.INQUERY_AREACD_GROUP", paramSet_AREACD_UNIT);

                this.cbo01_AREACD.DataBind(combo_source_AREACD_UNIT.Tables[0]); 

                DataTable combo_source_PALLET_TYPE = new DataTable();
                combo_source_PALLET_TYPE.Columns.Add("CODE");
                combo_source_PALLET_TYPE.Columns.Add("NAME");
                combo_source_PALLET_TYPE.Rows.Add("S", "STATIC");
                combo_source_PALLET_TYPE.Rows.Add("M", "MOVING");

                #region [ grd01 ]
                this.grd01.AllowEditing = true;
                this.grd01.Initialize();
                this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;

                this.grd01.AddColumn(true,  false, AxFlexGrid.FtextAlign.C, 080, "법인", "CORCD");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "ZONE 코드", "ZONECD", "ZONECD");
                this.grd01.Cols["ZONECD"].Style.BackColor = Color.FromArgb(208, 253, 248);
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 150, "ZONE 명", "ZONENM", "ZONENM");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 150, "파렛트 타입", "PALLET_TYPE", "PALLET_TYPE");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 200, "Area 코드", "AREACD", "AREACD");
                //this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "Area 명", "AREANM", "AREANM");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "사용여부", "USE_YN", "USE_YN");
                //this.grd01.AddHiddenColumn("CORCD");
                //this.grd01.AddHiddenColumn("BIZCD");
                //this.grd01.AddHiddenColumn("VINCD");

                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, combo_source_AREACD_UNIT.Tables[0], "AREACD");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, combo_source_PALLET_TYPE, "PALLET_TYPE");
               //this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, combo_source_AREACD_UNIT.Tables[0], "AREANM");

                
                #endregion

                DataTable combo_source_USE_YN = new DataTable();
                combo_source_USE_YN.Columns.Add("CODE");
                combo_source_USE_YN.Columns.Add("NAME");
                combo_source_USE_YN.Rows.Add("Y", "YES");
                combo_source_USE_YN.Rows.Add("N", "NO");
                this.cbo01_USE_YN.DataBind(combo_source_USE_YN, false);
                this.cbo01_USE_YN.DropDownStyle = ComboBoxStyle.DropDownList;

               
                this.BtnQuery_Click(null, null);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #region [공통버튼]

        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                string bizcd = this.UserInfo.BusinessCode;

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.UserInfo.BusinessCode);
                set.Add("AREACD", this.cbo01_AREACD.GetValue());
                set.Add("ZONECD", this.txt01_ZONECD.GetValue());
                set.Add("ZONENM", this.txt01_ZONENM.GetValue());                
                set.Add("USE_YN", this.cbo01_USE_YN.GetValue());
                set.Add("LANG_SET", this.UserInfo.Language);

                this.BeforeInvokeServer(true);

                DataSet source = _WSCOM.ExecuteDataSet("APG_WM20442.INQUERY", set, "OUT_CURSOR");
                
                this.AfterInvokeServer();

                this.grd01.SetValue(source.Tables[0]);
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

        protected override void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet source = this.grd01.GetValue(AxFlexGrid.FActionType.Save,
                    "CORCD", "ZONECD", "ZONENM", "PALLET_TYPE", "AREACD", "USE_YN", "EMPNO", "BIZCD", "LANG_SET");

                foreach (DataRow rows in source.Tables[0].Rows)
                {
                    rows["EMPNO"] = this.UserInfo.EmpNo;
                    rows["BIZCD"] = this.UserInfo.BusinessCode;
                    rows["LANG_SET"] = this.UserInfo.Language; 
                }

                if (!IsSaveValid(source)) return;

                this.BeforeInvokeServer(true);

                _WSCOM.ExecuteNonQueryTx("APG_WM20442.DATA_SAVE", source);

                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);

                //MsgBox.Show("입력하신 계측항목관리 정보가 저장되었습니다.");
                //저장되었습니다.
                MsgCodeBox.Show("CD00-0071");
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

        //protected override void  BtnDelete_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        DataSet source = this.grd01.GetValue(AxFlexGrid.FActionType.Remove,
        //            "CORCD", "ZONECD", "ZONENM", "BIZCD", "LANG_SET");
        //        foreach (DataRow rows in source.Tables[0].Rows)
        //        {
        //            rows["BIZCD"] = this.UserInfo.BusinessCode;
        //            rows["LANG_SET"] = this.UserInfo.Language;
        //        }

        //        if (!IsDeleteValid(source)) return;

        //        this.BeforeInvokeServer(true);

        //        _WSCOM.ExecuteNonQueryTx("APG_WM20442.DATA_REMOVE", source);

        //        this.AfterInvokeServer();

        //        this.BtnQuery_Click(null, null);

        //        //MsgBox.Show("선택하신 계측항목관리 정보가 삭제되었습니다");
        //        //삭제되었습니다.
        //        MsgCodeBox.Show("CD00-0072");
        //    }
        //    catch (FaultException<ExceptionDetail> ex)
        //    {
        //        this.AfterInvokeServer();
        //        MsgBox.Show(ex.ToString());
        //    }
        //    finally
        //    {
        //        this.AfterInvokeServer();
        //    }
        //}

        #endregion

        #region [컨트롤 이벤트]

        private void grd01_RowInserted(object sender, AxFlexGrid.FAlterEventRow args)
        {
            try
            {
                for (int i = args.RowIndex; i < args.RowIndex + args.RowCount; i++)
                {
                    this.grd01.SetValue(i, "CORCD", this.UserInfo.CorporationCode);
                    //this.grd01.SetValue(i, "AREACD", "A01"); 
                    this.grd01.SetValue(i, "USE_YN", "Y");        
                }              
                
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void grd01_AfterEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            try
            {
                this.GridCell_Changed(e);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void grd01_CellChanged(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            try
            {
                this.GridCell_Changed(e);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        #region [사용자 정의 메서드]

        private void GridCell_Changed(C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            try
            {
                //if (e.Row >= this.grd01.Rows.Fixed)
                //{
                //    if (e.Col == this.grd01.Cols["WHNM"].Index)
                //    {
                //        string INSPEC_DIVNM = this.grd01.GetValue(e.Row, "WHNM").ToString();
                //        this.grd01.SetValue(e.Row, "WHCD", INSPEC_DIVNM);
                //    }
                //}
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        #region [유효성 검사]

        private bool IsSaveValid(DataSet source)
        {
            try
            {
                if (source.Tables[0].Rows.Count == 0)
                {
                    //MsgBox.Show("저장할 계측항목 정보가 존재하지 않습니다.");
                    //저장할 데이터가 존재하지 않습니다.
                    MsgCodeBox.Show("CD00-0042");
                    return false;
                }

                for (int i = 1; i < this.grd01.Rows.Count; i++)
                {
                    string ZONECD = this.grd01.GetValue(i, "ZONECD").ToString();
                    string ZONENM = this.grd01.GetValue(i, "ZONENM").ToString();
                    string PALLET_TYPE = this.grd01.GetValue(i, "PALLET_TYPE").ToString();
                    string AREACD = this.grd01.GetValue(i, "AREACD").ToString();
                    string USE_YN = this.grd01.GetValue(i, "USE_YN").ToString();

                    if (this.GetByteCount(ZONECD) == 0)
                    {
                        //MsgBox.Show(i + " 번째 행에 {ZONE 코드}가 입력되지 않았습니다.");
                        MsgCodeBox.ShowFormat("XM00-0044", i.ToString(), this.grd01.Cols[2].Caption.ToString());
                        return false;
                    }

                    if (this.GetByteCount(ZONECD) > 4)
                    {
                        //MsgBox.Show(i + " 번째 행에 {ZONE 코드}은 4byte 이상 입력할 수 없습니다.");
                        MsgCodeBox.ShowFormat("XM00-0045", i.ToString(), this.grd01.Cols[2].Caption.ToString(), "4");
                        return false;
                    }

                    if (this.GetByteCount(AREACD) == 0)
                    {
                        //MsgBox.Show(i + " 번째 행에 {Area 코드}가 입력되지 않았습니다.");
                        MsgCodeBox.ShowFormat("XM00-0044", i.ToString(), this.grd01.Cols[5].Caption.ToString());
                        return false;
                    }                   
                }

                //if (MsgBox.Show("입력하신 계측항목 정보를 저장하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
                //저장하시겠습니까?
                if (MsgCodeBox.ShowFormat("CD00-0076", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return false;

                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }

            return false;
        }

        private bool IsDeleteValid(DataSet source)
        {
            try
            {
                if (source.Tables[0].Rows.Count == 0)
                {
                    //MsgBox.Show("삭제할 계측항목 정보가 존재하지 않습니다.");
                    //삭제할 데이터가 존재하지 않습니다.
                    MsgCodeBox.Show("CD00-0041");
                    return false;
                }

                //if (MsgBox.Show("선택하신 계측항목 정보를 삭제하시겠습니까?", "경고", MessageBoxButtons.OKCancel) != DialogResult.OK)
                //삭제하시겠습니까?
                if (MsgCodeBox.ShowFormat("CD00-0077", MessageBoxButtons.OKCancel) != DialogResult.OK)
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
              

    }
}
