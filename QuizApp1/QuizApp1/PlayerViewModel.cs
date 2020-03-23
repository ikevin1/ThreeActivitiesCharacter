using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.ComponentModel;
using Xamarin.Forms;

namespace QuizApp1
{
    public class PlayerViewModel : INotifyPropertyChanged
    {        
        public event PropertyChangedEventHandler PropertyChanged;
        public static string age;
        public string Age { get { return age; } set { if (age != value) { age = ProcessAge(value); OnPropertyChanged(Age); } } }

        public string name;
        public string Name { get { return name; } set { if (name != value) { name = ProcessName(value); OnPropertyChanged(Name); } } }

        public int plusScore;
        public int PlusScore { get { return plusScore; } set { if (plusScore != value) { plusScore = ProcessPlus(value); OnPropertyChanged(PlusScore); } } }

        private int ProcessPlus(int value)
        {
            throw new NotImplementedException();
        }

        private void OnPropertyChanged(int plusScore)
        {
            throw new NotImplementedException();
        }

        public int minusScore;
        public int MinusScore { get { return minusScore; } set { if (minusScore != value) { minusScore = ProcessMinus(value); OnPropertyChanged(MinusScore); } } }

        private int ProcessMinus(int value)
        {
            throw new NotImplementedException();
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string ProcessAge(string age)
        {
            if (string.IsNullOrEmpty(age))
                return age;

            if (age.Length > 3)
                age = age.Substring(0, 3);

            if (age.StartsWith("0"))
                age = age.Remove(0, 1);

            string pattern = "[^0-9]";

            if (Regex.IsMatch(age, pattern))
                age = age.Remove(age.Length - 1, 1);

            return age.Replace(".", "").Replace("-", "");
        }

        public string ProcessName(string name)
        {
            try
            {
                if (string.IsNullOrEmpty(name))
                    return name;

                if (name.Length > 20)
                    name = name.Substring(0, 20);

                string pattern = "[^-A-Za-z.' ]";

                if (Regex.IsMatch(name, pattern))
                    name = name.Remove(name.Length - 1, 1);

                return name;
            }
            catch (Exception e)
            {
                name = e.ToString();
                return name;
            }
        }

        //private int ProcessPlus(int plusScore)
        //{
        //    try
        //    {

        //        return plusScore;
        //    }
        //    finally
        //    {

        //    }

        //}

        //private int ProcessMinus(int minusScore)
        //{
        //    try
        //    {

        //        return minusScore;
        //    }
        //    finally
        //    {

        //    }

        //}

        public PlayerViewModel(string name, string age, int minusScore, int plusScore)
        {
            Name = name;
            Age = age;
            MinusScore = minusScore;
            PlusScore = plusScore;
        }      

        public static IList<PlayerViewModel> Player { private set; get; }
    }
}
