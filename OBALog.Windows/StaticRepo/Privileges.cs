using System.Data;
using System.Linq;

namespace OBALog.Windows
{
    [System.Diagnostics.DebuggerStepThrough()]
    public static class Privileges
    {
        public static DataTable UserPrivileges { get; set; }

        #region Level 1

        public const string MembershipDetails_Open = "MembershipDetails_Open";
        public const string MembershipDetails_Insert = "MembershipDetails_Insert";
        public const string MembershipDetails_Delete = "MembershipDetails_Delete";
        public const string MembershipDetails_Update = "MembershipDetails_Update";

        public const string CountryCity_Open = "CountryCity_Open";
        public const string CountryCity_Insert = "CountryCity_Insert";
        public const string CountryCity_Update = "CountryCity_Update";
        public const string CountryCity_Delete = "CountryCity_Delete";

        public const string Configurations_Open = "Configurations_Open";
        public const string Configurations_Insert = "Configurations_Insert";
        public const string Configurations_Update = "Configurations_Update";
        public const string Configurations_Delete = "Configurations_Delete";

        public const string Salutations_Open = "Salutations_Open";
        public const string Salutations_Update = "Salutations_Update";
        public const string Salutations_Insert = "Salutations_Insert";
        public const string Salutations_Delete = "Salutations_Delete";

        public const string UAT_Open = "UAT_Open";
        public const string UAT_Insert = "UAT_Insert";
        public const string UAT_Update = "UAT_Update";
        public const string UAT_Delete = "UAT_Delete";

        public const string Organisations_Open = "Organisations_Open";
        public const string Organisations_Insert = "Organisations_Insert";
        public const string Organisations_Update = "Organisations_Update";
        public const string Organisations_Delete = "Organisations_Delete";

        public const string Privileges_Open = "Privileges_Open";
        public const string Privileges_Insert = "Privileges_Insert";
        public const string Privileges_Delete = "Privileges_Delete";
        public const string Privileges_Update = "Privileges_Update";

        public const string Users_Open = "Users_Open";
        public const string Users_Insert = "Users_Insert";
        public const string Users_Delete = "Users_Delete";
        public const string Users_Update = "Users_Update";

        public const string OrganisationCategoriesSubCategories_Open = "OrganisationCategoriesSubCategories_Open";
        public const string OrganisationCategoriesSubCategories_Insert = "OrganisationCategoriesSubCategories_Insert";
        public const string OrganisationCategoriesSubCategories_Delete = "OrganisationCategoriesSubCategories_Delete";
        public const string OrganisationCategoriesSubCategories_Update = "OrganisationCategoriesSubCategories_Update";

        public const string Professions_Open = "Professions_Open";
        public const string Professions_Insert = "Professions_Insert";
        public const string Professions_Delete = "Professions_Delete";
        public const string Professions_Update = "Professions_Update"; 
        #endregion

        #region Level 2

        public const string MembershipDetails_DisableMemNotTypeAfterRecGen = "MembershipDetails_DisableMemNotTypeAfterRecGen";
        public const string MembershipDetails_DisableRecDetAfterRecGen = "MembershipDetails_DisableRecDetAfterRecGen";
        public const string MembershipDetails_DisableRegProgAfterRecGen = "MembershipDetails_DisableRegProgAfterRecGen";
        public const string MembershipDetails_DisableSchoolDetAfterRecGen = "MembershipDetails_DisableSchoolDetAfterRecGen";

        public const string MembershipDetails_DisableCardProIfCardGivenToMem = "MembershipDetails_DisableCardProIfCardGivenToMem";
        public const string MembershipDetails_DisableMemDateIfCardGivenToMem = "MembershipDetails_DisableMemDateIfCardGivenToMem";
        public const string MembershipDetails_DisableMemNoIfCardGivenToMem = "MembershipDetails_DisableMemNoIfCardGivenToMem";
        public const string MembershipDetails_DisableRegProgIfCardGivenToMem = "MembershipDetails_DisableRegProgIfCardGivenToMem";

        public const string MembershipDetails_DisableDeleteIfDeceased = "MembershipDetails_DisableDeleteIfDeceased";
        public const string MembershipDetails_DisableDeceasedIfDeceased = "MembershipDetails_DisableDeceasedIfDeceased";
        public const string MembershipDetails_DisableDeceasedDateIfDeceased = "MembershipDetails_DisableDeceasedDateIfDeceased";
        public const string MembershipDetails_DisableSaveIfDeceased = "MembershipDetails_DisableSaveIfDeceased";

        public const string MembershipDetails_DisableSaveIfDel = "MembershipDetails_DisableSaveIfDel";

        public const string MembershipDetails_DisableDeleteIfRej = "MembershipDetails_DisableDeleteIfRej";
        public const string MembershipDetails_DisableSaveIfRej = "MembershipDetails_DisableSaveIfRej";

        public const string MembershipDetails_DisableMemNotTypeTillRecGen = "MembershipDetails_DisableMemNotTypeTillRecGen";

        public const string MembershipDetails_DisableDelMemAfterAppRej = "MembershipDetails_DisableDelMemAfterAppRej";
        public const string MembershipDetails_DisableRecAmtAfterAppRej = "MembershipDetails_DisableRecAmtAfterAppRej";

        public const string MembershipDetails_DisableRegProgAfterApp = "MembershipDetails_DisableRegProgAfterApp";
        public const string MembershipDetails_DisableSchoolDetAfterApp = "MembershipDetails_DisableSchoolDetAfterApp";


        #endregion

        #region Level 3
        public const string MembershipDetails_MemberDetails_PersonalDetails_Surname = "MembershipDetails_MemberDetails_PersonalDetails_Surname";
        public const string MembershipDetails_MemberDetails_PersonalDetails_Initials = "MembershipDetails_MemberDetails_PersonalDetails_Initials";
        public const string MembershipDetails_MemberDetails_MembershipDate = "MembershipDetails_MemberDetails_MembershipDate";
        public const string MembershipDetails_MemberDetails_MembershipNo = "MembershipDetails_MemberDetails_MembershipNo";
        public const string MembershipDetails_MemberDetails_PersonalDetails_IDVal = "MembershipDetails_MemberDetails_PersonalDetails_IDVal";
        public const string MembershipDetails_MemberDetails_PersonalDetails_Forenames = "MembershipDetails_MemberDetails_PersonalDetails_Forenames";
        public const string MembershipDetails_ProcessingDetails_ReceiptDetails_ReceiptNo = "MembershipDetails_ProcessingDetails_ReceiptDetails_ReceiptNo";
        public const string MembershipDetails_ProcessingDetails_ReceiptDetails_ReceiptDate = "MembershipDetails_ProcessingDetails_ReceiptDetails_ReceiptDate"; 
        #endregion
        
        public static bool CheckAccess(string PrivilegeName)
        {
            if (UserPrivileges != null)
                return UserPrivileges.AsEnumerable().Where(r => r.Field<string>("privilege").Trim() == PrivilegeName.Trim() && r.Field<bool>("Allowed") == true).Count() == 1;
            else return false;
        }
    }
}
