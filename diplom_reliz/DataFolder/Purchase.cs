//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace diplom_reliz.DataFolder
{
    using System;
    using System.Collections.Generic;
    
    public partial class Purchase
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Purchase()
        {
            this.Orders = new HashSet<Orders>();
        }
    
        public int IdPurchase { get; set; }
        public string DatePurchase { get; set; }
        public string DescriptionProduct { get; set; }
        public Nullable<int> IdSupplier { get; set; }
        public string Price { get; set; }
        public Nullable<int> IdStatusPurchase { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Orders> Orders { get; set; }
        public virtual StatusPurchase StatusPurchase { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}
