using Nedeljni1_Andreja_Kolesar.Command;
using Nedeljni1_Andreja_Kolesar.Service;
using Nedeljni1_Andreja_Kolesar.View;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Nedeljni1_Andreja_Kolesar.ViewModel
{
    class RegistrationAdministratorViewModel:ViewModelBase
    {
        RegistrationAdministrator registrationAdministrator;
        #region Prop

        private tblUser _newUser;
        public tblUser newUser
        {
            get
            {
                return _newUser;
            }
            set
            {
                _newUser = value;
                OnPropertyChanged("newUser");
            }
        }

        private tblAdministrator _newAdministrator;
        public tblAdministrator newAdministrator
        {
            get
            {
                return _newAdministrator;
            }
            set
            {
                _newAdministrator = value;
                OnPropertyChanged("newAdministrator");
            }
        }

        private string _currentPassword;
        public string currentPassword
        {
            get
            {
                return _currentPassword;
            }
            set
            {
                _currentPassword = value;
            }
        }
        #endregion

        #region lists
        private List<tblGender> _genderList;
        public List<tblGender> genderList
        {
            get
            {
                return _genderList;
            }
            set
            {
                _genderList = value;
                OnPropertyChanged("genderList");
            }
        }

        private List<tblMarriageStatu> _maritalList;
        public List<tblMarriageStatu> maritalList
        {
            get
            {
                return _maritalList;
            }
            set
            {
                _maritalList = value;
                OnPropertyChanged("maritalList");
            }
        }


        private List<tblAdminType> _typeList;
        public List<tblAdminType> typeList
        {
            get
            {
                return _typeList;;
            }
            set
            {
                _typeList = value;
                OnPropertyChanged("typeList");
            }
        }
        #endregion

        #region selected items
        private tblGender _selectedGender;
        public tblGender selectedGender
        {
            get
            {
                return _selectedGender;
            }
            set
            {
                _selectedGender = value;
                OnPropertyChanged("selectedGender");
            }
        }

        private tblMarriageStatu _selectedMarital;
        public tblMarriageStatu selectedMarital
        {
            get
            {
                return _selectedMarital;
            }
            set
            {
                _selectedMarital = value;
                OnPropertyChanged("selectedMarital");
            }
        }

        private tblAdminType _selectedType;
        public tblAdminType selectedType
        {
            get
            {
                return _selectedType;
            }
            set
            {
                _selectedType = value;
                OnPropertyChanged("selectedType");
            }
        }
        #endregion
        public RegistrationAdministratorViewModel(RegistrationAdministrator reg)
        {
            registrationAdministrator = reg;
            newUser = new tblUser();
            newAdministrator = new tblAdministrator();
            //gender
            genderList = Service.Service.GetGenderList();
            selectedGender = new tblGender();
            //marriage
            maritalList = Service.Service.GetMaritalStatusList();
            selectedMarital = new tblMarriageStatu();
            //type
            selectedType = new tblAdminType();
            typeList = Service.Service.GetTypeAdminList();
        }


        private ICommand _save1;
        public ICommand save1
        {
            get
            {
                if (_save1 == null)
                {
                    _save1 = new RelayCommand(SaveExecute, CanSaveExecute);
                }
                return _save1;
            }
        }

        private void SaveExecute(object obj)
        {
            try
            {
                currentPassword = (obj as PasswordBox).Password;
                newUser.password = currentPassword;
                newUser.genderId = selectedGender.genderId;
                newUser.marriageStatusId = selectedMarital.marriageStatusId;
                tblUser u = Service.Service.AddUser(newUser);
                newAdministrator.userId = u.userId;
                newAdministrator.adminTypeId = selectedType.adminTypeId;
                tblAdministrator a = Service.Service.AddAdministrator(newAdministrator);

                if (u != null && a != null)
                {
                    MessageBox.Show("Administrator has been created.");
                    registrationAdministrator.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanSaveExecute(object obj)
        {
            //if (!String.IsNullOrEmpty(newUser.fullname) && !String.IsNullOrEmpty(newUser.JMBG) && !String.IsNullOrEmpty(newUser.username) && !String.IsNullOrEmpty(newUser.password) && !String.IsNullOrEmpty(newPatient.cardNumber) && selectedGender.doctorId != 0)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
            return true;
        }

        private ICommand _logOut;
        public ICommand logOut
        {
            get
            {
                if (_logOut == null)
                {
                    _logOut = new RelayCommand(param => LogOutExecute(), param => CanLogOutExecute());
                }
                return _logOut;
            }
        }

        private void LogOutExecute()
        {
            try
            {
                Login login = new Login();
                registrationAdministrator.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanLogOutExecute()
        {
            return true;
        }
    }
}
