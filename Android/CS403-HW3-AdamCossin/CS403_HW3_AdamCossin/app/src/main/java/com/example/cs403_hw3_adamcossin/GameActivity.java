package com.example.cs403_hw3_adamcossin;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;

import android.app.Activity;
import android.app.AlertDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.util.Log;
import android.view.GestureDetector;
import android.view.MotionEvent;
import android.view.ScaleGestureDetector;
import android.view.View;
import android.widget.TextView;

import java.time.LocalTime;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashSet;
import java.util.Random;

public class GameActivity extends AppCompatActivity {
    //String TAG = "arcadegame";
    ArrayList<Double> arrScaling = new ArrayList<>();
    TextView tvActivityOne, tvActivityTwo, tvActivityThree, tvActivityFour, tvStart;
    ScaleGestureDetector sgDetector;
    GestureDetector gDetector;
    Boolean blnStart = false;
    quadrant[] quads;
    SharedPreferences sp;
    SharedPreferences.Editor spEditor;
    quadrant quadEvent;
    String currentAction = "", neededAction = "";
    int remainingActions, tapCount, neededTaps, numTaps, numDoubleTaps, numSwipes, numZooms;
    float fastestSwipe;
    long timeStart;

    public boolean onTouchEvent(MotionEvent event) {
        if(gDetector.onTouchEvent(event) || sgDetector.onTouchEvent(event)){
            return true;
        }
        return super.onTouchEvent(event);
    }

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_game);

        tvActivityOne = findViewById(R.id.tvActivityOne); //block to get references to these objects
        tvActivityTwo = findViewById(R.id.tvActivityTwo);
        tvActivityThree = findViewById(R.id.tvActivityThree);
        tvActivityFour = findViewById(R.id.tvActivityFour);
        tvStart = findViewById(R.id.tvStart);

        quads = new quadrant[4]; //create a new array to store the quadrants for the screen
        sgDetector = new ScaleGestureDetector(this, new ScaleListener()); //detects scale gestures (zoom in/out)
        gDetector = new GestureDetector(this, new SimpleListener()); //detects swipes, taps, and double taps
        sp = getSharedPreferences("SETTINGS", Context.MODE_PRIVATE); //gets the sharedPreferences from the settings activity
        spEditor = sp.edit(); //initialize the editor for the sharedPreferences
        remainingActions = sp.getInt("NumberOfActions", 10); //initialize remainingActions to be the value that the user set in the settings (or default 10)

        tapCount = 0; neededTaps = 0; numTaps = 0; numDoubleTaps = 0; numSwipes = 0; numZooms = 0; fastestSwipe = 0; timeStart = 0; //initialize various counters
    }
    class ScaleListener extends ScaleGestureDetector.SimpleOnScaleGestureListener{
        @Override
        public boolean onScale(ScaleGestureDetector detector) {
            //zoom detection
            if(blnStart){ //if the game has started, then the scale gesture can be accepted, if not, do nothing
                arrScaling.add((double) detector.getScaleFactor());
                if(arrScaling.size() > 3){
                    if(arrScaling.get(arrScaling.size()-1) > arrScaling.get(arrScaling.size()-2)){
                        //user zoomed in
                        currentAction = "Zoom In";
                    }
                    else{
                        //user zoomed out
                        currentAction = "Zoom Out";
                    }
                }
            }
            return super.onScale(detector);
        }
        @Override
        public void onScaleEnd(ScaleGestureDetector detector) {
            //set textView back to number and clear the scaling array
            if(blnStart){ //if the game has started, then the end of the gesture can be processed, otherwise do nothing
                arrScaling.clear();
                validateZoom(detector); //sees if this action was performed in the right quadrant and was actually what was needed to progress the game
            }
            super.onScaleEnd(detector);
        }
    }

    class SimpleListener extends GestureDetector.SimpleOnGestureListener {
        @Override
        public boolean onFling(MotionEvent motionEvent, MotionEvent motionEvent1, float xVelocity, float yVelocity) {
            //swipe detection
            double changeInY = Math.abs(motionEvent.getY() - motionEvent1.getY()); //gets the change in the x values
            double changeInX = Math.abs(motionEvent.getX() - motionEvent1.getX()); //gets the change in the y values
            if(!blnStart && changeInY > changeInX && motionEvent.getY() > motionEvent1.getY()){ //initiation point of the game
                calculateQuadrants(); //calculates the properties of each quadrant after the initial swipe up has occurred
                tvStart.setVisibility(View.INVISIBLE); //hides the 'swipe up to start' text
                blnStart = true; //boolean to detect the initial launch of the game
                timeStart = System.currentTimeMillis(); //records the current system time in milliseconds
                randomize(); //starts the process of getting and displaying a random action
            }else if(blnStart){ //means that the game already started
                double velocity = Math.sqrt((xVelocity * xVelocity) + (yVelocity * yVelocity)); //get the velocity of the swipe
                if(velocity > fastestSwipe){ //see if the swipe was faster than the fastest so far, and if it was, replace fastestSwipes value with the new fastest swipe value
                    fastestSwipe = (float) velocity;
                }
                if(changeInY > changeInX) {
                    if (motionEvent.getY() > motionEvent1.getY()) { //swipe up
                        //Log.d(TAG, "Swiped up");
                        currentAction = "Swipe Up";
                        validate(motionEvent);
                    } else if (motionEvent.getY() < motionEvent1.getY()) { //swipe down
                        //Log.d(TAG, "Swiped down");
                        currentAction = "Swipe Down";
                        validate(motionEvent);
                    }
                }else{
                    if(motionEvent.getX() < motionEvent1.getX()){ //swipe right
                        //Log.d(TAG, "Swiped right");
                        currentAction = "Swipe Right";
                        validate(motionEvent);
                    }else if(motionEvent.getX() > motionEvent1.getX()){ //swipe left
                        //Log.d(TAG, "Swiped left");
                        currentAction = "Swipe Left";
                        validate(motionEvent);
                    }
                }
            }
            return false;
        }
        @Override
        public boolean onDoubleTap(MotionEvent motionEvent) {
            //double tap detection
            if(blnStart){ //if the game has already started, process the action, otherwise do nothing
                if(neededAction.equals("Tap")){ //if a double tap was detected but a tap was needed, add 2 to the tap count
                    tapCount = tapCount+2;
                }
                currentAction = "Double Tap";
                validate(motionEvent);
            }
            return false;
        }

        @Override
        public boolean onSingleTapConfirmed(@NonNull MotionEvent e) {
            //single tap detection
            if(blnStart){ //if the game has already started, process the action, otherwise do nothing
                if(neededAction.equals("Tap")){ //if the needed action was a tap, then increase tap count by 1
                    tapCount++;
                }
                currentAction = "Tap";
                validate(e);
            }
            return super.onSingleTapConfirmed(e);
        }
    }

    public void pickAQuadrant(){ //picks a random number 1-4 (representing quadrants 1-4)
        int[] zones = {1,2,3,4};
        int element = new Random().nextInt(zones.length);
        quadEvent = quads[zones[element]-1];
    }

    public String[] chosenActions(){ //gets the user's chosen actions from sharedPreferences
        String[] actions = sp.getStringSet("ChosenActions", new HashSet<>(Arrays.asList("Tap", "Double Tap", "Swipe", "Zoom"))).toArray(new String[0]);
        return actions;
    }

    public String pickAnAction(){ //picks a random action from whatever boxes the user checked in settings
        String[] actions = chosenActions();
        int element = new Random().nextInt(actions.length);
        return actions[element];
    }

    public String pickASwipeAction(){ //picks a random action for swipe (up, down, left, or right)
        //randomly picks a swipe action
        String[] options = {"Up", "Down", "Left", "Right"};
        int element = new Random().nextInt(options.length);
        return options[element];
    }

    public String pickAZoomAction(){ //picks a random action for zoom (in or out)
        //randomly picks a zoom action
        String[] options = {"In", "Out"};
        int element = new Random().nextInt(options.length);
        return options[element];
    }

    public int getNumberOfTaps(){ //picks a random number of taps (from 1-5)
        //randomly picks a number (1-5) to display for taps
        int possibleNumTaps[] = {1,2,3,4,5};
        int element = new Random().nextInt(possibleNumTaps.length);
        neededTaps = possibleNumTaps[element];
        return possibleNumTaps[element];
    }

    public void calculateQuadrants(){ //calculates the size of each quadrant on the screen and populates the quads array with those quadrants
        quadrant q1 = new quadrant(tvActivityOne.getLeft(), tvActivityOne.getRight(), tvActivityOne.getTop(), tvActivityOne.getBottom() + tvStart.getHeight(), 1);
        quadrant q2 = new quadrant(tvActivityTwo.getLeft(), tvActivityTwo.getRight(), tvActivityTwo.getTop(), tvActivityTwo.getBottom() + tvStart.getHeight(), 2);
        quadrant q3 = new quadrant(tvActivityThree.getLeft(), tvActivityThree.getRight(), tvActivityThree.getTop(), tvActivityThree.getBottom(), 3);
        quadrant q4 = new quadrant(tvActivityFour.getLeft(), tvActivityFour.getRight(), tvActivityFour.getTop(), tvActivityFour.getBottom(), 4);
        quads[0] = q1;
        quads[1] = q2;
        quads[2] = q3;
        quads[3] = q4;
    }

    public int getCurrentQuadrant(double x, double y){ //gets the current quadrant that the user performed a gesture in
        for(int i = 0; i < quads.length; i++){
            if(quads[i].inQuadrant(x,y)){
                return i+1;
            }
        }
        return 0;
    }

    public void displayAction(String action, TextView tvAction){ //displays the action for the user to perform on the passed textView
        switch (action){
            case "Tap":
                int times = getNumberOfTaps();
                tvAction.setText("Tap " + times + " times");
                neededAction = "Tap";
                numTaps++; //keeps track of the number of tap actions requested
                break;
            case "Double Tap":
                tvAction.setText("Double tap");
                neededAction = "Double Tap";
                numDoubleTaps++; //keeps track of the number of double tap actions requested
                break;
            case "Swipe":
                String swipeChoice = pickASwipeAction();
                tvAction.setText("Swipe " + swipeChoice);
                neededAction = "Swipe " + swipeChoice;
                numSwipes++; //keeps track of the number of swipe actions requested
                break;
            case "Zoom":
                String zoomChoice = pickAZoomAction();
                tvAction.setText("Zoom " + zoomChoice);
                neededAction = "Zoom " + zoomChoice;
                numZooms++; //keeps track of the number of zoom actions requested
                break;
        }
    }

    public void randomize(){
        tapCount = 0; //reset tapCount
        pickAQuadrant(); //picks a quadrant for the action to be displayed
        resetText(); //sets the text in each quadrant's textView back to that quadrant's number
        switch(quadEvent.num){ //gets the requested quadrant for the gesture to be performed in and switches to display the action in the correct textview
            case 1:
                displayAction(pickAnAction(), tvActivityOne);
                break;
            case 2:
                displayAction(pickAnAction(), tvActivityTwo);
                break;
            case 3:
                displayAction(pickAnAction(), tvActivityThree);
                break;
            case 4:
                displayAction(pickAnAction(), tvActivityFour);
                break;
        }
        remainingActions--; //decrement the number of remaining actions
    }

    public void validate(MotionEvent eve){ //sees if tap, double tap, and swipe actions were correct in that they were requested and performed in the correct quadrant
        int currentQuad = getCurrentQuadrant(eve.getX(), eve.getY());
        if(currentQuad == quadEvent.num && remainingActions > 0){ //action was performed in the correct quadrant and there are still actions remaining
            if(neededAction.equals(currentAction)){ //action that was performed is the correct action
                if(neededAction.equals("Tap")){ //if the action is 'tap', we also have to check if the correct amount of taps has been done
                    if(tapCount > neededTaps){ //resets tapCount to 0 if the user does too many taps
                        tapCount = 0;
                    }else if(tapCount == neededTaps){ //generate a new action if the user performs the correct number of taps
                        randomize();
                    }
                }else{ //no other actions have to have a counter, so a new action can be generated
                    randomize();
                }
            }else if(neededAction.equals("Tap") && currentAction.equals("Double Tap")){ //if the user double taps on a tap action, this is okay, so just check the number of taps
                if(tapCount > neededTaps){ //resets tapCount to 0 if the user does too many taps
                    tapCount = 0;
                }else if(tapCount == neededTaps){ //generate a new action if the user performs the correct number of taps
                    randomize();
                }
            }
        }else if(remainingActions == 0){ //if there are no remaining actions, show the summary page
            if(!neededAction.equals("Tap")){
                showResults();
            }else{
                if(tapCount > neededTaps){ //resets tapCount to 0 if the user does too many taps
                    tapCount = 0;
                }else if(tapCount == neededTaps){ //if the last action is a 'perform certain number of taps' command, need to check that the number of taps is correct before showing results
                    showResults();
                }
            }
        }
    }

    public void validateZoom(ScaleGestureDetector detector){ //sees if the zoom was the correct type of zoom and that it was performed in the correct quadrant
        int currentQuad = getCurrentQuadrant(detector.getFocusX(), detector.getFocusY());
        if(currentQuad == quadEvent.num && remainingActions > 0){ //means that the correct quadrant was detected and that there are actions remaining to be performed
            if(neededAction.equals(currentAction)){ //means that the correct action was detected, so generate a new action
                randomize();
            }
        }else if(remainingActions == 0){ //if the number of remaining actions is 0, that means that there shouldn't be any more actions generated, so showSummary is called
        }
    }

    public void resetText(){ //rests textViews in quadrants to be their respective numbers
        tvActivityOne.setText("1");
        tvActivityTwo.setText("2");
        tvActivityThree.setText("3");
        tvActivityFour.setText("4");
    }

    public void showResults(){ //saves the results of the game to sharedPreferences and shows the summary activity
        resetText();
        spEditor.putInt("numTaps", numTaps);
        spEditor.putInt("numDoubleTaps", numDoubleTaps);
        spEditor.putInt("numSwipes", numSwipes);
        spEditor.putInt("numZooms", numZooms);
        spEditor.putFloat("fastestSwipe", fastestSwipe);
        float duration = System.currentTimeMillis() - timeStart;
        spEditor.putFloat("totalTime", duration);
        spEditor.apply();

        Intent i = new Intent(this, SummaryActivity.class);
        AlertDialog.Builder builder = new AlertDialog.Builder(this); //build an alertDialog to show the user that all the commands have been completed
        builder.setMessage("All commands completed. Tap 'Next' to view results!");
        builder.setPositiveButton("Next", (dialogInterface, i1) -> { //when the user clicks the next button in the alertDialog, start the summary activity and finish the game activity
            startActivity(i);
            finish();
        });
        builder.setCancelable(false).show(); //ensures that the user cannot click anywhere on the screen other than the alertDialog
    }
}

