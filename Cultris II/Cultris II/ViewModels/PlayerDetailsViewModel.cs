using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace Cultris_II.ViewModels
{
    [QueryProperty(nameof(PlayerId), nameof(PlayerId))]
    class PlayerDetailsViewModel : BaseViewModel
    {
        private string playerId;
        private string playerName;
        private string playerImageSource;

        public string Id { get; set; }

        public string PlayerName
        {
            get => playerName;
            set => SetProperty(ref playerName, value);
        }

        public string PlayerImageSource
        {
            get => playerImageSource;
            set => SetProperty(ref playerImageSource, value);
        }

        public string PlayerId
        {
            get
            {
                return playerId;
            }
            set
            {
                playerId = value;
                LoadPlayerId(value);
            }
        }

        public void LoadPlayerId(string playerId)
        {
        }
    }
}
