// ReSharper disable VirtualMemberCallInConstructor
using System;
using System.Collections.Generic;

using FoodForHome.Data.Common.Models;

using Microsoft.AspNetCore.Identity;

namespace FoodForHome.Data.Models
{
    public class ApplicationUser : IdentityUser, IAuditInfo, IDeletableEntity
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Roles = new HashSet<IdentityUserRole<string>>();
            this.Claims = new HashSet<IdentityUserClaim<string>>();
            this.Logins = new HashSet<IdentityUserLogin<string>>();
            this.Dishes = new HashSet<ApplicationUserDish>();
            this.Orders = new HashSet<Order>();
            this.Cart = new HashSet<OrderDetail>();
        }

        public string FullName { get; set; }

        // Audit info
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        // Deletable entity
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<OrderDetail> Cart { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }

        public virtual ICollection<ApplicationUserDish> Dishes { get; set; }

        public virtual ICollection<Ingredient> Ingredients { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
