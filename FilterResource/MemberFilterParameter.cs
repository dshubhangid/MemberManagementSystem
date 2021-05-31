using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace MemberManagementSystem.FilterResource
{

    public enum BalanceConditionEnum
    {
        EqualTo,    
        GreaterThan,
        LessThan
    }

    public enum AccountStatusEnum
    {
        ACTIVE,
        INACTIVE
    }
    public class MemberFilterParameter
    {
      
        public int Points { get; set; }
        
        public BalanceConditionEnum condition { get; set;  }
        
        public AccountStatusEnum Status { get; set; }
    }
}
