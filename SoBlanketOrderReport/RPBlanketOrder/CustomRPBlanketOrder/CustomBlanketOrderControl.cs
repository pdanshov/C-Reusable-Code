using System;
using System.Collections.Generic;
using System.Text;
using TRAVERSE.Report.AccountsPayable;
using TRAVERSE.Report.SalesOrder;
using TRAVERSE.Business;
using TRAVERSE.Business.Batching;
using TRAVERSE.Business.AccountsPayable;
using TRAVERSE.Core;
using TRAVERSE.Client;
using TRAVERSE.Client.Report;
using System.Data;
using System.Windows.Forms;

namespace CSI.MT.CustomRPBlanketOrder
{
    public class CustomBlanketOrderControl : BlanketOrderControl
    {
        public CustomBlanketOrderControl()
            :base()
        {
        }
        public CustomBlanketOrderControl(IPlugin host)
        {
        }
        protected override void AssignReportPath()
        {
            //base.AssignParameters();

            string rptPath = TRAVERSE.Core.ApplicationContext.ReportPath;
            this.ReportDef.PathList.Add(rptPath + "\\SoBlanketOrder_CSI.rdl");//this.BuildReportPath(Resources.BlanketOrderFileName)
            this.ReportDef.PathList.Add(rptPath + "\\SoBlanketOrderDetail.rdl");//this.BuildReportPath(Resources.BlanketOrderDetailFileName)
            base.Landscape = true;
        }
        protected override void CreateDataGenerator()
        {
            this.DataGenerator = new CustomRPBlanketOrderData(this.CompId);
        }
    }
}
