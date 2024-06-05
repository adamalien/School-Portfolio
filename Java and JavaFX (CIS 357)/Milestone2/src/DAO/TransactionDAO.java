package DAO;
//imports
import Models.Transaction;
import java.sql.*;
import java.util.ArrayList;

public class TransactionDAO {
    //new connection
    Connection connection;
    //default constructor to initialize the connection and specify the database
    public TransactionDAO() throws SQLException {
        String url = "jdbc:sqlite:dbLib.db";
        connection = DriverManager.getConnection(url);
    }
    //method which takes in a transaction object and inserts it using the relevant fields into the database's 'libTransactions' table
    public void insertTransaction(Transaction t) throws SQLException {
        //statement for inserting into the libTransactions table
        PreparedStatement ps = connection.prepareStatement("INSERT INTO LIBTRANSACTIONS VALUES(?,?,?,?)");
        //convert transaction object's issue date into a sql date
        java.sql.Date sqlDate = java.sql.Date.valueOf(t.getIssueDate());
        //sets each '?' from 'VALUES' to the correct values for the field (ie. inserts the book's id in the 'bookID' column, etc.)
        ps.setInt(1,t.getBookID());
        ps.setInt(2,t.getUserID());
        ps.setDate(3,sqlDate);
        ps.setBoolean(4,t.isStatus());
        //updates the database to include the new transaction
        ps.executeUpdate();
    }
    //method which takes in a transaction object and updates it's status in the database
    public void updateTransaction(Transaction t) throws SQLException {
        //statement for updating a transaction with a specified bookID and userID to have a new status
        PreparedStatement ps = connection.prepareStatement("UPDATE LIBTRANSACTIONS SET STATUS=? WHERE BOOKID=? AND USERID=?");
        //sets the transaction with specified IDs status to the opposite of what it was (will be used when a book is returned)
        ps.setBoolean(1,!t.isStatus());
        ps.setInt(2,t.getBookID());
        ps.setInt(3,t.getUserID());
        ps.executeUpdate();
    }
    //method which takes in a transaction object and deletes it from the database
    public void deleteTransaction(Transaction t) throws SQLException{
        //statement for deleting a transaction with a specified bookID and userID
        PreparedStatement ps = connection.prepareStatement("DELETE FROM LIBTRANSACTIONS WHERE BOOKID=? AND USERID=?");
        ps.setInt(1,t.getBookID());
        ps.setInt(2,t.getUserID());
        ps.executeUpdate();
    }
    //method which will return an array of transactions from the database
    public ArrayList<Transaction> getTransactions() throws SQLException {
        //statement which will return all transactions from the database
        PreparedStatement ps = connection.prepareStatement("SELECT * FROM LIBTRANSACTIONS");
        //will get the transactions from the database after the above statement is run
        ResultSet rs = ps.executeQuery();
        //create a new arrayList that will hold our transactions
        ArrayList<Transaction> transactions = new ArrayList<>();
        //while there is another transaction from the database, creates a new transaction containing the relevant fields and pushes it into the array
        while(rs.next()){
            Transaction temp = new Transaction(
                    rs.getInt(1),
                    rs.getInt(2),
                    rs.getDate(3).toLocalDate(),
                    rs.getBoolean(4)
            );
            transactions.add(temp);
        }
        //returns the array of transactions after all transactions have been added
        return transactions;
    }
}
