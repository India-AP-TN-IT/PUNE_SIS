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
using System.Drawing;
using System.IO;

namespace Ax.SIS.TM.UI
{
    /// <summary>
    /// 수지 Grade 관리
    /// </summary>
    public partial class TM23000 : AxCommonBaseControl
    {
        //private IPD40520 _WSCOM;
        private AxClientProxy _DB;

        #region [ 초기화 작업 정의 ]

        public TM23000()
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

                

                this.grd01.AllowEditing = true;
                this.grd01.Initialize();
                this.grd01.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictAll;

                //PARTNO	PARTNM	SPEC	IMG	MAKER	WHEREUSED	RACK	LOC	UOM	MIN	MAX	GRADE


                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 80, "CORCD", "CORCD", "CORCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 80, "BIZCD", "BIZCD", "BIZCD");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 200, "Part No.", "PARTNO", "PARTNO");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 200, "Part Name", "PARTNM", "PARTNM");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 250, "Specification", "SPEC", "SPEC");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 60, "Image", "IMG_YN", "IMG_YN");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 150, "MAKER", "MAKER", "MAKER");

                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 210, "Where Used", "WHEREUSED", "WHEREUSED");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 50, "Unit", "UOM", "UOM");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 90, "MIN", "MIN_QY", "MIN_QY");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 90, "MAX", "MAX_QY", "MAX_QY");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 90, "GRADE", "GRADE", "GRADE");
                
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 80, "UPDATE_ID", "UPDATE_ID", "UPDATE_ID");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 80, "UPDATE_DATE", "UPDATE_DATE", "UPDATE_DATE");


            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion
        private Image ConvertByteToImg(byte[] byteArray)
        {
            System.IO.MemoryStream stream = new System.IO.MemoryStream(byteArray);
            return Image.FromStream(stream);
        }
        private Image GetImg(string partno)
        {
            Image img = null;
            try
            {
                img = ConvertByteToImg(GetByte(partno));
                return img;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }

            return null;
        }

        private byte[] GetByte(string partno)
        {
            byte[] file = null;
            try
            {
                HEParameterSet param = new HEParameterSet();

                param.Add("CORCD", cbo01_CORCD.GetValue());
                param.Add("BIZCD", cbo01_BIZCD.GetValue());
                param.Add("PARTNO", partno); ;
                DataSet ds = _DB.ExecuteDataSet("APG_TM23000.INQUERY_IMG", param);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {

                    file = (byte[])ds.Tables[0].Rows[0]["IMG"];
                    

                }
                return file;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }

            return null;
        }
        private byte[] GetStream(string path)
        {
            if(string.IsNullOrEmpty(path) || path =="O" || path == "X")
            {
                return null;
            }
            System.IO.FileStream oFile = System.IO.File.Open(path, System.IO.FileMode.Open, System.IO.FileAccess.Read);

            byte[] cFileBuf = new byte[oFile.Length];

            oFile.Read(cFileBuf, 0, Convert.ToInt32(oFile.Length));

            oFile.Close();
            return cFileBuf;
        }

        #region [ 공통 버튼에 대한 이벤트 정의 ]
        protected override void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt= grd01.GetValue
                        (AxFlexGrid.FActionType.Save
                                , "CORCD"
                                ,"BIZCD"
                                ,"PARTNO"
                                ,"PARTNM"
                                ,"SPEC"
                                ,"IMG_YN"
                                ,"MAKER"
                                ,"WHEREUSED"
                                ,"RACK"
                                ,"LOC"
                                ,"UOM"
                                ,"MIN_QY"
                                ,"MAX_QY"
                                ,"GRADE"
                                ,"UPDATE_ID"
                        ).Tables[0];

                DataSet source = this.GetDataSourceSchema("CORCD"
                                , "BIZCD"
                                , "PARTNO"
                                , "PARTNM"
                                , "SPEC"
                                , "BLOB$IMG"
                                , "MAKER"
                                , "WHEREUSED"
                                , "RACK"
                                , "LOC"
                                , "UOM"
                                , "MIN_QY"
                                , "MAX_QY"
                                , "GRADE"
                                , "UPDATE_ID");

                DataSet ds_del = grd01.GetValue(AxFlexGrid.FActionType.Remove, "CORCD", "BIZCD", "PARTNO");
                if (ds_del.Tables.Count > 0 && ds_del.Tables[0].Rows.Count > 0)
                {
                    _DB.ExecuteNonQueryTx("APG_TM23000.DEL_DATA", ds_del);
                }
                for (int row = 0; row < dt.Rows.Count; row++)
                {
                    source.Tables[0].Rows.Add();
                    source.Tables[0].Rows[row]["CORCD"] = cbo01_CORCD.GetValue().ToString();
                    source.Tables[0].Rows[row]["BIZCD"] = cbo01_BIZCD.GetValue().ToString();
                    source.Tables[0].Rows[row]["PARTNO"] = dt.Rows[row]["PARTNO"].ToString();
                    source.Tables[0].Rows[row]["PARTNM"] = dt.Rows[row]["PARTNM"].ToString();
                    source.Tables[0].Rows[row]["SPEC"] = dt.Rows[row]["SPEC"].ToString();
                    string path = dt.Rows[row]["IMG_YN"].ToString();
                    if (path == "O")
                    {
                        source.Tables[0].Rows[row]["$IMG"] = GetByte(dt.Rows[row]["PARTNO"].ToString());
                    }
                    else
                    {
                        source.Tables[0].Rows[row]["$IMG"] = GetStream(path);
                    }
                    source.Tables[0].Rows[row]["MAKER"] = dt.Rows[row]["MAKER"].ToString();
                    source.Tables[0].Rows[row]["WHEREUSED"] = dt.Rows[row]["WHEREUSED"].ToString();
                    source.Tables[0].Rows[row]["RACK"] = dt.Rows[row]["RACK"].ToString();
                    source.Tables[0].Rows[row]["LOC"] = dt.Rows[row]["LOC"].ToString();
                    source.Tables[0].Rows[row]["UOM"] = dt.Rows[row]["UOM"].ToString();
                    source.Tables[0].Rows[row]["MIN_QY"] = dt.Rows[row]["MIN_QY"].ToString();
                    source.Tables[0].Rows[row]["MAX_QY"] = dt.Rows[row]["MAX_QY"].ToString();
                    source.Tables[0].Rows[row]["GRADE"] = dt.Rows[row]["GRADE"].ToString();
                    source.Tables[0].Rows[row]["UPDATE_ID"] = UserInfo.UserID;
                }

                if (source.Tables[0].Rows.Count > 0)
                {

                    _DB.ExecuteNonQueryTx("APG_TM23000.SAVE", source);

                }
                BtnQuery_Click(null, null);
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
                param.Add("PARTNO", txt_GRP.GetValue());
                param.Add("PARTNM", txt_PID.GetValue());
                DataSet ds = _DB.ExecuteDataSet("APG_TM23000.INQUERY", param);

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

        private void grd01_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int row = grd01.Row;
            int col = grd01.Col;
            if (grd01.Cols[col].Name == "IMG_YN")
            {
                string img = grd01.GetValue(row, "IMG_YN").ToString();
                string partno = grd01.GetValue(row, "PARTNO").ToString();
                if (string.IsNullOrEmpty(img) || img == "X")
                {
                    OpenFileDialog ofd = new OpenFileDialog();

                    //파일 선택 필터
                    ofd.Title = "Image"; //(작업 표준서) PDF 파일 선택
                    ofd.FilterIndex = 0;
                    ofd.Filter = FileFilter.imageString;
                    //파일 선택 되면
                    if (ofd.ShowDialog(this) == DialogResult.OK)
                    {

                        grd01.SetValue(row, "IMG_YN", ofd.FileName);

                    }
                    grd01.SetValue(row, 0, "U");
                }
                else if(img == "O")
                {
                    pictureBox1.Visible = true;
                    pictureBox1.BringToFront();
                    pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
                    pictureBox1.BackgroundImage = GetImg(partno);
                }
                else
                {
                    
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
        }

        private void grd01_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
        }







    }
}

