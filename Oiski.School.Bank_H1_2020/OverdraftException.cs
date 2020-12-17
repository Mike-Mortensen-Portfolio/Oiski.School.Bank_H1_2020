using System;
using System.Collections.Generic;
using System.Text;

namespace Oiski.School.Bank_H1_2020
{
    public class OverdraftException : Exception
    {
        public OverdraftException (string message) : base(message)
        {
        }
    }
}