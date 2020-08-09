using Nedeljni1_Andreja_Kolesar.ViewModel;
using System.Windows;

namespace Nedeljni1_Andreja_Kolesar.View
{
    /// <summary>
    /// Interaction logic for RegistrationAdministrator.xaml
    /// </summary>
    public partial class RegistrationAdministrator : Window
    {
        public RegistrationAdministrator()
        {
            InitializeComponent();
            this.DataContext = new RegistrationAdministratorViewModel(this);
        }
    }
}
