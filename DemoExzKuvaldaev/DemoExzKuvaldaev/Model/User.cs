using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace KalyuzhniyDemo
{
    public class User : INotifyPropertyChanged
    {
        private int id_;
        private string login_;
        private string password_;
        private int age_;
        private string name_;
        private string lastName_;
        private string fullName_;
        private int roleId_;
        private string roleName_;

        [DisplayName("ID")]
        public int Id
        {
            get { return id_; }
            set { id_ = value; OnPropertyChanged(); }
        }

        [DisplayName("Логин")]
        public string Login
        {
            get { return login_; }
            set { login_ = value; OnPropertyChanged(); }
        }

        [DisplayName("Пароль")]
        public string Password
        {
            get { return password_; }
            set { password_ = value; OnPropertyChanged(); }
        }

        [DisplayName("Возраст")]
        public int Age
        {
            get { return age_; }
            set { age_ = value; OnPropertyChanged(); }
        }

        [DisplayName("Имя")]
        public string Name
        {
            get { return name_; }
            set { name_ = value; OnPropertyChanged(); }
        }

        [DisplayName("Фамилия")]
        public string LastName
        {
            get { return lastName_; }
            set { lastName_ = value; OnPropertyChanged(); }
        }

        [DisplayName("Полное имя")]
        public string FullName
        {
            get { return fullName_; }
            set { fullName_ = value; OnPropertyChanged(); }
        }

        [DisplayName("ID роли")]
        public int RoleId
        {
            get { return roleId_; }
            set { roleId_ = value; OnPropertyChanged(); }
        }

        [DisplayName("Роль")]
        public string RoleName
        {
            get { return roleName_; }
            set { roleName_ = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
