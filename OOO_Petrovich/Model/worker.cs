//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OOO_Petrovich.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class worker
    {
        public int idWorker { get; set; }
        public string workerFullName { get; set; }
    
        public virtual user user { get; set; }
    }
}
