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
using DevExpress.Data;
using DevExpress.XtraGrid;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using TRAVERSE.Client;
using TRAVERSE.Business.PartnerItemXref;
using TRAVERSE.Business;
using TRAVERSE.Controls;
using System;



namespace CSI.EDI.Client.PartnerItemXref
{

    public class PartnerItemXrefControl : PluginControlBase
    {

        private PartnerItemXrefProvider _provider;
        private BindingSource partnerItemXrefBindingSource;
        private IContainer components;
        private TravDataGridViewControl dgvCode;
        private GridView gridView1;
        private GridColumn colPartnerId;
        private GridColumn colTravItemId;
        private GridColumn colTravUom;
        private GridColumn colEdiUom;
        private GridColumn colEAN;
        private GridColumn colGTIN;
        private GridColumn colUPC;
        private GridColumn colSKU;
        private GridColumn colBuyerCode;
        private GridColumn colVendorCode;
        private GridColumn colInternalCode;
        private GridColumn colInternalCode1;
        private GridColumn colInternalCode2;
        private GridColumn colCustomField;
        private TravNavigator travNavCode;
        public RepositoryItemTravLookupControl rlkpPartnerId;
        public RepositoryItemTravLookupControl rlkpItemId;
       
        public PartnerItemXrefControl()
            : this(null)
        {

        }
        public PartnerItemXrefControl(IPlugin host)
        {


            this._provider = new PartnerItemXrefProvider();
            InitializeComponent();
            base.HostPlugin = host;
            this.BindingSource = partnerItemXrefBindingSource;
            this.travNavCode.Preview += new EventHandler(travNavCode_Preview);

            this.travNavCode.RefreshData += new EventHandler(this.travNavCode_RefreshData);
            this.BindingSource.AddingNew += new AddingNewEventHandler(this.BindingSource_AddingNew);
            this.gridView1.CellValueChanged += new CellValueChangedEventHandler(this.dgvCode_CellValueChanged);
            this.gridView1.CustomRowCellEditForEditing += new CustomRowCellEditEventHandler(this.gridView1_CustomRowCellEditForEditing);


        }
        protected override void LoadData()
        {

            this.Provider = this._provider;
            this.partnerItemXrefBindingSource.RaiseListChangedEvents = false;
            this.partnerItemXrefBindingSource.DataSource = this._provider.Load(this.CompId);
            this.partnerItemXrefBindingSource.RaiseListChangedEvents = true;
            this.partnerItemXrefBindingSource.ResetBindings(true);

        }
        protected override void OnLoad(EventArgs e)
        {
            try
            {
                this.CompId = this.HostPlugin.DatabaseName;
                this.LoadData();
                this.gridView1.OptionsSelection.InvertSelection = true;
                this.rlkpItemId = new RepositoryItemTravLookupControl();
                this.rlkpPartnerId = new RepositoryItemTravLookupControl();
                this.SetItemIdControl();
                this.SetPartnerIdControl();

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
                this.OnPartnerItemXrefAddingNew(e);
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
                this.gridView1.CellValueChanged -= new CellValueChangedEventHandler(this.dgvCode_CellValueChanged);
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
                // for later this.OndgvCodeCellValueChanged(e);
            }
            catch (Exception exception)
            {
                ClientContext.HandleError(exception, this);
            }
        }

        public virtual void OntravNavCodePreview(EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.dgvCode.ShowPrintPreview();
            this.Cursor = Cursors.Default;

        }

        public virtual void travNavCodeRefreshData(EventArgs e)
        {
            this.LoadData();
        }

        public virtual void OnPartnerItemXrefAddingNew(AddingNewEventArgs e)
        {
            e.NewObject = new TRAVERSE.Business.PartnerItemXref.PartnerItemXref();
        }
        //public virtual void OndgvCodeCellValueChanged(CellValueChangedEventArgs e)
        //{

        //    this.dgvCode.FindRowByKey(this.colPartnerId, e);

        //}

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

        protected virtual void SetItemIdControl()
        {

            this.rlkpItemId.LookupDefinitionId = "Item";
            this.rlkpItemId.LoadList(this.CompId);
            base.SetupMaintControl(this.rlkpItemId, 0xf4376);
        }
        public virtual void OngridView1CustomRowCellEditForEditing(CustomRowCellEditEventArgs e)
        {
            e.Column.OptionsColumn.ReadOnly = false;
            if (e.Column.Equals(this.colTravItemId))
            {

                e.RepositoryItem = this.rlkpItemId;


            }
            if (e.Column.Equals(this.colPartnerId))
            {

                e.RepositoryItem = this.rlkpPartnerId;


            }
        }

        protected virtual void SetPartnerIdControl()
        {

            this.rlkpPartnerId.LookupDefinitionId = "CsiEdiPartner";
            this.rlkpPartnerId.LoadList(this.CompId);
            base.SetupMaintControl(this.rlkpPartnerId, 0xf4375);
        }
       
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
                EntityProvider.InvalidateLookupObject("PartnerItemXref");
            }
        }




        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.partnerItemXrefBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.travNavCode = new TRAVERSE.Controls.TravNavigator(this.components);
            this.dgvCode = new TRAVERSE.Controls.TravDataGridViewControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPartnerId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTravItemId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTravUom = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEdiUom = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEAN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGTIN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUPC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSKU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBuyerCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVendorCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInternalCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInternalCode1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInternalCode2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomField = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splitContainerBase.Panel1.SuspendLayout();
            this.splitContainerBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.partnerItemXrefBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.travNavCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerBase
            // 
            // 
            // splitContainerBase.Panel1
            // 
            this.splitContainerBase.Panel1.Controls.Add(this.dgvCode);
            this.splitContainerBase.Panel1.Controls.Add(this.travNavCode);
            // 
            // partnerItemXrefBindingSource
            // 
            this.partnerItemXrefBindingSource.DataSource = typeof(TRAVERSE.Business.PartnerItemXref.PartnerItemXref);
            // 
            // travNavCode
            // 
            this.travNavCode.BackColor = System.Drawing.SystemColors.Control;
            this.travNavCode.BindingSource = this.partnerItemXrefBindingSource;
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
            this.travNavCode.TabIndex = 0;
            this.travNavCode.Text = "travNavigator1";
            // 
            // dgvCode
            // 
            this.dgvCode.DataSource = this.partnerItemXrefBindingSource;
            this.dgvCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCode.EmbeddedNavigator.Name = "";
            this.dgvCode.FormsUseDefaultLookAndFeel = false;
            this.dgvCode.Location = new System.Drawing.Point(0, 25);
            this.dgvCode.MainView = this.gridView1;
            this.dgvCode.MultiSelect = true;
            this.dgvCode.Name = "dgvCode";
            this.dgvCode.ShowGroupPanel = false;
            this.dgvCode.ShowNewRow = true;
            this.dgvCode.Size = new System.Drawing.Size(800, 575);
            this.dgvCode.TabIndex = 1;
            this.dgvCode.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPartnerId,
            this.colTravItemId,
            this.colTravUom,
            this.colEdiUom,
            this.colEAN,
            this.colGTIN,
            this.colUPC,
            this.colSKU,
            this.colBuyerCode,
            this.colVendorCode,
            this.colInternalCode,
            this.colInternalCode1,
            this.colInternalCode2,
            this.colCustomField});
            this.gridView1.GridControl = this.dgvCode;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colPartnerId
            // 
            this.colPartnerId.Caption = "Partner Id";
            this.colPartnerId.FieldName = "PartnerId";
            this.colPartnerId.Name = "colPartnerId";
            this.colPartnerId.Visible = true;
            this.colPartnerId.VisibleIndex = 0;
            // 
            // colTravItemId
            // 
            this.colTravItemId.Caption = "Traverse Item Id";
            this.colTravItemId.FieldName = "TravItemId";
            this.colTravItemId.Name = "colTravItemId";
            this.colTravItemId.Visible = true;
            this.colTravItemId.VisibleIndex = 1;
            // 
            // colTravUom
            // 
            this.colTravUom.Caption = "Traverse UOM";
            this.colTravUom.FieldName = "TravUom";
            this.colTravUom.Name = "colTravUom";
            this.colTravUom.Visible = true;
            this.colTravUom.VisibleIndex = 2;
            // 
            // colEdiUom
            // 
            this.colEdiUom.Caption = "EDI UOM";
            this.colEdiUom.FieldName = "EdiUom";
            this.colEdiUom.Name = "colEdiUom";
            this.colEdiUom.Visible = true;
            this.colEdiUom.VisibleIndex = 3;
            // 
            // colEAN
            // 
            this.colEAN.Caption = "EAN";
            this.colEAN.FieldName = "EAN";
            this.colEAN.Name = "colEAN";
            this.colEAN.Visible = true;
            this.colEAN.VisibleIndex = 4;
            // 
            // colGTIN
            // 
            this.colGTIN.Caption = "GTIN";
            this.colGTIN.FieldName = "GTIN";
            this.colGTIN.Name = "colGTIN";
            this.colGTIN.Visible = true;
            this.colGTIN.VisibleIndex = 5;
            // 
            // colUPC
            // 
            this.colUPC.Caption = "UPC";
            this.colUPC.FieldName = "UPC";
            this.colUPC.Name = "colUPC";
            this.colUPC.Visible = true;
            this.colUPC.VisibleIndex = 6;
            // 
            // colSKU
            // 
            this.colSKU.Caption = "SKU";
            this.colSKU.FieldName = "SKU";
            this.colSKU.Name = "colSKU";
            this.colSKU.Visible = true;
            this.colSKU.VisibleIndex = 7;
            // 
            // colBuyerCode
            // 
            this.colBuyerCode.Caption = "Buyer Code";
            this.colBuyerCode.FieldName = "BuyerCode";
            this.colBuyerCode.Name = "colBuyerCode";
            this.colBuyerCode.Visible = true;
            this.colBuyerCode.VisibleIndex = 8;
            // 
            // colVendorCode
            // 
            this.colVendorCode.Caption = "Vendor Code";
            this.colVendorCode.FieldName = "VendorCode";
            this.colVendorCode.Name = "colVendorCode";
            this.colVendorCode.Visible = true;
            this.colVendorCode.VisibleIndex = 9;
            // 
            // colInternalCode
            // 
            this.colInternalCode.Caption = "Internal Code";
            this.colInternalCode.FieldName = "InternalCode";
            this.colInternalCode.Name = "colInternalCode";
            this.colInternalCode.Visible = true;
            this.colInternalCode.VisibleIndex = 10;
            // 
            // colInternalCode1
            // 
            this.colInternalCode1.Caption = "Internal Code 1";
            this.colInternalCode1.FieldName = "InternalCode1";
            this.colInternalCode1.Name = "colInternalCode1";
            this.colInternalCode1.Visible = true;
            this.colInternalCode1.VisibleIndex = 11;
            // 
            // colInternalCode2
            // 
            this.colInternalCode2.Caption = "Internal Code 2";
            this.colInternalCode2.FieldName = "InternalCode2";
            this.colInternalCode2.Name = "colInternalCode2";
            this.colInternalCode2.Visible = true;
            this.colInternalCode2.VisibleIndex = 12;
            // 
            // colCustomField
            // 
            this.colCustomField.Caption = "Custom Field";
            this.colCustomField.FieldName = "CustomField";
            this.colCustomField.Name = "colCustomField";
            this.colCustomField.OptionsColumn.ReadOnly = true;
            this.colCustomField.Visible = true;
            this.colCustomField.VisibleIndex = 13;
            // 
            // PartnerItemXrefControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Name = "PartnerItemXrefControl";
            this.splitContainerBase.Panel1.ResumeLayout(false);
            this.splitContainerBase.Panel1.PerformLayout();
            this.splitContainerBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderBase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.partnerItemXrefBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.travNavCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
