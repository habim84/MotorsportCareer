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
    /// Interaction logic for SetCareerNamePopup.xaml
    /// </summary>
    /// 
    
    public partial class SetCareerNamePopup : Window
    {
        public string careerName {
            get { return CareerNameTextBox.Text;  }
        }
        public SetCareerNamePopup()
        {
            InitializeComponent();
            CareerNameErrorLabel.Visibility = Visibility.Collapsed;
        }

        public void CreateCareerButton_Click(object sender, RoutedEventArgs e)
        {
            if (CareerNameTextBox.Text.Length != 0)
            {
                CareerNameErrorLabel.Visibility = Visibility.Collapsed;
                Window.GetWindow(this).DialogResult = true;
                Window.GetWindow(this).Close();
            } else
            {
                CareerNameErrorLabel.Visibility = Visibility.Visible;
            }
        }
    }
}
