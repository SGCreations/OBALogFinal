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
    }
}
