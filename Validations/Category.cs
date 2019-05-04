//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OnlineFoodCorner
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Category
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Category()
        {
            this.Purchased_Items = new HashSet<Purchased_Item>();
        }
    
        public int CategoryId { get; set; }
        public int Id { get; set; }
        [DisplayAttribute(Name = "Category ame")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Category name is required")]
        public string CategoryName { get; set; }
        [DisplayAttribute(Name = "Description")]
        [DataType(DataType.Text)]
        public string Description { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Purchased_Item> Purchased_Items { get; set; }
    }
}
