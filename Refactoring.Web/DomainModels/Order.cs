using System;

namespace Refactoring.Web.DomainModels {
    public class Order {
        public string Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public decimal Total { get; set; } 
        public string OrderType { get; set; }
        public string Status { get; set; }
        public string District { get; set; }
        public Advert Advert { get; set; }
    }
}