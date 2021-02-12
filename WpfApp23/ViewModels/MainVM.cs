using System;
using System.Collections.Generic;
using System.Text;
using WpfApp23.Models;
using WpfApp23.MVVM;

namespace WpfApp23.ViewModels
{
    public class MainVM : MvvmNotify
    {
        Game game;

        public string Message
        {
            get => game.CurrentMessage;
        }
        public int UserMessage { get; set; }
        public bool GameIsOn
        {
            get => game.IsOn;
        }
        public bool GameIsOff
        {
            get => !game.IsOn;
        }
        public MvvmCommand StartGame { get; set; }
        public MvvmCommand SendNumber { get; set; }

        public int CountTry
        {
            get => game.CountTry;
            set { 
                game.CountTry = value; 
            }
        }

        public MainVM()
        {
            game = new Game();
            StartGame = new MvvmCommand(
                () => game.StartGame(CountTry),
                () => !game.IsOn);
            SendNumber = new MvvmCommand(
                () => game.SendNumber(UserMessage),
                () => game.IsOn);
            game.CurrentMessageChanged +=
                (o, e) => NotifyPropertyChanged("Message");
            game.GameStatusChanged +=
                (o, e) =>
                {
                    NotifyPropertyChanged("GameIsOn");
                    NotifyPropertyChanged("GameIsOff");
                };
            game.CountTryChanged +=
                (o,e) => NotifyPropertyChanged("CountTry");
        }
    }
}
