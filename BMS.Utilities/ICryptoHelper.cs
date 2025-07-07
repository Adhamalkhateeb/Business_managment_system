using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS.Utilities
{
    internal interface ICryptoHelper
    {
        string ComputeHash(string input);
        string Encrypt(string input);
        string Decrypt(string encryptedInput);
    }
}
