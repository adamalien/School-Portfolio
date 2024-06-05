package com.example.pizzamaker;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.CheckBox;
import android.widget.CompoundButton;
import android.widget.RadioButton;
import android.widget.RadioGroup;
import android.widget.SeekBar;
import android.widget.Spinner;
import android.widget.TextView;


public class MainActivity extends AppCompatActivity {
    String TAG = "PIZZA_APP";
    RadioButton rdoSmall,rdoMedium,rdoLarge;
    RadioGroup grpSize;
    TextView txtTip;
    SeekBar seekTip;
    Spinner spinPayments;
    String pay_opts[]={"Card","Crypto","Cash"};


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        grpSize = findViewById(R.id.grpSize);
        seekTip=findViewById(R.id.seekTip);
        txtTip=findViewById(R.id.txtTip);
        spinPayments = findViewById(R.id.spinPayment);

        /*

        Approach 1: Set listeners on each button.
        rdoSmall = findViewById(R.id.rdoSmall);
        rdoMedium = findViewById(R.id.rdoMed);
        rdoLarge = findViewById(R.id.rdoLarge);

        rdoSmall.setOnCheckedChangeListener((view, isChecked) -> {
            Log.d(TAG,rdoSmall.getText()+"");
        });
        */

        /* Approach 2: Set listener on radio group */

        grpSize.setOnCheckedChangeListener((radioGroup, i) -> {
            RadioButton rdoChecked = findViewById(i);
            Log.d(TAG,"CHECKED "+rdoChecked.getText());
        });

        /* Progress Bar implementation Logic */
        txtTip.setText(seekTip.getProgress()+"%");
        seekTip.setOnSeekBarChangeListener(new SeekBar.OnSeekBarChangeListener() {
            @Override
            public void onProgressChanged(SeekBar seekBar, int i, boolean b) {
                txtTip.setText(i+"%");
            }
            @Override
            public void onStartTrackingTouch(SeekBar seekBar) {}
            @Override
            public void onStopTrackingTouch(SeekBar seekBar) {}
        });

        /* spinner implementation logic */
        ArrayAdapter<String> payAdapter = new ArrayAdapter<>(this, android.R.layout.simple_spinner_dropdown_item,pay_opts);
        spinPayments.setAdapter(payAdapter);
        spinPayments.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> adapterView, View view, int i, long l) {
                Log.d(TAG,i+" "+l+" "+spinPayments.getItemAtPosition(i));
            }
            @Override
            public void onNothingSelected(AdapterView<?> adapterView) {}
        });
    } // end of onCreate

    public void checkToppings(View v){
        CheckBox chkSelected = (CheckBox) v;
        if(chkSelected.isChecked())
            Log.d(TAG,chkSelected.getText()+" Selected.");
        else
            Log.d(TAG,chkSelected.getText()+" Removed.");

    }
}