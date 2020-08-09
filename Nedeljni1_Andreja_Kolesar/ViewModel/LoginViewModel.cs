using Nedeljni1_Andreja_Kolesar.Command;
using Nedeljni1_Andreja_Kolesar.Model;
using Nedeljni1_Andreja_Kolesar.View;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Nedeljni1_Andreja_Kolesar.ViewModel
{
    class LoginViewModel:ViewModelBase
    {
        Login login;
        private int counter=0;


        private Person _person;
        public Person person
        {
            get
            {
                return _person;
            }
            set
            {
                _person=value;
                OnPropertyChanged("person");
            }
        }
        #region constructor
        public LoginViewModel(Login openLogin)
        {
            login = openLogin;
            person = new Person();
            counter++;
            if (counter == 1)
            {
                Startup start = new Startup();
            }
            //currentUser = new tblUser();
        }
        #endregion

        #region Commands
        private ICommand _loginBtn;
        public ICommand loginBtn
        {
            get
            {
                if (_loginBtn == null)
                {
                    _loginBtn = new RelayCommand(LoginExecute, CanLoginExecute);
                }
                return _loginBtn;
            }
        }

        private void LoginExecute(object obj)
        {

            try
            {
                person.password = (obj as PasswordBox).Password;

                if(person.role == "owner")
                {
                    Owner owner = new Owner();
                    owner.Show();
                    login.Close();
                }
                else if(person.role == "manager")
                {
                    Manager manager = new Manager();
                    manager.Show();
                    login.Close();
                }
                else if(person.role == "administrator")
                {
                    Administrator administrator = new Administrator();
                    administrator.Show();
                    login.Close();
                }else if(person.role =="pending manager")
                {
                    MessageBox.Show("Please wait until the administrator assigns you a level of responsibility");
                }
                else
                {
                    MessageBox.Show("Invalid username or password.Try again");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanLoginExecute(object obj)
        {
            return true;
        }
        #endregion

        #region REGISTRATION

        private ICommand _registration;
        public ICommand registration
        {
            get
            {
                if (_registration == null)
                {
                    _registration = new RelayCommand(param => RegistrationExecute(), param => CanRegistrationExecute());
                }
                return _registration;
            }
        }

        private void RegistrationExecute()
        {
            try
            {
                Registration reg = new Registration();
                reg.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanRegistrationExecute()
        {
            return true;
        }
        #endregion

    }
}
