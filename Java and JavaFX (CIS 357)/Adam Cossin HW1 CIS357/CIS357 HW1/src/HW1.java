//CIS357 HW1
//Author: Adam Cossin
//Date: 2/3/2022
//Description: This is a program that will allow you to import a file of students, and pass them as an arrayList of objects. From there, you can
//sort the list, print out the list, or export a detailed grade report for all students listed
import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileWriter;
import java.io.IOException;
import java.util.*;
public class HW1 {
//test program with choices to import a file, show the contents of the file, export a grade report, or sort the list of students from the imported file
	public static void main(String[] args) throws IOException {
		//initialize a list to be used
		StudentList list = new StudentList();
		//create a scanner to read user input
		Scanner input = new Scanner(System.in);
		//print out the menu
		System.out.println("\t*** Report Generator ***");
		System.out.println("I\t Import students from file");
		System.out.println("L\t Show student roster");
		System.out.println("E\t Export a grade report");
		System.out.println("S\t Sort Student List");
		System.out.println("M\t Show this Menu");
		System.out.println("Q\t Quit Program");
		String choice = input.next();
		//while loop to check for input from the console to 'navigate' the menu
		while(!choice.toUpperCase().contains("Q")) {
			String filename = "";
			if(choice.toUpperCase().contains("I")) {	
				System.out.print("Enter filename: ");
				//takes in user-passed filename
				filename = input.next();
				//imports file
				list.importFromFile(filename);
				//points input to the next line to read in next input
				choice=input.next();
			}
			else if(choice.toUpperCase().contains("L")) {
				//shows list of students
				list.showList();
				choice=input.next();
			}
			else if(choice.toUpperCase().contains("E")) {
				System.out.print("Enter filename: ");
				//takes in user-passed filename
				String exportedFile = input.next();
				//generates the student grade report
				list.generateReport(exportedFile);
				choice=input.next();
			}
			else if(choice.toUpperCase().contains("S")) {
				//sorts the list of students
				list.sortStudentList();
				choice=input.next();
			}
			//shows the menu again
			else if(choice.toUpperCase().contains("M")) {
				System.out.println("\t\t*** Report Generator ***");
				System.out.println("I\t\t Import students from file");
				System.out.println("L\t\t Show student roster");
				System.out.println("E\t\t Export a grade report");
				System.out.println("S\t\t Sort Student List");
				System.out.println("M\t\t Show this Menu");
				System.out.println("Q\t\t Quit Program");
				choice=input.next();
			}
			else {
				System.out.println("Not a valid choice! Please choose something else.");
				choice=input.next();
			}
		}
		//quits when the user enters q, and prints this message
		System.out.println("Goodbye!");
		input.close();
	}
}
//basic student class with dummy values and methods to be overridden/overloaded by child classes
class Student {
	private String ftname;
	private String lname;
	private Course c;
	public String getFtname() {
		return ftname;
	}
	public void setFtname(String ftname) {
		this.ftname = ftname;
	}
	public String getLname() {
		return lname;
	}
	public void setLname(String lname) {
		this.lname = lname;
	}
	public Course getC() {
		return c;
	}
	public void setC(Course c) {
		this.c = c;
	}
	//overridden in child classes
	public double getFinalExam() {
		return 0;
	}
	//overridden and overloaded in child classes
	public double getFinalGrade() {
		return 0;
	}
	//overridden in child classes
	public String toString() {
		return "";
	}
	//overridden in child classes
	public String getLetterGrade() {
		return "";
	}
}

//courses that will be used
enum Course{
	HISTORY,MATH,PHYSICS;
}

//history student class with methods specific to history students
class HistoryStudent extends Student{
	private double rawFinalAverage;
	private double finalGrade;
	private double attendance;
	private double project;
	private double midterm;
	private double finalExam;
	private Course c = Course.HISTORY;
	private String letterGrade;
	//getters and setters for variables above
	public Course getC() {
		return c;
	}
	public void setC(Course c) {
		this.c = c;
	}
	public String getLetterGrade() {
		return letterGrade;
	}
	public void setLetterGrade(String letterGrade) {
		this.letterGrade = letterGrade;
	}
	public double getFinalGrade() {
		return finalGrade;
	}
	public void setFinalGrade(double finalGrade) {
		this.finalGrade = finalGrade;
	}
	public double getFinalExam() {
		return finalExam;
	}
	public void setFinalExam(double finalExam) {
		this.finalExam = finalExam;
	}
	//takes in the grades for history students
	double getFinalGrade(double attendance, double project, double midterm, double finalExam) {
		this.attendance = attendance;
		this.project = project;
		this.midterm = midterm;
		this.finalExam = finalExam;
		//calculates rawFinalAverage based on specified weight
		rawFinalAverage = (attendance*0.1)+(project*0.3)+(midterm*0.3)+(finalExam*0.3);
		//calculates finalGrade based on curve of rawFinalAverage
		finalGrade = 10*Math.sqrt(rawFinalAverage);
		//sets current students letter grade based on percentages specified
		if(finalGrade>=90) {
			setLetterGrade("A");
		}
		else if(finalGrade<90 && finalGrade>=80) {
			setLetterGrade("B");
		}
		else if(finalGrade<80 && finalGrade>=70) {
			setLetterGrade("C");
		}
		else if(finalGrade<70 && finalGrade>=60) {
			setLetterGrade("D");
		}
		else {
			setLetterGrade("F");
		}
		//returns a final grade that has only 2 decimal places
		return Double.parseDouble(String.format("%.2f", finalGrade));
	}
	//overridden toString to output last name, first name, and course
	public String toString() {
		String str = String.format("%-15s", getLname());
		String str1 = String.format("%-15s", getFtname());
		String str2 = String.format("%-15s", c);
		return str+str1+str2;
	}
	
}
//math student class with methods specific to math students
class MathStudent extends Student{
	private double finalGrade;
	private double quiz1;
	private double quiz2;
	private double quiz3;
	private double quiz4;
	private double quiz5;
	private double midterm1;
	private double midterm2;
	private double finalExam;
	private Course c = Course.MATH;
	private String letterGrade;
	//getters and setters
	public Course getC() {
		return c;
	}
	public void setC(Course c) {
		this.c = c;
	}
	public String getLetterGrade() {
		return letterGrade;
	}
	public void setLetterGrade(String letterGrade) {
		this.letterGrade = letterGrade;
	}
	public double getFinalGrade() {
		return finalGrade;
	}
	public void setFinalGrade(double finalGrade) {
		this.finalGrade = finalGrade;
	}
	public double getFinalExam() {
		return finalExam;
	}
	public void setFinalExam(double finalExam) {
		this.finalExam = finalExam;
	}
	//method to calculate final grade from scores relevant to math students
	double getFinalGrade(double quiz1, double quiz2, double quiz3, double quiz4, double quiz5, double midterm1, double midterm2, double finalExam) {
		this.quiz1=quiz1;
		this.quiz2=quiz2;
		this.quiz3=quiz3;
		this.quiz4=quiz4;
		this.quiz5=quiz5;
		this.midterm1=midterm1;
		this.midterm2=midterm2;
		this.finalExam=finalExam;
		//calculates quiz average
		double quizAverage = (quiz1+quiz2+quiz3+quiz4+quiz5)/5;
		//calculates final grade with respective weights
		finalGrade = (quizAverage*0.2)+(midterm1*0.25)+(midterm2*0.25)+(finalExam*0.3);
		//determines letter grade based on final grade percentage
		if(finalGrade>=90) {
			setLetterGrade("A");
		}
		else if(finalGrade<90 && finalGrade>=80) {
			setLetterGrade("B");
		}
		else if(finalGrade<80 && finalGrade>=70) {
			setLetterGrade("C");
		}
		else if(finalGrade<70 && finalGrade>=60) {
			setLetterGrade("D");
		}
		else {
			setLetterGrade("F");
		}
		//returns a double with up to 2 decimal places
		return Double.parseDouble(String.format("%.2f", finalGrade));
	}
	//overridden toString
	public String toString() {
		String str = String.format("%-15s", getLname());
		String str1 = String.format("%-15s", getFtname());
		String str2 = String.format("%-15s", c);
		return str+str1+str2;
	}
}
//physics student class with methods specific to physics students
class PhysicsStudent extends Student{
	private double finalGrade;
	private ArrayList<Double> labs=new ArrayList<Double>();
	private double labs1;
	private double labs2;
	private double labs3;
	private double labsAverage;
	private double researchPaper;
	private double midterm;
	private double finalExam;
	private Course c = Course.PHYSICS;
	private String letterGrade;
	//getters and setters
	public Course getC() {
		return c;
	}
	public void setC(Course c) {
		this.c = c;
	}
	public String getLetterGrade() {
		return letterGrade;
	}
	public void setLetterGrade(String letterGrade) {
		this.letterGrade = letterGrade;
	}
	public double getFinalGrade() {
		return finalGrade;
	}
	public void setFinalGrade(double finalGrade) {
		this.finalGrade = finalGrade;
	}
	public double getFinalExam() {
		return finalExam;
	}
	public void setFinalExam(double finalExam) {
		this.finalExam = finalExam;
	}
	//method to calculate final grade for physics students relevant scores
	double getFinalGrade(double labs1, double labs2, double labs3, double researchPaper, double midterm, double finalExam) {
		this.labs1=labs1;
		this.labs2=labs2;
		this.labs3=labs3;
		this.researchPaper=researchPaper;
		this.midterm=midterm;
		this.finalExam=finalExam;
		labs.add(labs1);
		labs.add(labs2);
		labs.add(labs3);
		//if block to determine which 2 lab scores to keep (ie. which scores are highest)
		if(labs.get(0)<labs.get(1)&&labs.get(0)<labs.get(2)) {
			labs.remove(0);
		}
		else if(labs.get(0)<labs.get(1)&&labs.get(0)>labs.get(2)) {
			labs.remove(2);
		}
		else if(labs.get(0)>labs.get(1)&&labs.get(1)<labs.get(2)) {
			labs.remove(1);
		}
		//calculates average of lab assignments
		labsAverage = (labs.get(0)+labs.get(1))/2;
		//calculates final grade based on respective weights
		finalGrade=(labsAverage*0.2)+(researchPaper*0.25)+(midterm*0.25)+(finalExam*0.3);
		//determines letter grade
		if(finalGrade>=90) {
			setLetterGrade("A");
		}
		else if(finalGrade<90 && finalGrade>=80) {
			setLetterGrade("B");
		}
		else if(finalGrade<80 && finalGrade>=70) {
			setLetterGrade("C");
		}
		else if(finalGrade<70 && finalGrade>=60) {
			setLetterGrade("D");
		}
		else {
			setLetterGrade("F");
		}
		//returns a double with up to 2 decimal points
		return Double.parseDouble(String.format("%.2f", finalGrade));
	}
	//overridden toString
	public String toString() {
		String str = String.format("%-15s", getLname());
		String str1 = String.format("%-15s", getFtname());
		String str2 = String.format("%-15s", c);
		return str+str1+str2;
	}
}
//class for making a list of Students and populating it by importing a file. Then, allows sorting and generating a report from imported file
class StudentList{
	private ArrayList<Student> fileContents;
	//default constructor to initialize arrayList
	public StudentList() {
		fileContents = new ArrayList<Student>();
	}
	//method to allow importing of data from a file and passes it into an arrayList of students
	public void importFromFile(String fname) throws FileNotFoundException {
		//create a new file
		File file = new File("/Users/adama/Desktop/"+fname);
		//checks if the file exists, and if it doesn't, displays a message
		if(!file.exists()) {
			System.out.println("This file doesn't exist!");
			return;
		}
		//makes sure that the file can be read
		if(!file.canRead()) {
			file.setReadable(true);
		}
		//create a scanner that will scan through the file
		Scanner scanner = new Scanner(file);
		//dummy variable
		double endGrade= 0;
		//reads in the data from the imported file
		while(scanner.hasNextLine()) {
			//gets the full name from the respective lines of the file
			String[]fullName=scanner.nextLine().split(",");
			//gets the course info from the respective lines of the file (includes course name and scores)
			String[] courseInfo=scanner.nextLine().split(" ");
			//create a new arrayList for scores
			ArrayList<Double> scores = new ArrayList<Double>();
			//if block to determine what type of student to make the student data that is being passed
			if(courseInfo[0].equals("History")) {
				HistoryStudent s = new HistoryStudent();
				s.setFtname(fullName[1]);
				s.setLname(fullName[0]);
				s.setC(Course.HISTORY);
				//populates the scores arrayList to be passed to 'getFinalGrade' method later
				for(int indGrade = 1; indGrade<courseInfo.length; indGrade++) {
					scores.add(Double.parseDouble(courseInfo[indGrade]));
				}
				//calculates and sets the student's final grade
				endGrade = s.getFinalGrade(scores.get(0),scores.get(1),scores.get(2), scores.get(3));
				s.setFinalGrade(endGrade);
				//sets the student's final exam score
				s.setFinalExam(scores.get(3));
				//adds the student object to the arrayList
				fileContents.add(s);
			}
			//same logic as above but for math students
			else if(courseInfo[0].equals("Math")) {
				MathStudent s = new MathStudent();
				s.setFtname(fullName[1]);
				s.setLname(fullName[0]);
				s.setC(Course.MATH);
				for(int indGrade = 1; indGrade<courseInfo.length; indGrade++) {
					scores.add(Double.parseDouble(courseInfo[indGrade]));
				}
				endGrade = s.getFinalGrade(scores.get(0),scores.get(1),scores.get(2), scores.get(3), scores.get(4), scores.get(5), scores.get(6), scores.get(7));
				s.setFinalGrade(endGrade);
				s.setFinalExam(scores.get(7));
				fileContents.add(s);
			}
			//same logic as above but for physics students
			else if(courseInfo[0].equals("Physics")) {
				PhysicsStudent s = new PhysicsStudent();
				s.setFtname(fullName[1]);
				s.setLname(fullName[0]);
				s.setC(Course.PHYSICS);
				for(int indGrade = 1; indGrade<courseInfo.length; indGrade++) {
					scores.add(Double.parseDouble(courseInfo[indGrade]));
				}
				endGrade = s.getFinalGrade(scores.get(0),scores.get(1),scores.get(2), scores.get(3), scores.get(4), scores.get(5));
				s.setFinalGrade(endGrade);
				s.setFinalExam(scores.get(5));
				fileContents.add(s);
			}
		}
		scanner.close();
	}
	//method to generate a report by writing relevant data to a user specified file
	public void generateReport(String fname) throws IOException {
		//create a new file writer to export our file
		FileWriter writer = new FileWriter(fname);
		//initialize arrayLists for history, math, and physics students
		ArrayList<Student> history= new ArrayList<Student>();
		ArrayList<Student> math= new ArrayList<Student>();
		ArrayList<Student> physics= new ArrayList<Student>();
		//initialize variables that will hold the number of the respective letter grades
		int As=0, Bs=0, Cs=0, Ds=0, Fs = 0;
		//header
		writer.write("Student Grade Summary\n");
		writer.write("---------------------\n");
		//for loop that loops through the student objects in the arrayList and add them to their respective arrayLists as initialized earlier in this method
		for(int i = 0; i <fileContents.size(); i++) {
			if(fileContents.get(i).getC().toString().equals("HISTORY")) {
				history.add(fileContents.get(i));
			}
			else if(fileContents.get(i).getC().toString().equals("MATH")) {
				math.add(fileContents.get(i));
			}
			else if(fileContents.get(i).getC().toString().equals("PHYSICS")) {
				physics.add(fileContents.get(i));
			}
		}
		//for loop that calculates the amount of respective letter grades in the report
		for(int j = 0; j<fileContents.size(); j++) {
			if(fileContents.get(j).getLetterGrade().equals("A")) {
				As++;
			}
			else if(fileContents.get(j).getLetterGrade().equals("B")) {
				Bs++;
			}
			else if(fileContents.get(j).getLetterGrade().equals("C")) {
				Cs++;
			}
			else if(fileContents.get(j).getLetterGrade().equals("D")) {
				Ds++;
			}
			if(fileContents.get(j).getLetterGrade().equals("F")) {
				Fs++;
			}
		}
		//physics class header
		writer.write("\n\nPHYSICS CLASS\n\n");
		writer.write("Student\t\t\t\tFinal\t\tFinal\t\tLetter\n");
		writer.write("Name\t\t\t\tExam\t\tAvg\t\tGrade\n");
		writer.write("---------------------------------------------------------------------\n");
		//for loop to correct any spacing issues when the report is generated, and to print each value as specified
		for(int i = 0; i< physics.size(); i++) {
			String fullname = physics.get(i).getFtname()+" "+physics.get(i).getLname();
			if(fullname.length()<=15) {
				fullname = fullname+"      ";
			}
			String pfe = "\t\t"+physics.get(i).getFinalExam();
			String pfg = "\t\t"+physics.get(i).getFinalGrade();
			String plg = "\t\t"+ physics.get(i).getLetterGrade();
			writer.write(fullname+pfe+pfg+plg+"\n");
		}
		//history class header
		writer.write("\n\nHISTORY CLASS\n\n");
		writer.write("Student\t\t\t\tFinal\t\tFinal\t\tLetter\n");
		writer.write("Name\t\t\t\tExam\t\tAvg\t\tGrade\n");
		writer.write("---------------------------------------------------------------------\n");
		//same for loop logic as above but for history students
		for(int i = 0; i< history.size(); i++) {
			String fullname = history.get(i).getFtname()+" "+history.get(i).getLname();
			if(fullname.length()<=15) {
				fullname = fullname+"      ";
			}
			String hfe = "\t\t"+history.get(i).getFinalExam();
			String hfg = "\t\t"+history.get(i).getFinalGrade();
			String hlg = "\t\t"+ history.get(i).getLetterGrade();
			writer.write(fullname+hfe+hfg+hlg+"\n");
		}
		//math class header
		writer.write("\n\nMATH CLASS\n\n");
		writer.write("Student\t\t\t\tFinal\t\tFinal\t\tLetter\n");
		writer.write("Name\t\t\t\tExam\t\tAvg\t\tGrade\n");
		writer.write("---------------------------------------------------------------------\n");
		//same for loop logic as above but for math students
		for(int i = 0; i< math.size(); i++) {
			String fullname = math.get(i).getFtname()+" "+math.get(i).getLname();
			if(fullname.length()<=15) {
				fullname = fullname+"      ";
			}
			String mfe = "\t\t"+math.get(i).getFinalExam();
			String mfg = "\t\t"+math.get(i).getFinalGrade();
			String mlg = "\t\t"+ math.get(i).getLetterGrade();
			writer.write(fullname+mfe+mfg+mlg+"\n");
		}
		//grade distribution header which is followed by the number of grades present in student data
		writer.write("\n\n\nOVERALL GRADE DISTRIBUTION\n\n");
		writer.write("A:\t"+As+"\n");
		writer.write("B:\t"+Bs+"\n");
		writer.write("C:\t"+Cs+"\n");
		writer.write("D:\t"+Ds+"\n");
		writer.write("F:\t"+Fs+"\n");
		writer.close();
	}
	//method to show a list of students from the imported list
	public void showList() throws FileNotFoundException {
		//corrects spacing formatting issues
		String str = String.format("%-10s", "Last");
		String str1 = String.format("%-10s", "First");
		String str2 = String.format("%-10s", "Course");
		System.out.println(str+"      "+str1+"    "+str2);
		int size = fileContents.size();
		//prints each Student's data as described
		for(int i = 0; i<size; i++) {
			System.out.println(fileContents.get(i));
		}
		
	}
	public void sortStudentList(){
		//calls sort method in collections interface to implement a comparator (similar to comparable here), which takes in the arrayList and a comparator of student objects
		Collections.sort(fileContents, new Comparator<Student>() {
			//compares two different objects' last names and sorts them based on which comes before the other alphabetically, and if the last names are the same, sorts them by first name
			public int compare(Student o1, Student o2) {
				//compares object1's first name to object2's first name
				if(o1.getLname().equals(o2.getLname())) {
					return o1.getFtname().compareTo(o2.getFtname());
				}
				//compares object1's last name to object 2's last name
				else {
					return o1.getLname().compareTo(o2.getLname());
				}
			}
		});
	}
}