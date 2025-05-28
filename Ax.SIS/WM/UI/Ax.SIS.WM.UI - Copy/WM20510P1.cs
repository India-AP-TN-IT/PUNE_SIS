using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.ServiceModel;
using System.Text;
using System.Windows.Forms;


using HE.DevHelper;
using HE.Framework.Core;
using HE.Framework.WindowForms;
using TheOne.ServiceModel;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Controls;
using HE.Framework.ServiceModel;
using C1.Win.C1FlexGrid;
using Ax.DEV.Utility.Library;

namespace Ax.SIS.WM.UI
{
    /// <summary>
    /// <b>UI 화면을 정의하는 사용자 정의 클래스</b>    
    /// </summary>
    public partial class WM20510P1 : AxCommonPopupControl, IAxPopupHelper
    {
        private bool _UseCheck = false;
        
        public WM20510P1()
        {
            InitializeComponent();
        }

        public WM20510P1(bool bUseCheck)
        {
            InitializeComponent();
            _UseCheck = bUseCheck;
        }

        #region [ 초기화 작업 정의 ]

        /// <summary>
        /// Shown 이벤트를 통해 초기화 작업을 수행한다.
        /// </summary>
        /// <param name="sender">객체</param>
        /// <param name="e">이벤트</param>
        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                if (!IsCreated)
                {
                    IsCreated = true;

                    this.grd01.Initialize();

                    this.grd01.AllowEditing = true; 
                    this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 038, "CHK", "CHK", "CHK");
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 078, "Std Date", "STD_DATE", "STD_DATE");
                    this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "PALLET NO", "PALLET_NO", "PALLET_NO");
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 120, "Lot no", "LOTNO", "LOTNO");
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "Part no", "PARTNO", "PARTNO");
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 170, "Part name", "PARTNM", "PARTNM");
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "Inv desc", "INV_DESC", "INV_DESC");
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 040, "Qty", "QTY", "QTY");
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 040, "ALC", "ALCCD", "ALCCD");
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 070, "DOM Type","DOM_IMP_DIV", "DOM_IMP_DIV");
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 070, "MAT Type", "MAT_TYPE", "MAT_TYPE");
                    //this.grd01.AddHiddenColumn("MAT_TYPE_CD");
                    //this.grd01.AddHiddenColumn("DOM_IMP_DIV_CD");

                    if (_UseCheck)
                        this.grd01.Cols["CHK"].Visible = true;

                    this.grd01.SetColumnType(AxFlexGrid.FCellType.Check, "CHK");
                    this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "QTY");
                    
                    //전체선택 체크박스
                    /*CellStyle cs;
                    if (!this.grd01.Styles.Contains("Boolean"))
                    {
                        cs = this.grd01.Styles.Add("Boolean");
                        cs.DataType = typeof(Boolean);
                        cs.ImageAlign = C1.Win.C1FlexGrid.ImageAlignEnum.CenterCenter;
                    }
                    else
                    {
                        cs = this.grd01.Styles["Boolean"];
                    }
                    
                    this.grd01.Cols["CHK"].StyleFixed = cs;
                    this.grd01.Cols["CHK"].Style = cs;
                    */ 

                    Query();
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
        }



        #endregion

        #region [ Property ]

        private string _CORCD;
        public string CORCD
        {
            set
            {
                _CORCD = value;
            }
        }

        private string _BIZCD;
        public string BIZCD
        {
            set
            {
                _BIZCD = value;
            }
        }

        private string _PARTNO;
        public string PARTNO
        {
            set
            {
                _PARTNO = value;
            }
        }

        private string _LOTNO;
        public string LOTNO
        {
            set
            {
                _LOTNO = value;
            }
        }

        private string _PALLET_NO;
        public string PALLET_NO
        {
            set
            {
                _PALLET_NO = value;
            }
        }

        private string _LOCATION_NO;
        public string LOCATION_NO
        {
            set
            {
                _LOCATION_NO = value;
            }
        }

        private string _PRDT_DIV = "A";
        public string PRDT_DIV
        {
            set
            {
                // M(자재;Material)또는 A(완/반제품 Complete, in-Complete product)
                if (string.Equals(value, "M"))
                    _PRDT_DIV = "M";
                else
                    _PRDT_DIV = "A";
            }
        }

        private string _MAT_TYPE_CD;
        public string MAT_TYPE_CD
        {
            set
            {
                _MAT_TYPE_CD = value;
            }
        }

        private string _DOM_IMP_DIV_CD;
        public string DOM_IMP_DIV_CD
        {
            set
            {
                _DOM_IMP_DIV_CD = value;
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
        }

        public DataTable GetDataSource(HEParameterSet set)
        {
            return new DataTable();
        }

        #endregion

        private void btn01_CLEAR_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.grd01.Rows.Count < 2)
                {
                    return;
                }

                if (MsgCodeBox.Show("PD00-0023", MessageBoxButtons.OKCancel) != DialogResult.OK) return;
                 
                // get grid data
                DataSet set = this.grd01.GetValue(AxFlexGrid.FActionType.All, "CHK", "LOTNO", "PARTNO", "DOM_IMP_DIV_CD", "MAT_TYPE_CD");

                set.Tables[0].Columns.Add("CORCD");
                set.Tables[0].Columns.Add("BIZCD");
                set.Tables[0].Columns.Add("LOCATION_NO");
                set.Tables[0].Columns.Add("PRDT_DIV");
                //set.Tables[0].Columns.Add("DOM_IMP_DIV_CD");
                //set.Tables[0].Columns.Add("MAT_TYPE_CD");
                set.Tables[0].Columns.Add("USER_ID");
                 
                for (int i = set.Tables[0].Rows.Count-1; i > -1; i--)
                {
                    set.Tables[0].Rows[i]["CORCD"] = _CORCD;
                    set.Tables[0].Rows[i]["BIZCD"] = _BIZCD;
                    set.Tables[0].Rows[i]["LOCATION_NO"] = _LOCATION_NO;
                    set.Tables[0].Rows[i]["PRDT_DIV"] = _PRDT_DIV;
                    set.Tables[0].Rows[i]["LOTNO"] = this.grd01.Rows[i+1]["LOTNO"];
                    set.Tables[0].Rows[i]["DOM_IMP_DIV_CD"] = this.grd01.Rows[i+1]["DOM_IMP_DIV"];
                    set.Tables[0].Rows[i]["MAT_TYPE_CD"] = this.grd01.Rows[i+1]["MAT_TYPE"]; 
                    set.Tables[0].Rows[i]["USER_ID"] = this.UserInfo.EmpNo;
                    if (set.Tables[0].Rows[i]["CHK"].ToString().Equals("N"))
                        set.Tables[0].Rows.RemoveAt(i);
                }

                // remove check box column
                set.Tables[0].Columns.Remove("CHK");

                this.BeforeInvokeServer(true);

                using (AxClientProxy proxy = new AxClientProxy())
                {
                    proxy.ExecuteNonQueryTx("APG_WM20510.SAVE", set);  //MES8030.INV_STATUS to 'X'
                }

                Query();
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

        private void Query()
        {
            try
            {
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", _CORCD);
                paramSet.Add("BIZCD", _BIZCD);
                paramSet.Add("LOCATION_NO", _LOCATION_NO);
                paramSet.Add("LANG_SET", this.UserInfo.Language);
                paramSet.Add("PARTNO", _PARTNO);
                paramSet.Add("LOTNO", _LOTNO);
                //paramSet.Add("PALLET_NO", _PALLET_NO);
                paramSet.Add("MAT_TYPE", _MAT_TYPE_CD);
                paramSet.Add("DOM_IMP_DIV", _DOM_IMP_DIV_CD);

                this.BeforeInvokeServer(true);

                DataSet source;
                using (AxClientProxy proxy = new AxClientProxy())
                {
                    if (_PRDT_DIV == "M")
                    {
                        source = proxy.ExecuteDataSet("APG_WM20510.INQUIRY_LOCATION_MATERIAL", paramSet);
                        this.grd01.Cols["ALCCD"].Visible = false;
                        this.grd01.Cols["MAT_TYPE"].Visible = true;
                    }
                    else
                    {
                        source = proxy.ExecuteDataSet("APG_WM20510.INQUIRY_LOCATION_ASSY", paramSet);
                        this.grd01.Cols["ALCCD"].Visible = true;
                        this.grd01.Cols["MAT_TYPE"].Visible = false;
                    }
                }
                this.grd01.SetValue(source.Tables[0]);

                this.AfterInvokeServer();
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

        private void btn01_QUERY_Click(object sender, EventArgs e)
        {
            try
            {
                Query(); 
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
         

    }
}
