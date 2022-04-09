﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MicroMvvm;

namespace PlayerMusicale.ViewModel
{
    public class PlayerViewModel : ObservableObject
    {
        #region FileOrganization

        public static void Load()
        {
            Model.SpotiTappy.LoadFiles();
        }
        public static void Save()
        {
            Model.SpotiTappy.SaveFiles();
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
