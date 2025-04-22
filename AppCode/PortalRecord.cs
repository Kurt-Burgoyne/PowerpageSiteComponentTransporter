using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteComponentTransporter.AppCode {
    public class PortalRecord : INotifyPropertyChanged {
        public PortalRecord (string name, string createdon, string modifiedon, string modifiedby, string type) {
            Name = name;
            CreatedOn = createdon;
            ModifiedOn = modifiedon;
            ModifiedBy = modifiedby;
            Selected = false;
            Type = type;
        }

        private bool _selected;

        public bool Selected {
            get => _selected;
            set {
                if (_selected != value) {
                    _selected = value;
                    OnPropertyChanged(nameof(Selected));
                }
            }
        }
        public string Name { get; private set; }
        public string CreatedOn { get; private set; }
        public string ModifiedOn { get; private set; }
        public string ModifiedBy { get; private set; }
        public string Type { get; private set; }

        public Guid ComponentReference;
        public Entity SiteComponent;

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged (string propertyName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
