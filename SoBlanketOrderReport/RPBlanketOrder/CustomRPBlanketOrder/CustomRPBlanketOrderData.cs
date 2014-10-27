using System;
using System.Collections.Generic;
using System.Text;
using TRAVERSE.Report.AccountsPayable;
using System.Data;
using TRAVERSE.Business;
using TRAVERSE.Business.Batching;
using TRAVERSE.Core;
using TRAVERSE.Business.AccountsPayable;
using TRAVERSE.Report.SalesOrder;
//using TRAVERSE.Business.Sys; //Missing Assembly Reference?
//using System.Currency; //inaccessible due to protection level

namespace CSI.MT.CustomRPBlanketOrder
{
    public class CustomRPBlanketOrderData : BlanketOrderData
    {
        private int _sortBy;
        private Status _status;

        public CustomRPBlanketOrderData(string compId)
            :base(compId)
        {
            this.PrintAllInBase = true;
        }
        public override void Execute(Status status)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        public override Dictionary<string, DataSet> Execute(string filter, Status status)
        {
            Dictionary<string, DataSet> results;
            this._status = status; //Missing Definition
            try
            {
                base.StartPrivateSession();
                BuildBlanketOrderList(filter, this.CompId, base.TransMan);
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@SortBy", this._sortBy); //Missing Definition
                parameters.Add("@PrintAllInBaseCurrency", this.PrintAllInBase);
                parameters.Add("@ReportCurrency", this.ReportCurrency);
                parameters.Add("@ExchRate", TRAVERSE.Business.Sys.Currency.GetExchangeRate(this.ReportCurrency, ApplicationContext.SessionDate));//TRAVERSE.Business.Sys.
                parameters.Add("@WksDate", ApplicationContext.SessionDate);
                DataSet set = EntityProvider.ExecuteCommand("dbo.trav_SoBlanketOrderReport_proc_CSI", this.CompId, true, parameters, base.TransMan);
                for (int i = 0; i < set.Tables.Count; i++)
                {
                    DataSet set2 = new DataSet("MainDataset");
                    DataTable table = set.Tables[i].Copy();
                    set2.Tables.Add(table);
                    this.Results.Add(i.ToString(), set2);
                }
                results = this.Results;
            }
            catch (Exception exception)
            {
                base.StopPrivateSession(true);
                throw exception;
            }
            finally
            {
                base.StopPrivateSession(false);
            }
            return results;
        }
    }
}
