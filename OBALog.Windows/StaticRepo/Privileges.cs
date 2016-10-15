using System.Data;
using System.Linq;

namespace OBALog.Windows
{
    [System.Diagnostics.DebuggerStepThrough()]
    public static class Privileges
    {
        public static DataTable UserPrivileges { get; set; }

        #region Level 1

        public const string MemberDetails_Open = "MemberDetails_Open";
        public const string MemberDetails_Insert = "MemberDetails_Insert";
        public const string MemberDetails_Delete = "MemberDetails_Delete";
        public const string MemberDetails_Update = "MemberDetails_Update";

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

        public const string MemberDetails_DisableMemNotTypeAfterRecGen = "MemberDetails_DisableMemNotTypeAfterRecGen";
        public const string MemberDetails_DisableRecDetAfterRecGen = "MemberDetails_DisableRecDetAfterRecGen";
        public const string MemberDetails_DisableRegProgAfterRecGen = "MemberDetails_DisableRegProgAfterRecGen";
        public const string MemberDetails_DisableSchoolDetAfterRecGen = "MemberDetails_DisableSchoolDetAfterRecGen";

        public const string MemberDetails_DisableCardProIfCardGivenToMem = "MemberDetails_DisableCardProIfCardGivenToMem";
        public const string MemberDetails_DisableMemDateIfCardGivenToMem = "MemberDetails_DisableMemDateIfCardGivenToMem";
        public const string MemberDetails_DisableMemNoIfCardGivenToMem = "MemberDetails_DisableMemNoIfCardGivenToMem";
        public const string MemberDetails_DisableRegProgIfCardGivenToMem = "MemberDetails_DisableRegProgIfCardGivenToMem";

        public const string MemberDetails_DisableDeleteIfDeceased = "MemberDetails_DisableDeleteIfDeceased";
        public const string MemberDetails_DisableDeceasedIfDeceased = "MemberDetails_DisableDeceasedIfDeceased";
        public const string MemberDetails_DisableDeceasedDateIfDeceased = "MemberDetails_DisableDeceasedDateIfDeceased";
        public const string MemberDetails_DisableSaveIfDeceased = "MemberDetails_DisableSaveIfDeceased";

        public const string MemberDetails_DisableSaveIfDel = "MemberDetails_DisableSaveIfDel";

        public const string MemberDetails_DisableDeleteIfRej = "MemberDetails_DisableDeleteIfRej";
        public const string MemberDetails_DisableSaveIfRej = "MemberDetails_DisableSaveIfRej";

        public const string MemberDetails_DisableMemNotTypeTillRecGen = "MemberDetails_DisableMemNotTypeTillRecGen";

        public const string MemberDetails_DisableDelMemAfterAppRej = "MemberDetails_DisableDelMemAfterAppRej";
        public const string MemberDetails_DisableRegProgAfterAppRej = "MemberDetails_DisableRegProgAfterAppRej";
        public const string MemberDetails_DisableRecAmtAfterAppRej = "MemberDetails_DisableRecAmtAfterAppRej";

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
