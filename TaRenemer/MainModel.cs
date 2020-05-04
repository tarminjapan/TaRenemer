using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaRenemer
{
    internal class MainModel
    {
        private MainViewModel viewModel;

        public MainModel(MainViewModel vm)
        {
            Clear();
            viewModel = vm;
        }

        public void Clear()
        {
            viewModel = new MainViewModel();
        }

        /// <summary>
        /// Open Directory
        /// </summary>
        public void OpenDirectory(string path)
        {
            viewModel.DirectoryPath = path;
            viewModel.FileInfos.Clear();

            // Get file pathes in the selected directory.
            var fileList = Directory.GetFiles(path, "*", SearchOption.TopDirectoryOnly);
            foreach (string filePath in fileList)
            {
                var fd = new FileInfo(filePath);
                viewModel.FileInfos.Add(fd);
            }

            //int a = 1;
        }
    }
}