//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IssuancePointManegerMarketPlauceWpf.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Useer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Useer()
        {
            this.Chek = new HashSet<Chek>();
            this.DeliveryPoint = new HashSet<DeliveryPoint>();
            this.Order = new HashSet<Order>();
            this.Order1 = new HashSet<Order>();
            this.Review = new HashSet<Review>();
        }
    
        public int Id { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public Nullable<int> RoleId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public byte[] Photo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Chek> Chek { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DeliveryPoint> DeliveryPoint { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Order { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Order1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Review> Review { get; set; }
        public virtual Role Role { get; set; }
    }
}
