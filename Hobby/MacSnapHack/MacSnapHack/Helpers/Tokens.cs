using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MacSnapHack
{
    public static class Tokens
    {
        /// <summary>
        ///     Generates a Request Token from Post Data and a Static Token
        /// </summary>
        /// <param name="postData">The Html Encoded Post Data</param>
        /// <param name="staticToken">The Snapchat Static Token.</param>
        /// <returns>The Request Token, all nice.</returns>
        public static string GenerateRequestToken(string postData, string staticToken)
        {
            string s1 = KeyVault.Secret + postData;
            string s2 = staticToken + KeyVault.Secret;

            string s3 = "";
            string s4 = "";
            SHA256Managed crypt = new SHA256Managed();
            byte[] crypto1 = crypt.ComputeHash(Encoding.UTF8.GetBytes(s1), 0, Encoding.UTF8.GetByteCount(s1));
            byte[] crypto2 = crypt.ComputeHash(Encoding.UTF8.GetBytes(s2), 0, Encoding.UTF8.GetByteCount(s2));
            foreach (byte bit in crypto1)
            {
                s3 += bit.ToString("x2");
            }
            foreach (byte bit in crypto2)
            {
                s4 += bit.ToString("x2");
            }

            string output = "";
            for (int i = 0; i < KeyVault.HashingPattern.Length; i++)
            {
                char c = KeyVault.HashingPattern[i];

                if (c == '0')
                    output += s3[i];
                else
                    output += s4[i];
            }
            return output;
        }
    }
}
