using System;

namespace OBALog.Model
{
    public class ML_ViewMember
    {
        public int KEY { get; set; }
        public string MembershipNo { get; set; }
        public string OldMembershipNos { get; set; }
        public string salutation { get; set; }
        public string Surname { get; set; }
        public string Initials { get; set; }
        public string Forenames { get; set; }
        public string IdentificationType { get; set; }
        public string IdentificationNo { get; set; }
        public string YearJoined { get; set; }
        public string YearLeft { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string Telephone { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string OLYear { get; set; }
        public string ALYear { get; set; }
        public string ClassGroup { get; set; }
        public string ReceiptNo { get; set; }
        public string PaymentType { get; set; }
        public string CardChequeNo { get; set; }
        public string Bank { get; set; }
        public string RejectedReason { get; set; }
        public string RefundChqNo { get; set; }
        public string ApprovalStage { get; set; }
        public string MembershipNotificationType { get; set; }
        public string Remarks { get; set; }
        public string profession { get; set; }
        public string organisation { get; set; }
        public string SubCategory { get; set; }
        public string Category { get; set; }
        public string School { get; set; }
        public string AdmissionNo { get; set; }
        public string AdmissionKey { get; set; }
        public string MembershipDate { get; set; }
        public string DOB { get; set; }
        public string ReceiptDate { get; set; }
        public string RefundCheqDate { get; set; }
        public string DateSentToOffice { get; set; }
        public string DateApproved { get; set; }
        public string DateRejected { get; set; }
        public string DateCardSentToPrinter { get; set; }
        public string DateCardReceivedFromPrinter { get; set; }
        public string DateMemberNotified { get; set; }
        public string DateCardGivenToMember { get; set; }
        public string DeceasedDate { get; set; }
        public string SalutationKey { get; set; }
        public string AddressKey { get; set; }
        public string CityKey { get; set; }
        public string CountryKey { get; set; }
        public string ReceiptKey { get; set; }
        public string PrintCount { get; set; }
        public string ProfessionKey { get; set; }
        public string OrganisationKey { get; set; }
        public string SubCategoryKey { get; set; }
        public string CategoryKey { get; set; }
        public string ReceiptAmount { get; set; }
        public bool MailReturned { get; set; }
        public bool EmailReturned { get; set; }
        public bool Rejected { get; set; }
        public bool Deceased { get; set; }
        public bool Outdated { get; set; }
        public bool Deleted { get; set; }

        public string FullName
        {
            get { return string.Format("{0} {1}", Initials, Surname); }
        }
        public string DateOfBirth
        {
            get { return string.IsNullOrEmpty(DOB) ? null : Convert.ToDateTime(DOB).ToShortDateString(); }
        }
        public string ShortReceiptDate
        {
            get { return string.IsNullOrEmpty(ReceiptDate) ? null : Convert.ToDateTime(ReceiptDate).ToShortDateString(); }
        }

        public string ReceiptAmountText
        {
            get { return CurrencyToTextConverter.Convert(Convert.ToDouble(ReceiptAmount)); }
        }

        public string ReceiptAmountInt
        {
            get { return Convert.ToInt32(Convert.ToDouble(ReceiptAmount)).ToString(); }
        }
        public string FullAddress
        {
            get { return string.Format("{0}, {1}, {2}", address, city, country); }
        }

    }
}
