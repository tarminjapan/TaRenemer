using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaRenemer
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        { }

        private string _DirectoryPath = "";
        private ObservableCollection<FileInfo> _FileInfos = new ObservableCollection<FileInfo>();

        /// <summary>
        /// Target Directory Path
        /// </summary>
        public string DirectoryPath
        {
            get { return _DirectoryPath; }
            set
            {
                _DirectoryPath = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// File pathes in the selected directory.
        /// </summary>
        public ObservableCollection<FileInfo> FileInfos
        {
            get { return _FileInfos; }
            set
            {
                _FileInfos = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises OnPropertychangedEvent when property changes
        /// </summary>
        /// <param name="name">String representing the property name</param>
        protected void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}