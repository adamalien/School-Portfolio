//Author: Adam Cossin
//Date: Sept. 12th, 2023
//Description: a class representing a neighborhood which is able to gather info about the different buildings present
public class Neighborhood {
	public static String [] getInfo(Building buildings[]) { //method which takes in an array of buildings and gathers each individual building's 'toString' to show that building's relevant info
		String[] info = new String[buildings.length];
		for (int i = 0; i < buildings.length; i++) {
			info[i] = buildings[i].toString();
		}
		return info;
	}
	
	public static int calcArea(Building buildings[]) { //method which takes in an array of buildings and gathers each individual building lot's area and adds them together to find the neighborhood's total lot area
		int lotSize = 0;
		for (Building b : buildings) {
			lotSize += b.calcLotArea();
		}
		return lotSize;
	}
}
