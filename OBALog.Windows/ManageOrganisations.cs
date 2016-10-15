using DevExpress.XtraEditors;
using OBALog.Business;
using OBALog.Model;
using System;
using System.Data;
using System.Windows.Forms;

namespace OBALog.Windows
{
    public partial class ManageOrganisations : XtraForm
    {

        private bool hasAccessInsert = Privileges.CheckAccess(Privileges.Organisations_Insert);
        private bool hasAccessUpdate = Privileges.CheckAccess(Privileges.Organisations_Update);
        private bool hasAccessDelete = Privileges.CheckAccess(Privileges.Organisations_Delete);

        public bool FormDirty { get; set; }

        public int SelectedID { get; set; }
        public bool IsNewRecord { get; set; }
        public int? SelectedIndex { get; set; }

        public string LastOrganization { get; set; }

        public ManageOrganisations()
        {
            try
            {
                InitializeComponent();

                BindCategory();
                BindCountry();

                if (BindOrganisation() == 0)
                {
                    ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Exclamation, "No organisations are available to show. Please add a new organisation!", "Message");
                    btn_new_organisation.PerformClick();
                }

                btn_new_organisation.Enabled = hasAccessInsert;
                btn_delete_organisation.Enabled = hasAccessDelete;
                btn_save_organisation.Enabled = (hasAccessInsert || hasAccessUpdate);
            }
            catch (Exception ex)
            {
                AuditFactory.AuditLog(ex);
                ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, ex.Message);
            }
        }

        private int BindOrganisation()
        {
            using (DataTable dt = new BL_Organisation().select(new Model.ML_Organisation { Key = null, Organisation = null }))
            {
                FormDirty = false;

                //lst_organisation.UnSelectAll();
                lst_organisation.DataSource = dt;
                lst_organisation.DisplayMember = "Organisation";
                lst_organisation.ValueMember = "Key";

                return dt.Rows.Count;
            }
        }

        private int BindCategory()
        {
            using (DataTable dt = new BL_OrganisationCategory().select(new ML_OrganisationCategory { Category = null }))
            {
                cbo_category.Properties.DataSource = dt;
                cbo_category.Properties.DisplayMember = "Category";
                cbo_category.Properties.ValueMember = "Key";
                return dt.Rows.Count;
            }
        }

        private int BindCountry()
        {
            using (DataTable dt = new BL_Country().select(new ML_Country { Country = null }))
            {
                cbo_country.Properties.DataSource = dt;
                cbo_country.Properties.DisplayMember = "Country";
                cbo_country.Properties.ValueMember = "Key";
                return dt.Rows.Count;
            }
        }

        private void btn_new_organisation_Click(object sender, EventArgs e)
        {
            try
            {
                if (FormDirty)
                {
                    if (ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.YesNo, UniversalVariables.UnsavedData) == DialogResult.Yes)
                    {
                        ResetForm(false, true, false, false, true);
                    }
                }
                else
                {
                    ResetForm(false, true, false, false, true);
                }
            }
            catch (Exception ex)
            {
                AuditFactory.AuditLog(ex);
                ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, ex.Message);
            }
        }

        private void ResetForm(bool lstEnabled, bool txtClear, bool btnNewOrganisationEnabled, bool btnDeleteEnabled, bool IsNew)
        {
            lst_organisation.Enabled = lstEnabled;
            if (txtClear)
            {
                txt_new_organisation.ClearAndFocus();
                txt_address.Clear();
                txt_website.Clear();
            }

            SelectedID = 0;
            btn_new_organisation.Enabled = btnNewOrganisationEnabled;
            btn_delete_organisation.Enabled = btnDeleteEnabled;
            IsNewRecord = IsNew;

            if (IsNewRecord)
            {
                cbo_country.EditValue = null;
                cbo_category.EditValue = null;
                cbo_sub_category.EditValue = null;
                cbo_city.EditValue = null;
                //cbo_category_EditValueChanged(this, new EventArgs());
                //cbo_country_EditValueChanged(this, new EventArgs());
            }
            else
            {
                FormDirty = false;
                SelectedIndex = lst_organisation.SelectedIndex == 0 ? -1 : lst_organisation.SelectedIndex;
                lst_organisation_SelectedIndexChanged(this, new EventArgs());
            }

            FormDirty = false;
        }

        private void lst_org_IndexChanged()
        {
            if (lst_organisation.SelectedIndex > -1)
            {
                DataRowView currentRow = (lst_organisation.SelectedItem as DataRowView);
                if (currentRow != null)
                {
                    txt_new_organisation.Text = currentRow.Row["Organisation"].ToString();
                    SelectedID = (int)currentRow.Row["Key"];
                    SelectedIndex = lst_organisation.SelectedIndex;

                    cbo_category.EditValue = currentRow.Row["CategoryKey"].ToString().IsEmpty() ? null : currentRow.Row["CategoryKey"];
                    cbo_category_EditValueChanged(this, new EventArgs());

                    cbo_sub_category.EditValue = currentRow.Row["SubCategoryKey"].ToString().IsEmpty() ? null : currentRow.Row["SubCategoryKey"];

                    cbo_country.EditValue = currentRow.Row["CountryKey"].ToString().IsEmpty() ? null : currentRow.Row["CountryKey"];
                    cbo_country_EditValueChanged(this, new EventArgs());
                    cbo_city.EditValue = currentRow.Row["CityKey"].ToString().IsEmpty() ? null : currentRow.Row["CityKey"];

                    txt_address.Text = currentRow.Row["Address"].ToString();
                    txt_website.Text = currentRow.Row["Website"].ToString();

                    FormDirty = false;
                }
            }
        }

        private void lst_organisation_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                if (lst_organisation.SelectedIndex == SelectedIndex)
                {
                    return;
                }

                if (FormDirty)
                {
                    if (ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.YesNo, UniversalVariables.UnsavedData) == DialogResult.Yes)
                    {
                        lst_org_IndexChanged();
                    }
                    else
                    {
                        lst_organisation.SelectedIndex = (int)SelectedIndex;
                    }
                }
                else
                {
                    lst_org_IndexChanged();
                }
            }
            catch (Exception ex)
            {
                AuditFactory.AuditLog(ex);
                ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, ex.Message);
            }
        }

        private void cbo_category_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbo_category.EditValue != null)
                {
                    BindSubCategory(Convert.ToInt32(cbo_category.EditValue));
                    FormDirty = true;
                }
            }
            catch (Exception ex)
            {
                AuditFactory.AuditLog(ex);
                ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, ex.Message);
            }

        }


        private int BindSubCategory(int CategoryID)
        {
            using (DataTable dt = new BL_OrganisationSubCategory().selectByCategory(new ML_OrganisationSubCategory { CategoryKey = CategoryID }))
            {
                cbo_sub_category.Properties.DataSource = dt;
                cbo_sub_category.Properties.DisplayMember = "SubCategory";
                cbo_sub_category.Properties.ValueMember = "SubCategoryKey";
                cbo_sub_category.ItemIndex = dt.Rows.Count > 0 ? 0 : -1;
                return dt.Rows.Count;
            }
        }

        private void cbo_country_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbo_country.EditValue != null)
                {
                    BindCity(Convert.ToInt32(cbo_country.EditValue));
                    FormDirty = true;
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
                cbo_city.Properties.DataSource = dt;
                cbo_city.Properties.DisplayMember = "City";
                cbo_city.Properties.ValueMember = "CityKey";
                cbo_city.ItemIndex = dt.Rows.Count > 0 ? 0 : -1;
                return dt.Rows.Count;
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private bool CloseFormWithChecks()
        {
            if (IsNewRecord)
            {
                ResetForm(true, true, hasAccessInsert, hasAccessDelete, false);
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btn_delete_organisation_Click(object sender, EventArgs e)
        {
            try
            {
                if (new BL_Organisation().selectUsage(new ML_Organisation { Key = SelectedID }) == 0)
                {

                    if (ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Warning, string.Format("Are you sure you want to delete the organisation {0} from the database?", lst_organisation.Text)) == System.Windows.Forms.DialogResult.OK)
                    {
                        DataRowView currentRow = (lst_organisation.SelectedItem as DataRowView);
                        if (currentRow.Row["AddressKey"].ToString().IsNotEmpty())
                        {
                            new BL_Address().delete(new ML_Address { Key = Convert.ToInt32(currentRow.Row["AddressKey"]) });
                        }
                        new BL_Organisation().delete(new ML_Organisation { Key = SelectedID });
                        ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Information, string.Format("Organisation {0} has been successfully deleted.", lst_organisation.Text), "Deletion Successful!");

                        ResetForm(true, true, hasAccessInsert, hasAccessDelete, false);

                        BindOrganisation();
                        SelectedIndex = -1;
                        lst_organisation_SelectedIndexChanged(this, new EventArgs());
                    }
                }
                else
                {
                    ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, "The organisation you are trying to delete has been referenced in one or more member records. This organisation cannot be deleted.", "Error");
                }
            }
            catch (Exception ex)
            {
                AuditFactory.AuditLog(ex);
                ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, ex.Message);
            }
        }

        private void btn_save_organisation_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsNewRecord && !hasAccessUpdate)
                {
                    ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, "You have no save rights.", "Access Denied");
                    return;
                }

                if (txt_new_organisation.IsNotEmpty())
                {
                    var CityKey = cbo_city.ToIntNullable();
                    if (IsNewRecord)
                    {
                        if (new BL_Organisation().selectNewRecord(new ML_Organisation
                        {
                            Organisation = txt_new_organisation.Text,
                            Key = (SelectedID == 0 ? (int?)null : SelectedID)
                        }).Rows.Count < 1)
                        {
                            int? insertedID = null;

                            if (txt_address.IsNotEmpty())
                            {
                                if (cbo_city.IsNotEmpty() && cbo_country.IsNotEmpty())
                                {
                                    insertedID = new BL_Address().insert(new ML_Address
                                    {
                                        CityKey = cbo_city.ToIntNullable(),
                                        UserKey = UniversalVariables.UserKey,
                                        Address = txt_address.Text.Trim()
                                    });
                                }
                                else
                                {
                                    ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, "Error saving address. The address, city and country values need to be filled. Please re-check!", "Error");
                                    return;
                                }
                            }
                            else if (cbo_city.IsNotEmpty() || cbo_country.IsNotEmpty())
                            {
                                ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, "Error saving address. The address, city and country values need to be filled. Please re-check!", "Error");
                                return;
                            }

                            new BL_Organisation().insert(new ML_Organisation()
                            {
                                Organisation = txt_new_organisation.Text.Trim(),
                                SubCategoryKey = cbo_sub_category.ToIntNullable(),
                                Website = txt_website.Text.Trim(),
                                AddressKey = insertedID
                            });

                            LastOrganization = txt_new_organisation.Text;
                            BindOrganisation();
                            ResetForm(true, true, hasAccessInsert, hasAccessDelete, false);
                            SetPrevious();
                        }
                        else
                        {
                            ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, "The entered organisation is already in the database. Please re-check!", "Error");
                        }
                    }
                    else if (SelectedID > 0)
                    {
                        if (new BL_Organisation().select(new ML_Organisation
                        {
                            Organisation = txt_new_organisation.Text,
                            Key = (SelectedID == 0 ? (int?)null : SelectedID)
                        }).Rows.Count == 1)
                        {
                            DataRowView currentRow = (lst_organisation.SelectedItem as DataRowView);

                            int addressKey = currentRow.Row["AddressKey"].ToString().IsEmpty() ? 0 : currentRow.Row["AddressKey"].ToString().ToInt();

                            if (txt_address.IsNotEmpty())
                            {
                                if (cbo_city.IsNotEmpty() && cbo_country.IsNotEmpty())
                                {
                                    if (addressKey == 0)
                                    {
                                        addressKey = new BL_Address().insert(new ML_Address
                                        {
                                            CityKey = cbo_city.ToIntNullable(),
                                            UserKey = UniversalVariables.UserKey,
                                            Address = txt_address.Text.Trim()
                                        });
                                    }
                                    else
                                    {
                                        new BL_Address().update(new ML_Address
                                        {
                                            Key = Convert.ToInt32(currentRow.Row["AddressKey"]),
                                            CityKey = cbo_city.ToIntNullable(),
                                            UserKey = UniversalVariables.UserKey,
                                            Address = txt_address.Text.Trim()
                                        });
                                    }
                                }
                                else
                                {
                                    ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, "Error saving address. The address, city and country values need to be filled. Please re-check!", "Error");
                                    return;
                                }
                            }
                            else if (cbo_city.IsNotEmpty() || cbo_country.IsNotEmpty())
                            {
                                ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, "Error saving address. The address, city and country values need to be filled. Please re-check!", "Error");
                                return;
                            }

                            new BL_Organisation().update(new ML_Organisation
                            {
                                Key = SelectedID,
                                Organisation = txt_new_organisation.Text.Trim(),
                                SubCategoryKey = cbo_sub_category.ToIntNullable(),
                                Website = txt_website.Text.Trim(),
                                AddressKey = txt_address.IsNotEmpty() ? addressKey : (int?)null
                            });

                            LastOrganization = txt_new_organisation.Text;
                            BindOrganisation();
                            ResetForm(true, true, hasAccessInsert, hasAccessDelete, false);
                            SetPrevious();
                        }
                        else
                        {
                            ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, "The entered organisation is already in the database. Please re-check!", "Error");
                        }
                    }
                }
                else
                {
                    ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Exclamation, "Null value detected for organisation. Please re-check!", "Error!");
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
            if (LastOrganization.IsNotEmpty())
            {
                FormDirty = false;
                lst_organisation.SelectedIndex = lst_organisation.FindStringExact(LastOrganization);
            }
        }

        private void cbo_sub_category_EditValueChanged(object sender, EventArgs e)
        {
            FormDirty = true;
        }

        private void cbo_city_EditValueChanged(object sender, EventArgs e)
        {
            FormDirty = true;
        }

        private void cbo_category_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete)
                ((LookUpEdit)sender).EditValue = null;
        }

        private void txt_EditValueChanged(object sender, EventArgs e)
        {
            FormDirty = true;
        }

        private void ManageOrganisations_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !ApplicationUtilities.CheckFormDirtyClose(CloseFormWithChecks, FormDirty);
        }
    }
}
