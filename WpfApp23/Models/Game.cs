using System;
using System.Collections.Generic;
using System.Text;

namespace WpfApp23.Models
{
    public class Game
    {
        public string CurrentMessage 
        {
            get => currentMessage;
            internal set 
            { 
                currentMessage = value;
                CurrentMessageChanged?.Invoke(this, null);
            } 
        }
        public bool IsOn
        {
            get => isOn;
            internal set {
                isOn = value;
                if (!isOn)
                    CountTry = 5;
                GameStatusChanged?.Invoke(this, null);
            }
        }

        public int CountTry
        {
            get => countTry;
            set
            {
                countTry = value;
                CountTryChanged?.Invoke(this, null);
            }
        }

        int generatedNumber;
        int countTry = 5;
        private string currentMessage;
        private bool isOn;

        internal void StartGame(int countTry)
        {
            CurrentMessage = "Игра началась! Угадай число от 0 до 100!";
            generatedNumber = new Random().Next(0, 100);
            CountTry = countTry;
            IsOn = true;
        }

        internal void SendNumber(int userMessage)
        {
            if (userMessage == generatedNumber)
            {
                CurrentMessage = "Поздравляю! Ты угадал(а)";
                IsOn = false;
                return;
            }
            if (userMessage < 0 || userMessage > 100)
            {
                CurrentMessage = "Неверный диапазон!";
                return;
            }
            if (userMessage > generatedNumber)
                CurrentMessage = "Введи число поменьше!";
            else //if (userMessage < generatedNumber)
                CurrentMessage = "Введи число побольше";
            CountTry--;
            if (CountTry == 0)
            {
                CurrentMessage = "Попытки закончились. Попробуй снова!";
                IsOn = false;
            }
        }
        public event EventHandler GameStatusChanged;
        public event EventHandler CurrentMessageChanged;
        public event EventHandler CountTryChanged;
    }
}
