using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaRenemer.Classes
{
    public class FileDirectory : INotifyPropertyChanged
    {
        public FileDirectory(string originfullpath)
        {
        }

        private string _OriginFullPath;
        private string _NewFullPath;
        private DateTime _CreateDatetime;
        private DateTime _UpdateDateTime;

        /// <summary>
        /// Full path before update.
        /// </summary>
        public string OriginFullPath
        {
            get { return _OriginFullPath; }
        }

        /// <summary>
        /// Name before update.
        /// </summary>
        public string OriginName
        {
            get { return Path.GetFileName(_OriginFullPath); }
        }

        /// <summary>
        /// Name before update without extension.
        /// </summary>
        public string OriginNameWithoutExtension
        {
            get { return Path.GetFileNameWithoutExtension(_OriginFullPath); }
        }

        /// <summary>
        /// Extension before update.
        /// </summary>
        public string OriginExtension
        {
            get { return Path.GetExtension(_OriginFullPath); }
        }

        /// <summary>
        /// Full path after update.
        /// </summary>
        public string NewFullPath
        {
            get { return _NewFullPath; }
            set
            {
                _NewFullPath = value;
                OnPropertyChanged();
            }
        }

        public string NewNameExcludingExtension
        {
            get { return ""; }
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