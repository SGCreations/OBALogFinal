

using System;
using System.Collections.Generic;
namespace OBALog.Windows
{
    [System.Diagnostics.DebuggerStepThrough()]
    public static class UniversalVariables
    {

        /// <summary>
        /// Identification Types List
        /// </summary>
        private static string IDType_NIC = "NIC No.";
        private static string IDType_Passport = "Passport No.";
        private static string IDType_DL = "Driving License No.";

        public static string UnsavedData = "You have unsaved data. Do you wish to ignore them?";
        /// <summary>
        /// Payment Types List
        /// </summary>
        private static string PaymentType_Cash = "Cash";
        private static string PaymentType_Card = "Card";
        private static string PaymentType_Cheque = "Cheque";

        /// <summary>
        /// Notification Types List
        /// </summary>
        private static string NotificationType_Post = "Post";
        private static string NotificationType_Email = "Email";
        private static string NotificationType_SMS = "SMS";
        private static string NotificationType_Call = "Call";
        /// <summary>
        /// Schools List
        /// </summary>
        /// S. Thomas' College, Mount Lavinia
        public static string School_STCMount = "STC Mt. Lavinia";
        private static string School_Colpetty = "STC Colpetty";
        private static string School_Guruthalawa = "STC Guruthalawa";
        private static string School_Bandarawela = "STC Bandarawela";

        /// <summary>
        /// Approval Stages List
        /// </summary>
        public const string AppStage_OBA = "OBA Secretariat";
        public const string AppStage_ColOffice = "College Office";
        public const string AppStage_Approved = "Approved";
        public const string AppStage_Rejected = "Rejected";

        public static string MySQLDateFormat = "yyyy-MM-dd";


        public static int UserKey { get; set; }

        public static string Name { get; set; }

        public static string AccessTypeName { get; set; }

        public static int UserAccessTypeKey { get; set; }
        public static string Username { get; set; }

        public static List<string> IdentificationTypes = new List<string> { IDType_NIC, IDType_Passport, IDType_DL };
        public static List<string> PaymentTypes = new List<string> { PaymentType_Cash, PaymentType_Card, PaymentType_Cheque };
        public static List<string> NotificationTypes = new List<string> { NotificationType_Post, NotificationType_Email, NotificationType_SMS, NotificationType_Call };
        public static List<string> Schools = new List<string> { string.Empty, School_Colpetty, School_Guruthalawa, School_Bandarawela };
        public static List<string> ApprovalStages = new List<string> { AppStage_OBA, AppStage_ColOffice, AppStage_Approved, AppStage_Rejected };
    }
}
