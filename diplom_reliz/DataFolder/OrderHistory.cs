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
    
    public partial class OrderHistory
    {
        public int IdOrderHistory { get; set; }
        public int IdOrder { get; set; }
        public int IdProduct { get; set; }
        public int QuantityProduct { get; set; }
        public string Price { get; set; }
        public string AmountOrder { get; set; }
        public int IdOrderStatusHistory { get; set; }
    
        public virtual Orders Orders { get; set; }
        public virtual Product Product { get; set; }
        public virtual StatusOrderHistory StatusOrderHistory { get; set; }
    }
}