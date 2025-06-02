using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HE.Framework.ServiceModel;
using HE.Framework.Core;
using System.Data;
using System.Reflection;
using System.IO;
using HE.Framework.WindowForms.Menu;
namespace Ax.DEV.Utility.Library
{

    public interface IMenuHelper
    {
        event EventHandler UI_Ready;
        void extraSearch(HEParameterSet param);
    }


    public class MenuHelper
    {
        private HEParameterSet extraParam;

        public MenuHelper(HEParameterSet param)
        {
            extraParam = param;
        }
        /// <summary>
        /// 특정 화면을 메뉴open하고 오픈된 화면 컨트롤과 이미 열려있었는지 여부를 반환한다.
        /// </summary>
        /// <param name="thisUI">업무화면(메뉴를 오픈하는 주체)</param>
        /// <param name="menuid">메뉴아이디(메뉴로 오픈되는 화면의 아이디)</param>
        /// <returns>UIControl : 열리는 화면의 control 객체, IsExists : 이미 열려있었는지 여부</returns>
        public static MenuInfo OpenMenu(AxCommonBaseControl thisUI, string menuid, HEParameterSet param)
        {
            MenuInfo mi = new MenuInfo();
            mi.IsExists = false;    //기본값
            
            if (thisUI.ParentForm.GetType().Namespace.Equals("UI.TestContainer")) //개발런처의 경우
            {
                //개발 런처의 tab control 추출
                TabControl tc = (TabControl)thisUI.Parent.Parent; 
                
                //기존의 열려있는 화면인지 체크
                for (int i = 0; i < tc.TabPages.Count; i++)
                {
                    //열려 있는 화면이라면 해당 화면 활성화하고 종료.
                    if (tc.TabPages[i].Name.Equals(menuid))
                    {
                        mi.IsExists = true;

                        tc.SelectedTab = tc.TabPages[i];
                        mi.UIControl = tc.TabPages[i].Controls[0];
                        break;
                    }
                }

                //열려 있는 화면이 아니면 tabPage추가하여 해당 화면을 add한다.
                if (!mi.IsExists)
                {
                    //화면의 컨트롤 인스턴스(반환값)
                    Control target;             

                    TabPage tp = new TabPage(menuid);
                    tp.Name = menuid;                    
                    
                    //런처에서는 화면의 dll정보와 class 정보를 모르므로, XD1300의 메뉴데이터 가져와서 인스턴스 생성한다.
                    using (AxClientProxy proxy = new AxClientProxy())
                    {
                        HEParameterSet set = new HEParameterSet();
                        set.Add("LANGUAGE", StaticUserInfoContext.Language);
                        set.Add("SYSTEMCODE", StaticUserInfoContext.SystemCode);
                        DataSet source = proxy.ExecuteDataSet("APG_FXSERVICE.SELECTMENUINFO", set);

                        //넘어온 아이디의 메뉴 정보가 있는지?
                        DataRow[] drs = source.Tables[0].Select("MENUID='" + menuid + "'");

                        if (drs.Length > 0)
                        {
                            //MENUDLLURL에는 http://erm.hanileh.com/erm/smartclient/Ax.SIS.MM.dll  과 같이 경로정보까지 포함하고 있으므로, 파일명만 추출해야함.
                            string dllname = System.IO.Path.GetFileName(drs[0]["MENUDLLURL"].ToString());

                            //현재 실행중인 어셈블리의 절대경로 + 화면 dll 정보로 인스턴스 생성.
                            Assembly assembly = Assembly.LoadFile(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\" + dllname);
                            Type uitype = assembly.GetType(drs[0]["MENUCLASS"].ToString());                                                     
                            target = (Control) Activator.CreateInstance(uitype);

                            mi.UIControl = target;
                        }
                        else
                            return null;
                    }

                    target.Dock = DockStyle.Fill;
                    tp.Controls.Add(target);
                    tc.TabPages.Add(tp);
                    tc.SelectedTab = tp;

                }

            }
            else // 운영런처의 경우
            {
                //TheOne.UIModel.dll이 참조되어야 함.
                HEBasicMenuControl mc = thisUI.ParentForm.Controls[0] as HEBasicMenuControl;
                if (mc == null) return null;

                TheOne.UIModel.MenuItemInfo menuInfo = mc.MenuManager.Items[menuid];

                //운영런처의 tabControl은 C1DockingTab이며 Name 속성이 "tab01"임.
                Control[] tabControl = thisUI.ParentForm.Controls.Find("tab01", true); 
                C1.Win.C1Command.C1DockingTab tab = tabControl[0] as C1.Win.C1Command.C1DockingTab;

                //기존 존재하는 화면인지 체크
                if (tab.FindPage(string.Format("[{0}] {1}", menuid, menuInfo.DisplayTitle)) >= 0 || tab.FindPage(menuInfo.DisplayTitle) >= 0)
                    mi.IsExists = true;

                //화면 생성  or 해당화면 활성화
                mc.SelectMenuItem(menuInfo);    

                //운영런처 tabControl 구조
                //TabControl(tab01)
                //  └ TabPages
                //      └BottomPanel
                //          └ 화면UI
                //      └TopPanel
                //          └ 상단의 navi 정보
                mi.UIControl = tab.SelectedTab.Controls[0].Controls[0]; //화면UI를 리턴
            }

            MenuHelper mh = new MenuHelper(param);
            mh.SetMenuParm(mi);

            return mi;
        }

        private void SetMenuParm(MenuInfo mi)
        {            
 

            if (mi.IsExists)
            {
                IMenuHelper ui = mi.UIControl as IMenuHelper;
                if (ui != null) 
                    target_UI_Ready(mi.UIControl, null);  //이미 열려 있는 화면인 경우
            }
            else
            {
                IMenuHelper ui = mi.UIControl as IMenuHelper;
                if (ui != null)
                    ui.UI_Ready += new EventHandler(target_UI_Ready);    

            }
        }

        //※※※ 파라메터 전달 MENU 오픈 5 → 이벤트 핸들러 추가
        private void target_UI_Ready(object sender, EventArgs e)
        {
            IMenuHelper ui = sender as IMenuHelper;
            if (ui != null) ui.extraSearch(extraParam);
        }
        
    }

    /// <summary>
    /// 메뉴정보
    /// </summary>
    public class MenuInfo
    {
        private bool isexists;
        private Control uicontrol;

        /// <summary>
        /// 메뉴가 이미 open되었는지 여부
        /// </summary>
        public bool IsExists
        {
            get { return isexists; }
            set { isexists = value; }
        }

        /// <summary>
        /// 메뉴 open된 화면 control객체
        /// </summary>
        public Control UIControl
        {
            get { return uicontrol; }
            set { uicontrol = value; }
        }

    }
}
