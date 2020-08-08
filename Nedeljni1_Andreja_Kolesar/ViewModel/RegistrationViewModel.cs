﻿using Nedeljni1_Andreja_Kolesar.Command;
using Nedeljni1_Andreja_Kolesar.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Nedeljni1_Andreja_Kolesar.ViewModel
{
    class RegistrationViewModel:ViewModelBase
    {
        #region Prop
        Registration registration;
        //private tblUser _newUser;
        //public tblUser newUser
        //{
        //    get
        //    {
        //        return _newUser;
        //    }
        //    set
        //    {
        //        _newUser = value;
        //        OnPropertyChanged("newUser");
        //    }
        //}

        //private tblDoctor _newDoctor;
        //public tblDoctor newDoctor
        //{
        //    get
        //    {
        //        return _newDoctor;
        //    }
        //    set
        //    {
        //        _newDoctor = value;
        //        OnPropertyChanged("newDoctor");
        //    }
        //}

        //private tblPatient _newPatient;
        //public tblPatient newPatient
        //{
        //    get
        //    {
        //        return _newPatient;
        //    }
        //    set
        //    {
        //        _newPatient = value;
        //        OnPropertyChanged("newPatient");
        //    }
        //}

        //private List<vwDoctor> _doctorList;
        //public List<vwDoctor> doctorList
        //{
        //    get
        //    {
        //        return _doctorList;
        //    }
        //    set
        //    {
        //        _doctorList = value;
        //        OnPropertyChanged("doctorList");
        //    }
        //}



        //private vwDoctor _selectedDoctor;
        //public vwDoctor selectedDoctor
        //{
        //    get
        //    {
        //        return _selectedDoctor;
        //    }
        //    set
        //    {
        //        _selectedDoctor = value;
        //        OnPropertyChanged("selectedDoctor");
        //    }
        //}
        #endregion

        #region constructor
        public RegistrationViewModel(Registration open)
        {
            registration = open;
            //newUser = new tblUser();
            //newDoctor = new tblDoctor();
            //newPatient = new tblPatient();
            //selectedDoctor = new vwDoctor();
            //doctorList = Service.Service.GetDoctorsList();
        }
        #endregion

        #region Visibility
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

                if (viewEmployee == Visibility.Visible)
                {
                    viewEmployee = Visibility.Collapsed;
                }
                viewUser = Visibility.Visible;
                viewManager = Visibility.Visible;
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
                //if (doctorList.Count == 0)
                //{
                //    MessageBox.Show("It is impossible to register a patient at this time as there are no registered doctors");
                //}
                //else
                //{
                    if (viewManager == Visibility.Visible)
                    {
                        viewManager = Visibility.Hidden;
                    }
                    viewUser = Visibility.Visible;
                    viewEmployee = Visibility.Visible;
                //}
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
                    _save1 = new RelayCommand(param => SaveExecute(), param => CanSaveExecute());
                }
                return _save1;
            }
        }

        private void SaveExecute()
        {
            try
            {
                //tblUser u = Service.Service.AddUser(newUser);
                //newPatient.userId = u.userId;
                //newPatient.doctorId = selectedDoctor.doctorId;
                //tblPatient p = Service.Service.AddPatient(newPatient);

                //if (u != null && p != null)
                //{
                //    MessageBox.Show("Patient has been registered.");
                //    registration.Close();
                //}

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanSaveExecute()
        {
            //if (!String.IsNullOrEmpty(newUser.fullname) && !String.IsNullOrEmpty(newUser.JMBG) && !String.IsNullOrEmpty(newUser.username) && !String.IsNullOrEmpty(newUser.password) && !String.IsNullOrEmpty(newPatient.cardNumber) && selectedDoctor.doctorId != 0)
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
                    _save2 = new RelayCommand(param => Save2Execute(), param => CanSave2Execute());
                }
                return _save2;
            }
        }

        private void Save2Execute()
        {
            try
            {
                //tblUser u = Service.Service.AddUser(newUser);
                //newDoctor.userId = u.userId;
                //tblDoctor p = Service.Service.AddDoctor(newDoctor);

                //if (u != null && p != null)
                //{
                //    MessageBox.Show("Doctor has been registered.");
                //    registration.Close();
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanSave2Execute()
        {
            //if (!String.IsNullOrEmpty(newUser.fullname) && !String.IsNullOrEmpty(newUser.JMBG) && !String.IsNullOrEmpty(newUser.username) && !String.IsNullOrEmpty(newUser.password) && !String.IsNullOrEmpty(newDoctor.account))
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

