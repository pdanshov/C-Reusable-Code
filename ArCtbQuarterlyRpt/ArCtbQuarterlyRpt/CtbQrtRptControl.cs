#region Usings
using System;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using TRAVERSE.Business;
using TRAVERSE.Business.AccountsReceivable;
using TRAVERSE.Business.Link;
using TRAVERSE.Client;
using TRAVERSE.Controls;
using TRAVERSE.Core;
using System.Drawing;
using System.Data.SqlClient;
using System.IO;
using System.Data; // For DataSet
using System.Collections.Generic; // For List
using TRAVERSE.Client.Report; // For Outputting Reports to PDF using TRAVERSE dll's
using TRAVERSE.Client.FormPrinter; // For Outputting Reports to PDF using TRAVERSE dll's
using System.Reflection; // For the reflection technique of loading methods from TRAVERSE dll's
using System.Web.Services.Protocols; // SSRS outputting reports to pdf
using CSI.AAWS.ArCtbQuarterlyRpt.RS2005; // SSRS outputting reports to pdf
using CSI.AAWS.ArCtbQuarterlyRpt.RE2005; // SSRS outputting reports to pdf
//using ....;? need to setup screen basics to render gfx in traverse - was missing init (OnLoad) code
// in this document
#endregion

namespace CSI.AAWS.ArCtbQuarterlyRpt
{
    //public class CtbQrtRptControl : ProcessControlBase
    public class CtbQrtRptControl : ProcessControlBase
    {
        private System.ComponentModel.IContainer components;
        private TravDateControl txtDateThru;
        bool SkipEmail;
        bool ret;

        string EndMM; // parameter to pass to ssrs for user-selected month
        string Endyyyy = DateTime.Now.Year.ToString(); // parameter to pass to ssrs for user-selected year
        string eMail = "1"; // parameter to pass to ssrs for email option
        string strFileName;
        string strGroupId;
        string FilePath;
        string strFileNameY = "";
        string strFileNameN = "";

        string strMMYY;
        string strDate;
        string strMonth;
        DateTime StartDate;
        private TravLabel travLabel5;
        private TravLayoutControl travLayoutControl1;
        private FiscalYearSpinEdit Year;
        private TravRadioGroup OptEmail;
        private TravLabel travLabel1;
        private TravDateControl Month;
        private LayoutControlGroup layoutControlGroup1;
        private LayoutControlItem layoutControlItem1;
        private LayoutControlItem layoutControlItem3;
        private LayoutControlItem layoutControlItem4;
        private LayoutControlItem layoutControlItem7;
        private EmptySpaceItem emptySpaceItem1;
        private EmptySpaceItem emptySpaceItem2;
        private EmptySpaceItem emptySpaceItem3;
        private EmptySpaceItem emptySpaceItem4;
        private EmptySpaceItem emptySpaceItem5;
        private EmptySpaceItem emptySpaceItem6;
        DateTime EndDate;
        
        public CtbQrtRptControl()
            : this(null)
        {
        }

        public CtbQrtRptControl(IPlugin host)
        {
            this.InitializeComponent();
            //this.InitializeComponent();
            if (!DevEnvironment.InVSDesigner)//if (DevEnvironment.InVSDesigner) always should be "if not"
            {
                base.HostPlugin = host;
                base.ButtonExecute.Text = Localizer.GetLocalizedString("btnOK");
                base.ButtonReport.Enabled = true;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            //this.InitializeComponent(); always should be at the top of the constructor ^^
        }

        public override void Execute()
        {
            try
            {
                // Check if parameter options have been set, if not, exit function/method
                if (string.IsNullOrEmpty(this.Month.EditValue.ToString().Substring(0, 2)))//if ( string.IsNullOrEmpty(EndMM) )
                {
                    TravMessageBox.Show("TRAVERSE", "Please set the End Month before running the report.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Month.Focus();
                    return;
                }
                else if (Convert.ToInt32(this.Month.EditValue.ToString().Substring(0, 2)) < 0 || Convert.ToInt32(this.Month.EditValue.ToString().Substring(0, 2)) > 12)
                {
                    TravMessageBox.Show("TRAVERSE", "Please check that the month is correct.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Month.Focus();
                    return;
                }
                else if (string.IsNullOrEmpty(Endyyyy))
                {
                    TravMessageBox.Show("TRAVERSE", "Please set the Year before running the report.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Year.Focus();
                    return;
                } else {
                    EndMM = this.Month.EditValue.ToString();
                    EndMM = EndMM.Substring(0, 2);
                    Endyyyy = this.Year.EditValue.ToString();
                    //Endyyyy = Endyyyy.Substring(6, 4);
                }
            } catch (Exception exception)
            {
                //throw exception;
                TravMessageBox.Show("TRAVERSE", "Please set the End Month before running the report... " + exception, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Month.Focus();
                return;
            }

            //StartDate = Convert.ToDateTime(new DateTime(Convert.ToInt32(Endyyyy) - 1, 12, 31).ToOADate());
            StartDate = Convert.ToDateTime(new DateTime(Convert.ToInt32(Endyyyy) - 1, 12, 31));
            Int32 stD = Convert.ToInt32(StartDate.ToOADate());
            EndDate = Convert.ToDateTime(Month.EditValue.ToString()).AddMonths(stD);
            StartDate = new DateTime(Convert.ToInt32(Endyyyy), 1, 1);
            strMMYY = EndDate.ToString("MMYYYY");
            strDate = EndDate.ToString("mmm dd, yyyy");


            /////////////////////////////////////////////////////////////////////////////////////////////////////////
            // check if file exists

            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.SupportMultiDottedExtensions = true;
            DialogResult sdgResult = saveDialog.ShowDialog();
            if (sdgResult == DialogResult.OK)
            {
                strFileName = saveDialog.FileName;
                if (File.Exists(@strFileName + "Y") & File.Exists(@strFileName + "N"))
                {
                    var result2 = TravMessageBox.Show("TRAVERSE", strFileName + "Y \n" + strFileName + "N \n\n\talready exist, overwrite?", MessageBoxButtons.YesNo);
               
                    
                    if (result2 == DialogResult.Yes)
                    {
                        File.Delete(@strFileName + "Y");
                        File.Delete(@strFileName + "N");
                    }
                }
                strFileNameY = strFileName + "Y";
                strFileNameN = strFileName + "N";
                if (postToMaster() != false)
                {

                    if (Convert.ToInt32(OptEmail.EditValue) == 1 || Convert.ToInt32(OptEmail.EditValue) == 3)
                    {
                        ret = EmailQrtlContrubRpt_GenPDF(1, strMonth, strMMYY);
                        ret = EmailQrtlContrubRpt_GenPDF(0, strMonth, strMMYY);
                    }
                    else if (Convert.ToInt32(OptEmail.EditValue) == 2)
                    {
                        SkipEmail = true;
                    }
                    else
                    {
                        SkipEmail = false;
                    }
                    //Run TXT document generation code
                    generateTxt();
                }
            }
        }

        private Boolean postToMaster()
        {
            Boolean result = false;
            try
            {

                string _sqlexec = "";
                _sqlexec = "exec dbo.rptArQtrlContribution @StartDate='" + StartDate.ToString() + "',@EndDate=" + EndDate.ToString() + "'";
                try
                {
                    EntityProvider.ExecuteCommand(_sqlexec, CompId, null);
                    result = true;
                }
                catch (Exception exception)
                {
                    throw exception;
                  
                }
               
         
            }
            catch (Exception exception)
            {
                throw exception;
              
            }

            return result;
        }

        private void InitializeComponent()
        {
            this.travLabel5 = new TRAVERSE.Controls.TravLabel();
            this.travLayoutControl1 = new TRAVERSE.Controls.TravLayoutControl();
            this.Year = new TRAVERSE.Controls.FiscalYearSpinEdit();
            this.OptEmail = new TRAVERSE.Controls.TravRadioGroup();
            this.travLabel1 = new TRAVERSE.Controls.TravLabel();
            this.Month = new TRAVERSE.Controls.TravDateControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem5 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem6 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.splitContainerProcess.Panel1.SuspendLayout();
            this.splitContainerProcess.SuspendLayout();
            this.splitContainerBase.Panel1.SuspendLayout();
            this.splitContainerBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.travLayoutControl1)).BeginInit();
            this.travLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Year.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OptEmail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Month.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Month.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem6)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerProcess
            // 
            // 
            // splitContainerProcess.Panel1
            // 
            this.splitContainerProcess.Panel1.Controls.Add(this.travLayoutControl1);
            this.splitContainerProcess.Panel1.Controls.Add(this.travLabel5);
            this.splitContainerProcess.Panel2Collapsed = true;
            this.splitContainerProcess.Size = new System.Drawing.Size(739, 448);
            // 
            // splitContainerBase
            // 
            // 
            // travLabel5
            // 
            this.travLabel5.Location = new System.Drawing.Point(159, 32);
            this.travLabel5.Name = "travLabel5";
            this.travLabel5.SecurityId = null;
            this.travLabel5.Size = new System.Drawing.Size(0, 13);
            this.travLabel5.TabIndex = 8;
            // 
            // travLayoutControl1
            // 
            this.travLayoutControl1.AllowCustomizationMenu = false;
            this.travLayoutControl1.Controls.Add(this.Year);
            this.travLayoutControl1.Controls.Add(this.OptEmail);
            this.travLayoutControl1.Controls.Add(this.travLabel1);
            this.travLayoutControl1.Controls.Add(this.Month);
            this.travLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.travLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.travLayoutControl1.Name = "travLayoutControl1";
            this.travLayoutControl1.OptionsFocus.MoveFocusDirection = DevExpress.XtraLayout.MoveFocusDirection.DownThenAcross;
            this.travLayoutControl1.Root = this.layoutControlGroup1;
            this.travLayoutControl1.Size = new System.Drawing.Size(739, 448);
            this.travLayoutControl1.TabIndex = 9;
            this.travLayoutControl1.Text = "travLayoutControl1";
            // 
            // Year
            // 
            this.Year.EditValue = new decimal(new int[] {
            2014,
            0,
            0,
            0});
            this.Year.Location = new System.Drawing.Point(366, 132);
            this.Year.MaxValue = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.Year.Name = "Year";
            this.Year.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.Year.Properties.HideSpinners = false;
            this.Year.Properties.MaxValue = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.Year.Properties.NumericPrecision = 0;
            this.Year.Properties.SetupFunctionId = 0;
            this.Year.Properties.ValidateOnEnterKey = true;
            this.Year.SecurityId = null;
            this.Year.Size = new System.Drawing.Size(156, 20);
            this.Year.StyleController = this.travLayoutControl1;
            this.Year.TabIndex = 14;
            // 
            // OptEmail
            // 
            this.OptEmail.EditValue = 1;
            this.OptEmail.Location = new System.Drawing.Point(221, 165);
            this.OptEmail.Name = "OptEmail";
            this.OptEmail.Properties.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.OptEmail.Properties.Appearance.Options.UseBackColor = true;
            this.OptEmail.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "Generate Emails and File"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(2, "Generate File Only"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(3, "Generate Email and File, Repeat Emailed Records in File")});
            this.OptEmail.SecurityId = null;
            this.OptEmail.Size = new System.Drawing.Size(301, 133);
            this.OptEmail.StyleController = this.travLayoutControl1;
            this.OptEmail.TabIndex = 12;
            // 
            // travLabel1
            // 
            this.travLabel1.Location = new System.Drawing.Point(221, 68);
            this.travLabel1.Name = "travLabel1";
            this.travLabel1.SecurityId = null;
            this.travLabel1.Size = new System.Drawing.Size(301, 21);
            this.travLabel1.StyleController = this.travLayoutControl1;
            this.travLabel1.TabIndex = 9;
            this.travLabel1.Text = "End Date";
            // 
            // Month
            // 
            this.Month.EditValue = null;
            this.Month.Location = new System.Drawing.Point(366, 100);
            this.Month.Name = "Month";
            this.Month.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.Month.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Month.Properties.DisplayFormat.FormatString = "MM";
            this.Month.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.Month.Properties.Mask.EditMask = "MM";
            this.Month.Properties.MaxValue = new System.DateTime(9999, 12, 31, 23, 59, 59, 0);
            this.Month.Properties.MinValue = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.Month.Properties.SetupFunctionId = 0;
            this.Month.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.Month.SecurityId = null;
            this.Month.Size = new System.Drawing.Size(156, 20);
            this.Month.StyleController = this.travLayoutControl1;
            this.Month.TabIndex = 8;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.emptySpaceItem1,
            this.emptySpaceItem2,
            this.emptySpaceItem3,
            this.emptySpaceItem4,
            this.layoutControlItem7,
            this.emptySpaceItem5,
            this.layoutControlItem1,
            this.emptySpaceItem6});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(739, 448);
            this.layoutControlGroup1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.Year;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(330, 125);
            this.layoutControlItem1.MaxSize = new System.Drawing.Size(196, 33);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(196, 33);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(196, 33);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.Text = "YYYY";
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(24, 0);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.OptEmail;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(214, 158);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(312, 144);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(312, 144);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(312, 144);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.Text = "layoutControlItem3";
            this.layoutControlItem3.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.travLabel1;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem4.Location = new System.Drawing.Point(214, 61);
            this.layoutControlItem4.MaxSize = new System.Drawing.Size(312, 32);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(312, 32);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(312, 32);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.Text = "layoutControlItem4";
            this.layoutControlItem4.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextToControlDistance = 0;
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.Month;
            this.layoutControlItem7.CustomizationFormText = "layoutControlItem7";
            this.layoutControlItem7.Location = new System.Drawing.Point(330, 93);
            this.layoutControlItem7.MaxSize = new System.Drawing.Size(196, 32);
            this.layoutControlItem7.MinSize = new System.Drawing.Size(196, 32);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(196, 32);
            this.layoutControlItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem7.Text = "MM";
            this.layoutControlItem7.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem7.TextSize = new System.Drawing.Size(24, 0);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(214, 302);
            this.emptySpaceItem1.MaxSize = new System.Drawing.Size(312, 144);
            this.emptySpaceItem1.MinSize = new System.Drawing.Size(312, 144);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(312, 144);
            this.emptySpaceItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 61);
            this.emptySpaceItem2.MaxSize = new System.Drawing.Size(214, 385);
            this.emptySpaceItem2.MinSize = new System.Drawing.Size(214, 385);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(214, 385);
            this.emptySpaceItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem2.Text = "emptySpaceItem2";
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.CustomizationFormText = "emptySpaceItem3";
            this.emptySpaceItem3.Location = new System.Drawing.Point(526, 61);
            this.emptySpaceItem3.MaxSize = new System.Drawing.Size(211, 385);
            this.emptySpaceItem3.MinSize = new System.Drawing.Size(211, 385);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(211, 385);
            this.emptySpaceItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem3.Text = "emptySpaceItem3";
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem4
            // 
            this.emptySpaceItem4.CustomizationFormText = "emptySpaceItem4";
            this.emptySpaceItem4.Location = new System.Drawing.Point(214, 125);
            this.emptySpaceItem4.MaxSize = new System.Drawing.Size(116, 33);
            this.emptySpaceItem4.MinSize = new System.Drawing.Size(116, 33);
            this.emptySpaceItem4.Name = "emptySpaceItem4";
            this.emptySpaceItem4.Size = new System.Drawing.Size(116, 33);
            this.emptySpaceItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem4.Text = "emptySpaceItem4";
            this.emptySpaceItem4.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem5
            // 
            this.emptySpaceItem5.CustomizationFormText = "emptySpaceItem5";
            this.emptySpaceItem5.Location = new System.Drawing.Point(214, 93);
            this.emptySpaceItem5.MaxSize = new System.Drawing.Size(116, 32);
            this.emptySpaceItem5.MinSize = new System.Drawing.Size(116, 32);
            this.emptySpaceItem5.Name = "emptySpaceItem5";
            this.emptySpaceItem5.Size = new System.Drawing.Size(116, 32);
            this.emptySpaceItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem5.Text = "emptySpaceItem5";
            this.emptySpaceItem5.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem6
            // 
            this.emptySpaceItem6.CustomizationFormText = "emptySpaceItem6";
            this.emptySpaceItem6.Location = new System.Drawing.Point(0, 0);
            this.emptySpaceItem6.MaxSize = new System.Drawing.Size(737, 61);
            this.emptySpaceItem6.MinSize = new System.Drawing.Size(737, 61);
            this.emptySpaceItem6.Name = "emptySpaceItem6";
            this.emptySpaceItem6.Size = new System.Drawing.Size(737, 61);
            this.emptySpaceItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem6.Text = "emptySpaceItem6";
            this.emptySpaceItem6.TextSize = new System.Drawing.Size(0, 0);
            // 
            // CtbQrtRptControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Name = "CtbQrtRptControl";
            this.splitContainerProcess.Panel1.ResumeLayout(false);
            this.splitContainerProcess.Panel1.PerformLayout();
            this.splitContainerProcess.ResumeLayout(false);
            this.splitContainerBase.Panel1.ResumeLayout(false);
            this.splitContainerBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderBase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.travLayoutControl1)).EndInit();
            this.travLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Year.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OptEmail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Month.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Month.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem6)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
   /*
        private void Month_EditValueChanged(object sender, EventArgs e)
        {
            EndMM = this.Month.EditValue.ToString();
            EndMM = EndMM.Substring(0, 2);
        }

        private void Year_EditValueChanged(object sender, EventArgs e)
        {
            Endyyyy = this.Year.EditValue.ToString();
            Endyyyy = Endyyyy.Substring(6, 4);
        }
    */
        private void OptEmail_EditValueChanged(object sender, EventArgs e)
        {
            eMail = this.OptEmail.EditValue.ToString();
        }

        public bool EmailQrtlContrubRpt_GenPDF(int intYesNo, string strDate, string strMMYY)
        {
            string SSRSUrl = "http://202.1.1.223/reportserver/ReportExecution2005.asmx"; //change to business rules url
            string ReportPathN = "/Report Project1/rptArQtrCntMailCotributedN"; //change to business rules path
            string ReportPathY = "/Report Project1/rptArQtrCntMailCotributedY"; //change to business rules path
            CSI.AAWS.ArCtbQuarterlyRpt.RE2005.ReportExecutionService rsPDF = new CSI.AAWS.ArCtbQuarterlyRpt.RE2005.ReportExecutionService();
            rsPDF.Credentials = System.Net.CredentialCache.DefaultCredentials;
            rsPDF.Url = SSRSUrl;
            // http://localhost/reports/Pages/Folder.aspx
            // http://localhost/reportserver

            Directory.CreateDirectory(@"C:\AAWS_Reports");

            // Render arguments
            byte[] result = null;
            string reportPath = ReportPathN; // This is which report it selects on the SSRS server
            string reportPath2 = ReportPathY;
            string format = "PDF";
            string historyID = null;
            string devInfo = @"<DeviceInfo><Toolbar>False</Toolbar></DeviceInfo>";

            string EmailTo;
            string EmailCC;
            string EmailBCC;
            string strBody;
            string rptName;
            string strProc;
            string path;
            int i; // Counter for emails
            string path4 = "";
            string strGlobalAtt;
            string strlang;
            string sqlAttachDir;
            string gArFilePath;
            
            if (intYesNo == 1)
            {
                rptName = "rptArQtrCntMailCotributedY";
                strProc = "dbo.rptArQtrlContributionExpEmailY";
            }
            else
            {
                rptName = "rptArQtrCntMailCotributedN";
                strProc = "dbo.rptArQtrlContributionExpEmailN";
            }

            try
            {
                string _sqlexec = "";
                string _sqlAttachDir = "";
                _sqlexec = "select * from dbo.glbArOption";
                _sqlAttachDir = "select * from dbo.stpSmCommAccounts where AccountName = '" + this.CompId + "STMT'";
                try
                {
                    DataSet dataSet = new DataSet("glbArOption");
                    dataSet = EntityProvider.ExecuteCommand(_sqlexec, CompId, null);
                    DataTable dataTable = dataSet.Tables[0];
                    strGlobalAtt = Convert.ToString(dataTable.Rows[0]["GenAreaAttachDir"]) ?? ""; //Nz(rs!GenAreaAttachDir, "")

                    DataSet dataAtchDir = new DataSet("glbArOption");
                    sqlAttachDir = EntityProvider.ExecuteCommand(_sqlAttachDir, CompId, null).ToString(); ; //gCompId = this.CompId
                    DataTable dTAtchDir = dataSet.Tables[0];
                    gArFilePath = Convert.ToString(dTAtchDir.Rows[0]["DfltAttachPath"]).Trim();
                    path = gArFilePath.Trim();
                }
                catch (Exception exception)
                {
                    throw exception;
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            try
            {
                // Init Parameters for PDF
                CSI.AAWS.ArCtbQuarterlyRpt.RE2005.ParameterValue[] parameter = new CSI.AAWS.ArCtbQuarterlyRpt.RE2005.ParameterValue[1];
                new CSI.AAWS.ArCtbQuarterlyRpt.RE2005.ParameterValue();

                // Init Parameters for Email
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                DataSet rsEMAIL = EntityProvider.ExecuteCommand("dbo.qryARInsertSMComm", this.CompId, true, parameters, null);
                DataTable dt = rsEMAIL.Tables[0];
                for (int x = 0; x < dt.Rows.Count - 1; x++)
                {
                    strGroupId = dt.Rows[x]["FellowID"].ToString();
                    strlang = dt.Rows[x]["Lang"].ToString();
                    strFileName = strMMYY + "_" + strGroupId;
                    FilePath = path + strFileName + ".pdf";
                    this.travLabel5.Text = strGroupId;
                    strBody = "Contributions statements for  " + strDate + Convert.ToChar(13) + Convert.ToChar(10) + strGroupId + Convert.ToChar(13) + Convert.ToChar(10) + dt.Rows[x]["groupName"];
                    
                    //Loop: create pdf & create email records here

                    // Add Parameters for PDF
                    parameter[0] = new CSI.AAWS.ArCtbQuarterlyRpt.RE2005.ParameterValue();
                    parameter[0].Name = "GroupID";
                    parameter[0].Value = strGroupId;

                    // Add Parameters for Email
                    parameters.Add("@TransId", strGroupId.Substring(2, 8)); //string.Substring(startIndex, length)
                    parameters.Add("@CommKeyType", "CTB STMT");
                    parameters.Add("@CommKeyVal", strMMYY + strGroupId);
                    parameters.Add("@Subject", "Contributions statements for  " + strGroupId + "; " + strDate);
                    parameters.Add("@Body", strBody);
                    parameters.Add("@IsHTMLYN", 0);
                    parameters.Add("@Attachments", FilePath + ";" + (path4 ?? "")); // Nz(variable, ValIfNull) = (variable ?? ValIfNull)in .NET
                    parameters.Add("@DateCreated", DateTime.Now);
                    parameters.Add("@AccountName", this.CompId + "STMT");
                    parameters.Add("@EmailTo", dt.Rows[x]["EmailAddr"]); // rs!EmailAddr Convert.ToString(dtY.Rows[i]["ReferenceId"])
                    parameters.Add("@EmailCC", null);
                    parameters.Add("@EmailBCC", null);
                    parameters.Add("@CustID", strGroupId);

                    // Create PDF's
                    string showHideToggle = null;
                    string encoding;
                    string mimeType;
                    string extension;
                    CSI.AAWS.ArCtbQuarterlyRpt.RE2005.Warning[] warnings = null;
                    CSI.AAWS.ArCtbQuarterlyRpt.RE2005.ParameterValue[] reportHistoryParameters = null;
                    string[] streamIDs = null;

                    ExecutionInfo execInfo = new ExecutionInfo();
                    ExecutionHeader execHeader = new ExecutionHeader();
                    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    ////////////////
                    /////                   PDF N
                    ////////////////
                    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    rsPDF.ExecutionHeaderValue = execHeader;
                    execInfo = rsPDF.LoadReport(reportPath, historyID);
                    rsPDF.SetExecutionParameters(parameter, "en-us");
                    String SessionId = rsPDF.ExecutionHeaderValue.ExecutionID;
                    //Console.WriteLine("SessionID: {0}", rs.ExecutionHeaderValue.ExecutionID);
                    try
                    {
                        result = rsPDF.Render(format, devInfo, out extension, out encoding, out mimeType, out warnings, out streamIDs);
                        execInfo = rsPDF.GetExecutionInfo();
                    }
                    catch (SoapException e)
                    {
                        //Console.WriteLine(e.Detail.OuterXml);
                    }
                    // Write the contents of the report to an MHTML file.
                    try
                    {
                        FileStream stream = File.Create(@path+strFileName+".pdf", result.Length);
                        stream.Write(result, 0, result.Length);
                        stream.Close();
                     }
                    catch (Exception e)
                    {
                        //Console.WriteLine(e.Message);
                    }
                    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    ////////////////
                    /////                  PDF Y
                    ////////////////
                    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    rsPDF.ExecutionHeaderValue = execHeader;
                    execInfo = rsPDF.LoadReport(reportPath2, historyID);
                    rsPDF.SetExecutionParameters(parameter, "en-us");
                    SessionId = rsPDF.ExecutionHeaderValue.ExecutionID;
                    try
                    {
                        result = rsPDF.Render(format, devInfo, out extension, out encoding, out mimeType, out warnings, out streamIDs);
                        execInfo = rsPDF.GetExecutionInfo();
                    }
                    catch (SoapException e)
                    {
                        Console.WriteLine(e.Detail.OuterXml);
                    }
                    // Write the contents of the report to an MHTML file.
                    try
                    {
                        strFileName = strMMYY + "_" + strGroupId;
                        FilePath = path + strFileName + ".pdf";
                        //FileStream stream = File.Create(@"C:\AAWS_Reports\201409_000151434-Y.pdf", result.Length);
                        FileStream stream = File.Create(@path+strFileName+".pdf", result.Length);
                        stream.Write(result, 0, result.Length);
                        stream.Close();
                    }
                    catch (Exception e)
                    {
                        //Console.WriteLine(e.Message);
                    }

                    if (strGlobalAtt != "" && File.Exists(strGlobalAtt))
                    {
                        path4 = path + strFileName + "_1.pdf";
                        File.Copy(strGlobalAtt, path4, true);
                    }

                    if (parameters.Count != 0)
                    {
                        return false;
                    }

                    //cmd = Nothing;
                    FilePath = "";
                    //rs.MoveNext;
                    //Loop;
                    //rs.Close;
                    rsEMAIL = null;
                    //EmailQrtlContrubRpt_GenPDF = true;
                    return true;
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
      
            return true;
        } // End Send Email & Generate PDF

        public void generateTxt()
        {
            List<string> outList = new List<string>();
            List<string> outList1 = new List<string>();
            string strSetup;
            string strTemp;
            string str8 = new String(' ', 8);
            string str30 = new String(' ', 30);
            string str40 = new String(' ', 40);
            string strAmtUs;
            string strAmtCan;
            string currFellowID = "9";
            //string strDate = "12 31 2012";
            var rand = new Random();
            //bool SkipEmail = Convert.ToBoolean(rand.Next(2));
            /*
                    #region Test Variables
                    string Zip = "12345";
                    string Country = "CY";
                    string groupName = " ";
                    string GroupCity = " ";
                    string GroupState = " ";
                    string Language = "LG";
                    string District = "Dist";
                    string City = "City";
                    string State = "ST";
                    string Area = "Area";
                    string FellowID = "99999";
            */

            int PeriodFrom = Convert.ToInt32(EndMM);
            bool ContribYn = true;
            switch (PeriodFrom) // MePeriodFrom, this.PeriodFrom
            {
                case 1:
                    strMonth = "ONE MONTH    ";
                    break;
                case 2:
                    strMonth = "TWO MONTHS   ";
                    break;
                case 3:
                    strMonth = "THREE MONTHS ";
                    break;
                case 4:
                    strMonth = "FOUR MONTHS  ";
                    break;
                case 5:
                    strMonth = "FIVE MONTHS  ";
                    break;
                case 6:
                    strMonth = "SIX MONTHS   ";
                    break;
                case 7:
                    strMonth = "SEVEN MONTHS ";
                    break;
                case 8:
                    strMonth = "EIGHT MONTHS ";
                    break;
                case 9:
                    strMonth = "NINE MONTHS  ";
                    break;
                case 10:
                    strMonth = "TEN MONTHS   ";
                    break;
                case 11:
                    strMonth = "ELEVEN MONTHS";
                    break;
                case 12:
                    strMonth = "TWELVE MONTHS";
                    break;
                default:
                    // 13 chars in string
                    strMonth = "DEFAULT MONTH";
                    break;
            }
            this.EndMM = strMonth.ToLower();
        //    this.Endyyyy = strDate;

            ////////////////////////////////////////////////////////////
            // Email here
            ////////////////////////////////////////////////////////////
            
            if (Convert.ToInt32(this.OptEmail.EditValue) != 2) {
	            ret = EmailQrtlContrubRpt_GenPDF(1, strMonth, strMMYY);
                ret = EmailQrtlContrubRpt_GenPDF(0, strMonth, strMMYY);
            }
            else if (Convert.ToInt32(this.OptEmail.EditValue) == 2)
            {
                SkipEmail = true;
            }
            else
            {
                SkipEmail = false;
            }

            /*
            'do yes first
            iChan = FreeFile
            Open strFileNameY For Output As iChan
            Set comY = New Command
            Set rsY = New Recordset
            DoCmd.Hourglass True
            */
            //FileStream fileStream = new FileStream(@"c:\file.txt", FileMode.Open);
            //FileStream outfile = new FileStream(@strFileNameY, FileMode.Open);

            /*
            With comY
              .ActiveConnection = getadoconnection("A3")
              .CommandType = adCmdStoredProc
              .CommandText = "dbo.rptArQtrlContributionExpy"
              .Parameters.Refresh
              .Parameters("@skipEmailYN") = SkipEmail
               Set rsY = .Execute
            End With
            */

            ///////////////////////////////////////////////
            // Do Yes First
            ///////////////////////////////////////////////
     //       currFellowID = "9";

            try
            {
                Dictionary<string, object> parameters2 = new Dictionary<string, object>();
          //      parameters2.Add("@skipEmailYN", SkipEmail);
                parameters2.Add("@ContribYn", ContribYn);
                DataSet rsY = EntityProvider.ExecuteCommand("dbo.trav_ArQtrlContributionRptExp_proc_CSI", this.CompId, true, parameters2, null);
                DataTable dtY = rsY.Tables[0];
                for (int i = 0; i < dtY.Rows.Count - 1; i++)
                {

                    string FellowID = Convert.ToString(dtY.Rows[i]["FellowID"]);
                    string Zip = Convert.ToString(dtY.Rows[i]["Zip"]);
                    string Country = Convert.ToString(dtY.Rows[i]["Country"]);
                    string groupName = Convert.ToString(dtY.Rows[i]["groupName"]);
                    string GroupCity = Convert.ToString(dtY.Rows[i]["GroupCity"]);
                    string GroupState = Convert.ToString(dtY.Rows[i]["GroupState"]);
                    string Language = Convert.ToString(dtY.Rows[i]["Language"]);

                    string District = Convert.ToString(dtY.Rows[i]["District"]);
                    if (District.Length < 2)
                        District = "  ";
                    else
                        District = District.Trim().Substring(0, 2);

                    string City = Convert.ToString(dtY.Rows[i]["City"]);
                    string State = Convert.ToString(dtY.Rows[i]["State"]);
                    string Area = Convert.ToString(dtY.Rows[i]["Area"]);
                    string LastName = Convert.ToString(dtY.Rows[i]["LastName"]);
                    string FirstName = Convert.ToString(dtY.Rows[i]["FirstName"]);
                    string Addr1 = Convert.ToString(dtY.Rows[i]["Addr1"]);
                    string Addr2 = Convert.ToString(dtY.Rows[i]["Addr2"]);
                    string Addr3 = Convert.ToString(dtY.Rows[i]["Addr3"]);
                    string USAmt = Convert.ToString(dtY.Rows[i]["USAmt"]);
                    string CadAmt = Convert.ToString(dtY.Rows[i]["CadAmt"]);
                    string CheckDate = Convert.ToString(dtY.Rows[i]["CheckDate"]);
                    string ReferenceId = Convert.ToString(dtY.Rows[i]["ReferenceId"]);
                    string Mhsrc = Convert.ToString(dtY.Rows[i]["Mhsrc"]);

                    if (currFellowID != FellowID)
                    {
                        strSetup = Language + new String(' ', 2 - Language.Length) + FellowID + District + new String(' ', 2 - District.Length) + Area + new String(' ', 8 - Area.Length) + ContribYn;
                        strTemp = "H0" + strSetup + str40 + str30 + str30 + str30 + str8;
                        outList.Add(strTemp.ToString());
                        strTemp = "H1" + strSetup + LastName + new String(' ', 40 - LastName.Length) + FirstName + new String(' ', 30 - FirstName.Length) + str30 + str30 + str8;
                        outList.Add(strTemp.ToString());
                        strTemp = "H2" + strSetup + Addr1 + new String(' ', 40 - Addr1.Length) + Addr2 + new String(' ', 30 - Addr2.Length) + Addr3 + new String(' ', 30 - Addr3.Length) + str30 + str8;
                        outList.Add(strTemp.ToString());
                        strTemp = "H3" + strSetup + City + new String(' ', 40 - City.Length) + State + new String(' ', 30 - State.Length) + Zip + new String(' ', 30 - Zip.Length) + Country + new String(' ', 30 - Country.Length) + str8;
                        outList.Add(strTemp.ToString());
                        strTemp = "H4" + strSetup + groupName + new String(' ', 40 - groupName.Length) + GroupCity + new String(' ', 30 - GroupCity.Length) + GroupState + new String(' ', 30 - GroupState.Length) + str30 + str8;
                        outList.Add(strTemp.ToString());
             //           strTemp = "H5" + strSetup + strMonth + strDate + str30 + str30 + str8;
                        outList.Add(strTemp.ToString());
                        currFellowID = FellowID;
                    }
                    else
                    {
                        strSetup = Language + new String(' ', 2 - Language.Length) + FellowID + District + new String(' ', 2 - District.Length) + Area + new String(' ', 8 - Area.Length) + ContribYn;
                    }
                    if (ContribYn == true)
                    {
                        strAmtUs = "";
                        strAmtCan = "";
                        strAmtUs = string.Format("{0:0.00}", USAmt);
                        strAmtCan = string.Format("{0:0.00}", CadAmt);
                        strTemp = "";
                        strTemp = "DD" + strSetup;
                        strTemp = strTemp + CheckDate + new String(' ', 32);
                        strTemp = strTemp + ReferenceId.ToString() + new String(' ', 30 - ReferenceId.ToString().Length);
                        strTemp = strTemp + strAmtUs + strAmtCan + Mhsrc;
                        outList.Add(strTemp.ToString());
                    }
                    string[] lines = outList.ToArray();
                    System.IO.File.WriteAllLines(@strFileNameY, lines);
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            ///////////////////////////////////////////////
            // Do No
            ///////////////////////////////////////////////
            try
            {
                Dictionary<string, object> parameters2 = new Dictionary<string, object>();
        //      parameters2.Add("@skipEmailYN", SkipEmail);
                parameters2.Add("@ContribYn", ContribYn);
                DataSet rsY = EntityProvider.ExecuteCommand("dbo.trav_ArQtrlContributionRptExp_proc_CSI", this.CompId, true, parameters2, null);
                DataTable dtY = rsY.Tables[0];
                for (int i = 0; i < dtY.Rows.Count - 1; i++)
                {
                    string FellowID = Convert.ToString(dtY.Rows[i]["FellowID"]);
                    string Zip = Convert.ToString(dtY.Rows[i]["Zip"]);
                    string Country = Convert.ToString(dtY.Rows[i]["Country"]);
                    string groupName = Convert.ToString(dtY.Rows[i]["groupName"]);
                    string GroupCity = Convert.ToString(dtY.Rows[i]["GroupCity"]);
                    string GroupState = Convert.ToString(dtY.Rows[i]["GroupState"]);
                    string Language = Convert.ToString(dtY.Rows[i]["Language"]);

                    string District = Convert.ToString(dtY.Rows[i]["District"]);
                    if (District.Length < 2)
                        District = "  ";
                    else
                        District = District.Trim().Substring(0, 2);

                    string City = Convert.ToString(dtY.Rows[i]["City"]);
                    string State = Convert.ToString(dtY.Rows[i]["State"]);
                    string Area = Convert.ToString(dtY.Rows[i]["Area"]);
                    string LastName = Convert.ToString(dtY.Rows[i]["LastName"]);
                    string FirstName = Convert.ToString(dtY.Rows[i]["FirstName"]);
                    string Addr1 = Convert.ToString(dtY.Rows[i]["Addr1"]);
                    string Addr2 = Convert.ToString(dtY.Rows[i]["Addr2"]);
                    string Addr3 = Convert.ToString(dtY.Rows[i]["Addr3"]);
                    string USAmt = Convert.ToString(dtY.Rows[i]["USAmt"]);
                    string CadAmt = Convert.ToString(dtY.Rows[i]["CadAmt"]);
                    string CheckDate = Convert.ToString(dtY.Rows[i]["CheckDate"]);
                    string ReferenceId = Convert.ToString(dtY.Rows[i]["ReferenceId"]);
                    string Mhsrc = Convert.ToString(dtY.Rows[i]["Mhsrc"]);

                    if (currFellowID != FellowID)
                    {
                        strSetup = Language + new String(' ', 2 - Language.Length) + FellowID + District + new String(' ', 2 - District.Length) + Area + new String(' ', 8 - Area.Length) + ContribYn;
                        strTemp = "H0" + strSetup + str40 + str30 + str30 + str30 + str8;
                        outList.Add(strTemp.ToString());
                        strTemp = "H1" + strSetup + LastName + new String(' ', 40 - LastName.Length) + FirstName + new String(' ', 30 - FirstName.Length) + str30 + str30 + str8;
                        outList.Add(strTemp.ToString());
                        strTemp = "H2" + strSetup + Addr1 + new String(' ', 40 - Addr1.Length) + Addr2 + new String(' ', 30 - Addr2.Length) + Addr3 + new String(' ', 30 - Addr3.Length) + str30 + str8;
                        outList.Add(strTemp.ToString());
                        strTemp = "H3" + strSetup + City + new String(' ', 40 - City.Length) + State + new String(' ', 30 - State.Length) + Zip + new String(' ', 30 - Zip.Length) + Country + new String(' ', 30 - Country.Length) + str8;
                        outList.Add(strTemp.ToString());
                        strTemp = "H4" + strSetup + groupName + new String(' ', 40 - groupName.Length) + GroupCity + new String(' ', 30 - GroupCity.Length) + GroupState + new String(' ', 30 - GroupState.Length) + str30 + str8;
                        outList.Add(strTemp.ToString());
        //                strTemp = "H5" + strSetup + strMonth + strDate + str30 + str30 + str8;
                        outList.Add(strTemp.ToString());
                        currFellowID = FellowID;
                    }
                    else
                    {
                        strSetup = Language + new String(' ', 2 - Language.Length) + FellowID + District + new String(' ', 2 - District.Length) + Area + new String(' ', 8 - Area.Length) + ContribYn;
                    }
                    if (ContribYn == true)
                    {
                        strAmtUs = "";
                        strAmtCan = "";
                        strAmtUs = string.Format("{0:0.00}", USAmt);
                        strAmtCan = string.Format("{0:0.00}", CadAmt);
                        strTemp = "";
                        strTemp = "DD" + strSetup;
                        strTemp = strTemp + CheckDate + new String(' ', 32);
                        strTemp = strTemp + ReferenceId.ToString() + new String(' ', 30 - ReferenceId.ToString().Length);
                        strTemp = strTemp + strAmtUs + strAmtCan + Mhsrc;
                        outList.Add(strTemp.ToString());
                    }
                    string[] lines = outList.ToArray();
                    System.IO.File.WriteAllLines(@strFileNameN, lines);
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private void travLabel4_Click(object sender, EventArgs e)
        {

        }//end generateTxt
    } // public class end
} // namespace end
