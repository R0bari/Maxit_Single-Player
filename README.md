# Maxit_Single-Player
Once upon a time there was a computer game called Maxit. It was just beginning of the IBM-PC era, so the game is older than average user of CodeAbbey. Later ports included version called "Hot Numbers" with pictures by Penthouse (amiga version) - we'll not share the link here! :)

The gameplay (for two players) is simple:

the square field is filled randomly with negative and positive numbers;
some cell is chosen as "current" and is empty;
the first player on his move can choose any cell in the same row as current - he erases the value here and adds it to his score - the chosen cell becames "current" then;
the second player on his move can choose any cel in the same column as current in the same way and tries to increase his score;
positive values increase player's score, while negative ones decrease it;
cells from which numbers were already taken could not be visited again by any of the players;
the game ends when one of the player's could not make a move (because of empty current row or column) - then the scores of the players are compared, one who gained more - wins.
In your free time you can try programming AI for this game - it is a good exercise since it is almost direct implementation of Minimax algorithm, allowing all of its features without additional complexity given by specific rules of chess, checkers etc.

Single-player modification
We'll use the following modifiation: there is only one player, and he performs "horizontal" and "vertical" moves in turns. On "horizontal" move he adds the taken value to his score while on "vertical" move he subtracts it.

The goal is to maximize score.
