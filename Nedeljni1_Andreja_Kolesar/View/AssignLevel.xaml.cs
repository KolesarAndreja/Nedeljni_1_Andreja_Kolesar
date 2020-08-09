using Nedeljni1_Andreja_Kolesar.Service;
using Nedeljni1_Andreja_Kolesar.ViewModel;
using System.Windows;

namespace Nedeljni1_Andreja_Kolesar.View
{
    /// <summary>
    /// Interaction logic for AssignLevel.xaml
    /// </summary>
    public partial class AssignLevel : Window
    {
        public AssignLevel(vwManager manager)
        {
            InitializeComponent();
            this.DataContext = new AssignLevelViewModel(this,manager);
        }
    }
}
