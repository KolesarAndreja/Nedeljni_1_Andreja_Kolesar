using Nedeljni1_Andreja_Kolesar.ViewModel;
using System.Windows;

namespace Nedeljni1_Andreja_Kolesar.View
{
    /// <summary>
    /// Interaction logic for SystemAdministrator.xaml
    /// </summary>
    public partial class SystemAdministrator : Window
    {
        public SystemAdministrator()
        {
            InitializeComponent();
            this.DataContext = new SystemAdministratorViewModel(this);
        }
    }
}
