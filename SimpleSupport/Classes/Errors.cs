using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web;

namespace SimpleSupport.Classes
{
    public enum ErrorsStrings
    {
        [Description("That Case was not found. Please select a case below.")]
        CaseNotFound,
        [Description("You do not have access to that Case. Please select a case below.")]
        CaseNoAccess,
        [Description("Sorry, we did not quite get what Case you wanted. Please select a case below.")]
        CaseNoInteger,
        [Description("Sorry, we did not quite get what Case you wanted. Please select a case below.")]
        NoCaseId,
        [Description("Please provide a <strong>Parent A</strong>.")]
        ParentAMissing,
        [Description("Please provide a <strong>Parent B</strong>.")]
        ParentBMissing,
        [Description("Please provide a <strong>Third Party</strong>.")]
        ThirdPartyMissing,
        [Description("Please provide a Parenting Time schedule for <strong>each</strong> child that is <strong>not</strong> in the custody of a Third Party.")]
        NeedParentingTime,
        [Description("There must be at least <strong>one</strong> child in the custody of the parents to create a Parenting Time Schedule.")]
        NoChildren
    }

    public class ErrorMessage
    {
        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }
    }
}