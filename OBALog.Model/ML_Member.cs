using System;

namespace OBALog.Model
{
    public class ML_Member
    {
        public int Key { get; set; }
        public string MembershipNo { get; set; }
        public string OldMembershipNos { get; set; }
        public string Surname { get; set; }
        public string Initials { get; set; }
        public string Forenames { get; set; }
        public string IdentificationType { get; set; }
        public string IdentificationNo { get; set; }
        public string YearJoined { get; set; }
        public string YearLeft { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string OLYear { get; set; }
        public string ALYear { get; set; }
        public string ClassGroup { get; set; }
        public string RejectedReason { get; set; }
        public string RefundChqNo { get; set; }
        public string ApprovalStage { get; set; }
        public string MembershipNotificationType { get; set; }
        public string Remarks { get; set; }
        public string MembershipDate { get; set; }
        public string DOB { get; set; }
        public string RefundCheqDate { get; set; }
        public string DateSentToOffice { get; set; }
        public string DateApproved { get; set; }
        public string DateRejected { get; set; }
        public string DateCardSentToPrinter { get; set; }
        public string DateCardReceivedFromPrinter { get; set; }
        public string DateMemberNotified { get; set; }
        public string DateCardGivenToMember { get; set; }
        public byte[] Picture { get; set; }
        public byte[] Archive { get; set; }
        public bool? Deceased { get; set; }
        public string DeceasedDate { get; set; }
        public int? ProfessionKey { get; set; }
        public bool Outdated { get; set; }
        public int UserKey { get; set; }
        public string UpdatedDate { get; set; }
        public bool Deleted { get; set; }
        public bool Rejected { get; set; }
        public int ReceiptKey { get; set; }
        public bool? EmailReturned { get; set; }
        public bool? MailReturned { get; set; }
        public int AddressKey { get; set; }
        public int SalutationKey { get; set; }
    }
}
