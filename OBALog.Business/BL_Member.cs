/*I*n*v*i*n*c*b*l*e----*S*t*u*d*i*o*s*/
//© 2016 - Sidath Gajanayaka
//sinhalokaya@gmail.com
/*All Rights Reserved*/

using OBALog.Data;
using OBALog.Model;

namespace OBALog.Business
{
    public class BL_Member
    {
        public int insert(ML_Member member)
        {
            return new DL_Member().insert(member);
        }
        public bool updateMemberImage(ML_Member member)
        {
            return new DL_Member().updateMemberImage(member);
        }

        public System.Data.DataTable selectMemberTop20()
        {
            return new DL_Member().selectMemberTop20();
        }

        public System.Data.DataSet select(int MemberKey)
        {
            return new DL_Member().select(MemberKey);
        }

        public System.Data.DataTable selectMemberLastUpdatedTop20()
        {
            return new DL_Member().selectMemberLastUpdatedTop20();
        }

        public bool delete(ML_Member member)
        {
            return new DL_Member().delete(member);
        }

        public System.Data.DataTable selectMemberAdvancedPersonal(ML_Member member, int? CountryKey, int? CityKey, string DOBSD, string DOBED, string Telephone, bool? Deleted)
        {
            return new DL_Member().selectMemberAdvancedPersonal(member, CountryKey, CityKey, DOBSD, DOBED, Telephone, Deleted);
        }

        public System.Data.DataTable selectMemberAdvancedMembership(ML_Member member, string DateFrom, string DateTo, bool? Deleted, bool includeDuplicates)
        {
            return new DL_Member().selectMemberAdvancedMembership(member, DateFrom, DateTo, Deleted, includeDuplicates);
        }
        public System.Data.DataTable selectMemberAdvancedSchool(string AdmissionNo, int? FROLYear, int? TOOLYear, int? FRALYear, int? TOALYear, int? FRYearJoined, int? TOYearJoined, int? FRYearLeft, int? TOYearLeft, int? FRClassGroup, int? TOClassGroup, bool? Deleted)
        {
            return new DL_Member().selectMemberAdvancedSchool(AdmissionNo, FROLYear, TOOLYear, FRALYear, TOALYear, FRYearJoined, TOYearJoined, FRYearLeft, TOYearLeft, FRClassGroup, TOClassGroup, Deleted);

        }
        public System.Data.DataTable selectMemberAdvancedProcessing(string ReceiptNo, string FRReceiptDate, string TOReceiptDate, string ApprovalStage, bool? Deleted)
        {
            return new DL_Member().selectMemberAdvancedProcessing(ReceiptNo, FRReceiptDate, TOReceiptDate, ApprovalStage, Deleted);
        }

        public System.Data.DataTable selectMemberAdvancedProfessional(int? ProfessionKey, int? CategoryKey, int? SubCategoryKey, int? OrganisationKey, bool? Deleted)
        {
            return new DL_Member().selectMemberAdvancedProfessional(ProfessionKey, CategoryKey, SubCategoryKey, OrganisationKey, Deleted);
        }
    }
}
