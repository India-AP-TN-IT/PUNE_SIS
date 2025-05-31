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
using HE.Framework.Core.Report;
using System.IO;
using System.Collections.Generic;

namespace Ax.SIS.TM.UI
{
    /// <summary>
    /// 수지 Grade 관리
    /// </summary>
    public partial class TM21100 : AxCommonBaseControl
    {
        private string m_EQID = "";
        Dictionary<string, byte[]> m_Imgs = new Dictionary<string, byte[]>();
        //private IPD40520 _WSCOM;
        private AxClientProxy _DB;

        #region [ 초기화 작업 정의 ]

        public TM21100()
        {
            InitializeComponent();

            _DB = new AxClientProxy();
            
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                //CORCD
                cbo01_CORCD.DataBind_CORCD();
                cbo01_CORCD.SetValue(this.UserInfo.CorporationCode);
                cbo01_CORCD.SetReadOnly(true);
                //BIZCD
                cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode);
                cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                cbo01_BIZCD.SetReadOnly(this.UserInfo.IsAdmin.Equals("N"));
                cbo01_BIZCD.DropDownStyle = ComboBoxStyle.DropDownList;

                

                this.grd01.AllowEditing = false;
                this.grd01.Initialize();
                this.grd01.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictAll;

                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 80, "CORCD", "CORCD", "CORCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 80, "BIZCD", "BIZCD", "BIZCD");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 200, "TOOL No.", "EQNO", "EQNO");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 200, "TOOL Name", "EQNM", "EQNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "CERTIFICATE NUMBER", "LAST_CERT_NO", "LAST_CERT_NO");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 180, "Maker", "MAKER", "MAKER");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 250, "Capacity", "CAPA", "CAPA");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 180, "LEAST COUNT", "LCOUNT", "LCOUNT");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "Last C/DATE", "LAST_CALIB_DATE", "LAST_CALIB_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "Next C/DATE", "RE_CALIB_DATE", "RE_CALIB_DATE");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 80, "UPDATE_ID", "UPDATE_ID", "UPDATE_ID");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 80, "UPDATE_DATE", "UPDATE_DATE", "UPDATE_DATE");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "LAST_CALIB_DATE");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "RE_CALIB_DATE");

                this.grd02.AllowEditing = true;
                this.grd02.Initialize();
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 80, "CORCD", "CORCD", "CORCD");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 80, "BIZCD", "BIZCD", "BIZCD");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 200, "TOOL No.", "EQNO", "EQNO");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "CERT.DATE", "CDATE", "CDATE");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 200, "CERT.No.", "CID", "CID");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "UP", "DATA_UP", "DATA_UP");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "DOWN", "DATA_DOWN", "DATA_DOWN");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 80, "IMG_FILE_NM", "IMG_FILE_NM", "IMG_FILE_NM");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Date, "CDATE");
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
                DataSet source = this.GetDataSourceSchema("CORCD"
                                                                  , "BIZCD"

                                                                  , "EQNO"
                                                                  , "CDATE"
                                                                  , "CID"
                                                                  , "BLOB$IMG"
                                                                  , "IMG_FILE_NM"
                                                                  , "UPDATE_ID");
                DataTable dt = null;
                dt = this.grd02.GetValue(AxFlexGrid.FActionType.Save
                                                              , "CORCD"
                                                              , "BIZCD"
                                                              ,"CID"
                                                              , "EQNO"
                                                              , "CDATE"
                                                              , "DATA_VIEW"
                                                              , "IMG_FILE_NM"
                                                              ,"DATA_UP"
                                                            ).Tables[0];
                for(int row =0;row<dt.Rows.Count;row++)
                {
                    source.Tables[0].Rows.Add();
                    source.Tables[0].Rows[row]["CORCD"] = cbo01_CORCD.GetValue().ToString();
                    source.Tables[0].Rows[row]["BIZCD"] = cbo01_BIZCD.GetValue().ToString();
                    source.Tables[0].Rows[row]["CDATE"] = dt.Rows[row]["CDATE"].ToString();
                    source.Tables[0].Rows[row]["CID"] = dt.Rows[row]["CID"].ToString();
                    source.Tables[0].Rows[row]["EQNO"] = m_EQID;
                    source.Tables[0].Rows[row]["IMG_FILE_NM"] = dt.Rows[row]["IMG_FILE_NM"].ToString(); ;
                    //PDF 파일을 읽어서 Grid 등록 처리함
                    FileStream oFile = File.Open(dt.Rows[row]["DATA_UP"].ToString(), FileMode.Open, FileAccess.Read);

                    byte[] cFileBuf = new byte[oFile.Length];

                    oFile.Read(cFileBuf, 0, Convert.ToInt32(oFile.Length));

                    oFile.Close();



                    source.Tables[0].Rows[row]["$IMG"] = cFileBuf;
                    source.Tables[0].Rows[row]["UPDATE_ID"] = UserInfo.UserID;
                }
                _DB.ExecuteNonQueryTx("APG_TM21100.SAVE", source);
                BtnQuery_Click(null, null);


                HEParameterSet param = new HEParameterSet();

                param.Add("CORCD", cbo01_CORCD.GetValue());
                param.Add("BIZCD", cbo01_BIZCD.GetValue());
                param.Add("EQNO", m_EQID); ;
                DataSet ds = _DB.ExecuteDataSet("APG_TM21100.INQUERY", param);

                grd02.SetValue(ds);

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                
            }
            finally
            {
               
            }
        }
        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {

                HEParameterSet param = new HEParameterSet();

                param.Add("CORCD", cbo01_CORCD.GetValue());
                param.Add("BIZCD", cbo01_BIZCD.GetValue());
                param.Add("EQNO", txt_GRP.GetValue());
                param.Add("EQNM", txt_PID.GetValue());
                DataSet ds = _DB.ExecuteDataSet("APG_TM21000.INQUERY", param);

                grd01.SetValue(ds);

            }
            catch (FaultException<ExceptionDetail> ex)
            {
               
            }
            finally
            {
            }
        }
        
        #endregion

        private void grd02_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int row = grd02.Row;
            int col = grd02.Col;
            if (grd02.Cols[col].Name == "DATA_UP")
            {
                OpenFileDialog ofd = new OpenFileDialog();

                //파일 선택 필터
                ofd.Title = "CERTIFICATION"; //(작업 표준서) PDF 파일 선택
                ofd.FilterIndex = 0;

                //파일 선택 되면
                if (ofd.ShowDialog(this) == DialogResult.OK)
                {

                    grd02.SetValue(row, "DATA_UP", ofd.FileName);
                    grd02.SetValue(row, "IMG_FILE_NM", ofd.SafeFileName);
                    
                }
                grd02.SetValue(row, 0, "U");
            }
            else if (grd02.Cols[col].Name == "DATA_DOWN")
            {
                
                try
                {
                    HEParameterSet param = new HEParameterSet();

                    param.Add("CORCD", cbo01_CORCD.GetValue());
                    param.Add("BIZCD", cbo01_BIZCD.GetValue());
                    param.Add("EQNO", m_EQID); ;
                    param.Add("CID", grd02.GetValue(row, "CID"));
                    DataSet ds = _DB.ExecuteDataSet("APG_TM21100.INQUERY_DET", param);
                    if(ds.Tables.Count>0 && ds.Tables[0].Rows.Count>0)
                    {
                        SaveFileDialog sfd = new SaveFileDialog();

                        sfd.Title = "CERTIFICATION";
                        sfd.FilterIndex = 0;

                        sfd.FileName = ds.Tables[0].Rows[0]["CM_FILE"].ToString();
                      
                        if (sfd.ShowDialog() != DialogResult.OK) return;

                        string fileName = sfd.FileName;
                        byte[] file = (byte[])ds.Tables[0].Rows[0]["CM"];
                        int ArraySize = file.GetUpperBound(0);
                        FileStream stream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
                        stream.Write(file, 0, ArraySize + 1);
                        stream.Close();

                    }
                }
                catch (FaultException<ExceptionDetail> ex)
                {
                    MsgBox.Show(ex.ToString());
                }


            }
        }

        private void grd01_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int row = grd01.Row;
            if (row >= 1)
            {
                m_EQID = grd01.GetValue(row, "EQNO").ToString();


                HEParameterSet param = new HEParameterSet();

                param.Add("CORCD", cbo01_CORCD.GetValue());
                param.Add("BIZCD", cbo01_BIZCD.GetValue());
                param.Add("EQNO", m_EQID); ;
                DataSet ds = _DB.ExecuteDataSet("APG_TM21100.INQUERY", param);

                grd02.SetValue(ds);
            }
            else
            {
                grd02.SetValue(new DataSet());
            }
            
        }

    }
}

