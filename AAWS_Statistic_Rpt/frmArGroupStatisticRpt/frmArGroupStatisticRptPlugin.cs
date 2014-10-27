using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using TRAVERSE.Client;
using TRAVERSE.Core;

namespace CSI.AACTB.frmArGroupStatisticRpt
{
    public class frmArGroupStatisticRptPlugin : PluginBase
    {
        public override void Initialize()
        {
            this.MainInterface = new frmArGroupStatisticRptControl();//(this);
        }
        public override string Description
        {
            get
            {
                return "ArGroupStatisticRpt";
                //return base.Description;
            }
            protected set
            {
                base.Description = value;
            }
        }
    }
}
