using Nedeljni1_Andreja_Kolesar.Command;
using Nedeljni1_Andreja_Kolesar.Service;
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
    class SystemAdministratorViewModel:ViewModelBase
    {
        #region property
        SystemAdministrator sa;
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


        #endregion
        #region constructor
        public SystemAdministratorViewModel(SystemAdministrator open)
        {
            sa = open;
            sectorList = Service.Service.GetSectorList();
        }
        #endregion


        #region log out
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
                sa.Close();
                login.ShowDialog();

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

        #region Add Position
        private ICommand _addPosition;
        public ICommand addPosition
        {
            get
            {
                if (_addPosition == null)
                {
                    _addPosition = new RelayCommand(param => AddPositionExecute(), param => CanAddPositionExecute());
                }
                return _addPosition;
            }
        }

        private void AddPositionExecute()
        {
            try
            {
                AddPosition addPosition = new AddPosition();
                addPosition.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanAddPositionExecute()
        {
            return true;
        }
        #endregion


        #region Add Sector
        private ICommand _addSector;
        public ICommand addSector
        {
            get
            {
                if (_addSector == null)
                {
                    _addSector = new RelayCommand(param => AddSectorExecute(), param => CanAddSectorExecute());
                }
                return _addSector;
            }
        }

        private void AddSectorExecute()
        {
            try
            {
                AddSector addSector = new AddSector();
                addSector.ShowDialog();
                if ((addSector.DataContext as AddSectorViewModel).isUpdated == true)
                {
                    sectorList = Service.Service.GetSectorList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanAddSectorExecute()
        {
            return true;
        }
        #endregion
    }
}
