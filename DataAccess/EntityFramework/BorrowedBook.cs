//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccess.EntityFramework
{
    using System;
    using System.Collections.Generic;
    
    public partial class BorrowedBook
    {
        public int BookId { get; set; }
        public int ClientId { get; set; }
        public int Id { get; set; }
        public bool Returned { get; set; }
    
        public virtual Book Book { get; set; }
        public virtual Client Client { get; set; }
    }
}
