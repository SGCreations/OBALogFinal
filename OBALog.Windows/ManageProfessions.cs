using DevExpress.XtraEditors;
using OBALog.Business;
using OBALog.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OBALog.Windows
{
    public partial class ManageProfessions : XtraForm
    {
        public int SelectedID { get; set; }

        public bool IsNewRecord { get; set; }

        public ManageProfessions()
        {
            try
            {
                InitializeComponent();
                if (BindProfession() == 0)
                {
                    ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Exclamation, "No professions are available to show. Please add a new profession!", "Message");
                    btn_new_profession.PerformClick();
                }
            }
            catch (Exception ex)
            {
                AuditFactory.AuditLog(ex);
                ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, ex.Message);
            }
        }

        private void btn_new_profession_Click(object sender, EventArgs e)
        {
            try
            {
                ResetForm(true, false, true, false, false, false);
            }
            catch (Exception ex)
            {
                AuditFactory.AuditLog(ex);
                ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, ex.Message);
            }
        }

        private void ResetForm(bool IsNew, bool lstEnabled, bool txtClear, bool btnNewProfessionEnabled, bool btnDeleteEnabled, bool focusList)
        {
            lst_professions.Enabled = lstEnabled;
            if (txtClear) txt_new_profession.ClearAndFocus();
            SelectedID = 0;

            btn_new_profession.Enabled = btnNewProfessionEnabled;
            btn_delete_profession.Enabled = btnDeleteEnabled;
            IsNewRecord = IsNew;
            if (focusList) lst_professions_SelectedIndexChanged(this, new EventArgs());
        }

        private void lst_professions_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lst_professions.SelectedIndex > -1)
                {
                    DataRowView currentRow = (lst_professions.SelectedItem as DataRowView);
                    if (currentRow != null)
                    {
                        txt_new_profession.Text = currentRow.Row["Profession"].ToString();
                        SelectedID = (int)currentRow.Row["Key"];
                    }
                }
            }
            catch (Exception ex)
            {
                AuditFactory.AuditLog(ex);
                ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, ex.Message);
            }
        }

        private void btn_save_profession_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_new_profession.IsNotEmpty())
                {
                    using (DataTable Table = new BL_Profession().select(new ML_Profession { Profession = txt_new_profession.Text }))
                    {
                        if (Table.Rows.Count < 1)
                        {
                            if (IsNewRecord)
                            {
                                new BL_Profession().insert(new ML_Profession { Profession = txt_new_profession.Text.Trim(), UserKey = UniversalVariables.UserKey });
                            }
                            else if (SelectedID > 0)
                            {
                                new BL_Profession().update(new ML_Profession { Key = SelectedID, Profession = txt_new_profession.Text.Trim(), UserKey = UniversalVariables.UserKey });
                            }

                            BindProfession();
                            ResetForm(false, true, true, true, true, true);
                        }
                        else
                        {
                            ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, "The entered profession is already in the database. Please re-check!", "Error");
                        }
                    }
                }
                else
                {
                    ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Exclamation, "Null value detected for profession. Please re-check!", "Error!");
                }
            }
            catch (Exception ex)
            {

                AuditFactory.AuditLog(ex);
                ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, ex.Message);
            }
        }

        private int BindProfession()
        {
            using (DataTable dt = new BL_Profession().select(new ML_Profession { Profession = null }))
            {
                lst_professions.UnSelectAll();
                lst_professions.DataSource = dt;
                lst_professions.DisplayMember = "Profession";
                lst_professions.ValueMember = "Key";
                return dt.Rows.Count;
            }
        }

        private void btn_delete_profession_Click(object sender, EventArgs e)
        {
            try
            {
                if (new BL_Profession().selectUsage(new ML_Profession { Key = SelectedID }) == 0)
                {
                    if (ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Warning, string.Format("Are you sure you want to delete the profession {0} from the database?", lst_professions.Text)) == System.Windows.Forms.DialogResult.OK)
                    {
                        new BL_Profession().delete(new ML_Profession { Key = SelectedID });
                        ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Information, string.Format("Profession {0} has been successfully deleted.", lst_professions.Text), "Deletion Successful!");
                        BindProfession();
                        ResetForm(false, true, true, true, true, true);
                    }
                }
                else
                {
                    ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, "The profession you are trying to delete has been referenced in one or more member records. This profession cannot be deleted.", "Error");
                }
            }
            catch (Exception ex)
            {
                AuditFactory.AuditLog(ex);
                ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, ex.Message);
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            if (IsNewRecord)
            {
                ResetForm(false, true, true, true, true, true);
            }
            else
            {
                this.Close();
            }
        }

    }
}
