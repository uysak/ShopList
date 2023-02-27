using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class ShoppingListItemForUpdateDTO
    {
        public int Quantity { get; set; }
        public string Note { get; set; }
    }
}
