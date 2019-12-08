using DTO;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class CartItem
    {
        [Key]
        public string ItemId { get; set; }

        public string CartId { get; set; }

        public int Quantity { get; set; }

        public System.DateTime DateCreated { get; set; }

        public int DishesId { get; set; }

        public virtual Dishes dishes{ get; set; }

    }
}