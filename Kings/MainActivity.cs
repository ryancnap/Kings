using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Kings;
using static CardDeck;
using Android.Graphics.Drawables;


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
            /* Below line would get an array of the files in Resources/drawable.
               I'd like to iterate through them to generate cards instead of a huge 
               switch-case with manually entered card object strings being matched 
               to the corresponding .PNG in Resources/drawable, but I haven't been 
               able to figure out how yet :/

               string[] cardpics = Assets.List("Resources/drawable");
            */

            // Create and get layout info from XML file 'Main' (Resources/layout/Main.axml).
            // Always call base first when dealing with OnCreate(), OnRestore(), etc. (Why???)
            base.OnCreate(bundle);
            // Start by setting the main screen layout for this Activity.
            SetContentView(Resource.Layout.Main);

            // Create a pre-sorted deck.
            // TODO: This is where a new thread should be started to offload
            // some work away from the main/UI thread.
            CardDeck MyDeck = new CardDeck();

            // Using CardDeck instance's helper method to create an array of
            // CardDeck.Card type objects; iterates through Suit and Rank
            // enumerated types defined in the Card object constructor.
            // TODO: Refactor this to be a private method of CardDeck instances;
            // poor design, caller should not have to invoke this after deck instantiation.
            // See Cards.CardDeck.populateDeck() for more details.
            MyDeck.populateDeck();

            // Get our Button and TextView (simple text box).
            var DrawCardButton = FindViewById<Button>(Resource.Id.DrawCard);
            var CardViewText = FindViewById<TextView>(Resource.Id.TestView);

            // This will give us an ImageView object to display card images in.
            var RealCard = FindViewById<ImageView>(Resource.Id.ImageCardView);


            // Bind short-lived event handler to the button responsible for
            // pulling cards.
            // Iteration through the deck (which has already been populated above)
            // is handled by this function being called every time the button is clicked,
            // ie, it will call GetCard() every time on the (only) deck instance available,
            // (MyDeck in this case) which will keep track of the deck length and remove
            // each card drawn below from the List<Card> element (the CardDeck.deck instance).
            DrawCardButton.Click += delegate 
            {
                // See Cards.CardDeck.GetCard() for summary of the following.
                // Get a card,
                Card currentCard = MyDeck.GetCard();
                // and append the name of that card to a text-box.
                CardViewText.Text = string.Format("You drew the {0}", currentCard + "!");
                // Now set that card's image to an ImageView.
                RealCard.SetImageResource(currentCard.image);
                
            }; // End anonymous click handler.

        } // End OnCreate() activity.

    } // End MainActivity.

} // End namespace and all code; small app doesn't necessitate multiple namespaces in this case.

