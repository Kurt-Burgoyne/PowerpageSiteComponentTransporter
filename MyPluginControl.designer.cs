namespace SiteComponentTransporter {
    partial class window {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose (bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent () {
            this.toolStripMenu = new System.Windows.Forms.ToolStrip();
            this.btn_close = new System.Windows.Forms.ToolStripButton();
            this.tssSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_addTarget = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_loadSource = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_retrieveItems = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_transferRecords = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.gb_connectionDetails = new System.Windows.Forms.GroupBox();
            this.txt_targetName = new System.Windows.Forms.Label();
            this.txt_trgtLabel = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.checklist_items = new System.Windows.Forms.CheckedListBox();
            this.menu_selection_checklist = new System.Windows.Forms.MenuStrip();
            this.btn_selectall_types = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_clearselected_types = new System.Windows.Forms.ToolStripMenuItem();
            this.data_portalItems = new System.Windows.Forms.DataGridView();
            this.gb_options = new System.Windows.Forms.GroupBox();
            this.menu_selection_records = new System.Windows.Forms.MenuStrip();
            this.btn_selectall_components = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_clearselected_components = new System.Windows.Forms.ToolStripMenuItem();
            this.combo_website = new System.Windows.Forms.ComboBox();
            this.date_before = new System.Windows.Forms.DateTimePicker();
            this.date_after = new System.Windows.Forms.DateTimePicker();
            this.check_active = new System.Windows.Forms.CheckBox();
            this.check_website = new System.Windows.Forms.CheckBox();
            this.check_before = new System.Windows.Forms.CheckBox();
            this.check_after = new System.Windows.Forms.CheckBox();
            this.toolStripMenu.SuspendLayout();
            this.gb_connectionDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.menu_selection_checklist.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.data_portalItems)).BeginInit();
            this.gb_options.SuspendLayout();
            this.menu_selection_records.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripMenu
            // 
            this.toolStripMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_close,
            this.tssSeparator1,
            this.btn_addTarget,
            this.toolStripSeparator3,
            this.btn_loadSource,
            this.toolStripSeparator2,
            this.btn_retrieveItems,
            this.toolStripSeparator4,
            this.btn_transferRecords,
            this.toolStripSeparator1});
            this.toolStripMenu.Location = new System.Drawing.Point(0, 0);
            this.toolStripMenu.Name = "toolStripMenu";
            this.toolStripMenu.Size = new System.Drawing.Size(1355, 25);
            this.toolStripMenu.TabIndex = 4;
            this.toolStripMenu.Text = "toolStrip1";
            // 
            // btn_close
            // 
            this.btn_close.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(40, 22);
            this.btn_close.Text = "Close";
            // 
            // tssSeparator1
            // 
            this.tssSeparator1.Name = "tssSeparator1";
            this.tssSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btn_addTarget
            // 
            this.btn_addTarget.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btn_addTarget.Name = "btn_addTarget";
            this.btn_addTarget.Size = new System.Drawing.Size(78, 22);
            this.btn_addTarget.Text = "Select Target";
            this.btn_addTarget.Click += new System.EventHandler(this.btn_addTarget_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // btn_loadSource
            // 
            this.btn_loadSource.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btn_loadSource.Name = "btn_loadSource";
            this.btn_loadSource.Size = new System.Drawing.Size(76, 22);
            this.btn_loadSource.Text = "Load Source";
            this.btn_loadSource.Click += new System.EventHandler(this.btn_loadSource_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btn_retrieveItems
            // 
            this.btn_retrieveItems.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btn_retrieveItems.Name = "btn_retrieveItems";
            this.btn_retrieveItems.Size = new System.Drawing.Size(98, 22);
            this.btn_retrieveItems.Text = "Retrieve Records";
            this.btn_retrieveItems.Click += new System.EventHandler(this.btn_retrieveItems_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // btn_transferRecords
            // 
            this.btn_transferRecords.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btn_transferRecords.Name = "btn_transferRecords";
            this.btn_transferRecords.Size = new System.Drawing.Size(98, 22);
            this.btn_transferRecords.Text = "Transfer Records";
            this.btn_transferRecords.Click += new System.EventHandler(this.btn_transferRecords_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // gb_connectionDetails
            // 
            this.gb_connectionDetails.Controls.Add(this.txt_targetName);
            this.gb_connectionDetails.Controls.Add(this.txt_trgtLabel);
            this.gb_connectionDetails.Dock = System.Windows.Forms.DockStyle.Top;
            this.gb_connectionDetails.Location = new System.Drawing.Point(0, 25);
            this.gb_connectionDetails.Name = "gb_connectionDetails";
            this.gb_connectionDetails.Size = new System.Drawing.Size(1355, 50);
            this.gb_connectionDetails.TabIndex = 5;
            this.gb_connectionDetails.TabStop = false;
            this.gb_connectionDetails.Text = "Connection Details";
            // 
            // txt_targetName
            // 
            this.txt_targetName.AutoSize = true;
            this.txt_targetName.Dock = System.Windows.Forms.DockStyle.Left;
            this.txt_targetName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_targetName.ForeColor = System.Drawing.Color.Red;
            this.txt_targetName.Location = new System.Drawing.Point(140, 16);
            this.txt_targetName.Name = "txt_targetName";
            this.txt_targetName.Padding = new System.Windows.Forms.Padding(0, 5, 10, 0);
            this.txt_targetName.Size = new System.Drawing.Size(93, 22);
            this.txt_targetName.TabIndex = 3;
            this.txt_targetName.Text = "Unassigned";
            this.txt_targetName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_trgtLabel
            // 
            this.txt_trgtLabel.AutoSize = true;
            this.txt_trgtLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.txt_trgtLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_trgtLabel.Location = new System.Drawing.Point(3, 16);
            this.txt_trgtLabel.Name = "txt_trgtLabel";
            this.txt_trgtLabel.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.txt_trgtLabel.Size = new System.Drawing.Size(137, 22);
            this.txt_trgtLabel.TabIndex = 2;
            this.txt_trgtLabel.Text = "Target Environment:";
            this.txt_trgtLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 75);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.checklist_items);
            this.splitContainer1.Panel1.Controls.Add(this.menu_selection_checklist);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.data_portalItems);
            this.splitContainer1.Panel2.Controls.Add(this.gb_options);
            this.splitContainer1.Size = new System.Drawing.Size(1355, 603);
            this.splitContainer1.SplitterDistance = 451;
            this.splitContainer1.TabIndex = 6;
            // 
            // checklist_items
            // 
            this.checklist_items.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checklist_items.FormattingEnabled = true;
            this.checklist_items.Location = new System.Drawing.Point(0, 24);
            this.checklist_items.Name = "checklist_items";
            this.checklist_items.Size = new System.Drawing.Size(451, 579);
            this.checklist_items.TabIndex = 1;
            // 
            // menu_selection_checklist
            // 
            this.menu_selection_checklist.BackColor = System.Drawing.Color.Transparent;
            this.menu_selection_checklist.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_selectall_types,
            this.btn_clearselected_types});
            this.menu_selection_checklist.Location = new System.Drawing.Point(0, 0);
            this.menu_selection_checklist.Name = "menu_selection_checklist";
            this.menu_selection_checklist.Size = new System.Drawing.Size(451, 24);
            this.menu_selection_checklist.TabIndex = 0;
            this.menu_selection_checklist.Text = "menu_listitems";
            // 
            // btn_selectall_types
            // 
            this.btn_selectall_types.ForeColor = System.Drawing.Color.Blue;
            this.btn_selectall_types.Name = "btn_selectall_types";
            this.btn_selectall_types.Size = new System.Drawing.Size(67, 20);
            this.btn_selectall_types.Text = "Select All";
            this.btn_selectall_types.Click += new System.EventHandler(this.btn_selectall_types_Click);
            // 
            // btn_clearselected_types
            // 
            this.btn_clearselected_types.ForeColor = System.Drawing.Color.Blue;
            this.btn_clearselected_types.Name = "btn_clearselected_types";
            this.btn_clearselected_types.Size = new System.Drawing.Size(93, 20);
            this.btn_clearselected_types.Text = "Clear Selected";
            this.btn_clearselected_types.Click += new System.EventHandler(this.btn_clearselected_types_Click);
            // 
            // data_portalItems
            // 
            this.data_portalItems.AllowUserToAddRows = false;
            this.data_portalItems.AllowUserToDeleteRows = false;
            this.data_portalItems.AllowUserToOrderColumns = true;
            this.data_portalItems.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.data_portalItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.data_portalItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.data_portalItems.Location = new System.Drawing.Point(0, 211);
            this.data_portalItems.Name = "data_portalItems";
            this.data_portalItems.RowHeadersVisible = false;
            this.data_portalItems.ShowCellToolTips = false;
            this.data_portalItems.ShowEditingIcon = false;
            this.data_portalItems.Size = new System.Drawing.Size(900, 392);
            this.data_portalItems.StandardTab = true;
            this.data_portalItems.TabIndex = 1;
            // 
            // gb_options
            // 
            this.gb_options.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gb_options.Controls.Add(this.menu_selection_records);
            this.gb_options.Controls.Add(this.combo_website);
            this.gb_options.Controls.Add(this.date_before);
            this.gb_options.Controls.Add(this.date_after);
            this.gb_options.Controls.Add(this.check_active);
            this.gb_options.Controls.Add(this.check_website);
            this.gb_options.Controls.Add(this.check_before);
            this.gb_options.Controls.Add(this.check_after);
            this.gb_options.Dock = System.Windows.Forms.DockStyle.Top;
            this.gb_options.Location = new System.Drawing.Point(0, 0);
            this.gb_options.Name = "gb_options";
            this.gb_options.Size = new System.Drawing.Size(900, 211);
            this.gb_options.TabIndex = 0;
            this.gb_options.TabStop = false;
            this.gb_options.Text = "Options";
            // 
            // menu_selection_records
            // 
            this.menu_selection_records.BackColor = System.Drawing.Color.Transparent;
            this.menu_selection_records.Dock = System.Windows.Forms.DockStyle.None;
            this.menu_selection_records.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_selectall_components,
            this.btn_clearselected_components});
            this.menu_selection_records.Location = new System.Drawing.Point(7, 184);
            this.menu_selection_records.Name = "menu_selection_records";
            this.menu_selection_records.Size = new System.Drawing.Size(168, 24);
            this.menu_selection_records.TabIndex = 2;
            this.menu_selection_records.Text = "menu_listitems";
            // 
            // btn_selectall_components
            // 
            this.btn_selectall_components.ForeColor = System.Drawing.Color.Blue;
            this.btn_selectall_components.Name = "btn_selectall_components";
            this.btn_selectall_components.Size = new System.Drawing.Size(67, 20);
            this.btn_selectall_components.Text = "Select All";
            this.btn_selectall_components.Click += new System.EventHandler(this.btn_selectall_components_Click);
            // 
            // btn_clearselected_components
            // 
            this.btn_clearselected_components.ForeColor = System.Drawing.Color.Blue;
            this.btn_clearselected_components.Name = "btn_clearselected_components";
            this.btn_clearselected_components.Size = new System.Drawing.Size(93, 20);
            this.btn_clearselected_components.Text = "Clear Selected";
            this.btn_clearselected_components.Click += new System.EventHandler(this.btn_clearselected_components_click);
            // 
            // combo_website
            // 
            this.combo_website.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.combo_website.FormattingEnabled = true;
            this.combo_website.Location = new System.Drawing.Point(195, 118);
            this.combo_website.Name = "combo_website";
            this.combo_website.Size = new System.Drawing.Size(696, 21);
            this.combo_website.TabIndex = 8;
            // 
            // date_before
            // 
            this.date_before.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.date_before.Location = new System.Drawing.Point(195, 79);
            this.date_before.Name = "date_before";
            this.date_before.Size = new System.Drawing.Size(696, 20);
            this.date_before.TabIndex = 7;
            // 
            // date_after
            // 
            this.date_after.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.date_after.Location = new System.Drawing.Point(195, 41);
            this.date_after.Name = "date_after";
            this.date_after.Size = new System.Drawing.Size(696, 20);
            this.date_after.TabIndex = 6;
            // 
            // check_active
            // 
            this.check_active.AutoSize = true;
            this.check_active.Location = new System.Drawing.Point(7, 158);
            this.check_active.Name = "check_active";
            this.check_active.Size = new System.Drawing.Size(135, 17);
            this.check_active.TabIndex = 5;
            this.check_active.Text = "Get only active records";
            this.check_active.UseVisualStyleBackColor = true;
            // 
            // check_website
            // 
            this.check_website.AutoSize = true;
            this.check_website.Location = new System.Drawing.Point(7, 122);
            this.check_website.Name = "check_website";
            this.check_website.Size = new System.Drawing.Size(138, 17);
            this.check_website.TabIndex = 4;
            this.check_website.Text = "Get record from website";
            this.check_website.UseVisualStyleBackColor = true;
            // 
            // check_before
            // 
            this.check_before.AutoSize = true;
            this.check_before.Location = new System.Drawing.Point(6, 82);
            this.check_before.Name = "check_before";
            this.check_before.Size = new System.Drawing.Size(183, 17);
            this.check_before.TabIndex = 3;
            this.check_before.Text = "Get records modified on or before";
            this.check_before.UseVisualStyleBackColor = true;
            // 
            // check_after
            // 
            this.check_after.AutoSize = true;
            this.check_after.Location = new System.Drawing.Point(7, 44);
            this.check_after.Name = "check_after";
            this.check_after.Size = new System.Drawing.Size(174, 17);
            this.check_after.TabIndex = 1;
            this.check_after.Text = "Get records modified on or after";
            this.check_after.UseVisualStyleBackColor = true;
            // 
            // window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.gb_connectionDetails);
            this.Controls.Add(this.toolStripMenu);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "window";
            this.Size = new System.Drawing.Size(1355, 678);
            this.Load += new System.EventHandler(this.MyPluginControl_Load);
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            this.gb_connectionDetails.ResumeLayout(false);
            this.gb_connectionDetails.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.menu_selection_checklist.ResumeLayout(false);
            this.menu_selection_checklist.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.data_portalItems)).EndInit();
            this.gb_options.ResumeLayout(false);
            this.gb_options.PerformLayout();
            this.menu_selection_records.ResumeLayout(false);
            this.menu_selection_records.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStripMenu;
        private System.Windows.Forms.ToolStripButton btn_addTarget;
        private System.Windows.Forms.ToolStripSeparator tssSeparator1;
        private System.Windows.Forms.GroupBox gb_connectionDetails;
        private System.Windows.Forms.Label txt_targetName;
        private System.Windows.Forms.Label txt_trgtLabel;
        private System.Windows.Forms.ToolStripButton btn_transferRecords;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btn_loadSource;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.CheckedListBox checklist_items;
        private System.Windows.Forms.MenuStrip menu_selection_checklist;
        private System.Windows.Forms.ToolStripMenuItem btn_selectall_types;
        private System.Windows.Forms.ToolStripMenuItem btn_clearselected_types;
        private System.Windows.Forms.ToolStripButton btn_close;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btn_retrieveItems;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.GroupBox gb_options;
        private System.Windows.Forms.CheckBox check_active;
        private System.Windows.Forms.CheckBox check_website;
        private System.Windows.Forms.CheckBox check_before;
        private System.Windows.Forms.CheckBox check_after;
        private System.Windows.Forms.DateTimePicker date_before;
        private System.Windows.Forms.DateTimePicker date_after;
        private System.Windows.Forms.DataGridView data_portalItems;
        private System.Windows.Forms.ComboBox combo_website;
        private System.Windows.Forms.MenuStrip menu_selection_records;
        private System.Windows.Forms.ToolStripMenuItem btn_selectall_components;
        private System.Windows.Forms.ToolStripMenuItem btn_clearselected_components;
    }
}
