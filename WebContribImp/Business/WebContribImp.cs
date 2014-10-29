using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using TRAVERSE.Core;

namespace TRAVERSE.Business.WebContribImp
{
    public class WebContribImp : WebContribImpBase
    {
        public WebContribImp()
            : this(string.Empty)
        {
        }

        public WebContribImp(string compId)
            : base(compId)
        {
        }


    }
}


