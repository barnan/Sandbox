using System;
using System.Windows.Input;
using WpfDataBase.BaseClasses;

namespace WpfDataBase.ViewMod
{
    public class ViewModel : NotifyBase
    {
        public ViewModel()
        {
            AddCommand = new RelayCommand(ExecuteAdd);
            ClearCommand = new RelayCommand(ExecuteClear);

            CurrentVerb = new VerbViewModel { Present = "nehmen" };
            CurrentNoun = new NounViewModel { Word = "hihi" };
            CurrentAdjective = new AdjectiveViewModel { Adjective = "kapa" };
        }



        public Parts[] AvailableParts => (Parts[])Enum.GetValues(typeof(Parts));

        private Parts _selectedParts;
        public Parts SelectedParts
        {
            get { return _selectedParts; }
            set
            {
                _selectedParts = value;
                OnPropertyChanged();
            }
        }


        private VerbViewModel _currentVerb;
        public VerbViewModel CurrentVerb
        {
            get { return _currentVerb; }
            set
            {
                _currentVerb = value;
                OnPropertyChanged();
            }
        }


        private NounViewModel _currentNoun;
        public NounViewModel CurrentNoun
        {
            get { return _currentNoun; }
            set
            {
                _currentNoun = value;
                OnPropertyChanged();
            }
        }


        private AdjectiveViewModel _currentAdjective;
        public AdjectiveViewModel CurrentAdjective
        {
            get { return _currentAdjective; }
            set
            {
                _currentAdjective = value;
                OnPropertyChanged();
            }
        }





        #region commands

        private ICommand _addCommand;
        public ICommand AddCommand
        {
            get { return _addCommand; }
            set { _addCommand = value; }
        }


        private ICommand _clearCommand;
        public ICommand ClearCommand
        {
            get { return _clearCommand; }
            set { _clearCommand = value; }
        }

        private void ExecuteAdd()
        {

        }

        private void ExecuteClear()
        {

        }

        #endregion

    }
}

