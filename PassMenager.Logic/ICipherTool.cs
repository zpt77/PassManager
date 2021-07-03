using System;
using System.Collections.Generic;
using System.Text;

namespace PassMenager.Logic
{
    public interface ICipherTool
    {
        public int Key { get; }
        public char Cipher(char ch, int key);
        public string Encipher(string input, int key);
        public string Decipher(string input, int key);
            
    }
}
