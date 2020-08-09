using Nedeljni1_Andreja_Kolesar.Command;
using Nedeljni1_Andreja_Kolesar.Service;
using Nedeljni1_Andreja_Kolesar.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Nedeljni1_Andreja_Kolesar.ViewModel
{
    class RegistrationViewModel:ViewModelBase
    {
        #region Prop
        Registration registration;
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

        private tblManager _newManager;
        public tblManager newManager
        {
            get
            {
                return _newManager;
            }
            set
            {
                _newManager = value;
                OnPropertyChanged("newManager");
            }
        }

        private tblEmployee _newEmployee;
        public tblEmployee newEmployee
        {
            get
            {
                return _newEmployee;
            }
            set
            {
                _newEmployee = value;
                OnPropertyChanged("newEmployee");
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

        #region list props
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

        private List<tblSector> _sectorList;
        public List<tblSector> sectorList
        {
            get
            {
                return _sectorList;
            }
            set
            {
                _sectorList = value;
                OnPropertyChanged("sectorList");
            }
        }

        private List<tblPosition> _positionList;
        public List<tblPosition> positionList
        {
            get
            {
                return _positionList;
            }
            set
            {
                _positionList = value;
                OnPropertyChanged("positionList");
            }
        }


        private List<tblProfessionalQualification> _qualificationList;
        public List<tblProfessionalQualification> qualificationList
        {
            get
            {
                return _qualificationList;
            }
            set
            {
                _qualificationList = value;
                OnPropertyChanged("qualificationList");
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

        private tblSector _selectedSector;
        public tblSector selectedSector
        {
            get
            {
                return _selectedSector;
            }
            set
            {
                _selectedSector = value;
                OnPropertyChanged("selectedSector");
            }
        }

        private tblPosition _selectedPosition;
        public tblPosition selectedPosition
        {
            get
            {
                return _selectedPosition;
            }
            set
            {
                _selectedPosition = value;
                OnPropertyChanged("selectedPosition");
            }
        }

        private tblProfessionalQualification _selectedQualification;
        public tblProfessionalQualification selectedQualification
        {
            get
            {
                return _selectedQualification;
            }
            set
            {
                _selectedQualification = value;
                OnPropertyChanged("selectedQualification");
            }
        }
        #endregion

        #region constructor
        public RegistrationViewModel(Registration open)
        {
            registration = open;
            newUser = new tblUser();
            newManager = new tblManager();
            newEmployee = new tblEmployee();
            //gender
            selectedGender = new tblGender();
            genderList = Service.Service.GetGenderList();
            //sector
            selectedSector = new tblSector();
            sectorList = Service.Service.GetSectorList();
            //marital status
            selectedMarital = new tblMarriageStatu();
            maritalList = Service.Service.GetMaritalStatusList();
            //position
            selectedPosition = new tblPosition();
            positionList = Service.Service.GetPositionList();
            //qualification
            selectedQualification = new tblProfessionalQualification();
            qualificationList = Service.Service.GetQualificationList();
            
        }
        #endregion

        #region Visibility
        private Visibility _buttonViewManager = Visibility.Visible;
        public Visibility buttonViewManager
        {
            get
            {
                return _buttonViewManager;
            }
            set
            {
                _buttonViewManager = value;
                OnPropertyChanged("buttonViewManager");
            }
        }

        private Visibility _viewUser = Visibility.Collapsed;
        public Visibility viewUser
        {
            get
            {
                return _viewUser;
            }
            set
            {
                _viewUser = value;
                OnPropertyChanged("viewUser");
            }
        }

        private Visibility _viewManager = Visibility.Collapsed;
        public Visibility viewManager
        {
            get
            {
                return _viewManager;
            }
            set
            {
                _viewManager = value;
                OnPropertyChanged("viewManager");
            }
        }
        private Visibility _viewEmployee = Visibility.Collapsed;
        public Visibility viewEmployee
        {
            get
            {
                return _viewEmployee;
            }
            set
            {
                _viewEmployee = value;
                OnPropertyChanged("viewEmployee");
            }
        }
        private ICommand _createManager;
        public ICommand createManager
        {
            get
            {
                if (_createManager == null)
                {
                    _createManager = new RelayCommand(param => CreateManagerExecute(), param => CanCreateManagerExecute());
                }
                return _createManager;
            }
        }

        private void CreateManagerExecute()
        {

            try
            {
                MessageBoxResult result = MessageBox.Show("Do you realy want to register a manager?", "Manager registration", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    ManagerAccess access = new ManagerAccess();
                    access.ShowDialog();
                    if ((access.DataContext as ManagerAccessViewModel).isSuccessful == true)
                    {
                        if (viewEmployee == Visibility.Visible)
                        {
                            viewEmployee = Visibility.Collapsed;
                        }
                        viewUser = Visibility.Visible;
                        viewManager = Visibility.Visible;
                    }
                    else
                    {
                        buttonViewManager = Visibility.Hidden;
                    }
                   
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanCreateManagerExecute()
        {
            return true;
        }

        private ICommand _createEmployee;
        public ICommand createEmployee
        {
            get
            {
                if (_createEmployee == null)
                {
                    _createEmployee = new RelayCommand(param => CreateEmployeeExecute(), param => CanCreateEmployeeExecute());
                }
                return _createEmployee;
            }
        }

        private void CreateEmployeeExecute()
        {

            try
            {
                List<tblManager> allManagers = Service.Service.GetManagerList();
                if(allManagers.Count == 0)
                {
                    MessageBox.Show("It is impossible to register an employee at this time as there are no registered managers.");
                }
                else 
                {
                    if (sectorList.Count == 0)
                    {
                        MessageBox.Show("It is impossible to register an employee at this time as there are no available sectors.");
                    }
                    else
                    {
                        if (viewManager == Visibility.Visible)
                        {
                            viewManager = Visibility.Hidden;
                        }
                        viewUser = Visibility.Visible;
                        viewEmployee = Visibility.Visible;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanCreateEmployeeExecute()
        {
            return true;
        }
        #endregion

        #region Commands

        private ICommand _save1;
        public ICommand save1
        {
            get
            {
                if (_save1 == null)
                {
                    _save1 = new RelayCommand(SaveExecute,CanSaveExecute);
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
                newManager.userId = u.userId;
                newManager.backupPassword += "WPF";
                tblManager m = Service.Service.AddManager(newManager);

                if (u != null && m != null)
                {
                    MessageBox.Show("Manager has been registered.");
                    registration.Close();
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

        private ICommand _save2;
        public ICommand save2
        {
            get
            {
                if (_save2 == null)
                {
                    _save2 = new RelayCommand(Save2Execute,CanSave2Execute);
                }
                return _save2;
            }
        }

        private void Save2Execute(object obj)
        {
            try
            {
                currentPassword = (obj as PasswordBox).Password;
                newUser.password = currentPassword;
                newUser.genderId = selectedGender.genderId;
                newUser.marriageStatusId = selectedMarital.marriageStatusId;
                tblUser u = Service.Service.AddUser(newUser);
                newEmployee.userID = u.userId;
                newEmployee.sectorId = selectedSector.sectorId;
                newEmployee.qualificationsId = selectedQualification.qualificationsId;
              
                //get random manager
                Random rnd = new Random();
                List<tblManager> allManagers = Service.Service.GetManagerList();
                int i = rnd.Next(0, allManagers.Count);
                newEmployee.managerId = allManagers[i].managerId;

                tblEmployee e = Service.Service.AddEmployee(newEmployee);

                if (u != null && e != null)
                {
                    MessageBox.Show("Employee has been registered.");
                    registration.Close();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanSave2Execute(object obj)
        {
            //if (!String.IsNullOrEmpty(newUser.fullname) && !String.IsNullOrEmpty(newUser.JMBG) && !String.IsNullOrEmpty(newUser.username) && !String.IsNullOrEmpty(newUser.password) && !String.IsNullOrEmpty(newManager.account))
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
                registration.Close();

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
        #endregion
    }
}

