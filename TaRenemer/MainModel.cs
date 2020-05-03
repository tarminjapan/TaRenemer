using System;
using System.Collections.Generic;
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
            viewModel = vm;
        }

        /// <summary>
        /// ディレクトリを開く
        /// </summary>
        public void OpenDirectory(string path)
        {
            viewModel.DirectoryPath = path;
        }
    }
}