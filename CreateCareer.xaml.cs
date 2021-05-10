using DynamicData;
using MotorsportCareer.Career;
using MotorsportCareer.Popups;
using Newtonsoft.Json;
using NodeNetwork.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace MotorsportCareer
{
    /// <summary>
    /// Interaction logic for CreateCareer.xaml
    /// </summary>
    public partial class CreateCareer : Page
    {
        private NetworkViewModel network;
        private List<SeriesNode> seriesNodes = new List<SeriesNode>();
        private string careerName;
        public CreateCareer()
        {
            InitializeComponent();
            this.network = new NetworkViewModel();

            //testing
            var node1 = new NodeViewModel();
            node1.Name = "FIA Karting 250cc";
            this.network.Nodes.Add(node1);

            var node1Input = new NodeInputViewModel();
            node1Input.Name = "Node 1 Input";
            node1.Inputs.Add(node1Input);

            var node2 = new NodeViewModel();
            node2.Name = "Formula 4";
            this.network.Nodes.Add(node2);

            var node2Output = new NodeOutputViewModel();
            node2Output.Name = "Node 2 Output";
            node2.Outputs.Add(node2Output);

            CareerNetworkView.ViewModel = network;

            // Set stack panel and button visibility states
            SeriesStackPanel.Visibility = Visibility.Collapsed;
            SeriesPanelButton.Visibility = Visibility.Visible;

            // TODO: Complete the Template Popup
            // Template Popup 
            CreateCareerPopup templatePopup = new CreateCareerPopup();
            if (templatePopup.ShowDialog().Value)
            {
                if (templatePopup.templateMode == CreateCareerPopup.CreateCareerTemplateMode.CloneExisting)
                {
                    Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

                    dlg.DefaultExt = ".json";
                    dlg.Filter = "Career Save (.json)|*.json";

                    Nullable<bool> result = dlg.ShowDialog();
                    if (result == true)
                    {
                        // Get selected file
                        //dlf.File Name

                    }
                }
                else if (templatePopup.templateMode == CreateCareerPopup.CreateCareerTemplateMode.CreateNew)
                {

                } else if (templatePopup.templateMode == CreateCareerPopup.CreateCareerTemplateMode.EditExisting)
                {

                }
            }

            // Define career name
            SetCareerNamePopup nameWindow = new SetCareerNamePopup();
            if (nameWindow.ShowDialog().Value)
            {
                this.careerName = nameWindow.careerName;
            }
        }

        /**
         * Function to add new series Node onto the career*/
        private void OnAddSeriesClick(object sender, RoutedEventArgs e)
        {
            var newSeriesNode = new NodeViewModel();
            string seriesName = SeriesNameEdit.Text;
            string licenseName = LicenseEdit.Text;
            if (seriesName.Length != 0)
            {
                string gameName = GameEdit.Text;
                newSeriesNode.Name = String.Format("{0} - {1}", seriesName, gameName);
                SeriesNode newSeries = new SeriesNode(seriesName, gameName, licenseName);
                this.seriesNodes.Add(newSeries);
                this.network.Nodes.Add(newSeriesNode);
                SeriesStackPanel.Visibility = Visibility.Collapsed;
                SeriesPanelButton.Visibility = Visibility.Visible;
                SaveCareerButton.Visibility = Visibility.Visible;
                StackErrorLabel.Visibility = Visibility.Collapsed;
            } else
            {
                StackErrorLabel.Content = CreateError("Fill in the empty Series Name field.");
                StackErrorLabel.Visibility = Visibility.Visible;
            }
            
        }

        private void OnCancelSeriesClick(object sender, RoutedEventArgs e)
        {
            SeriesStackPanel.Visibility = Visibility.Collapsed;
            SeriesPanelButton.Visibility = Visibility.Visible;
            SaveCareerButton.Visibility = Visibility.Visible;
        }

        private void OnOpenPanelSeriesClick(object sender, RoutedEventArgs e)
        {
            SeriesStackPanel.Visibility = Visibility.Visible;
            StackErrorLabel.Visibility = Visibility.Collapsed;
            SeriesPanelButton.Visibility = Visibility.Collapsed;
            SaveCareerButton.Visibility = Visibility.Collapsed;
        }

        private void OnCreateCareerClick(object sender, RoutedEventArgs e)
        {
            /**
             * Movie movie = new Movie
            {
                Name = "Bad Boys",
                Year = 1995
            };

            // serialize JSON to a string and then write string to a file
            File.WriteAllText(@"c:\movie.json", JsonConvert.SerializeObject(movie));

            // serialize JSON directly to a file
            using (StreamWriter file = File.CreateText(@"c:\movie.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, movie);
            }*/
            /*var docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var dirName = $@"{docPath}\MotorsportCareer";
            Console.WriteLine(dirName);
            DirectoryInfo di = Directory.CreateDirectory(dirName);
            string jsonString = JsonConvert.SerializeObject(this.seriesNodes);
            File.WriteAllText($@"{di.FullName}/test.json", jsonString);*/
            CareerReader newReader = new CareerReader(this.careerName);
            newReader.SaveCareer(this.seriesNodes);
        }

        private string CreateError(string msg)
        {
            return String.Format("Error: {0}", msg);
        }
    }

    
}
