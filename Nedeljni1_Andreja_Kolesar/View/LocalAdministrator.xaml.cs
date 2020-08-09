using Nedeljni1_Andreja_Kolesar.ViewModel;
using System.Windows;

namespace Nedeljni1_Andreja_Kolesar.View
{
    /// <summary>
    /// Interaction logic for LocalAdministrator.xaml
    /// </summary>
    public partial class LocalAdministrator : Window
    {
        public LocalAdministrator()
        {
            InitializeComponent();
            this.DataContext = new LocalAdministratorViewModel(this);
        }
    }
}
