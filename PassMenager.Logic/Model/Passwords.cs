using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace PassMenager.Logic.Model
{
    public class Passwords
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string LoginName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string URL { get; set; }
        public string Details { get; set; }
    }
}
