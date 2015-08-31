using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Kings;
using static CardDeck;
using Players;
using Android.Graphics.Drawables;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using Android.Views.InputMethods;
namespace Kings
{
    
    
    [Activity(Label = "Kings", MainLauncher = true, Icon = "@drawable/icon")]
    
    /* Be warned; I'm doing all my work on the main thread.
       Once I get multithreading and BG tasks down, the MainActivity here
       will only serve to update the UI, as it (Main) runs on the main UI thread. 
    */
    public class MainActivity : Activity
    {
        
        /* Main Activity is now created, takes a bundle;
           bundle is null until I implement saving application states,
           ie, OnExit(), OnRestore(), etc.
           Need to look into more Android Application Lifecycle Management.
        */

        protected override void OnCreate(Bundle bundle)
        {
            string name;
            /* Below line would get an array of the files in Resources/drawable.
             I'd like to iterate through them to generate cards instead of a huge 
             switch-case with manually entered card object strings being matched 
             to the corresponding .PNG in Resources/drawable, but I haven't been 
             able to figure out how yet...

             string[] cardpics = Assets.List("Resources/drawable");
            */

            // Always call base first when dealing with OnCreate(), OnRestore(), etc. (Why???)
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            // Create a pre-sorted deck.
            // TODO: This is where a new thread should be started to offload
            // some work away from the main/UI thread.
            CardDeck MyDeck = new CardDeck();

            // Create a list of players.
            //List<string> roster = new List<string>();
            //StringBuilder builder = new StringBuilder();
            Player PlayerManager = new Player("manager");
            

            // Using CardDeck instance's helper method to create an array of
            // CardDeck.Card type objects; iterates through Suit and Rank
            // enumerated types defined in the Card object constructor.
            // TODO: Refactor this to be a private method of CardDeck instances;
            // poor design, caller should not have to invoke this after deck instantiation.
            // See Cards.CardDeck.populateDeck() for more details.
            
            MyDeck.populateDeck();

            // Get our EditText (to input player names) and Button.
            var RosterEdit = FindViewById<EditText>(Resource.Id.Roster);
            var DrawCardButton = FindViewById<Button>(Resource.Id.DrawCard);

            // This will give us an ImageView object to display card images in;
            // the TextView's only there to display player names to ensure I'm 
            // storing and retrieving them correctly.
            var CardWindow = FindViewById<ImageView>(Resource.Id.ImageCardView);
            //var TestPlayer = FindViewById<TextView>(Resource.Id.TestPlayer);

            // Don't want users drawing cards before entering players.
            DrawCardButton.Visibility = ViewStates.Invisible;
            CardWindow.Clickable = false;

            // Event handler to deal with Input Method Events.
            // Add strings to our roster on each click of 'done'/'enter' on 
            // keyboard, then reset the text box.
            RosterEdit.EditorAction += (sender, e) =>
            {
                
                if (e.ActionId == ImeAction.Done)
                {
                    name = RosterEdit.Text.ToString().ToUpper();
                    PlayerManager.roster.Add(name);
                    RosterEdit.Text = "";
                    RosterEdit.Hint = "Enter player or draw card to start";
                }

                // Once player roster is full, make the card button
                // visible and the window clickable to allow drawing of cards.
                DrawCardButton.Visibility = ViewStates.Visible;
                CardWindow.Clickable = true;
            };

            /* Bind an event handler to the button responsible for
             pulling cards.
             Iteration through the deck (which has already been populated above)
             is handled by this function being called every time the button is clicked,
             ie, it will call GetCard() every time on the (only) deck instance available,
             (MyDeck in this case) which will keep track of the deck length and remove
             each card drawn below from the List<Card> element (the CardDeck.deck instance).
             */
            
            // Sentinel for keeping track of player turns.
            int countPlayerIndex = 0;
            CardWindow.Click += async delegate 
            {
                // Once the roster is done being added to we can hide it;
                // we don't want people adding players after the game has started.
                RosterEdit.Visibility = ViewStates.Gone;

                /* Make sure we're looping through turns, ie the player's in the roster,
                 and switch to the first person's turn when the sentinel reaches
                 the last player in the roster.

                 NOTE: We will ALWAYS be checking for the count of roster, minus one.
                 This is because the indexes of our roster start at 0, and end at
                 one less than the number of actual items in the roster.
                 For example: Player0 is at index 0, Player1 is at index 1;
                 however, the count of items in the roster is 2, so we have to 
                 check for one less than the number of items in the roster to ensure
                 that our indices aren't going out of bounds.
                */
                if (countPlayerIndex > PlayerManager.roster.Count - 1)
                {
                    countPlayerIndex = 0;
                }

                // Get the playe's name from his index in the roster.
                string currentPlayer = PlayerManager.roster[countPlayerIndex];
                string nextPlayer;

                /* Make sure to take care of looking for the next player;
                 if it's the last player's turn, long-clicks on the DrawCard
                 button will execute the anon function to see who's turn is next.
                 That would result in an off-by-one, falling right off the edge
                 of our flat List<string> that the universe is revolving around.
                 We have to check on each press that we're not the last player.
                */ 
                if (countPlayerIndex == PlayerManager.roster.Count - 1)
                {
                    nextPlayer = PlayerManager.roster[0];
                }
                // In otherwords, if the above if statement evaluates to false, we're
                // not the last player on the roster.
                else { nextPlayer = PlayerManager.roster[countPlayerIndex + 1]; }

                // See Cards.CardDeck.GetCard() for summary of the following.
                // Get a card,
                Card CurrentCard = await MyDeck.GetCard();
                // and append the name of that card to the Button, adding
                // the players name by using our sentinel to find player names in the roster.
                
                DrawCardButton.Text = string.Format("{0} drew the {1}", currentPlayer, CurrentCard + "!");
                // And HERE is the part so simple, it's genius. Increment the
                // sentinel to move to the next player in the list, and 
                // the sentinel is checked on each new click; if it's past the
                // number of players in our roster, it's reset to zero!
                countPlayerIndex++;
                
                // Now set that card's image to an ImageView.
                CardWindow.SetImageResource(CurrentCard.image);
                
                // Small click handler for checking who's turn is next.
                DrawCardButton.LongClick += delegate
                {
                    DrawCardButton.Text = string.Format("{0}'S turn is next.", nextPlayer);
                };
            };

        } // End OnCreate() activity.

    } // End MainActivity.

} // End namespace and all code; small app doesn't necessitate multiple namespaces in this case.

