using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Scenes
{
    class Dialouge
    {
        //Fourty Char Limit
        private int charNum;
        private Bounds2 manBounds;
        private Texture character;
        private float frameIndex;
        private string charName;
        private string pathName;
        private ArrayList char1Dialouge;
        private ArrayList char2Dialouge;
        private ArrayList char3Dialouge;

        private ArrayList curDialouge;
        public Dialouge(int characterSelection)
        {
            charNum = characterSelection;
            frameIndex = 0f;

            char1Dialouge = new ArrayList()
            {
                //Tim AGAIN
                //POG
                "WAIT",
                "Now that I think about it",
                "This is where our paths diverge",
                "I am not headed to Andromeda",
                "This may be the last you ever see",
                "of your best buddy Tim",
                "Now that is just heartbreaking",
                "Reminds me of the one time",
                "back about 3 years back",
                "or was it 4",
                "hm wait so if it was 4 years ago",
                "then that would mean it was 1 year",
                "after the zexor aliens went around",
                "but I feel like that's too soon",
                "Yeah maybe 3 and a half years ago",
                "So back then believe it or not",
                "But I wasn't quite the rootin tootin",
                "Space gangster I appear today",
                "No, no, I was far more innocuous",
                "But I picked up a pal named Quark",
                "Quirky Quark, people called him",
                "Always lookin at me like",
                "He wanted me to stop talking",
                "Imagine that! Whatta guy",
                "But he was out hunting one day",
                "Dipping down planet to planet",
                "And he just",
                "Forgot to return to his ship for O2",
                "Died on the spot",
                "Say, why do they call it O2",
                "WAIT don't answer that",
                "How I phrased that",
                "Reminds me of this great joke",
                "Okok this is a hoot",
                "Get ready",
                "alright",
                "so",
                "Why do they call it",
                "Hours minutes and seconds",
                "Shouldn't it be",
                "FOURTHS THIRDS AND SECONDS??",
                "HAHAHAHAHAHAHAHAHAAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAAH",
                "Man",
                "That was GOOD",
                "Came up with that one myself",
                "Alright well",
                "My point is",
                "I miss ol Quark an awful lot",
                "Especially when I make jokes",
                "And well",
                "I'm going to miss you a lot too",
                "Keep ol Tim in your thoughts will ya",
                "I believe in you",
                "Andromeda won't know what hit them",
                "Good luck my friend"
            };

            char2Dialouge = new ArrayList()
            {
                //Tim
                //Hell Yeah
                //Shows up right before last station
                "jshdgfhsgdfhdgfjkajsurgjkjsnhgfni",
                "Well well well",
                "If it ain't my ol buddy!",
                "Told you we'd meet again",
                "Well in any case",
                "I'm here to tell you that",
                "You'rea almost there pal",
                "Almost at the Milke Way Station",
                "Your last stop before Andromeda",
                "So stock up on supplies",
                "Cause boy",
                "You don't wanna be missing out",
                "I remember this one time",
                "My wife and I were out and about",
                "Near Alpha Centauri",
                "Now my wife",
                "She's a bit cranky sometimes",
                "But who isn't am I right",
                "Anyways",
                "She came up to me right",
                "And I was drinking some iced tea",
                "Lemon flavored of course, my fav",
                ".. or was it peach flavored",
                "no no it was definitely lemon",
                "You know what they say about lemons",
                "Well",
                "I hope you do cause I don't",
                "I may seem like a smart guy but",
                "There are a lot of things I don't know",
                "But the smartest people are those",
                "Who know what they don't know",
                "I guess that makes me very smart huh",
                "So anyways",
                "My ice tea was getting a bit warm",
                "Like not WARM warm but",
                "Room temperature to say the least",
                "And so I was already a bit irritable",
                "And my wife, hoo boy",
                "She comes in and says like 'Tim'",
                "(that's me)",
                "'We are COMPLETELY out of FOOD'",
                "And you know me",
                "Witty Tim they call me",
                "I go 'ok well'",
                "'If you like food so much'",
                "'Why didn't you MARRY it'",
                "And so I sat there waiting",
                "For the inevitable cheers and laughter",
                "But she got this real hungry look",
                "And I figured",
                "Poor choice of words",
                "So I hustled on over to this station",
                "Bought like",
                "A whole BUNCH of food",
                "And some other stuff",
                "So just take advantage of this",
                "Have a safe flight, homeslice"
            };
            char3Dialouge = new ArrayList()
            {
                "Heya Pal, I'm Tim",
                "Tutorial TIm, my friends call me",
                "They also say I talk too much",
                "But really I don't see it",
                "I think I talk the perfect amount",
                "Smooth talker Tim they should say",
                "Cause that's me, a smooth talker",
                "So anyways",
                "You seem pretty new but don't fear",
                "I'll give you the low-down",
                "And if you aren't new at least",
                "You get to hear from your pal Tim",
                "So right now you're in your ship",
                "Good choice btw I love that model",
                "When you're above a planet..",
                "You can press [SPACE] to land!",
                "This lets you venture out and hunt",
                "Nabbing plants and punching aliens",
                "Both of which gives you food",
                "Move and jump with the Arrow Keys",
                "Punch/collect with the Down Key",
                "Some platforms you can't reach",
                "Unless you have some rocket boots",
                "If you get your hands on some",
                "Just press the Up Key twice",
                "Easy as Pie",
                "But be warned, watch your oxygen",
                "If your oxygen runs out you ",
                "Need to head back to your ship",
                "You can always buy more  O2 at shops",
                "They cost a pretty penny though",
                "Wihtought Oxygen you cant land",
                "However there is no risk that",
                "you die from no Oxygen on your ship",
                "You will die withought food",
                "or fuel for that matter",
                "Huh 'risk' reminds me",
                "Of this board game I used to play",
                "With my first mate Amos",
                "Famous Amos I called him",
                "He was a riot",
                "Came from Jupiter actually",
                "Never got rid of the smell",
                "Well unfortunately it's time",
                "For your pal Tim to go",
                "I gotta go do things",
                "I hate to up at leave but",
                "Don't you worry",
                "I'm sure we will see one another",
                "In this life or the next",
                "See ya round partner"
            };
            
            if (characterSelection == 1)
            {
                charName = "Tim";
                curDialouge = char1Dialouge;
            }
            else if (characterSelection == 2)
            {
                charName = "Tim";
                curDialouge = char2Dialouge;
            }
            else
            {
                charName = "Tim";
                curDialouge = char3Dialouge;
            }
            pathName = "Alien" + "3" + ".png";
            character = Engine.LoadTexture(pathName);
        }

        private int i = 0;
        private bool lastLine = false;
        private string curText;

        public void dialouge()
        {
            curText = curDialouge[i] + "";
            frameIndex = (frameIndex + Engine.TimeDelta * 2) % 2.0f;
            manBounds = new Bounds2(new Vector2(0f, ((int)frameIndex) * 640f), new Vector2(640f, 640f));
            Engine.DrawTexture(character, new Vector2(0, 25), source: manBounds);
            Engine.DrawString(curText, new Vector2(500f, 225f), Color.White, Fonts.Labelf32());
            Engine.DrawString(charName + ":", new Vector2(500f, 150f), Color.White, Fonts.Labelf32());
            Engine.DrawString("Click To Continue", new Vector2(600f, 675f), Color.White, Fonts.Labelf20());

            if (Engine.GetMouseButtonDown(MouseButton.Left))
            {
                i++;
                if (i == curDialouge.Count - 1)
                {
                    lastLine = true;
                }
                if (lastLine)
                {
                    Ship.Scene = 1;
                }
            }

            // SKIP THE DANG SCENE
            if (Engine.GetKeyDown(Key.Tab))
            {
                Ship.Scene = 1;
            }
        }
    }
}
