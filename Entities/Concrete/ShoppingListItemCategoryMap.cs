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
    public class ShoppingListItemCategoryMap: IEntity  // ShoppingList-ShoppingListItem map tablosu için
    {                                                  // TODO: isim revize olabilir
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ShoppingListItemId { get; set; }
        public int ShoppingListId { get; set; }
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        [ForeignKey("ShoppingListId")]
        public ShoppingList ShoppingList { get; set; }

        [ForeignKey("ShoppingListItemId")]
        public ShoppingListItem ShoppingListItem { get; set; }

    }
}
