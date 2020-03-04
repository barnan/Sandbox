using WpfDataBase.BaseClasses;

namespace Investigate_AttachedProperty
{
    class ViewModel : NotifyBase
    {
        private string _vmProperty = "...";
        public string VmProperty
        {
            get => _vmProperty;
            set
            {
                _vmProperty = value;
                OnPropertyChanged();
            }
        }

        private string _vmProperty2 = "...";
        public string VmProperty2
        {
            get => _vmProperty2;
            set
            {
                _vmProperty2 = value;
                OnPropertyChanged();
            }
        }
    }
}
