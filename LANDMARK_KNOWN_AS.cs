//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Bus_Application
{
    using System;
    using System.Collections.Generic;
    
    public partial class LANDMARK_KNOWN_AS
    {
        public int Known_As_ID { get; set; }
        public string Known_As_Description { get; set; }
        public int Landmark_FK { get; set; }
    
        public virtual LANDMARK LANDMARK { get; set; }
    }
}
