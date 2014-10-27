#region using_statements
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using DevExpress.XtraEditors.Filtering;
using TRAVERSE.Report.AccountsReceivable;
using TRAVERSE.Business;
using TRAVERSE.Business.Sys;
using TRAVERSE.Business.Batching;
using TRAVERSE.Business.AccountsReceivable;
using TRAVERSE.Core;
using TRAVERSE.Client;
using TRAVERSE.Client.Report;
using TRAVERSE.Controls;
#endregion

namespace CSI.AACTB.frmArGroupStatisticRpt
{
    public partial class frmArGroupStatisticRptControl : PickScreenBase
    //public class frmArGroupStatisticRptControl : PickScreenBase
    {
        private BindingSource bindingSource1;
        private System.ComponentModel.IContainer components = null;
        private TRAVERSE.Controls.TravDateControl travDateControl2;
        private TRAVERSE.Controls.TravDateControl travDateControl1;
        private TRAVERSE.Controls.TravLabel travLabel1;
        public static int _selection = 1;
        public static DateTime _from = DateTime.Now.AddMonths(-1);
        public static DateTime _thru = DateTime.Now;

        //public frmArGroupStatisticRptControl():base()
        public frmArGroupStatisticRptControl()
        {
            this.InitializeComponent();
        }

        //public frmArGroupStatisticRptControl(IPlugin host)

   /*     protected override void AssignReportPath()
        {
            //base.AssignParameters();

            string rptPath = TRAVERSE.Core.ApplicationContext.ReportPath;
            this.ReportDef.PathList.Add(rptPath + "\\rptArGroupStatisticArea.rdl");//this.BuildReportPath(Resources.BlanketOrderFileName)
            this.ReportDef.PathList.Add(rptPath + "\\rptArGroupStatisticCountrySt.rdl");//this.BuildReportPath(Resources.BlanketOrderDetailFileName)
            base.Landscape = true;
        }
        protected override void CreateDataGenerator()
        {
            this.DataGenerator = new frmArGroupStatisticRptData(this.CompId);
        }
    */
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
           
            this.CompId = base.HostPlugin.DatabaseName;
            this.InitDataFilter();
            //base.splitContainerPick.Panel2Collapsed = true;
            this.FilterControl.ToggleEnabled = false;
            this.ResetParameters();
           
        }

        public override void InitDataFilter()
        {
            //FilterColumnCollection filterColumns = FilterColumns.ArHistory();
            base.InitDataFilter();
            FilterColumnCollection filterColumns = new FilterColumnCollection();
            filterColumns.Add(new UnboundFilterColumn("Group ID", "CustId", typeof(string), new RepositoryItemTravTextBox(), FilterColumnClauseClass.String));
            filterColumns.Add(new UnboundFilterColumn("Delegate Area", "Area", typeof(string), new RepositoryItemTravTextBox(), FilterColumnClauseClass.String));
            filterColumns.Add(new UnboundFilterColumn("Group City", "City", typeof(string), new RepositoryItemTravTextBox(), FilterColumnClauseClass.String));
            filterColumns.Add(new UnboundFilterColumn("Group State", "Region", typeof(string), new RepositoryItemTravTextBox(), FilterColumnClauseClass.String));
            filterColumns.Add(new UnboundFilterColumn("Start Payment Date", "PmtDateFrom", typeof(string), new RepositoryItemTravTextBox(), FilterColumnClauseClass.String));
            filterColumns.Add(new UnboundFilterColumn("End Payment Date", "PmtDateThru", typeof(string), new RepositoryItemTravTextBox(), FilterColumnClauseClass.String));

            this.FilterControl.SetFilterColumnsCollection(filterColumns);
           
        }

        public override void ResetParameters()
        {
            base.ResetParameters();
            base.Validate();
            this.FilterControl.FilterEditorControl.FilterString = string.Empty;
        }

        protected override bool RenderReport()
        //public override bool RenderReport()
        {
            try
            {
                base.Validate();
              // this.FilterControl.FilterEditorControl.PostEditor();
                this.ReportDef.Init();//get_ReportDef()
                this.ReportDef.Title = "AR Statistic Report";

                #region set report parameters
              //  this.ReportDef.ReportParameterList.Add(new ReportParameter("ReportFilter", this.FilterControl.GetFilterDisplayText()));
                #endregion

                #region set report datasets
                frmArGroupStatisticRptData data = new frmArGroupStatisticRptData(this.CompId);
                this.DataGenerator = data;
                Dictionary<string, DataSet> dictionary = this.DataGenerator.Execute(this.FilterControl.SqlFilterString, null);
                foreach (KeyValuePair<string, DataSet> pair in dictionary)
                {
                    this.ReportDef.DataSetList.Add(pair.Value);
                }
                #endregion

                #region set report paths
                //this.get_ReportDef().PathList.Add(this.BuildReportPath(ApplicationContext.ReportPath + @"\SmEmployeeCustom.rdl"));//change
                //this.ReportDef.PathList.Add(this.BuildReportPath("C:\\path\\to\\RDL.rdl"));
                //this.ReportDef.PathList.Add(this.BuildReportPath(TRAVERSE.Core.ApplicationContext.ReportPath + "\\rptArGroupStatisticCountrySt.rdl"));
                if (Convert.ToInt32(this.selection.EditValue) == 1)
                {
                    this.ReportDef.PathList.Add(this.BuildReportPath(TRAVERSE.Core.ApplicationContext.ReportPath + "\\rptArGroupStatisticArea.rdl"));
                }
                else if (Convert.ToInt32(this.selection.EditValue) == 2)
                {
                    this.ReportDef.PathList.Add(this.BuildReportPath(TRAVERSE.Core.ApplicationContext.ReportPath + "\\rptArGroupStatisticCountrySt.rdl"));
                }
                else
                {
                    //nothing
                }
                #endregion
                                
                //base.Landscape = false;
                //this.Landscape = false; // set report layout

                #region validate report
                string errorDescription = null;
                if (this.ReportDef.IsValid(ref errorDescription))
                {
                    return true;
                   // return base.RenderReport();

                } else {
                    TravMessageBox.Show("invalidReport", errorDescription, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                    //return base.RenderReport();
                }
                #endregion

            }
            catch (Exception exception)
            {
                //...................
                ClientContext.HandleError(exception, this);
                //return true;
            }
            return false;
        }

        //private void InitializeComponent()
        public void InitializeComponent()
        {
            this.travLayoutControl1 = new TRAVERSE.Controls.TravLayoutControl();
            this.Thru = new TRAVERSE.Controls.TravDateControl();
            this.From = new TRAVERSE.Controls.TravDateControl();
            this.selection = new TRAVERSE.Controls.TravRadioGroup();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.splitContainerPick.Panel2.SuspendLayout();
            this.splitContainerPick.SuspendLayout();
            this.splitContainerBase.Panel1.SuspendLayout();
            this.splitContainerBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.travLayoutControl1)).BeginInit();
            this.travLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Thru.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Thru.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.From.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.From.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selection.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerPick
            // 
            // 
            // splitContainerPick.Panel2
            // 
            this.splitContainerPick.Panel2.Controls.Add(this.travLayoutControl1);
            this.splitContainerPick.Size = new System.Drawing.Size(800, 575);
            // 
            // splitContainerBase
            // 
            // 
            // travLayoutControl1
            // 
            this.travLayoutControl1.AllowCustomizationMenu = false;
            this.travLayoutControl1.Controls.Add(this.Thru);
            this.travLayoutControl1.Controls.Add(this.From);
            this.travLayoutControl1.Controls.Add(this.selection);
            this.travLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.travLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.travLayoutControl1.Name = "travLayoutControl1";
            this.travLayoutControl1.OptionsFocus.MoveFocusDirection = DevExpress.XtraLayout.MoveFocusDirection.DownThenAcross;
            this.travLayoutControl1.Root = this.layoutControlGroup1;
            this.travLayoutControl1.Size = new System.Drawing.Size(800, 405);
            this.travLayoutControl1.TabIndex = 0;
            this.travLayoutControl1.Text = "travLayoutControl1";
            // 
            // Thru
            // 
            this.Thru.EditValue = new System.DateTime(2014, 10, 23, 16, 29, 22, 99);
            this.Thru.Location = new System.Drawing.Point(307, 104);
            this.Thru.Name = "Thru";
            this.Thru.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.Thru.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Thru.Properties.MaxValue = new System.DateTime(9999, 12, 31, 23, 59, 59, 0);
            this.Thru.Properties.MinValue = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.Thru.Properties.SetupFunctionId = 0;
            this.Thru.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.Thru.SecurityId = null;
            this.Thru.Size = new System.Drawing.Size(222, 20);
            this.Thru.StyleController = this.travLayoutControl1;
            this.Thru.TabIndex = 6;
            this.Thru.EditValueChanged += new System.EventHandler(this.Thru_EditValueChanged);
            // 
            // From
            // 
            this.From.EditValue = new System.DateTime(2014, 9, 23, 16, 29, 22, 108);
            this.From.Location = new System.Drawing.Point(308, 73);
            this.From.Name = "From";
            this.From.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.From.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.From.Properties.MaxValue = new System.DateTime(9999, 12, 31, 23, 59, 59, 0);
            this.From.Properties.MinValue = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.From.Properties.SetupFunctionId = 0;
            this.From.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.From.SecurityId = null;
            this.From.Size = new System.Drawing.Size(221, 20);
            this.From.StyleController = this.travLayoutControl1;
            this.From.TabIndex = 5;
            this.From.EditValueChanged += new System.EventHandler(this.From_EditValueChanged);
            // 
            // selection
            // 
            this.selection.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.selection.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.selection.EditValue = 1;
            this.selection.Location = new System.Drawing.Point(308, 135);
            this.selection.Name = "selection";
            this.selection.Properties.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.selection.Properties.Appearance.Options.UseBackColor = true;
            this.selection.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "Area Report"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(2, "Country / State Report")});
            this.selection.SecurityId = null;
            this.selection.Size = new System.Drawing.Size(221, 59);
            this.selection.StyleController = this.travLayoutControl1;
            this.selection.TabIndex = 4;
            this.selection.SelectedIndexChanged += new System.EventHandler(this.selection_SelectedIndexChanged);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem2,
            this.emptySpaceItem1,
            this.emptySpaceItem3,
            this.emptySpaceItem4,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem7});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(800, 405);
            this.layoutControlGroup1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.ImageAlignment = System.Drawing.ContentAlignment.BottomCenter;
            this.emptySpaceItem2.Location = new System.Drawing.Point(183, 198);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(350, 205);
            this.emptySpaceItem2.Text = "emptySpaceItem2";
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.ImageAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.emptySpaceItem1.Location = new System.Drawing.Point(183, 0);
            this.emptySpaceItem1.MinSize = new System.Drawing.Size(110, 30);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(350, 66);
            this.emptySpaceItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.CustomizationFormText = "emptySpaceItem3";
            this.emptySpaceItem3.Location = new System.Drawing.Point(0, 0);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(183, 403);
            this.emptySpaceItem3.Text = "emptySpaceItem3";
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem4
            // 
            this.emptySpaceItem4.CustomizationFormText = "emptySpaceItem4";
            this.emptySpaceItem4.ImageAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.emptySpaceItem4.Location = new System.Drawing.Point(533, 0);
            this.emptySpaceItem4.MinSize = new System.Drawing.Size(110, 30);
            this.emptySpaceItem4.Name = "emptySpaceItem4";
            this.emptySpaceItem4.Size = new System.Drawing.Size(265, 403);
            this.emptySpaceItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem4.Text = "emptySpaceItem4";
            this.emptySpaceItem4.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.selection;
            this.layoutControlItem5.ControlAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.layoutControlItem5.CustomizationFormText = "Report Type";
            this.layoutControlItem5.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.layoutControlItem5.Location = new System.Drawing.Point(183, 128);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(350, 70);
            this.layoutControlItem5.Text = "Report Type";
            this.layoutControlItem5.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem5.TextSize = new System.Drawing.Size(113, 20);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.From;
            this.layoutControlItem6.CustomizationFormText = "Payment Date";
            this.layoutControlItem6.Location = new System.Drawing.Point(183, 66);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(350, 31);
            this.layoutControlItem6.Text = "Payment Date       From";
            this.layoutControlItem6.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem6.TextSize = new System.Drawing.Size(113, 20);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.Thru;
            this.layoutControlItem7.CustomizationFormText = "Thru";
            this.layoutControlItem7.Location = new System.Drawing.Point(183, 97);
            this.layoutControlItem7.MaxSize = new System.Drawing.Size(0, 31);
            this.layoutControlItem7.MinSize = new System.Drawing.Size(116, 31);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(350, 31);
            this.layoutControlItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem7.Spacing = new DevExpress.XtraLayout.Utils.Padding(90, 0, 0, 0);
            this.layoutControlItem7.Text = "Thru";
            this.layoutControlItem7.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem7.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem7.TextSize = new System.Drawing.Size(22, 20);
            // 
            // frmArGroupStatisticRptControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Name = "frmArGroupStatisticRptControl";
            this.splitContainerPick.Panel2.ResumeLayout(false);
            this.splitContainerPick.ResumeLayout(false);
            this.splitContainerBase.Panel1.ResumeLayout(false);
            this.splitContainerBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderBase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.travLayoutControl1)).EndInit();
            this.travLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Thru.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Thru.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.From.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.From.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selection.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void selection_EditValueChanged(object sender, EventArgs e)
        {
            //selection = this.selection.EditValue.ToString();
        }

        private void travCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            //selection = this.selection.EditValue.ToString();
        }

        private void selection_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selection = Convert.ToInt32(this.selection.EditValue);
        }

        private void From_EditValueChanged(object sender, EventArgs e)
        {
            _from = Convert.ToDateTime(this.From.EditValue);
        }

        private void Thru_EditValueChanged(object sender, EventArgs e)
        {
            _thru = Convert.ToDateTime(this.Thru.EditValue);
        }
    }
}

