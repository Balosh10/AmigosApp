using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AmigosApp.HttpHelper;
using AmigosApp.Models;
using Xamarin.Forms;

namespace AmigosApp.ViewModel
{
    public class MainPageViewModel : BaseViewModel
    {
        private ObservableCollection<Amiibo> _amigos;

        public ObservableCollection<Character> Characters { get; set; }
        public ObservableCollection<Amiibo> amigos
        {
            get => _amigos;
            set
            {
                _amigos = value;
                OnPropertyChanged();
            }
        }

        public ICommand SearchCommand { set; get; }

        public MainPageViewModel()
        {
            Title = "Amigos";
            SearchCommand = new Command(async (param) =>
            {
                IsBusy = true;
                var character = param as Character;
                if (character != null)
                {
                    string url = $"http://www.amiiboapi.com/api/amiibo/?character={character.name}";
                    var service = new HttpHelper<Amiibos>();
                    var amiibos = await service.GetRestServiceDataAsync(url);
                    amigos = new ObservableCollection<Amiibo>(amiibos.amiibo);
                }
                IsBusy = false;
            });
        }
        public async Task LoadCharacters()
        {
            IsBusy = true;
            var url = "http://www.amiiboapi.com/api/character";
            var service = new HttpHelper<Characters>();
            var characters = await service.GetRestServiceDataAsync(url);
            Characters = new ObservableCollection<Character>(characters.amiibo);
            IsBusy = false;
        }
    }
}
