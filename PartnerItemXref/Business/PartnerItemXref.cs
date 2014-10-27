using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using System.ComponentModel;
using TRAVERSE.Core;

//namespace Business
namespace TRAVERSE.Business.PartnerItemXref
{
    //[Serializable]
    //class PartnerItemXref
    public class PartnerItemXref : PartnerItemXrefBase
    {
        public PartnerItemXref()
            : this(string.Empty)
        {
        }

        public PartnerItemXref(string compId)
            : base(compId)
        {
        }


    }
}
