using OBALog.Data;
using OBALog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBALog.Business
{
    public class BL_Member
    {
        public int insert(ML_Member member)
        {
            return new DL_Member().insert(member);
        }
        public System.Data.DataTable selectMemberTop20()
        {
            return new DL_Member().selectMemberTop20();

        }

        public System.Data.DataTable selectMemberLastUpdatedTop20()
        {
            return new DL_Member().selectMemberLastUpdatedTop20();
        }
    }
}
