﻿using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class User : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int CountryCode { get; set; }
        public int PasswordAttemptCount { get; set; }
        public DateTime LastLogin { get; set; }
        public DateTime RegistrationDate { get; set; }

        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }


        public string RefreshToken { get; set; } = string.Empty;
        public DateTime TokenExpire { get; set; }
        public DateTime TokenCreated { get; set; }

    }
}
