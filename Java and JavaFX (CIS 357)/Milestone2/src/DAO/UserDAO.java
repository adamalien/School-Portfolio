package DAO;
//imports
import Models.User;
import java.sql.*;
import java.util.ArrayList;

public class UserDAO {
    //new connection
    Connection connection;
    //default constructor to initialize the connection and specify the database
    public UserDAO() throws SQLException {
        String url = "jdbc:sqlite:dbLib.db";
        connection = DriverManager.getConnection(url);
    }
    //method which takes in a user object and inserts it using the relevant fields into the database's 'users' table
    public void insertUser(User u) throws SQLException {
        //statement for inserting into the users table
        PreparedStatement ps = connection.prepareStatement("INSERT INTO USERS(NAME,EMAIL,ADDRESS,DATEOFBIRTH,ISSTUDENT,BALANCE) VALUES(?,?,?,?,?,?)");
        //convert user object's date of birth into a sql date
        java.sql.Date sqlDate = java.sql.Date.valueOf(u.getDateOfBirth());
        //sets each '?' from 'VALUES' to the correct values for the field (ie. inserts the user's name in the 'name' column, etc.)
        ps.setString(1,u.getName());
        ps.setString(2,u.getEmail());
        ps.setString(3,u.getAddress());
        ps.setDate(4,sqlDate);
        ps.setBoolean(5,u.getStudent());
        ps.setDouble(6, u.getBalance());
        //updates the database to include the new user
        ps.executeUpdate();
    }
    //method which takes in a user object and updates their balance in the database
    public void updateUser(User u) throws SQLException {
        //statement for updating a user with a specified ID to have a new balance
        PreparedStatement ps = connection.prepareStatement("UPDATE USERS SET BALANCE=? WHERE ID=?");
        //sets the user with specified ID's balance to their new balance (will be called after u.setBalance() was called, so the balance will contain a new value)
        ps.setDouble(1,u.getBalance());
        ps.setInt(2,u.getID());
        ps.executeUpdate();
    }
    //method which will return an array of users from the database
    public ArrayList<User> getUsers() throws SQLException {
        //statement which will return all users from the database
        PreparedStatement ps = connection.prepareStatement("SELECT * FROM USERS");
        //will get the users from the database after the above statement is run
        ResultSet rs = ps.executeQuery();
        //create a new arrayList that will hold our users
        ArrayList<User> users = new ArrayList<>();
        //while there is another user from the database, creates a new user containing the relevant fields and pushes it into the array
        while(rs.next()){
            User temp = new User(
                    rs.getInt(1),
                    rs.getString(2),
                    rs.getString(3),
                    rs.getString(4),
                    rs.getDate(5).toLocalDate(),
                    rs.getBoolean(6),
                    rs.getDouble(7)
            );
            users.add(temp);
        }
        //returns the array of users after all users have been added
        return users;
    }
}
