# One-Piece-Quiz
A game I developed for Apulia Cosplay using Unity (game engine) and VSC (C#).



I uploaded code about quiz working mechanics.
After Intro has played, game starts 4 seconds after clicking "Inizia" button.
Main characters in this game mechanics are GameManager and QuizCanvas. 
For each question to be charged, GameManager selects a random question type ( A, B or C)
and a random question index. Each question has a fixed associate background.
QuizCanvas is where questions are displayed: question text, possible answers and background.
For A and B type if the clicked answer is wrong, that answer button gets red and disabled.
Whereas, if the clicked answer is correct, that answer gets green and all answers get disabled.
C type questions require an input answer in a dedicated form. Pressing return it will evaluate typed answer.
The form gets green if the typed answer is right or red if the answer is wrong.
Next question is loaded when player click on a sun shape button.
When number of desired questions is reached, End screen appears.
A button on End screen resets the game.
