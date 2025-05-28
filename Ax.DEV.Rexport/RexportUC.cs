using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ax.DEV.Rexport
{
    [ToolboxBitmap(typeof(Button))]
    public partial class RexportUC : UserControl
    {
        public RexportUC()
        {
            InitializeComponent();
        }
        public void PrintAsPDF(string dataSetXMLPath, string rebPath, string saveAsPath)
        {
            rebPath = rebPath.Replace("\\", "/");
            dataSetXMLPath = dataSetXMLPath.Replace("\\", "/");
            string OOF = @"<?xml version='1.0' encoding='utf-8'?>
                            <oof version ='3.0'>
                              <document title='report' enable-thread='0'>
                                <file-list>
                                  <file type='reb' path='{0}'>
                                    <config-param-list></config-param-list>
                                  </file>
                                </file-list>

                                <connection-list>
                                  <connection type='file' namespace='XML'>
                                    <config-param-list>
                                      <config-param name='connection.once'>1</config-param>
                                      <config-param name='path'>{1}</config-param>
                                    </config-param-list>
                                    <content content-type='xml'>
                                      <content-param name='root'>{%dataset.xml.root%}</content-param>
                                      <content-param name='preservedwhitespace'>1</content-param>
                                      <content-param name='bindmode'>name</content-param>
                                    </content>
                                  </connection>
                                </connection-list>
                                <plugin-list></plugin-list>
                              </document>
                            </oof>
                            ";
            OOF = OOF.Replace("{0}", rebPath).Replace("{1}", dataSetXMLPath);
            object dd = axRexViewerCtrl301.OpenOOF(OOF);
            axRexViewerCtrl301.Export(false, "pdf", saveAsPath, 1, -1, "");
        }

    }
}
