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
    
    public partial class Comment
    {
        public int IdComment { get; set; }
        public Nullable<int> IdProduct { get; set; }
        public string TextComment { get; set; }
        public System.DateTime DateComment { get; set; }
    
        public virtual Product Product { get; set; }
    }
}
