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
using HE.Framework.Core.Report;
using System.Diagnostics;
using C1.Win.C1FlexGrid;
using System.Data.OleDb;
using System.Text;
using Ax.SIS.CM.UI;
using System.IO;
using System.Collections.Generic;

namespace Ax.SIS.PD.UI
{
    /// <summary>
    /// Location 마스터
    /// </summary>
    public partial class PD20060 : AxCommonBaseControl
    {
        private AxClientProxy _WSCOM;
        Dictionary<string, byte[]> m_Imgs = new Dictionary<string, byte[]>();
        public PD20060()
        {
            InitializeComponent();
            _WSCOM = new AxClientProxy();
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                label2.Text = "";
                this.cdx01_LINECD.HEPopupHelper = new CM30030P1(this.GetLabel("LINECD"));//new PD20043P1();
                this.cdx01_LINECD.CodeParameterName = "LINECD";
                this.cdx01_LINECD.NameParameterName = "LINENM";
                this.cdx01_LINECD.HEUserParameterSetValue("CORCD", this.UserInfo.CorporationCode);
                this.cdx01_LINECD.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue());
                this.cdx01_LINECD.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                this.cdx01_LINECD.HEUserParameterSetValue("PRDT_DIV", "");
                this.cdx01_LINECD.HEUserParameterSetValue("DATE", "");
                this.cdx01_LINECD.HEUserParameterSetValue("PLANT_DIV", this.UserInfo.PlantDiv); //2013.03.20 공장구분 추가(배명희)
                this.cdx01_LINECD.HEUserParameterSetValue("LINECD_DIV", "");

                this.cdx01_VINCD.HEPopupHelper = new CM30010P1("A3", true, true, this.cdx01_VINCD);
                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo01_BIZCD.SetReadOnly(true);

                this.cbo01_CORCD.DataBind_CORCD();
                this.cbo01_CORCD.SetValue(this.UserInfo.CorporationCode);
                this.cbo01_CORCD.SetReadOnly(true);

                #region [그리드1]
                
                this.grd01.AllowEditing = false;
                this.grd01.Initialize();
                this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
                
                this.grd01.AllowSorting = AllowSortingEnum.None;
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "Corporation Code", "CORCD", "CORCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "Business Code", "BIZCD", "BIZCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 70, "MODEL", "VINCD", "VINCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "Part Number", "PARTNO", "PARTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 380, "Part Description", "PARTNM", "PARTNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 210, "LINE", "LINENM", "LINENM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 55, "POS", "INSTALL_POS", "INSTALL_POS");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 55, "DIV", "PRDT_DIV", "PRDT_DIV");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 75, "ITEM/CNT", "ITEM_CNT", "ITEM_CNT");

     


                #endregion


                this.grd02.AllowEditing = true;
                this.grd02.Initialize();
                this.grd02.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;

                this.grd02.AllowSorting = AllowSortingEnum.None;
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "Corporation Code", "CORCD", "CORCD");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "Business Code", "BIZCD", "BIZCD");                
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 150, "Part Number", "PARTNO", "PARTNO");

                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 60, "SEQ", "SEQ", "SEQ");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 180, "INSPECT", "INSP_DESC", "INSP_DESC");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 55, "D/SEQ", "ORD_SEQ", "ORD_SEQ");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 65, "U/IMG", "IMG_ICON", "IMG_ICON");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 65, "V/IMG", "IMG_VIEW", "IMG_VIEW");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 65, "IMG", "IMG", "IMG");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 85, "UPDATE", "UPDATE_ID", "UPDATE_ID");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 85, "ITEMNO", "ITEMNO", "ITEMNO");



                this.grd03.AllowEditing = false;
                this.grd03.Initialize();
                this.grd03.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;

                this.grd03.AllowSorting = AllowSortingEnum.None;
                this.grd03.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "Corporation Code", "CORCD", "CORCD");
                this.grd03.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "Business Code", "BIZCD", "BIZCD");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "Part Number", "PARTNO", "PARTNO");
                this.grd03.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 90, "LOT", "LOTNO", "LOTNO");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 60, "SEQ", "SEQ_ID", "SEQ_ID");
                this.grd03.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 55, "D/SEQ", "ORD_SEQ", "ORD_SEQ");
                this.grd03.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 180, "INSPECT", "INSP_DESC", "INSP_DESC");
                this.grd03.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 90, "RSLT", "RSLT", "RSLT");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 170, "I/DATE", "UPDATE_DATE", "UPDATE_DATE");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 85, "Worker", "UPDATE_ID", "UPDATE_ID");
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
                if (tabControl1.SelectedIndex == 0)
                {
                    pictureBox1.Image = null;
                    string bizcd = this.UserInfo.BusinessCode;

                    HEParameterSet set = new HEParameterSet();
                    DataSet source = null;
                    set.Add("CORCD", cbo01_CORCD.GetValue());
                    set.Add("BIZCD", cbo01_BIZCD.GetValue());
                    set.Add("VINCD", cdx01_VINCD.GetValue());
                    set.Add("PARTNO", Txt_PartNo.Text);
                    set.Add("PRDT_DIV", "");
                    set.Add("LINECD", cdx01_LINECD.GetValue());

                    this.BeforeInvokeServer(true);

                    source = _WSCOM.ExecuteDataSet("APG_PD20060.INQUERY", set, "OUT_CURSOR");

                    this.AfterInvokeServer();

                    this.grd01.SetValue(source.Tables[0]);
                    m_Imgs = new Dictionary<string, byte[]>();
                }
                else if(tabControl1.SelectedIndex == 1)
                {
                    DataSet source = null;
                    HEParameterSet set = new HEParameterSet();
                    set.Add("CORCD", cbo01_CORCD.GetValue());
                    set.Add("BIZCD", cbo01_BIZCD.GetValue());
                    set.Add("VINCD", cdx01_VINCD.GetValue());
                    set.Add("PARTNO", Txt_PartNo.Text);
                    set.Add("PRDT_DIV", "");
                    set.Add("LINECD", cdx01_LINECD.GetValue());
                    set.Add("LOTNO", textBox2.Text);
                    set.Add("PROD_DATE", axDateEdit1.GetDateText());
                    
                    this.BeforeInvokeServer(true);

                    source = _WSCOM.ExecuteDataSet("APG_PD20060.INQUERY_HIST", set, "OUT_CURSOR");

                    this.AfterInvokeServer();

                    this.grd03.SetValue(source.Tables[0]);
                }
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
        private int GetDETRow(string ordSEQ)
        {
            for(int row = grd02.Rows.Fixed;row<grd02.Rows.Count;row++)
            {
                if(grd02.GetValue(row, "ORD_SEQ").ToString() == ordSEQ)
                {
                    return row;
                }
            }
            return -1;
        }
        private void SetImgDic()
        {
            DataSet sourceIU = this.grd02.GetValue(AxFlexGrid.FActionType.Save
                                                              , "CORCD"
                                                              , "BIZCD"

                                                              , "PARTNO"
                                                              , "ITEMNO"
                                                              , "INSP_DESC"

                                                              , "ORD_SEQ"
                                                              , "UPDATE_ID"
                                                            );
            
            for(int row = 0;row<sourceIU.Tables[0].Rows.Count;row++)
            {
                string key = sourceIU.Tables[0].Rows[row]["PARTNO"].ToString() + sourceIU.Tables[0].Rows[row]["ORD_SEQ"].ToString();
                string ordSEQ = sourceIU.Tables[0].Rows[row]["ORD_SEQ"].ToString();
                if(m_Imgs.ContainsKey(key) == false)
                {
                    int grdROW = GetDETRow(ordSEQ);
                    if(grdROW!=-1)
                    {
                        object objIMG = grd02.GetValue(grdROW, "IMG");
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
            try
            {
                if (tabControl1.SelectedIndex == 0)
                {


                    DataSet source = this.GetDataSourceSchema("CORCD"
                                                                  , "BIZCD"

                                                                  , "PARTNO"
                                                                  , "ITEMNO"
                                                                  , "INSP_DESC"
                                                                  , "BLOB$IMG"
                                                                  , "ORD_SEQ"
                                                                  , "UPDATE_ID");
                    DataSet sourceIU = null;
                    sourceIU = this.grd02.GetValue(AxFlexGrid.FActionType.Save
                                                                  , "CORCD"
                                                                  , "BIZCD"

                                                                  , "PARTNO"
                                                                  , "ITEMNO"
                                                                  , "INSP_DESC"

                                                                  , "ORD_SEQ"
                                                                  , "UPDATE_ID"
                                                                );

                    DataSet sourceDel = null;
                    sourceDel = this.grd02.GetValue(AxFlexGrid.FActionType.Remove
                                                                  , "CORCD"
                                                                  , "BIZCD"

                                                                  , "PARTNO"
                                                                  , "ORD_SEQ"
                                                                );
                    if (sourceDel.Tables[0].Rows.Count > 0)
                    {
                        _WSCOM.ExecuteNonQueryTx("APG_PD20060.DELETE_DATA", sourceDel);
                    }

                    SetImgDic();
                    if (sourceIU.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow rows in sourceIU.Tables[0].Rows)
                        {
                            rows["CORCD"] = cbo01_CORCD.GetValue().ToString();
                            rows["BIZCD"] = cbo01_BIZCD.GetValue().ToString();
                            rows["UPDATE_ID"] = UserInfo.UserID;


                            source.Tables[0].ImportRow(rows);
                            string key = rows["PARTNO"].ToString() + rows["ORD_SEQ"].ToString();
                            if (m_Imgs.Count > 0 && m_Imgs.ContainsKey(key))
                            {
                                source.Tables[0].Rows[source.Tables[0].Rows.Count - 1]["$IMG"] = m_Imgs[key];
                            }
                        }

                        if (!IsSaveValid(sourceIU)) return;

                        this.BeforeInvokeServer(true);

                        _WSCOM.ExecuteNonQueryTx("APG_PD20060.SAVE", source);
                        m_Imgs = new Dictionary<string, byte[]>();
                        this.AfterInvokeServer();
                    }

                    LoadDET();

                    //저장되었습니다.
                    MsgCodeBox.Show("CD00-0071");
                }
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
        #region [유효성 검사]

        private bool IsSaveValid(DataSet source)
        {
            try
            {
                if (source.Tables[0].Rows.Count == 0)
                {
                    //저장할 데이터가 존재하지 않습니다.
                    MsgCodeBox.Show("CD00-0042");
                    return false;
                }
                for (int row = 0; row < source.Tables[0].Rows.Count;row++)
                {
                    if(string.IsNullOrEmpty(source.Tables[0].Rows[row]["PARTNO"].ToString()))
                    {
                        MsgBox.Show("No Part number selection!!", "Error");
                        return false;
                    }
                }
                

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
                    //저장할 데이터가 존재하지 않습니다..
                    MsgCodeBox.Show("CD00-0041");
                    return false;
                }


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
        private void LoadDET()
        {
            try
            {
                pictureBox1.Image = null;
                int row = grd01.Row;
                if (row >= this.grd01.Rows.Fixed)
                {

                    string bizcd = grd01.GetValue(row, "BIZCD").ToString();
                    string corcd = grd01.GetValue(row, "CORCD").ToString();
                    string partno = grd01.GetValue(row, "PARTNO").ToString();
                    label2.Text = partno;
                    HEParameterSet set = new HEParameterSet();
                    DataSet source = null;
                    set.Add("CORCD", corcd);
                    set.Add("BIZCD", bizcd);
                    set.Add("PARTNO", partno);


                    source = _WSCOM.ExecuteDataSet("APG_PD20060.INQUERY_DET", set, "OUT_CURSOR");

                    this.grd02.SetValue(source.Tables[0]);
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
            finally
            {
            }
        }
        private void grd01_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            LoadDET();
        }
        private bool ExistORD(int cop, string ord)
        {
            for(int row=grd02.Rows.Fixed;row<grd02.Rows.Count;row++)
            {
                if (cop != row)
                {
                    if (grd02.GetValue(row, "ORD_SEQ").ToString() == ord)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        private Image GetByteImg(byte[] by)
        {
            try
            {
                MemoryStream ms = new MemoryStream(by, 0, by.Length);
                ms.Write(by, 0, by.Length);
                return Image.FromStream(ms,true);
            }
                catch{}
                return null;
        }
        private void grd02_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FileStream oFile = null;
            try
            {

                
                int row = grd02.Row;
                int col = grd02.Col;
                if (grd02.Cols[col].Name == "IMG_VIEW")
                {
                    pictureBox1.Image = null;
                    object objIMG = grd02.GetValue(row, "IMG");
                    if (objIMG != DBNull.Value)
                    {
                        byte[] by = (byte[])objIMG;
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                        if(by !=null)
                        { 
                            pictureBox1.Image = GetByteImg(by);
                        }
                    }
                    
                }
                if (grd02.Cols[col].Name == "IMG_ICON")
                {
                    string ord = grd02.GetValue(row, "ORD_SEQ").ToString();
                    string part = label2.Text;
                    if (string.IsNullOrEmpty(ord))
                    {
                        MsgBox.Show("D/SEQ is mandatory", "Error");
                        return;
                    }
                    if (ExistORD(row, ord))
                    {
                        MsgBox.Show("D/SEQ needs to be unique", "Error");
                        return;
                    }
                    if (string.IsNullOrEmpty(part))
                    {
                        MsgBox.Show("Part number is not selected", "Error");
                        return;
                    }
                    if (row >= this.grd02.Rows.Fixed)
                    {
                        

                        OpenFileDialog ofd = new OpenFileDialog();

                        //파일 선택 필터
                        ofd.Title = this.GetLabel("ATTACH_PDF"); //(작업 표준서) PDF 파일 선택
                        ofd.Filter = FileFilter.imageString;
                        ofd.FilterIndex = 0;

                        //파일 선택 되면
                        if (ofd.ShowDialog(this) == DialogResult.OK)
                        {
                            //PDF 파일을 읽어서 Grid 등록 처리함
                            oFile = File.Open(ofd.FileName, FileMode.Open, FileAccess.Read);

                            byte[] cFileBuf = new byte[oFile.Length];

                            oFile.Read(cFileBuf, 0, Convert.ToInt32(oFile.Length));
                            if (m_Imgs.ContainsKey(part+ord) == false)
                            {
                                m_Imgs.Add(part + ord, cFileBuf);
                            }
                            else
                            {
                                m_Imgs[part + ord] = cFileBuf;
                            }
                            grd02.SetValue(row, "PARTNO", grd01.GetValue(grd01.Row, "PARTNO").ToString());
                            oFile.Close();
                        }
                        grd02.SetValue(row, 0, "U");
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(label2.Text))
            {
                MsgBox.Show("Part number is not selected", "Error");
                return;
            }
            if (textBox1.Text.Trim().Length<5)
            {
                MsgBox.Show("No inputed Part number", "Error");
                return;
            }
            if(MsgBox.Show("Do you want to copy '" + label2.Text +"' data into '"+textBox1.Text+"'?", "Question", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                HEParameterSet set1 = new HEParameterSet();
                set1.Add("CORCD", cbo01_CORCD.GetValue());
                set1.Add("BIZCD", cbo01_BIZCD.GetValue());
                set1.Add("PARTNO", label2.Text);
                set1.Add("CP_PARTNO", textBox1.Text);
                _WSCOM.ExecuteNonQueryTx("APG_PD20060.SAVE_COPY", set1);
                textBox1.Text = "";
            }
        }


        


    }
}
