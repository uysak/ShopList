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
    public class ShoppingList : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int UserId { get; set; }

        [MaxLength(50)]
        public string ListName { get; set; }
        public bool isActive { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime CompletionDate { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

    }
}
