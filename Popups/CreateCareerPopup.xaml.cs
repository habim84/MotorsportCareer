using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MotorsportCareer.Popups
{
    /// <summary>
    /// Interaction logic for CreateCareerPopup.xaml
    /// </summary>
    public partial class CreateCareerPopup : Window
    {

        public enum CreateCareerTemplateMode
        {
            EditExisting,
            CreateNew,
            CloneExisting
        }

        public CreateCareerTemplateMode templateMode;

        public CreateCareerPopup()
        {
            InitializeComponent();
        }


        // TODO: Load existing templates to modify
        private void OnEditExistingClick(object sender, RoutedEventArgs e)
        {
            templateMode = CreateCareerTemplateMode.EditExisting;
            Window.GetWindow(this).DialogResult = true;
            Window.GetWindow(this).Close();
        }

        // TODO: Create completely new career template
        private void OnCreateNewClick(object sender, RoutedEventArgs e)
        {
            templateMode = CreateCareerTemplateMode.CreateNew;
            Window.GetWindow(this).DialogResult = true;
            Window.GetWindow(this).Close();
        }

        // TODO: Clone existing template to modify
        private void OnCloneExistingClick(object sender, RoutedEventArgs e)
        {
            templateMode = CreateCareerTemplateMode.CloneExisting;
            Window.GetWindow(this).DialogResult = true;
            Window.GetWindow(this).Close();

        }
    }
}
