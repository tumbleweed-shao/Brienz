using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Brienz.Util
{
    public enum ActionPriorityEnum
    {
        Low = 1,
        Middle,
        High,
        AlwaysShow
    }
    public enum FileProcessStatusEnum
    {
        Processed =1,
        OnGoing,
        Pending,
        NotStart,
        AllStatus
    }
    public enum AlertPriorityEnum
    {
        Low = 1,
        Middle,
        High,
        AlwaysShow
    }
}
