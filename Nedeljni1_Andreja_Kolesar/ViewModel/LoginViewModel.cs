using Nedeljni1_Andreja_Kolesar.Command;
using Nedeljni1_Andreja_Kolesar.Model;
using Nedeljni1_Andreja_Kolesar.Service;
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
                tblUser user = Service.Service.GetUser(person.username, person.password);
                if (user == null)
                {
                    if (person.username == "WPFMaster" && person.password == "WPFAccess")
                    {
                        Owner owner = new Owner();
                        login.Close();
                        owner.Show();
                        
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password.Try again");
                    }
                }
                else
                {
                    if (Service.Service.isAdministrator(user) != null)
                    {
                        tblAdministrator a = Service.Service.isAdministrator(user);
                        string type = Service.Service.TypeOfAdmin(a);
                        if (type == "Local")
                        {
                            LocalAdministrator la = new LocalAdministrator();
                            login.Close();
                            la.ShowDialog();
                           
                        }
                        else if (type == "Team")
                        {

                        }
                        else
                        {

                        }
                    }
                    else if (Service.Service.isEmployee(user) != null)
                    {
                        tblEmployee e = Service.Service.isEmployee(user);
                        Employee employee = new Employee();
                        login.Close();
                        employee.Show();
                        
                    }
                    else
                    {
                        tblManager m = Service.Service.isManager(user);
                        if (m.levelOfResponsibility != null)
                        {
                            Manager manager = new Manager();
                            login.Close();
                            manager.Show();
                            
                        }
                        else
                        {
                            MessageBox.Show("Please wait until the Local administrator assigns a level of responsibility");
                        }
                    }
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
