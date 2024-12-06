using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DefaultUserNamespace;

namespace qq
{
    internal class TeacherClass:DefaultUser
    {
        public string number { get; set; }
        public string email { get; set; }
    }
}
