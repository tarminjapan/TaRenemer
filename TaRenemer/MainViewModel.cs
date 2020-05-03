using System;
using System.Collections.Generic;
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