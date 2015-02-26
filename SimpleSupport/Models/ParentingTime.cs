namespace SimpleSupport.Models
{
    using System;
    using System.Collections.Generic;
    
    public class ParentingTime
    {
        public ParentingTime()
        {
            this.Children = new HashSet<Child>();
        }
    
        public int ParentingTimeId { get; set; }
        public bool SchoolAMonday { get; set; }
        public bool SchoolATuesday { get; set; }
        public bool SchoolAWednesday { get; set; }
        public bool SchoolAThursday { get; set; }
        public bool SchoolAFriday { get; set; }
        public bool SchoolASaturday { get; set; }
        public bool SchoolASunday { get; set; }
        public bool SchoolBMonday { get; set; }
        public bool SchoolBTuesday { get; set; }
        public bool SchoolBWednesday { get; set; }
        public bool SchoolBThursday { get; set; }
        public bool SchoolBFriday { get; set; }
        public bool SchoolBSaturday { get; set; }
        public bool SchoolBSunday { get; set; }
        public short SchoolWeeks { get; set; }
        public bool SummerAMonday { get; set; }
        public bool SummerATuesday { get; set; }
        public bool SummerAWednesday { get; set; }
        public bool SummerAThursday { get; set; }
        public bool SummerAFriday { get; set; }
        public bool SummerASaturday { get; set; }
        public bool SummerASunday { get; set; }
        public bool SummerBMonday { get; set; }
        public bool SummerBTuesday { get; set; }
        public bool SummerBWednesday { get; set; }
        public bool SummerBThursday { get; set; }
        public bool SummerBFriday { get; set; }
        public bool SummerBSaturday { get; set; }
        public bool SummerBSunday { get; set; }
        public short SummerWeeks { get; set; }
        public Nullable<short> MemorialDay { get; set; }
        public Nullable<short> LaborDay { get; set; }
        public Nullable<short> July4th { get; set; }
        public Nullable<short> ThanksGiving { get; set; }
        public Nullable<short> SpringBreak { get; set; }
        public Nullable<short> ChristmasEve { get; set; }
        public Nullable<short> ChristmasDay { get; set; }
        public Nullable<short> MothersDay { get; set; }
        public Nullable<short> FathersDay { get; set; }
        public Nullable<short> Offset { get; set; }
    
        // Foreign Keys
        public virtual ICollection<Child> Children { get; set; }
    }
}
