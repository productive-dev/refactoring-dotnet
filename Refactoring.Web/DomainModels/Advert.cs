using System;

namespace Refactoring.Web.DomainModels {
    public class Advert {
        public DateTime CreatedOn { get; set; }
        public string Heading { get; set; } 
        public string ImageUrl { get; set; } 
        public string Content { get; set; } 
    }
}