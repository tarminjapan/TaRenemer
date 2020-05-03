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
                Cursor = Cursors.Wait;

                // Select directory.
                var dialog = new OpenFileDialog()
                {
                    FileName = "SelectFolder",
                    Filter = "Folder|.",
                    CheckFileExists = false
                };
                if (dialog.ShowDialog() == true)
                {
                    string folderpath = dialog.FileName;
                    this.model.OpenDirectory(folderpath);
                }
            }
            catch (Exception ex)
            {
                ShowMessageBox.Error(ex);
            }
            finally
            {
                Cursor = Cursors.Arrow;
            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}