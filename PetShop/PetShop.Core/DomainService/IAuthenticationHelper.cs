﻿using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.DomainService
{
    public interface IAuthenticationHelper
    {
        string GenerateToken(Owner owner);
    }
}
