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

namespace Players
{
    class Player
    {
        // Create a class member array to store list of all players.
        // Hey, asshole, move all this to a different module. You're shitting it up in here.
        const int MAX_PLAYERS = 3;
        static List<string> playerList = new List<string>();

        // Takes a name and appends it to an array.
        public List<string> generatePlayers()
        {
         
            foreach (var i in playerList)
            {
                string playerName = Console.ReadLine();
                playerList.Add(playerName);
            }
            return playerList;
        }

        public static void printPlayers()
        {
            // And then this sexy, functional beast down here!
            playerList.ToList().ForEach(_player => Console.WriteLine(_player));
            
        }

        public Player()
        {
            
         
        } // End Player object constructor.


    }
}