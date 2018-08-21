using StarWars.Helpers;
using StarWars.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private ObservableCollection<Character> _characters;
        private Character _selectedCharacter;
        private readonly ICharacterRepository _characterRepository;

        public MainViewModel(ICharacterRepository characterRepository)
        {
            _characterRepository = characterRepository;
            Initalise();
        }

        private async void Initalise()
        {
            this.Characters = new ObservableCollection<Character>(await _characterRepository.GetCharacters());
        }

        /// <summary>
        /// Gets and sets the contact status text.
        /// </summary>
        /// 
        public ObservableCollection<Character> Characters
        {
            get
            {
                return _characters;
            }
            private set
            {
                if (_characters != value)
                {
                    _characters = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets and sets the contact status text.
        /// </summary>
        /// 
        public Character SelectedCharacter
        {
            get
            {
                return _selectedCharacter;
            }
            set
            {
                if (_selectedCharacter != value)
                {
                    _selectedCharacter = value;
                    RaisePropertyChanged();
                }
            }
        }
    }
}
