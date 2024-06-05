//Author: Adam Cossin
//Date: Sept. 12th, 2023
//Description: a class representing a building which has properties of the building itself's length and width as well as the lot the building is on's length and width
public class Building {
	private int mLength;
	private int mWidth;
	private int mLotLength;
	private int mLotWidth;
	
	public Building(int length, int width, int lotLength, int lotWidth) { //constructor to set the building's properties
		this.mLength = length;
		this.mWidth = width;
		this.mLotLength = lotLength;
		this.mLotWidth = lotWidth;
	}
	
	public int getLength() { //getter for the building's length
		return this.mLength;
	}
	
	public int getWidth() { //getter for the building's width
		return this.mWidth;
	}
	
	public int getLotLength() { //getter for the lot's length
		return this.mLotLength;
	}
	
	public int getLotWidth() { //getter for the lot's width
		return this.mLotWidth;
	}
	
	public void setLength(int num) { //sets the building's length to the passed value
		this.mLength = num;
	}
	
	public void setWidth(int num) { //sets the building's width to the passed value
		this.mWidth = num;
	}
	
	public void setLotLength(int num) { //sets the lot's length to the passed value
		this.mLotLength = num;
	}
	
	public void setLotWidth(int num) { //sets the lot's width to the passed value
		this.mLotWidth = num;
	}
	
	public int calcBuildingArea() { //calculates the building's area by multiplying the length by the width
		return getLength() * getWidth();
	}
	
	public int calcLotArea() { //calculates the lot's area by multiplying the length by the width
		return getLotLength() * getLotWidth();
	}
	
	public String toString() { //overridden toString method to print out relevant info about the building
		return ("A " + getLength() + "X" + getWidth() + " Building");
	}

}
