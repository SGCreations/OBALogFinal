using DevExpress.XtraEditors;
using OBALog.Business;
using OBALog.Model;
using System;
using System.Data;

namespace OBALog.Windows
{
    public partial class ManageCountryCity : XtraForm
    {
        private bool hasAccessInsert = Privileges.CheckAccess(Privileges.CountryCity_Insert);
        private bool hasAccessUpdate = Privileges.CheckAccess(Privileges.CountryCity_Update);
        private bool hasAccessDelete = Privileges.CheckAccess(Privileges.CountryCity_Delete);

        public bool FormDirty { get; set; }

        public int CountryID { get; set; }
        public int CityID { get; set; }

        public bool IsNewCountry { get; set; }
        public bool IsNewCity { get; set; }

        public string LastCountry { get; set; }
        public string LastCity { get; set; }

        public ManageCountryCity()
        {
            try
            {
                InitializeComponent();

                if (BindCountry() == 0)
                {
                    ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Exclamation, "No countries are available to show. Please add a new country!", "Message");
                    btn_new_country.PerformClick();
                }

                btn_new_country.Enabled = btn_new_city.Enabled = hasAccessInsert;
                btn_delete_country.Enabled = btn_delete_city.Enabled = hasAccessDelete;
                btn_save_country.Enabled = btn_save_city.Enabled = (hasAccessInsert || hasAccessUpdate);
            }
            catch (Exception ex)
            {
                AuditFactory.AuditLog(ex);
                ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, ex.Message);
            }
        }

        #region Country
        private int BindCountry()
        {
            using (DataTable dt = new BL_Country().select(new ML_Country { Country = null }))
            {
                lst_country.UnSelectAll();
                lst_country.DataSource = dt;
                lst_country.DisplayMember = "Country";
                lst_country.ValueMember = "Key";
                return dt.Rows.Count;
            }
        }

        private void lst_country_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lst_country.SelectedIndex > -1)
                {
                    DataRowView currentRow = (lst_country.SelectedItem as DataRowView);
                    if (currentRow != null)
                    {
                        txt_new_country.Text = currentRow.Row["Country"].ToString();
                        CountryID = (int)currentRow.Row["Key"];

                        BindCity(CountryID);
                        FormDirty = false;
                    }
                }
            }
            catch (Exception ex)
            {
                AuditFactory.AuditLog(ex);
                ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, ex.Message);
            }
        }

        private int BindCity(int CountryID)
        {
            using (DataTable dt = new BL_City().selectByCountry(new ML_City { CountryKey = CountryID }))
            {
                txt_new_city.Clear();
                lst_city.UnSelectAll();
                lst_city.DataSource = dt;
                lst_city.DisplayMember = "City";
                lst_city.ValueMember = "CityKey";

                return dt.Rows.Count;
            }
        }

        private void btn_new_country_Click(object sender, EventArgs e)
        {
            try
            {
                ApplicationUtilities.CheckFormDirty(NewCountry, FormDirty);
                //NewCountry();
            }
            catch (Exception ex)
            {
                AuditFactory.AuditLog(ex);
                ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, ex.Message);
            }
        }

        private void NewCountry()
        {
            txt_new_country.ClearAndFocus();
            lst_country.Enabled = false;
            lst_city.Clear();
            txt_new_city.Clear();
            grp_cities.Enabled = false;
            CountryID = 0;
            CityID = 0;
            btn_delete_country.Enabled = false;
            btn_new_country.Enabled = false;
            IsNewCountry = true;
            IsNewCity = false;

            FormDirty = false;
        }

        private void btn_save_country_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsNewCountry && !hasAccessUpdate)
                {
                    ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, "You have no save rights.", "Access Denied");
                    return;
                }

                if (txt_new_country.IsNotEmpty())
                {
                    using (DataTable Table = new BL_Country().select(new ML_Country { Country = txt_new_country.Text }))
                    {
                        if (Table.Rows.Count < 1)
                        {
                            if (IsNewCountry)
                            {
                                new BL_Country().insert(new ML_Country { Country = txt_new_country.Text });
                            }
                            else if (CountryID > 0)
                            {
                                new BL_Country().update(new ML_Country { Key = CountryID, Country = txt_new_country.Text });
                            }

                            ResetCountryForm();
                            BindCountry();
                            SetPrevious();
                        }
                        else
                        {
                            ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, "The entered country is already in the database. Please re-check!", "Error");
                        }
                    }
                }
                else
                {
                    ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Exclamation, "Null value detected for country. Please re-check!", "Error!");
                }
            }
            catch (Exception ex)
            {
                AuditFactory.AuditLog(ex);
                ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, ex.Message);
            }
        }

        private void btn_delete_country_Click(object sender, EventArgs e)
        {
            try
            {
                if (CountryID > 0)
                {
                    if (new BL_Country().selectUsage(new ML_Country { Key = CountryID }) == 0)
                    {
                        if (ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Warning, string.Format("Are you sure you want to delete the country {0} from the database? WARNING: All its cities will also be deleted!", lst_country.Text), "Warning") == System.Windows.Forms.DialogResult.OK)
                        {
                            new BL_City().deleteByCountry(new ML_City { CountryKey = CountryID });
                            new BL_Country().delete(new ML_Country { Key = CountryID });

                            ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Information, string.Format("Country {0} and all its cities have been successfully deleted.", lst_country.Text), "Deletion Successful.");

                            ResetCountryForm();
                            BindCountry();
                        }
                    }
                    else
                    {
                        ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, "The country you are trying to delete has been referenced in one or more member records. This country cannot be deleted.", "Error");
                    }
                }
            }
            catch (Exception ex)
            {
                AuditFactory.AuditLog(ex);
                ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, ex.Message);
            }
        }

        private void ResetCountryForm()
        {
            FormDirty = false;

            txt_new_country.Clear();
            lst_country.Enabled = true;
            grp_cities.Enabled = true;
            btn_delete_country.Enabled = true;
            btn_new_country.Enabled = true;

            IsNewCountry = false;
            IsNewCity = false;
        }
        #endregion

        #region City
        private void lst_city_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lst_city.SelectedIndex > -1)
                {
                    DataRowView currentRow = (lst_city.SelectedItem as DataRowView);
                    if (currentRow != null)
                    {
                        txt_new_city.Text = currentRow.Row["City"].ToString();
                        CityID = (int)currentRow.Row["CityKey"];
                        FormDirty = false;
                    }
                }
            }
            catch (Exception ex)
            {
                AuditFactory.AuditLog(ex);
                ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, ex.Message);
            }
        }

        private void btn_new_city_Click(object sender, EventArgs e)
        {
            try
            {
                ApplicationUtilities.CheckFormDirty(NewCity, FormDirty);
            }
            catch (Exception ex)
            {
                AuditFactory.AuditLog(ex);
                ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, ex.Message);
            }
        }


        private void NewCity()
        {
            lst_city.Enabled = false;
            lbl_message.Visible = true;
            lbl_message.Text = "Note: The city will be added under the selected country.";
            grp_countries.Enabled = false;
            IsNewCountry = false;
            IsNewCity = true;
            btn_delete_city.Enabled = hasAccessDelete;
            btn_new_city.Enabled = hasAccessInsert;
            txt_new_city.ClearAndFocus();
            FormDirty = false;
        }

        private void btn_save_city_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsNewCity && !hasAccessUpdate)
                {
                    ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, "You have no save rights.", "Access Denied");
                    return;
                }

                if (txt_new_city.IsNotEmpty())
                {
                    using (DataTable Table = new BL_City().select(new ML_City { City = txt_new_city.Text }))
                    {
                        if (Table.Rows.Count < 1)
                        {
                            if (IsNewCity)
                            {
                                new BL_City().insert(new ML_City { CountryKey = CountryID, City = txt_new_city.Text });
                            }
                            else if (CityID > 0)
                            {
                                new BL_City().update(new ML_City { Key = CityID, City = txt_new_city.Text });
                            }

                            LastCountry = lst_country.Text;
                            LastCity = txt_new_city.Text;

                            ResetCityForm();
                            lst_country_SelectedIndexChanged(this, new EventArgs());
                            SetPrevious();

                        }
                        else
                        {
                            ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, "The entered city is already in the database. Please re-check!", "Error");
                        }
                    }
                }
                else
                {
                    ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Exclamation, "Null value detected for city. Please re-check!", "Error!");
                }
            }
            catch (Exception ex)
            {
                AuditFactory.AuditLog(ex);
                ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, ex.Message);
            }
        }

        private void SetPrevious()
        {
            if (LastCountry.IsNotEmpty())
            {
                lst_country.SelectedIndex = lst_country.FindStringExact(LastCountry);
            }

            if (LastCity.IsNotEmpty())
            {
                lst_city.SelectedIndex = lst_city.FindStringExact(LastCity);
            }
        }

        private void btn_delete_city_Click(object sender, EventArgs e)
        {
            try
            {
                if (CityID > 0)
                {
                    if (new BL_City().selectUsage(new ML_City { Key = CityID }) == 0)
                    {
                        if (ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Warning, string.Format("Are you sure you want to delete the city {0} from the database?", lst_city.Text), "Warning") == System.Windows.Forms.DialogResult.OK)
                        {
                            new BL_City().delete(new ML_City { Key = CityID });
                            ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Warning, string.Format("City {0} has been successfully deleted.", lst_city.Text), "Deletion Successful.");
                            ResetCityForm();
                            lst_country_SelectedIndexChanged(this, new EventArgs());
                        }
                    }
                    else
                    {
                        ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, "The city you are trying to delete has been referenced in one or more member records. This city cannot be deleted.", "Error");
                    }
                }
            }
            catch (Exception ex)
            {
                AuditFactory.AuditLog(ex);
                ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, ex.Message);
            }
        }

        private void ResetCityForm()
        {
            FormDirty = false;

            lst_city.Enabled = true;
            lbl_message.Visible = false;
            grp_countries.Enabled = true;
            IsNewCountry = false;
            IsNewCity = false;
            btn_delete_city.Enabled = hasAccessDelete;
            btn_new_city.Enabled = hasAccessInsert;
            txt_new_city.Clear();
        }
        #endregion

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool CloseFormWithChecks()
        {
            if (IsNewCountry)
            {
                ResetCountryForm();
                BindCountry();
                return false;
            }
            else if (IsNewCity)
            {
                ResetCityForm();
                lst_city_SelectedIndexChanged(this, new EventArgs());
                return false;
            }
            else
            {
                return true;
            }

        }

        private void txt_EditValueChanged(object sender, EventArgs e)
        {
            FormDirty = true;
        }

        private void ManageCountryCity_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            e.Cancel = !ApplicationUtilities.CheckFormDirtyClose(CloseFormWithChecks, FormDirty);
        }
    }
}
