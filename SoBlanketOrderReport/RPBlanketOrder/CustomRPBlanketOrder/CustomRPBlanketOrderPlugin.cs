using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using TRAVERSE.Client;
using TRAVERSE.Core;

namespace CSI.MT.CustomRPBlanketOrder
{
    public class CustomRPBlanketOrderPlugin : PluginBase
    {
        public override void Initialize()
        {
            this.MainInterface = new CustomBlanketOrderControl(this);//(this);
        }
        public override string Description
        {
            get
            {
                //return Resources.BlanketOrderTitle;
                return "RPBlanket Order";
            }
            protected set
            {
                base.Description = value;
            }
        }
    }
}
