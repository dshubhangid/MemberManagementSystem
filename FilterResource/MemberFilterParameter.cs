using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemberManagementSystem.FilterResource
{

    public enum BalanceConditionEnum
    {
        EqualTo,
        GreaterThan,
        LessThan
    }

    public class MemberFilterParameter
    {
        public int Points { get; set; }

        public BalanceConditionEnum condition { get; set; }

        public string Status { get; set; }
    }
}
