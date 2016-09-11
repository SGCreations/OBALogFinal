using System;

namespace OBALog.Model
{
    public class ML_ProfessionalDetails
    {
        public string Designation { get; set; }
        public string Email { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int? Key { get; set; }
        public int OrganisationKey { get; set; }
        //public ML_Organisation Organisation { get; set; }
        public int MemberKey { get; set; }
        //public ML_Member Member { get; set; }
        public int UserKey { get; set; }
        public bool Active { get; set; }
    }
}
