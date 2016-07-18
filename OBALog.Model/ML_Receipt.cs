using System;

namespace OBALog.Model
{
    public class ML_Receipt
    {
        public string ReceiptNo { get; set; }
        public string PaymentType { get; set; }
        public string CardChequeNo { get; set; }
        public string Bank { get; set; }
        public DateTime ReceiptDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int Key { get; set; }
        public int PrintCount { get; set; }
        public int UserKey { get; set; }
        public double ReceiptAmount { get; set; }
    }
}
