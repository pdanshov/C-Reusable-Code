using System;
using System.Collections.Generic;
using System.Text;
using TRAVERSE.Client;

namespace CSI.AAWSctb.Client.WebContribImp
{
    public class WebContribImpPlugin : PluginBase
    {
        public WebContribImpPlugin()
            : base()
        {
        }

        public override void Initialize()
        {
            this.MainInterface = new WebContribImpControl();
        }
       

        public override string Description
        {
            get
            {
                return "Import Web Contributions";
            }
            protected set
            {
                base.Description = value;
            }
        }
    }
}


