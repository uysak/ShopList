using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class ShoppingListItemForAddDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string Note { get; set; }
        public int ShoppingListId { get; set; }
    }
}