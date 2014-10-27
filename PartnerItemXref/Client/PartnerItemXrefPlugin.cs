using System;
using System.Collections.Generic;
using System.Text;
using TRAVERSE.Client;


namespace CSI.EDI.Client.PartnerItemXref
{
    public class PartnerItemXrefPlugin : PluginBase
    {
        public PartnerItemXrefPlugin()
            : base()
        {
        }

        public override void Initialize()
        {
            this.MainInterface = new PartnerItemXrefControl();
        }


        public override string Description
        {
            get
            {
                return "Partner-Item Cross-Reference";
            }
            protected set
            {
                base.Description = value;
            }
        }
    }
}
