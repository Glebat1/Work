//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ВКР_общежитие
{
    using System;
    using System.Collections.Generic;
    
    public partial class Storage
    {
        public int ID { get; set; }
        public string Артикул { get; set; }
        public Nullable<int> id_Поставщика { get; set; }
        public Nullable<int> id_Типа { get; set; }
        public Nullable<int> id_Товарной_накладной { get; set; }
        public string Наименование { get; set; }
        public Nullable<int> id_Ед_измерения { get; set; }
        public Nullable<int> На_Складе { get; set; }
        public string Минимальный_запас { get; set; }
    
        public virtual Provider Provider { get; set; }
        public virtual StorageType StorageType { get; set; }
        public virtual TowarNakl TowarNakl { get; set; }
        public virtual Unit Unit { get; set; }
    }
}
