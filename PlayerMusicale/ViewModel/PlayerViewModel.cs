using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MicroMvvm;
using PlayerMusicale.Model;

namespace PlayerMusicale.ViewModel
{
    public class PlayerViewModel : ObservableObject
    {
        public Model.SpotiTappy st;

        public ObservableCollection<Playlist> HomePage;

        #region FileOrganization

        public void Load()
        {
            st = new SpotiTappy();
            HomePage = new ObservableCollection<Playlist>();
            //st.LoadFiles();
            st.Playlists.Add(new Playlist("SpotiTappy"));
            HomePageViewUpdate();
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
