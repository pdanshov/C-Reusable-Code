using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TRAVERSE.Client;

namespace CSI.AAWS.ArCtbQuarterlyRpt
{
    public class ArCtbQrtRptPlugin : PluginBase
    {
        public override void Initialize()
        {
            this.MainInterface = new CtbQrtRptControl(this);

        }
        public override string Description
        {
            get
            {
                return "CTB quarterly reports";
            }
            protected set
            {
                base.Description = value;
            }
        }
    }
}
