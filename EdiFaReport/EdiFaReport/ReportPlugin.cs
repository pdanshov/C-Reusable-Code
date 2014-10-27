using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TRAVERSE.Client;

namespace CSI.EDI.FaReport
{
    public class ReportPlugin : PluginBase
    {
        public override void Initialize()
        {
            this.MainInterface = new CustomEdiFaRptControl();

        }
        public override string Description
        {
            get
            {
                return "EDI FA Report";
            }
            protected set
            {
                base.Description = value;
            }
        }
    }
}