package com.example.tester;

import android.graphics.Color;
import android.os.Bundle;
import android.util.Log;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Toast;

import androidx.appcompat.app.AppCompatActivity;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.Random;

public class MainActivity extends AppCompatActivity {
    int hangmanNumber = 0; //variable that keeps track of user guesses
    Button btnGo;
    Button btnNewGame;
    TextView tvWord;
    TextView tvGuessHistory;
    EditText etLetter;
    ImageView ivHangman;
    ArrayList<String> altWords;
    String wordToGuess;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        btnGo = findViewById(R.id.btnGo);
        btnNewGame = findViewById(R.id.btnNewGame);
        etLetter = findViewById(R.id.etLetter);
        tvWord = findViewById(R.id.tvWord);
        tvGuessHistory = findViewById(R.id.tvGuessHistory);
        ivHangman = findViewById(R.id.ivHangman);

        try {
            importList();
            pickAWord();
        } catch (IOException e) {
            throw new RuntimeException(e);
        }

        btnNewGame.setOnClickListener(e->{
            reset(); //resets the ui to be that of a fresh game
        });

        btnGo.setOnClickListener(e->{
            if(etLetter.getText().toString().equals("")){ //if there's no user entry, show a toast requesting the user enter a letter
                Toast.makeText(this, "Please enter a letter to guess.", Toast.LENGTH_SHORT).show();
            }else if(etLetter.getText().toString().length() > 1){ //if the user enters more than one letter (ie. a full word), then show a toast requesting the user enter only one letter
                Toast.makeText(this, "Please enter only one letter at a time.", Toast.LENGTH_SHORT).show();
            }else if(isNumeric(etLetter.getText().toString())){ //if the user enters a number, then show a toast requesting the user enter only letters
                Toast.makeText(this, "Please enter a letter to guess... Numbers aren't allowed!", Toast.LENGTH_SHORT).show();
            }else{ //otherwise, a valid entry was made
                if(checkDuplicateLetter(etLetter.getText().toString())){ //checks if the letter has already been guessed, and if it has, then displays a toast to the user
                    Toast.makeText(this, etLetter.getText().toString() + " has already been guessed! Please guess a new letter.", Toast.LENGTH_SHORT).show();
                }else{
                    validateLetter(etLetter.getText().toString().charAt(0)); //otherwise, a valid new letter was guessed, so check if it is in the word
                }
            }
            etLetter.setText(""); //resets the editText to be blank
        });
    }

    public void reset(){ //resets the ui for a new game
        tvWord.setText("");
        hangmanNumber = 0;
        tvGuessHistory.setText("Guess History: ");
        tvGuessHistory.setTextColor(Color.BLACK);
        etLetter.setEnabled(true);
        btnGo.setEnabled(true);
        etLetter.setText("");
        setImage();
        pickAWord();
    }

    public void pickAWord(){ //picks a new word from the list of words
        String word = "";
        Random rnd = new Random();
        wordToGuess = altWords.get(rnd.nextInt(altWords.size()));
        for(int i = 0; i < wordToGuess.length(); i++){
            word+="_ ";
        }
        tvWord.setText(word);
        Log.d("gobble", wordToGuess);
    }

    public void importList() throws IOException { //imports the words between 3-6 letters from the 'wordlist10000.txt' file into an arraylist
        altWords = new ArrayList<>();
        InputStream stream = getResources().openRawResource(R.raw.wordlist10000);
        BufferedReader reader = new BufferedReader(new InputStreamReader(stream));
        String line = "";
        while((line = reader.readLine()) != null){
            if(line.length() < 3 || line.length() > 6){
                //skip the word
            }else {
                altWords.add(line); //add the word to the arraylist
            }
        }
    }

    public void validateLetter(char letter){ //checks if the letter is in the word or not
        boolean foundLetter = false;
        char[] result = tvWord.getText().toString().replace(" ", "").toCharArray(); //filters out the space characters and puts the result into a character array (this is the current state of the user's guesses)
        for(int i = 0; i < wordToGuess.length(); i++){ //loop to check if the letter that the user entered was in the word
            if(wordToGuess.charAt(i) == letter){ //letter is present in the word
                Toast.makeText(this, "Nice Work! You guessed right.", Toast.LENGTH_SHORT).show();
                result[i] = letter;
                foundLetter = true;
            }
        }
        tvGuessHistory.setText(tvGuessHistory.getText().toString()+letter); //append the guessed letter to the guess history
        if(!foundLetter){ //letter is not present in the word
            hangmanNumber++; //increase the current number of attempts
            int guessesLeft = 6 - hangmanNumber; //calculate the guesses that the user has remaining
            Toast.makeText(this, "Nope :( You have " + guessesLeft + " guesse(s) left.", Toast.LENGTH_SHORT).show();
            setImage(); //set the image to the next stage of the hangman
            checkLoss(); //check if the user has lost (ie. maxed out their attempts)
        }else{
            setSpaces(new String(result)); //reformats the text to show in the tvWord textView
            checkWin(); //checks to see if the user won (ie. has guessed all the letters)
        }
    }

    public void setImage(){ //sets the image for the current state of the hangman
        switch (hangmanNumber){
            case 0:
                ivHangman.setImageResource(R.drawable.hangman0);
                break;
            case 1:
                ivHangman.setImageResource(R.drawable.hangman1);
                break;
            case 2:
                ivHangman.setImageResource(R.drawable.hangman2);
                break;
            case 3:
                ivHangman.setImageResource(R.drawable.hangman3);
                break;
            case 4:
                ivHangman.setImageResource(R.drawable.hangman4);
                break;
            case 5:
                ivHangman.setImageResource(R.drawable.hangman5);
                break;
            case 6:
                ivHangman.setImageResource(R.drawable.hangman6);
                break;
        }
    }

    public void checkWin(){ //checks to see if the user has won (ie. guessed all letters in the word)
        if(tvWord.getText().toString().replace(" ","").equals(wordToGuess)){
            int guessesLeft = 6 - hangmanNumber;
            tvGuessHistory.setText("Yay! You won with " + guessesLeft + " guesse(s) left... Play again?");
            tvGuessHistory.setTextColor(Color.GREEN);
            etLetter.setEnabled(false);
            btnGo.setEnabled(false);
        }
    }

    public void checkLoss(){ //checks to see if the user has lost (ie. maxed out their attempts)
        if(hangmanNumber == 6){
            tvGuessHistory.setText("You lost. The correct answer was " + wordToGuess);
            tvGuessHistory.setTextColor(Color.RED);
            etLetter.setEnabled(false);
            btnGo.setEnabled(false);
        }
    }

    public void setSpaces(String word){ //reformats the text to show in the tvWord textView
        String newWord = "";
        for(int i = 0; i < word.length(); i++){
            newWord += word.charAt(i)+" ";
        }
        tvWord.setText(newWord);
    }

    public boolean checkDuplicateLetter(String letter){ //checks if the user has already guessed a letter
        String guessesSoFar = tvGuessHistory.getText().toString().substring(14).replace(" ", "");
        if(guessesSoFar.contains(letter)){
            return true;
        }
        return false;
    }

    public boolean isNumeric(String str){ //checks if a user guess is numeric
        try{
            int value = Integer.parseInt(str); //try to cast the user guess into an integer, and if it doesn't throw an error, it must have been a number, so return true
            return true;
        }catch (NumberFormatException e){ //otherwise, catches the error and returns false
            return false;
        }
    }
}