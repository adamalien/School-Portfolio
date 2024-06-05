package com.example.cs403_hw3_adamcossin;
//imageview image credits: https://unsplash.com/photos/dkXn0RbgdU4?utm_content=creditShareLink&utm_medium=referral&utm_source=unsplash
import androidx.appcompat.app.AppCompatActivity;

import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.util.Log;
import android.widget.Button;

public class HomeActivity extends AppCompatActivity {
    Button btnSettings, btnNewGame;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        btnSettings = findViewById(R.id.btnSettings); //get a reference to button objects
        btnNewGame = findViewById(R.id.btnNewGame);

        btnSettings.setOnClickListener(e->{ //when settings is clicked, launches the settings activity and finishes the main menu activity
            openSettings();
            finish();
        });

        btnNewGame.setOnClickListener(e->{ //when new game is clicked, launches the game activity and finishes the main menu activity
            openNewGame();
            finish();
        });
    }

    public void openSettings(){ //opens the settings activity
        Intent i = new Intent(this, SettingsActivity.class);
        startActivity(i);
    }

    public void openNewGame(){ //opens the new game activity
        Intent i = new Intent(this, GameActivity.class);
        startActivity(i);
    }
}