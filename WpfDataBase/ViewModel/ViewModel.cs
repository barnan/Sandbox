using System;
using WpfDataBase.BaseClasses;

namespace WpfDataBase.ViewMod
{
    public class ViewModel : NotifyBase
    {

        public Parts[] AvailableParts => (Parts[])Enum.GetValues(typeof(Parts));


        private Parts _selectedParts = Parts.Verb;
        public Parts SelectedParts
        {
            get => _selectedParts;
            set
            {
                _selectedParts = value;
                OnPropertyChanged();
            }
        }
    }
}

