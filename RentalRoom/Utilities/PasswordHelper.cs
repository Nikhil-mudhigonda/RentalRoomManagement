using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace RentalRoom.Utilities
{
    public static class PasswordHelper
    {
        public static string HashPassword(string password)
        {
            if(password != null)
            {
                using (SHA256 sha256 = SHA256.Create())
                {
                    byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                    StringBuilder sb = new StringBuilder();
                    foreach (byte b in bytes)
                    {
                        sb.Append(b.ToString("x2"));
                    }
                    return sb.ToString();
                }
            }
            return string.Empty;
        }
    }
}