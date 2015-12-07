# Team Digitron
## Team Members
* dentia - Михаела Енчева
* Goran91 - Горан Цветков
* Aleksandra92 - Александра Стойчева

## SKOFGAD Texas Hold'em Poker AI Bot
#### Preflop Strategy
The prefop strategy uses pre-computed map and it calculates the strength of the hand according that map. Depending on the strength it raises by the hand strength percentage, checks/calls or folds

#### Postflop Strategy
The postflop strategy uses hand strength and that is the probability that a given hand is better than any other
possible hand. It consists in enumerating all possible hands that an opponent can have
a checking if hand is better than the enumerated hand. By counting the number of
times the player’s hand is ahead, it is possible to measure the quality of the hand. It is
possible to calculate the hand strength as:
~~~c#
function HandStrength(ourcards, boardcards){
 ahead = tied = behind = 0
 ourrank = Rank(ourcards, boardcards)
 /*Consider all two-card combinations of remaining
cards*/
 for each case(oppcards) {
 opprank = Rank(oppcards, boardcards)
 if(ourrank > opprank) ahead++
 else if (ourrank == opprank) tied++
 else behind++
 }
 return (ahead + tied / 2) / (ahead + tied + behind)
}
~~~

#### High Quality Code
-Factory Method for creating Decision Maker depending on the type of the game round
-State pattern 
-No Stylecop errors
-SOLID

## GitHub repository
https://github.com/NikolayIT/TeamDigitron 




