using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace QuizApp1
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        IList<Quizy> quizy;
               
        public IList<PlayerViewModel> playerViewModel;
        private IList<PlayerViewModel> Player;

        //private double number = 1;
        //public event PropertyChangedEventHandler PropertyChanged;

        public Quizy currentQuizy { get; set; }
        public int currentScore { get; private set; }

        public MainPage()
        {
            InitializeComponent();

           
            quizy = Quizy.Play;
            playerViewModel = PlayerViewModel.Player;
                      
            if (quizy.Count > 0)
            {
                currentQuizy = quizy.First();
                showQuiz.Text = currentQuizy.Text;
            }

        

            //    TrueCommand = new Command(
            //    execute: () =>
            //        {
            //            currentScore += currentQuizy.TruePoint;
            //            //((Command)TrueCommand).ChangeCanExecute();
            //            //((Command)FalseCommand).ChangeCanExecute();
            //        //   showQuiz.TextColor = Color.Blue;
            //        //showQuiz.FontSize = 16;
            //            quizyChange();
            //        }
            //    );
            //    //canExecute: () => Number<Math.Pow(2, 4));

            //    FalseCommand = new Command(
            //execute: () =>
            //{
            //    currentScore += currentQuizy.FalsePoint;
            //    //((Command)TrueCommand).ChangeCanExecute();
            //    //((Command)FalseCommand).ChangeCanExecute();
            //    quizyChange();
            //}
            //);
            //    //canExecute: () => Number > Math.Pow(2, -4));

        }

    //public double Number
    //    {
    //        set
    //        {
    //            if (number != value)
    //            {
    //                number = value;
    //            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Number"));
    //        }
    //        }
    //        get
    //        {
    //            return number;
    //        }
    //    }

    //public ICommand TrueCommand { private set; get; }

    //public ICommand FalseCommand { private set; get; }

       
        //public void OnSwipe(Object sender, SwipedEventArgs e)
        //{
        //    if (e.Direction.ToString() == "Right")
        //    {
        //        currentScore += currentQuizy.TruePoint;
        //        quizyChange();
        //    }
        //    else if (e.Direction.ToString() == "Left")
        //    {
        //        currentScore += currentQuizy.FalsePoint;
        //        quizyChange();
        //    }
        //}
        private void quizyChange()
        {
            int currentElement = quizy.IndexOf(currentQuizy);
       
            if (currentElement > quizy.Count - 1)
            {
                currentQuizy = quizy.ElementAt(quizy.IndexOf(currentQuizy)+1);
                showQuiz.Text = currentQuizy.Text;
            }         
            currentQuizy = quizy.First();
            currentScore = 0;
           
        }

        public void OnSwipe(object sender, SwipedEventArgs e)
        {
            switch (e.Direction)
            {
                case SwipeDirection.Left:
                    // Handle the swipe
                    currentScore += currentQuizy.FalsePoint;
                    quizyChange();
                    break;
                case SwipeDirection.Right:
                    // Handle the swipe
                    currentScore += currentQuizy.TruePoint;
                    quizyChange();
                    break;
                case SwipeDirection.Up:
                    // Handle the swipe
                    break;
                case SwipeDirection.Down:
                    // Handle the swipe
                    break;
            }
        }

        //public void trueButton(object sender, EventArgs args)
        //{
            
        //        currentScore += currentQuizy.TruePoint;
        //        //currentScore++;
        //        quizyChange();
            
        //}
        //public void falseButton(object sender, EventArgs args)
        //{
            
        //    currentScore += currentQuizy.FalsePoint;
        //    quizyChange();
        //}

    
        public void AgeCompleted(object sender, EventArgs args)
        {
            //PlayerViewModel.age = new PlayerViewModel.Age();
            age.Completed += AgeCompleted;
            //if (int.TryParse(age.Text, out var Age))
            //PlayerViewModel.age = Age;
        }
        public void NameCompleted(object sender, EventArgs args)
        {
            Name.Completed += NameCompleted;
        }
    }
}
