using System;
using System.Collections.Generic;
using System.Text;

namespace PassMenager.Logic
{
    public class PassCryptor : ICipherTool
    {
        public int Key => 5;

        public char Cipher(char ch, int key)
        {
            if (!char.IsLetter(ch))
                return ch;

            char offset = char.IsUpper(ch) ? 'A' : 'a';
            return (char)((((ch + key) - offset) % 26) + offset);
        }

        public string Decipher(string input, int key)
        {
            return Encipher(input, 26 - key);
        }

        public string Encipher(string input, int key)
        {
            string output = string.Empty;

            foreach (char ch in input)
                output += Cipher(ch, key);

            return output;
        }
    }
}
