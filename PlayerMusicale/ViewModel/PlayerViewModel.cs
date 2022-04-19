using MicroMvvm;
using PlayerMusicale.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace PlayerMusicale.ViewModel
{
    public class PlayerViewModel : ObservableObject
    {
        private SpotiTappy st;

        private Playlist CurrentPlaylist;

        private ObservableCollection<Playlist> HomePage;

        #region Get/Set
        public SpotiTappy St
        {
            get { return st; }
            set { st = value; RaisePropertyChanged("SpotiTappy"); }
        }
        #endregion

        public PlayerViewModel()
        {
            st = new SpotiTappy();
            HomePage = new ObservableCollection<Playlist>();
            Load();
        }

        #region FileOrganization

        public void Load()
        {
            //st.LoadFiles();
            //HomePageViewUpdate();
        }
        public void HomePageViewUpdate()
        {

        }

        public void Save()
        {
            //st.SaveFiles();
        }
        #endregion

        #region Commands
        public ICommand NewSong
        {
            get
            {
                return new RelayCommand(NewSongExecute, NewSongCanExecute);
            }
        }

        void NewSongExecute()
        {

        }

        bool NewSongCanExecute()
        {
            return true;
        }

        public ICommand NewPlaylist
        {
            get
            {
                return new RelayCommand(NewPlaylistExecute, NewPlaylistCanExecute);
            }
        }

        void NewPlaylistExecute()
        {

        }

        bool NewPlaylistCanExecute()
        {
            return true;
        }
        #endregion
    }
}
