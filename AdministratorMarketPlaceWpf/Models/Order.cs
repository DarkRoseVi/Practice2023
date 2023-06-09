//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AdministratorMarketPlaceWpf.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            this.ProductOrder = new HashSet<ProductOrder>();
        }
    
        public int Id { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<System.DateTime> DateEnd { get; set; }
        public Nullable<int> TypePaymentId { get; set; }
        public Nullable<int> DeliveryTypeId { get; set; }
        public string AdressDelivery { get; set; }
        public string Check { get; set; }
        public Nullable<int> DeliveryPointId { get; set; }
        public Nullable<decimal> Sum { get; set; }
        public Nullable<int> EmployeeId { get; set; }
    
        public virtual DeliveryPoint DeliveryPoint { get; set; }
        public virtual DeliveryType DeliveryType { get; set; }
        public virtual TypePayment TypePayment { get; set; }
        public virtual Useer Useer { get; set; }
        public virtual Useer Useer1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductOrder> ProductOrder { get; set; }
    }
}
