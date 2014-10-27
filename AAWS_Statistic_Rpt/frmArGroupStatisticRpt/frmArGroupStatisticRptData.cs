using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors.Filtering;
using TRAVERSE.Report.AccountsReceivable;
using TRAVERSE.Business;
using TRAVERSE.Business.Sys;
using TRAVERSE.Business.Batching;
using TRAVERSE.Core;
using TRAVERSE.Business.AccountsReceivable;
using TRAVERSE.Business.Report;
using TRAVERSE.Client;
using TRAVERSE.Client.Report;

namespace CSI.AACTB.frmArGroupStatisticRpt
{
    //public class frmArGroupStatisticRptData : ArAnalysisData
    public class frmArGroupStatisticRptData : DataGeneratorBase
    {
        //public int _selection = 0;
        private int _sortBy;
        private Status _status;
        DataSet set = null;

        #region Constructor
        public frmArGroupStatisticRptData(string compId)
            :base(compId)
        {
            //this.PrintAllInBase = true;
        }
        #endregion

        public override void Execute(Status status)
        {
            //throw new Exception("The method or operation is not implemented.");
        }

        public override Dictionary<string, DataSet> Execute(string filter, Status status)
        {
            Dictionary<string, DataSet> results;
            this._status = status;
            try
            {
                base.StartPrivateSession();
                //BuildJournalList(filter, this.CompId, base.TransMan);
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@PmtDateFrom", Convert.ToString(frmArGroupStatisticRptControl._from));
                parameters.Add("@PmtDateThru", Convert.ToString(frmArGroupStatisticRptControl._thru));
                //parameters.Add("@PrintOption", this.PrintOption);
                //parameters.Add("@SortOption", this.SortOption);
                //parameters.Add("@SortOrder", this.SortOrder);
                //parameters.Add("@ReportCurrency", this.ReportCurrency);
                //if (Convert.ToInt32(frmArGroupStatisticRptControl.selection.EditValue) == 1)
                if (frmArGroupStatisticRptControl._selection == 1)
                {
                    set = EntityProvider.ExecuteCommand("dbo.trav_ARGroupStatisticAreaRpt_CSI", this.CompId, true, parameters, base.TransMan);
                }
                else if (frmArGroupStatisticRptControl._selection == 2)
                {
                    set = EntityProvider.ExecuteCommand("trav_ARGroupStatisticCityStRpt_CSI", this.CompId, true, parameters, base.TransMan);
                }
                else
                {
                    set = null;
                }
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
