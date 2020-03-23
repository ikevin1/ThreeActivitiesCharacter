using System;
using System.Collections.Generic;
using System.Text;

namespace QuizApp1
{
    public class Quizy
    {
        public Quizy(string text, int posScore, int negScore)
        {
            Text = text;
            TruePoint = posScore;
            FalsePoint = negScore;
        }

        public string Text { get; private set; }
        public int TruePoint { get; private set; }
        public int FalsePoint { get; private set; }
        public static IList<Quizy> Play { get; internal set; }

        static Quizy()
        {
            //IList<Quizy> Quiz = new List<Quizy>;
               Play = new List<Quizy>
            {
                // Part 1. Getting Started with XAML
                new Quizy("WCTC is in Pewaukee?", 3, -3),
                new Quizy("Sky is blue?", 3, -3),
                new Quizy("December is the 12th month?", 3, -3),
                new Quizy("January has only 7 weeks?", -3, 3)
            };
            
        }

        //public static IList<Quizy> Play { private set; get; }
    }
}
