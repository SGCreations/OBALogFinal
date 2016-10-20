using DevExpress.XtraEditors;
using OBALog.Business;
using OBALog.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Cache;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace OBALog.Windows
{
    public partial class MemberDetails : XtraForm
    {
        #region Variables
        private bool hasAccessInsert = Privileges.CheckAccess(Privileges.MembershipDetails_Insert);
        private bool hasAccessUpdate = Privileges.CheckAccess(Privileges.MembershipDetails_Update);
        private bool hasAccessDelete = Privileges.CheckAccess(Privileges.MembershipDetails_Delete);
        public bool FormDirty { get; set; }
        public string LastMember { get; set; }

        public int SelectedMemberKey { get; set; }

        public ML_ViewMember Member { get; set; }
        public ML_Admission Admission { get; set; }
        public List<ML_ProfessionalDetails> ProfessionalDetails { get; set; }
        public List<ML_RemarksHistory> RemarksHistory { get; set; }
        public bool IsNewRecord { get; set; }
        #endregion

        public MemberDetails()
        {
            InitializeComponent();
        }

        private void MemberDetails_Load(object sender, EventArgs e)
        {
            try
            {
                vp_phone.SetValidationRule(txt_tel, new PhoneValidation());
                vp_phone.SetValidationRule(txt_mobile, new PhoneValidation());

                vp_email.SetValidationRule(txt_email, new EmailValidation());
                vp_email_professional.SetValidationRule(txt_email_professional, new EmailValidation());

                vp_TelephoneValidation.SetValidationRule(txt_tel, new TelephoneValidation());
                vp_MobileValidation.SetValidationRule(txt_mobile, new MobileValidation());
                vp_EmailValidation.SetValidationRule(txt_email, new EmailControlValidation());

                split_search.PanelVisibility = SplitPanelVisibility.Panel2;
                split_search.Collapsed = true;
                chk_include_deleted.Visible = false;
                tab_member.SelectedTabPageIndex = 0;
                IsNewRecord = false;
                chk_col_office_CheckedChanged(this, new EventArgs());
                bindSearchData();

                this.Invoke((MethodInvoker)delegate { bindInitialData(); });

                btn_new.Enabled = hasAccessInsert;
                btn_delete.Enabled = hasAccessDelete;
                btn_save.Enabled = btn_print.Enabled = (hasAccessInsert || hasAccessUpdate);
            }
            catch (Exception ex)
            {
                AuditFactory.AuditLog(ex);
                ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, ex.Message);
            }
        }

        private void bindInitialData()
        {
            using (DataTable dt = new BL_Country().select(new ML_Country { Country = null }))
            {
                search_cbo_country.Properties.DataSource = dt;
                search_cbo_country.Properties.DisplayMember = "Country";
                search_cbo_country.Properties.ValueMember = "Key";

                cbo_country.Properties.DataSource = dt;
                cbo_country.Properties.DisplayMember = "Country";
                cbo_country.Properties.ValueMember = "Key";
            }

            using (DataTable dt = new BL_Salutation().select(new ML_Salutation { Salutation = null }))
            {
                cbo_salutation.Properties.DataSource = dt;
                cbo_salutation.Properties.DisplayMember = "Salutation";
                cbo_salutation.Properties.ValueMember = "Key";
            }

            bindProfession();

            using (DataTable dt = new BL_OrganisationCategory().select(new ML_OrganisationCategory { Category = null }))
            {
                search_cbo_category.Properties.DataSource = dt;
                search_cbo_category.Properties.DisplayMember = "Category";
                search_cbo_category.Properties.ValueMember = "Key";
            }

            bindOrganisation();

            cbo_id_type.Properties.Items.Clear();
            cbo_school_2.Properties.Items.Clear();
            cbo_mem_not_type.Properties.Items.Clear();
            cbo_payment_type.Properties.Items.Clear();
            search_cbo_app_stage.Properties.Items.Clear();

            cbo_id_type.Properties.Items.AddRange(UniversalVariables.IdentificationTypes);
            cbo_school_2.Properties.Items.AddRange(UniversalVariables.Schools);
            cbo_mem_not_type.Properties.Items.AddRange(UniversalVariables.NotificationTypes);
            cbo_payment_type.Properties.Items.AddRange(UniversalVariables.PaymentTypes);
            search_cbo_app_stage.Properties.Items.AddRange(UniversalVariables.ApprovalStages);

            cbo_id_type.SelectFirstIndex();
            cbo_school_2.SelectFirstIndex();
            cbo_mem_not_type.SelectFirstIndex();
            cbo_payment_type.SelectFirstIndex();
            cbo_country.SelectFirstIndex();
            cbo_salutation.SelectFirstIndex();

        }

        private void bindProfession()
        {
            using (DataTable dt = new BL_Profession().select(new ML_Profession { Profession = null }))
            {
                search_cbo_profession.Properties.DataSource = dt;
                search_cbo_profession.Properties.DisplayMember = "Profession";
                search_cbo_profession.Properties.ValueMember = "Key";

                cbo_profession.Properties.DataSource = dt;
                cbo_profession.Properties.DisplayMember = "Profession";
                cbo_profession.Properties.ValueMember = "Key";
            }
        }
        private void bindOrganisation()
        {
            using (DataTable dt = new BL_Organisation().select(new ML_Organisation { Key = null, Organisation = null }))
            {
                search_cbo_org.Properties.DataSource = dt;
                search_cbo_org.Properties.DisplayMember = "Organisation";
                search_cbo_org.Properties.ValueMember = "Key";

                cbo_org.Properties.DataSource = dt;
                cbo_org.Properties.DisplayMember = "Organisation";
                cbo_org.Properties.ValueMember = "Key";
            }
        }
        private void btn_find_Click(object sender, EventArgs e)
        {
            txt_surname.Text = "Gajanayaka Test";
            txt_initials.Text = "S.C. Test";
            txt_id_val.Text = "94289522V";
            txt_address.Text = "No. 5, Templer's Road, Mount Lavinia.";
            txt_admission_1.Text = "18369";
            txt_forenames.Text = "Sidath Test";
            txt_mobile.Text = "011275425825";
            txt_tel.Text = "01127754258";

        }

        private void dtp_approved_rejected_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void dtp_col_office_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void rad_search_options_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rad_search_options.SelectedIndex == 2)
                {
                    split_search.PanelVisibility = SplitPanelVisibility.Both;
                    TabAdvancedSearch.SelectedTabPageIndex = 0;
                    split_search.Collapsed = false;
                }
                else
                {
                    split_search.PanelVisibility = SplitPanelVisibility.Panel2;
                    split_search.Collapsed = true;
                }

                chk_include_deleted.Checked = rad_search_options.SelectedIndex == 2;
                bindSearchData();
            }
            catch (Exception ex)
            {
                AuditFactory.AuditLog(ex);
                ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, ex.Message);
            }
        }

        private void bindSearchData()
        {
            try
            {
                chk_include_deleted.Visible = rad_search_options.SelectedIndex == 2;
                switch (rad_search_options.SelectedIndex)
                {
                    case 0:
                        gcSearch.DataSource = new BL_Member().selectMemberLastUpdatedTop20();
                        break;
                    case 1:
                        gcSearch.DataSource = new BL_Member().selectMemberTop20();
                        break;
                    case 2:
                        AdvancedSearch();
                        break;
                }
            }
            catch (Exception ex)
            {
                AuditFactory.AuditLog(ex);
                ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, ex.Message);
            }
        }

        private void AdvancedSearch()
        {
            switch (TabAdvancedSearch.SelectedTabPage.Text)
            {
                case "Personal":
                    gcSearch.DataSource = new BL_Member().selectMemberAdvancedPersonal(new Model.ML_Member
                    {
                        Initials = search_txt_initials.NullIfEmpty(),
                        Forenames = search_txt_forenames.NullIfEmpty(),
                        Surname = search_txt_surname.NullIfEmpty(),
                        IdentificationNo = search_txt_id_no.NullIfEmpty(),
                        Mobile = search_txt_mobile.NullIfEmpty(),
                        EmailReturned = search_chk_email_returned.NullIfIndeterminate(),
                        MailReturned = search_chk_mail_returned.NullIfIndeterminate(),
                        Deceased = search_chk_deceased.NullIfIndeterminate()
                    },

                    //search_cbo_country.IsEmpty() ? (int?)null : Convert.ToInt32(search_cbo_country.EditValue),
                    search_cbo_country.ToIntNullable(),
                    search_cbo_city.ToIntNullable(),
                    search_dtp_dob_from.GetFormattedDateString(UniversalVariables.MySQLDateFormat),
                    search_dtp_dob_to.GetFormattedDateString(UniversalVariables.MySQLDateFormat),
                    search_txt_tel_no.NullIfEmpty(),
                    chk_include_deleted.NullIfTrue());
                    break;
                case "Membership":
                    gcSearch.DataSource = new BL_Member().selectMemberAdvancedMembership(new ML_Member
                    {
                        MembershipNo = search_chk_include_duplicates.Checked ? (search_txt_mem_no.Text.Contains("%") ? search_txt_mem_no.NullIfEmpty() : search_txt_mem_no.NullIfEmpty().IsEmpty() ? "null" : string.Format("%{0}%", search_txt_mem_no.NullIfEmpty())) : search_txt_mem_no.NullIfEmpty(),
                        OldMembershipNos = search_chk_include_duplicates.Checked ? null : search_txt_old_mem_no.NullIfEmpty()
                    },
                    search_dtp_mem_date_from.GetFormattedDateString(UniversalVariables.MySQLDateFormat),
                    search_dtp_mem_date_to.GetFormattedDateString(UniversalVariables.MySQLDateFormat),
                    chk_include_deleted.NullIfTrue(), search_chk_include_duplicates.Checked);
                    break;
                case "Processing":
                    gcSearch.DataSource = new BL_Member().selectMemberAdvancedProcessing(search_txt_rec_no.NullIfEmpty(),
                    search_rec_date_from.GetFormattedDateString(UniversalVariables.MySQLDateFormat),
                    search_rec_date_to.GetFormattedDateString(UniversalVariables.MySQLDateFormat),
                    search_cbo_app_stage.SelectedText.NullIfEmpty(),
                    chk_include_deleted.NullIfTrue());
                    break;
                case "School":
                    gcSearch.DataSource = new BL_Member().selectMemberAdvancedSchool(
                        search_txt_ad_no.NullIfEmpty(),
                        search_txt_ol_from.ToIntNullable(),
                        search_txt_ol_to.ToIntNullable(),
                        search_txt_al_from.ToIntNullable(),
                        search_txt_al_to.ToIntNullable(),
                        search_txt_year_joined_from.ToIntNullable(),
                        search_txt_year_joined_to.ToIntNullable(),
                        search_txt_year_left_from.ToIntNullable(),
                        search_txt_year_left_to.ToIntNullable(),
                        search_txt_class_grp_from.ToIntNullable(),
                        search_txt_class_grp_to.ToIntNullable(),
                        chk_include_deleted.NullIfTrue());
                    break;
                case "Professional":
                    gcSearch.DataSource = new BL_Member().selectMemberAdvancedProfessional(
                                           search_cbo_profession.ToIntNullable(),
                                            search_cbo_category.ToIntNullable(),
                                            search_cbo_sub_category.ToIntNullable(),
                                            search_cbo_org.ToIntNullable(),
                                            chk_include_deleted.NullIfTrue());
                    break;
            }
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            try
            {
                bindSearchData();

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
                bindCity(Convert.ToInt32(cbo_country.EditValue), 2);
            }
            catch (Exception ex)
            {
                AuditFactory.AuditLog(ex);
                ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, ex.Message);
            }
        }

        private void search_cbo_country_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                bindCity(Convert.ToInt32(search_cbo_country.EditValue), 1);
            }
            catch (Exception ex)
            {
                AuditFactory.AuditLog(ex);
                ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, ex.Message);
            }
        }

        private void bindCity(int CountryID, int part)
        {
            using (DataTable dt = new BL_City().selectByCountry(new ML_City { CountryKey = CountryID }))
            {
                switch (part)
                {
                    case 1:
                        search_cbo_city.Clear();
                        search_cbo_city.Properties.DataSource = dt;
                        search_cbo_city.Properties.DisplayMember = "City";
                        search_cbo_city.Properties.ValueMember = "CityKey";
                        search_cbo_city.SelectFirstIndex();
                        break;
                    case 2:
                        cbo_city.Clear();
                        cbo_city.Properties.DataSource = dt;
                        cbo_city.Properties.DisplayMember = "City";
                        cbo_city.Properties.ValueMember = "CityKey";
                        cbo_city.SelectFirstIndex();
                        break;
                }
            }
        }

        private void search_cbo_category_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                using (DataTable dt = new BL_OrganisationSubCategory().selectByCategory(new ML_OrganisationSubCategory { CategoryKey = Convert.ToInt32(search_cbo_category.EditValue) }))
                {
                    search_cbo_sub_category.Clear();
                    search_cbo_sub_category.Properties.DataSource = dt;
                    search_cbo_sub_category.Properties.DisplayMember = "SubCategory";
                    search_cbo_sub_category.Properties.ValueMember = "SubCategoryKey";
                    //search_cbo_sub_category.ItemIndex = dt.Rows.Count > 0 ? 0 : -1;
                    search_cbo_sub_category.SelectFirstIndex();
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
            try
            {
                mainSplit.Panel1.Enabled = true;

                this.Close();
            }
            catch (Exception ex)
            {
                AuditFactory.AuditLog(ex);
                ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, ex.Message);
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            SaveCore(true, false);
        }

        private void SaveCore(bool showConfirmActionDialog, bool genRecBtnClicked)
        {
            try
            {
                //if (vp_config_validate.Validate())
                //{

                //}

                if (!IsNewRecord && !hasAccessUpdate)
                {
                    ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, "You have no save rights.", "Access Denied");
                    return;
                }

                bool Tab_Member = false, Tab_School = false, Tab_Processing = false, Tab_Professional = false;

                ValidateTabs(ref Tab_Member, ref Tab_School, ref Tab_Processing, ref Tab_Professional);

                if (Tab_Member & Tab_School & Tab_Processing & Tab_Professional)
                {

                    if (new BL_Member().checkMemNo(txt_mem_no.Text.Trim().IsNotEmpty() ? txt_mem_no.Text.Trim() : "0", IsNewRecord) && IsNewRecord)
                    {
                        ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Exclamation, "Error updating record. The specified membership no. already exists in the system. Please re-check!");
                        return;
                    }
                    else if (new BL_Member().checkMemNo(txt_mem_no.Text.Trim().IsNotEmpty() ? txt_mem_no.Text.Trim() : "0", IsNewRecord, Member.KEY.ToString()) && !IsNewRecord)
                    {
                        ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Exclamation, "Error updating record. The specified membership no. already exists in the system. Please re-check!");
                        return;
                    }

                    if (new BL_Member().checkIDVal(txt_id_val.Text.Trim().IsNotEmpty() ? txt_id_val.Text.Trim() : "0", IsNewRecord) && IsNewRecord)
                    {
                        ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Exclamation, "Error updating record. The specified identification no. already exists in the system. Please re-check!");
                        return;
                    }
                    else if (new BL_Member().checkIDVal(txt_id_val.Text.Trim().IsNotEmpty() ? txt_id_val.Text.Trim() : "0", IsNewRecord, Member.KEY.ToString()) && !IsNewRecord)
                    {
                        ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Exclamation, "Error updating record. The specified identification no. already exists in the system. Please re-check!");
                        return;
                    }

                    if (chk_outdated.Checked && lst_remarks.ItemCount == 0)
                    {
                        ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Exclamation, "Please include a note in the remarks textbox, to denote why this record is outdated!");
                        return;
                    }

                    if (chk_deceased.Checked && ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.YesNo, string.Format("This member has been marked as deceased. It would be impossible to edit any details of this member once saved, unless you have appropriate permissions.{0}Are you sure you wish to commit this operation?", Environment.NewLine), "Warning") == System.Windows.Forms.DialogResult.No)
                    {
                        return;
                    }

                    saveMember(showConfirmActionDialog, genRecBtnClicked);
                    ResetFormAfterSave(IsNewRecord);
                }
                else
                {
                    ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Exclamation, "One or more of the required fields are blank or contain invalid data. Please re-check! The errorneous fields are marked with a \"X\"", "Validation Error");
                }
            }
            catch (Exception ex)
            {
                DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);

                AuditFactory.AuditLog(ex);
                if (ex.InnerException != null)
                {
                    AuditFactory.AuditLog(ex.InnerException);
                }
                ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, ex.Message);
            }
            finally
            {
                DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
            }
        }

        private void saveMember(bool showConfirmActionDialog, bool genRecBtnClicked)
        {
            if (IsNewRecord)
            {

                #region Insert New Record

                string newMemNoStr = string.Empty;

                if (ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Warning, "Are you sure you want to save the new member?", "Confirm Action") == System.Windows.Forms.DialogResult.OK)
                {
                    DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this, typeof(AppProgress), true, true, false);

                    var address = new ML_Address
                    {
                        CityKey = cbo_city.ToIntNullable(),
                        Address = txt_address.Text.Trim(),
                        Telephone = txt_tel.Text.Trim(),
                        UpdatedDate = DateTime.Now.GetFormattedDateString(UniversalVariables.MySQLDateFormat)
                    };

                    var receipt = new ML_Receipt
                      {
                          ReceiptNo = (genRecBtnClicked && txt_rec_no.IsNotEmpty()) ? txt_rec_no.Text.Trim() : new BL_Member().getReceiptNo(Configurations.ReceiptNoStr),
                          ReceiptDate = DateTime.Now.GetFormattedDateString(UniversalVariables.MySQLDateFormat),
                          CardChequeNo = txt_cheque_no.Text.Trim(),
                          Bank = txt_bank.Text.Trim(),
                          ReceiptAmount = Convert.ToDouble(txt_amount.ToIntNullable()),
                          PaymentType = cbo_payment_type.Text,
                          PrintCount = 0,
                          UpdatedDate = DateTime.Now.GetFormattedDateString(UniversalVariables.MySQLDateFormat)
                      };

                    var member = new ML_Member
                    {
                        ALYear = txt_al_year.Text.Trim(),
                        ApprovalStage = getApprovalStage(),
                        ClassGroup = txt_class_group.Text.Trim(),
                        DateApproved = dtp_approved_rejected.GetFormattedDateString(UniversalVariables.MySQLDateFormat),
                        DateCardGivenToMember = dtp_given_to_member.GetFormattedDateString(UniversalVariables.MySQLDateFormat),
                        DateCardReceivedFromPrinter = dtp_received_from_printer.GetFormattedDateString(UniversalVariables.MySQLDateFormat),
                        DateCardSentToPrinter = dtp_sent_to_printer.GetFormattedDateString(UniversalVariables.MySQLDateFormat),
                        DateMemberNotified = dtp_member_notified.GetFormattedDateString(UniversalVariables.MySQLDateFormat),
                        DateRejected = dtp_rejected.GetFormattedDateString(UniversalVariables.MySQLDateFormat),
                        Deceased = chk_deceased.Checked,
                        DeceasedDate = dtp_deceased.GetFormattedDateString(UniversalVariables.MySQLDateFormat),
                        DOB = dtp_dob.GetFormattedDateString(UniversalVariables.MySQLDateFormat),
                        Email = txt_email.Text.Trim(),
                        EmailReturned = chk_email_returned.Checked,
                        Forenames = txt_forenames.Text.Trim(),
                        IdentificationNo = txt_id_val.Text.Trim(),
                        IdentificationType = cbo_id_type.Text,
                        Initials = txt_initials.Text.Trim(),
                        MailReturned = chk_mail_returned.Checked,
                        MembershipNo = (txt_mem_no.IsEmpty() && ts_approved_rejected.Enabled && ts_approved_rejected.IsOn) ? generateMemNo(ref newMemNoStr) : txt_mem_no.Text.Trim(),
                        MembershipDate = (newMemNoStr.IsNotEmpty() && ts_approved_rejected.Enabled && ts_approved_rejected.IsOn) ? DateTime.Now.ToString(UniversalVariables.MySQLDateFormat) : dtp_mem_date.GetFormattedDateString(UniversalVariables.MySQLDateFormat),
                        MembershipNotificationType = cbo_mem_not_type.Text,
                        Mobile = txt_mobile.Text,
                        OldMembershipNos = getDuplicateMemNos(),
                        OLYear = txt_ol_year.Text,
                        Outdated = chk_outdated.Checked,
                        ProfessionKey = cbo_profession.ToIntNullable(),
                        RefundCheqDate = dtp_rejected.GetFormattedDateString(UniversalVariables.MySQLDateFormat),
                        RefundChqNo = txt_rejected_cheque_no.Text.Trim(),
                        Rejected = (ts_approved_rejected.Enabled && !ts_approved_rejected.IsOn) ? true : false,
                        RejectedReason = rtb_rej_reason.Text.Trim(),
                        SalutationKey = Convert.ToInt32(cbo_salutation.EditValue),
                        Surname = txt_surname.Text.Trim(),
                        UserKey = UniversalVariables.UserKey,
                        YearJoined = txt_year_joined.Text,
                        YearLeft = txt_year_left.Text,
                        Picture = pic_member.Image != null ? ApplicationUtilities.imageToByteArray(pic_member.Image) : null,
                        UpdatedDate = DateTime.Now.GetFormattedDateString(UniversalVariables.MySQLDateFormat)
                    };


                    List<ML_Admission> admission = new List<ML_Admission>();

                    admission.Add(new ML_Admission { AdmissionNo = txt_admission_1.Text.Trim(), School = UniversalVariables.School_STCMount });

                    //if (Admission != null && Admission.Key != null)
                    //{
                    //    admission.Add(new ML_Admission { AdmissionNo = txt_admission_2.Text.Trim(), School = cbo_school_2.Text.Trim(), Key = Admission.Key });
                    //}
                    //else 

                    if (txt_admission_2.IsNotEmpty() && cbo_school_2.IsNotEmpty())
                    {
                        admission.Add(new ML_Admission { AdmissionNo = txt_admission_2.Text.Trim(), School = cbo_school_2.Text.Trim() });
                    }

                    ML_ProfessionalDetails professionalDetails = null;

                    if (txt_designation.IsNotEmpty() || txt_email_professional.IsNotEmpty() || cbo_org.IsNotEmpty())
                    {
                        professionalDetails = new ML_ProfessionalDetails
                         {
                             Active = true,
                             Designation = txt_designation.Text.Trim(),
                             Email = txt_email_professional.Text.Trim(),
                             OrganisationKey = Convert.ToInt32(cbo_org.EditValue),
                             UpdatedDate = DateTime.Now.GetFormattedDateString(UniversalVariables.MySQLDateFormat)
                         };
                    }


                    #region Auto Remarks

                    RemarksHistory.Add(new ML_RemarksHistory { Remarks = "New member record created.", UpdatedDate = DateTime.Now.GetFormattedDateString(UniversalVariables.MySQLDateFormat), UserKey = UniversalVariables.UserKey });

                    if (chk_deceased.Checked)
                    {
                        RemarksHistory.Add(new ML_RemarksHistory { Remarks = "Member marked as deceased.", UpdatedDate = DateTime.Now.GetFormattedDateString(UniversalVariables.MySQLDateFormat), UserKey = UniversalVariables.UserKey });
                    }

                    if (ts_approved_rejected.Enabled && ts_approved_rejected.IsOn)
                    {
                        RemarksHistory.Add(new ML_RemarksHistory { Remarks = "Member marked as approved.", UpdatedDate = DateTime.Now.GetFormattedDateString(UniversalVariables.MySQLDateFormat), UserKey = UniversalVariables.UserKey });
                    }
                    else if (ts_approved_rejected.Enabled && !ts_approved_rejected.IsOn)
                    {
                        RemarksHistory.Add(new ML_RemarksHistory { Remarks = "Member marked as rejected.", UpdatedDate = DateTime.Now.GetFormattedDateString(UniversalVariables.MySQLDateFormat), UserKey = UniversalVariables.UserKey });
                    }

                    if (dtp_given_to_member.IsNotEmpty())
                    {
                        RemarksHistory.Add(new ML_RemarksHistory { Remarks = "Member given the membership card.", UpdatedDate = DateTime.Now.GetFormattedDateString(UniversalVariables.MySQLDateFormat), UserKey = UniversalVariables.UserKey });
                    }

                    #endregion

                    new BL_Member().insertMember(
                        address,
                        receipt,
                        member,
                        admission,
                        professionalDetails,
                        RemarksHistory,
                        Configurations.ReceiptNoStr,
                        Configurations.MembershipDateStr,
                        Configurations.MembershipNoIndexStr,
                        UniversalVariables.UserKey.ToString()
                        );

                    DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);

                    //ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Information, (newMemNoStr.IsNotEmpty() ? string.Format("New member saved with membership no.: {0}!", newMemNoStr) : "New member saved!"), "Operation Successful");

                    XtraMessageBox.Show(this, (newMemNoStr.IsNotEmpty() ? string.Format("New member saved with membership no.: {0}!", newMemNoStr) : "New member saved!"), "Operation Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    SelectedMemberKey = member.Key;
                }
                #endregion
            }


            else if (SelectedMemberKey > 0)
            {
                #region Update Old Record

                string memNoStr = string.Empty;

                if (showConfirmActionDialog ? ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Warning, "Are you sure you want to save the record?", "Confirm Action") == System.Windows.Forms.DialogResult.OK : true)
                {
                    DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this, typeof(AppProgress), true, true, false);

                    var address = new ML_Address
                    {
                        CityKey = cbo_city.ToIntNullable(),
                        Address = txt_address.Text.Trim(),
                        Telephone = txt_tel.Text.Trim(),
                        Key = Member.AddressKey.ToInt(),
                        UpdatedDate = DateTime.Now.GetFormattedDateString(UniversalVariables.MySQLDateFormat)
                    };


                    var receipt = new ML_Receipt
                      {
                          //check this - should a receipt no be always generated when saving?
                          ReceiptNo = (genRecBtnClicked && txt_rec_no.IsNotEmpty()) ? txt_rec_no.Text.Trim() : new BL_Member().getReceiptNo(Configurations.ReceiptNoStr),
                          ReceiptDate = dtp_rec_date.GetFormattedDateString(UniversalVariables.MySQLDateFormat),
                          CardChequeNo = txt_cheque_no.Text.Trim(),
                          Bank = txt_bank.Text.Trim(),
                          ReceiptAmount = Convert.ToDouble(txt_amount.ToIntNullable()),
                          PaymentType = cbo_payment_type.Text,
                          PrintCount = Member.PrintCount == string.Empty ? 0 : (genRecBtnClicked ? Member.PrintCount.ToInt() + 1 : Member.PrintCount.ToInt()),
                          Key = (Member.ReceiptKey == null || Member.ReceiptKey == string.Empty) ? (int?)null : Member.ReceiptKey.ToInt(),
                          UpdatedDate = DateTime.Now.GetFormattedDateString(UniversalVariables.MySQLDateFormat)
                      };


                    var member = new ML_Member()
                    {
                        ALYear = txt_al_year.Text.Trim(),
                        AddressKey = Member.AddressKey.ToInt(),
                        ApprovalStage = getApprovalStage(),
                        ClassGroup = txt_class_group.Text.Trim(),
                        DateApproved = dtp_approved_rejected.GetFormattedDateString(UniversalVariables.MySQLDateFormat),
                        DateCardGivenToMember = dtp_given_to_member.GetFormattedDateString(UniversalVariables.MySQLDateFormat),
                        DateCardReceivedFromPrinter = dtp_received_from_printer.GetFormattedDateString(UniversalVariables.MySQLDateFormat),
                        DateCardSentToPrinter = dtp_sent_to_printer.GetFormattedDateString(UniversalVariables.MySQLDateFormat),
                        DateMemberNotified = dtp_member_notified.GetFormattedDateString(UniversalVariables.MySQLDateFormat),
                        DateRejected = dtp_rejected.GetFormattedDateString(UniversalVariables.MySQLDateFormat),
                        Deceased = chk_deceased.Checked,
                        DeceasedDate = dtp_deceased.GetFormattedDateString(UniversalVariables.MySQLDateFormat),
                        DOB = dtp_dob.GetFormattedDateString(UniversalVariables.MySQLDateFormat),
                        Email = txt_email.Text.Trim(),
                        EmailReturned = chk_email_returned.Checked,
                        Forenames = txt_forenames.Text.Trim(),
                        IdentificationNo = txt_id_val.Text.Trim(),
                        IdentificationType = cbo_id_type.Text,
                        Initials = txt_initials.Text.Trim(),
                        MailReturned = chk_mail_returned.Checked,
                        MembershipNo = (txt_mem_no.IsEmpty() && ts_approved_rejected.Enabled && ts_approved_rejected.IsOn) ? generateMemNo(ref memNoStr) : txt_mem_no.Text.Trim(),
                        MembershipDate = (memNoStr.IsNotEmpty() && ts_approved_rejected.Enabled && ts_approved_rejected.IsOn) ? DateTime.Now.ToString(UniversalVariables.MySQLDateFormat) : dtp_mem_date.GetFormattedDateString(UniversalVariables.MySQLDateFormat),
                        MembershipNotificationType = cbo_mem_not_type.Text,
                        Mobile = txt_mobile.Text,
                        OldMembershipNos = getDuplicateMemNos(),
                        OLYear = txt_ol_year.Text,
                        Outdated = chk_outdated.Checked,
                        ProfessionKey = cbo_profession.ToIntNullable(),
                        RefundCheqDate = dtp_rejected.GetFormattedDateString(UniversalVariables.MySQLDateFormat),
                        RefundChqNo = txt_rejected_cheque_no.Text.Trim(),
                        RejectedReason = rtb_rej_reason.Text.Trim(),
                        SalutationKey = Convert.ToInt32(cbo_salutation.EditValue),
                        Rejected = (ts_approved_rejected.Enabled && !ts_approved_rejected.IsOn) ? true : false,
                        Surname = txt_surname.Text.Trim(),
                        UserKey = UniversalVariables.UserKey,
                        YearJoined = txt_year_joined.Text,
                        YearLeft = txt_year_left.Text,
                        Picture = pic_member.Image != null ? ApplicationUtilities.imageToByteArray(pic_member.Image) : null,
                        Key = SelectedMemberKey,
                        UpdatedDate = DateTime.Now.GetFormattedDateString(UniversalVariables.MySQLDateFormat)
                    };


                    List<ML_Admission> admission = new List<ML_Admission>();

                    admission.Add(new ML_Admission
                    {
                        AdmissionNo = txt_admission_1.Text.Trim(),
                        School = UniversalVariables.School_STCMount
                    });

                    if (txt_admission_2.IsNotEmpty() && cbo_school_2.IsNotEmpty())
                    {
                        admission.Add(new ML_Admission
                        {
                            AdmissionNo = txt_admission_2.Text.Trim(),
                            School = cbo_school_2.Text.Trim()
                        });
                    }

                    ML_ProfessionalDetails professionalDetails = null;

                    if (txt_designation.IsNotEmpty() || txt_email_professional.IsNotEmpty() || cbo_org.IsNotEmpty())
                    {
                        professionalDetails = new ML_ProfessionalDetails()
                         {
                             Active = true,
                             Designation = txt_designation.Text.Trim(),
                             Email = txt_email_professional.Text.Trim(),
                             OrganisationKey = Convert.ToInt32(cbo_org.EditValue),
                             UpdatedDate = DateTime.Now.GetFormattedDateString(UniversalVariables.MySQLDateFormat)
                         };
                    }

                    #region Auto Remarks
                    if (!Member.Deceased && chk_deceased.Checked)
                    {
                        RemarksHistory.Add(new ML_RemarksHistory
                        {
                            Remarks = "Member marked as deceased.",
                            UserKey = UniversalVariables.UserKey,
                            UpdatedDate = DateTime.Now.GetFormattedDateString(UniversalVariables.MySQLDateFormat)
                        });
                    }

                    if (Member.Deceased && !chk_deceased.Checked)
                    {
                        RemarksHistory.Add(new ML_RemarksHistory { Remarks = "Member deceased reverted.", UpdatedDate = DateTime.Now.GetFormattedDateString(UniversalVariables.MySQLDateFormat), UserKey = UniversalVariables.UserKey });
                    }

                    if (Member.MembershipNo != null && Member.MembershipNo != txt_mem_no.Text.Trim())
                    {
                        RemarksHistory.Add(new ML_RemarksHistory { Remarks = "Membership no. changed manually.", UpdatedDate = DateTime.Now.GetFormattedDateString(UniversalVariables.MySQLDateFormat), UserKey = UniversalVariables.UserKey });
                    }

                    if ((Member.ApprovalStage != UniversalVariables.AppStage_Approved) && ts_approved_rejected.Enabled && ts_approved_rejected.IsOn)
                    {
                        RemarksHistory.Add(new ML_RemarksHistory { Remarks = "Member marked as approved.", UpdatedDate = DateTime.Now.GetFormattedDateString(UniversalVariables.MySQLDateFormat), UserKey = UniversalVariables.UserKey });
                    }
                    else if ((Member.ApprovalStage != UniversalVariables.AppStage_Rejected) && ts_approved_rejected.Enabled && !ts_approved_rejected.IsOn)
                    {
                        RemarksHistory.Add(new ML_RemarksHistory { Remarks = "Member marked as rejected.", UpdatedDate = DateTime.Now.GetFormattedDateString(UniversalVariables.MySQLDateFormat), UserKey = UniversalVariables.UserKey });
                    }

                    if (Member.DateCardGivenToMember == null && dtp_given_to_member.IsNotEmpty())
                    {
                        RemarksHistory.Add(new ML_RemarksHistory { Remarks = "Member given the membership card.", UpdatedDate = DateTime.Now.GetFormattedDateString(UniversalVariables.MySQLDateFormat), UserKey = UniversalVariables.UserKey });
                    }

                    if (Member.IdentificationNo != txt_id_val.Text.Trim())
                    {
                        RemarksHistory.Add(new ML_RemarksHistory { Remarks = "Identification no. changed.", UpdatedDate = DateTime.Now.GetFormattedDateString(UniversalVariables.MySQLDateFormat), UserKey = UniversalVariables.UserKey });
                    }
                    #endregion

                    new BL_Member().updateMember(
                        address,
                        receipt,
                        member,
                        admission,
                        professionalDetails,
                        RemarksHistory,
                        Configurations.ReceiptNoStr,
                        Configurations.MembershipDateStr,
                        Configurations.MembershipNoIndexStr,
                        UniversalVariables.School_STCMount,
                        UniversalVariables.UserKey.ToString()
                        );

                    DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);

                    XtraMessageBox.Show(this, (memNoStr.IsNotEmpty() ? string.Format("Member saved with membership no.: {0}!", memNoStr) : "Member saved successfully!"), "Operation Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
                #endregion
        }

        private string getApprovalStage()
        {
            string approvalStage = string.Empty;
            if (!chk_col_office.Checked)
            {
                approvalStage = UniversalVariables.AppStage_OBA;
            }
            else if (chk_col_office.Checked && !ts_approved_rejected.Enabled)
            {
                approvalStage = UniversalVariables.AppStage_ColOffice;
            }
            else if (ts_approved_rejected.Enabled && ts_approved_rejected.IsOn)
            {
                approvalStage = UniversalVariables.AppStage_Approved;
            }
            else if (ts_approved_rejected.Enabled && !ts_approved_rejected.IsOn)
            {
                approvalStage = UniversalVariables.AppStage_Rejected;
            }
            return approvalStage;
        }

        private void ResetFormAfterSave(bool insert)
        {
            if (insert)
            {

                DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this, typeof(AppProgress), true, true, false);
                ResetButtons();
                IsNewRecord = false;
                chk_include_deleted.Visible = false;
                tab_member.SelectedTabPageIndex = 0;
                chk_col_office_CheckedChanged(this, new EventArgs());
                bindSearchData();
                //this.Invoke((MethodInvoker)delegate { bindInitialData(); });
                rad_search_options.SelectedIndex = 1;
                mainSplit.Panel1.Enabled = true;
                DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
            }
            else
            {
                DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this, typeof(AppProgress), true, true, false);
                ResetButtons();
                IsNewRecord = false;
                chk_include_deleted.Visible = false;
                tab_member.SelectedTabPageIndex = 0;
                chk_col_office_CheckedChanged(this, new EventArgs());
                rad_search_options_SelectedIndexChanged(this, new EventArgs());
                //this.Invoke((MethodInvoker)delegate { bindInitialData(); });
                rad_search_options.SelectedIndex = 0;
                mainSplit.Panel1.Enabled = true;
                DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
            }
        }

        private void ResetButtons()
        {
            btn_delete.Enabled = hasAccessDelete;
            btn_new.Enabled = hasAccessInsert;
            btn_save.Enabled = btn_print.Enabled = (hasAccessInsert || hasAccessUpdate);
        }

        private string generateMemNo(ref string newMemNo)
        {
            string memNo = string.Empty;

            if (Configurations.InternetConnection)
            {
                DateTime date = getPresentDateWebRequest();
                memNo = (Convert.ToInt32(new BL_Member().getLastMemNo(string.Format("{0}{1}%", date.Year, date.Month.ToString().PadLeft(2, '0')))) + 1).ToString().PadLeft(3, '0');
            }
            else
            {
                memNo = (Convert.ToInt32(new BL_Member().getLastMemNo(string.Format("{0}{1}%", DateTime.Now.Year, DateTime.Now.Month.ToString().PadLeft(2, '0')))) + 1).ToString().PadLeft(3, '0');
            }

            newMemNo = memNo;

            return memNo;
        }

        private string getDuplicateMemNos()
        {
            string allDuplicateNos = string.Empty;
            foreach (string item in lst_mem_nos.Items)
            {
                if (item != string.Empty)
                {
                    allDuplicateNos = string.Format("{0}{1};", allDuplicateNos, item);
                }
            }
            return allDuplicateNos;
        }

        private void ValidateTabs(ref bool Tab_Member, ref bool Tab_School, ref bool Tab_Processing, ref bool Tab_Professional)
        {
            if (!vp_main.Validate() | !vp_TelephoneValidation.Validate() | !vp_EmailValidation.Validate() | !vp_MobileValidation.Validate() | !vp_phone.Validate() | !vp_email.Validate())
            {
                Tab_Member = false;
                tp_member.Image = OBALog.Windows.Properties.Resources.High_Importance;
            }
            else
            {
                Tab_Member = true;
                tp_member.Image = null;
            }

            if (!vp_school_details.Validate())
            {
                Tab_School = false;
                tp_school.Image = OBALog.Windows.Properties.Resources.High_Importance;
            }
            else
            {
                Tab_School = true;
                tp_school.Image = null;
            }


            if (!vp_date_validator.Validate())
            {
                Tab_Processing = false;
                tp_processing.Image = OBALog.Windows.Properties.Resources.High_Importance;
            }
            else
            {
                Tab_Processing = true;
                tp_processing.Image = null;
            }

            if (!vp_email_professional.Validate())
            {
                Tab_Professional = false;
                tp_profession.Image = OBALog.Windows.Properties.Resources.High_Importance;
            }
            else
            {
                Tab_Professional = true;
                tp_profession.Image = null;
            }
        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            try
            {
                ResetForm();
                FormatButtons(true);
                mainSplit.Panel1.Enabled = false;
                IsNewRecord = true;
                //FormDirty = false;
            }
            catch (Exception ex)
            {
                AuditFactory.AuditLog(ex);
                ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, ex.Message);
            }

        }

        private void ResetForm()
        {
            if (FormDirty)
            {

            }
            else
            {

            }

            ClearAllForm(tab_member);
            SetDefaults();
        }

        private void SetDefaults()
        {
            Member = new ML_ViewMember();
            cbo_salutation.EditValue = Configurations.DefaultSalutation;
            cbo_country.EditValue = Configurations.DefaultCountry;
            cbo_city.EditValue = Configurations.DefaultCity;
            FormatDeceased();
            FormatButtons(true);
            RemarksHistory.Clear();
            BindRemarksHistory();
            pic_approval_stage.Visible = false;
            grp_processing_complete.Enabled = false;
            //gvSearch.ClearSelection();
            //if (gvSearch.SelectedRowsCount > 0)
            //    gvSearch.UnselectRow(gvSearch.FocusedRowHandle);
        }

        public static void ClearAllForm(Control Ctrl)
        {
            foreach (Control ctrl in Ctrl.Controls)
            {
                if (ctrl is TextEdit || ctrl is LookUpEdit || ctrl is DateEdit || ctrl is SpinEdit)
                {
                    BaseEdit editor = ctrl as BaseEdit;
                    if (editor != null)
                        editor.EditValue = null;
                }
                else if (ctrl is PictureEdit)
                {
                    (ctrl as PictureEdit).Image = null;
                }
                else if (ctrl is CheckEdit)
                {
                    (ctrl as CheckEdit).Checked = false;
                }
                else if (ctrl is ListBoxControl)
                {
                    (ctrl as ListBoxControl).Clear();
                }

                ClearAllForm(ctrl);
            }
        }

        private void btn_profession_Click(object sender, EventArgs e)
        {
            try
            {
                new ManageProfessions().ShowDialog();
                bindProfession();
            }
            catch (Exception ex)
            {
                AuditFactory.AuditLog(ex);
                ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, ex.Message);
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Warning, string.Format("Are you sure you want to delete the record with name: {0} {1} ? This can only be undone by the database administrator!", txt_initials.Text, txt_surname.Text), "Warning") == System.Windows.Forms.DialogResult.OK)
                {
                    new BL_Member().delete(new ML_Member { Key = SelectedMemberKey });
                    ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Information, string.Format("Member with name: {0} {1} has been successfully deleted.", txt_initials.Text, txt_surname.Text), "Deletion Successful!");

                    bindSearchData();
                }
            }
            catch (Exception ex)
            {
                AuditFactory.AuditLog(ex);
                ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, ex.Message);
            }
        }

        private void loadMemberDetails(int SelectedMemberKey)
        {
            try
            {
                using (DataSet dt = new BL_Member().select(SelectedMemberKey))
                {
                    Member = dt.Tables[0].Rows.Count == 1 ? dt.Tables[0].DataTableToList<ML_ViewMember>()[0] : null;
                    Admission = dt.Tables[1].Rows.Count == 1 ? dt.Tables[1].DataTableToList<ML_Admission>()[0] : null;
                    ProfessionalDetails = dt.Tables[2].Rows.Count >= 1 ? dt.Tables[2].DataTableToList<ML_ProfessionalDetails>() : new List<ML_ProfessionalDetails>();
                    RemarksHistory = dt.Tables[3].Rows.Count >= 1 ? dt.Tables[3].DataTableToList<ML_RemarksHistory>() : new List<ML_RemarksHistory>();

                    if (dt.Tables[4].Rows.Count == 1)
                    {
                        byte[] bytes = (byte[])dt.Tables[4].Rows[0]["Picture"];
                        pic_member.Image = ApplicationUtilities.byteArrayToImage(bytes);
                    }
                    else
                    {
                        pic_member.Image = null;
                    }
                }

                if (Member != null)
                {
                    #region TAB 1 - Personal Details
                    cbo_salutation.EditValue = Member.SalutationKey.ToIntNullable();
                    txt_forenames.Text = Member.Forenames;
                    txt_surname.Text = Member.Surname;
                    txt_initials.Text = Member.Initials;
                    txt_mem_no.Text = Member.MembershipNo;
                    cbo_id_type.SelectedText = Member.IdentificationType;
                    txt_id_val.Text = Member.IdentificationNo;
                    dtp_dob.EditValue = Member.DOB.DateFromString();
                    dtp_mem_date.EditValue = Member.MembershipDate.DateFromString();
                    chk_outdated.Checked = Member.Outdated;
                    lst_mem_nos.Items.Clear();
                    lst_mem_nos.Items.AddRange(Member.OldMembershipNos.Trim().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries));
                    txt_mobile.Text = Member.Mobile;
                    txt_email.Text = Member.Email;
                    chk_email_returned.Checked = Member.EmailReturned;
                    cbo_country.EditValue = Member.CountryKey.ToIntNullable();
                    cbo_city.EditValue = Member.CityKey.ToIntNullable();
                    txt_address.Text = Member.address;
                    txt_tel.Text = Member.Telephone;
                    chk_mail_returned.Checked = Member.MailReturned;

                    BindRemarksHistory();
                    #endregion


                    #region TAB 2 - School Details
                    txt_admission_1.Text = Member.AdmissionNo;
                    txt_admission_2.Text = Admission == null ? string.Empty : Admission.AdmissionNo;
                    cbo_school_2.EditValue = Admission == null ? string.Empty : Admission.School;
                    txt_year_joined.Text = Member.YearJoined;
                    txt_year_left.Text = Member.YearLeft;
                    txt_class_group.Text = Member.ClassGroup;
                    txt_ol_year.Text = Member.OLYear;
                    txt_al_year.Text = Member.ALYear;
                    #endregion

                    #region TAB 3 - Processing Details
                    txt_rec_no.Text = Member.ReceiptNo;
                    dtp_rec_date.EditValue = Member.ReceiptDate.DateFromString();
                    txt_amount.Text = Member.ReceiptAmount;
                    cbo_payment_type.SelectedText = Member.PaymentType;
                    txt_cheque_no.Text = Member.CardChequeNo;
                    txt_bank.Text = Member.Bank;
                    FormatApprovalStage(Member.ApprovalStage, Member.DateApproved, Member.DateRejected);
                    dtp_col_office.EditValue = Member.DateSentToOffice.DateFromString();
                    dtp_sent_to_printer.EditValue = Member.DateCardSentToPrinter.DateFromString();
                    dtp_member_notified.EditValue = Member.DateMemberNotified.DateFromString();
                    dtp_received_from_printer.EditValue = Member.DateCardReceivedFromPrinter.DateFromString();
                    dtp_given_to_member.EditValue = Member.DateCardGivenToMember.DateFromString();
                    txt_receipt_print_count.Text = Member.PrintCount;
                    cbo_mem_not_type.SelectedText = Member.MembershipNotificationType;
                    txt_rejected_cheque_no.Text = Member.RefundChqNo;
                    rtb_rej_reason.Text = Member.RejectedReason;
                    dtp_rejected.EditValue = Member.DateRejected.DateFromString();
                    #endregion


                    #region TAB 4 - Professional Details
                    cbo_profession.EditValue = Member.ProfessionKey.ToIntNullable();
                    cbo_org.EditValue = Member.OrganisationKey.ToIntNullable();
                    txt_category.Text = Member.Category;
                    txt_sub_category.Text = Member.SubCategory;
                    txt_email_professional.Text = ProfessionalDetails.Count == 1 ? ProfessionalDetails[0].Email : null;
                    txt_designation.Text = ProfessionalDetails.Count == 1 ? ProfessionalDetails[0].Designation : null;
                    #endregion

                    #region Form Controls & Privileges
                    FormatButtons(!Member.Deleted);

                    FormatDeceased();

                    AllocatePrivileges();
                    #endregion
                }
            }
            catch (Exception ex)
            {
                AuditFactory.AuditLog(ex);
                ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, ex.Message);
            }
        }

        private void AllocatePrivileges()
        {

            #region Level 3
            txt_mem_no.Enabled = !Privileges.CheckAccess(Privileges.MembershipDetails_MemberDetails_MembershipNo);
            txt_initials.Enabled = !Privileges.CheckAccess(Privileges.MembershipDetails_MemberDetails_PersonalDetails_Initials);
            txt_surname.Enabled = !Privileges.CheckAccess(Privileges.MembershipDetails_MemberDetails_PersonalDetails_Surname);
            dtp_mem_date.Enabled = !Privileges.CheckAccess(Privileges.MembershipDetails_MemberDetails_MembershipDate);
            txt_id_val.Enabled = !Privileges.CheckAccess(Privileges.MembershipDetails_MemberDetails_PersonalDetails_IDVal);
            txt_rec_no.Enabled = !Privileges.CheckAccess(Privileges.MembershipDetails_ProcessingDetails_ReceiptDetails_ReceiptNo);
            dtp_rec_date.Enabled = !Privileges.CheckAccess(Privileges.MembershipDetails_ProcessingDetails_ReceiptDetails_ReceiptDate);
            txt_forenames.Enabled = !Privileges.CheckAccess(Privileges.MembershipDetails_MemberDetails_PersonalDetails_Forenames);
            #endregion

            #region Level 2
            if (Member.ReceiptNo.IsNotEmpty())
            {
                cbo_mem_not_type.Enabled = !Privileges.CheckAccess(Privileges.MembershipDetails_DisableMemNotTypeAfterRecGen);
                grp_receipt.Enabled = !Privileges.CheckAccess(Privileges.MembershipDetails_DisableRecDetAfterRecGen);
                grp_reg_progress.Enabled = !Privileges.CheckAccess(Privileges.MembershipDetails_DisableRegProgAfterRecGen);
                tp_school.Enabled = !Privileges.CheckAccess(Privileges.MembershipDetails_DisableSchoolDetAfterRecGen);
            }

            if (Member.DateCardGivenToMember.IsNotEmpty())
            {
                grp_crd_processing.Enabled = !Privileges.CheckAccess(Privileges.MembershipDetails_DisableCardProIfCardGivenToMem);
                dtp_mem_date.Enabled = !Privileges.CheckAccess(Privileges.MembershipDetails_DisableMemDateIfCardGivenToMem);
                txt_mem_no.Enabled = !Privileges.CheckAccess(Privileges.MembershipDetails_DisableMemNoIfCardGivenToMem);
                grp_reg_progress.Enabled = !Privileges.CheckAccess(Privileges.MembershipDetails_DisableRegProgIfCardGivenToMem);
            }

            if (Member.Deceased)
            {
                btn_delete.Enabled = !Privileges.CheckAccess(Privileges.MembershipDetails_DisableDeleteIfDeceased);
                chk_deceased.Enabled = !Privileges.CheckAccess(Privileges.MembershipDetails_DisableDeceasedIfDeceased);
                dtp_deceased.Enabled = !Privileges.CheckAccess(Privileges.MembershipDetails_DisableDeceasedDateIfDeceased);
                btn_save.Enabled = btn_print.Enabled = !Privileges.CheckAccess(Privileges.MembershipDetails_DisableSaveIfDeceased);
            }

            if (Member.Deleted)
            {
                btn_save.Enabled = btn_print.Enabled = !Privileges.CheckAccess(Privileges.MembershipDetails_DisableSaveIfDel);
            }

            if (Member.Rejected)
            {
                btn_delete.Enabled = !Privileges.CheckAccess(Privileges.MembershipDetails_DisableDeleteIfRej);
                btn_save.Enabled = btn_print.Enabled = !Privileges.CheckAccess(Privileges.MembershipDetails_DisableSaveIfRej);
            }

            if (Member.ReceiptNo.IsEmpty())
            {
                cbo_mem_not_type.Enabled = !Privileges.CheckAccess(Privileges.MembershipDetails_DisableMemNotTypeTillRecGen);
            }

            if (Member.ApprovalStage == UniversalVariables.AppStage_Approved || Member.ApprovalStage == UniversalVariables.AppStage_Rejected)
            {
                btn_delete.Enabled = !Privileges.CheckAccess(Privileges.MembershipDetails_DisableDelMemAfterAppRej);
                txt_amount.Enabled = !Privileges.CheckAccess(Privileges.MembershipDetails_DisableRecAmtAfterAppRej);
            }

            if (Member.ApprovalStage == UniversalVariables.AppStage_Approved)
            {
                grp_reg_progress.Enabled = !Privileges.CheckAccess(Privileges.MembershipDetails_DisableRegProgAfterApp);
                tp_school.Enabled = !Privileges.CheckAccess(Privileges.MembershipDetails_DisableSchoolDetAfterApp);

            }
            #endregion
        }

        private void FormatButtons(bool IsEnabled)
        {
            btn_delete.Enabled = IsEnabled;
            btn_save.Enabled = IsEnabled;
        }

        private void BindRemarksHistory()
        {
            lst_remarks.Items.Clear();

            if (RemarksHistory != null)
            {
                RemarksHistory.ForEach(remark => lst_remarks.Items.Add(remark.Remarks));
            }
        }

        private void FormatApprovalStage(string ApprovalStage, string DateApproved, string DateRejected)
        {
            switch (ApprovalStage)
            {
                case UniversalVariables.AppStage_ColOffice:
                    chk_col_office.ReadOnly = false;
                    chk_col_office.Checked = true;
                    ts_approved_rejected.ReadOnly = false;
                    pic_approval_stage.Visible = true;
                    pic_approval_stage.BackColor = Color.Yellow;
                    pic_approval_stage.Properties.NullText = "PENDING";
                    break;
                case UniversalVariables.AppStage_Approved:
                    dtp_approved_rejected.EditValue = DateApproved;
                    ts_approved_rejected.ReadOnly = false;
                    pic_approval_stage.Visible = false;
                    break;
                case UniversalVariables.AppStage_Rejected:
                    dtp_approved_rejected.EditValue = DateRejected;
                    ts_approved_rejected.ReadOnly = false;
                    pic_approval_stage.Visible = true;
                    pic_approval_stage.BackColor = Color.Red;
                    pic_approval_stage.Properties.NullText = "REJECTED";
                    break;
                default:
                    ts_approved_rejected.Enabled = false;
                    pic_approval_stage.Visible = false;
                    break;
            }
        }

        private void FormatDeceased()
        {
            if (Member.Deceased)
            {
                chk_deceased.Checked = true;
                chk_deceased.ForeColor = Color.Red;
                lbl_deceased_date.ForeColor = Color.Red;
                lbl_deceased_date.Font = new Font(lbl_deceased_date.Font, FontStyle.Bold);
                chk_deceased.Font = new Font(chk_deceased.Font, FontStyle.Bold);
                dtp_deceased.ForeColor = Color.Red;
            }
            else
            {
                chk_deceased.Checked = false;
                chk_deceased.ForeColor = Color.FromArgb(32, 31, 53);
                lbl_deceased_date.ForeColor = Color.FromArgb(32, 31, 53);
                lbl_deceased_date.Font = new Font(lbl_deceased_date.Font, FontStyle.Regular);
                chk_deceased.Font = new Font(chk_deceased.Font, FontStyle.Regular);
                dtp_deceased.ForeColor = Color.FromArgb(32, 31, 53);
            }
        }

        private void txt_admission_2_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                txt_admission_2.Text = cbo_school_2.IsEmpty() ? null : txt_admission_2.Text;
            }
            catch (Exception ex)
            {
                AuditFactory.AuditLog(ex);
                ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, ex.Message);
            }
        }

        private void chk_col_office_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                grp_processing_complete.Enabled = chk_col_office.Checked;
            }
            catch (Exception ex)
            {
                AuditFactory.AuditLog(ex);
                ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, ex.Message);
            }
        }

        private void gvSearch_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

        }

        private void btn_view_remarks_Click(object sender, EventArgs e)
        {
            try
            {
                ApplicationUtilities.DisplayForm(new ManageRemarks(RemarksHistory), this);
            }
            catch (Exception ex)
            {
                AuditFactory.AuditLog(ex);
                ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, ex.Message);
            }
        }

        private void btn_add_remark_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_new_remark.IsNotEmpty())
                {
                    RemarksHistory.Add(new ML_RemarksHistory { MemberKey = SelectedMemberKey, Remarks = txt_new_remark.Text, UpdatedDate = DateTime.Now.GetFormattedDateString(UniversalVariables.MySQLDateFormat), User = UniversalVariables.Name });
                    txt_new_remark.ClearAndFocus();
                    BindRemarksHistory();
                }
            }
            catch (Exception ex)
            {
                AuditFactory.AuditLog(ex);
                ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, ex.Message);
            }
        }

        private void gvSearch_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            try
            {
                //gvSearch.OptionsSelection.EnableAppearanceFocusedRow = true;
                if (gvSearch.SelectedRowsCount == 1)
                {
                    DataRow currentRow = (gvSearch.GetFocusedDataRow() as DataRow);
                    if (currentRow != null)
                    {
                        SelectedMemberKey = (int)currentRow["KEY"];
                        loadMemberDetails(SelectedMemberKey);
                    }
                }
            }
            catch (Exception ex)
            {
                AuditFactory.AuditLog(ex);
                ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, ex.Message);
            }
        }

        private void btn_picture_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog ofd_picture = new OpenFileDialog() { Filter = "All Supported Formats|*.jpg;*.jpeg;*.bmp;*.tiff;*.tif;*.png;*.gif|JPEG files (*.jpg)|*.jpg|GIF files (*.gif)|*.gif|PNG files (*.png)|*.png" })
                {
                    ofd_picture.ShowDialog();

                    if (ofd_picture.FileName != null)
                    {
                        pic_member.Image = Image.FromFile(ofd_picture.FileName);
                    }
                }
            }
            catch (Exception ex)
            {
                AuditFactory.AuditLog(ex);
                ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, ex.Message);
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_old_mem_nos.IsNotEmpty() && !txt_old_mem_nos.Text.Contains(";"))
                {
                    lst_mem_nos.Items.Add(txt_old_mem_nos.Text);
                    txt_old_mem_nos.ClearAndFocus();
                }
                else
                {
                    ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, "The duplicate membership no. cannot be null or contain the ';' character!", "Error Adding Value");
                    txt_old_mem_nos.Focus();
                }
            }
            catch (Exception ex)
            {
                AuditFactory.AuditLog(ex);
                ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, ex.Message);
            }
        }

        private void btn_remove_Click(object sender, EventArgs e)
        {
            try
            {
                if (lst_mem_nos.SelectedIndex > -1)
                {
                    lst_mem_nos.Items.RemoveAt(lst_mem_nos.SelectedIndex);
                }
            }
            catch (Exception ex)
            {
                AuditFactory.AuditLog(ex);
                ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, ex.Message);
            }
        }

        private void txt_new_remark_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && txt_new_remark.IsNotEmpty())
                {
                    btn_add_remark_Click(this, new EventArgs());
                }
            }
            catch (Exception ex)
            {
                AuditFactory.AuditLog(ex);
                ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, ex.Message);
            }
        }

        private void txt_old_mem_nos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txt_old_mem_nos.IsNotEmpty())
            {
                btn_add_Click(this, new EventArgs());
            }
        }

        private void search_chk_include_duplicates_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                search_txt_old_mem_no.ReadOnly = search_chk_include_duplicates.Checked;
            }
            catch (Exception ex)
            {
                AuditFactory.AuditLog(ex);
                ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, ex.Message);
            }
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            try
            {
                if (ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.YesNo, string.Format("The record needs to be saved before the receipt can be generated.{0}Are you sure you want to save the record now?", Environment.NewLine), "Generate Receipt") == DialogResult.Yes)
                {
                    SaveCore(false, true);

                    DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this, typeof(AppProgress), true, true, false);

                    rptReceipt report = new rptReceipt();

                    report.Parameters["MemberKey"].Value = SelectedMemberKey;
                    report.Parameters["MemberKey"].Visible = false;
                    DevExpress.XtraReports.UI.ReportPrintTool tool = new DevExpress.XtraReports.UI.ReportPrintTool(report);

                    DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);

                    tool.ShowPreview(this, this.LookAndFeel);
                }
            }
            catch (Exception ex)
            {
                AuditFactory.AuditLog(ex);
                ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, ex.Message);
            }
        }

        private void dtp_sent_to_printer_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (dtp_sent_to_printer.EditValue != null)
                {
                    dtp_received_from_printer.Enabled = true;
                }
                else
                {
                    dtp_received_from_printer.EditValue = null;
                    dtp_received_from_printer.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                AuditFactory.AuditLog(ex);
                ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, ex.Message);
            }
        }

        private void dtp_received_from_printer_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (dtp_received_from_printer.EditValue != null)
                {
                    dtp_member_notified.Enabled = true;
                }
                else
                {
                    dtp_member_notified.EditValue = null;
                    dtp_member_notified.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                AuditFactory.AuditLog(ex);
                ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, ex.Message);
            }
        }

        private void dtp_member_notified_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (dtp_member_notified.EditValue != null)
                {
                    dtp_given_to_member.Enabled = true;
                }
                else
                {
                    dtp_given_to_member.EditValue = null;
                    dtp_given_to_member.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                AuditFactory.AuditLog(ex);
                ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, ex.Message);
            }
        }

        private void MemberDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                e.Cancel = !ApplicationUtilities.CheckFormDirtyClose(CloseFormWithChecks, FormDirty);
            }
            catch (Exception ex)
            {
                AuditFactory.AuditLog(ex);
                ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, ex.Message);
            }
        }

        private bool CloseFormWithChecks()
        {
            return true;
        }

        private void grp_processing_complete_CustomButtonChecked(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            try
            {
                ts_approved_rejected.Enabled = true;
                dtp_approved_rejected.Enabled = true;
            }
            catch (Exception ex)
            {
                AuditFactory.AuditLog(ex);
                ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, ex.Message);
            }
        }

        private void grp_processing_complete_CustomButtonUnchecked(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            try
            {
                ts_approved_rejected.Enabled = false;
                dtp_approved_rejected.Enabled = false;
            }
            catch (Exception ex)
            {
                AuditFactory.AuditLog(ex);
                ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, ex.Message);
            }
        }

        public DateTime getPresentDateWebRequest()
        {
            try
            {
                DateTime dateTime = default(DateTime);

                using (WebClient client = new WebClient())
                {
                    string text = client.DownloadString("http://nist.time.gov/actualtime.cgi?lzbc=siqm9b");
                    double milliseconds = Convert.ToInt64(System.Text.RegularExpressions.Regex.Match(text, "(?<=\\btime=\")[^\"]*").Value) / 1000.0;
                    dateTime = new DateTime(1970, 1, 1).AddMilliseconds(milliseconds).ToLocalTime();
                }

                return dateTime;
            }
            catch (WebException ex)
            {
                throw new Exception("A working Internet connection is required to generate the Membership No. The save process will now abort. Please contact the System Administrator!", new Exception(ex.Message));
            }
        }

        private void btn_add_org_Click(object sender, EventArgs e)
        {
            try
            {
                new ManageOrganisations().ShowDialog();
                bindOrganisation();
            }
            catch (Exception ex)
            {
                AuditFactory.AuditLog(ex);
                ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, ex.Message);
            }
        }

        private void ts_approved_rejected_Toggled(object sender, EventArgs e)
        {
            try
            {
                grp_rejected.Enabled = !ts_approved_rejected.IsOn;
            }
            catch (Exception ex)
            {
                AuditFactory.AuditLog(ex);
                ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, ex.Message);
            }
        }
    }
}