﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeShop.Business.Dtos
{
    public class AddUserDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName{ get; set; }
        public string LastName { get; set; }

    }
}
