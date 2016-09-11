using DevExpress.XtraEditors;
using OBALog.Business;
using System;
using System.Data;
using System.Linq;

namespace OBALog.Windows
{
    public partial class ManageConfigurations : XtraForm
    {
        public bool FormDirty { get; set; }

        public ManageConfigurations()
        {
            InitializeComponent();

            try
            {
                bindInitialData();
                bindConfigurations();
                FormDirty = false;
            }
            catch (Exception ex)
            {
                AuditFactory.AuditLog(ex);
                ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, ex.Message);
            }
        }

        private void bindInitialData()
        {
            using (DataTable dt = new BL_Salutation().select(new OBALog.Model.ML_Salutation { Salutation = null }))
            {
                cbo_salutation.Properties.DataSource = dt;
                cbo_salutation.Properties.DisplayMember = "Salutation";
                cbo_salutation.Properties.ValueMember = "Key";
            }

            using (DataTable dt = new BL_Country().select(new OBALog.Model.ML_Country { Country = null }))
            {
                cbo_country.Properties.DataSource = dt;
                cbo_country.Properties.DisplayMember = "Country";
                cbo_country.Properties.ValueMember = "Key";
            }
        }

        private void bindConfigurations()
        {
            try
            {
                using (DataTable dt = new BL_Configurations().select())
                {
                    EnumerableRowCollection<DataRow> MembershipNoIndex = from myRow in dt.AsEnumerable() where myRow.Field<string>("ConfigurationName") == Configurations.MembershipNoIndexStr select myRow;
                    if (MembershipNoIndex.Any())
                    {
                        rtb_mem_no_desc.Text = MembershipNoIndex.First()["Description"].ToString();
                        txt_mem_no_value.Text = MembershipNoIndex.First()["ConfigurationValue"].ToString();
                        txt_mem_no_conf_by.Text = MembershipNoIndex.First()["Name"].ToString();
                        txt_mem_no_conf_date.Text = Convert.ToDateTime(MembershipNoIndex.First()["UpdatedDate"].ToString()).ToShortDateString();
                    }

                    EnumerableRowCollection<DataRow> MembershipDate = from myRow in dt.AsEnumerable() where myRow.Field<string>("ConfigurationName") == Configurations.MembershipDateStr select myRow;
                    if (MembershipDate.Any())
                    {
                        txt_mem_date_desc.Text = MembershipDate.First()["Description"].ToString();
                        txt_mem_date_value.EditValue = Convert.ToDateTime(MembershipDate.First()["ConfigurationValue"].ToString()).ToShortDateString();
                        txt_mem_date_conf_by.Text = MembershipDate.First()["Name"].ToString();
                        txt_mem_date_conf_date.Text = Convert.ToDateTime(MembershipDate.First()["UpdatedDate"].ToString()).ToShortDateString();
                    }

                    EnumerableRowCollection<DataRow> InternetConnection = from myRow in dt.AsEnumerable() where myRow.Field<string>("ConfigurationName") == Configurations.InternetConnectionStr select myRow;
                    if (InternetConnection.Any())
                    {
                        txt_int_con_desc.Text = InternetConnection.First()["Description"].ToString();
                        tsw_int_con.IsOn = Convert.ToBoolean(InternetConnection.First()["ConfigurationValue"].ToString());
                        txt_int_con_conf_by.Text = InternetConnection.First()["Name"].ToString();
                        txt_int_con_conf_date.Text = Convert.ToDateTime(InternetConnection.First()["UpdatedDate"].ToString()).ToShortDateString();
                    }

                    EnumerableRowCollection<DataRow> ReceiptNo = from myRow in dt.AsEnumerable() where myRow.Field<string>("ConfigurationName") == Configurations.ReceiptNoStr select myRow;
                    if (ReceiptNo.Any())
                    {
                        txt_rec_no_desc.Text = ReceiptNo.First()["Description"].ToString();
                        txt_rec_no_value.Text = ReceiptNo.First()["ConfigurationValue"].ToString();
                        txt_rec_no_conf_by.Text = ReceiptNo.First()["Name"].ToString();
                        txt_rec_no_conf_date.Text = Convert.ToDateTime(ReceiptNo.First()["UpdatedDate"].ToString()).ToShortDateString();
                    }

                    EnumerableRowCollection<DataRow> ReceiptAmount = from myRow in dt.AsEnumerable() where myRow.Field<string>("ConfigurationName") == Configurations.ReceiptAmountStr select myRow;
                    if (ReceiptAmount.Any())
                    {
                        txt_rec_amount_desc.Text = ReceiptAmount.First()["Description"].ToString();
                        lst_receipt_amount.Items.Clear();
                        lst_receipt_amount.Items.AddRange(ReceiptAmount.First()["ConfigurationValue"].ToString().Split(new char[] { ';' }));
                        txt_rec_amount_conf_by.Text = ReceiptAmount.First()["Name"].ToString();
                        txt_rec_amount_conf_date.Text = Convert.ToDateTime(ReceiptAmount.First()["UpdatedDate"].ToString()).ToShortDateString();
                    }

                    EnumerableRowCollection<DataRow> TimeoutPeriod = from myRow in dt.AsEnumerable() where myRow.Field<string>("ConfigurationName") == Configurations.TimeoutPeriodStr select myRow;
                    if (TimeoutPeriod.Any())
                    {
                        txt_timeout_desc.Text = TimeoutPeriod.First()["Description"].ToString();
                        string[] time = TimeoutPeriod.First()["ConfigurationValue"].ToString().Split(new char[] { ':' });
                        nud_timeout_hrs.Text = time[0];
                        nud_timeout_minutes.Text = time[1];
                        nud_timeout_seconds.Text = time[2];
                        txt_timeout_conf_by.Text = TimeoutPeriod.First()["Name"].ToString();
                        txt_timeout_conf_date.Text = Convert.ToDateTime(TimeoutPeriod.First()["UpdatedDate"].ToString()).ToShortDateString();
                    }

                    EnumerableRowCollection<DataRow> LogoffPeriod = from myRow in dt.AsEnumerable() where myRow.Field<string>("ConfigurationName") == Configurations.LogoffPeriodStr select myRow;
                    if (LogoffPeriod.Any())
                    {
                        mem_logout_desc.Text = LogoffPeriod.First()["Description"].ToString();
                        string[] time = LogoffPeriod.First()["ConfigurationValue"].ToString().Split(new char[] { ':' });
                        nud_msg_box_minutes.Text = time[0];
                        nud_msg_box_seconds.Text = time[1];
                        txt_logout_conf_by.Text = LogoffPeriod.First()["Name"].ToString();
                        txt_logout_conf_date.Text = Convert.ToDateTime(LogoffPeriod.First()["UpdatedDate"].ToString()).ToShortDateString();
                    }

                    EnumerableRowCollection<DataRow> DefaultSalutation = from myRow in dt.AsEnumerable() where myRow.Field<string>("ConfigurationName") == Configurations.DefaultSalutationStr select myRow;
                    if (DefaultSalutation.Any())
                    {
                        mem_def_val_desc.Text = DefaultSalutation.First()["Description"].ToString();
                        cbo_salutation.EditValue = DefaultSalutation.First()["ConfigurationValue"].ToString();
                        txt_def_val_conf_by.Text = DefaultSalutation.First()["Name"].ToString();
                        txt_def_val_conf_date.Text = Convert.ToDateTime(DefaultSalutation.First()["UpdatedDate"].ToString()).ToShortDateString();
                    }

                    EnumerableRowCollection<DataRow> DefaultCountry = from myRow in dt.AsEnumerable() where myRow.Field<string>("ConfigurationName") == Configurations.DefaultCountryStr select myRow;
                    if (DefaultCountry.Any())
                    {
                        cbo_country.EditValue = DefaultCountry.First()["ConfigurationValue"].ToString();
                        cbo_country_EditValueChanged(this, new EventArgs());
                    }

                    EnumerableRowCollection<DataRow> DefaultCity = from myRow in dt.AsEnumerable() where myRow.Field<string>("ConfigurationName") == Configurations.DefaultCityStr select myRow;
                    if (DefaultCity.Any())
                    {
                        cbo_city.EditValue = DefaultCity.First()["ConfigurationValue"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                AuditFactory.AuditLog(ex);
                ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, ex.Message);
            }
        }

        private void cbo_country_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbo_country.EditValue != null)
                {
                    using (DataTable dt = new BL_City().selectByCountry(new OBALog.Model.ML_City { CountryKey = Convert.ToInt32(cbo_country.EditValue) }))
                    {
                        cbo_city.Clear();
                        cbo_city.Properties.DataSource = dt;
                        cbo_city.Properties.DisplayMember = "City";
                        cbo_city.Properties.ValueMember = "CityKey";
                        cbo_city.SelectFirstIndex();
                    }
                    FormDirty = true;
                }
            }
            catch (Exception ex)
            {
                AuditFactory.AuditLog(ex);
                ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, ex.Message);
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                switch (tab_configurations.SelectedTabPage.Text.Trim())
                {
                    case "Membership No":
                        new BL_Configurations().update(new Model.ML_Configurations { ConfigurationName = Configurations.MembershipNoIndexStr, Description = rtb_mem_no_desc.Text, ConfigurationValue = txt_mem_no_value.Text, UserKey = UniversalVariables.UserKey });
                        break;
                    case "Receipt No":
                        new BL_Configurations().update(new Model.ML_Configurations { ConfigurationName = Configurations.ReceiptNoStr, Description = txt_rec_no_desc.Text, ConfigurationValue = txt_rec_no_value.Text, UserKey = UniversalVariables.UserKey });
                        break;
                    case "Membership Date":
                        new BL_Configurations().update(new Model.ML_Configurations { ConfigurationName = Configurations.MembershipDateStr, Description = txt_mem_date_desc.Text, ConfigurationValue = txt_mem_date_value.Text, UserKey = UniversalVariables.UserKey });
                        break;
                    case "Internet Connection":
                        new BL_Configurations().update(new Model.ML_Configurations { ConfigurationName = Configurations.InternetConnectionStr, Description = txt_int_con_desc.Text, ConfigurationValue = tsw_int_con.IsOn.ToString(), UserKey = UniversalVariables.UserKey });
                        break;
                    case "Receipt Amount":
                        string receiptValues = string.Empty;
                        int count = 0;
                        foreach (string rec_val in lst_receipt_amount.Items)
                        {
                            receiptValues = (count == lst_receipt_amount.Items.Count) ? string.Format("{0}{1}", receiptValues, rec_val) : string.Format("{0}{1};", receiptValues, rec_val);
                            count++;
                        }
                        new BL_Configurations().update(new Model.ML_Configurations { ConfigurationName = Configurations.ReceiptAmountStr, Description = txt_rec_amount_desc.Text, ConfigurationValue = receiptValues, UserKey = UniversalVariables.UserKey });
                        break;
                    case "System Timeout":
                        new BL_Configurations().update(new Model.ML_Configurations { ConfigurationName = Configurations.TimeoutPeriodStr, Description = txt_timeout_desc.Text, ConfigurationValue = string.Format("{0}:{1}:{2}", nud_timeout_hrs.Text.PadLeft(2, '0'), nud_timeout_minutes.Text.PadLeft(2, '0'), nud_timeout_seconds.Text.PadLeft(2, '0')), UserKey = UniversalVariables.UserKey });
                        break;
                    case "Logout Confirmation Timeout":
                        new BL_Configurations().update(new Model.ML_Configurations { ConfigurationName = Configurations.LogoffPeriodStr, Description = mem_logout_desc.Text, ConfigurationValue = string.Format("{0}:{1}", nud_msg_box_minutes.Text.PadLeft(2, '0'), nud_msg_box_seconds.Text.PadLeft(2, '0')), UserKey = UniversalVariables.UserKey });
                        break;
                    case "Default Values":
                        if (cbo_country.EditValue != null && cbo_city.EditValue != null && cbo_salutation.EditValue != null)
                        {
                            new BL_Configurations().update(new Model.ML_Configurations { ConfigurationName = Configurations.DefaultCountryStr, Description = mem_def_val_desc.Text, ConfigurationValue = cbo_country.EditValue.ToString(), UserKey = UniversalVariables.UserKey });

                            new BL_Configurations().update(new Model.ML_Configurations { ConfigurationName = Configurations.DefaultCityStr, Description = mem_def_val_desc.Text, ConfigurationValue = cbo_city.EditValue.ToString(), UserKey = UniversalVariables.UserKey });

                            new BL_Configurations().update(new Model.ML_Configurations { ConfigurationName = Configurations.DefaultSalutationStr, Description = mem_def_val_desc.Text, ConfigurationValue = cbo_salutation.EditValue.ToString(), UserKey = UniversalVariables.UserKey });
                        }
                        else
                        {
                            ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Exclamation, "One or more required values are null. Please re-check!", "Error Saving");
                        }
                        break;
                    default:
                        break;
                }
                ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Information, "Configuration settings saved. The new settings will be applied at next login.", "Record Updated");
                bindConfigurations();
                FormDirty = false;
            }
            catch (Exception ex)
            {
                AuditFactory.AuditLog(ex);
                ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, ex.Message);
            }

        }

        private void btn_add_receipt_amount_Click(object sender, EventArgs e)
        {
            if (txt_rec_amount_value.IsNotEmpty())
            {
                lst_receipt_amount.Items.Add(txt_rec_amount_value.Text);
                FormDirty = true;
                txt_rec_amount_value.ClearAndFocus();
            }
        }

        private void btn_remove_receipt_amount_Click(object sender, EventArgs e)
        {
            if (lst_receipt_amount.Items.Count != 0 && lst_receipt_amount.SelectedIndex > -1)
            {
                lst_receipt_amount.Items.RemoveAt(lst_receipt_amount.SelectedIndex);
                FormDirty = true;
            }
        }

        private void txt_EditValueChanged(object sender, EventArgs e)
        {
            FormDirty = true;
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ManageConfigurations_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            e.Cancel = !ApplicationUtilities.CheckFormDirtyClose(CloseFormWithChecks, FormDirty);
        }

        private bool CloseFormWithChecks()
        {
            return true;
        }

    }
}
