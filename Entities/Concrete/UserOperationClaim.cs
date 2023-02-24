using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class UserOperationClaim : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ClaimId { get; set; }


        [ForeignKey("UserId")]
        public User User { get; set; }

        [ForeignKey("ClaimId")]
        public OperationClaim OperationClaim { get; set; }

    }
}
