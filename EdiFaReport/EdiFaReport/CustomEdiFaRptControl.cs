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

namespace CSI.EDI.FaReport
{
    public class CustomEdiFaRptControl:PickScreenBase 
    {
        private BindingSource bindingSource1;
        private System.ComponentModel.IContainer components;
        public CustomEdiFaRptControl()
        {
            this.InitializeComponent();
        }
        public override void InitDataFilter()
        {
            FilterColumnCollection columns = new FilterColumnCollection();

            columns.Add(new UnboundFilterColumn("Partner Id", "PartnerId", typeof(string), new RepositoryItemTravTextBox(), FilterColumnClauseClass.String));
            this.FilterControl.SetFilterColumnsCollection(columns);
            base.InitDataFilter();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.CompId = base.HostPlugin.DatabaseName;
            this.InitDataFilter();
            base.splitContainerPick.Panel2Collapsed = true;
            this.FilterControl.ToggleEnabled = false;
            this.ResetParameters();
        }
        protected override bool RenderReport()
        {
            try
            {
                base.Validate();
                this.FilterControl.FilterEditorControl.PostEditor();
                this.get_ReportDef().Init();
                this.get_ReportDef().Title = "EDI FA Report";
                this.get_ReportDef().ReportParameterList.Add(new ReportParameter("ReportFilter", this.FilterControl.GetFilterDisplayText()));
                CustomEdiFaRptData data = new CustomEdiFaRptData(this.CompId);
                this.DataGenerator = data;
                Dictionary<string, DataSet> dictionary = this.DataGenerator.Execute(this.FilterControl.SqlFilterString, null);
                foreach (KeyValuePair<string, DataSet> pair in dictionary)
                {
                    this.get_ReportDef().DataSetList.Add(pair.Value);
                }
                this.get_ReportDef().PathList.Add(this.BuildReportPath(ApplicationContext.ReportPath + @"\SmEmployeeCustom.rdl"));
                base.Landscape = false;
                string errorDescription = null;
                if (this.get_ReportDef().IsValid(ref errorDescription))
                {
                    return true;
                }
                TravMessageBox.Show("invalidReport", errorDescription, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            catch (Exception exception)
            {
                ClientContext.HandleError(exception, this);
            }
            return false;
        }
        public override void ResetParameters()
        {
            base.ResetParameters();
            base.Validate();
            this.FilterControl.FilterEditorControl.FilterString = string.Empty;
        }


        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.splitContainerPick.SuspendLayout();
            this.splitContainerBase.Panel1.SuspendLayout();
            this.splitContainerBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerPick
            // 
            this.splitContainerPick.Size = new System.Drawing.Size(800, 575);
            // 
            // splitContainerBase
            // 
            // 
            // CustomEdiFaRptControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Name = "CustomEdiFaRptControl";
            this.splitContainerPick.ResumeLayout(false);
            this.splitContainerBase.Panel1.ResumeLayout(false);
            this.splitContainerBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderBase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

    }
}
