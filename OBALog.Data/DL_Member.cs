using MySql.Data.MySqlClient;
using OBALog.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBALog.Data
{
    public class DL_Member
    {
        public int insert(ML_Member member)
        {
            List<MySqlParameter> paraList = getParameterList(ref member);
            MySqlParameter[] para = new MySqlParameter[paraList.Count];
            para = paraList.ToArray();

            return (int)MySQLHelper.ExecuteScalar(DBConnection.connectionString, CommandType.Text, "INSERT INTO stc_oba.member (`Key` , MembershipNo , MembershipDate , OldMembershipNos , SalutationKey , Surname , Initials , Forenames , DOB , IdentificationType , IdentificationNo , YearJoined , YearLeft , AddressKey , Mobile , Email , MailReturned , EmailReturned , OLYear , ALYear , ClassGroup , ReceiptKey , Rejected , RejectedReason , RefundChqNo , RefundCheqDate , ApprovalStage , DateSentToOffice , DateApproved , DateRejected , DateCardSentToPrinter , DateCardReceivedFromPrinter , DateMemberNotified , DateCardGivenToMember , MembershipNotificationType , Picture , Archive , Deceased , DeceasedDate , Remarks , ProfessionKey , Outdated , UserKey , UpdatedDate , Deleted) VALUES (NULL, @MembershipNo, @MembershipDate, @OldMembershipNos, @SalutationKey, @Surname, @Initials, @Forenames, @DOB, @IdentificationType, @IdentificationNo, @YearJoined, @YearLeft, @AddressKey, @Mobile, @Email, @MailReturned, @EmailReturned, @OLYear, @ALYear, @ClassGroup, @ReceiptKey, @Rejected, @RejectedReason, @RefundChqNo, @RefundCheqDate, @ApprovalStage, @DateSentToOffice, @DateApproved, @DateRejected, @DateCardSentToPrinter, @DateCardReceivedFromPrinter, @DateMemberNotified, @DateCardGivenToMember, @MembershipNotificationType, @Picture, @Archive, @Deceased, @DeceasedDate, @Remarks, @ProfessionKey, @Outdated, @UserKey, @UpdatedDate, @Deleted); SELECT LAST_INSERT_ID();", para);
        }

        public bool updateMemberImage(ML_Member member)
        {
            MySqlParameter[] para = new MySqlParameter[2];
            para[0] = new MySqlParameter("@Picture", member.Picture);
            para[1] = new MySqlParameter("@Key", member.Key);

            MySQLHelper.ExecuteNonQuery(DBConnection.connectionString, CommandType.Text, "UPDATE `member` SET `Picture` = @Picture WHERE `Key`= @Key;", para);

            return true;
        }

        public bool update(ML_Member member)
        {
            try
            {
                List<MySqlParameter> paraList = getParameterList(ref member);
                paraList.Add(new MySqlParameter("@Key", member.Key));
                MySqlParameter[] para = new MySqlParameter[paraList.Count];
                para = paraList.ToArray();
                MySQLHelper.ExecuteNonQuery(DBConnection.connectionString, CommandType.Text, "UPDATE `member` SET `MembershipNo` = @MembershipNo, `MembershipDate` = @MembershipDate, `OldMembershipNos` = @OldMembershipNos, `SalutationKey` = @SalutationKey, `Surname` = @Surname, `Initials` = @Initials, `Forenames` = @Forenames, `DOB` = @DOB, `IdentificationType` = @IdentificationType, `IdentificationNo` = @IdentificationNo, `YearJoined` = @YearJoined, `YearLeft` = @YearLeft, `AddressKey` = @AddressKey, `Mobile` = @Mobile, `Email` = @Email, `MailReturned` = @MailReturned, `EmailReturned` = @EmailReturned, `OLYear` = @OLYear, `ALYear` = @ALYear, `ClassGroup` = @ClassGroup, `ReceiptKey` = @ReceiptKey, `Rejected` = @Rejected, `RejectedReason` = @RejectedReason, `RefundChqNo` = @RefundChqNo, `RefundCheqDate` = @RefundCheqDate, `ApprovalStage` = @ApprovalStage, `DateSentToOffice` = @DateSentToOffice, `DateApproved` = @DateApproved, `DateRejected` = @DateRejected, `DateCardSentToPrinter` = @DateCardSentToPrinter, `DateCardReceivedFromPrinter` = @DateCardReceivedFromPrinter, `DateMemberNotified` = @DateMemberNotified, `DateCardGivenToMember` = @DateCardGivenToMember, `MembershipNotificationType` = @MembershipNotificationType, `Picture` = @Picture, `Archive` = @Archive, `Deceased` = @Deceased, `DeceasedDate` = @DeceasedDate, `Remarks` = @Remarks, `ProfessionKey` = @ProfessionKey, `Outdated` = @Outdated, `UserKey` = @UserKey, `UpdatedDate` = @UpdatedDate, `Deleted` = @Deleted WHERE `Key`= @Key;", para);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public DataTable selectMemberTop20()
        {
            return MySQLHelper.ExecuteDataTable(DBConnection.connectionString, CommandType.Text, "SELECT M.KEY ,MembershipNo, Initials, Forenames, Surname FROM member M WHERE `Deleted` = 0 ORDER BY M.KEY ASC LIMIT 20;");
        }

        public DataSet select(int? MemberKey)
        {
            MySqlParameter[] para = new MySqlParameter[1];
            para[0] = new MySqlParameter("@MemberKey", MemberKey);
            return MySQLHelper.ExecuteDataSet(DBConnection.connectionString, CommandType.Text, "SELECT * FROM vw_allmemberdata WHERE `KEY` = @MemberKey; SELECT * FROM admission a WHERE a.MemberKey = @MemberKey AND a.School != 'STC Mt. Lavinia'; SELECT * FROM professionaldetails WHERE MemberKey = @MemberKey; SELECT rh.`KEY`, rh.MemberKey, rh.UserKey, u.`Name` As User, rh.Remarks, rh.UpdatedDate FROM remarkshistory rh LEFT JOIN USER u ON rh.UserKey = u.`KEY` WHERE MemberKey = @MemberKey; SELECT Picture FROM member WHERE `Key` = @MemberKey AND Picture IS NOT NULL;", para);
        }

        public DataTable selectMemberLastUpdatedTop20()
        {
            return MySQLHelper.ExecuteDataTable(DBConnection.connectionString, CommandType.Text, "SELECT M.KEY, MembershipNo, Initials, Forenames, Surname FROM member M WHERE `Deleted` = 0 ORDER BY UpdatedDate DESC LIMIT 20");
        }

        #region Advanced



        public DataTable selectMemberAdvancedMembership()
        {
            return MySQLHelper.ExecuteDataTable(DBConnection.connectionString, CommandType.Text, "SELECT M.KEY, MembershipNo, Initials, Forenames, Surname FROM member M ORDER BY UpdatedDate DESC LIMIT 20");
        }

        public DataTable selectMemberAdvancedSchool()
        {
            return MySQLHelper.ExecuteDataTable(DBConnection.connectionString, CommandType.Text, "SELECT M.KEY, MembershipNo, Initials, Forenames, Surname FROM member M ORDER BY UpdatedDate DESC LIMIT 20");
        }

        public DataTable selectMemberAdvancedProfessional()
        {
            return MySQLHelper.ExecuteDataTable(DBConnection.connectionString, CommandType.Text, "SELECT M.KEY, MembershipNo, Initials, Forenames, Surname FROM member M ORDER BY UpdatedDate DESC LIMIT 20");
        }
        #endregion

        public bool delete(ML_Member member)
        {
            MySqlParameter[] para = new MySqlParameter[1];
            para[0] = new MySqlParameter("@Key", member.Key);

            MySQLHelper.ExecuteNonQuery(DBConnection.connectionString, CommandType.Text, "UPDATE `member` SET `Deleted` = 1 WHERE `Key`= @Key;", para);
            return true;
        }

        public List<MySqlParameter> getParameterList(ref ML_Member member)
        {
            List<MySqlParameter> paraList = new List<MySqlParameter> { };
            paraList.Add(new MySqlParameter("@MembershipNo", member.MembershipNo));
            paraList.Add(new MySqlParameter("@MembershipDate", member.MembershipDate));
            paraList.Add(new MySqlParameter("@OldMembershipNos", member.OldMembershipNos));
            paraList.Add(new MySqlParameter("@SalutationKey", member.SalutationKey));
            paraList.Add(new MySqlParameter("@Surname", member.Surname));
            paraList.Add(new MySqlParameter("@Initials", member.Initials));
            paraList.Add(new MySqlParameter("@Forenames", member.Forenames));
            paraList.Add(new MySqlParameter("@DOB", member.DOB));
            paraList.Add(new MySqlParameter("@IdentificationType", member.IdentificationType));
            paraList.Add(new MySqlParameter("@IdentificationNo", member.IdentificationNo));
            paraList.Add(new MySqlParameter("@YearJoined", member.YearJoined));
            paraList.Add(new MySqlParameter("@YearLeft", member.YearLeft));
            paraList.Add(new MySqlParameter("@AddressKey", member.AddressKey));
            paraList.Add(new MySqlParameter("@Mobile", member.Mobile));
            paraList.Add(new MySqlParameter("@Email", member.Email));
            paraList.Add(new MySqlParameter("@MailReturned", member.MailReturned));
            paraList.Add(new MySqlParameter("@EmailReturned", member.EmailReturned));
            paraList.Add(new MySqlParameter("@OLYear", member.OLYear));
            paraList.Add(new MySqlParameter("@ALYear", member.ALYear));
            paraList.Add(new MySqlParameter("@ClassGroup", member.ClassGroup));
            paraList.Add(new MySqlParameter("@ReceiptKey", member.ReceiptKey));
            paraList.Add(new MySqlParameter("@Rejected", member.Rejected));
            paraList.Add(new MySqlParameter("@RejectedReason", member.RejectedReason));
            paraList.Add(new MySqlParameter("@RefundChqNo", member.RefundChqNo));
            paraList.Add(new MySqlParameter("@RefundCheqDate", member.RefundCheqDate));
            paraList.Add(new MySqlParameter("@ApprovalStage", member.ApprovalStage));
            paraList.Add(new MySqlParameter("@DateSentToOffice", member.DateSentToOffice));
            paraList.Add(new MySqlParameter("@DateApproved", member.DateApproved));
            paraList.Add(new MySqlParameter("@DateRejected", member.DateRejected));
            paraList.Add(new MySqlParameter("@DateCardSentToPrinter", member.DateCardSentToPrinter));
            paraList.Add(new MySqlParameter("@DateCardReceivedFromPrinter", member.DateCardReceivedFromPrinter));
            paraList.Add(new MySqlParameter("@DateMemberNotified", member.DateMemberNotified));
            paraList.Add(new MySqlParameter("@DateCardGivenToMember", member.DateCardGivenToMember));
            paraList.Add(new MySqlParameter("@MembershipNotificationType", member.MembershipNotificationType));
            paraList.Add(new MySqlParameter("@Picture", member.Picture));
            paraList.Add(new MySqlParameter("@Archive", member.Archive));
            paraList.Add(new MySqlParameter("@Deceased", member.Deceased));
            paraList.Add(new MySqlParameter("@DeceasedDate", member.DeceasedDate));
            paraList.Add(new MySqlParameter("@Remarks", member.Remarks));
            paraList.Add(new MySqlParameter("@ProfessionKey", member.ProfessionKey));
            paraList.Add(new MySqlParameter("@Outdated", member.Outdated));
            paraList.Add(new MySqlParameter("@UserKey", member.UserKey));
            paraList.Add(new MySqlParameter("@UpdatedDate", member.UpdatedDate));
            paraList.Add(new MySqlParameter("@Deleted", member.Deleted));
            return paraList;
        }

        public DataTable selectMemberAdvancedPersonal(ML_Member member, int? CountryKey, int? CityKey, string DOBSD, string DOBED, string Telephone, bool? Deleted)
        {
            MySqlParameter[] para = new MySqlParameter[15];
            para[0] = new MySqlParameter("@Initials", member.Initials);
            para[1] = new MySqlParameter("@Surname", member.Surname);
            para[2] = new MySqlParameter("@Forenames", member.Forenames);
            para[3] = new MySqlParameter("@CountryKey", CountryKey);
            para[4] = new MySqlParameter("@CityKey", CityKey);
            para[5] = new MySqlParameter("@Telephone", Telephone);
            para[6] = new MySqlParameter("@Deceased", member.Deceased);
            para[7] = new MySqlParameter("@EmailReturned", member.EmailReturned);
            para[8] = new MySqlParameter("@MailReturned", member.MailReturned);
            para[9] = new MySqlParameter("@Mobile", member.Mobile);
            para[10] = new MySqlParameter("@IdentificationNo", member.IdentificationNo);
            para[11] = new MySqlParameter("@MembershipNo", member.MembershipNo);
            para[12] = new MySqlParameter("@DOBSD", DOBSD);
            para[13] = new MySqlParameter("@DOBED", DOBED);
            para[14] = new MySqlParameter("@Deleted", Deleted);

            return MySQLHelper.ExecuteDataTable(DBConnection.connectionString, CommandType.Text, "SELECT `KEY`, MembershipNo, Initials, Surname, Forenames, country FROM vw_allmemberdata WHERE (Initials LIKE @Initials OR @Initials IS NULL) AND (Surname LIKE @Surname OR @Surname IS NULL) AND (Forenames LIKE @Forenames OR @Forenames IS NULL) AND (CountryKey LIKE @CountryKey OR @CountryKey IS NULL) AND (CityKey LIKE @CityKey OR @CityKey IS NULL) AND (Telephone LIKE @Telephone OR @Telephone IS NULL) AND (Deceased = @Deceased OR @Deceased IS NULL) AND (EmailReturned = @EmailReturned OR @EmailReturned IS NULL) AND (MailReturned = @MailReturned OR @MailReturned IS NULL) AND (Mobile LIKE @Mobile OR @Mobile IS NULL) AND (IdentificationNo LIKE @IdentificationNo OR @IdentificationNo IS NULL) AND (CONVERT(DOB, date) >= CONVERT(@DOBSD, date) OR @DOBSD IS NULL) AND (CONVERT(DOB, date) <= CONVERT(@DOBED, date) OR @DOBED IS NULL) AND (MembershipNo LIKE @MembershipNo OR @MembershipNo IS NULL) AND (Deleted = @Deleted OR @Deleted IS NULL);", para);
        }

        public DataTable selectMemberAdvancedMembership(ML_Member member, string DateFrom, string DateTo, bool? Deleted)
        {
            MySqlParameter[] para = new MySqlParameter[5];
            para[0] = new MySqlParameter("@MembershipNo", member.MembershipNo);
            para[1] = new MySqlParameter("@OldMembershipNos", member.OldMembershipNos);
            para[2] = new MySqlParameter("@MDSD", DateFrom);
            para[3] = new MySqlParameter("@MDED", DateTo);
            para[4] = new MySqlParameter("@Deleted", Deleted);

            return MySQLHelper.ExecuteDataTable(DBConnection.connectionString, CommandType.Text, "SELECT `Key`, MembershipNo, Initials, Surname, Forenames, country FROM vw_allmemberdata WHERE (MembershipNo LIKE @MembershipNo OR @MembershipNo IS NULL) AND (OldMembershipNos LIKE @OldMembershipNos OR @OldMembershipNos IS NULL) AND (CONVERT(MembershipDate, date) >= CONVERT(@MDSD, date) OR @MDSD IS NULL) AND (CONVERT(MembershipDate, date) <= CONVERT(@MDED, date) OR @MDED IS NULL) AND (Deleted = @Deleted OR @Deleted IS NULL)", para);
        }

        public DataTable selectMemberAdvancedSchool(string AdmissionNo, int? FROLYear, int? TOOLYear, int? FRALYear, int? TOALYear, int? FRYearJoined, int? TOYearJoined, int? FRYearLeft, int? TOYearLeft, int? FRClassGroup, int? TOClassGroup, bool? Deleted)
        {
            MySqlParameter[] para = new MySqlParameter[12];
            para[0] = new MySqlParameter("@AdmissionNo", AdmissionNo);

            para[1] = new MySqlParameter("@FROLYear", FROLYear);
            para[2] = new MySqlParameter("@TOOLYear", TOOLYear);

            para[3] = new MySqlParameter("@FRALYear", FRALYear);
            para[4] = new MySqlParameter("@TOALYear", TOALYear);

            para[5] = new MySqlParameter("@FRYearJoined", FRYearJoined);
            para[6] = new MySqlParameter("@TOYearJoined", TOYearJoined);

            para[7] = new MySqlParameter("@FRYearLeft", FRYearLeft);
            para[8] = new MySqlParameter("@TOYearLeft", TOYearLeft);

            para[9] = new MySqlParameter("@FRClassGroup", FRClassGroup);
            para[10] = new MySqlParameter("@TOClassGroup", TOClassGroup);
            para[11] = new MySqlParameter("@Deleted", Deleted);

            return MySQLHelper.ExecuteDataTable(DBConnection.connectionString, CommandType.Text, "SELECT `Key`, MembershipNo, Initials, Surname, Forenames, country FROM vw_allmemberdata WHERE (AdmissionNo LIKE @AdmissionNo OR @AdmissionNo IS NULL) AND (OLYear >= @FROLYear OR @FROLYear IS NULL) AND (OLYear <= @TOOLYear OR @TOOLYear IS NULL) AND (ALYear >= @FRALYear OR @FRALYear IS NULL) AND (ALYear <= @TOALYear OR @TOALYear IS NULL) AND (YearJoined >= @FRYearJoined OR @FRYearJoined IS NULL) AND (YearJoined <= @TOYearJoined OR @TOYearJoined IS NULL) AND (YearLeft >= @FRYearLeft OR @FRYearLeft IS NULL) AND (YearLeft <= @TOYearLeft OR @TOYearLeft IS NULL) AND (ClassGroup >= @FRClassGroup OR @FRClassGroup IS NULL) AND (ClassGroup <= @TOClassGroup OR @TOClassGroup IS NULL)  AND (Deleted = @Deleted OR @Deleted IS NULL);", para);
        }

        public DataTable selectMemberAdvancedProcessing(string ReceiptNo, string FRReceiptDate, string TOReceiptDate, string ApprovalStage, bool? Deleted)
        {
            MySqlParameter[] para = new MySqlParameter[5];
            para[0] = new MySqlParameter("@ReceiptNo", ReceiptNo);
            para[1] = new MySqlParameter("@FRReceiptDate", FRReceiptDate);
            para[2] = new MySqlParameter("@TOReceiptDate", TOReceiptDate);
            para[3] = new MySqlParameter("@ApprovalStage", ApprovalStage);
            para[4] = new MySqlParameter("@Deleted", Deleted);

            return MySQLHelper.ExecuteDataTable(DBConnection.connectionString, CommandType.Text, "SELECT `Key`, MembershipNo, Initials, Surname, Forenames, country FROM vw_allmemberdata WHERE (ReceiptNo LIKE @ReceiptNo OR @ReceiptNo IS NULL) AND (CONVERT(ReceiptDate, date) >= CONVERT(@FRReceiptDate, date) OR @FRReceiptDate IS NULL) AND (CONVERT(ReceiptDate, date) <= CONVERT(@TOReceiptDate, date) OR @TOReceiptDate IS NULL) AND (ApprovalStage LIKE @ApprovalStage OR @ApprovalStage IS NULL) AND (Deleted = @Deleted OR @Deleted IS NULL);", para);
        }
        public DataTable selectMemberAdvancedProfessional(int? ProfessionKey, int? CategoryKey, int? SubCategoryKey, int? OrganisationKey, bool? Deleted)
        {
            MySqlParameter[] para = new MySqlParameter[5];
            para[0] = new MySqlParameter("@ProfessionKey", ProfessionKey);
            para[1] = new MySqlParameter("@CategoryKey", CategoryKey);
            para[2] = new MySqlParameter("@SubCategoryKey", SubCategoryKey);
            para[3] = new MySqlParameter("@OrganisationKey", OrganisationKey);
            para[4] = new MySqlParameter("@Deleted", Deleted);

            return MySQLHelper.ExecuteDataTable(DBConnection.connectionString, CommandType.Text, "SELECT `KEY`, MembershipNo, Initials, Surname, Forenames FROM vw_allmemberdata WHERE (ProfessionKey LIKE @ProfessionKey OR @ProfessionKey IS NULL) AND (CategoryKey LIKE @CategoryKey OR @CategoryKey IS NULL) AND (SubCategoryKey LIKE @SubCategoryKey OR @SubCategoryKey IS NULL) AND (OrganisationKey LIKE @OrganisationKey OR @OrganisationKey IS NULL) AND (Deleted = @Deleted OR @Deleted IS NULL);", para);
        }
    }
}
