//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Headway.Data.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class ConfigItem
    {
        public int ConfigItemId { get; set; }
        public int ConfigId { get; set; }
        public bool IsIdentity { get; set; }
        public bool IsTitle { get; set; }
        public int Order { get; set; }
        public string ComponentArgs { get; set; }
        public string ConfigName { get; set; }
        public Nullable<int> ConfigContainerId { get; set; }
        public string PropertyName { get; set; }
        public string Label { get; set; }
        public string Tooltip { get; set; }
        public string Component { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
    
        public virtual ConfigContainer ConfigContainer { get; set; }
        public virtual Config Config { get; set; }
    }
}
