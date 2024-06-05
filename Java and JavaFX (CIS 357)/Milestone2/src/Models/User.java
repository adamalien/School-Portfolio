package Models;

//imports
import java.time.LocalDate;

//'User' class representing a user object
public class User {
    //declare necessary fields
    private int ID;
    private String name;
    private String email;
    private String address;
    private LocalDate dateOfBirth;
    private boolean isStudent;
    private double balance;

    //user's constructor takes in necessary fields to create a user object
    public User(String name, String email, String address, LocalDate dateOfBirth, boolean isStudent) {
        super();
        this.name = name;
        this.email = email;
        this.address = address;
        this.dateOfBirth = dateOfBirth;
        this.isStudent = isStudent;
        this.balance = 0.0;
    }
    //second user constructor to be used when 'getUsers()' is called from the 'UserDAO'
    public User(int ID,String name, String email, String address, LocalDate dateOfBirth, boolean isStudent, double balance) {
        super();
        this.ID = ID;
        this.name = name;
        this.email = email;
        this.address = address;
        this.dateOfBirth = dateOfBirth;
        this.isStudent = isStudent;
        this.balance = balance;
    }
    //auto-generated getters/setters for each relevant field so that the values can be set/read
    public int getID() {
        return ID;
    }
    public String getName() {
        return name;
    }
    public void setName(String name) {
        this.name = name;
    }
    public String getEmail() {
        return email;
    }
    public void setEmail(String email) {
        this.email = email;
    }
    public String getAddress() {
        return address;
    }
    public void setAddress(String address) {
        this.address = address;
    }
    public LocalDate getDateOfBirth() {
        return dateOfBirth;
    }
    public void setDateOfBirth(LocalDate dateOfBirth) {
        this.dateOfBirth = dateOfBirth;
    }
    public boolean getStudent() {
        return isStudent;
    }
    public void setStudent(boolean isStudent) {
        this.isStudent = isStudent;
    }
    public double getBalance() {
        return balance;
    }
    public void setBalance(double balance) {
        this.balance = balance;
    }
    public boolean equals(User user){
        if(this.ID == user.ID) {
            return true;
        }
        return false;
    }
    @Override
    //toString to display a user in this way when it is printed
    public String toString() {
        return "ID: " + ID + " Name: " + name;
    }
}
