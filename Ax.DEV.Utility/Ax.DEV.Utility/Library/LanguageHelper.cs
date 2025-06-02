using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using C1.Win.C1FlexGrid;
using HE.Framework.Core;
using HE.Framework.ServiceModel;
using HE.ComponentOne;
using System.Globalization;
using System.Drawing;
using C1.Win.C1Input;

namespace Ax.DEV.Utility.Library
{
    public static class LanguageHelper
    {
        /// <summary>
        /// 다국어 관련 데이터 가져오는 메서드
        /// </summary>
        /// <param name="menuId"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        public static DataSet GetUIData(string menuId, string language)
        {
            HEParameterSet paramSet = new HEParameterSet();
            paramSet.Add("MENUID", menuId);
            paramSet.Add("LANGUAGE", (string.IsNullOrEmpty(language)) ? "KO" : language);
            
            //여러 시스템을 사용할 경우 필요
            //paramSet.Add("SYSTEMCODE", "ERM");

            //DB에 다국어 정보를 가져온다
            AxClientProxy proxy = new AxClientProxy();
            using (proxy as IDisposable)
            {
                string[] procedureNames = new string[3];                
                procedureNames[0] = "APG_FXSERVICE.SELECTLABLEINFO";
                procedureNames[1] = "APG_FXSERVICE.SELECTGRIDINFO";
                procedureNames[2] = "APG_FXSERVICE.SELECTGRIDHEADERCOUNTINFO";

                DataSet source = proxy.MultipleExecuteDataSet(procedureNames, paramSet);

                return source;
            }
        }

        /// <summary>
        /// C1 관련 컨트롤들을 찾는 메서드
        /// </summary>
        /// <param name="ctrls">UI Controls</param>
        /// <param name="dtLanInfo">다국어 명칭</param>
        /// <param name="dtGridInfo">Grid 컬럼 정보</param>
        /// <param name="dtGridHeaderInfo">Grid 헤더 정보</param>
        public static void InitializeC1Control(System.Windows.Forms.Control.ControlCollection ctrls,
            DataTable dtLanInfo, DataTable dtGridInfo, DataTable dtGridHeaderInfo)
        {
            foreach (Control ctrl in ctrls)
            {
                string findCodeName = string.Empty;
                string codeName = string.Empty;
                string ctrlName = (ctrl.GetType()).Name.ToUpper();

                //한일이화 Naming rule 컨트롤약어_명칭
                int pos = 0;
                if (ctrl.Name.IndexOf('_') > 0 )
                    pos = ctrl.Name.IndexOf('_') + 1;

                //로직 체크필요
                switch (ctrlName)
                {
                    case "C1FLEXGRID":
                    case "AXFLEXGRID":
                        InitialzeGridField(ctrl as C1FlexGrid, dtGridInfo, dtGridHeaderInfo);
                        break;
                    case "C1LABEL":
                    case "AXLABEL":
                    case "C1BUTTON":
                    case "AXBUTTON":
                    case "LABEL":
                    case "BUTTON":
                    case "CHECKBOX":
                    case "AXCHECKBOX":
                    case "AXRADIOBUTTON":
                    case "RADIOBUTTON":
                    case "GROUPBOX":
                    case "AXGROUPBOX":
                    case "TABPAGE":
                        if (!string.IsNullOrEmpty(ctrl.Name))
                        {
                            if (pos > 0)
                            {
                                findCodeName = ctrl.Name.Substring(pos);
                                codeName = GetCodeName(dtLanInfo, findCodeName);

                                if (!string.IsNullOrEmpty(codeName))
                                {
                                    if (ctrl is C1Label)
                                    {
                                        (ctrl as C1Label).Value =  codeName;
                                    }
                                    else
                                    {
                                        ctrl.Text = codeName;
                                    }
                                }                                
                            }
                        }
                        break;
                    default:
                        break;
                }
                if (ctrl.HasChildren)
                {
                    InitializeC1Control(ctrl.Controls, dtLanInfo, dtGridInfo, dtGridHeaderInfo);
                }
            }
        }

        /// <summary>
        /// 다국어 언어 테이블에서 특정 코드를 찾을 때 사용하는 메서드
        /// </summary>
        /// <param name="dtLanInfo"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        private static string GetCodeName(DataTable dtLanInfo, string code)
        {
            string codename = string.Empty;

            if (dtLanInfo != null)
            {
                DataRow[] findRows = dtLanInfo.Select("CODE= '" + code + "'");

                if (findRows.Length > 0)
                {
                    codename = findRows[0]["CODENAME"].ToString();
                }
            }

            return codename;
        }

        /// <summary>
        /// 그리드 관련 설정 작업(DB 메타 정보를 이용하여 그리드 생성)
        /// </summary>
        /// <param name="ctrl">C1FlexGrid 컨트롤</param>
        /// <param name="dtGridInfo"></param>
        /// <param name="dtGridHeaderInfo"></param>
        /// <remarks>
        /// 이 컨트롤 관련 DataRow[] 집합을 매개변수로 사용해야 함
        /// DataRow[] 집합을 찾는 경우에는 그리드명을 사용하여 찾음
        /// </remarks>
        private static void InitialzeGridField(C1FlexGrid ctrl, DataTable dtGridInfo, DataTable dtGridHeaderInfo)
        {
            //그리드 컬럼 셋팅
            if (dtGridInfo == null || dtGridInfo.Rows.Count <= 0)
            {
                return;
            }

            if (dtGridHeaderInfo == null || dtGridHeaderInfo.Rows.Count <= 0)
            {
                return;
            }

            string gridName = (ctrl as C1FlexGrid).Name.ToUpper();

            //그리드의 헤더 개수를 확인한다.
            DataRow[] headerRows = dtGridHeaderInfo.Select("GRIDNAME = '" + gridName + "'");

            int headerCount = 1;

            if (headerRows.Length == 1)
            {
                headerCount = int.Parse(headerRows[0]["HEADERCOUNT"].ToString());
            }

            //헤더의 개수가 0이면 로직을중단한다.
            if (headerCount == 0)
            {
                return;
            }

            //정렬은 DB쿼리에서 했기 때문에 하지 않는다.
            DataRow[] gridRows = dtGridInfo.Select("GRIDNAME = '" + gridName + "'");
 
            //값이 없는 경우, 로직을 중단한다.
            if (gridRows.Length == 0)
            {
                return;
            }

            ctrl.AutoGenerateColumns = false;
            ctrl.AllowMerging = AllowMergingEnum.FixedOnly;

            //고정값 할당
            ctrl.Rows.Fixed = headerCount;
            ctrl.Cols.Count = gridRows.Length + 1;
            ctrl.Cols.Fixed = 1;

            int[] mergeCols = HE.DevHelper.UtilHelper.MakeIntArray(ctrl.Cols.Count);
            int[] mergeRows = HE.DevHelper.UtilHelper.MakeIntArray(ctrl.Rows.Fixed);

            if (headerCount > 1)
            {
                ctrl.x_AllowMerging(mergeCols, mergeRows, true);
            }

            int iFormatInfo = 0;

            //헤더구성
            for (int i = 1; i <= headerCount; i++)
            {
                //?용도?
                iFormatInfo = (headerCount == 1) ? i + 2 : (headerCount == 2) ? i + 1 : i;

                string headerCode = string.Format("HEADERCODE{0}", iFormatInfo.ToString());
                string headerCodeName = string.Format("HEADERCODE{0}NAME", iFormatInfo.ToString());
                ctrl[i - 1, 0] = " ";

                //헤더 WordWrap 설정
                ctrl.Rows[i - 1].StyleDisplay.WordWrap = true;

                for (int j = 1; j <= gridRows.Length; j++)
                {
                    DataRow row = gridRows[j - 1];

                    //병합을 위해 헤더부분만을 설정한다.
                    ctrl[i - 1, j] = row[headerCodeName];
                    
                    //실제 필드 설정 부분
                    //컬럼의 데이터 필드명
                    ctrl.Cols[j].Name = row[headerCode].ToString();

                    //컬럼의 넓이
                    ctrl.Cols[j].Width = int.Parse(row["COLUMNWIDTH"].ToString());
                    //컬럼 정렬
                    string columnAlign = row["COLUMNALIGN"].ToString();
                    //데이터 타입
                    ctrl.Cols[j].DataType = Type.GetType(row["DATATYPE"].ToString());
                    ctrl.Cols[j].TextAlign =
                        (string.Compare(columnAlign, "L", true) == 0) ? TextAlignEnum.LeftCenter :
                        (string.Compare(columnAlign, "R", true) == 0) ? TextAlignEnum.RightCenter :
                        TextAlignEnum.CenterCenter;

                    //컬럼 헤더 정렬은 CenterCenter로 고정
                    ctrl.Cols[j].TextAlignFixed = TextAlignEnum.CenterCenter;
                    //숨김 여부
                    ctrl.Cols[j].Visible = (string.Compare(row["HIDDEN"].ToString(), "1", true) == 0) ? false : true;

                    //포맷 여부
                    if (!string.IsNullOrEmpty(row["FORMAT"].ToString()))
                    {
                        ctrl.Cols[j].Format = row["FORMAT"].ToString();
                    }

                    //고정 컬럼 여부
                    if (string.Compare(row["FROZENCOLUMN"].ToString(), "1", true) == 0)
                    {
                        ctrl.Cols.Frozen = j;
                    }

                    //활성화 여부
                    if (string.Compare(row["ENABLED"].ToString(), "1", true) == 0)
                    {
                        ctrl.Cols[j].AllowEditing = false;
                    }
                    else
                    {
                        ctrl.Cols[j].AllowEditing = true;
                    }

                    //색 적용 여부
                    if (!string.IsNullOrEmpty(row["COLOR"].ToString()))
                    {
                        ctrl.Cols[j].StyleNew.BackColor = HexToColor(row["COLOR"].ToString());
                    }

                    //if (ctrl is Ax.SIS.Utility.Controls.HEFlexGrid)
                    //    (ctrl as Ax.SIS.Utility.Controls.HEFlexGrid).AddGridColumns(j, row[headerCode].ToString());
                }
            }

            if (ctrl.Cols.DefaultSize == 0)
            {
                ctrl.Cols.DefaultSize = 120;
            }

        }

        private static Color HexToColor(string colorValue)
        {
            int red = int.Parse(colorValue.Substring(0, 2), NumberStyles.AllowHexSpecifier);
            int green = int.Parse(colorValue.Substring(2, 2), NumberStyles.AllowHexSpecifier);
            int blue = int.Parse(colorValue.Substring(4, 2), NumberStyles.AllowHexSpecifier);

            return Color.FromArgb(red, green, blue);            
        }

        /// <summary>
        /// 다국어 언어 테이블에서 특정 코드를 찾을 때 사용하는 메서드
        /// </summary>
        /// <param name="findKey"></param>
        /// <returns></returns>
        public static string GetLabel(DataTable dtLanInfo, string findKey)
        {
            string lanInfo = string.Empty;

            if (dtLanInfo != null && dtLanInfo.Rows.Count > 0)
            {
                DataRow[] findRows = dtLanInfo.Select("CODE= '" + findKey + "'");

                if (findRows.Length == 1)
                {
                    lanInfo = findRows[0]["CODENAME"].ToString();
                }
            }

            return lanInfo;
        }

    }
}
