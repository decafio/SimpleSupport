﻿// Generated by Xamasoft JSON Class Generator
// http://www.xamasoft.com/json-class-generator
// {"BaseObligation":854,"FormulaUsed":"Low Income Transition"}

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SimpleSupport.Models
{
    public class BaseSupport
    {
        [JsonProperty("BaseObligation")]
        public int BaseObligation { get; set; }

        [JsonProperty("FormulaUsed")]
        public string FormulaUsed { get; set; }
    }
}