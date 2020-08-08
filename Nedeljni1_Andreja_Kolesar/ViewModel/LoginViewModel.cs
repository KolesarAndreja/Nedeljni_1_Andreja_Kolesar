using Nedeljni1_Andreja_Kolesar.Command;
using Nedeljni1_Andreja_Kolesar.Model;
using Nedeljni1_Andreja_Kolesar.View;
using System;
using System.IO;
using System.Windows;
using System.Windows.Input;

namespace Nedeljni1_Andreja_Kolesar.ViewModel
{
    class LoginViewModel:ViewModelBase
    {
        Login login;
        private int counter=0;

        #region constructor
        public LoginViewModel(Login openLogin)
        {
            login = openLogin;
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

            //try
            //{
            //    currentUser.password = (obj as PasswordBox).Password;
            //    currentUser = Service.Service.GetUserByUsernameAndPsw(currentUser.username, currentUser.password);
            //    if (currentUser == null)
            //    {
            //        MessageBox.Show("Invalid username or password.Try again");
            //        currentUser = new tblUser();
            //    }
            //    else
            //    {
            //        if (Service.Service.isPatient(currentUser) != null)
            //        {
            //            tblPatient currentPatient = Service.Service.isPatient(currentUser);
            //            Patient pat = new Patient(currentPatient);
            //            login.Close();
            //            pat.Show();
            //        }
            //        else
            //        {
            //            tblDoctor currentDoctor = Service.Service.isDoctor(currentUser);
            //            Doctor doc = new Doctor(currentDoctor);
            //            login.Close();
            //            doc.Show();
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}
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
