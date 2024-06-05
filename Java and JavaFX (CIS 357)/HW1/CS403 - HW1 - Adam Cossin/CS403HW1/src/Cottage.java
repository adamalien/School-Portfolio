//Author: Adam Cossin
//Date: Sept. 12th, 2023
//Description: a class representing a cottage which is a type of house that has properties of the building itself's length and width as well as the lot the building is on's length and width, and also has an owner and a pool, and a possible second floor
public class Cottage extends House {
	private boolean mSecondFloor;
	
	public Cottage(int dimension, int lotLength, int lotWidth) { //constructor to set the cottage's properties
		super(dimension, dimension, lotLength, lotWidth);
	}
	
	public Cottage(int dimension, int lotLength, int lotWidth, String owner, boolean secondFloor) { //constructor to set the cottage's properties including if it has a second floor or not
		super(dimension, dimension, lotLength, lotWidth, owner);
		this.mSecondFloor = secondFloor;
	}
	
	public boolean hasSecondFloor() { //getter for if the cottage has a second floor or not
		return this.mSecondFloor;
	}
	
	public String toString() { //overridden toString method to print out relevant info about the cottage
		String result = super.toString(); //gets the result of the toString() method from the 'House' class which derives from the 'Building' class
		if(this.hasSecondFloor()) { //if the cottage has a second story, 'is a two story cottage' is added to the result string
			result += "; is a two story cottage";
		} else { //if the cottage does not have a second story, 'is a cottage' is added to the result string
			result += "; is a cottage";
		}
		return result;
	}
}
