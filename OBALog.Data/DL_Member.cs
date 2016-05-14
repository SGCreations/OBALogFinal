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
            var a = MySQLHelper.ExecuteScalar(DBConnection.connectionString, CommandType.Text, "INSERT INTO stc_oba.member (`Key` , MembershipNo , MembershipDate , OldMembershipNos , SalutationKey , Surname , Initials , Forenames , DOB , IdentificationType , IdentificationNo , YearJoined , YearLeft , AddressKey , Mobile , Email , MailReturned , EmailReturned , OLYear , ALYear , ClassGroup , ReceiptKey , Rejected , RejectedReason , RefundChqNo , RefundCheqDate , ApprovalStage , DateSentToOffice , DateApproved , DateRejected , DateCardSentToPrinter , DateCardReceivedFromPrinter , DateMemberNotified , DateCardGivenToMember , MembershipNotificationType , Picture , Archive , Deceased , DeceasedDate , Remarks , ProfessionKey , Outdated , UserKey , UpdatedDate , Deleted) VALUES (NULL, @MembershipNo, @MembershipDate, @OldMembershipNos, @SalutationKey, @Surname, @Initials, @Forenames, @DOB, @IdentificationType, @IdentificationNo, @YearJoined, @YearLeft, @AddressKey, @Mobile, @Email, @MailReturned, @EmailReturned, @OLYear, @ALYear, @ClassGroup, @ReceiptKey, @Rejected, @RejectedReason, @RefundChqNo, @RefundCheqDate, @ApprovalStage, @DateSentToOffice, @DateApproved, @DateRejected, @DateCardSentToPrinter, @DateCardReceivedFromPrinter, @DateMemberNotified, @DateCardGivenToMember, @MembershipNotificationType, @Picture, @Archive, @Deceased, @DeceasedDate, @Remarks, @ProfessionKey, @Outdated, @UserKey, @UpdatedDate, @Deleted); SELECT LAST_INSERT_ID();", para);
            return (int)a;
        }

        public bool update(ML_Member member)
        {
            try
            {
                List<MySqlParameter> paraList = getParameterList(ref member);
                paraList.Add(new MySqlParameter("@Key", member.Key));
                MySqlParameter[] para = new MySqlParameter[paraList.Count];
                para = paraList.ToArray();
                var a = MySQLHelper.ExecuteNonQuery(DBConnection.connectionString, CommandType.Text, "UPDATE `member` SET `MembershipNo` = @MembershipNo, `MembershipDate` = @MembershipDate, `OldMembershipNos` = @OldMembershipNos, `SalutationKey` = @SalutationKey, `Surname` = @Surname, `Initials` = @Initials, `Forenames` = @Forenames, `DOB` = @DOB, `IdentificationType` = @IdentificationType, `IdentificationNo` = @IdentificationNo, `YearJoined` = @YearJoined, `YearLeft` = @YearLeft, `AddressKey` = @AddressKey, `Mobile` = @Mobile, `Email` = @Email, `MailReturned` = @MailReturned, `EmailReturned` = @EmailReturned, `OLYear` = @OLYear, `ALYear` = @ALYear, `ClassGroup` = @ClassGroup, `ReceiptKey` = @ReceiptKey, `Rejected` = @Rejected, `RejectedReason` = @RejectedReason, `RefundChqNo` = @RefundChqNo, `RefundCheqDate` = @RefundCheqDate, `ApprovalStage` = @ApprovalStage, `DateSentToOffice` = @DateSentToOffice, `DateApproved` = @DateApproved, `DateRejected` = @DateRejected, `DateCardSentToPrinter` = @DateCardSentToPrinter, `DateCardReceivedFromPrinter` = @DateCardReceivedFromPrinter, `DateMemberNotified` = @DateMemberNotified, `DateCardGivenToMember` = @DateCardGivenToMember, `MembershipNotificationType` = @MembershipNotificationType, `Picture` = @Picture, `Archive` = @Archive, `Deceased` = @Deceased, `DeceasedDate` = @DeceasedDate, `Remarks` = @Remarks, `ProfessionKey` = @ProfessionKey, `Outdated` = @Outdated, `UserKey` = @UserKey, `UpdatedDate` = @UpdatedDate, `Deleted` = @Deleted WHERE `Key`= @Key;", para);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public bool delete(ML_Member member)
        {
            try
            {
                MySqlParameter[] para = new MySqlParameter[2];
                para[0] = new MySqlParameter("@Deleted", member.Deleted);
                para[1] = new MySqlParameter("@Key", member.Key);
                var a = MySQLHelper.ExecuteNonQuery(DBConnection.connectionString, CommandType.Text, "UPDATE `member` SET `Deleted` = @Deleted WHERE `Key`= @Key;", para);
            }
            catch (Exception ex)
            {
                return false;
            }
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
    }
}
