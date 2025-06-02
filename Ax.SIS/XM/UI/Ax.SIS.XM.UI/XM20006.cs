#region ▶ Description & History
/* 
 * 프로그램명 : 확정버튼권한설정
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2014-07-02      배명희      프로그램 아이디 변경(XM01200 -> XM20006)
 *                                          웹서비스 호출(DB) 로직 변경, 다국어 처리, 시스템코드 적용(콤보)
 *              2014-07-22      배명희     Ax.SIS.XM.IF 참조 제거
 *              2014-12-17      배명희     그리드 다국어 처리 방식 변경 (XD1410사용하지 않고 XD1420사용)
*/
#endregion
using System;
using System.Data;
using System.ServiceModel;
using System.Windows.Forms;
using Ax.DEV.Utility.Controls;
using Ax.DEV.Utility.Library;
using HE.Framework.Core;
using HE.Framework.ServiceModel;
using TheOne.Windows.Forms;

namespace Ax.SIS.XM.UI
{
    /// <summary>
	/// <b>확정버튼권한설정</b>
    /// - 작 성 자 : Neostyx<br />
    /// - 작 성 일 : 2010-06-01 오전 10:44:22<br />
    /// - 주요 변경 사항
    ///     1) 2010-06-01 오전 10:44:22   Neostyx : 최초 클래스 생성<br />
    /// </summary>
    public partial class XM20006 : AxCommonBaseControl
    {
		private DataTable _authTable;

        private AxClientProxy _WSCOM;
        private string PAKAGE_NAME = "APG_XM20006";
        private string PAKAGE_NAME_XM20001 = "APG_XM20001";

        public XM20006()
        {
            InitializeComponent();
            _WSCOM = new AxClientProxy();
        }

        #region [ 초기화 작업 정의 ]

        /// <summary>
        /// Shown 이벤트를 통해 초기화 작업을 수행한다.
        /// </summary>
        /// <param name="sender">객체</param>
        /// <param name="e">이벤트</param>
        protected override void UI_Shown(EventArgs e)
        {
            this.InitializeGridStyle();
            this.InitializeControlStyle();

			_authTable = new DataTable();

			BtnQuery_Click(null, null);
        }

        /// <summary>
        /// 그리드에 관련된 초기 설정을 수행한다.
        /// </summary>
        private void InitializeGridStyle()
        {
            this.grd01.AllowEditing = false;            
            this.grd01.Initialize(1, 1);
            this.grd01.AllowEditing = true;

            //this.grd01.Cols.RemoveRange(1, this.grd01.Cols.Count - 1);
            this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "_확장권한순번", "AUTHINDEX", "AUTHINDEX");
            this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "_System", "SYSTEMCODE", "SYSTEMCODE");
            this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 100, "_확장권한명", "AUTHNAME", "AUTHNAME");
            this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 300, "_DESCRIPTION", "DESCRIPTION", "DESCRIPTION");
            this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "_적용유무", "USE_YN", "USE_YN");
            this.grd01.SetColumnType(AxFlexGrid.FCellType.Check, "USE_YN");            
        }

        /// <summary>
        /// 그리드를 제외한 다른 컨트롤에 관련된 초기 설정을 수행한다.
        /// </summary>
        private void InitializeControlStyle()
        {
            DataTable dtSystemCode = this.getSystemCode();
            this.cbo00_SYSTEMCODE.DataBind(dtSystemCode, false);
            this.cbo00_SYSTEMCODE.SetValue(this.UserInfo.SystemCode);

        }

        #endregion

        #region [ 공통 버튼에 대한 이벤트 정의 ]

        protected override void BtnSave_Click(object sender, EventArgs e)
        {         
			try
			{
                DataSet source = this.grd01.GetValue(AxFlexGrid.FActionType.Save,
                               "SYSTEMCODE", "AUTHINDEX", "AUTHNAME", "DESCRIPTION", "USE_YN");

                // 유효성 검사
                if (!IsSaveValidation(source.Tables[0]))
                {
                    return;
                }

                foreach (DataRow dr in source.Tables[0].Rows)
                {
                    dr["USE_YN"] = dr["USE_YN"].ToString().Equals("Y") ? "1" : "0";
                }

                 //확장권한 정보를 저장하시겠습니까?
                if (MsgCodeBox.Show("XM00-0038",
                   MessageBoxButtons.OKCancel) != DialogResult.OK) return;

				this.BeforeInvokeServer(true);

                _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "SAVE"), source);

                this.AfterInvokeServer();

                // XM00-0018 : 정상적으로 처리되었습니다.
                MsgCodeBox.Show("XM00-0018");

                // 재조회
                BtnQuery_Click(null, null);
			}
			catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();

				// XM00-0019 : 다음과 같은 오류가 발생하였습니다.\r\n{0}
				MsgCodeBox.ShowFormat("XM00-0019", MessageBoxButtons.OK, ImageKinds.Error, ex.ToString());
			}
			finally
			{
				this.AfterInvokeServer();
			}
        }

        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
			HEParameterSet paramSet = new HEParameterSet();
			paramSet["SYSTEMCODE"] = this.cbo00_SYSTEMCODE.GetValue();

			try
			{
				this.BeforeInvokeServer(true);

				//_authTable = proxy.GetExtensionAuthList(paramSet).Tables[0];
                _authTable = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_EXTENSION_AUTH"), paramSet).Tables[0];
				CreateDataRow();

				//this.grd01.x_DataBind(_authTable.DefaultView, false);
                this.grd01.SetValue(_authTable);

            }
			catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();

				// XM00-0019 : 다음과 같은 오류가 발생하였습니다.\r\n{0}
				MsgCodeBox.ShowFormat("XM00-0019", MessageBoxButtons.OK, ImageKinds.Error, ex.ToString());
			}
			finally
			{
				this.AfterInvokeServer();
			}
        }	

        #endregion

		#region [ ETC METHODS ]
        //시스템코드 콤보상자용 데이터 조회
        private DataTable getSystemCode()
        {
            try
            {
                HEParameterSet set = new HEParameterSet();

                DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_XM20001, "INQUERY_SYSTEMCODE"), set);

                return source.Tables[0];
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }

            return null;
        }

		/// <summary>
		/// 확장 권한 정보를 만드는 메서드
		/// </summary>
		private void CreateDataRow()
		{
			// 확장 권한은 총 32가지이므로, 이만큼의 행을 미리 생성해준다.
			int nowAuthCnt = _authTable.Rows.Count;
			int needAuthCnt = 32 - nowAuthCnt;
			int lastAuthNo = (_authTable.Rows.Count > 0)
				? int.Parse(_authTable.Rows[_authTable.Rows.Count - 1]["AUTHINDEX"].ToString()) + 1 : 1;
			DataRow drNew = null;

			for (int i = 1; i <= needAuthCnt; i++)
			{
				drNew = _authTable.NewRow();
				drNew["AUTHINDEX"] = lastAuthNo.ToString();
				drNew["SYSTEMCODE"] = this.cbo00_SYSTEMCODE.GetValue();
				drNew["USE_YN"] = false;
				_authTable.Rows.Add(drNew);
				drNew = null;

				lastAuthNo++;
			}

			_authTable.AcceptChanges();
		}

		/// <summary>
		/// 저장 버튼을 클릭할 경우의 유효성 검사 메서드
		/// </summary>
		/// <returns></returns>
		private bool IsSaveValidation(DataTable source)
		{
			bool bValidate = true;

            if (source.Rows.Count <= 0)
            {
                MsgCodeBox.Show("XM00-0024");//저장할 데이터가 없습니다.");
                bValidate = false;
                return bValidate;
            }

            foreach (DataRow row in source.Rows)
			{
				// 빈 값이 있는지의 여부를 체크
				if ((string.Compare(row["USE_YN"].ToString(), "1", true) == 0) && 
					(string.IsNullOrEmpty(row["AUTHNAME"].ToString())))
				{
					// FX00-0021 : 확장 권한명이 입력되지 않은 행이 있습니다.
                    MsgCodeBox.Show("XM00-0039");
					bValidate = false;
					break;
				}

				if (!bValidate)
				{
					// 중복되는 확장 권한명이 있는지의 여부 체크
                    DataRow[] selectedRows = source.Select("AUTHNAME=" + row["AUTHNAME"].ToString());

					// 중복되는 그룹 ID가 2개 이상 있으면
					if (selectedRows.Length > 1)
					{
						// FX00-0022 : 중복되는 확장 권한명 {0}이(가) 2개 이상 있습니다.
                        MsgCodeBox.ShowFormat("XM00-0040", row["AUTHNAME"].ToString());
						bValidate = false;
						break;
					}
				}
			}

			return bValidate;
		}

		#endregion
	}
}
