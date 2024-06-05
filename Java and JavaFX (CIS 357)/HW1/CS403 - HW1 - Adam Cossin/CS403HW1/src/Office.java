//Author: Adam Cossin
//Date: Sept. 12th, 2023
//Description: a class representing an office which is a type of building that has properties of the building itself's length and width as well as the lot the building is on's length and width, and also has a business name, and parking spaces, and a static variable counting the amount of offices created
public class Office extends Building{
	private String mBusinessName;
	private int mParkingSpaces;
	private static int sTotalOffices;

	public Office(int length, int width, int lotLength, int lotWidth) { //constructor to set the office's properties
		super(length, width, lotLength, lotWidth);
		sTotalOffices++; //increments the number of offices every time a new office is created (since all other office constructors use 'this', this constructor will be called every time an office is created)
	}
	
	public Office(int length, int width, int lotLength, int lotWidth, String businessName) { //constructor to set the office's properties including the business name
		this(length, width, lotLength, lotWidth);
		this.mBusinessName = businessName;
	}
	
	public Office(int length, int width, int lotLength, int lotWidth, String businessName, int parkingSpaces) { //constructor to set the office's properties including the business name and number of parking spaces
		this(length, width, lotLength, lotWidth, businessName);
		this.mParkingSpaces = parkingSpaces;
	}
	
	public String getBusinessName() { //getter for the business name
		return this.mBusinessName;
	}
	
	public int getParkingSpaces() { //getter for the number of parking spaces
		return this.mParkingSpaces;
	}
	
	public static int getTotalOffices() { //getter for the total number of offices created
		return sTotalOffices;
	}
	
	public void setBusinessName(String name) { //sets the business name to that of the passed value
		this.mBusinessName = name;
	}
	
	public void setParkingSpaces(int num) { //sets the number of parking spaces to the passed value
		this.mParkingSpaces = num;
	}
	
	public String toString() { //overridden toString method to print out relevant info about the office
		String result = super.toString(); //gets the result of the toString from the Building class
		String business = "unoccupied"; //default value for business name will be 'unoccupied'
		if(getBusinessName() != null) { //if the business does have a name, then the 'business' string will point to that business name instead of 'unoccupied'
			business = getBusinessName();
		}
		result += "; Business: " + business; //add the business name to the result string
		if(getParkingSpaces() > 0) { //if there is more than 0 parking spaces, then that number will be added to the result string to show the number of parking spaces
			result +=("; has " + getParkingSpaces() + " parking spaces");
		}
		result += (" (total offices: " + getTotalOffices() + ")"); //the total number of offices will be added to the result string
		return result;
	}
	
	public boolean equals(Object o) { //method to compare if two office objects are equal (they will be equal if their building area's are equal and their number of parking spaces are equal)
		Office off = (Office) o; //cast the passed object to an office so that the properties can be compared
		if(this.calcBuildingArea() == off.calcBuildingArea() && this.getParkingSpaces() == off.getParkingSpaces()) { //if their building area's are equal and their number of parking spaces are equal, then they are equal, so return true
			return true;
		} else {
			return false;
		}
	}
}
