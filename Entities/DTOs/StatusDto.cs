using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class StatusDto
    {
        public string StatusName { get; set; }
        public string? StatusDescription { get; set; }
    }
}
