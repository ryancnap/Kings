using Android;
using Android.Content;
using Kings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// Create a class to model the behavior of a deck of cards;
// it contains a card object and some helper methods.
class CardDeck
{
    // This is the random object to be used in the deck object's
    // logic for figuring out which card to pick.
    public Random rand = new Random();

    // Individual card class that belongs to CardDeck.
    public class Card
    {
        // Override Card's ToString method so we can write to console.
        public override string ToString()
        {
            if (this.image == Kings.Resource.Drawable.Gameover)
            {
                return "final card, game over";
            }
            return rank.ToString() + " of " + suit.ToString();
        }

        // Private class members of enumerated type Suit and Rank respectively.
        private Suits suit;
        private Rank rank;
        public string description;
        public int image;

        // Card constructor using enumerated types.
        public Card (Suits suit, Rank rank)
        {
            this.suit = suit;
            this.rank = rank;
            description = this.ToString().ToLower().Replace(" ", "_");
  
        }

        // Let's add some suits and ranks.
        public enum Suits
        {
            Spades,
            Hearts,
            Diamonds,
            Clubs,
        }

        public enum Rank
        {
            Ace, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten,
            Jack,
            Queen,
            King,

        }
    } // End Card class definition.


    // Using a List of Card objects as the deck container.
    public List<Card> deck = new List<Card>(52);

    // fuckmefuckmefuckme
    public async Task<int> GetCardImage(Card card)
    {
        
        foreach (Card _card in this.deck)
        {
            switch (card.description)
            {
                case "ace_of_clubs":
                    card.image = Kings.Resource.Drawable.ace_of_clubs;
                    //return _card.image;
                    break;
                   
                case "ace_of_spades":
                    card.image = Kings.Resource.Drawable.ace_of_spades;
                    //return _card.image;
                    break;

                case "ace_of_hearts":
                    card.image = Kings.Resource.Drawable.ace_of_hearts;
                    //return _card.image;
                    break;

                case "ace_of_diamonds":
                    card.image = Kings.Resource.Drawable.ace_of_diamonds;
                    //return _card.image;
                    break;

                case "two_of_clubs":
                    card.image = Kings.Resource.Drawable.two_of_clubs;
                    //return _card.image;
                    break;

                case "two_of_spades":
                    card.image = Kings.Resource.Drawable.two_of_spades;
                    //return _card.image;
                    break;

                case "two_of_hearts":
                    card.image = Kings.Resource.Drawable.two_of_hearts;
                    //return _card.image;
                    break;

                case "two_of_diamonds":
                    card.image = Kings.Resource.Drawable.two_of_diamonds;
                    //return _card.image;
                    break;

                case "three_of_clubs":
                    card.image = Kings.Resource.Drawable.three_of_clubs;
                    //return _card.image;
                    break;

                case "three_of_spades":
                    card.image = Kings.Resource.Drawable.three_of_spades;
                    //return _card.image;
                    break;

                case "three_of_hearts":
                    card.image = Kings.Resource.Drawable.three_of_hearts;
                    //return _card.image;
                    break;

                case "three_of_diamonds":
                    card.image = Kings.Resource.Drawable.three_of_diamonds;
                    //return _card.image;
                    break;

                case "four_of_clubs":
                    card.image = Kings.Resource.Drawable.four_of_clubs;
                    //return _card.image;
                    break;

                case "four_of_spades":
                    card.image = Kings.Resource.Drawable.four_of_spades;
                    //return _card.image;
                    break;

                case "four_of_hearts":
                    card.image = Kings.Resource.Drawable.four_of_hearts;
                    //return _card.image;
                    break;

                case "four_of_diamonds":
                    card.image = Kings.Resource.Drawable.four_of_diamonds;
                    //return _card.image;
                    break;

                case "five_of_clubs":
                    card.image = Kings.Resource.Drawable.five_of_clubs;
                    //return _card.image;
                    break;

                case "five_of_spades":
                    card.image = Kings.Resource.Drawable.five_of_spades;
                    //return _card.image;
                    break;

                case "five_of_hearts":
                    card.image = Kings.Resource.Drawable.five_of_hears;
                    //return _card.image;
                    break;

                case "five_of_diamonds":
                    card.image = Kings.Resource.Drawable.five_of_diamonds;
                    //return _card.image;
                    break;

                case "six_of_clubs":
                    card.image = Kings.Resource.Drawable.six_of_clubs;
                    //return _card.image;
                    break;

                case "six_of_spades":
                    card.image = Kings.Resource.Drawable.six_of_spades;
                    //return _card.image;
                    break;

                case "six_of_diamonds":
                    card.image = Kings.Resource.Drawable.six_of_diamonds;
                    //return _card.image;
                    break;

                case "six_of_hearts":
                    card.image = Kings.Resource.Drawable.six_of_hearts;
                    //return _card.image;
                    break;

                case "seven_of_clubs":
                    card.image = Kings.Resource.Drawable.seven_of_clubs;
                    //return _card.image;
                    break;

                case "seven_of_spades":
                    card.image = Kings.Resource.Drawable.seven_of_spades;
                    //return _card.image;
                    break;

                case "seven_of_hearts":
                    card.image = Kings.Resource.Drawable.seven_of_hearts;
                    //return _card.image;
                    break;

                case "seven_of_diamonds":
                    card.image = Kings.Resource.Drawable.seven_of_diamonds;
                    //return _card.image;
                    break;

                case "eight_of_clubs":
                    card.image = Kings.Resource.Drawable.eight_of_clubs;
                    //return _card.image;
                    break;

                case "eight_of_spades":
                    card.image = Kings.Resource.Drawable.eight_of_spades;
                    //return _card.image;
                    break;

                case "eight_of_hearts":
                    card.image = Kings.Resource.Drawable.eight_of_hearts;
                    //return _card.image;
                    break;

                case "eight_of_diamonds":
                    card.image = Kings.Resource.Drawable.eight_of_diamonds;
                    //return _card.image;
                    break;

                case "nine_of_clubs":
                    card.image = Kings.Resource.Drawable.nine_of_clubs;
                    break;

                case "nine_of_spades":
                    card.image = Kings.Resource.Drawable.nine_of_spades;
                    break;

                case "nine_of_hearts":
                    card.image = Kings.Resource.Drawable.nine_of_hearts;
                    break;

                case "nine_of_diamonds":
                    card.image = Kings.Resource.Drawable.nine_of_diamonds;
                    break;

                case "ten_of_clubs":
                    card.image = Kings.Resource.Drawable.ten_of_clubs;
                    break;

                case "ten_of_spades":
                    card.image = Kings.Resource.Drawable.ten_of_spades;
                    break;

                case "ten_of_hearts":
                    card.image = Kings.Resource.Drawable.ten_of_hearts;
                    break;

                case "ten_of_diamonds":
                    card.image = Kings.Resource.Drawable.ten_of_diamonds;
                    break;

                case "jack_of_clubs":
                    card.image = Kings.Resource.Drawable.jack_of_clubs;
                    break;

                case "jack_of_spades":
                    card.image = Kings.Resource.Drawable.jack_of_spades;
                    break;

                case "jack_of_hearts":
                    card.image = Kings.Resource.Drawable.jack_of_hearts;
                    break;

                case "jack_of_diamonds":
                    card.image = Kings.Resource.Drawable.jack_of_diamonds;
                    break;

                case "queen_of_clubs":
                    card.image = Kings.Resource.Drawable.queen_of_clubs;
                    break;

                case "queen_of_spades":
                    card.image = Kings.Resource.Drawable.queen_of_spades;
                    break;

                case "queen_of_hearts":
                    card.image = Kings.Resource.Drawable.queen_of_hearts;
                    break;

                case "queen_of_diamonds":
                    card.image = Kings.Resource.Drawable.queen_of_diamonds;
                    break;

                case "king_of_clubs":
                    card.image = Kings.Resource.Drawable.king_of_clubs;
                    break;

                case "king_of_spades":
                    card.image = Kings.Resource.Drawable.king_of_spades;
                    break;

                case "king_of_hearts":
                    card.image = Kings.Resource.Drawable.king_of_hearts;
                    break;

                case "king_of_diamonds":
                    card.image = Kings.Resource.Drawable.king_of_diamonds;
                    break;
                                        
                default:
                    card.image = Kings.Resource.Drawable.Icon;
                    break;                  
            }  
        } // End foreach looping over every card in deck instance.
        return card.image;
    } // End GetCardImage method of deck.
    
    // To be called with a new CardDeck instance; fills deck with card object instances.
    public async void populateDeck()
    {
        // Iterates over each sub-type in enumerated types Rank and Suit.
        // Covering that gives us a card object created for each suit/rank combination.
        // Afterwards we add the current Card object to the deck.
        foreach (Card.Rank rank in Enum.GetValues(typeof(Card.Rank)))
        {
            foreach (Card.Suits suit in Enum.GetValues(typeof(Card.Suits)))
            {
                Card card = new Card(suit, rank);
                card.image = await GetCardImage(card);
                this.deck.Add(card);
            }

        }
    } // End populate deck.

    public void showFullDeck()
    {
        // Iterates over the deck to ensure we've got all our cards.
        foreach (var card in this.deck)
        {
            // Keep in mind that since the Card is an instantiated object of
            // the Card class, who inherits from CardDeck, our ToString override
            // will help us out here.
            Console.WriteLine(card);
        }
    } // End showFullDeck.

    public async Task<Card> GetCard()
    {
        int _length = this.deck.Count();

        if (_length > 0)
        {
            int seed = rand.Next(0, _length);
            //if this.deck.contains() <- seems useful, let's keep this around
            Card card = this.deck.ElementAt(seed);
         
            //GetCardImage(card);

            if (this.deck.Contains(card))
            {
                this.deck.Remove(card);
            }
          
            return card;
        }      

        else
        {
            Card card = new Card(Card.Suits.Spades, Card.Rank.Ace);
            card.image = Kings.Resource.Drawable.Gameover;         
            return card;
        }
    }
    

} // End CardDeck class definition.

 


