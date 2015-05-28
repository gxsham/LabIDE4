using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;
using LoLChamps.API;
using System.Collections.ObjectModel;
using System.Diagnostics;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace LoLChamps
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
            this.Loaded += MainPage_Loaded;
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            
        }
        async void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Champion> champs = new ObservableCollection<Champion>();
            Champions ids = await GetChampInfo.GetIds();
            ChampionsView.ItemsSource = champs;
            for (int i = 0; i < ids.champions.Length; i++)
            {
                Champion chmp = await GetChampInfo.GetChamps(ids.champions[i].id.ToString());
                if (chmp.name != "Connection Error")
                {
                    chmp.image.full = "http://ddragon.leagueoflegends.com/cdn/5.7.2/img/champion/" + chmp.image.full;
                    champs.Add(chmp);
                }
            }
            Debug.WriteLine("zaebis'");

        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you
        }
        

        private void ChampionsView_Tapped(object sender, TappedRoutedEventArgs e)
        {

            Frame.Navigate(typeof(DetailsPage), ((ListView)sender).SelectedItem);
        }
    }
}
