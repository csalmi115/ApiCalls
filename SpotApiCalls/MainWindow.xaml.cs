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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using SpotApiCalls;
using OPIS.Spots.SpotApi.Client;
using OPIS.Spots.SpotApi.DTO;

namespace SpotApiCalls
{
  
    public partial class MainWindow : Window
    {
        public string specificDate;
        public string endDate;
        public string startDate;
        public bool rbProductCodes;
        public bool rbProductGroups;
        public string productCodes;
        public string productGroups;
        //public const string url = @"https://sp-spotapi-v1.opisnet.io/api/SpotValues/Pivoted/QueryByVirtualGroup?virtualGroups=1";

        public MainWindow()
        {
            InitializeComponent();

         }

        private void txtSpecificDate_TextChanged(object sender, TextChangedEventArgs e)
        {
            specificDate = txtSpecificDate.Text;
        }

        private void txtEndDate_TextChanged(object sender, TextChangedEventArgs e)
        {
            endDate = txtEndDate.Text;
        }

        private void txtStartDate_TextChanged(object sender, TextChangedEventArgs e)
        {
            startDate = txtStartDate.Text;
        }

        private void TBProduct_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (rbProductCodes)
            {
                productCodes = tbProducts.Text;
            }
            else if (rbProductGroups)
            {
                productGroups = tbProducts.Text;
            }
        }

        private void RBProductCodes_Checked(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton RBProductCodes)
            {
                rbProductCodes = true;
            }

        }

        private void RBProductGroups_Checked(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton RBProductGroups)
            {
                rbProductGroups = true;
            }

        }
        private async void btExecute_Click(object sender, RoutedEventArgs e)
        {
            string html = string.Empty;

            var newRequest = new SpotValueClient("https://sp-spotapi-v1.opisnet.io/");

            DateTime? spDate = specificDate != "yyyy-mm-dd" ? DateTime.Parse(specificDate) : null;
            DateTime? stDate = startDate != "yyyy-mm-dd" ? DateTime.Parse(startDate) : null;
            DateTime? enDate = endDate != "yyyy-mm-dd" ? DateTime.Parse(endDate) : null;

            if (rbProductGroups)
            {
                List<PivotedSpotValue> response = await newRequest.GetPivotedSpotValuesByVirtualGroupAsync(tbProducts.Text, spDate, stDate, enDate);
                DataTable.ItemsSource = response;
            }
            else if (rbProductCodes)
            {
                List<PivotedSpotValue> response = await newRequest.GetPivotedSpotValuesByProductCodeAsync(tbProducts.Text, spDate, stDate, enDate);
                DataTable.ItemsSource = response;
            }
        }

        public class Concept
        {
            public string Classification { get; set; }
        }
    }
}
