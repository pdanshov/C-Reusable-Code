using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using TRAVERSE.Business;

//namespace Business
namespace TRAVERSE.Business.PartnerItemXref
{
    public class PartnerItemXrefProvider : PartnerItemXrefProviderBase<PartnerItemXref>
    {
        public override void Update(string compId)
        {
            if (this.UsePortal())
            {
                EntityProvider.UpdateEntityList<PartnerItemXref>(this);
                return;
            }

            try
            {
                StartSession();
                this.Items.EnlistTransaction(this.TransMan);
                //persist detail records 
                foreach (PartnerItemXref PartnerItemXref in this.Items.ChangedItems)
                {
                    if (PartnerItemXref.IsValid)
                    {
                        //  PartnerItemXref.PriorityCodeDetailList.DeletedItems.Clear();
                    }
                }


                base.Update(compId);
            }
            catch
            {
                StopSession(true);
                throw;
            }
            finally
            {
                StopSession();
            }
        }
    }
}
