using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ModelViewLib.ModelViews
{
    public class User
    {

        public User(string Login, string Password, string Name)
        {
            this.Login = Login;
            this.Password = Password;
            this.Name = Name;
        }

        public string Login {  get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
    }
}
