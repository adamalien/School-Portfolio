//Author: Adam Cossin
//Date: Sept. 12th, 2023
//Description: a class representing a house which is a type of building that has properties of the building itself's length and width as well as the lot the building is on's length and width, and also has an owner and a pool
public class House extends Building{
	private String mOwner;
	private boolean mPool;

	public House(int length, int width, int lotLength, int lotWidth) { //constructor to set the house's properties
		super(length, width, lotLength, lotWidth);
	}
	
	public House(int length, int width, int lotLength, int lotWidth, String owner) { //constructor to set the house's properties including the owner
		this(length, width, lotLength, lotWidth);
		this.mOwner = owner;
	}
	
	public House(int length, int width, int lotLength, int lotWidth, String owner, boolean pool) { //constructor to set the house's properties including the owner and if there is a pool or not
		this(length, width, lotLength, lotWidth, owner);
		this.mPool = pool;
	}
	
	public String getOwner() { //getter for the house's owner
		return this.mOwner;
	}
	
	public boolean hasPool() { //getter for if the house has a pool or not
		return this.mPool;
	}
	
	public void setOwner(String name) { //sets the house's owner to the passed value
		this.mOwner = name;
	}
	
	public void setPool(boolean choice) { //sets if the house has a pool or not based on the passed value
		this.mPool = choice;
	}
	
	public String toString() { //overridden toString method to print out relevant info about the house
		String result = super.toString().concat("; Owner: ");
		String owner = "n/a"; //default owner value will be 'n/a' assuming there is no owner
		if(this.getOwner() != null) { //if there is an owner, however, the 'owner' string will be set to the owner's name
			owner = this.getOwner();
		}
		result += owner; //adds the result of the above owner string to the current result string
		if(this.hasPool()) { //if there is a pool, add 'has a pool' to the result string
			result += "; has a pool";
		}
		if(this.calcLotArea() > this.calcBuildingArea()) { //if the lot area is bigger than the area that the house is on, then adds 'has a big open space' to the result string
			result += "; has a big open space";
		}
		return result;
	}
	
	public boolean equals(Object o) { //method to compare if two house objects are equal (they will be equal if their building area's are equal and their 'mPool' values are equal)
		House h = (House) o; //cast the passed object to a house so that the properties can be compared
		if(this.calcBuildingArea() == h.calcBuildingArea() && this.hasPool() == h.hasPool()) { //if the building areas and 'mPool' values are equal, then the houses are equal
			return true;
		} else {
			return false;
		}
	}

}
