using MySql.Data.MySqlClient;
using OBALog.Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace OBALog.Data
{
    public class DL_Member
    {
        public int insert(ML_Member member)
        {
            List<MySqlParameter> paraList = getParameterList(ref member);
            MySqlParameter[] para = new MySqlParameter[paraList.Count];
            para = paraList.ToArray();

            return (int)MySQLHelper.ExecuteScalar(DBConnection.connectionString, CommandType.Text, "INSERT INTO stc_oba.member (MembershipNo , MembershipDate , OldMembershipNos , SalutationKey , Surname , Initials , Forenames , DOB , IdentificationType , IdentificationNo , YearJoined , YearLeft , AddressKey , Mobile , Email , MailReturned , EmailReturned , OLYear , ALYear , ClassGroup , ReceiptKey , Rejected , RejectedReason , RefundChqNo , RefundCheqDate , ApprovalStage , DateSentToOffice , DateApproved , DateRejected , DateCardSentToPrinter , DateCardReceivedFromPrinter , DateMemberNotified , DateCardGivenToMember , MembershipNotificationType , Picture , Archive , Deceased , DeceasedDate , Remarks , ProfessionKey , Outdated , UserKey , UpdatedDate , Deleted) VALUES (@MembershipNo, @MembershipDate, @OldMembershipNos, @SalutationKey, @Surname, @Initials, @Forenames, @DOB, @IdentificationType, @IdentificationNo, @YearJoined, @YearLeft, @AddressKey, @Mobile, @Email, @MailReturned, @EmailReturned, @OLYear, @ALYear, @ClassGroup, @ReceiptKey, @Rejected, @RejectedReason, @RefundChqNo, @RefundCheqDate, @ApprovalStage, @DateSentToOffice, @DateApproved, @DateRejected, @DateCardSentToPrinter, @DateCardReceivedFromPrinter, @DateMemberNotified, @DateCardGivenToMember, @MembershipNotificationType, @Picture, @Archive, @Deceased, @DeceasedDate, @Remarks, @ProfessionKey, @Outdated, @UserKey, @UpdatedDate, @Deleted); SELECT LAST_INSERT_ID();", para);
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
            return MySQLHelper.ExecuteDataTable(DBConnection.connectionString, CommandType.Text, "SELECT M.KEY ,MembershipNo, Initials, Forenames, Surname FROM member M WHERE `Deleted` = 0 ORDER BY M.KEY DESC LIMIT 20;");
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

        public DataTable selectMemberAdvancedMembership(ML_Member member, string DateFrom, string DateTo, bool? Deleted, bool includeDuplicates)
        {
            MySqlParameter[] para = new MySqlParameter[5];
            para[0] = new MySqlParameter("@MembershipNo", member.MembershipNo);
            para[1] = new MySqlParameter("@OldMembershipNos", member.OldMembershipNos);
            para[2] = new MySqlParameter("@MDSD", DateFrom);
            para[3] = new MySqlParameter("@MDED", DateTo);
            para[4] = new MySqlParameter("@Deleted", Deleted);

            string Query = string.Format("SELECT `Key`, MembershipNo, Initials, Surname, Forenames, country FROM vw_allmemberdata WHERE {0} AND (CONVERT(MembershipDate, date) >= CONVERT(@MDSD, date) OR @MDSD IS NULL) AND (CONVERT(MembershipDate, date) <= CONVERT(@MDED, date) OR @MDED IS NULL) AND (Deleted = @Deleted OR @Deleted IS NULL)", includeDuplicates ? "(MembershipNo LIKE @MembershipNo OR @MembershipNo IS NULL) OR (OldMembershipNos LIKE @MembershipNo OR @MembershipNo IS NULL)" : "(MembershipNo LIKE @MembershipNo OR @MembershipNo IS NULL) AND (OldMembershipNos LIKE @OldMembershipNos OR @OldMembershipNos IS NULL) ");

            return MySQLHelper.ExecuteDataTable(DBConnection.connectionString, CommandType.Text, Query, para);
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

        public ML_ViewMember selectMember(int MemberKey)
        {
            MySqlParameter[] para = new MySqlParameter[1];
            para[0] = new MySqlParameter("@MemberKey", MemberKey);

            return MySQLHelper.ExecuteDataTable(DBConnection.connectionString, CommandType.Text, "SELECT * FROM vw_allmemberdata WHERE `KEY` = @MemberKey;", para).DataTableToList<ML_ViewMember>()[0];
        }


        public int insertMemberAddress(ML_Address address)
        {
            MySqlTransaction tr = null;
            MySqlConnection con = new MySqlConnection(DBConnection.connectionString);
            con.Open();
            try
            {
                tr = con.BeginTransaction();
                MySqlCommand cmd = new MySqlCommand();
                cmd = new MySqlCommand("INSERT INTO stc_oba.address (address , CityKey , Telephone , UserKey , UpdatedDate) VALUES (@Address, @CityKey, @Telephone, @UserKey, @UpdatedDate); SELECT LAST_INSERT_ID();", con, tr);
                cmd.Parameters.AddWithValue("@Address", address.Address);
                cmd.Parameters.AddWithValue("@CityKey", address.CityKey);
                cmd.Parameters.AddWithValue("@Telephone", address.Telephone);
                cmd.Parameters.AddWithValue("@UserKey", address.UserKey);
                cmd.ExecuteNonQuery();
                tr.Commit();
            }
            catch
            {
                tr.Rollback();
                throw;
            }
            finally
            {
                con.Close();
            }
            return 0;
        }
        public int insertReceipt(ML_Receipt receipt)
        {
            MySqlTransaction tr = null;
            int returnKey = 0;
            MySqlConnection con = new MySqlConnection(DBConnection.connectionString);
            con.Open();
            try
            {
                tr = con.BeginTransaction();
                MySqlCommand cmd = new MySqlCommand();
                cmd = new MySqlCommand("INSERT INTO stc_oba.receipt (ReceiptNo, ReceiptDate, ReceiptAmount, PaymentType, CardChequeNo, Bank, PrintCount, UserKey, UpdatedDate) VALUES (@ReceiptNo, @ReceiptDate, @ReceiptAmount, @PaymentType, @CardChequeNo, @Bank, @PrintCount, @UserKey, @UpdatedDate); SELECT LAST_INSERT_ID();", con, tr);
                cmd.Parameters.AddWithValue("@ReceiptNo", receipt.ReceiptNo);
                cmd.Parameters.AddWithValue("@ReceiptDate", receipt.ReceiptDate);
                cmd.Parameters.AddWithValue("@ReceiptAmount", receipt.ReceiptAmount);
                cmd.Parameters.AddWithValue("@PaymentType", receipt.PaymentType);
                cmd.Parameters.AddWithValue("@CardChequeNo", receipt.CardChequeNo);
                cmd.Parameters.AddWithValue("@Bank", receipt.Bank);
                cmd.Parameters.AddWithValue("@PrintCount", receipt.PrintCount);
                cmd.Parameters.AddWithValue("@UserKey", receipt.UserKey);
                cmd.Parameters.AddWithValue("@UpdatedDate", receipt.UpdatedDate);

                returnKey = Convert.ToInt32(cmd.ExecuteScalar());
                tr.Commit();
            }
            catch
            {
                tr.Rollback();
                throw;
            }
            finally
            {
                con.Close();
            }
            return returnKey;
        }

        public int insertAdmission(ML_Admission admission)
        {
            MySqlTransaction tr = null;
            int returnKey = 0;
            MySqlConnection con = new MySqlConnection(DBConnection.connectionString);
            con.Open();
            try
            {
                tr = con.BeginTransaction();
                MySqlCommand cmd = new MySqlCommand();
                cmd = new MySqlCommand("INSERT INTO stc_oba.admission ( MemberKey ,School ,AdmissionNo ,UserKey ) VALUES ( @MemberKey ,@School ,@AdmissionNo ,@UserKey ); SELECT LAST_INSERT_ID();", con, tr);
                cmd.Parameters.AddWithValue("@MemberKey", admission.MemberKey);
                cmd.Parameters.AddWithValue("@School", admission.School);
                cmd.Parameters.AddWithValue("@AdmissionNo", admission.AdmissionNo);
                cmd.Parameters.AddWithValue("@UserKey", admission.UserKey);
                returnKey = Convert.ToInt32(cmd.ExecuteScalar());
                tr.Commit();
            }
            catch
            {
                tr.Rollback();
                throw;
            }
            finally
            {
                con.Close();
            }
            return returnKey;
        }


        public int insertProfessionalDetails(ML_ProfessionalDetails proDetails)
        {
            MySqlTransaction tr = null;
            int returnKey = 0;
            MySqlConnection con = new MySqlConnection(DBConnection.connectionString);
            con.Open();
            try
            {
                tr = con.BeginTransaction();
                MySqlCommand cmd = new MySqlCommand();
                cmd = new MySqlCommand("INSERT INTO stc_oba.professionaldetails ( OrganisationKey ,MemberKey ,Designation ,Email ,Active ,UserKey ,UpdatedDate ) VALUES ( @OrganisationKey ,@MemberKey ,@Designation ,@Email ,@Active ,@UserKey , @UpdatedDate); SELECT LAST_INSERT_ID();", con, tr);
                cmd.Parameters.AddWithValue("@OrganisationKey", proDetails.OrganisationKey);
                cmd.Parameters.AddWithValue("@MemberKey", proDetails.MemberKey);
                cmd.Parameters.AddWithValue("@Designation", proDetails.Designation);
                cmd.Parameters.AddWithValue("@Email", proDetails.Email);
                cmd.Parameters.AddWithValue("@Active", proDetails.Active);
                cmd.Parameters.AddWithValue("@UserKey", proDetails.UserKey);
                cmd.Parameters.AddWithValue("@UpdatedDate", proDetails.UpdatedDate);

                returnKey = Convert.ToInt32(cmd.ExecuteScalar());
                tr.Commit();
            }
            catch
            {
                tr.Rollback();
                throw;
            }
            finally
            {
                con.Close();
            }
            return returnKey;
        }

        public bool insertRemark(ML_RemarksHistory remark)
        {
            MySqlTransaction tr = null;
            MySqlConnection con = new MySqlConnection(DBConnection.connectionString);
            con.Open();
            try
            {
                tr = con.BeginTransaction();
                MySqlCommand cmd = new MySqlCommand();
                cmd = new MySqlCommand("INSERT INTO stc_oba.remarkshistory ( MemberKey ,UserKey ,Remarks ,UpdatedDate ) VALUES ( @MemberKey ,@UserKey ,@Remarks , @UpdatedDate );", con, tr);
                cmd.Parameters.AddWithValue("@MemberKey", remark.MemberKey);
                cmd.Parameters.AddWithValue("@Remarks", remark.Remarks);
                cmd.Parameters.AddWithValue("@UserKey", remark.UserKey);
                cmd.Parameters.AddWithValue("@UpdatedDate", remark.UpdatedDate);

                tr.Commit();
            }
            catch
            {
                tr.Rollback();
                throw;
            }
            finally
            {
                con.Close();
            }
            return true;
        }


        public bool insertMember(ML_Address address, ML_Receipt receipt, ML_Member member, List<ML_Admission> admissions, ML_ProfessionalDetails proDetails, List<ML_RemarksHistory> remarks, string ReceiptNoStr, string MembershipDateStr, string MembershipNoIndexStr, string userKey)
        {
            int memberKey = 0;

            MySqlTransaction tr = null;

            using (MySqlConnection con = new MySqlConnection(DBConnection.connectionString))
            {
                con.Open();
                try
                {
                    tr = con.BeginTransaction();

                    #region Address

                    int addressKey = 0;

                    using (MySqlCommand cmdAddress = new MySqlCommand("INSERT INTO stc_oba.address (address , CityKey , Telephone , UserKey , UpdatedDate) VALUES (@Address, @CityKey, @Telephone, @UserKey, @UpdatedDate); SELECT LAST_INSERT_ID();", con, tr))
                    {
                        cmdAddress.Parameters.AddWithValue("@Address", address.Address);
                        cmdAddress.Parameters.AddWithValue("@CityKey", address.CityKey);
                        cmdAddress.Parameters.AddWithValue("@Telephone", address.Telephone);
                        cmdAddress.Parameters.AddWithValue("@UserKey", userKey);
                        cmdAddress.Parameters.AddWithValue("@UpdatedDate", address.UpdatedDate);

                        addressKey = Convert.ToInt32(cmdAddress.ExecuteScalar());
                    }

                    #endregion

                    #region Receipt

                    int receiptKey = 0;
                    using (MySqlCommand cmdReceipt = new MySqlCommand("INSERT INTO stc_oba.receipt (ReceiptNo, ReceiptDate, ReceiptAmount, PaymentType, CardChequeNo, Bank, PrintCount, UserKey, UpdatedDate) VALUES (@ReceiptNo, @ReceiptDate, @ReceiptAmount, @PaymentType, @CardChequeNo, @Bank, @PrintCount, @UserKey, @UpdatedDate); SELECT LAST_INSERT_ID();", con, tr))
                    {

                        cmdReceipt.Parameters.AddWithValue("@ReceiptNo", receipt.ReceiptNo);
                        cmdReceipt.Parameters.AddWithValue("@ReceiptDate", receipt.ReceiptDate);
                        cmdReceipt.Parameters.AddWithValue("@ReceiptAmount", receipt.ReceiptAmount);
                        cmdReceipt.Parameters.AddWithValue("@PaymentType", receipt.PaymentType);
                        cmdReceipt.Parameters.AddWithValue("@CardChequeNo", receipt.CardChequeNo);
                        cmdReceipt.Parameters.AddWithValue("@Bank", receipt.Bank);
                        cmdReceipt.Parameters.AddWithValue("@PrintCount", receipt.PrintCount);
                        cmdReceipt.Parameters.AddWithValue("@UserKey", userKey);
                        cmdReceipt.Parameters.AddWithValue("@UpdatedDate", receipt.UpdatedDate);

                        receiptKey = Convert.ToInt32(cmdReceipt.ExecuteScalar());
                    }

                    #endregion

                    #region ReceiptNoConfig

                    using (MySqlCommand cmdReceiptNoConfig = new MySqlCommand("UPDATE configurations SET ConfigurationValue = @ConfigurationValue,UserKey = @UserKey ,UpdatedDate = @UpdatedDate WHERE ConfigurationName = @ConfigurationName", con, tr))
                    {

                        cmdReceiptNoConfig.Parameters.AddWithValue("@ConfigurationValue", receipt.ReceiptNo);
                        cmdReceiptNoConfig.Parameters.AddWithValue("@UserKey", userKey);
                        cmdReceiptNoConfig.Parameters.AddWithValue("@ConfigurationName", ReceiptNoStr);
                        cmdReceiptNoConfig.Parameters.AddWithValue("@UpdatedDate", receipt.UpdatedDate);
                        cmdReceiptNoConfig.ExecuteNonQuery();
                    }

                    #endregion

                    #region Member

                    using (MySqlCommand cmdMember = new MySqlCommand("INSERT INTO stc_oba.member (MembershipNo , MembershipDate , OldMembershipNos , SalutationKey , Surname , Initials , Forenames , DOB , IdentificationType , IdentificationNo , YearJoined , YearLeft , AddressKey , Mobile , Email , MailReturned , EmailReturned , OLYear , ALYear , ClassGroup , ReceiptKey , Rejected , RejectedReason , RefundChqNo , RefundCheqDate , ApprovalStage , DateSentToOffice , DateApproved , DateRejected , DateCardSentToPrinter , DateCardReceivedFromPrinter , DateMemberNotified , DateCardGivenToMember , MembershipNotificationType , Deceased , DeceasedDate , ProfessionKey , Outdated , UserKey ,Picture , UpdatedDate) VALUES (@MembershipNo, @MembershipDate, @OldMembershipNos, @SalutationKey, @Surname, @Initials, @Forenames, @DOB, @IdentificationType, @IdentificationNo, @YearJoined, @YearLeft, @AddressKey, @Mobile, @Email, @MailReturned, @EmailReturned, @OLYear, @ALYear, @ClassGroup, @ReceiptKey, @Rejected, @RejectedReason, @RefundChqNo, @RefundCheqDate, @ApprovalStage, @DateSentToOffice, @DateApproved, @DateRejected, @DateCardSentToPrinter, @DateCardReceivedFromPrinter, @DateMemberNotified, @DateCardGivenToMember, @MembershipNotificationType, @Deceased, @DeceasedDate, @ProfessionKey, @Outdated, @UserKey, @Picture, @UpdatedDate); SELECT LAST_INSERT_ID();", con, tr))
                    {

                        cmdMember.Parameters.AddWithValue("@MembershipNo", member.MembershipNo);
                        cmdMember.Parameters.AddWithValue("@MembershipDate", member.MembershipDate);
                        cmdMember.Parameters.AddWithValue("@OldMembershipNos", member.OldMembershipNos);
                        cmdMember.Parameters.AddWithValue("@SalutationKey", member.SalutationKey);
                        cmdMember.Parameters.AddWithValue("@Surname", member.Surname);
                        cmdMember.Parameters.AddWithValue("@Initials", member.Initials);
                        cmdMember.Parameters.AddWithValue("@Forenames", member.Forenames);
                        cmdMember.Parameters.AddWithValue("@DOB", member.DOB);
                        cmdMember.Parameters.AddWithValue("@IdentificationType", member.IdentificationType);
                        cmdMember.Parameters.AddWithValue("@IdentificationNo", member.IdentificationNo);
                        cmdMember.Parameters.AddWithValue("@YearJoined", member.YearJoined);
                        cmdMember.Parameters.AddWithValue("@YearLeft", member.YearLeft);
                        cmdMember.Parameters.AddWithValue("@AddressKey", addressKey);
                        cmdMember.Parameters.AddWithValue("@Mobile", member.Mobile);
                        cmdMember.Parameters.AddWithValue("@Email", member.Email);
                        cmdMember.Parameters.AddWithValue("@MailReturned", member.MailReturned);
                        cmdMember.Parameters.AddWithValue("@EmailReturned", member.EmailReturned);
                        cmdMember.Parameters.AddWithValue("@OLYear", member.OLYear);
                        cmdMember.Parameters.AddWithValue("@ALYear", member.ALYear);
                        cmdMember.Parameters.AddWithValue("@ClassGroup", member.ClassGroup);
                        cmdMember.Parameters.AddWithValue("@ReceiptKey", receiptKey);
                        cmdMember.Parameters.AddWithValue("@Rejected", member.Rejected);
                        cmdMember.Parameters.AddWithValue("@RejectedReason", member.RejectedReason);
                        cmdMember.Parameters.AddWithValue("@RefundChqNo", member.RefundChqNo);
                        cmdMember.Parameters.AddWithValue("@RefundCheqDate", member.RefundCheqDate);
                        cmdMember.Parameters.AddWithValue("@ApprovalStage", member.ApprovalStage);
                        cmdMember.Parameters.AddWithValue("@DateSentToOffice", member.DateSentToOffice);
                        cmdMember.Parameters.AddWithValue("@DateApproved", member.DateApproved);
                        cmdMember.Parameters.AddWithValue("@DateRejected", member.DateRejected);
                        cmdMember.Parameters.AddWithValue("@DateCardSentToPrinter", member.DateCardSentToPrinter);
                        cmdMember.Parameters.AddWithValue("@DateCardReceivedFromPrinter", member.DateCardReceivedFromPrinter);
                        cmdMember.Parameters.AddWithValue("@DateMemberNotified", member.DateMemberNotified);
                        cmdMember.Parameters.AddWithValue("@DateCardGivenToMember", member.DateCardGivenToMember);
                        cmdMember.Parameters.AddWithValue("@MembershipNotificationType", member.MembershipNotificationType);
                        cmdMember.Parameters.AddWithValue("@Deceased", member.Deceased);
                        cmdMember.Parameters.AddWithValue("@DeceasedDate", member.DeceasedDate);
                        cmdMember.Parameters.AddWithValue("@ProfessionKey", member.ProfessionKey);
                        cmdMember.Parameters.AddWithValue("@Outdated", member.Outdated);
                        cmdMember.Parameters.AddWithValue("@UserKey", userKey);
                        cmdMember.Parameters.AddWithValue("@Picture", member.Picture);
                        cmdMember.Parameters.AddWithValue("@UpdatedDate", member.UpdatedDate);

                        memberKey = Convert.ToInt32(cmdMember.ExecuteScalar());
                    }

                    #endregion

                    #region MembershipNoConfig

                    using (MySqlCommand cmdMembershipNoConfig = new MySqlCommand("UPDATE configurations SET ConfigurationValue = @ConfigurationValue,UserKey = @UserKey ,UpdatedDate = @UpdatedDate WHERE ConfigurationName = @ConfigurationName", con, tr))
                    {

                        cmdMembershipNoConfig.Parameters.AddWithValue("@ConfigurationValue", getMaxMemNo());
                        cmdMembershipNoConfig.Parameters.AddWithValue("@UserKey", userKey);
                        cmdMembershipNoConfig.Parameters.AddWithValue("@ConfigurationName", MembershipNoIndexStr);
                        cmdMembershipNoConfig.Parameters.AddWithValue("@UpdatedDate", member.UpdatedDate);
                        cmdMembershipNoConfig.ExecuteNonQuery();
                    }

                    /*
                     * if (!string.IsNullOrEmpty(member.MembershipNo))
                    {
                        using (MySqlCommand cmdMembershipNoConfig = new MySqlCommand("UPDATE configurations SET ConfigurationValue = @ConfigurationValue,UserKey = @UserKey ,UpdatedDate = NOW() WHERE ConfigurationName = @ConfigurationName", con, tr))
                        {

                            cmdMembershipNoConfig.Parameters.AddWithValue("@ConfigurationValue", member.MembershipNo);
                            cmdMembershipNoConfig.Parameters.AddWithValue("@UserKey", userKey);
                            cmdMembershipNoConfig.Parameters.AddWithValue("@ConfigurationName", MembershipNoIndexStr);

                            cmdMembershipNoConfig.ExecuteNonQuery();
                        }
                    }
                    */
                    #endregion

                    #region MembershipDate

                    using (MySqlCommand cmdMembershipNoConfig = new MySqlCommand("UPDATE configurations SET ConfigurationValue = @ConfigurationValue,UserKey = @UserKey, UpdatedDate = @UpdatedDate WHERE ConfigurationName = @ConfigurationName", con, tr))
                    {
                        cmdMembershipNoConfig.Parameters.AddWithValue("@ConfigurationValue", getMaxMemDate());
                        cmdMembershipNoConfig.Parameters.AddWithValue("@UserKey", userKey);
                        cmdMembershipNoConfig.Parameters.AddWithValue("@ConfigurationName", MembershipDateStr);
                        cmdMembershipNoConfig.Parameters.AddWithValue("@UpdatedDate", member.UpdatedDate);
                        cmdMembershipNoConfig.ExecuteNonQuery();
                    }

                    /*
                     * if (member.MembershipDate != null)
                    {
                        using (MySqlCommand cmdMembershipNoConfig = new MySqlCommand("UPDATE configurations SET ConfigurationValue = @ConfigurationValue,UserKey = @UserKey ,UpdatedDate = NOW() WHERE ConfigurationName = @ConfigurationName", con, tr))
                        {
                            cmdMembershipNoConfig.Parameters.AddWithValue("@ConfigurationValue", member.MembershipDate);
                            cmdMembershipNoConfig.Parameters.AddWithValue("@UserKey", userKey);
                            cmdMembershipNoConfig.Parameters.AddWithValue("@ConfigurationName", MembershipDateStr);

                            cmdMembershipNoConfig.ExecuteNonQuery();
                        }
                    }
                    */
                    #endregion

                    #region Admission

                    foreach (ML_Admission admission in admissions)
                    {
                        using (MySqlCommand cmdAdmission = new MySqlCommand("INSERT INTO stc_oba.admission ( MemberKey ,School ,AdmissionNo ,UserKey ) VALUES ( @MemberKey ,@School ,@AdmissionNo ,@UserKey );", con, tr))
                        {
                            cmdAdmission.Parameters.AddWithValue("@MemberKey", memberKey);
                            cmdAdmission.Parameters.AddWithValue("@School", admission.School);
                            cmdAdmission.Parameters.AddWithValue("@AdmissionNo", admission.AdmissionNo);
                            cmdAdmission.Parameters.AddWithValue("@UserKey", userKey);

                            cmdAdmission.ExecuteNonQuery();
                        }
                    }


                    #endregion

                    #region ProfessionalDetails

                    if (proDetails != null && proDetails.OrganisationKey > 0)
                    {
                        using (MySqlCommand cmdProfessionalDetails = new MySqlCommand("INSERT INTO stc_oba.professionaldetails ( OrganisationKey ,MemberKey ,Designation ,Email ,Active ,UserKey ,UpdatedDate ) VALUES ( @OrganisationKey ,@MemberKey ,@Designation ,@Email ,@Active ,@UserKey, @UpdatedDate);", con, tr))
                        {

                            cmdProfessionalDetails.Parameters.AddWithValue("@OrganisationKey", proDetails.OrganisationKey);
                            cmdProfessionalDetails.Parameters.AddWithValue("@MemberKey", memberKey);
                            cmdProfessionalDetails.Parameters.AddWithValue("@Designation", proDetails.Designation);
                            cmdProfessionalDetails.Parameters.AddWithValue("@Email", proDetails.Email);
                            cmdProfessionalDetails.Parameters.AddWithValue("@Active", proDetails.Active);
                            cmdProfessionalDetails.Parameters.AddWithValue("@UserKey", userKey);
                            cmdProfessionalDetails.Parameters.AddWithValue("@UpdatedDate", proDetails.UpdatedDate);

                            cmdProfessionalDetails.ExecuteNonQuery();
                        }
                    }

                    #endregion

                    #region RemarksHistory

                    foreach (ML_RemarksHistory remark in remarks)
                    {
                        using (MySqlCommand cmdRemark = new MySqlCommand("INSERT INTO stc_oba.remarkshistory ( MemberKey ,UserKey ,Remarks ,UpdatedDate ) VALUES ( @MemberKey ,@UserKey ,@Remarks , @UpdatedDate );", con, tr))
                        {
                            cmdRemark.Parameters.AddWithValue("@MemberKey", memberKey);
                            cmdRemark.Parameters.AddWithValue("@Remarks", remark.Remarks);
                            cmdRemark.Parameters.AddWithValue("@UserKey", userKey);
                            cmdRemark.Parameters.AddWithValue("@UpdatedDate", remark.UpdatedDate);

                            cmdRemark.ExecuteNonQuery();
                        }
                    }

                    #endregion

                    tr.Commit();
                }
                catch
                {
                    tr.Rollback();
                    throw;
                }
                finally
                {
                    con.Close();
                }
            }

            member.Key = memberKey;

            return true;
        }


        public bool updateMember(ML_Address address, ML_Receipt receipt, ML_Member member, List<ML_Admission> admissions, ML_ProfessionalDetails proDetails, List<ML_RemarksHistory> remarks, string ReceiptNoStr, string MembershipDateStr, string MembershipNoIndexStr, string school_STCMount, string userKey)
        {
            MySqlTransaction tr = null;
            using (MySqlConnection con = new MySqlConnection(DBConnection.connectionString))
            {
                con.Open();
                try
                {
                    tr = con.BeginTransaction();

                    #region Address
                    if (member.AddressKey == null)
                    {
                        using (MySqlCommand cmdAddress = new MySqlCommand("INSERT INTO stc_oba.address (address , CityKey , Telephone , UserKey , UpdatedDate) VALUES (@Address, @CityKey, @Telephone, @UserKey, @UpdatedDate); SELECT LAST_INSERT_ID();", con, tr))
                        {
                            cmdAddress.Parameters.AddWithValue("@Address", address.Address);
                            cmdAddress.Parameters.AddWithValue("@CityKey", address.CityKey);
                            cmdAddress.Parameters.AddWithValue("@Telephone", address.Telephone);
                            cmdAddress.Parameters.AddWithValue("@UserKey", userKey);
                            cmdAddress.Parameters.AddWithValue("@UpdatedDate", address.UpdatedDate);

                            member.AddressKey = Convert.ToInt32(cmdAddress.ExecuteScalar());
                        }
                    }
                    else
                    {
                        using (MySqlCommand cmdAddress = new MySqlCommand("UPDATE stc_oba.address SET Address = @Address, CityKey = @CityKey, Telephone = @Telephone, UserKey = @UserKey, UpdatedDate = @UpdatedDate WHERE `Key` = @Key", con, tr))
                        {
                            cmdAddress.Parameters.AddWithValue("@Address", address.Address);
                            cmdAddress.Parameters.AddWithValue("@CityKey", address.CityKey);
                            cmdAddress.Parameters.AddWithValue("@Telephone", address.Telephone);
                            cmdAddress.Parameters.AddWithValue("@UserKey", userKey);
                            cmdAddress.Parameters.AddWithValue("@Key", address.Key);
                            cmdAddress.Parameters.AddWithValue("@UpdatedDate", address.UpdatedDate);
                            cmdAddress.ExecuteNonQuery();
                        }
                    }
                    #endregion

                    #region Receipt

                    if (receipt.Key == null)
                    {
                        using (MySqlCommand cmdReceipt = new MySqlCommand("INSERT INTO stc_oba.receipt (ReceiptNo, ReceiptDate, ReceiptAmount, PaymentType, CardChequeNo, Bank, PrintCount, UserKey, UpdatedDate) VALUES (@ReceiptNo, @ReceiptDate, @ReceiptAmount, @PaymentType, @CardChequeNo, @Bank, @PrintCount, @UserKey, @UpdatedDate); SELECT LAST_INSERT_ID();", con, tr))
                        {

                            cmdReceipt.Parameters.AddWithValue("@ReceiptNo", receipt.ReceiptNo);
                            cmdReceipt.Parameters.AddWithValue("@ReceiptDate", receipt.ReceiptDate);
                            cmdReceipt.Parameters.AddWithValue("@ReceiptAmount", receipt.ReceiptAmount);
                            cmdReceipt.Parameters.AddWithValue("@PaymentType", receipt.PaymentType);
                            cmdReceipt.Parameters.AddWithValue("@CardChequeNo", receipt.CardChequeNo);
                            cmdReceipt.Parameters.AddWithValue("@Bank", receipt.Bank);
                            cmdReceipt.Parameters.AddWithValue("@PrintCount", receipt.PrintCount);
                            cmdReceipt.Parameters.AddWithValue("@UserKey", userKey);
                            cmdReceipt.Parameters.AddWithValue("@UpdatedDate", receipt.UpdatedDate);
                            receipt.Key = member.ReceiptKey = Convert.ToInt32(cmdReceipt.ExecuteScalar());
                        }
                    }
                    else
                    {
                        using (MySqlCommand cmdReceipt = new MySqlCommand("UPDATE stc_oba.receipt SET ReceiptNo = @ReceiptNo, ReceiptDate = @ReceiptDate, ReceiptAmount = @ReceiptAmount, PaymentType = @PaymentType, CardChequeNo = @CardChequeNo, Bank = @Bank, PrintCount = @PrintCount, UserKey = @UserKey, UpdatedDate = @UpdatedDate WHERE `Key` = @Key", con, tr))
                        {

                            cmdReceipt.Parameters.AddWithValue("@ReceiptNo", receipt.ReceiptNo);
                            cmdReceipt.Parameters.AddWithValue("@ReceiptDate", receipt.ReceiptDate);
                            cmdReceipt.Parameters.AddWithValue("@ReceiptAmount", receipt.ReceiptAmount);
                            cmdReceipt.Parameters.AddWithValue("@PaymentType", receipt.PaymentType);
                            cmdReceipt.Parameters.AddWithValue("@CardChequeNo", receipt.CardChequeNo);
                            cmdReceipt.Parameters.AddWithValue("@Bank", receipt.Bank);
                            cmdReceipt.Parameters.AddWithValue("@PrintCount", receipt.PrintCount);
                            cmdReceipt.Parameters.AddWithValue("@UserKey", userKey);
                            cmdReceipt.Parameters.AddWithValue("@Key", receipt.Key);
                            cmdReceipt.Parameters.AddWithValue("@UpdatedDate", receipt.UpdatedDate);
                            cmdReceipt.ExecuteNonQuery();
                        }
                    }
                    #endregion

                    #region ReceiptNoConfig

                    using (MySqlCommand cmdReceiptNoConfig = new MySqlCommand("UPDATE configurations SET ConfigurationValue = @ConfigurationValue, UserKey = @UserKey, UpdatedDate = @UpdatedDate WHERE ConfigurationName = @ConfigurationName", con, tr))
                    {

                        cmdReceiptNoConfig.Parameters.AddWithValue("@ConfigurationValue", getMaxReceiptNo());
                        cmdReceiptNoConfig.Parameters.AddWithValue("@UserKey", userKey);
                        cmdReceiptNoConfig.Parameters.AddWithValue("@ConfigurationName", ReceiptNoStr);
                        cmdReceiptNoConfig.Parameters.AddWithValue("@UpdatedDate", member.UpdatedDate);
                        cmdReceiptNoConfig.ExecuteNonQuery();
                    }

                    #endregion

                    #region Member

                    using (MySqlCommand cmdMember = new MySqlCommand("UPDATE stc_oba.member SET MembershipNo = @MembershipNo, MembershipDate = @MembershipDate, OldMembershipNos = @OldMembershipNos, SalutationKey = @SalutationKey, Surname = @Surname, Initials = @Initials, Forenames = @Forenames, DOB = @DOB, IdentificationType = @IdentificationType, IdentificationNo = @IdentificationNo, YearJoined = @YearJoined, YearLeft = @YearLeft, AddressKey = @AddressKey, Mobile = @Mobile, Email = @Email, MailReturned =@MailReturned, EmailReturned = @EmailReturned, OLYear = @OLYear, ALYear = @ALYear, ClassGroup = @ClassGroup, ReceiptKey = @ReceiptKey, Rejected = @Rejected, RejectedReason = @RejectedReason, RefundChqNo = @RefundChqNo, RefundCheqDate = @RefundCheqDate, ApprovalStage = @ApprovalStage, DateSentToOffice = @DateSentToOffice, DateApproved = @DateApproved, DateRejected = @DateRejected, DateCardSentToPrinter = @DateCardSentToPrinter, DateCardReceivedFromPrinter = @DateCardReceivedFromPrinter, DateMemberNotified = @DateMemberNotified, DateCardGivenToMember = @DateCardGivenToMember, MembershipNotificationType = @MembershipNotificationType, Picture = @Picture, Deceased = @Deceased, DeceasedDate = @DeceasedDate, ProfessionKey = @ProfessionKey, Outdated = @Outdated, UserKey = @UserKey, UpdatedDate = @UpdatedDate WHERE `Key` = @Key", con, tr))
                    {

                        cmdMember.Parameters.AddWithValue("@MembershipNo", member.MembershipNo);
                        cmdMember.Parameters.AddWithValue("@MembershipDate", member.MembershipDate);
                        cmdMember.Parameters.AddWithValue("@OldMembershipNos", member.OldMembershipNos);
                        cmdMember.Parameters.AddWithValue("@SalutationKey", member.SalutationKey);
                        cmdMember.Parameters.AddWithValue("@Surname", member.Surname);
                        cmdMember.Parameters.AddWithValue("@Initials", member.Initials);
                        cmdMember.Parameters.AddWithValue("@Forenames", member.Forenames);
                        cmdMember.Parameters.AddWithValue("@DOB", member.DOB);
                        cmdMember.Parameters.AddWithValue("@IdentificationType", member.IdentificationType);
                        cmdMember.Parameters.AddWithValue("@IdentificationNo", member.IdentificationNo);
                        cmdMember.Parameters.AddWithValue("@YearJoined", member.YearJoined);
                        cmdMember.Parameters.AddWithValue("@YearLeft", member.YearLeft);
                        cmdMember.Parameters.AddWithValue("@AddressKey", member.AddressKey);
                        cmdMember.Parameters.AddWithValue("@Mobile", member.Mobile);
                        cmdMember.Parameters.AddWithValue("@Email", member.Email);
                        cmdMember.Parameters.AddWithValue("@MailReturned", member.MailReturned);
                        cmdMember.Parameters.AddWithValue("@EmailReturned", member.EmailReturned);
                        cmdMember.Parameters.AddWithValue("@OLYear", member.OLYear);
                        cmdMember.Parameters.AddWithValue("@ALYear", member.ALYear);
                        cmdMember.Parameters.AddWithValue("@ClassGroup", member.ClassGroup);
                        cmdMember.Parameters.AddWithValue("@ReceiptKey", receipt.Key);
                        cmdMember.Parameters.AddWithValue("@Rejected", member.Rejected);
                        cmdMember.Parameters.AddWithValue("@RejectedReason", member.RejectedReason);
                        cmdMember.Parameters.AddWithValue("@RefundChqNo", member.RefundChqNo);
                        cmdMember.Parameters.AddWithValue("@RefundCheqDate", member.RefundCheqDate);
                        cmdMember.Parameters.AddWithValue("@ApprovalStage", member.ApprovalStage);
                        cmdMember.Parameters.AddWithValue("@DateSentToOffice", member.DateSentToOffice);
                        cmdMember.Parameters.AddWithValue("@DateApproved", member.DateApproved);
                        cmdMember.Parameters.AddWithValue("@DateRejected", member.DateRejected);
                        cmdMember.Parameters.AddWithValue("@DateCardSentToPrinter", member.DateCardSentToPrinter);
                        cmdMember.Parameters.AddWithValue("@DateCardReceivedFromPrinter", member.DateCardReceivedFromPrinter);
                        cmdMember.Parameters.AddWithValue("@DateMemberNotified", member.DateMemberNotified);
                        cmdMember.Parameters.AddWithValue("@DateCardGivenToMember", member.DateCardGivenToMember);
                        cmdMember.Parameters.AddWithValue("@MembershipNotificationType", member.MembershipNotificationType);
                        cmdMember.Parameters.AddWithValue("@Deceased", member.Deceased);
                        cmdMember.Parameters.AddWithValue("@DeceasedDate", member.DeceasedDate);
                        cmdMember.Parameters.AddWithValue("@ProfessionKey", member.ProfessionKey);
                        cmdMember.Parameters.AddWithValue("@Outdated", member.Outdated);
                        cmdMember.Parameters.AddWithValue("@UserKey", userKey);
                        cmdMember.Parameters.AddWithValue("@Picture", member.Picture);
                        cmdMember.Parameters.AddWithValue("@Key", member.Key);
                        cmdMember.Parameters.AddWithValue("@UpdatedDate", member.UpdatedDate);

                        cmdMember.ExecuteNonQuery();
                    }

                    #endregion

                    #region MembershipNoConfig

                    using (MySqlCommand cmdMembershipNoConfig = new MySqlCommand("UPDATE configurations SET ConfigurationValue = @ConfigurationValue,UserKey = @UserKey ,UpdatedDate = @UpdatedDate WHERE ConfigurationName = @ConfigurationName", con, tr))
                    {

                        cmdMembershipNoConfig.Parameters.AddWithValue("@ConfigurationValue", getMaxMemNo());
                        cmdMembershipNoConfig.Parameters.AddWithValue("@UserKey", userKey);
                        cmdMembershipNoConfig.Parameters.AddWithValue("@ConfigurationName", MembershipNoIndexStr);
                        cmdMembershipNoConfig.Parameters.AddWithValue("@UpdatedDate", member.UpdatedDate);
                        cmdMembershipNoConfig.ExecuteNonQuery();
                    }
                    #endregion

                    #region MembershipDate

                    using (MySqlCommand cmdMembershipNoConfig = new MySqlCommand("UPDATE configurations SET ConfigurationValue = @ConfigurationValue,UserKey = @UserKey, UpdatedDate = @UpdatedDate WHERE ConfigurationName = @ConfigurationName", con, tr))
                    {
                        cmdMembershipNoConfig.Parameters.AddWithValue("@ConfigurationValue", getMaxMemDate());
                        cmdMembershipNoConfig.Parameters.AddWithValue("@UserKey", userKey);
                        cmdMembershipNoConfig.Parameters.AddWithValue("@ConfigurationName", MembershipDateStr);
                        cmdMembershipNoConfig.Parameters.AddWithValue("@UpdatedDate", member.UpdatedDate);
                        cmdMembershipNoConfig.ExecuteNonQuery();
                    }
                    #endregion

                    #region Admission

                    using (MySqlCommand cmdAdmission = new MySqlCommand("DELETE FROM stc_oba.admission WHERE MemberKey = @MemberKey", con, tr))
                    {
                        cmdAdmission.Parameters.AddWithValue("@MemberKey", member.Key);
                        cmdAdmission.ExecuteNonQuery();
                    }

                    foreach (ML_Admission admission in admissions)
                    {
                        using (MySqlCommand cmdAdmission = new MySqlCommand("INSERT INTO stc_oba.admission ( MemberKey ,School ,AdmissionNo ,UserKey ) VALUES ( @MemberKey ,@School ,@AdmissionNo ,@UserKey );", con, tr))
                        {
                            cmdAdmission.Parameters.AddWithValue("@MemberKey", member.Key);
                            cmdAdmission.Parameters.AddWithValue("@School", admission.School);
                            cmdAdmission.Parameters.AddWithValue("@AdmissionNo", admission.AdmissionNo);
                            cmdAdmission.Parameters.AddWithValue("@UserKey", userKey);

                            cmdAdmission.ExecuteNonQuery();
                        }
                    }

                    #endregion

                    #region ProfessionalDetails

                    using (MySqlCommand cmdProfessionalDetails = new MySqlCommand("DELETE FROM stc_oba.professionaldetails WHERE MemberKey = @MemberKey", con, tr))
                    {
                        cmdProfessionalDetails.Parameters.AddWithValue("@MemberKey", member.Key);
                        cmdProfessionalDetails.ExecuteNonQuery();
                    }

                    if (proDetails != null)
                    {
                        using (MySqlCommand cmdProfessionalDetails = new MySqlCommand("INSERT INTO stc_oba.professionaldetails ( OrganisationKey ,MemberKey ,Designation ,Email ,Active ,UserKey ,UpdatedDate ) VALUES ( @OrganisationKey ,@MemberKey ,@Designation ,@Email ,@Active ,@UserKey, @UpdatedDate);", con, tr))
                        {

                            cmdProfessionalDetails.Parameters.AddWithValue("@OrganisationKey", proDetails.OrganisationKey);
                            cmdProfessionalDetails.Parameters.AddWithValue("@MemberKey", member.Key);
                            cmdProfessionalDetails.Parameters.AddWithValue("@Designation", proDetails.Designation);
                            cmdProfessionalDetails.Parameters.AddWithValue("@Email", proDetails.Email);
                            cmdProfessionalDetails.Parameters.AddWithValue("@Active", proDetails.Active);
                            cmdProfessionalDetails.Parameters.AddWithValue("@UpdatedDate", proDetails.UpdatedDate);
                            cmdProfessionalDetails.Parameters.AddWithValue("@UserKey", userKey);
                            cmdProfessionalDetails.ExecuteNonQuery();
                        }
                    }
                    #endregion

                    #region RemarksHistory
                    MySqlParameter[] paraRemark = new MySqlParameter[1];
                    paraRemark[0] = new MySqlParameter("@MemberKey", member.Key);
                    bool successDeleteRemarks = Convert.ToBoolean(MySQLHelper.ExecuteNonQuery(DBConnection.connectionString, CommandType.Text, "DELETE FROM remarkshistory WHERE MemberKey = @MemberKey", paraRemark));

                    if (successDeleteRemarks)
                    {
                        foreach (ML_RemarksHistory remark in remarks)
                        {
                            using (MySqlCommand cmdRemark = new MySqlCommand("INSERT INTO stc_oba.remarkshistory ( MemberKey ,UserKey ,Remarks ,UpdatedDate ) VALUES ( @MemberKey ,@UserKey ,@Remarks , @UpdatedDate );", con, tr))
                            {
                                cmdRemark.Parameters.AddWithValue("@MemberKey", member.Key);
                                cmdRemark.Parameters.AddWithValue("@Remarks", remark.Remarks);
                                cmdRemark.Parameters.AddWithValue("@UserKey", userKey);
                                cmdRemark.Parameters.AddWithValue("@UpdatedDate", remark.UpdatedDate);

                                cmdRemark.ExecuteNonQuery();
                            }
                        }

                    }
                    #endregion
                    tr.Commit();
                }
                catch
                {
                    tr.Rollback();
                    throw;
                }
                finally
                {
                    con.Close();
                }
            }
            return true;
        }

        private string getMaxMemDate()
        {
            return MySQLHelper.ExecuteDataTable(DBConnection.connectionString, CommandType.Text, "SELECT MAX(CAST(m.MembershipDate AS DATETIME)) AS MemDate FROM member m").Rows[0]["MemDate"].ToString();
        }
        public string getLastMemNo(string CurrentDateVal)
        {
            MySqlParameter[] para = new MySqlParameter[1];
            para[0] = new MySqlParameter("@CurrentDateVal", CurrentDateVal);

            return string.Format("{0}{1}", CurrentDateVal.Replace('%', ' ').Trim(), MySQLHelper.ExecuteDataTable(DBConnection.connectionString, CommandType.Text, "SELECT COUNT(*) AS Mem_No FROM Member WHERE MembershipNo LIKE @CurrentDateVal;", para).Rows[0]["Mem_No"].ToString().PadLeft(3, '0'));
        }

        public bool checkMemNo(string membershipNo, bool IsNewRecord, string memberKey = null)
        {
            if (IsNewRecord)
            {

                MySqlParameter[] para = new MySqlParameter[1];
                para[0] = new MySqlParameter("@MembershipNo", membershipNo);
                return Convert.ToInt32(MySQLHelper.ExecuteDataTable(DBConnection.connectionString, CommandType.Text, "SELECT COUNT(*) AS `Count` FROM vw_allmemberdata va WHERE va.MembershipNo = @MembershipNo;", para).Rows[0]["Count"].ToString()) > 0;
            }
            else
            {
                MySqlParameter[] para = new MySqlParameter[2];
                para[0] = new MySqlParameter("@MembershipNo", membershipNo);
                para[1] = new MySqlParameter("@Key", memberKey);
                return Convert.ToInt32(MySQLHelper.ExecuteDataTable(DBConnection.connectionString, CommandType.Text, "SELECT COUNT(*) AS `Count` FROM vw_allmemberdata va WHERE va.MembershipNo = @MembershipNo OR va.`KEY`= @Key", para).Rows[0]["Count"].ToString()) != 1;
            }
        }

        public string getReceiptNo(string configurationName)
        {
            MySqlParameter[] para = new MySqlParameter[1];
            para[0] = new MySqlParameter("@ConfigurationName", configurationName);

            return MySQLHelper.ExecuteDataTable(DBConnection.connectionString, CommandType.Text, "SELECT CONCAT('R',LPAD(CONVERT(SUBSTRING(ConfigurationValue, 2), SIGNED integer) + 1,4,'0')) AS ReceiptNo FROM configurations c WHERE c.ConfigurationName = @ConfigurationName", para).Rows[0]["ReceiptNo"].ToString();
        }

        public string getMaxReceiptNo()
        {
            return MySQLHelper.ExecuteDataTable(DBConnection.connectionString, CommandType.Text, "SELECT CONCAT('R', LPAD(CONVERT(SUBSTRING((SELECT MAX(CAST(SUBSTRING(r.ReceiptNo, 2, 5) AS UNSIGNED)) FROM receipt r WHERE r.ReceiptNo LIKE 'R%'), 1), SIGNED integer), 4, '0')) AS ReceiptNo").Rows[0]["ReceiptNo"].ToString();
        }

        public string getMaxMemNo()
        {
            return MySQLHelper.ExecuteDataTable(DBConnection.connectionString, CommandType.Text, "SELECT MAX(CAST(m.MembershipNo AS UNSIGNED)) AS MemNo FROM member m").Rows[0]["MemNo"].ToString();
        }

        public bool checkIDVal(string identificationNo, bool IsNewRecord, string memberKey = null)
        {
            if (IsNewRecord)
            {
                MySqlParameter[] para = new MySqlParameter[1];
                para[0] = new MySqlParameter("@IdentificationNo", identificationNo);
                return Convert.ToInt32(MySQLHelper.ExecuteDataTable(DBConnection.connectionString, CommandType.Text, "SELECT COUNT(*) AS `Count` FROM vw_allmemberdata va WHERE va.IdentificationNo = @IdentificationNo;", para).Rows[0]["Count"].ToString()) > 0;
            }
            else
            {
                MySqlParameter[] para = new MySqlParameter[2];
                para[0] = new MySqlParameter("@IdentificationNo", identificationNo);
                para[1] = new MySqlParameter("@Key", memberKey);
                return Convert.ToInt32(MySQLHelper.ExecuteDataTable(DBConnection.connectionString, CommandType.Text, "SELECT COUNT(*) AS `Count` FROM vw_allmemberdata va WHERE va.IdentificationNo = @IdentificationNo OR va.`KEY`= @Key", para).Rows[0]["Count"].ToString()) != 1;
            }
        }
    }
}
