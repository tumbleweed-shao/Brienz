using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Brienz.Util
{
    public class ActionStructure
    {
       public string Subject { get; set; }
       public string Location { get; set; }
       public string FromResource { get;set;}
       public ActionPriorityEnum Priority { get; set; }
       public DateTime StartTime { get; set; }
       public DateTime EndTime { get; set; }
       public bool IsAllDayEvent { get; set; }
       public string InnerHTML { get; set; }
    }
}
