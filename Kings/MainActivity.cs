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
    public class MainActivity : Activity
    {
        // Sentinel for code I'll soon demolish.
        int _count = 1;

        // Main Activity is now created, from what I understand.
        protected override void OnCreate(Bundle bundle)
        {
            // Create and get layout info from XML file 'Main'.
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            // Create a pre-sorted deck.
            CardDeck MyDeck = new CardDeck();
            MyDeck.populateDeck();

            // Get our button and text-view (text box).
            var DrawCardButton = FindViewById<Button>(Resource.Id.DrawCard);
            var CardViewText = FindViewById<TextView>(Resource.Id.TestView);

            // TEST Now let's test the ImageCardView to generate images.
            var RealCard = FindViewById<ImageView>(Resource.Id.ImageCardView);


            // Bind short-lived event handler to the button responsible for
            // pulling cards.
            DrawCardButton.Click += delegate 
            {
                Card currentCard = MyDeck.GetCard();
                CardViewText.Text = string.Format("You drew the {0}", currentCard + "!");

                // TEST try switching images depending on type.
                
                // Get resource ID int for the drawable resource.
                RealCard.SetImageResource(currentCard.image);
            }; // End anon.

        } // End OnCreate activity.

    } // End MainActivity.

}

