using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android;
using Kings;

namespace Players
{
    class Player
    {

        // Store list of players
        public List<string> roster = new List<string>();
        //public StringBuilder builder = new StringBuilder();
        private string name;

        public string DisplayPlayerRoster()
        {
            string combined = string.Join("\n", this.roster);
            return combined;            
        }

        // Constructor (some of these comments are here solely for my benefit).
        // I think I'm doing ctors' wrong cause of the hoops I had to jump through
        // when creating it in the MainActivity.
        public Player(string name)
        {
            this.name = name;

        }       
    }
}