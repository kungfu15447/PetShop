using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.ExceptionHandling
{
    public interface IErrorFactory
    {
        void Invalid(string message);
    }
}
