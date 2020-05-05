using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        }

        /// <summary>
        /// Update Name
        /// </summary>
        public void UpdateName()
        {
            foreach (FileInfo fd in viewModel.FileInfos)
            {
                System.IO.File.Move(fd.OriginFileFullPath, fd.NewFileFullPath);
            }
        }
    }
}