//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DentAda.Data.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class ANNOUNCEMENT
    {
        public long IdAnnouncement { get; set; }
        public long OperationIdUserRef { get; set; }
        public string OperationIP { get; set; }
        public System.DateTime OperationDate { get; set; }
        public short OperationIsDeleted { get; set; }
        public string MessageSubject { get; set; }
        public string MessageContent { get; set; }
        public Nullable<System.DateTime> MessageDate { get; set; }
        public string MessageIcon { get; set; }
        public short Priority { get; set; }
        public string Area { get; set; }
        public bool IsVisibleToMain { get; set; }
    
        public virtual SystemUser SystemUser { get; set; }
    }
}
