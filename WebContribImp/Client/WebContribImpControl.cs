using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using DevExpress.Utils;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using TRAVERSE.Client;
using TRAVERSE.Business.WebContribImp;
using TRAVERSE.Business;
using TRAVERSE.Controls;
using System;

namespace CSI.AAWSctb.Client.WebContribImp
{

    public class WebContribImpControl : PluginControlBase
    {
        private BindingSource webContribImpBindingSource;
        private IContainer components;
        private TravNavigator travNavCode;
        private TravLayoutControl travLayoutControl1;
        private LayoutControlGroup layoutControlGroup1;
        private TravLookupControl lkpBatchId;
        //private GridView travLookupControl1View;
        private TravTextBox travTextBox1;
        private LayoutControlItem layoutControlItem1;
        private LayoutControlItem layoutControlItem2;
        private WebContribImpProvider _provider;
        private TravTextBox travTextBox2;
        private TravCheckBox travCheckBox1;
        private LayoutControlItem layoutControlItem3;
        private LayoutControlItem layoutControlItem4;
        private EmptySpaceItem emptySpaceItem3;
        private EmptySpaceItem emptySpaceItem1;
        private TravLayoutControl travLayoutControl2;
        private LayoutControlGroup layoutControlGroup2;
        private TravTextBox travTextBox4;
        private TravTextBox travTextBox3;
        private LayoutControlItem layoutControlItem5;
        private LayoutControlItem layoutControlItem6;
        private TravLabel travLabel1;
        private LayoutControlItem layoutControlItem8;
        private TravCheckBox travCheckBox2;
        private TravLabel travLabel2;
        private LayoutControlItem layoutControlItem9;
        private LayoutControlItem layoutControlItem10;
        private TravCheckBox travCheckBox3;
        private LayoutControlItem layoutControlItem11;
        private TravLabel travLabel3;
        private LayoutControlItem layoutControlItem12;
        private TravTextBox travTextBox6;
        private LayoutControlItem layoutControlItem13;
        private EmptySpaceItem emptySpaceItem2;
        private TravLabel travLabel6;
        private TravLabel travLabel5;
        private TravLabel travLabel4;
        private LayoutControlItem layoutControlItem14;
        private LayoutControlItem layoutControlItem15;
        private LayoutControlItem layoutControlItem16;
        private TravLabel travLabel7;
        private LayoutControlItem layoutControlItem17;
        private TravLabel travLabel8;
        private LayoutControlItem layoutControlItem18;
        private TravLabel travLabel9;
        private LayoutControlItem layoutControlItem19;
        private TravTextBox travTextBox7;
        private LayoutControlItem layoutControlItem20;
        private TravTextBox travTextBox8;
        private LayoutControlItem layoutControlItem21;
        private TravTextBox travTextBox9;
        private LayoutControlItem layoutControlItem22;
        private TravLabel travLabel10;
        private LayoutControlItem layoutControlItem23;
        private EmptySpaceItem emptySpaceItem5;
        private TravLabel travLabel12;
        private TravLabel travLabel11;
        private LayoutControlItem layoutControlItem24;
        private LayoutControlItem layoutControlItem25;
        private TravLabel travLabel14;
        private TravLabel travLabel13;
        private LayoutControlItem layoutControlItem26;
        private LayoutControlItem layoutControlItem27;
        private TravLabel travLabel15;
        private LayoutControlItem layoutControlItem28;
        private TravLabel travLabel16;
        private LayoutControlItem layoutControlItem29;
        private TravTextBox travTextBox10;
        private LayoutControlItem layoutControlItem30;
        private TravComboBox travComboBox1;
        private LayoutControlItem layoutControlItem31;
        private EmptySpaceItem emptySpaceItem7;
        private EmptySpaceItem emptySpaceItem8;
        private TravComboBoxAdv travComboBoxAdv1;
        private LayoutControlItem layoutControlItem32;
        private TravTextBox travTextBox5;
        private LayoutControlItem layoutControlItem7;
        private TravComboBox travComboBox2;
        private LayoutControlItem layoutControlItem33;
        private EmptySpaceItem emptySpaceItem4;
        private EmptySpaceItem emptySpaceItem10;
        private EmptySpaceItem emptySpaceItem9;
        private TravLabel travLabel17;
        private LayoutControlItem layoutControlItem34;
        private TravLabel travLabel18;
        private LayoutControlItem layoutControlItem35;
        private TravComboBox travComboBox3;
        private LayoutControlItem layoutControlItem36;
        private TravComboBox travComboBox4;
        private LayoutControlItem layoutControlItem37;
        private TravLabel travLabel19;
        private LayoutControlItem layoutControlItem38;
        private TravTextBox travTextBox11;
        private LayoutControlItem layoutControlItem39;
        private EmptySpaceItem emptySpaceItem6;
        private EmptySpaceItem emptySpaceItem11;
        private EmptySpaceItem emptySpaceItem12;
        private EmptySpaceItem emptySpaceItem13;
        private EmptySpaceItem emptySpaceItem14;
        public RepositoryItemTravLookupControl rlkpGroupId;

        public WebContribImpControl()
            : this(null)
        {
        }
        public WebContribImpControl(IPlugin host)
        {

            this._provider = new WebContribImpProvider();
            InitializeComponent();
            base.HostPlugin = host;
            this.BindingSource = webContribImpBindingSource;
            this.travNavCode.Preview += new EventHandler(travNavCode_Preview);

            this.travNavCode.RefreshData += new EventHandler(this.travNavCode_RefreshData);
            this.BindingSource.AddingNew += new AddingNewEventHandler(this.BindingSource_AddingNew);
         //   this.gridView1.CellValueChanged += new CellValueChangedEventHandler(this.dgvCode_CellValueChanged);
          //  this.gridView1.CustomRowCellEditForEditing += new CustomRowCellEditEventHandler(this.gridView1_CustomRowCellEditForEditing);


        }
        protected override void LoadData()
        {

            this.Provider = this._provider;
            this.webContribImpBindingSource.RaiseListChangedEvents = false;
            this.webContribImpBindingSource.DataSource = this._provider.Load(this.CompId);
            this.webContribImpBindingSource.RaiseListChangedEvents = true;
            this.webContribImpBindingSource.ResetBindings(true);

        }
        protected override void OnLoad(EventArgs e)
        {
            try
            {
                this.CompId = this.HostPlugin.DatabaseName;
                this.LoadData();
            //    this.gridView1.OptionsSelection.InvertSelection = true;
                this.rlkpGroupId = new RepositoryItemTravLookupControl();
                this.SetGroupIdControl();

            }
            catch (Exception exception)
            {
                ClientContext.HandleError(exception, this);
            }
            base.OnLoad(e);
        }
        private void travNavCode_Preview(object sender, EventArgs e)
        {
            try
            {
                this.OntravNavCodePreview(e);
            }
            catch (Exception exception)
            {
                ClientContext.HandleError(exception, this);
            }
        }
        private void travNavCode_RefreshData(object sender, EventArgs e)
        {
            try
            {
                this.travNavCodeRefreshData(e);
            }
            catch (SqlException exception)
            {
                ClientContext.HandleError(exception, this);
            }
            catch (Exception exception2)
            {
                ClientContext.HandleError(exception2, this);
            }
        }
        private void BindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            try
            {
                this.OnWebContribImpAddingNew(e);
            }
            catch (Exception exception)
            {
                ClientContext.HandleError(exception, this);
            }
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.travNavCode != null)
                {
                    this.travNavCode.RefreshData -= new EventHandler(this.travNavCode_RefreshData);
                    this.travNavCode.Preview -= new EventHandler(this.travNavCode_Preview);
                    this.travNavCode.Dispose();
                    this.travNavCode = null;
                }
                this.BindingSource.AddingNew -= new AddingNewEventHandler(this.BindingSource_AddingNew);
         //       this.gridView1.CellValueChanged -= new CellValueChangedEventHandler(this.dgvCode_CellValueChanged);
                if (this.components != null)
                {
                    this.components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
        private void dgvCode_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            try
            {
                this.OndgvCodeCellValueChanged(e);
            }
            catch (Exception exception)
            {
                ClientContext.HandleError(exception, this);
            }
        }

        public virtual void OntravNavCodePreview(EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
       //     this.dgvCode.ShowPrintPreview();
            this.Cursor = Cursors.Default;

        }

        public virtual void travNavCodeRefreshData(EventArgs e)
        {
            this.LoadData();
        }

        public virtual void OnWebContribImpAddingNew(AddingNewEventArgs e)
        {
            e.NewObject = new TRAVERSE.Business.WebContribImp.WebContribImp();
        }
        public virtual void OndgvCodeCellValueChanged(CellValueChangedEventArgs e)
        {

        //    this.dgvCode.FindRowByKey(this.colId, e);

        }
        private void gridView1_CustomRowCellEditForEditing(object sender, CustomRowCellEditEventArgs e)
        {
            try
            {
                this.OngridView1CustomRowCellEditForEditing(e);
            }
            catch (Exception exception)
            {
                ClientContext.HandleError(exception, this);
            }
        }

        protected virtual void SetGroupIdControl()
        {

            this.rlkpGroupId.LookupDefinitionId = "Customer";
            this.rlkpGroupId.LoadList(this.CompId);
            base.SetupMaintControl(this.rlkpGroupId, 0xf4376);
        }
        public virtual void OngridView1CustomRowCellEditForEditing(CustomRowCellEditEventArgs e)
        {
            e.Column.OptionsColumn.ReadOnly = false;
     /*       if (e.Column.Equals(this.colGroupId))
            {

                e.RepositoryItem = this.rlkpGroupId;


            }
     */ }

        protected override void UpdateData(int index)
        {
            try
            {
                if (index < 0)
                {
                    //persist delete operation
                    if (_provider.Items.IsDeletedCount > 0)
                    {
                        _provider.Update(this.CompId);
                    }
                }
                else
                {
                    //persist add/edit operations
                    if (_provider[index].IsDirty)
                    {
                        //validate the item
                        _provider[index].Validate();

                        //if valid, update the database
                        if (_provider[index].IsValid)
                            _provider.Update(this.CompId);
                    }
                    //clear error
                    _provider[index].SetErrorText(null);
                }
            }
            catch (ProviderException pex)
            {
                if (index > -1)
                    _provider[index].SetErrorText(pex.Message);
                ClientContext.HandleError(pex, this);
            }
            catch (Exception ex)
            {
                ClientContext.HandleError(ex, this);
            }
            finally
            {
                if (_provider.Items.IsDeletedCount > 0)
                {
                    _provider.Items.AddRange(_provider.Items.DeletedItems);
                    _provider.Items.DeletedItems.Clear();
                    this.BindingSource.ResetBindings(false);
                }
                EntityProvider.InvalidateLookupObject("WebContribImp");
            }
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.travNavCode = new TRAVERSE.Controls.TravNavigator(this.components);
            this.travLayoutControl1 = new TRAVERSE.Controls.TravLayoutControl();
            this.travTextBox2 = new TRAVERSE.Controls.TravTextBox();
            this.travCheckBox1 = new TRAVERSE.Controls.TravCheckBox();
            this.lkpBatchId = new TRAVERSE.Controls.TravLookupControl();
            this.travTextBox1 = new TRAVERSE.Controls.TravTextBox();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.travLayoutControl2 = new TRAVERSE.Controls.TravLayoutControl();
            this.travTextBox10 = new TRAVERSE.Controls.TravTextBox();
            this.travLabel16 = new TRAVERSE.Controls.TravLabel();
            this.travLabel15 = new TRAVERSE.Controls.TravLabel();
            this.travLabel14 = new TRAVERSE.Controls.TravLabel();
            this.travLabel13 = new TRAVERSE.Controls.TravLabel();
            this.travLabel12 = new TRAVERSE.Controls.TravLabel();
            this.travLabel11 = new TRAVERSE.Controls.TravLabel();
            this.travLabel10 = new TRAVERSE.Controls.TravLabel();
            this.travTextBox9 = new TRAVERSE.Controls.TravTextBox();
            this.travTextBox8 = new TRAVERSE.Controls.TravTextBox();
            this.travTextBox7 = new TRAVERSE.Controls.TravTextBox();
            this.travLabel8 = new TRAVERSE.Controls.TravLabel();
            this.travLabel7 = new TRAVERSE.Controls.TravLabel();
            this.travLabel6 = new TRAVERSE.Controls.TravLabel();
            this.travLabel5 = new TRAVERSE.Controls.TravLabel();
            this.travTextBox6 = new TRAVERSE.Controls.TravTextBox();
            this.travLabel3 = new TRAVERSE.Controls.TravLabel();
            this.travCheckBox3 = new TRAVERSE.Controls.TravCheckBox();
            this.travCheckBox2 = new TRAVERSE.Controls.TravCheckBox();
            this.travLabel9 = new TRAVERSE.Controls.TravLabel();
            this.travLabel2 = new TRAVERSE.Controls.TravLabel();
            this.travLabel1 = new TRAVERSE.Controls.TravLabel();
            this.travTextBox4 = new TRAVERSE.Controls.TravTextBox();
            this.travLabel4 = new TRAVERSE.Controls.TravLabel();
            this.travTextBox3 = new TRAVERSE.Controls.TravTextBox();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem5 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.travComboBox1 = new TRAVERSE.Controls.TravComboBox();
            this.emptySpaceItem7 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem8 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.travComboBoxAdv1 = new TRAVERSE.Controls.TravComboBoxAdv();
            this.travTextBox5 = new TRAVERSE.Controls.TravTextBox();
            this.travComboBox2 = new TRAVERSE.Controls.TravComboBox();
            this.emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem9 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem10 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.travLabel17 = new TRAVERSE.Controls.TravLabel();
            this.travLabel18 = new TRAVERSE.Controls.TravLabel();
            this.travComboBox3 = new TRAVERSE.Controls.TravComboBox();
            this.travComboBox4 = new TRAVERSE.Controls.TravComboBox();
            this.travLabel19 = new TRAVERSE.Controls.TravLabel();
            this.travTextBox11 = new TRAVERSE.Controls.TravTextBox();
            this.emptySpaceItem6 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem11 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem12 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.webContribImpBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem12 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem13 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem15 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem16 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem17 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem18 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem19 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem23 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem14 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem25 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem26 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem27 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem28 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem29 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem30 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem32 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem31 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem33 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem24 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem34 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem35 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem36 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem37 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem38 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem39 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem21 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem20 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem22 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem13 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem14 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.splitContainerBase.Panel1.SuspendLayout();
            this.splitContainerBase.Panel2.SuspendLayout();
            this.splitContainerBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.travNavCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.travLayoutControl1)).BeginInit();
            this.travLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.travTextBox2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.travCheckBox1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpBatchId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.travTextBox1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.travLayoutControl2)).BeginInit();
            this.travLayoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.travTextBox10.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.travTextBox9.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.travTextBox8.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.travTextBox7.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.travTextBox6.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.travCheckBox3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.travCheckBox2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.travTextBox4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.travTextBox3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.travComboBox1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.travComboBoxAdv1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.travTextBox5.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.travComboBox2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.travComboBox3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.travComboBox4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.travTextBox11.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.webContribImpBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem30)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem32)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem31)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem33)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem34)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem35)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem36)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem37)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem38)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem39)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem14)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerBase
            // 
            this.splitContainerBase.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerBase.Panel1
            // 
            this.splitContainerBase.Panel1.Controls.Add(this.travLayoutControl1);
            this.splitContainerBase.Panel1.Controls.Add(this.travNavCode);
            // 
            // splitContainerBase.Panel2
            // 
            this.splitContainerBase.Panel2.Controls.Add(this.travLayoutControl2);
            this.splitContainerBase.Panel2Collapsed = false;
            this.splitContainerBase.SplitterDistance = 58;
            // 
            // travNavCode
            // 
            this.travNavCode.BackColor = System.Drawing.SystemColors.Control;
            this.travNavCode.BindingSource = this.webContribImpBindingSource;
            this.travNavCode.CountFormat = "of {0}";
            this.travNavCode.DisableDataEvents = false;
            this.travNavCode.DisplayDeleteVerification = true;
            this.travNavCode.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F);
            this.travNavCode.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.travNavCode.Location = new System.Drawing.Point(0, 0);
            this.travNavCode.Name = "travNavCode";
            this.travNavCode.ShowSmallIcons = false;
            this.travNavCode.Size = new System.Drawing.Size(800, 25);
            this.travNavCode.SourceControl = null;
            this.travNavCode.TabIndex = 1;
            this.travNavCode.Text = "travNavigator1";
            // 
            // travLayoutControl1
            // 
            this.travLayoutControl1.AllowCustomizationMenu = false;
            this.travLayoutControl1.Controls.Add(this.travTextBox2);
            this.travLayoutControl1.Controls.Add(this.travCheckBox1);
            this.travLayoutControl1.Controls.Add(this.lkpBatchId);
            this.travLayoutControl1.Controls.Add(this.travTextBox1);
            this.travLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.travLayoutControl1.Location = new System.Drawing.Point(0, 25);
            this.travLayoutControl1.Name = "travLayoutControl1";
            this.travLayoutControl1.OptionsFocus.MoveFocusDirection = DevExpress.XtraLayout.MoveFocusDirection.DownThenAcross;
            this.travLayoutControl1.Root = this.layoutControlGroup1;
            this.travLayoutControl1.Size = new System.Drawing.Size(800, 33);
            this.travLayoutControl1.TabIndex = 2;
            this.travLayoutControl1.Text = "travLayoutControl1";
            // 
            // travTextBox2
            // 
            this.travTextBox2.Location = new System.Drawing.Point(445, 7);
            this.travTextBox2.Name = "travTextBox2";
            this.travTextBox2.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.travTextBox2.Properties.FixedPointFormat = false;
            this.travTextBox2.Properties.NumericControl = false;
            this.travTextBox2.Properties.NumericPrecision = -1;
            this.travTextBox2.Properties.SetupFunctionId = 0;
            this.travTextBox2.SecurityId = null;
            this.travTextBox2.Size = new System.Drawing.Size(66, 20);
            this.travTextBox2.StyleController = this.travLayoutControl1;
            this.travTextBox2.TabIndex = 6;
            this.travTextBox2.EditValueChanged += new System.EventHandler(this.travTextBox2_EditValueChanged);
            // 
            // travCheckBox1
            // 
            this.travCheckBox1.Location = new System.Drawing.Point(633, 7);
            this.travCheckBox1.Name = "travCheckBox1";
            this.travCheckBox1.Properties.Caption = "";
            this.travCheckBox1.SecurityId = null;
            this.travCheckBox1.Size = new System.Drawing.Size(51, 19);
            this.travCheckBox1.StyleController = this.travLayoutControl1;
            this.travCheckBox1.TabIndex = 7;
            // 
            // lkpBatchId
            // 
            this.lkpBatchId.EditValue = "";
            this.lkpBatchId.Location = new System.Drawing.Point(172, 7);
            this.lkpBatchId.Name = "lkpBatchId";
            this.lkpBatchId.PopupSize = new System.Drawing.Size(0, 0);
            this.lkpBatchId.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.lkpBatchId.Properties.DisablePopup = false;
            this.lkpBatchId.Properties.LimitToList = false;
            this.lkpBatchId.Properties.LookupDefinitionId = null;
            this.lkpBatchId.Properties.NullText = "";
            this.lkpBatchId.Properties.PopupFormMinSize = new System.Drawing.Size(500, 50);
            this.lkpBatchId.Properties.SetupFunctionId = 0;
            this.lkpBatchId.Properties.SimpleMask = null;
            this.lkpBatchId.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lkpBatchId.Size = new System.Drawing.Size(71, 20);
            this.lkpBatchId.StyleController = this.travLayoutControl1;
            this.lkpBatchId.TabIndex = 5;
            // 
            // travTextBox1
            // 
            this.travTextBox1.Location = new System.Drawing.Point(309, 7);
            this.travTextBox1.Name = "travTextBox1";
            this.travTextBox1.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.travTextBox1.Properties.FixedPointFormat = false;
            this.travTextBox1.Properties.NumericControl = false;
            this.travTextBox1.Properties.NumericPrecision = -1;
            this.travTextBox1.Properties.SetupFunctionId = 0;
            this.travTextBox1.SecurityId = null;
            this.travTextBox1.Size = new System.Drawing.Size(70, 20);
            this.travTextBox1.StyleController = this.travLayoutControl1;
            this.travTextBox1.TabIndex = 4;
            this.travTextBox1.EditValueChanged += new System.EventHandler(this.travTextBox1_EditValueChanged);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3,
            this.layoutControlItem2,
            this.layoutControlItem1,
            this.layoutControlItem4,
            this.emptySpaceItem3,
            this.emptySpaceItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(800, 33);
            this.layoutControlGroup1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.CustomizationFormText = "emptySpaceItem3";
            this.emptySpaceItem3.Location = new System.Drawing.Point(688, 0);
            this.emptySpaceItem3.MinSize = new System.Drawing.Size(110, 30);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(110, 31);
            this.emptySpaceItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem3.Text = "emptySpaceItem3";
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 0);
            this.emptySpaceItem1.MinSize = new System.Drawing.Size(110, 30);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(110, 31);
            this.emptySpaceItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // travLayoutControl2
            // 
            this.travLayoutControl2.AllowCustomizationMenu = false;
            this.travLayoutControl2.Controls.Add(this.travTextBox11);
            this.travLayoutControl2.Controls.Add(this.travLabel19);
            this.travLayoutControl2.Controls.Add(this.travComboBox4);
            this.travLayoutControl2.Controls.Add(this.travComboBox3);
            this.travLayoutControl2.Controls.Add(this.travLabel17);
            this.travLayoutControl2.Controls.Add(this.travComboBox2);
            this.travLayoutControl2.Controls.Add(this.travTextBox5);
            this.travLayoutControl2.Controls.Add(this.travComboBoxAdv1);
            this.travLayoutControl2.Controls.Add(this.travLabel18);
            this.travLayoutControl2.Controls.Add(this.travComboBox1);
            this.travLayoutControl2.Controls.Add(this.travLabel16);
            this.travLayoutControl2.Controls.Add(this.travLabel15);
            this.travLayoutControl2.Controls.Add(this.travLabel14);
            this.travLayoutControl2.Controls.Add(this.travLabel13);
            this.travLayoutControl2.Controls.Add(this.travLabel12);
            this.travLayoutControl2.Controls.Add(this.travLabel11);
            this.travLayoutControl2.Controls.Add(this.travLabel10);
            this.travLayoutControl2.Controls.Add(this.travTextBox9);
            this.travLayoutControl2.Controls.Add(this.travTextBox10);
            this.travLayoutControl2.Controls.Add(this.travTextBox7);
            this.travLayoutControl2.Controls.Add(this.travLabel8);
            this.travLayoutControl2.Controls.Add(this.travLabel7);
            this.travLayoutControl2.Controls.Add(this.travLabel6);
            this.travLayoutControl2.Controls.Add(this.travTextBox8);
            this.travLayoutControl2.Controls.Add(this.travLabel5);
            this.travLayoutControl2.Controls.Add(this.travTextBox6);
            this.travLayoutControl2.Controls.Add(this.travLabel3);
            this.travLayoutControl2.Controls.Add(this.travCheckBox3);
            this.travLayoutControl2.Controls.Add(this.travCheckBox2);
            this.travLayoutControl2.Controls.Add(this.travLabel9);
            this.travLayoutControl2.Controls.Add(this.travLabel2);
            this.travLayoutControl2.Controls.Add(this.travLabel1);
            this.travLayoutControl2.Controls.Add(this.travTextBox4);
            this.travLayoutControl2.Controls.Add(this.travLabel4);
            this.travLayoutControl2.Controls.Add(this.travTextBox3);
            this.travLayoutControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.travLayoutControl2.Location = new System.Drawing.Point(0, 0);
            this.travLayoutControl2.Name = "travLayoutControl2";
            this.travLayoutControl2.OptionsFocus.MoveFocusDirection = DevExpress.XtraLayout.MoveFocusDirection.DownThenAcross;
            this.travLayoutControl2.Root = this.layoutControlGroup2;
            this.travLayoutControl2.Size = new System.Drawing.Size(800, 540);
            this.travLayoutControl2.TabIndex = 0;
            this.travLayoutControl2.Text = "travLayoutControl2";
            // 
            // travTextBox10
            // 
            this.travTextBox10.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.webContribImpBindingSource, "PmtDate", true));
            this.travTextBox10.Location = new System.Drawing.Point(504, 31);
            this.travTextBox10.Name = "travTextBox10";
            this.travTextBox10.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.travTextBox10.Properties.FixedPointFormat = false;
            this.travTextBox10.Properties.NumericControl = false;
            this.travTextBox10.Properties.NumericPrecision = -1;
            this.travTextBox10.Properties.SetupFunctionId = 0;
            this.travTextBox10.SecurityId = null;
            this.travTextBox10.Size = new System.Drawing.Size(64, 20);
            this.travTextBox10.StyleController = this.travLayoutControl2;
            this.travTextBox10.TabIndex = 29;
            // 
            // travLabel16
            // 
            this.travLabel16.Location = new System.Drawing.Point(733, 7);
            this.travLabel16.Name = "travLabel16";
            this.travLabel16.SecurityId = null;
            this.travLabel16.Size = new System.Drawing.Size(61, 13);
            this.travLabel16.StyleController = this.travLayoutControl2;
            this.travLabel16.TabIndex = 28;
            this.travLabel16.Text = "Rpt Exch";
            // 
            // travLabel15
            // 
            this.travLabel15.Location = new System.Drawing.Point(650, 7);
            this.travLabel15.Name = "travLabel15";
            this.travLabel15.SecurityId = null;
            this.travLabel15.Size = new System.Drawing.Size(72, 13);
            this.travLabel15.StyleController = this.travLayoutControl2;
            this.travLabel15.TabIndex = 27;
            this.travLabel15.Text = "Amount";
            // 
            // travLabel14
            // 
            this.travLabel14.Location = new System.Drawing.Point(578, 7);
            this.travLabel14.Name = "travLabel14";
            this.travLabel14.SecurityId = null;
            this.travLabel14.Size = new System.Drawing.Size(61, 13);
            this.travLabel14.StyleController = this.travLayoutControl2;
            this.travLabel14.TabIndex = 26;
            this.travLabel14.Text = "Pmt Method";
            // 
            // travLabel13
            // 
            this.travLabel13.Location = new System.Drawing.Point(503, 7);
            this.travLabel13.Name = "travLabel13";
            this.travLabel13.SecurityId = null;
            this.travLabel13.Size = new System.Drawing.Size(64, 13);
            this.travLabel13.StyleController = this.travLayoutControl2;
            this.travLabel13.TabIndex = 25;
            this.travLabel13.Text = "Pmt Date";
            // 
            // travLabel12
            // 
            this.travLabel12.Location = new System.Drawing.Point(425, 7);
            this.travLabel12.Name = "travLabel12";
            this.travLabel12.SecurityId = null;
            this.travLabel12.Size = new System.Drawing.Size(67, 13);
            this.travLabel12.StyleController = this.travLayoutControl2;
            this.travLabel12.TabIndex = 24;
            this.travLabel12.Text = "Area";
            // 
            // travLabel11
            // 
            this.travLabel11.Location = new System.Drawing.Point(146, 62);
            this.travLabel11.Name = "travLabel11";
            this.travLabel11.SecurityId = null;
            this.travLabel11.Size = new System.Drawing.Size(105, 19);
            this.travLabel11.StyleController = this.travLayoutControl2;
            this.travLabel11.TabIndex = 23;
            this.travLabel11.Text = "Contributor Name";
            // 
            // travLabel10
            // 
            this.travLabel10.Location = new System.Drawing.Point(146, 7);
            this.travLabel10.Name = "travLabel10";
            this.travLabel10.SecurityId = null;
            this.travLabel10.Size = new System.Drawing.Size(268, 13);
            this.travLabel10.StyleController = this.travLayoutControl2;
            this.travLabel10.TabIndex = 22;
            this.travLabel10.Text = "Group ID";
            // 
            // travTextBox9
            // 
            this.travTextBox9.Location = new System.Drawing.Point(146, 185);
            this.travTextBox9.Name = "travTextBox9";
            this.travTextBox9.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.travTextBox9.Properties.FixedPointFormat = false;
            this.travTextBox9.Properties.NumericControl = false;
            this.travTextBox9.Properties.NumericPrecision = -1;
            this.travTextBox9.Properties.SetupFunctionId = 0;
            this.travTextBox9.SecurityId = null;
            this.travTextBox9.Size = new System.Drawing.Size(478, 20);
            this.travTextBox9.StyleController = this.travLayoutControl2;
            this.travTextBox9.TabIndex = 21;
            // 
            // travTextBox8
            // 
            this.travTextBox8.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.webContribImpBindingSource, "Addr2", true));
            this.travTextBox8.Location = new System.Drawing.Point(146, 154);
            this.travTextBox8.Name = "travTextBox8";
            this.travTextBox8.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.travTextBox8.Properties.FixedPointFormat = false;
            this.travTextBox8.Properties.NumericControl = false;
            this.travTextBox8.Properties.NumericPrecision = -1;
            this.travTextBox8.Properties.SetupFunctionId = 0;
            this.travTextBox8.SecurityId = null;
            this.travTextBox8.Size = new System.Drawing.Size(478, 20);
            this.travTextBox8.StyleController = this.travLayoutControl2;
            this.travTextBox8.TabIndex = 20;
            // 
            // travTextBox7
            // 
            this.travTextBox7.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.webContribImpBindingSource, "Addr1", true));
            this.travTextBox7.Location = new System.Drawing.Point(146, 123);
            this.travTextBox7.Name = "travTextBox7";
            this.travTextBox7.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.travTextBox7.Properties.FixedPointFormat = false;
            this.travTextBox7.Properties.NumericControl = false;
            this.travTextBox7.Properties.NumericPrecision = -1;
            this.travTextBox7.Properties.SetupFunctionId = 0;
            this.travTextBox7.SecurityId = null;
            this.travTextBox7.Size = new System.Drawing.Size(478, 20);
            this.travTextBox7.StyleController = this.travLayoutControl2;
            this.travTextBox7.TabIndex = 19;
            // 
            // travLabel8
            // 
            this.travLabel8.Location = new System.Drawing.Point(62, 331);
            this.travLabel8.Name = "travLabel8";
            this.travLabel8.SecurityId = null;
            this.travLabel8.Size = new System.Drawing.Size(73, 13);
            this.travLabel8.StyleController = this.travLayoutControl2;
            this.travLabel8.TabIndex = 17;
            this.travLabel8.Text = "State";
            // 
            // travLabel7
            // 
            this.travLabel7.Location = new System.Drawing.Point(62, 277);
            this.travLabel7.Name = "travLabel7";
            this.travLabel7.SecurityId = null;
            this.travLabel7.Size = new System.Drawing.Size(73, 13);
            this.travLabel7.StyleController = this.travLayoutControl2;
            this.travLabel7.TabIndex = 16;
            this.travLabel7.Text = "CC Number";
            // 
            // travLabel6
            // 
            this.travLabel6.Location = new System.Drawing.Point(62, 253);
            this.travLabel6.Name = "travLabel6";
            this.travLabel6.SecurityId = null;
            this.travLabel6.Size = new System.Drawing.Size(73, 13);
            this.travLabel6.StyleController = this.travLayoutControl2;
            this.travLabel6.TabIndex = 15;
            this.travLabel6.Text = "CC Holder";
            // 
            // travLabel5
            // 
            this.travLabel5.Location = new System.Drawing.Point(62, 229);
            this.travLabel5.Name = "travLabel5";
            this.travLabel5.SecurityId = null;
            this.travLabel5.Size = new System.Drawing.Size(73, 13);
            this.travLabel5.StyleController = this.travLayoutControl2;
            this.travLabel5.TabIndex = 14;
            this.travLabel5.Text = "Group City";
            // 
            // travTextBox6
            // 
            this.travTextBox6.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.webContribImpBindingSource, "Id", true));
            this.travTextBox6.Location = new System.Drawing.Point(32, 141);
            this.travTextBox6.Name = "travTextBox6";
            this.travTextBox6.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.travTextBox6.Properties.FixedPointFormat = false;
            this.travTextBox6.Properties.NumericControl = false;
            this.travTextBox6.Properties.NumericPrecision = -1;
            this.travTextBox6.Properties.SetupFunctionId = 0;
            this.travTextBox6.SecurityId = null;
            this.travTextBox6.Size = new System.Drawing.Size(78, 20);
            this.travTextBox6.StyleController = this.travLayoutControl2;
            this.travTextBox6.TabIndex = 12;
            // 
            // travLabel3
            // 
            this.travLabel3.Location = new System.Drawing.Point(37, 117);
            this.travLabel3.Name = "travLabel3";
            this.travLabel3.SecurityId = null;
            this.travLabel3.Size = new System.Drawing.Size(98, 13);
            this.travLabel3.StyleController = this.travLayoutControl2;
            this.travLabel3.TabIndex = 11;
            this.travLabel3.Text = "Contributor Address";
            // 
            // travCheckBox3
            // 
            this.travCheckBox3.Location = new System.Drawing.Point(68, 87);
            this.travCheckBox3.Name = "travCheckBox3";
            this.travCheckBox3.Properties.Caption = "";
            this.travCheckBox3.SecurityId = null;
            this.travCheckBox3.Size = new System.Drawing.Size(67, 19);
            this.travCheckBox3.StyleController = this.travLayoutControl2;
            this.travCheckBox3.TabIndex = 10;
            // 
            // travCheckBox2
            // 
            this.travCheckBox2.Location = new System.Drawing.Point(7, 87);
            this.travCheckBox2.Name = "travCheckBox2";
            this.travCheckBox2.Properties.Caption = "";
            this.travCheckBox2.SecurityId = null;
            this.travCheckBox2.Size = new System.Drawing.Size(50, 19);
            this.travCheckBox2.StyleController = this.travLayoutControl2;
            this.travCheckBox2.TabIndex = 9;
            // 
            // travLabel9
            // 
            this.travLabel9.Location = new System.Drawing.Point(7, 355);
            this.travLabel9.Name = "travLabel9";
            this.travLabel9.SecurityId = null;
            this.travLabel9.Size = new System.Drawing.Size(128, 13);
            this.travLabel9.StyleController = this.travLayoutControl2;
            this.travLabel9.TabIndex = 18;
            this.travLabel9.Text = "Special Acknowledgements";
            // 
            // travLabel2
            // 
            this.travLabel2.Location = new System.Drawing.Point(7, 31);
            this.travLabel2.Name = "travLabel2";
            this.travLabel2.SecurityId = null;
            this.travLabel2.Size = new System.Drawing.Size(128, 20);
            this.travLabel2.StyleController = this.travLayoutControl2;
            this.travLabel2.TabIndex = 8;
            this.travLabel2.Text = "TransId";
            // 
            // travLabel1
            // 
            this.travLabel1.Location = new System.Drawing.Point(7, 7);
            this.travLabel1.Name = "travLabel1";
            this.travLabel1.SecurityId = null;
            this.travLabel1.Size = new System.Drawing.Size(128, 13);
            this.travLabel1.StyleController = this.travLayoutControl2;
            this.travLabel1.TabIndex = 7;
            this.travLabel1.Text = "Web Trans ID";
            // 
            // travTextBox4
            // 
            this.travTextBox4.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.webContribImpBindingSource, "GroupId", true));
            this.travTextBox4.Location = new System.Drawing.Point(146, 31);
            this.travTextBox4.Name = "travTextBox4";
            this.travTextBox4.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.travTextBox4.Properties.FixedPointFormat = false;
            this.travTextBox4.Properties.NumericControl = false;
            this.travTextBox4.Properties.NumericPrecision = -1;
            this.travTextBox4.Properties.SetupFunctionId = 0;
            this.travTextBox4.SecurityId = null;
            this.travTextBox4.Size = new System.Drawing.Size(268, 20);
            this.travTextBox4.StyleController = this.travLayoutControl2;
            this.travTextBox4.TabIndex = 5;
            // 
            // travLabel4
            // 
            this.travLabel4.Location = new System.Drawing.Point(62, 205);
            this.travLabel4.Name = "travLabel4";
            this.travLabel4.SecurityId = null;
            this.travLabel4.Size = new System.Drawing.Size(73, 13);
            this.travLabel4.StyleController = this.travLayoutControl2;
            this.travLabel4.TabIndex = 13;
            this.travLabel4.Text = "Group Name";
            // 
            // travTextBox3
            // 
            this.travTextBox3.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.webContribImpBindingSource, "CustName", true));
            this.travTextBox3.Location = new System.Drawing.Point(146, 92);
            this.travTextBox3.Name = "travTextBox3";
            this.travTextBox3.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.travTextBox3.Properties.FixedPointFormat = false;
            this.travTextBox3.Properties.NumericControl = false;
            this.travTextBox3.Properties.NumericPrecision = -1;
            this.travTextBox3.Properties.SetupFunctionId = 0;
            this.travTextBox3.SecurityId = null;
            this.travTextBox3.Size = new System.Drawing.Size(478, 20);
            this.travTextBox3.StyleController = this.travLayoutControl2;
            this.travTextBox3.TabIndex = 4;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.CustomizationFormText = "layoutControlGroup2";
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem8,
            this.layoutControlItem9,
            this.layoutControlItem10,
            this.layoutControlItem11,
            this.layoutControlItem12,
            this.layoutControlItem13,
            this.layoutControlItem15,
            this.layoutControlItem16,
            this.layoutControlItem17,
            this.layoutControlItem18,
            this.layoutControlItem19,
            this.layoutControlItem23,
            this.layoutControlItem14,
            this.emptySpaceItem5,
            this.layoutControlItem25,
            this.layoutControlItem6,
            this.layoutControlItem26,
            this.layoutControlItem27,
            this.layoutControlItem28,
            this.layoutControlItem29,
            this.layoutControlItem30,
            this.layoutControlItem32,
            this.layoutControlItem31,
            this.layoutControlItem7,
            this.emptySpaceItem2,
            this.layoutControlItem33,
            this.emptySpaceItem8,
            this.emptySpaceItem7,
            this.emptySpaceItem4,
            this.layoutControlItem24,
            this.layoutControlItem5,
            this.layoutControlItem34,
            this.layoutControlItem36,
            this.layoutControlItem37,
            this.layoutControlItem38,
            this.layoutControlItem39,
            this.layoutControlItem21,
            this.emptySpaceItem9,
            this.layoutControlItem20,
            this.layoutControlItem22,
            this.emptySpaceItem10,
            this.emptySpaceItem12,
            this.emptySpaceItem6,
            this.emptySpaceItem11,
            this.layoutControlItem35,
            this.emptySpaceItem13,
            this.emptySpaceItem14});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(800, 540);
            this.layoutControlGroup2.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup2.Text = "layoutControlGroup2";
            this.layoutControlGroup2.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.Location = new System.Drawing.Point(139, 313);
            this.emptySpaceItem2.MinSize = new System.Drawing.Size(110, 30);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(329, 59);
            this.emptySpaceItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem2.Text = "emptySpaceItem2";
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem5
            // 
            this.emptySpaceItem5.CustomizationFormText = "emptySpaceItem5";
            this.emptySpaceItem5.Location = new System.Drawing.Point(0, 294);
            this.emptySpaceItem5.MinSize = new System.Drawing.Size(110, 30);
            this.emptySpaceItem5.Name = "emptySpaceItem5";
            this.emptySpaceItem5.Size = new System.Drawing.Size(139, 30);
            this.emptySpaceItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem5.Text = "emptySpaceItem5";
            this.emptySpaceItem5.TextSize = new System.Drawing.Size(0, 0);
            // 
            // travComboBox1
            // 
            this.travComboBox1.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.webContribImpBindingSource, "PmtMethodId", true));
            this.travComboBox1.Location = new System.Drawing.Point(579, 31);
            this.travComboBox1.Name = "travComboBox1";
            this.travComboBox1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.travComboBox1.Properties.FormatString = null;
            this.travComboBox1.Properties.NumericPrecision = -1;
            this.travComboBox1.Properties.SetupFunctionId = 0;
            this.travComboBox1.SecurityId = null;
            this.travComboBox1.Size = new System.Drawing.Size(60, 20);
            this.travComboBox1.StyleController = this.travLayoutControl2;
            this.travComboBox1.TabIndex = 30;
            // 
            // emptySpaceItem7
            // 
            this.emptySpaceItem7.CustomizationFormText = "emptySpaceItem7";
            this.emptySpaceItem7.Location = new System.Drawing.Point(409, 55);
            this.emptySpaceItem7.MinSize = new System.Drawing.Size(110, 30);
            this.emptySpaceItem7.Name = "emptySpaceItem7";
            this.emptySpaceItem7.Size = new System.Drawing.Size(110, 30);
            this.emptySpaceItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem7.Text = "emptySpaceItem7";
            this.emptySpaceItem7.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem8
            // 
            this.emptySpaceItem8.CustomizationFormText = "emptySpaceItem8";
            this.emptySpaceItem8.Location = new System.Drawing.Point(255, 55);
            this.emptySpaceItem8.MinSize = new System.Drawing.Size(110, 30);
            this.emptySpaceItem8.Name = "emptySpaceItem8";
            this.emptySpaceItem8.Size = new System.Drawing.Size(154, 30);
            this.emptySpaceItem8.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem8.Text = "emptySpaceItem8";
            this.emptySpaceItem8.TextSize = new System.Drawing.Size(0, 0);
            // 
            // travComboBoxAdv1
            // 
            this.travComboBoxAdv1.AllowNullInput = true;
            this.travComboBoxAdv1.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.webContribImpBindingSource, "Area", true));
            this.travComboBoxAdv1.Location = new System.Drawing.Point(425, 31);
            this.travComboBoxAdv1.Name = "travComboBoxAdv1";
            this.travComboBoxAdv1.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.travComboBoxAdv1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.travComboBoxAdv1.Properties.NullText = null;
            this.travComboBoxAdv1.Properties.SetupFunctionId = 0;
            this.travComboBoxAdv1.Properties.ShowHeader = false;
            this.travComboBoxAdv1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.travComboBoxAdv1.SecurityId = null;
            this.travComboBoxAdv1.Size = new System.Drawing.Size(68, 20);
            this.travComboBoxAdv1.StyleController = this.travLayoutControl2;
            this.travComboBoxAdv1.TabIndex = 31;
            // 
            // travTextBox5
            // 
            this.travTextBox5.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.webContribImpBindingSource, "PmtAmt", true));
            this.travTextBox5.Location = new System.Drawing.Point(650, 31);
            this.travTextBox5.Name = "travTextBox5";
            this.travTextBox5.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.travTextBox5.Properties.FixedPointFormat = false;
            this.travTextBox5.Properties.NumericControl = false;
            this.travTextBox5.Properties.NumericPrecision = -1;
            this.travTextBox5.Properties.SetupFunctionId = 0;
            this.travTextBox5.SecurityId = null;
            this.travTextBox5.Size = new System.Drawing.Size(78, 20);
            this.travTextBox5.StyleController = this.travLayoutControl2;
            this.travTextBox5.TabIndex = 32;
            // 
            // travComboBox2
            // 
            this.travComboBox2.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.webContribImpBindingSource, "RptExchRate", true));
            this.travComboBox2.Location = new System.Drawing.Point(739, 31);
            this.travComboBox2.Name = "travComboBox2";
            this.travComboBox2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.travComboBox2.Properties.FormatString = null;
            this.travComboBox2.Properties.NumericPrecision = -1;
            this.travComboBox2.Properties.SetupFunctionId = 0;
            this.travComboBox2.SecurityId = null;
            this.travComboBox2.Size = new System.Drawing.Size(55, 20);
            this.travComboBox2.StyleController = this.travLayoutControl2;
            this.travComboBox2.TabIndex = 33;
            // 
            // emptySpaceItem4
            // 
            this.emptySpaceItem4.CustomizationFormText = "emptySpaceItem4";
            this.emptySpaceItem4.Location = new System.Drawing.Point(139, 239);
            this.emptySpaceItem4.Name = "emptySpaceItem4";
            this.emptySpaceItem4.Size = new System.Drawing.Size(659, 10);
            this.emptySpaceItem4.Text = "emptySpaceItem4";
            this.emptySpaceItem4.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem9
            // 
            this.emptySpaceItem9.CustomizationFormText = "emptySpaceItem9";
            this.emptySpaceItem9.Location = new System.Drawing.Point(139, 209);
            this.emptySpaceItem9.MinSize = new System.Drawing.Size(110, 30);
            this.emptySpaceItem9.Name = "emptySpaceItem9";
            this.emptySpaceItem9.Size = new System.Drawing.Size(489, 30);
            this.emptySpaceItem9.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem9.Text = "emptySpaceItem9";
            this.emptySpaceItem9.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem10
            // 
            this.emptySpaceItem10.CustomizationFormText = "emptySpaceItem10";
            this.emptySpaceItem10.Location = new System.Drawing.Point(628, 178);
            this.emptySpaceItem10.Name = "emptySpaceItem10";
            this.emptySpaceItem10.Size = new System.Drawing.Size(170, 61);
            this.emptySpaceItem10.Text = "emptySpaceItem10";
            this.emptySpaceItem10.TextSize = new System.Drawing.Size(0, 0);
            // 
            // travLabel17
            // 
            this.travLabel17.Location = new System.Drawing.Point(526, 62);
            this.travLabel17.Name = "travLabel17";
            this.travLabel17.SecurityId = null;
            this.travLabel17.Size = new System.Drawing.Size(86, 19);
            this.travLabel17.StyleController = this.travLayoutControl2;
            this.travLabel17.TabIndex = 34;
            this.travLabel17.Text = "Language";
            // 
            // travLabel18
            // 
            this.travLabel18.Location = new System.Drawing.Point(623, 62);
            this.travLabel18.Name = "travLabel18";
            this.travLabel18.SecurityId = null;
            this.travLabel18.Size = new System.Drawing.Size(61, 19);
            this.travLabel18.StyleController = this.travLayoutControl2;
            this.travLabel18.TabIndex = 35;
            this.travLabel18.Text = "Source Code";
            // 
            // travComboBox3
            // 
            this.travComboBox3.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.webContribImpBindingSource, "Lang", true));
            this.travComboBox3.Location = new System.Drawing.Point(635, 92);
            this.travComboBox3.Name = "travComboBox3";
            this.travComboBox3.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.travComboBox3.Properties.FormatString = null;
            this.travComboBox3.Properties.NumericPrecision = -1;
            this.travComboBox3.Properties.SetupFunctionId = 0;
            this.travComboBox3.SecurityId = null;
            this.travComboBox3.Size = new System.Drawing.Size(76, 20);
            this.travComboBox3.StyleController = this.travLayoutControl2;
            this.travComboBox3.TabIndex = 36;
            // 
            // travComboBox4
            // 
            this.travComboBox4.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.webContribImpBindingSource, "SourceCode", true));
            this.travComboBox4.Location = new System.Drawing.Point(722, 92);
            this.travComboBox4.Name = "travComboBox4";
            this.travComboBox4.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.travComboBox4.Properties.FormatString = null;
            this.travComboBox4.Properties.NumericPrecision = -1;
            this.travComboBox4.Properties.SetupFunctionId = 0;
            this.travComboBox4.SecurityId = null;
            this.travComboBox4.Size = new System.Drawing.Size(72, 20);
            this.travComboBox4.StyleController = this.travLayoutControl2;
            this.travComboBox4.TabIndex = 37;
            // 
            // travLabel19
            // 
            this.travLabel19.Location = new System.Drawing.Point(635, 123);
            this.travLabel19.Name = "travLabel19";
            this.travLabel19.SecurityId = null;
            this.travLabel19.Size = new System.Drawing.Size(159, 20);
            this.travLabel19.StyleController = this.travLayoutControl2;
            this.travLabel19.TabIndex = 38;
            this.travLabel19.Text = "City";
            // 
            // travTextBox11
            // 
            this.travTextBox11.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.webContribImpBindingSource, "City", true));
            this.travTextBox11.Location = new System.Drawing.Point(635, 154);
            this.travTextBox11.Name = "travTextBox11";
            this.travTextBox11.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.travTextBox11.Properties.FixedPointFormat = false;
            this.travTextBox11.Properties.NumericControl = false;
            this.travTextBox11.Properties.NumericPrecision = -1;
            this.travTextBox11.Properties.SetupFunctionId = 0;
            this.travTextBox11.SecurityId = null;
            this.travTextBox11.Size = new System.Drawing.Size(159, 20);
            this.travTextBox11.StyleController = this.travLayoutControl2;
            this.travTextBox11.TabIndex = 39;
            // 
            // emptySpaceItem6
            // 
            this.emptySpaceItem6.CustomizationFormText = "emptySpaceItem6";
            this.emptySpaceItem6.Location = new System.Drawing.Point(139, 249);
            this.emptySpaceItem6.Name = "emptySpaceItem6";
            this.emptySpaceItem6.Size = new System.Drawing.Size(329, 64);
            this.emptySpaceItem6.Text = "emptySpaceItem6";
            this.emptySpaceItem6.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem11
            // 
            this.emptySpaceItem11.CustomizationFormText = "emptySpaceItem11";
            this.emptySpaceItem11.Location = new System.Drawing.Point(688, 55);
            this.emptySpaceItem11.MinSize = new System.Drawing.Size(110, 30);
            this.emptySpaceItem11.Name = "emptySpaceItem11";
            this.emptySpaceItem11.Size = new System.Drawing.Size(110, 30);
            this.emptySpaceItem11.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem11.Text = "emptySpaceItem11";
            this.emptySpaceItem11.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem12
            // 
            this.emptySpaceItem12.CustomizationFormText = "emptySpaceItem12";
            this.emptySpaceItem12.Location = new System.Drawing.Point(0, 372);
            this.emptySpaceItem12.MinSize = new System.Drawing.Size(110, 30);
            this.emptySpaceItem12.Name = "emptySpaceItem12";
            this.emptySpaceItem12.Size = new System.Drawing.Size(798, 166);
            this.emptySpaceItem12.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem12.Text = "emptySpaceItem12";
            this.emptySpaceItem12.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.travTextBox2;
            this.layoutControlItem3.CustomizationFormText = "Fiscal Year";
            this.layoutControlItem3.Location = new System.Drawing.Point(383, 0);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(0, 31);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(116, 31);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(132, 31);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.Text = "Fiscal Year";
            this.layoutControlItem3.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem3.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(50, 20);
            this.layoutControlItem3.TrimClientAreaToControl = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.lkpBatchId;
            this.layoutControlItem2.ControlAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.layoutControlItem2.CustomizationFormText = "Batch ID";
            this.layoutControlItem2.Location = new System.Drawing.Point(110, 0);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(0, 31);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(116, 31);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(137, 31);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.Text = "Batch ID";
            this.layoutControlItem2.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(50, 20);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.travTextBox1;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.FillControlToClientArea = false;
            this.layoutControlItem1.Location = new System.Drawing.Point(247, 0);
            this.layoutControlItem1.MaxSize = new System.Drawing.Size(0, 31);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(116, 31);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(136, 31);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.Text = "GL Period";
            this.layoutControlItem1.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(50, 20);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.travCheckBox1;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem4.Location = new System.Drawing.Point(515, 0);
            this.layoutControlItem4.MaxSize = new System.Drawing.Size(0, 31);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(172, 31);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(173, 31);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.Text = "Show Exceptions Only";
            this.layoutControlItem4.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(106, 0);
            // 
            // webContribImpBindingSource
            // 
            this.webContribImpBindingSource.AllowNew = false;
            this.webContribImpBindingSource.DataSource = typeof(TRAVERSE.Business.WebContribImp.WebContribImp);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.travLabel1;
            this.layoutControlItem8.CustomizationFormText = "layoutControlItem8";
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem8.MaxSize = new System.Drawing.Size(139, 24);
            this.layoutControlItem8.MinSize = new System.Drawing.Size(139, 24);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(139, 24);
            this.layoutControlItem8.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem8.Text = "layoutControlItem8";
            this.layoutControlItem8.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextToControlDistance = 0;
            this.layoutControlItem8.TextVisible = false;
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.travLabel2;
            this.layoutControlItem9.CustomizationFormText = "layoutControlItem9";
            this.layoutControlItem9.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem9.MinSize = new System.Drawing.Size(48, 24);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(139, 31);
            this.layoutControlItem9.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem9.Text = "layoutControlItem9";
            this.layoutControlItem9.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem9.TextToControlDistance = 0;
            this.layoutControlItem9.TextVisible = false;
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.Control = this.travCheckBox2;
            this.layoutControlItem10.ControlAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.layoutControlItem10.CustomizationFormText = "Valid";
            this.layoutControlItem10.Location = new System.Drawing.Point(0, 55);
            this.layoutControlItem10.MinSize = new System.Drawing.Size(61, 55);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Size = new System.Drawing.Size(61, 55);
            this.layoutControlItem10.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem10.Text = "Valid";
            this.layoutControlItem10.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem10.TextSize = new System.Drawing.Size(22, 20);
            // 
            // layoutControlItem11
            // 
            this.layoutControlItem11.Control = this.travCheckBox3;
            this.layoutControlItem11.CustomizationFormText = "Skip";
            this.layoutControlItem11.Location = new System.Drawing.Point(61, 55);
            this.layoutControlItem11.MinSize = new System.Drawing.Size(61, 55);
            this.layoutControlItem11.Name = "layoutControlItem11";
            this.layoutControlItem11.Size = new System.Drawing.Size(78, 55);
            this.layoutControlItem11.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem11.Text = "Skip";
            this.layoutControlItem11.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem11.TextSize = new System.Drawing.Size(22, 20);
            // 
            // layoutControlItem12
            // 
            this.layoutControlItem12.Control = this.travLabel3;
            this.layoutControlItem12.CustomizationFormText = " ";
            this.layoutControlItem12.Location = new System.Drawing.Point(0, 110);
            this.layoutControlItem12.MinSize = new System.Drawing.Size(138, 24);
            this.layoutControlItem12.Name = "layoutControlItem12";
            this.layoutControlItem12.Size = new System.Drawing.Size(139, 24);
            this.layoutControlItem12.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem12.Text = " ";
            this.layoutControlItem12.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem12.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem12.TextSize = new System.Drawing.Size(25, 20);
            // 
            // layoutControlItem13
            // 
            this.layoutControlItem13.Control = this.travTextBox6;
            this.layoutControlItem13.CustomizationFormText = "layoutControlItem13";
            this.layoutControlItem13.Location = new System.Drawing.Point(0, 134);
            this.layoutControlItem13.MinSize = new System.Drawing.Size(111, 31);
            this.layoutControlItem13.Name = "layoutControlItem13";
            this.layoutControlItem13.Padding = new DevExpress.XtraLayout.Utils.Padding(20, 20, 5, 5);
            this.layoutControlItem13.Size = new System.Drawing.Size(139, 64);
            this.layoutControlItem13.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem13.Spacing = new DevExpress.XtraLayout.Utils.Padding(10, 10, 0, 0);
            this.layoutControlItem13.Text = "layoutControlItem13";
            this.layoutControlItem13.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem13.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem13.TextToControlDistance = 0;
            this.layoutControlItem13.TextVisible = false;
            // 
            // layoutControlItem15
            // 
            this.layoutControlItem15.Control = this.travLabel5;
            this.layoutControlItem15.CustomizationFormText = " ";
            this.layoutControlItem15.Location = new System.Drawing.Point(0, 222);
            this.layoutControlItem15.MinSize = new System.Drawing.Size(117, 24);
            this.layoutControlItem15.Name = "layoutControlItem15";
            this.layoutControlItem15.Size = new System.Drawing.Size(139, 24);
            this.layoutControlItem15.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem15.Text = " ";
            this.layoutControlItem15.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem15.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem15.TextSize = new System.Drawing.Size(50, 20);
            // 
            // layoutControlItem16
            // 
            this.layoutControlItem16.Control = this.travLabel6;
            this.layoutControlItem16.CustomizationFormText = " ";
            this.layoutControlItem16.Location = new System.Drawing.Point(0, 246);
            this.layoutControlItem16.MinSize = new System.Drawing.Size(114, 24);
            this.layoutControlItem16.Name = "layoutControlItem16";
            this.layoutControlItem16.Size = new System.Drawing.Size(139, 24);
            this.layoutControlItem16.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem16.Text = " ";
            this.layoutControlItem16.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem16.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem16.TextSize = new System.Drawing.Size(50, 20);
            // 
            // layoutControlItem17
            // 
            this.layoutControlItem17.Control = this.travLabel7;
            this.layoutControlItem17.CustomizationFormText = " ";
            this.layoutControlItem17.Location = new System.Drawing.Point(0, 270);
            this.layoutControlItem17.MinSize = new System.Drawing.Size(120, 24);
            this.layoutControlItem17.Name = "layoutControlItem17";
            this.layoutControlItem17.Size = new System.Drawing.Size(139, 24);
            this.layoutControlItem17.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem17.Text = " ";
            this.layoutControlItem17.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem17.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem17.TextSize = new System.Drawing.Size(50, 20);
            // 
            // layoutControlItem18
            // 
            this.layoutControlItem18.Control = this.travLabel8;
            this.layoutControlItem18.CustomizationFormText = " ";
            this.layoutControlItem18.Location = new System.Drawing.Point(0, 324);
            this.layoutControlItem18.MinSize = new System.Drawing.Size(92, 24);
            this.layoutControlItem18.Name = "layoutControlItem18";
            this.layoutControlItem18.Size = new System.Drawing.Size(139, 24);
            this.layoutControlItem18.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem18.Text = " ";
            this.layoutControlItem18.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem18.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem18.TextSize = new System.Drawing.Size(50, 20);
            // 
            // layoutControlItem19
            // 
            this.layoutControlItem19.Control = this.travLabel9;
            this.layoutControlItem19.CustomizationFormText = "layoutControlItem19";
            this.layoutControlItem19.Location = new System.Drawing.Point(0, 348);
            this.layoutControlItem19.MinSize = new System.Drawing.Size(139, 24);
            this.layoutControlItem19.Name = "layoutControlItem19";
            this.layoutControlItem19.Size = new System.Drawing.Size(139, 24);
            this.layoutControlItem19.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem19.Text = "layoutControlItem19";
            this.layoutControlItem19.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem19.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem19.TextToControlDistance = 0;
            this.layoutControlItem19.TextVisible = false;
            // 
            // layoutControlItem23
            // 
            this.layoutControlItem23.Control = this.travLabel10;
            this.layoutControlItem23.CustomizationFormText = "layoutControlItem23";
            this.layoutControlItem23.Location = new System.Drawing.Point(139, 0);
            this.layoutControlItem23.MinSize = new System.Drawing.Size(54, 24);
            this.layoutControlItem23.Name = "layoutControlItem23";
            this.layoutControlItem23.Size = new System.Drawing.Size(279, 24);
            this.layoutControlItem23.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem23.Text = "layoutControlItem23";
            this.layoutControlItem23.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem23.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem23.TextToControlDistance = 0;
            this.layoutControlItem23.TextVisible = false;
            // 
            // layoutControlItem14
            // 
            this.layoutControlItem14.Control = this.travLabel4;
            this.layoutControlItem14.CustomizationFormText = " ";
            this.layoutControlItem14.Location = new System.Drawing.Point(0, 198);
            this.layoutControlItem14.MinSize = new System.Drawing.Size(125, 24);
            this.layoutControlItem14.Name = "layoutControlItem14";
            this.layoutControlItem14.Size = new System.Drawing.Size(139, 24);
            this.layoutControlItem14.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem14.Text = " ";
            this.layoutControlItem14.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem14.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem14.TextSize = new System.Drawing.Size(50, 20);
            // 
            // layoutControlItem25
            // 
            this.layoutControlItem25.Control = this.travLabel12;
            this.layoutControlItem25.CustomizationFormText = "layoutControlItem25";
            this.layoutControlItem25.Location = new System.Drawing.Point(418, 0);
            this.layoutControlItem25.MinSize = new System.Drawing.Size(34, 24);
            this.layoutControlItem25.Name = "layoutControlItem25";
            this.layoutControlItem25.Size = new System.Drawing.Size(78, 24);
            this.layoutControlItem25.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem25.Text = "layoutControlItem25";
            this.layoutControlItem25.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem25.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem25.TextToControlDistance = 0;
            this.layoutControlItem25.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.travTextBox4;
            this.layoutControlItem6.CustomizationFormText = "Group ID";
            this.layoutControlItem6.Location = new System.Drawing.Point(139, 24);
            this.layoutControlItem6.MinSize = new System.Drawing.Size(109, 31);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(279, 31);
            this.layoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem6.Text = "Group ID";
            this.layoutControlItem6.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextToControlDistance = 0;
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem26
            // 
            this.layoutControlItem26.Control = this.travLabel13;
            this.layoutControlItem26.CustomizationFormText = "layoutControlItem26";
            this.layoutControlItem26.Location = new System.Drawing.Point(496, 0);
            this.layoutControlItem26.MinSize = new System.Drawing.Size(59, 24);
            this.layoutControlItem26.Name = "layoutControlItem26";
            this.layoutControlItem26.Size = new System.Drawing.Size(75, 24);
            this.layoutControlItem26.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem26.Text = "layoutControlItem26";
            this.layoutControlItem26.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem26.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem26.TextToControlDistance = 0;
            this.layoutControlItem26.TextVisible = false;
            // 
            // layoutControlItem27
            // 
            this.layoutControlItem27.Control = this.travLabel14;
            this.layoutControlItem27.CustomizationFormText = "layoutControlItem27";
            this.layoutControlItem27.Location = new System.Drawing.Point(571, 0);
            this.layoutControlItem27.MinSize = new System.Drawing.Size(72, 24);
            this.layoutControlItem27.Name = "layoutControlItem27";
            this.layoutControlItem27.Size = new System.Drawing.Size(72, 24);
            this.layoutControlItem27.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem27.Text = "layoutControlItem27";
            this.layoutControlItem27.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem27.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem27.TextToControlDistance = 0;
            this.layoutControlItem27.TextVisible = false;
            // 
            // layoutControlItem28
            // 
            this.layoutControlItem28.Control = this.travLabel15;
            this.layoutControlItem28.CustomizationFormText = "layoutControlItem28";
            this.layoutControlItem28.Location = new System.Drawing.Point(643, 0);
            this.layoutControlItem28.MinSize = new System.Drawing.Size(48, 24);
            this.layoutControlItem28.Name = "layoutControlItem28";
            this.layoutControlItem28.Size = new System.Drawing.Size(83, 24);
            this.layoutControlItem28.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem28.Text = "layoutControlItem28";
            this.layoutControlItem28.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem28.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem28.TextToControlDistance = 0;
            this.layoutControlItem28.TextVisible = false;
            // 
            // layoutControlItem29
            // 
            this.layoutControlItem29.Control = this.travLabel16;
            this.layoutControlItem29.CustomizationFormText = "layoutControlItem29";
            this.layoutControlItem29.Location = new System.Drawing.Point(726, 0);
            this.layoutControlItem29.MinSize = new System.Drawing.Size(54, 24);
            this.layoutControlItem29.Name = "layoutControlItem29";
            this.layoutControlItem29.Size = new System.Drawing.Size(72, 24);
            this.layoutControlItem29.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem29.Text = "layoutControlItem29";
            this.layoutControlItem29.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem29.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem29.TextToControlDistance = 0;
            this.layoutControlItem29.TextVisible = false;
            // 
            // layoutControlItem30
            // 
            this.layoutControlItem30.Control = this.travTextBox10;
            this.layoutControlItem30.CustomizationFormText = "layoutControlItem30";
            this.layoutControlItem30.Location = new System.Drawing.Point(497, 24);
            this.layoutControlItem30.MinSize = new System.Drawing.Size(61, 31);
            this.layoutControlItem30.Name = "layoutControlItem30";
            this.layoutControlItem30.Size = new System.Drawing.Size(75, 31);
            this.layoutControlItem30.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem30.Text = "layoutControlItem30";
            this.layoutControlItem30.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem30.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem30.TextToControlDistance = 0;
            this.layoutControlItem30.TextVisible = false;
            // 
            // layoutControlItem32
            // 
            this.layoutControlItem32.Control = this.travComboBoxAdv1;
            this.layoutControlItem32.CustomizationFormText = "layoutControlItem32";
            this.layoutControlItem32.Location = new System.Drawing.Point(418, 24);
            this.layoutControlItem32.MinSize = new System.Drawing.Size(61, 31);
            this.layoutControlItem32.Name = "layoutControlItem32";
            this.layoutControlItem32.Size = new System.Drawing.Size(79, 31);
            this.layoutControlItem32.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem32.Text = "layoutControlItem32";
            this.layoutControlItem32.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem32.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem32.TextToControlDistance = 0;
            this.layoutControlItem32.TextVisible = false;
            // 
            // layoutControlItem31
            // 
            this.layoutControlItem31.Control = this.travComboBox1;
            this.layoutControlItem31.CustomizationFormText = "layoutControlItem31";
            this.layoutControlItem31.Location = new System.Drawing.Point(572, 24);
            this.layoutControlItem31.MinSize = new System.Drawing.Size(1, 31);
            this.layoutControlItem31.Name = "layoutControlItem31";
            this.layoutControlItem31.Size = new System.Drawing.Size(71, 31);
            this.layoutControlItem31.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem31.Text = "layoutControlItem31";
            this.layoutControlItem31.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem31.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem31.TextToControlDistance = 0;
            this.layoutControlItem31.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.travTextBox5;
            this.layoutControlItem7.CustomizationFormText = "layoutControlItem7";
            this.layoutControlItem7.Location = new System.Drawing.Point(643, 24);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(89, 31);
            this.layoutControlItem7.Text = "layoutControlItem7";
            this.layoutControlItem7.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextToControlDistance = 0;
            this.layoutControlItem7.TextVisible = false;
            // 
            // layoutControlItem33
            // 
            this.layoutControlItem33.Control = this.travComboBox2;
            this.layoutControlItem33.CustomizationFormText = "layoutControlItem33";
            this.layoutControlItem33.Location = new System.Drawing.Point(732, 24);
            this.layoutControlItem33.Name = "layoutControlItem33";
            this.layoutControlItem33.Size = new System.Drawing.Size(66, 31);
            this.layoutControlItem33.Text = "layoutControlItem33";
            this.layoutControlItem33.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem33.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem33.TextToControlDistance = 0;
            this.layoutControlItem33.TextVisible = false;
            // 
            // layoutControlItem24
            // 
            this.layoutControlItem24.Control = this.travLabel11;
            this.layoutControlItem24.CustomizationFormText = "layoutControlItem24";
            this.layoutControlItem24.Location = new System.Drawing.Point(139, 55);
            this.layoutControlItem24.MinSize = new System.Drawing.Size(96, 24);
            this.layoutControlItem24.Name = "layoutControlItem24";
            this.layoutControlItem24.Size = new System.Drawing.Size(116, 30);
            this.layoutControlItem24.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem24.Text = "layoutControlItem24";
            this.layoutControlItem24.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem24.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem24.TextToControlDistance = 0;
            this.layoutControlItem24.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.travTextBox3;
            this.layoutControlItem5.CustomizationFormText = "layoutControlItem5";
            this.layoutControlItem5.Location = new System.Drawing.Point(139, 85);
            this.layoutControlItem5.MinSize = new System.Drawing.Size(61, 31);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(489, 31);
            this.layoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem5.Text = "layoutControlItem5";
            this.layoutControlItem5.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextToControlDistance = 0;
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem34
            // 
            this.layoutControlItem34.Control = this.travLabel17;
            this.layoutControlItem34.CustomizationFormText = "layoutControlItem34";
            this.layoutControlItem34.Location = new System.Drawing.Point(519, 55);
            this.layoutControlItem34.MinSize = new System.Drawing.Size(58, 24);
            this.layoutControlItem34.Name = "layoutControlItem34";
            this.layoutControlItem34.Size = new System.Drawing.Size(97, 30);
            this.layoutControlItem34.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem34.Text = "layoutControlItem34";
            this.layoutControlItem34.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem34.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem34.TextToControlDistance = 0;
            this.layoutControlItem34.TextVisible = false;
            // 
            // layoutControlItem35
            // 
            this.layoutControlItem35.Control = this.travLabel18;
            this.layoutControlItem35.CustomizationFormText = "layoutControlItem35";
            this.layoutControlItem35.Location = new System.Drawing.Point(616, 55);
            this.layoutControlItem35.MinSize = new System.Drawing.Size(72, 24);
            this.layoutControlItem35.Name = "layoutControlItem35";
            this.layoutControlItem35.Size = new System.Drawing.Size(72, 30);
            this.layoutControlItem35.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem35.Text = "layoutControlItem35";
            this.layoutControlItem35.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem35.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem35.TextToControlDistance = 0;
            this.layoutControlItem35.TextVisible = false;
            // 
            // layoutControlItem36
            // 
            this.layoutControlItem36.Control = this.travComboBox3;
            this.layoutControlItem36.CustomizationFormText = "layoutControlItem36";
            this.layoutControlItem36.Location = new System.Drawing.Point(628, 85);
            this.layoutControlItem36.Name = "layoutControlItem36";
            this.layoutControlItem36.Size = new System.Drawing.Size(87, 31);
            this.layoutControlItem36.Text = "layoutControlItem36";
            this.layoutControlItem36.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem36.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem36.TextToControlDistance = 0;
            this.layoutControlItem36.TextVisible = false;
            // 
            // layoutControlItem37
            // 
            this.layoutControlItem37.Control = this.travComboBox4;
            this.layoutControlItem37.CustomizationFormText = "layoutControlItem37";
            this.layoutControlItem37.Location = new System.Drawing.Point(715, 85);
            this.layoutControlItem37.Name = "layoutControlItem37";
            this.layoutControlItem37.Size = new System.Drawing.Size(83, 31);
            this.layoutControlItem37.Text = "layoutControlItem37";
            this.layoutControlItem37.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem37.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem37.TextToControlDistance = 0;
            this.layoutControlItem37.TextVisible = false;
            // 
            // layoutControlItem38
            // 
            this.layoutControlItem38.Control = this.travLabel19;
            this.layoutControlItem38.CustomizationFormText = "layoutControlItem38";
            this.layoutControlItem38.Location = new System.Drawing.Point(628, 116);
            this.layoutControlItem38.MinSize = new System.Drawing.Size(30, 24);
            this.layoutControlItem38.Name = "layoutControlItem38";
            this.layoutControlItem38.Size = new System.Drawing.Size(170, 31);
            this.layoutControlItem38.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem38.Text = "layoutControlItem38";
            this.layoutControlItem38.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem38.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem38.TextToControlDistance = 0;
            this.layoutControlItem38.TextVisible = false;
            // 
            // layoutControlItem39
            // 
            this.layoutControlItem39.Control = this.travTextBox11;
            this.layoutControlItem39.CustomizationFormText = "layoutControlItem39";
            this.layoutControlItem39.Location = new System.Drawing.Point(628, 147);
            this.layoutControlItem39.MinSize = new System.Drawing.Size(61, 31);
            this.layoutControlItem39.Name = "layoutControlItem39";
            this.layoutControlItem39.Size = new System.Drawing.Size(170, 31);
            this.layoutControlItem39.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem39.Text = "layoutControlItem39";
            this.layoutControlItem39.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem39.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem39.TextToControlDistance = 0;
            this.layoutControlItem39.TextVisible = false;
            // 
            // layoutControlItem21
            // 
            this.layoutControlItem21.Control = this.travTextBox8;
            this.layoutControlItem21.CustomizationFormText = "layoutControlItem21";
            this.layoutControlItem21.Location = new System.Drawing.Point(139, 147);
            this.layoutControlItem21.MinSize = new System.Drawing.Size(61, 31);
            this.layoutControlItem21.Name = "layoutControlItem21";
            this.layoutControlItem21.Size = new System.Drawing.Size(489, 31);
            this.layoutControlItem21.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem21.Text = "layoutControlItem21";
            this.layoutControlItem21.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem21.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem21.TextToControlDistance = 0;
            this.layoutControlItem21.TextVisible = false;
            // 
            // layoutControlItem20
            // 
            this.layoutControlItem20.Control = this.travTextBox7;
            this.layoutControlItem20.CustomizationFormText = "layoutControlItem20";
            this.layoutControlItem20.Location = new System.Drawing.Point(139, 116);
            this.layoutControlItem20.MinSize = new System.Drawing.Size(61, 31);
            this.layoutControlItem20.Name = "layoutControlItem20";
            this.layoutControlItem20.Size = new System.Drawing.Size(489, 31);
            this.layoutControlItem20.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem20.Text = "layoutControlItem20";
            this.layoutControlItem20.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem20.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem20.TextToControlDistance = 0;
            this.layoutControlItem20.TextVisible = false;
            // 
            // layoutControlItem22
            // 
            this.layoutControlItem22.Control = this.travTextBox9;
            this.layoutControlItem22.CustomizationFormText = "layoutControlItem22";
            this.layoutControlItem22.Location = new System.Drawing.Point(139, 178);
            this.layoutControlItem22.MinSize = new System.Drawing.Size(61, 31);
            this.layoutControlItem22.Name = "layoutControlItem22";
            this.layoutControlItem22.Size = new System.Drawing.Size(489, 31);
            this.layoutControlItem22.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem22.Text = "layoutControlItem22";
            this.layoutControlItem22.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem22.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem22.TextToControlDistance = 0;
            this.layoutControlItem22.TextVisible = false;
            // 
            // emptySpaceItem13
            // 
            this.emptySpaceItem13.CustomizationFormText = "emptySpaceItem13";
            this.emptySpaceItem13.Location = new System.Drawing.Point(468, 249);
            this.emptySpaceItem13.Name = "emptySpaceItem13";
            this.emptySpaceItem13.Size = new System.Drawing.Size(330, 64);
            this.emptySpaceItem13.Text = "emptySpaceItem13";
            this.emptySpaceItem13.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem14
            // 
            this.emptySpaceItem14.CustomizationFormText = "emptySpaceItem14";
            this.emptySpaceItem14.Location = new System.Drawing.Point(468, 313);
            this.emptySpaceItem14.Name = "emptySpaceItem14";
            this.emptySpaceItem14.Size = new System.Drawing.Size(330, 59);
            this.emptySpaceItem14.Text = "emptySpaceItem14";
            this.emptySpaceItem14.TextSize = new System.Drawing.Size(0, 0);
            // 
            // WebContribImpControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Name = "WebContribImpControl";
            this.splitContainerBase.Panel1.ResumeLayout(false);
            this.splitContainerBase.Panel1.PerformLayout();
            this.splitContainerBase.Panel2.ResumeLayout(false);
            this.splitContainerBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderBase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.travNavCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.travLayoutControl1)).EndInit();
            this.travLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.travTextBox2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.travCheckBox1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpBatchId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.travTextBox1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.travLayoutControl2)).EndInit();
            this.travLayoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.travTextBox10.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.travTextBox9.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.travTextBox8.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.travTextBox7.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.travTextBox6.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.travCheckBox3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.travCheckBox2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.travTextBox4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.travTextBox3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.travComboBox1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.travComboBoxAdv1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.travTextBox5.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.travComboBox2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.travComboBox3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.travComboBox4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.travTextBox11.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.webContribImpBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem30)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem32)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem31)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem33)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem34)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem35)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem36)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem37)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem38)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem39)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem14)).EndInit();
            this.ResumeLayout(false);

        }

        private void travTextBox2_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void travTextBox1_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}
