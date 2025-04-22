using McTools.Xrm.Connection;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using XrmToolBox.Extensibility;
using SiteComponentTransporter.AppCode;

namespace SiteComponentTransporter {
    public partial class window : MultipleConnectionsPluginControlBase {
        private Settings mySettings;
        private ConnectionDetail targetEnvironment = null;
        private List<PortalRecord> portalRecords = new List<PortalRecord>();
        private BindingList<PortalRecord> portalRecordsBinding = new BindingList<PortalRecord>();
        private List<OptionSetMap> componentTypeMap = new List<OptionSetMap>();

        public window () {
            InitializeComponent();
        }

        private void MyPluginControl_Load (object sender, EventArgs e) {
            //ShowInfoNotification("This is a notification that can lead to XrmToolBox repository", new Uri("https://github.com/MscrmTools/XrmToolBox"));

            // Loads or creates the settings for the plugin
            if (!SettingsManager.Instance.TryLoad(GetType(), out mySettings)) {
                mySettings = new Settings();
                LogWarning("Settings not found => a new settings file has been created!");
            }
            else {
                LogInfo("Settings found and loaded");  
            }

            data_portalItems.DataSource = portalRecordsBinding;

            data_portalItems.CurrentCellDirtyStateChanged += data_portalItems_on_CurrentCellDirtyStateChanged;
            data_portalItems.ColumnHeaderMouseClick += data_portalItems_ColumnHeaderMouseClick;
        }

        private void data_portalItems_on_CurrentCellDirtyStateChanged (object sender, EventArgs e) {
            if (data_portalItems.IsCurrentCellDirty)
                data_portalItems.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void data_portalItems_ColumnHeaderMouseClick (object sender, DataGridViewCellMouseEventArgs e) {
            string columnName = data_portalItems.Columns[e.ColumnIndex].Name;

            var sortedList = portalRecordsBinding.OrderBy(r =>
                typeof(PortalRecord).GetProperty(columnName).GetValue(r)).ToList();

            portalRecordsBinding = new BindingList<PortalRecord>(sortedList);
            data_portalItems.DataSource = portalRecordsBinding;
        }

        public override void UpdateConnection (IOrganizationService newService, ConnectionDetail detail, string actionName, object parameter) {
            base.UpdateConnection(newService, detail, actionName, parameter);

            if (mySettings != null && detail != null) {
                mySettings.LastUsedOrganizationWebappUrl = detail.WebApplicationUrl;
                LogInfo("Connection has changed to: {0}", detail.WebApplicationUrl);
            }

            ExecuteMethod(PopulateWebsiteOptions);
        }

        private void MyPluginControl_OnCloseTool (object sender, EventArgs e) {
            // Before leaving, save the settings
            SettingsManager.Instance.Save(GetType(), mySettings);
        }

        protected override void ConnectionDetailsUpdated (NotifyCollectionChangedEventArgs e) {
            if (AdditionalConnectionDetails.Count > 0)
                targetEnvironment = AdditionalConnectionDetails.LastOrDefault();
            UpdateConnectionText();
        }

        // Click Handlers
        private void btn_addTarget_Click (object sender, EventArgs e) {
            AdditionalConnectionDetails.Clear();
            AddAdditionalOrganization();
        }

        private void btn_loadSource_Click (object sender, EventArgs e) {
            checklist_items.Items.Clear();
            ExecuteMethod(GetSiteComponentTypes);
        }
        private void tsbClose_Click (object sender, EventArgs e) {
            CloseTool();
        }
        private void btn_retrieveItems_Click (object sender, EventArgs e) {
            ExecuteMethod(GetPortalRecords);
        }

        private void btn_transferRecords_Click (object sender, EventArgs e) {
            ExecuteMethod(TransferRecords);
        }

        private void btn_selectall_types_Click (object sender, EventArgs e) {
            if (checklist_items.Items.Count > 0) {
                for (int i = 0; i < checklist_items.Items.Count ; i++) {
                    checklist_items.SetItemChecked(i, true);
                    checklist_items.SetItemCheckState(i, CheckState.Checked);
                }
            }
        }

        private void btn_clearselected_types_Click (object sender, EventArgs e) {
            if (checklist_items.Items.Count > 0) {
                for (int i = 0 ; i < checklist_items.Items.Count ; i++) {
                    checklist_items.SetItemChecked(i, false);
                    checklist_items.SetItemCheckState(i, CheckState.Unchecked);
                }
            }
        }

        private void btn_selectall_components_Click (object sender, EventArgs e) {
            foreach (var item in portalRecordsBinding)
                item.Selected = true;
        }

        private void btn_clearselected_components_click (object sender, EventArgs e) {
            foreach (var item in portalRecordsBinding)
                item.Selected = false;
        }

        
        // Helper Functions
        private void GetAccounts () {
            WorkAsync(new WorkAsyncInfo {
                Message = "Getting accounts",
                Work = (worker, args) => {
                    args.Result = Service.RetrieveMultiple(new QueryExpression("account") {
                        TopCount = 50
                    });
                },
                PostWorkCallBack = (args) => {
                    if (args.Error != null) {
                        MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    var result = args.Result as EntityCollection;
                    if (result != null) {
                        MessageBox.Show($"Found {result.Entities.Count} accounts");
                    }
                }
            });
        }

        private void UpdateConnectionText () {
            if (targetEnvironment == null) {
                txt_targetName.Text = "Unassigned";
                txt_targetName.ForeColor = Color.Red;
            }
            else {
                txt_targetName.Text = targetEnvironment.ConnectionName;
                txt_targetName.ForeColor = Color.Green;
            }         
        }

        private void GetSiteComponentTypes () {
            RetrieveOptionSetRequest request = new RetrieveOptionSetRequest();
            request.Name = "powerpagecomponenttype";

            WorkAsync(new WorkAsyncInfo {
                Message = "Getting Component Types",
                Work = (worker, args) => {
                    args.Result = Service.Execute(request);
               
                },
                PostWorkCallBack = (args) => {
                    if (args.Error != null) {
                        MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    RetrieveOptionSetResponse result = args.Result as RetrieveOptionSetResponse;
                    var options = (OptionSetMetadata) result.OptionSetMetadata;
                    componentTypeMap.Clear();
                    foreach (var item in options.Options) {
                        checklist_items.Items.Add($"{item.Label.UserLocalizedLabel.Label} ({item.Value})");

                        componentTypeMap.Add(new OptionSetMap(item.Label.UserLocalizedLabel.Label, item.Value));
                    }
                    PopulateWebsiteOptions();
                }
            });
        }

        private void GetPortalRecords() {
            if (checklist_items.CheckedItems.Count == 0) {
                MessageBox.Show("No types are selected");
                return;
            }
            portalRecordsBinding.Clear();

            List<int> recordTypes = new List<int>();
            foreach (string item in checklist_items.CheckedItems) {
                int optionsetValue = int.Parse(item.Split('(')[1].Split(')')[0]);
                recordTypes.Add(optionsetValue);
            }

            FilterExpression recordTypeFilter = new FilterExpression();
            recordTypeFilter.FilterOperator = LogicalOperator.Or;

            foreach (int optionsetValue in recordTypes) {
                ConditionExpression condition1 = new ConditionExpression();
                condition1.AttributeName = "powerpagecomponenttype";
                condition1.Operator = ConditionOperator.Equal;
                condition1.Values.Add(optionsetValue);

                recordTypeFilter.AddCondition(condition1);
            }

            FilterExpression recordAndFilter = new FilterExpression();

            // Conditons
            ConditionExpression activeConditon = new ConditionExpression();
            activeConditon.AttributeName = "statecode";
            activeConditon.Operator = ConditionOperator.Equal;
            activeConditon.Values.Add(0);
            if (check_active.Checked)
                recordAndFilter.AddCondition(activeConditon);

            ConditionExpression beforeCondition = new ConditionExpression();
            beforeCondition.AttributeName = "modifiedon";
            beforeCondition.Operator = ConditionOperator.OnOrBefore;
            beforeCondition.Values.Add(date_before.Value);
            if (check_before.Checked)
                recordAndFilter.AddCondition(beforeCondition);

            ConditionExpression afterCondition = new ConditionExpression();
            afterCondition.AttributeName = "modifiedon";
            afterCondition.Operator = ConditionOperator.OnOrAfter;
            afterCondition.Values.Add(date_after.Value);
            if (check_after.Checked)
                recordAndFilter.AddCondition(afterCondition);

            Guid websiteGuid = Guid.Empty;
            try {
                websiteGuid = Guid.Parse(combo_website.Text.Split('(')[1].Split(')')[0]);
            }
            catch (Exception ex) {
                LogError($"Error with website guid: {ex}");
            }
            
            ConditionExpression websiteCondition = new ConditionExpression();
            websiteCondition.AttributeName = "powerpagesiteid";
            websiteCondition.Operator = ConditionOperator.Equal;
            websiteCondition.Values.Add(websiteGuid);
            if (check_website.Checked)
                recordAndFilter.AddCondition(websiteCondition);
            
                

            QueryExpression query = new QueryExpression("powerpagecomponent");
            query.Criteria.AddFilter(recordTypeFilter);
            query.Criteria.AddFilter(recordAndFilter);
            query.ColumnSet = new ColumnSet(true);

            WorkAsync(new WorkAsyncInfo {
                Message = "Getting Portal Records",
                Work = (worker, args) => {
                    args.Result = Service.RetrieveMultiple(query);
                },
                PostWorkCallBack = (args) => {
                    if (args.Error != null) {
                        MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    EntityCollection records = args.Result as EntityCollection;
                    foreach (Entity record in records.Entities) {
                        string name = record.GetAttributeValue<string>("name");
                        string createdOn = record.GetAttributeValue<DateTime>("createdon").ToShortDateString();
                        string modifiedOn = record.GetAttributeValue<DateTime>("modifiedon").ToShortDateString();
                        string modifiedBy = record.GetAttributeValue<EntityReference>("modifiedby").Name;
                        string type = componentTypeMap.Where(i => i.Value == record.GetAttributeValue<OptionSetValue>("powerpagecomponenttype").Value).FirstOrDefault().Name;
                        Guid siteComponentReference = record.GetAttributeValue<Guid>("powerpagecomponentid");

                        PortalRecord newRecord = new PortalRecord(name, createdOn, modifiedOn, modifiedBy, type);
                        newRecord.ComponentReference = siteComponentReference;
                        newRecord.SiteComponent = record;
                        portalRecordsBinding.Add(newRecord);
                    }
                }
            });
        }

        private void TransferRecords() {
            if (targetEnvironment == null) {
                MessageBox.Show("Select a target environment before attempting to transfer records.");
                return;
            }

            List<PortalRecord> selectedRecords = portalRecordsBinding.Where(i => i.Selected == true).ToList();

            if (selectedRecords.Count <= 0) {
                MessageBox.Show("No Records Selected to transfer");

                return;
            }

            int createdItems = 0;
            int updatedItems = 0;
            int errorItems = 0;

            WhoAmIResponse resp = targetEnvironment.ServiceClient.Execute(new WhoAmIRequest()) as WhoAmIResponse;
            EntityReference newOwner = new EntityReference("systemuser", resp.UserId);
            EntityReference newBusinessUnit = new EntityReference("businessunit", resp.BusinessUnitId);

            WorkAsync(new WorkAsyncInfo {
                Message = $"Transffering {selectedRecords.Count} record(s)",
                Work = (worker, args) => {
                    foreach (PortalRecord record in selectedRecords) {
                        record.SiteComponent.Attributes["ownerid"] = newOwner;
                        record.SiteComponent.Attributes["modifiedby"] = newOwner;
                        record.SiteComponent.Attributes["createdby"] = newOwner;
                        record.SiteComponent.Attributes["owninguser"] = newOwner;
                        record.SiteComponent.Attributes["owningbusinessunit"] = newBusinessUnit;

                        if (DoesRecordExist(record.ComponentReference)) {
                            try {
                                targetEnvironment.ServiceClient.Update(record.SiteComponent);
                                updatedItems++;
                            }
                            catch (Exception ex) {
                                errorItems++;
                                LogError($"Error Creating {record.Name}: {ex}");
                            }
                        }
                        else {
                            try {
                                targetEnvironment.ServiceClient.Create(record.SiteComponent);
                                createdItems++;
                            }
                            catch (Exception ex) {
                                errorItems++;
                                LogError($"Error Creating {record.Name}: {ex}");
                            }
                        }
                    }
                },
                PostWorkCallBack = (args) => {
                    if (errorItems <= 0)
                        MessageBox.Show($"{createdItems} have been created and {updatedItems} have been updated.");
                    else
                        MessageBox.Show($"{createdItems} have been created and {updatedItems} have been updated. {errorItems} were encountered check the logs for more details!");
                }
            });
        }   

        private bool DoesRecordExist(Guid recordId) {
            try {
                Entity existingRecord = targetEnvironment.ServiceClient.Retrieve("powerpagecomponent", recordId, new ColumnSet(new string[] { "powerpagecomponentid" }));
                return existingRecord != null;
            }
            catch (Exception ex) {
                return false;
            }
        }

        private void PopulateWebsiteOptions() {
            QueryExpression queryExpression = new QueryExpression("mspp_website");
            queryExpression.ColumnSet = new ColumnSet(new string[] {"mspp_name, mspp_websiteid"});

            WorkAsync(new WorkAsyncInfo {
                Message = "Loading Websites",
                Work = (worker, args) => {
                    args.Result = Service.RetrieveMultiple(queryExpression);
                },
                PostWorkCallBack = (args) => {
                    if (args.Error != null) {
                        MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    if (args.Result != null) {
                        combo_website.Items.Clear();
                        EntityCollection records = args.Result as EntityCollection;
                        foreach (Entity entity in records.Entities) {
                            combo_website.Items.Add($"{entity.Attributes["mspp_name"]} ({entity.Attributes["mspp_websiteid"]})");
                        }
                    }
                }
            });
        }
    }
}