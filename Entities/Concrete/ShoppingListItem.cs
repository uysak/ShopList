using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class ShoppingListItem : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int ShoppingListId { get; set; }
        public int Quantity { get; set; }

        [MaxLength(255)]
        public string Note { get; set; }

        public List<ProductCategory>? ProductCategories { get; set; }

        [ForeignKey("ProductId")]
        public Product? Product { get; set; }
        [ForeignKey("ShoppingListId")]
        public ShoppingList? ShoppingList { get; set; }
    }
}