using OBALog.Business;
using OBALog.Model;
using System;
using System.Data;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace OBALog.Windows
{
    public partial class Home : DevExpress.XtraEditors.XtraForm
    {
        private Login LoginForm;
        private Utilities.IdleTimeTool idleTimeTool;
        public Home()
        {
            InitializeComponent();
            idleTimeTool = new Utilities.IdleTimeTool();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            ManageLogin(false);
        }

        private void ManageLogin(bool IsLogOut)
        {
            try
            {
                this.lbl_name.Text = string.Empty;
                LoginForm = new Login();

                if (IsLogOut)
                {
                    new BL_UsageLog().update(new ML_UsageLog { UserKey = UniversalVariables.UserKey, To = DateTime.Now });

                    UniversalVariables.IsLoggedIn = false;

                    LoginForm.btExit.Click -= btExit_Click;
                    LoginForm.btn_Login.Click -= btn_Login_Click;
                }

                // this.MenuStrip1.Enabled = false;
                LoginForm.btExit.Click += btExit_Click;
                LoginForm.btn_Login.Click += btn_Login_Click;
                lbUserName.Visible = false;
                LoginForm.Owner = this;
                //LoginForm.Parent = this;
                MenuStrip1.Enabled = false;
                LoginForm.Show(this);
                LoginForm.txt_loginid.Text = string.Empty;
                LoginForm.txt_pwd.Text = string.Empty;
                LoginForm.txt_loginid.Text = "admin";
                LoginForm.txt_pwd.Text = "aaa111";

                LoginForm.Focus();
                LoginForm.txt_loginid.Focus();
            }
            catch (Exception ex)
            {
                AuditFactory.AuditLog(ex);
                ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, ex.Message);
            }

        }

        void btn_Login_Click(object sender, EventArgs e)
        {
            try
            {
                if (LoginForm.txt_loginid.IsNotEmpty() && LoginForm.txt_pwd.IsNotEmpty())
                {
                    DataSet user = new BL_User().checkLogin(new ML_User { LoginId = LoginForm.txt_loginid.Text, Password = LoginForm.txt_pwd.Text });

                    if (user.Tables[0].Rows.Count == 1 && user.Tables[1].Rows.Count > 0)
                    {
                        UniversalVariables.UserKey = user.Tables[0].Rows[0]["Key"].ToString().ToInt();
                        UniversalVariables.Name = user.Tables[0].Rows[0]["Name"].ToString();
                        UniversalVariables.UserAccessTypeKey = user.Tables[0].Rows[0]["UserAccessTypeKey"].ToString().ToInt();
                        UniversalVariables.AccessTypeName = user.Tables[0].Rows[0]["AccessTypeName"].ToString();
                        UniversalVariables.Username = user.Tables[0].Rows[0]["LoginId"].ToString();

                        UniversalVariables.IsLoggedIn = true;

                        Privileges.UserPrivileges = user.Tables[1];
                        Configurations.ConfigurationTable = user.Tables[2];

                        lbUserName.Text = "Logged in as : " + UniversalVariables.Name;
                        lbUserName.Visible = true;
                        MenuStrip1.Enabled = true;

                        SetDefaults(false);
                        SetMainFormPrivileges();
                        LoginForm.Hide();
                    }
                    else
                    {
                        ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, "Wrong username and / or password! Please enter correct details to continue.", "Login Error!");
                        LoginForm.txt_loginid.Focus();
                    }
                }
                else
                {
                    ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, "The username and / or password field/s cannot be blank. Please re-check!", "Login Error!");
                    LoginForm.txt_loginid.Focus();
                }
            }
            catch (Exception ex)
            {
                AuditFactory.AuditLog(ex);
                ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, ex.Message);
            }
        }

        private void SetDefaults(bool hasAccess)
        {
            MembershipToolStripMenuItem.Visible = hasAccess;
            MemberToolStripMenuItem.Visible = hasAccess;

            AdminToolStripMenuItem.Visible = hasAccess;
            ManageConfigurationsToolStripMenuItem.Visible = hasAccess;
            UsersToolStripMenuItem.Visible = hasAccess;
            ManageUserAccessTypesToolStripMenuItem.Visible = hasAccess;
            PrivilegesToolStripMenuItem.Visible = hasAccess;

            DataToolStripMenuItem.Visible = hasAccess;
            ManageOrganisationCategoriesSubCategoriesToolStripMenuItem.Visible = hasAccess;
            ManageCountriesCitiesToolStripMenuItem.Visible = hasAccess;
            ManageOrganisationsToolStripMenuItem.Visible = hasAccess;
            ManageProfessionsToolStripMenuItem.Visible = hasAccess;
            ManageSalutationsToolStripMenuItem.Visible = hasAccess;
        }

        private void SetMainFormPrivileges()
        {
            foreach (string privilege in Privileges.UserPrivileges.AsEnumerable().Where(rc => Convert.ToBoolean(rc["Allowed"].ToString()) == true).Select(rc => rc["Privilege"].ToString()).Where(rc => rc.Contains("Open")))
            {
                switch (privilege)
                {
                    case Privileges.MembershipDetails_Open:
                        MembershipToolStripMenuItem.Visible = true;
                        MemberToolStripMenuItem.Visible = true;
                        break;
                    case Privileges.Configurations_Open:
                        AdminToolStripMenuItem.Visible = true;
                        ManageConfigurationsToolStripMenuItem.Visible = true;
                        break;
                    case Privileges.CountryCity_Open:
                        DataToolStripMenuItem.Visible = true;
                        ManageCountriesCitiesToolStripMenuItem.Visible = true;
                        break;
                    case Privileges.Organisations_Open:
                        DataToolStripMenuItem.Visible = true;
                        ManageOrganisationsToolStripMenuItem.Visible = true;
                        break;
                    case Privileges.Privileges_Open:
                        AdminToolStripMenuItem.Visible = true;
                        PrivilegesToolStripMenuItem.Visible = true;
                        break;
                    case Privileges.Professions_Open:
                        DataToolStripMenuItem.Visible = true;
                        ManageProfessionsToolStripMenuItem.Visible = true;
                        break;
                    case Privileges.Salutations_Open:
                        DataToolStripMenuItem.Visible = true;
                        ManageSalutationsToolStripMenuItem.Visible = true;
                        break;
                    case Privileges.UAT_Open:
                        AdminToolStripMenuItem.Visible = true;
                        ManageUserAccessTypesToolStripMenuItem.Visible = true;
                        break;
                    case Privileges.Users_Open:
                        AdminToolStripMenuItem.Visible = true;
                        UsersToolStripMenuItem.Visible = true;
                        break;
                    case Privileges.OrganisationCategoriesSubCategories_Open:
                        DataToolStripMenuItem.Visible = true;
                        ManageOrganisationCategoriesSubCategoriesToolStripMenuItem.Visible = true;
                        break;
                    default:
                        break;
                }
            }

        }

        void btExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ManageFormClosingEvent(FormClosingEventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to exit?", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (UniversalVariables.UserKey != 0)
                    {
                        new BL_UsageLog().update(new ML_UsageLog { UserKey = UniversalVariables.UserKey, To = DateTime.Now });
                    }

                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                AuditFactory.AuditLog(ex);
                ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, ex.Message);
            }

        }

        private void ManageOrganisationSectorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplicationUtilities.DisplayForm(new ManageCategoriesSubCategories(), this);
        }

        private void LoginToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            var result_msg_box = ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.YesNoCancel, "Are you sure you want to initiate a new session? Any unsaved data will be lost. \n \nIf you click 'Yes', you will lose all your unsaved data and all the open forms will be closed.", "Confirm Re-login!");
            if (result_msg_box.Equals(DialogResult.Yes))
            {
                for (int i = Application.OpenForms.Count - 1; i >= 1; i += -1)
                {
                    Form form = Application.OpenForms[i];
                    if (form.Name != "Home")
                    {
                        form.Close();
                    }
                }

                ManageLogin(true);
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MemberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplicationUtilities.DisplayForm(new MemberDetails(), this);
        }

        private void ManageCountriesCitiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplicationUtilities.DisplayForm(new ManageCountryCity(), this);
        }

        private void ManageOrganisationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplicationUtilities.DisplayForm(new ManageOrganisations(), this);
        }

        private void ManageProfessionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplicationUtilities.DisplayForm(new ManageProfessions(), this);
        }

        private void ManageSalutationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplicationUtilities.DisplayForm(new ManageSalutations(), this);
        }

        private void ContactAdminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplicationUtilities.DisplayForm(new About(), this);
        }

        private void Home_FormClosing(object sender, FormClosingEventArgs e)
        {
            ManageFormClosingEvent(e);
        }

        private void Home_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void ManageConfigurationsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ApplicationUtilities.DisplayForm(new ManageConfigurations(), this);
        }

        private void usageLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplicationUtilities.DisplayForm(new ViewSessions(), this);
        }

        private void UsersToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ApplicationUtilities.DisplayForm(new ManageUsers(), this);
        }

        private void ManageUserAccessTypesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ApplicationUtilities.DisplayForm(new ManageUserAccessTypes(), this);
        }

        private void UserAccessLevelsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ApplicationUtilities.DisplayForm(new ManagePrivileges(), this);
        }

        private void changePasswordToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ApplicationUtilities.DisplayForm(new ResetPassword(), this);
        }
        bool flag = true;
        private void InactivityTimer_Tick(object sender, EventArgs e)
        {
            if (UniversalVariables.IsLoggedIn)
            {
                //Calculates for how long we have been idle
                var inactiveTime = idleTimeTool.GetInactiveTime();
                Console.WriteLine(inactiveTime.ToString());
                if (inactiveTime == null)
                {
                    //Unknown state
                    tmr_close_form.Enabled = false;
                }
                else if (inactiveTime.Value.TotalSeconds > Configurations.TimeoutPeriod.TotalSeconds & flag)
                {
                    //Idle
                    flag = false;
                    Utilities.MyXtraMessageArgs myArgs = new Utilities.MyXtraMessageArgs()
                    {
                        Owner = this,
                        Timeout = Configurations.LogoffPeriod.TotalSeconds.ToString().ToInt(),
                        ShowCountdown = true,
                        AutoClose = true,
                        
                        Icon = MessageBoxIcon.Warning.ToString(),
                        Buttons = MessageBoxButtons.OKCancel,
                        Text = string.Format("OBALog has been inactive for {0} hour/s, {1} minute/s and {2} second/s. It will log off after above time has elapsed due to inactivity. Click on 'Cancel' to cancel logging off. Clicking on 'OK' will make the system logoff now.", Configurations.TimeoutPeriod.Hours, Configurations.TimeoutPeriod.Minutes, Configurations.TimeoutPeriod.Seconds)
                    };
                    //new Utilities.MyXtraMessageBoxForm().ShowForm(myArgs);
                    InactivityTimer.Enabled = false;

                }
            }
        }

        private void tmr_close_form_Tick(object sender, EventArgs e)
        {

        }

    }
}
