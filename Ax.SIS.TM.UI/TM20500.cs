#region ▶ Description & History
/* 
 * 프로그램명 : PD40520 금형투입이력 조회
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2017-07~09    배명희     SIS 이관
 *				
*/
#endregion
using System;
using System.Data;
using System.ServiceModel;
using System.Windows.Forms;


using HE.Framework.Core;
using TheOne.ServiceModel;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using Ax.DEV.Utility.Controls;
using HE.Framework.ServiceModel;
using System.IO;
using System.Collections.Generic;
using System.Drawing;

namespace Ax.SIS.TM.UI
{
    /// <summary>
    /// 수지 Grade 관리
    /// </summary>
    public partial class TM20500 : AxCommonBaseControl
    {
        private Dictionary<string, byte[]> m_Imgs = new Dictionary<string, byte[]>();
        private Dictionary<string, string> m_DicSelected = new Dictionary<string, string>();
        private AxClientProxy _DB = new AxClientProxy();
        public enum TabEnum
        {
            NONE,
            AREA,
            DOCUMENT,
            GROUP
        }
        private TabEnum GetCurTab()
        {
            if(tabControl1.SelectedIndex == 0)
            {
                return TabEnum.AREA;
            }
            else if(tabControl1.SelectedIndex == 1)
            { 
                return TabEnum.DOCUMENT;
            }
            else if (tabControl1.SelectedIndex == 2)
            {
                return TabEnum.GROUP;
            }
            else
            {
                return TabEnum.NONE;
            }
        }
        
        public TM20500()
        {
            InitializeComponent();
            
            
        }
        protected override void UI_Shown(EventArgs e)
        {
            base.UI_Shown(e);
            pictureBox1.Visible = false;
            Lbl_DocSelected.Text = "";
            lblSelectedGrp.Text = "";
            //CORCD
            cbo01_CORCD.DataBind_CORCD();
            cbo01_CORCD.SetValue(this.UserInfo.CorporationCode);
            cbo01_CORCD.SetReadOnly(true);
            //BIZCD
            cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode);
            cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
            cbo01_BIZCD.SetReadOnly(this.UserInfo.IsAdmin.Equals("N"));
            cbo01_BIZCD.DropDownStyle = ComboBoxStyle.DropDownList;

            this.cdx01_DOCCD.HEPopupHelper = new Ax.SIS.TM.UI.TM20500_DLG("DOCCD", "Doc No.", "Doc Name","","");
            this.cdx01_DOCCD.PopupTitle = "Document";
            this.cdx01_DOCCD.HEUserParameterSetValue("CORCD", cbo01_CORCD.GetValue());
            this.cdx01_DOCCD.HEUserParameterSetValue("BIZCD", cbo01_BIZCD.GetValue());
            this.cdx01_DOCCD.CodeParameterName = "CD";
            this.cdx01_DOCCD.NameParameterName = "NM";
            this.cdx01_DOCCD.HEPopupHelper.Initialize_Helper(cdx01_DOCCD);

            this.cdx01_AREA.HEPopupHelper = new Ax.SIS.TM.UI.TM20500_DLG("LOCCD", "Location NO.", "Location Name", "", "");
            this.cdx01_AREA.PopupTitle = "Area";
            this.cdx01_AREA.HEUserParameterSetValue("CORCD", cbo01_CORCD.GetValue());
            this.cdx01_AREA.HEUserParameterSetValue("BIZCD", cbo01_BIZCD.GetValue());
            this.cdx01_AREA.CodeParameterName = "CD";
            this.cdx01_AREA.NameParameterName = "NM";
            this.cdx01_AREA.HEPopupHelper.Initialize_Helper(cdx01_AREA);


            cdx01_GRPCD.HEPopupHelper = new Ax.SIS.TM.UI.TM20500_DLG("GRPCD", "GROUP NO.", "GROUP Name", "", "");
            this.cdx01_GRPCD.PopupTitle = "Group";
            this.cdx01_GRPCD.HEUserParameterSetValue("CORCD", cbo01_CORCD.GetValue());
            this.cdx01_GRPCD.HEUserParameterSetValue("BIZCD", cbo01_BIZCD.GetValue());
            this.cdx01_GRPCD.CodeParameterName = "CD";
            this.cdx01_GRPCD.NameParameterName = "NM";
            this.cdx01_GRPCD.HEPopupHelper.Initialize_Helper(cdx01_GRPCD);


            //grd02
            this.grd02.AllowEditing = true;
            this.grd02.Initialize();
            this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 48, "CORCD", "CORCD", "CORCD");
            this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 80, "BIZCD", "BIZCD", "BIZCD");
            this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 80, "BUILDING", "AREA_DESC", "AREA_DESC");
            this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 80, "L/CODE", "LOCCD", "LOCCD");
            this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 200, "L/NAME", "LOCNM", "LOCNM");
            this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 300, "COMMENT", "COMM", "COMM");
            this.grd02.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 80, "UPDATE_ID", "UPDATE_ID", "UPDATE_ID");
            this.grd02.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 80, "UPDATE_DATE", "UPDATE_DATE", "UPDATE_DATE");


            //grd03
            this.grd03.AllowEditing = true;
            this.grd03.Initialize();
            this.grd03.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 48, "CORCD", "CORCD", "CORCD");
            this.grd03.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 80, "BIZCD", "BIZCD", "BIZCD");
            this.grd03.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 80, "D/CODE", "DOCCD", "DOCCD");
            this.grd03.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 300, "D/DESC", "DOCNM", "DOCNM");
            this.grd03.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 300, "COMMENT", "COMM", "COMM");
            this.grd03.AllowEditing = false;
            //grd04
            this.grd04.AllowEditing = true;
            this.grd04.Initialize();
            this.grd04.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 48, "CORCD", "CORCD", "CORCD");
            this.grd04.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 80, "BIZCD", "BIZCD", "BIZCD");
            this.grd04.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 80, "D/CODE", "AREACD", "AREACD");
            this.grd04.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 80, "CHK/CODE", "CHKCD", "CHKCD");
            this.grd04.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 300, "CHK/DESC", "CHKNM", "CHKNM");
            this.grd04.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 280, "COMMENT", "COMM", "COMM");
            this.grd04.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 90, "PERIOD", "PERD", "PERD");
            this.grd04.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 200, "METHOD", "METHOD", "METHOD");
            this.grd04.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "V/TYPE", "VALUE_TYPE", "VALUE_TYPE");
            this.grd04.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 60, "IMG", "IMG", "IMG");
            this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 70, "UPLOAD", "IMG_BTN", "IMG_BTN");
            this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 70, "VIEW", "IMG_DESC", "IMG_DESC");
            this.grd04.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 80, "UPDATE_ID", "UPDATE_ID", "UPDATE_ID");
            this.grd04.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 80, "UPDATE_DATE", "UPDATE_DATE", "UPDATE_DATE");
            this.grd04.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 80, "CHKIDX", "CHKIDX", "CHKIDX");
            this.grd04.SetColumnType(AxFlexGrid.FCellType.ComboBox, "T7", "PERD");
            this.grd04.SetColumnType(AxFlexGrid.FCellType.ComboBox, "TW", "VALUE_TYPE");



            //grd05
            this.grd05.AllowEditing = true;
            this.grd05.Initialize();
            this.grd05.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 48, "CORCD", "CORCD", "CORCD");
            this.grd05.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 80, "BIZCD", "BIZCD", "BIZCD");
            this.grd05.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 80, "G/CODE", "GRPCD", "GRPCD");
            this.grd05.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 300, "Group Name", "GRPNM", "GRPNM");            
            this.grd05.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 200, "COMMENT", "COMM", "COMM");
            this.grd05.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 80, "UPDATE_ID", "UPDATE_ID", "UPDATE_ID");
            this.grd05.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 80, "UPDATE_DATE", "UPDATE_DATE", "UPDATE_DATE");
            this.grd05.AllowEditing = false;


            //grd06
            this.grd06.AllowEditing = true;
            this.grd06.Initialize();
            this.grd06.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 48, "CORCD", "CORCD", "CORCD");
            this.grd06.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 80, "BIZCD", "BIZCD", "BIZCD");
            this.grd06.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 80, "G/CODE", "GRPCD", "AREACD");
            this.grd06.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 80, "M/CODE", "MEMCD", "MEMCD");
            this.grd06.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 300, "MEMBER NAME", "MEMNM", "MEMNM");
            this.grd06.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 250, "WHATSAPP#", "WHA_NUM", "WHA_NUM");
            this.grd06.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 80, "UPDATE_ID", "UPDATE_ID", "UPDATE_ID");
            this.grd06.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 80, "UPDATE_DATE", "UPDATE_DATE", "UPDATE_DATE");
        }
        private int GetDETRow(string ordSEQ, string colname)
        {
            
            for (int row = grd04.Rows.Fixed; row < grd04.Rows.Count; row++)
            {
                if (grd04.GetValue(row, colname).ToString() == ordSEQ)
                {
                    return row;
                }
            }
            return -1;
        }
        private string GetSelectedHeader(string colnm)
        {
            if(m_DicSelected.ContainsKey(colnm))
            {
                return m_DicSelected[colnm];
            }
            else
            {
                return "";
            }
        }
        private void SetSelectedHeader(string colnm, string val)
        {
            if(m_DicSelected.ContainsKey(colnm) == false)
            {
                m_DicSelected.Add(colnm, val);
            }
            else
            {
                m_DicSelected[colnm] = val;
            }
        }
        private void SetImgDic()
        {
            DataSet sourceIU = this.grd04.GetValue(AxFlexGrid.FActionType.Save
                                                              , "CORCD", "BIZCD", "DOCCD", "CHKCD", "CHKIDX"
                                                              
                                                            );

            for (int row = 0; row < sourceIU.Tables[0].Rows.Count; row++)
            {
                string key = sourceIU.Tables[0].Rows[row]["CHKCD"].ToString() + GetSelectedHeader("DOCCD");
                string ordSEQ = sourceIU.Tables[0].Rows[row]["CHKIDX"].ToString();
                if (m_Imgs.ContainsKey(key) == false)
                {
                    int grdROW = GetDETRow(ordSEQ, "CHKIDX");
                    if (grdROW != -1)
                    {
                        object objIMG = grd04.GetValue(grdROW, "IMG");
                        if (objIMG != DBNull.Value)
                        {
                            m_Imgs.Add(key, (byte[])objIMG);
                        }
                    }


                }
            }
        }
        protected override void BtnSave_Click(object sender, EventArgs e)
        {
            base.BtnSave_Click(sender, e);
            if (GetCurTab() == TabEnum.AREA)
            {   //Area/Loc
                DataSet ds_LOC = grd02.GetValue(AxFlexGrid.FActionType.Save, "CORCD", "BIZCD", "AREA_DESC", "LOCCD", "LOCNM", "COMM", "UPDATE_ID");
                DataSet ds_LOC_DEL = grd02.GetValue(AxFlexGrid.FActionType.Remove, "CORCD", "BIZCD",  "LOCCD");
                if (ds_LOC.Tables[0].Rows.Count > 0)
                {
                    for (int row = 0; row < ds_LOC.Tables[0].Rows.Count; row++)
                    {
                        ds_LOC.Tables[0].Rows[row]["CORCD"] = cbo01_CORCD.GetValue().ToString();
                        ds_LOC.Tables[0].Rows[row]["BIZCD"] = cbo01_BIZCD.GetValue().ToString();
                        ds_LOC.Tables[0].Rows[row]["UPDATE_ID"] = UserInfo.UserID;
                        ;
                    }
                    _DB.ExecuteNonQueryTx("APG_TM20500.LOC_SAVE", ds_LOC);
                }
                
                if (ds_LOC_DEL.Tables[0].Rows.Count > 0)
                {
                    _DB.ExecuteNonQueryTx("APG_TM20500.LOC_DEL", ds_LOC_DEL);
                }                
                
            }
            else if (GetCurTab() == TabEnum.DOCUMENT)
            {   //Doc
                DataSet ds = grd03.GetValue(AxFlexGrid.FActionType.Save, "CORCD", "BIZCD", "DOCCD", "DOCNM","COMM", "UPDATE_ID");
                
                DataSet ds_DEL = grd03.GetValue(AxFlexGrid.FActionType.Remove, "CORCD", "BIZCD", "DOCCD");

                DataSet ds_ChkUI = grd04.GetValue(AxFlexGrid.FActionType.Save, "CORCD", "BIZCD", "DOCCD", "CHKCD", "CHKNM", "COMM"
                                                                    , "UPDATE_ID", "CHKIDX", "PERD"
                                                                  , "METHOD"
                                                                  , "VALUE_TYPE");
                
                DataSet ds_Chk = this.GetDataSourceSchema("CORCD"
                                                                  , "BIZCD"

                                                                  , "DOCCD"
                                                                  , "CHKCD"
                                                                  , "CHKNM"
                                                                  , "COMM"
                                                                  , "BLOB$IMG"
                                                                  , "UPDATE_ID"
                                                                  ,"CHKIDX"
                                                                  ,"PERD"
                                                                  ,"METHOD"
                                                                  ,"VALUE_TYPE");
                DataSet ds_Chk_DEL = grd02.GetValue(AxFlexGrid.FActionType.Remove, "CORCD", "BIZCD", "DOCCD", "CHKCD");

                if (ds_ChkUI.Tables[0].Rows.Count > 0)
                {
                    SetImgDic();
                    foreach (DataRow dr in ds_ChkUI.Tables[0].Rows)
                    {
                        

                        dr["CORCD"] = cbo01_CORCD.GetValue().ToString();
                        dr["BIZCD"] = cbo01_BIZCD.GetValue().ToString();
                        dr["UPDATE_ID"] = UserInfo.UserID;
                        dr["DOCCD"] = GetSelectedHeader("DOCCD");

                        string key = dr["CHKCD"].ToString() + GetSelectedHeader("DOCCD");
                        ds_Chk.Tables[0].ImportRow(dr);
                        if (m_Imgs.Count > 0 && m_Imgs.ContainsKey(key))
                        {
                            ds_Chk.Tables[0].Rows[ds_Chk.Tables[0].Rows.Count - 1]["$IMG"] = m_Imgs[key];
                        }

                    }
                    _DB.ExecuteNonQueryTx("APG_TM20500.CHK_SAVE", ds_Chk);
                    
                }
                m_Imgs = new Dictionary<string, byte[]>();

                if (ds_Chk_DEL.Tables[0].Rows.Count > 0)
                {
                    _DB.ExecuteNonQueryTx("APG_TM20500.CHK_DEL", ds_Chk_DEL);
                }
                
                
                if (ds_DEL.Tables[0].Rows.Count > 0)
                {
                    _DB.ExecuteNonQueryTx("APG_TM20500.DOC_DEL", ds_DEL);
                }
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int row = 0; row < ds.Tables[0].Rows.Count; row++)
                    {
                        ds.Tables[0].Rows[row]["CORCD"] = cbo01_CORCD.GetValue().ToString();
                        ds.Tables[0].Rows[row]["BIZCD"] = cbo01_BIZCD.GetValue().ToString();
                        ds.Tables[0].Rows[row]["UPDATE_ID"] = UserInfo.UserID;
                    }
                    _DB.ExecuteNonQueryTx("APG_TM20500.DOC_SAVE", ds);
                }
                

            }
            else if (GetCurTab() == TabEnum.GROUP)
            {
                
                DataSet ds = grd05.GetValue(AxFlexGrid.FActionType.Save, "CORCD", "BIZCD", "GRPCD", "GRPNM", "COMM", "UPDATE_ID");

                DataSet ds_DEL = grd05.GetValue(AxFlexGrid.FActionType.Remove, "CORCD", "BIZCD", "GRPCD");

                DataSet ds_MEM_DEL = grd06.GetValue(AxFlexGrid.FActionType.Remove, "CORCD", "BIZCD", "GRPCD","MEMCD");

                DataSet ds_MEM = grd06.GetValue(AxFlexGrid.FActionType.Save, "CORCD", "BIZCD", "GRPCD", "MEMCD", "MEMNM", "WHA_NUM", "UPDATE_ID");
                if (ds_DEL.Tables[0].Rows.Count > 0)
                {
                    _DB.ExecuteNonQueryTx("APG_TM20500.GRP_DEL", ds_DEL);
                }
                if (ds_MEM_DEL.Tables[0].Rows.Count > 0)
                {
                    _DB.ExecuteNonQueryTx("APG_TM20500.MEMBER_DEL", ds_MEM_DEL);
                }
                if (ds_MEM.Tables[0].Rows.Count > 0)
                {
                    for (int row = 0; row < ds_MEM.Tables[0].Rows.Count; row++)
                    {
                        ds_MEM.Tables[0].Rows[row]["GRPCD"] = GetSelectedHeader("GRPCD");
                        ds_MEM.Tables[0].Rows[row]["CORCD"] = cbo01_CORCD.GetValue().ToString();
                        ds_MEM.Tables[0].Rows[row]["BIZCD"] = cbo01_BIZCD.GetValue().ToString();
                        ds_MEM.Tables[0].Rows[row]["UPDATE_ID"] = UserInfo.UserID;
                    }
                    _DB.ExecuteNonQueryTx("APG_TM20500.MEMBER_SAVE", ds_MEM);
                }
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int row = 0; row < ds.Tables[0].Rows.Count; row++)
                    {
                        ds.Tables[0].Rows[row]["CORCD"] = cbo01_CORCD.GetValue().ToString();
                        ds.Tables[0].Rows[row]["BIZCD"] = cbo01_BIZCD.GetValue().ToString();
                        ds.Tables[0].Rows[row]["UPDATE_ID"] = UserInfo.UserID;
                    }
                    _DB.ExecuteNonQueryTx("APG_TM20500.GRP_SAVE", ds);

                }
            }

            BtnQuery_Click(null, null);
            ReadDetData(); 
        }

        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            if (GetCurTab() == TabEnum.AREA)
            {

                HEParameterSet param = new HEParameterSet();

                param.Add("CORCD", cbo01_CORCD.GetValue());
                param.Add("BIZCD", cbo01_BIZCD.GetValue());
                param.Add("LOCCD", cdx01_AREA.GetValue());
                DataSet ds = _DB.ExecuteDataSet("APG_TM20500.LOC_INQUERY", param);

                grd02.SetValue(ds);

            }
            else if(GetCurTab() == TabEnum.DOCUMENT)
            {
                HEParameterSet param = new HEParameterSet();

                param.Add("CORCD", cbo01_CORCD.GetValue());
                param.Add("BIZCD", cbo01_BIZCD.GetValue());
                param.Add("DOCCD", cdx01_DOCCD.GetValue());
                DataSet ds = _DB.ExecuteDataSet("APG_TM20500.DOC_INQUERY", param);

                grd03.SetValue(ds);

                Chk_DocEdit.Checked = false;
            }
            else if(GetCurTab() == TabEnum.GROUP)
            {
                HEParameterSet param = new HEParameterSet();

                param.Add("CORCD", cbo01_CORCD.GetValue());
                param.Add("BIZCD", cbo01_BIZCD.GetValue());
                param.Add("GRPCD", cdx01_GRPCD.GetValue());
                DataSet ds = _DB.ExecuteDataSet("APG_TM20500.GRP_INQUERY", param);

                grd05.SetValue(ds);

                ChkGRPEdit.Checked = false;
            }
        }

        private void ReadDetData()
        {
            string corcd = cbo01_CORCD.GetValue().ToString();
            string bizcd = cbo01_BIZCD.GetValue().ToString();
            HEParameterSet param =null;
            if(GetCurTab() == TabEnum.DOCUMENT)
            {
                
                param = new HEParameterSet();
                param.Add("CORCD", corcd);
                param.Add("BIZCD", bizcd);
                param.Add("DOCCD", GetSelectedHeader("DOCCD"));
                DataSet ds = _DB.ExecuteDataSetTx("APG_TM20500.CHKLIST_INQUERY", param);
                grd04.SetValue(ds);
              
            }
            else if (GetCurTab() == TabEnum.GROUP)
            {

                param = new HEParameterSet();
                param.Add("CORCD", corcd);
                param.Add("BIZCD", bizcd);
                param.Add("GRPCD", GetSelectedHeader("GRPCD"));
                DataSet ds = _DB.ExecuteDataSetTx("APG_TM20500.MEMBER_INQUERY", param);
                grd06.SetValue(ds);

            }
        }

        private void ChkEdit_CheckedChanged(object sender, EventArgs e)
        {
            if (GetCurTab() == TabEnum.DOCUMENT)
            {
                grd03.AllowEditing = Chk_DocEdit.Checked;
            }
            else if (GetCurTab() == TabEnum.GROUP)
            {
                grd05.AllowEditing = ChkGRPEdit.Checked;
            }
        }

        private void GRD_DblClick(object sender, MouseEventArgs e)
        {
            if (sender is AxFlexGrid)
            {

                AxFlexGrid tmpGRD = ((AxFlexGrid)sender);
                int row = tmpGRD.Row;
                if(row >= tmpGRD.Rows.Fixed)
                {
                    string colnm = "";
                
                    switch(GetCurTab())
                    {
                        
                        case TabEnum.DOCUMENT:
                            colnm = "DOCCD";
                            SetSelectedHeader(colnm,tmpGRD.GetValue(row, colnm).ToString());
                            Lbl_DocSelected.Text = GetSelectedHeader(colnm);
                            break;
                        case TabEnum.GROUP:
                            colnm = "GRPCD";
                            SetSelectedHeader(colnm,tmpGRD.GetValue(row, colnm).ToString());
                            lblSelectedGrp.Text = GetSelectedHeader(colnm);
                            break;
                    }
                    
                    
                }
                ReadDetData();
            }
        }
        private Image GetByteImg(byte[] by)
        {
            try
            {
                MemoryStream ms = new MemoryStream(by, 0, by.Length);
                ms.Write(by, 0, by.Length);
                return Image.FromStream(ms, true);
            }
            catch { }
            return null;
        }
        private bool ExistCHKCD(int cop, string ord)
        {
            for (int row = grd04.Rows.Fixed; row < grd04.Rows.Count; row++)
            {
                if (cop != row)
                {
                    if (grd04.GetValue(row, "CHKCD").ToString() == ord)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        private void grd04_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FileStream oFile = null;
            try
            {
                pictureBox1.Visible = false;

                int row = grd04.Row;
                int col = grd04.Col;
                if (grd04.Cols[col].Name == "IMG_DESC")
                {
                    pictureBox1.Image = null;
                    object objIMG = grd04.GetValue(row, "IMG");
                    if (objIMG != DBNull.Value)
                    {
                        byte[] by = (byte[])objIMG;
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                        if (by != null)
                        {
                            pictureBox1.Image = GetByteImg(by);
                        }
                        
                        pictureBox1.BringToFront();
                        pictureBox1.Visible = true;
                    }
                  
                }
                if (grd04.Cols[col].Name == "IMG_BTN")
                {
                    string chkcd = grd04.GetValue(row, "CHKCD").ToString();
                    string doccd = GetSelectedHeader("DOCCD");
                    if (string.IsNullOrEmpty(doccd))
                    {
                        MsgBox.Show("Document Code is mandatory", "Error");
                        return;
                    }
                    if (string.IsNullOrEmpty(chkcd))
                    {
                        MsgBox.Show("Check Code is mandatory", "Error");
                        return;
                    }
                    if (ExistCHKCD(row, chkcd))
                    {
                        MsgBox.Show("Check Code needs to be unique", "Error");
                        return;
                    }
                    if (row >= this.grd04.Rows.Fixed)
                    {
                        OpenFileDialog ofd = new OpenFileDialog();

                        //파일 선택 필터
                        ofd.Title = this.GetLabel("ATTACH_PDF"); 
                        ofd.Filter = FileFilter.imageString;
                        ofd.FilterIndex = 0;

                        //파일 선택 되면
                        if (ofd.ShowDialog(this) == DialogResult.OK)
                        {
                            //PDF 파일을 읽어서 Grid 등록 처리함
                            oFile = File.Open(ofd.FileName, FileMode.Open, FileAccess.Read);

                            byte[] cFileBuf = new byte[oFile.Length];

                            oFile.Read(cFileBuf, 0, Convert.ToInt32(oFile.Length));
                            string key = chkcd + doccd;
                            if (m_Imgs.ContainsKey(key) == false)
                            {
                                m_Imgs.Add(key, cFileBuf);
                            }
                            else
                            {
                                m_Imgs[key] = cFileBuf;
                            }
                            oFile.Close();
                        }
                        grd04.SetValue(row, 0, "U");
                    }
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
            finally
            {
                if (oFile != null)
                    oFile.Close();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
        }

        private void cdx01_AREA_CodeBoxBindingAfter(object sender, EventArgs args)
        {
            
        }

        private void cbo01_BIZCD_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cdx01_AREA.HEUserParameterSetValue("BIZCD", cbo01_BIZCD.GetValue());
            this.cdx01_DOCCD.HEUserParameterSetValue("BIZCD", cbo01_BIZCD.GetValue());
            this.cdx01_GRPCD.HEUserParameterSetValue("BIZCD", cbo01_BIZCD.GetValue());
        }


    }
}

