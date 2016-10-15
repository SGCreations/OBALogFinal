using DevExpress.XtraEditors;
using OBALog.Business;
using OBALog.Model;
using System;
using System.Data;

namespace OBALog.Windows
{
    public partial class ManageCategoriesSubCategories : XtraForm
    {

        private bool hasAccessInsert = Privileges.CheckAccess(Privileges.OrganisationCategoriesSubCategories_Insert);
        private bool hasAccessUpdate = Privileges.CheckAccess(Privileges.OrganisationCategoriesSubCategories_Update);
        private bool hasAccessDelete = Privileges.CheckAccess(Privileges.OrganisationCategoriesSubCategories_Delete);

        public bool FormDirty { get; set; }

        public int CategoryID { get; set; }

        public int SubCategoryID { get; set; }

        public bool IsNewCategory { get; set; }

        public bool IsNewSubCategory { get; set; }

        public string LastCategory { get; set; }
        public string LastSubCategory { get; set; }

        public ManageCategoriesSubCategories()
        {
            try
            {
                InitializeComponent();

                if (BindCategory() == 0)
                {
                    ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Exclamation, "No categories are available to show. Please add a new category!", "Message");
                    //btn_new_category.PerformClick();
                    btn_new_category_Click(this, new EventArgs());
                }

                btn_new_category.Enabled = btn_new_sub_category.Enabled = hasAccessInsert;
                btn_delete_category.Enabled = btn_delete_sub_category.Enabled = hasAccessDelete;
                btn_save_sub_category.Enabled = btn_save_category.Enabled = (hasAccessInsert || hasAccessUpdate);
            }
            catch (Exception ex)
            {
                AuditFactory.AuditLog(ex);
                ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, ex.Message);
            }
        }

        private int BindCategory()
        {
            using (DataTable dt = new BL_OrganisationCategory().select(new ML_OrganisationCategory { Category = null }))
            {
                lst_categories.UnSelectAll();
                lst_categories.DataSource = dt;
                lst_categories.DisplayMember = "Category";
                lst_categories.ValueMember = "Key";
                return dt.Rows.Count;
            }
        }

        private void btn_new_category_Click(object sender, EventArgs e)
        {
            try
            {
                ApplicationUtilities.CheckFormDirty(NewCategory, FormDirty);
            }
            catch (Exception ex)
            {
                AuditFactory.AuditLog(ex);
                ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, ex.Message);
            }
        }

        private void NewCategory()
        {
            lst_categories.Enabled = false;
            lst_sub_categories.Clear();
            txt_new_sub_category.Clear();
            grp_sub_categories.Enabled = false;
            CategoryID = 0;
            SubCategoryID = 0;
            btn_delete_category.Enabled = hasAccessDelete;
            btn_new_category.Enabled = hasAccessInsert;
            IsNewCategory = true;
            IsNewSubCategory = false;
            txt_new_category.ClearAndFocus();

            FormDirty = false;
        }

        private void lst_categories_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lst_categories.SelectedIndex > -1)
                {
                    DataRowView currentRow = (lst_categories.SelectedItem as DataRowView);
                    if (currentRow != null)
                    {
                        txt_new_category.Text = currentRow.Row["Category"].ToString();
                        CategoryID = (int)currentRow.Row["Key"];

                        BindSubCategory(CategoryID);
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

        private int BindSubCategory(int CategoryID)
        {
            using (DataTable dt = new BL_OrganisationSubCategory().selectByCategory(new ML_OrganisationSubCategory { CategoryKey = CategoryID }))
            {
                txt_new_sub_category.Clear();
                lst_sub_categories.UnSelectAll();
                lst_sub_categories.DataSource = dt;
                lst_sub_categories.DisplayMember = "SubCategory";
                lst_sub_categories.ValueMember = "Key";

                return dt.Rows.Count;
            }
        }

        private void btn_save_category_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsNewCategory && !hasAccessUpdate)
                {
                    ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, "You have no save rights.", "Access Denied");
                    return;
                }

                if (txt_new_category.IsNotEmpty())
                {
                    using (DataTable Table = new BL_OrganisationCategory().select(new ML_OrganisationCategory { Category = txt_new_category.Text }))
                    {
                        if (Table.Rows.Count < 1)
                        {
                            if (IsNewCategory)
                            {
                                new BL_OrganisationCategory().insert(new ML_OrganisationCategory { Category = txt_new_category.Text });
                            }
                            else if (CategoryID > 0)
                            {
                                new BL_OrganisationCategory().update(new ML_OrganisationCategory { Key = CategoryID, Category = txt_new_category.Text });
                            }

                            LastCategory = txt_new_category.Text;

                            ResetCategoryForm();
                            BindCategory();
                            SetPrevious();
                        }
                        else
                        {
                            ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, "The entered category is already in the database. Please re-check!", "Error");
                        }
                    }
                }
                else
                {
                    ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Exclamation, "Null value detected for category. Please re-check!", "Error!");
                }
            }
            catch (Exception ex)
            {
                AuditFactory.AuditLog(ex);
                ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, ex.Message);
            }
        }

        private void ResetCategoryForm()
        {
            FormDirty = false;

            txt_new_category.Clear();
            lst_categories.Enabled = true;
            grp_sub_categories.Enabled = true;
            btn_delete_category.Enabled = hasAccessDelete;
            btn_new_category.Enabled = hasAccessInsert;

            IsNewCategory = false;
            IsNewSubCategory = false;
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool CloseFormWithChecks()
        {
            if (IsNewCategory)
            {
                ResetCategoryForm();
                BindCategory();
                return false;
            }
            else if (IsNewSubCategory)
            {
                ResetSubCategoryForm();
                lst_categories_SelectedIndexChanged(this, new EventArgs());
                return false;
            }
            else
            {
                return true;
            }

        }

        private void ResetSubCategoryForm()
        {
            FormDirty = false;
            lst_sub_categories.Enabled = true;
            lbl_message.Visible = false;
            grp_categories.Enabled = true;
            IsNewCategory = false;
            IsNewSubCategory = false;
            btn_delete_sub_category.Enabled = hasAccessDelete;
            btn_new_sub_category.Enabled = hasAccessInsert;
            txt_new_sub_category.Clear();
        }

        private void lst_sub_categories_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lst_sub_categories.SelectedIndex > -1)
                {
                    DataRowView currentRow = (lst_sub_categories.SelectedItem as DataRowView);
                    if (currentRow != null)
                    {
                        txt_new_sub_category.Text = currentRow.Row["SubCategory"].ToString();
                        SubCategoryID = (int)currentRow.Row["SubCategoryKey"];
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

        private void btn_new_sub_category_Click(object sender, EventArgs e)
        {
            try
            {
                ApplicationUtilities.CheckFormDirty(NewSubCategory, FormDirty);
            }
            catch (Exception ex)
            {
                AuditFactory.AuditLog(ex);
                ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, ex.Message);
            }
        }

        private void NewSubCategory()
        {
            lst_sub_categories.Enabled = false;
            lbl_message.Visible = true;
            lbl_message.Text = "Note: The sub category will be added under the selected category.";
            grp_categories.Enabled = false;
            IsNewCategory = false;
            IsNewSubCategory = true;
            btn_delete_sub_category.Enabled = hasAccessDelete;
            btn_new_sub_category.Enabled = hasAccessInsert;
            txt_new_sub_category.ClearAndFocus();

            FormDirty = false;
        }

        private void btn_delete_sub_category_Click(object sender, EventArgs e)
        {
            try
            {
                if (SubCategoryID > 0 && lst_sub_categories.SelectedIndex > -1)
                {
                    if (new BL_OrganisationSubCategory().selectUsage(new ML_OrganisationSubCategory { Key = SubCategoryID }) == 0)
                    {
                        if (ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Warning, string.Format("Are you sure you want to delete the sub category {0} from the database?", lst_sub_categories.Text), "Warning") == System.Windows.Forms.DialogResult.OK)
                        {
                            new BL_OrganisationSubCategory().delete(new ML_OrganisationSubCategory { Key = SubCategoryID });
                            ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Warning, string.Format("Sub category {0} has been successfully deleted.", lst_sub_categories.Text), "Deletion Successful.");
                            ResetSubCategoryForm();
                            lst_categories_SelectedIndexChanged(this, new EventArgs());
                        }
                    }
                    else
                    {
                        ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, "The sub category you are trying to delete has been referenced in one or more member records. This sub category cannot be deleted.", "Error");
                    }
                }
            }
            catch (Exception ex)
            {
                AuditFactory.AuditLog(ex);
                ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, ex.Message);
            }
        }

        private void btn_save_sub_category_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsNewSubCategory && !hasAccessUpdate)
                {
                    ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, "You have no save rights.", "Access Denied");
                    return;
                }

                if (txt_new_sub_category.IsNotEmpty())
                {
                    using (DataTable Table = new BL_OrganisationSubCategory().select(new ML_OrganisationSubCategory { SubCategory = txt_new_sub_category.Text }))
                    {
                        if (Table.Rows.Count < 1)
                        {
                            if (IsNewSubCategory)
                            {
                                new BL_OrganisationSubCategory().insert(new ML_OrganisationSubCategory { CategoryKey = CategoryID, SubCategory = txt_new_sub_category.Text });
                            }
                            else if (SubCategoryID > 0)
                            {
                                new BL_OrganisationSubCategory().update(new ML_OrganisationSubCategory { Key = SubCategoryID, SubCategory = txt_new_sub_category.Text });
                            }

                            LastCategory = lst_categories.Text;
                            LastSubCategory = txt_new_sub_category.Text;

                            ResetSubCategoryForm();
                            lst_categories_SelectedIndexChanged(this, new EventArgs());
                            SetPrevious();
                        }
                        else
                        {
                            ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, "The entered sub category is already in the database. Please re-check!", "Error");
                        }
                    }
                }
                else
                {
                    ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Exclamation, "Null value detected for sub category. Please re-check!", "Error!");
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
            if (LastCategory.IsNotEmpty())
            {
                lst_categories.SelectedIndex = lst_categories.FindStringExact(LastCategory);
            }

            if (LastSubCategory.IsNotEmpty())
            {
                lst_sub_categories.SelectedIndex = lst_sub_categories.FindStringExact(LastSubCategory);
            }
        }


        private void btn_delete_category_Click(object sender, EventArgs e)
        {
            try
            {
                if (CategoryID > 0)
                {
                    if (new BL_OrganisationCategory().selectUsage(new ML_OrganisationCategory { Key = CategoryID }) == 0)
                    {
                        if (ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Warning, string.Format("Are you sure you want to delete the category {0} from the database? WARNING: All its sub categories will also be deleted!", lst_categories.Text), "Warning") == System.Windows.Forms.DialogResult.OK)
                        {
                            new BL_OrganisationSubCategory().deleteByCategory(new ML_OrganisationSubCategory { CategoryKey = CategoryID });
                            new BL_OrganisationCategory().delete(new ML_OrganisationCategory { Key = CategoryID });

                            ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Information, string.Format("Category {0} and all its sub categories have been successfully deleted.", lst_categories.Text), "Deletion Successful.");

                            ResetCategoryForm();
                            BindCategory();
                        }
                    }
                    else
                    {
                        ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, "The category you are trying to delete has been referenced in one or more organisation records. This category cannot be deleted.", "Error");
                    }
                }
            }
            catch (Exception ex)
            {
                AuditFactory.AuditLog(ex);
                ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, ex.Message);
            }
        }

        private void txt_EditValueChanged(object sender, EventArgs e)
        {
            FormDirty = true;
        }

        private void ManageCategoriesSubCategories_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            e.Cancel = !ApplicationUtilities.CheckFormDirtyClose(CloseFormWithChecks, FormDirty);
        }
    }
}
