using Microsoft.VisualBasic.FileIO;
using Microsoft.Win32;
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

namespace TaRenemer
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel viewModel;
        private MainModel model;

        public MainWindow()
        {
            InitializeComponent();
            Clear();
        }

        private void Clear()
        {
            viewModel = new MainViewModel();
            model = new MainModel(viewModel);
            this.DataContext = viewModel;
        }

        /// <summary>
        /// OpenDirectoryButton_Click
        /// </summary>
        private void OpenDirectoryButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Select directory.
                var dialog = new WindowsFormsApp1.FolderSelectDialog() { Title = "Select Folder" };
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string folderpath = dialog.Path;

                    // Load files in the seleted directory.
                    model.OpenDirectory(folderpath);
                }
            }
            catch (Exception ex)
            {
                ShowMessageBox.Error(ex);
            }
        }

        /// <summary>
        /// UpdateButton_Click
        /// </summary>
        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!ShowMessageBox.YesNo("Do you really rename files?"))
                { return; }

                // Run update name.
                model.UpdateName();
                ShowMessageBox.Information("Files has been renamed.");

                // Load files in the seleted directory.
                model.OpenDirectory(viewModel.DirectoryPath);
            }
            catch (Exception ex)
            {
                ShowMessageBox.Error(ex);
            }
        }
    }
}