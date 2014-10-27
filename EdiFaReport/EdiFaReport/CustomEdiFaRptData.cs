using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using TRAVERSE.Business;
using TRAVERSE.Business.Sys;
using TRAVERSE.Business.CompanySetup;
using DevExpress.XtraEditors.Filtering;
using TRAVERSE.Client;
using TRAVERSE.Client.Report;
using TRAVERSE.Core;
using TRAVERSE.Business.Report;

namespace CSI.EDI.FaReport
{
   public  class CustomEdiFaRptData: DataGeneratorBase 
    {
    }
      public CustomEdiFaRptData(string compId) : base(compId)
    {
    }

    public override void Execute(Status status)
    {
    }

    public override Dictionary<string, DataSet> Execute(string filter, Status status)
    {
        Dictionary<string, DataSet> dictionary = new Dictionary<string, DataSet>();
        string command = "SELECT EmployeeId, LastName, AddressLine1, AddressLine2, ResidentCity, ResidentState, ZipCode, CountryCode\r\n                    , SocialSecurityNo, PhoneNumber, WorkPhoneNo, WorkExtension, BirthDate, EmergrncyContact AS EmergencyContact\r\n                    , ContactWorkPhone, ContactHomePhone, ContactRelation, WorkEmail, HomeEmail, Internet\r\n                    , COALESCE(LastName, '') + ', ' + COALESCE(FirstName, '') + ' ' + COALESCE(MiddleInit, '') AS EmployeeName \r\n                    FROM dbo.tblSmEmployee";
        if (!string.IsNullOrEmpty(filter))
        {
            command = command + " WHERE " + filter;
        }
        DataSet set = null;
        DataTable table = new DataTable();
        try
        {
            Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
            set = EntityProvider.ExecuteCommand(command, this.CompId, base.TransMan);
            set.DataSetName = "MainDataset";
            dictionary.Add("", set);
        }
        catch (Exception exception)
        {
            TravMessageBox.Show("", exception.Message);
        }
        return dictionary;
    }

}
