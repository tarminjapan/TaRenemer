using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaRenemer
{
    public class FileInfo : INotifyPropertyChanged
    {
        public FileInfo(string originFullFath)
        {
            this._OriginFileFullPath = originFullFath;
            this._NewFileFullPath = originFullFath;
            this._CreationTime = File.GetCreationTime(originFullFath);
            this._LastWriteTime = File.GetLastWriteTime(originFullFath);
        }

        private string _OriginFileFullPath;
        private string _NewFileFullPath;
        private DateTime _CreationTime;
        private DateTime _LastWriteTime;

        public string OriginFileFullPath
        {
            get { return _OriginFileFullPath; }
        }

        public string OriginFileName
        {
            get { return Path.GetFileName(_OriginFileFullPath); }
        }

        public string OriginFileNameWithoutExtension
        {
            get { return Path.GetFileNameWithoutExtension(_OriginFileFullPath); }
        }

        public string OriginFileExtension
        {
            get { return Path.GetExtension(_OriginFileFullPath); }
        }

        public string OriginDirectoryFullPath
        {
            get { return Path.GetDirectoryName(_OriginFileFullPath); }
        }

        public string NewFileFullPath
        {
            get { return _NewFileFullPath; }
            set
            {
                _NewFileFullPath = value;
                OnPropertyChanged();
            }
        }

        public string NewFileName
        {
            get { return Path.GetFileName(_NewFileFullPath); }
            set
            {
                string path = _NewFileFullPath;
                _NewFileFullPath = Path.Combine(Path.GetDirectoryName(path), value);
                OnPropertyChanged();
            }
        }

        public string NewFileNameWithoutExtension
        {
            get { return Path.GetFileNameWithoutExtension(_NewFileFullPath); }
            set
            {
                string path = _NewFileFullPath;
                _NewFileFullPath = Path.Combine(Path.GetDirectoryName(path), value + Path.GetExtension(path));
                OnPropertyChanged();
            }
        }

        public string NewFileExtension
        {
            get { return Path.GetExtension(_NewFileFullPath); }
            set
            {
                string path = _NewFileFullPath;
                _NewFileFullPath = Path.Combine(Path.GetDirectoryName(path), Path.GetFileNameWithoutExtension(path) + value);
                OnPropertyChanged();
            }
        }

        public string NewDirectoryFullPath
        {
            get { return Path.GetDirectoryName(_NewFileFullPath); }
            set
            {
                string path = _NewFileFullPath;
                _NewFileFullPath = Path.Combine(value, Path.GetFileName(path));
            }
        }

        public DateTime CreationTime
        {
            get { return _CreationTime; }
        }

        public DateTime LastWriteTime
        {
            get { return _LastWriteTime; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises OnPropertychangedEvent when property changes
        /// </summary>
        /// <param name="name">String representing the property name</param>
        protected void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NewFileFullPath"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NewFileName"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NewFileNameWithoutExtension"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NewFileExtension"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NewDirectoryFullPath"));
        }
    }
}