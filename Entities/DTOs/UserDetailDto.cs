using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class UserDetailDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int CountryCode { get; set; }
        public string Country { get; set; }
        public int StatusCode { get; set; }
        public string Status { get; set; }
        public string StatusDescription { get; set; }
    }
}
