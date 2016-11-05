using System;
using System.Data;
using System.Linq;

namespace OBALog.Windows
{
    public static class Configurations
    {
        public static DataTable ConfigurationTable { get; set; }

        public const string InternetConnectionStr = "InternetConnectionForMembership";
        public const string MembershipNoIndexStr = "MembershipNoIndex";
        public const string ReceiptAmountStr = "ReceiptAmount";
        public const string ReceiptNoStr = "ReceiptNo";
        public const string TimeoutPeriodStr = "TimeoutPeriod";
        public const string LogoffPeriodStr = "LogoffPeriod";
        public const string MembershipDateStr = "MembershipDate";
        public const string DefaultSalutationStr = "DefaultSalutationIndex";
        public const string DefaultCountryStr = "DefaultCountryIndex";
        public const string DefaultCityStr = "DefaultCityIndex";

        public const string TelephoneValidationStr = "TelephoneValidation";
        public const string MobileValidationStr = "MobileValidation";
        public const string EmailValidationStr = "EmailValidation";

        public static bool InternetConnection { get { return GetConfigurationValue(InternetConnectionStr).ToBool(); } }
        public static int[] ReceiptAmount { get {
            return GetConfigurationValue(ReceiptAmountStr).Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray(); 
        } }
        public static string LastReceiptNo { get { return GetConfigurationValue(ReceiptNoStr); } }
        public static TimeSpan TimeoutPeriod { get { return GetConfigurationValue(TimeoutPeriodStr).ToTimeSpan(); } }
        public static TimeSpan LogoffPeriod { get { return GetConfigurationValue(LogoffPeriodStr).ToTimeSpan(); } }
        public static DateTime LastMembershipDate { get { return GetConfigurationValue(MembershipDateStr).ToDateTime(); } }
        public static int DefaultSalutation { get { return GetConfigurationValue(DefaultSalutationStr).ToInt(); } }
        public static int DefaultCountry { get { return GetConfigurationValue(DefaultCountryStr).ToInt(); } }
        public static int DefaultCity { get { return GetConfigurationValue(DefaultCityStr).ToInt(); } }

        public static bool MobileValidation { get { return GetConfigurationValue(MobileValidationStr).ToBool(); } }
        public static bool TelephoneValidation { get { return GetConfigurationValue(TelephoneValidationStr).ToBool(); } }
        public static bool EmailValidation { get { return GetConfigurationValue(EmailValidationStr).ToBool(); } }

        internal static string GetConfigurationValue(string Key)
        {
            return (from myRow in ConfigurationTable.AsEnumerable() where myRow.Field<string>("ConfigurationName") == Key select myRow).FirstOrDefault()["ConfigurationValue"].ToString();
        }
    }
}
