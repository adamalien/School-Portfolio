package com.example.cs403_hw3_adamcossin;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.util.Log;
import android.widget.Button;
import android.widget.TextView;

public class SummaryActivity extends AppCompatActivity {
    Button btnPlayAgain, btnMainMenu;
    TextView tvNumTaps, tvNumDoubleTaps, tvNumSwipes, tvNumZooms, tvTotalCommands, tvFastestSwipe, tvAvgReactionTime;
    SharedPreferences sp;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_summary);

        btnPlayAgain = findViewById(R.id.btnPlayAgain); //block to get references to each object
        btnMainMenu = findViewById(R.id.btnMainMenu);
        tvNumTaps = findViewById(R.id.tvNumTaps);
        tvNumDoubleTaps = findViewById(R.id.tvNumDoubleTaps);
        tvNumSwipes = findViewById(R.id.tvNumSwipes);
        tvNumZooms = findViewById(R.id.tvNumZooms);
        tvTotalCommands = findViewById(R.id.tvTotalCommands);
        tvFastestSwipe = findViewById(R.id.tvFastestSwipe);
        tvAvgReactionTime = findViewById(R.id.tvAvgReactionTime);

        sp = getSharedPreferences("SETTINGS", Context.MODE_PRIVATE); //get the sharedPreferences from the game activity (ie. gets the results of playing the game)
        setStats(); //sets each textview to its' corresponding value from the game that was just played

        btnPlayAgain.setOnClickListener(e->{ //launches the game activity and finishes the summary activity
            Intent i = new Intent(this, GameActivity.class);
            startActivity(i);
            finish();
        });

        btnMainMenu.setOnClickListener(e->{ //launches the main menu activity and finishes the summary activity
            Intent i = new Intent(this, HomeActivity.class);
            startActivity(i);
            finish();
        });
    }

    public void setStats(){ //gets values from sharedPreferences (which contains the results from the game played) and displays them to their corresponding textviews
        int numActions = sp.getInt("NumberOfActions", 10);
        double totalTime = sp.getFloat("totalTime", 0);
        double avgTime = totalTime / numActions;
        String formattedTime = String.format("%.2f", avgTime/1000.0);
        String formattedVelocity = String.format("%.2f", sp.getFloat("fastestSwipe", 10));

        tvNumTaps.setText(""+sp.getInt("numTaps",0));
        tvNumDoubleTaps.setText(""+sp.getInt("numDoubleTaps",0));
        tvNumSwipes.setText(""+sp.getInt("numSwipes",0));
        tvNumZooms.setText(""+sp.getInt("numZooms",0));
        tvTotalCommands.setText(""+numActions);
        tvFastestSwipe.setText(formattedVelocity + " pixels/sec");
        tvAvgReactionTime.setText(formattedTime + " seconds");
    }
}