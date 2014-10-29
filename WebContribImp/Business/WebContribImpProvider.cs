using System;
using System.Collections.Generic;
using System.Text;
using TRAVERSE.Business;

namespace TRAVERSE.Business.WebContribImp
{
    public class WebContribImpProvider : WebContribImpProviderBase<WebContribImp>
    {
        public override void Update(string compId)
        {
            if (this.UsePortal())
            {
                EntityProvider.UpdateEntityList<WebContribImp>(this);
                return;
            }

            try
            {
                StartSession();
                this.Items.EnlistTransaction(this.TransMan);
                //persist detail records 
                foreach (WebContribImp WebContribImp in this.Items.ChangedItems)
                {
                    if (WebContribImp.IsValid)
                    {
                      //  FormType.PriorityCodeDetailList.DeletedItems.Clear();
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

