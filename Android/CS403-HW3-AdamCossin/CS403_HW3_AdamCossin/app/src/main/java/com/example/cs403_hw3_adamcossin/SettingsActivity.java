package com.example.cs403_hw3_adamcossin;

import androidx.appcompat.app.AppCompatActivity;
import androidx.constraintlayout.widget.ConstraintLayout;

import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.SeekBar;
import android.widget.TextView;
import android.widget.Toast;

import java.lang.reflect.Array;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashSet;
import java.util.Iterator;
import java.util.Set;

public class SettingsActivity extends AppCompatActivity {
        SeekBar sbCommands;
        TextView tvCommands;
        Button btnSave, btnCancel;
        Set<String> setActions;
        SharedPreferences sp;
        SharedPreferences.Editor spEditor;
        int numActions;
        CheckBox[] checkBoxes;
        CheckBox chkTap, chkDoubleTap, chkSwipe, chkZoom;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_settings);

        sbCommands = findViewById(R.id.sbCommands); //block of findViewById's to get a reference to each object
        tvCommands = findViewById(R.id.tvCommands);
        btnCancel = findViewById(R.id.btnCancel);
        btnSave = findViewById(R.id.btnSave);
        chkTap = findViewById(R.id.chkTap);
        chkDoubleTap = findViewById(R.id.chkDoubleTap);
        chkSwipe = findViewById(R.id.chkSwipe);
        chkZoom = findViewById(R.id.chkZoom);

        checkBoxes = new CheckBox[]{chkTap, chkDoubleTap, chkSwipe, chkZoom}; //get checkboxes into an array to loop through
        setActions = new HashSet<>(); //initialize array
        sp = getSharedPreferences("SETTINGS", Context.MODE_PRIVATE); //get the shared preferences
        spEditor = sp.edit(); //initialize sharedPreference editor

        numActions = sp.getInt("NumberOfActions", 10); //get 'NumberOfActions' from shared preferences to set seekbar and textview accordingly
        tvCommands.setText(numActions + "");
        sbCommands.setProgress(numActions);
        getSettings(); //sets which checkboxes should be checked based on the user's existing settings

        sbCommands.setOnSeekBarChangeListener(new SeekBar.OnSeekBarChangeListener() { //detects changes in the seekbar to properly display the current value below it
            @Override
            public void onProgressChanged(SeekBar seekBar, int i, boolean b) {
                tvCommands.setText(i+""); //set the textview to the value of the seekbar
            }
            @Override
            public void onStartTrackingTouch(SeekBar seekBar) {
            }
            @Override
            public void onStopTrackingTouch(SeekBar seekBar) {
            }
        });

        btnCancel.setOnClickListener(e->{
            //when cancel is clicked, just goes back to the main menu
            goHome();
        });

        btnSave.setOnClickListener(e->{
            //persist settings and go back to the home screen
            getSelectedCheckBoxes(); //called to fill the setActions set with the currently selected checkboxes text values (to know what has been selected)
            if(!twoCheckboxesSelected()){ //if two checkboxes aren't selected, just displays a toast
                Toast.makeText(this, "Please select at least 2 actions.", Toast.LENGTH_SHORT).show();
            }else{ //if two or more checkboxes are selected, save the settings, display a toast, and go back to the main menu
                saveSettings();
                Toast.makeText(this, "Settings saved successfully!", Toast.LENGTH_SHORT).show();
                goHome();
            }
        });
    }

    @Override
    protected void onPause() {
        //makes sure that settings are saved BEFORE the app closes
        saveSettings();
        super.onPause();
    }

    @Override
    protected void onResume() {
        //retrieves settings upon an app restart
        getSettings();
        super.onResume();
    }

    public boolean twoCheckboxesSelected(){
        //checks the size of the set, if it is greater than or equal to 2, then there is a valid number of selections, otherwise there is not
        if(setActions.size() >= 2){
            return true;
        }
        return false;
    }

    public void saveSettings() {
        //set sharedPreferences attributes
        spEditor.putInt("NumberOfActions", Integer.parseInt(tvCommands.getText().toString()));
        spEditor.putStringSet("ChosenActions", setActions);
        spEditor.apply();
    }

    public void goHome(){
        //goes back to the main menu and finishes the settings activity
        Intent i = new Intent(this, HomeActivity.class);
        startActivity(i);
        finish();
    }

    public void getSelectedCheckBoxes(){
        //gets the selected checkboxes and populates the set with only those text values
        for(int i = 0; i < checkBoxes.length; i++){
            if(checkBoxes[i].isChecked()){
                setActions.add(checkBoxes[i].getText()+"");
            }else{
                setActions.remove(checkBoxes[i].getText()+"");
            }
        }
    }

    public void getSettings(){
        //retrieves the settings from sharedPreferences to get which checkboxes should be selected based on what the user had already saved
        Set<String> set = sp.getStringSet("ChosenActions", new HashSet<>(Arrays.asList("Tap", "Double Tap", "Swipe", "Zoom")));
        String[] arr = set.toArray(new String[0]);
        for(int i = 0; i < arr.length; i++) { //loop through an array of the set values
            for(int j = 0; j < checkBoxes.length; j++){ //loop through the checkBoxes array
                if(arr[i].equals(checkBoxes[j].getText())){ //tries to match the checkBox text with a string value from sharedPreferences, if it is present that means the checkbox should be checked
                    checkBoxes[j].setChecked(true);
                }
            }
        }
    }
}