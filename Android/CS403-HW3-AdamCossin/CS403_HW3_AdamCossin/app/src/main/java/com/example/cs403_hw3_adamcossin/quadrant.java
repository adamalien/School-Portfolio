package com.example.cs403_hw3_adamcossin;

public class quadrant { //quadrant class to set the bounds for a quadrant on the phone screen
    double xMin; //leftmost x value
    double xMax; //rightmost x value
    double yMin; //lowest y value
    double yMax; //highest y value
    int num; //number of the quadrant (ie. 1, 2, 3, or 4)

    public quadrant(double xMin, double xMax, double yMin, double yMax, int num) { //constructor to set the values for the properties
        this.xMin = xMin;
        this.xMax = xMax;
        this.yMin = yMin;
        this.yMax = yMax;
        this.num = num;
    }

    public boolean inQuadrant(double x, double y) { //method to see if a certain coordinate is within the quadrant
        if(x > xMin && x < xMax && y > yMin && y < yMax){
            return true;
        }
        return false;
    }

    @Override
    public String toString() { //toString to print out values - mostly for debugging/testing
        return "quadrant{" +
                "xMin=" + xMin +
                ", xMax=" + xMax +
                ", yMin=" + yMin +
                ", yMax=" + yMax +
                '}';
    }
}
