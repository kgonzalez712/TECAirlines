//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TECAirlinesDataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class AIRPLANE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AIRPLANE()
        {
            this.FLIGHTs = new HashSet<FLIGHT>();
        }
    
        public int AIRPLANE_ID { get; set; }
        public int PILOT_ID { get; set; }
    
        public virtual PILOT PILOT { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FLIGHT> FLIGHTs { get; set; }
    }
}
