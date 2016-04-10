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
            MySqlParameter[] para = new MySqlParameter[0];
            para[0] = new MySqlParameter("@MembershipNo", member.MembershipNo);

            var a = MySQLHelper.ExecuteScalar(DBConnection.connectionString, CommandType.Text, "INSERT INTO stc_oba.member (`Key` , MembershipNo , MembershipDate , OldMembershipNos , SalutationKey , Surname , Initials , Forenames , DOB , IdentificationType , IdentificationNo , YearJoined , YearLeft , AddressKey , Mobile , Email , MailReturned , EmailReturned , OLYear , ALYear , ClassGroup , ReceiptKey , Rejected , RejectedReason , RefundChqNo , RefundCheqDate , ApprovalStage , DateSentToOffice , DateApproved , DateRejected , DateCardSentToPrinter , DateCardReceivedFromPrinter , DateMemberNotified , DateCardGivenToMember , MembershipNotificationType , Picture , Archive , Deceased , DeceasedDate , Remarks , ProfessionKey , Outdated , UserKey , UpdatedDate , Deleted) VALUES (NULL, @MembershipNo, @MembershipDate, @OldMembershipNos, @SalutationKey, @Surname, @Initials, @Forenames, @DOB, @IdentificationType, @IdentificationNo, @YearJoined, @YearLeft, @AddressKey, @Mobile, @Email, @MailReturned, @EmailReturned, @OLYear, @ALYear, @ClassGroup, @ReceiptKey, @Rejected, @RejectedReason, @RefundChqNo, @RefundCheqDate, @ApprovalStage, @DateSentToOffice, @DateApproved, @DateRejected, @DateCardSentToPrinter, @DateCardReceivedFromPrinter, @DateMemberNotified, @DateCardGivenToMember, @MembershipNotificationType, @Picture, @Archive, @Deceased, @DeceasedDate, @Remarks, @ProfessionKey, @Outdated, @UserKey, @UpdatedDate, @Deleted); SELECT LAST_INSERT_ID();", para);
            return (int)a;
        }
    }
}
