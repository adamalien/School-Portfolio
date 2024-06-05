package Models;
//imports
import DAO.BookDAO;
import DAO.TransactionDAO;
import DAO.UserDAO;
import java.sql.SQLException;
import java.time.LocalDate;
import java.time.temporal.ChronoUnit;
import java.util.*;
//updated to include references to the database as opposed to arrayLists
public class Library {
    public UserDAO users;
    public BookDAO books;
    public TransactionDAO transactions;
    private int MAX_BOOK_LIMIT=3;
    private int MAX_LOAN_DAYS=14;
    public ArrayList<String> msgLog;

    public Library() throws SQLException {
        this.users = new UserDAO();
        this.books = new BookDAO();
        this.transactions = new TransactionDAO();
        msgLog = new ArrayList<>();
    }

    public void addBook(Book b) throws SQLException {
        //calls insertBook
        books.insertBook(b);
    }
    public void addUser(User u) throws SQLException {
        //calls insertUser
        users.insertUser(u);
    }
    public void addTransaction(Transaction t) throws SQLException {
        //calls insertTransaction
        transactions.insertTransaction(t);
    }
    public boolean isAvailable(int bookID) throws SQLException {
        for(Transaction t:transactions.getTransactions()){
            if (t.getBookID() == bookID && t.isStatus())
                return false;
        }
        return true;
    }

    public int getBorrowCount(int userID) throws SQLException {
        int count=0;
        for(Transaction t: transactions.getTransactions()){
            if (t.getUserID()== userID && t.isStatus())
                count++;
        }
        return count;
    }

    public LocalDate getDueDate(LocalDate issueDate) {
        return issueDate.plusDays(MAX_LOAN_DAYS);
    }

    public boolean issueBook(int userID, int bookID) throws SQLException {
        User u = getUser(userID);
        //check if book is unavailable
        if (!isAvailable(bookID)){
            return false;
        }
        //check if max books limit has been reached or outstanding fines
        if (getBorrowCount(userID) >= MAX_BOOK_LIMIT) {
            return false;
        }
        //check if user has outstanding balance
        if (u.getBalance() > 0){
            return false;
        }
        //when the book is ready to be issued, we have to check if this user has previously checked out this book, if they have, we have to delete
        //the previous transaction from the table and add a new one to the table (because there cannot be 2 rows with the same bookID/userID combination)
        for (Transaction t: transactions.getTransactions()) {
            if (t.getBookID() == bookID && t.getUserID() == userID) {
                transactions.deleteTransaction(t);
                break;
            }
        }
        //create a new transaction and add it to the database
        Transaction trans = new Transaction(userID,bookID);
        addTransaction(trans);
        return true;
    }

    public boolean returnBook(int bookID) throws SQLException {
        Transaction trans=null;
        for (Transaction t: transactions.getTransactions())
            if (t.getBookID()==bookID && t.isStatus()){
                trans = t;
                break;
            }
        if (trans==null){
            return false;
        }
        //compute Fines
        int userID = trans.getUserID();
        User u = getUser(userID);
        Book b = getBook(bookID);
        double fine = computeFine(trans);
        u.setBalance(u.getBalance()+fine);
        //updates the user to reflect their balance
        users.updateUser(u);
        //updates the transaction's status to be false
        transactions.updateTransaction(trans);
        msgLog.clear();
        if(fine == 0){
            msgLog.add("Thanks for returning "+b.getName()+"!");
        }
        else{
            msgLog.add("You returned " + b.getName() + " " + fine + " days late!");
            msgLog.add("Your outstanding balance is $" + u.getBalance());
        }
        return true;
    }

    public void collectFine(User u) throws SQLException {
        if (u.getBalance()>0){
            u.setBalance(0);
            //updates the user to reflect their fine has been collected
            users.updateUser(u);
        }
    }

    private double computeFine(Transaction t)
    {
        long days = t.getIssueDate().until(LocalDate.now(), ChronoUnit.DAYS);
        if (days<=MAX_LOAN_DAYS)
            return 0;

        return days;
    }

    public ArrayList<Book> searchBook(String name) throws SQLException {
        ArrayList<Book> results= new ArrayList<>();
        for (Book b: books.getBooks()) {
            if (b.getName().toLowerCase().contains(name.toLowerCase()))
                results.add(b);
        }
        return results;
    }

    //helper method to search for a name in the library's list of users
    public ArrayList<User> searchUser(String str) throws SQLException {
        //create new arrayList 'temp'
        ArrayList<User> temp = new ArrayList<>();
        //goes through the library's users, if the user name contains the searched string, adds it to the temp array
        for(User u: users.getUsers()) {
            if(u.getName().toLowerCase().contains(str.toLowerCase())) {
                temp.add(u);
            }
        }
        //returns the temp array which contains any user containing the passed string
        return temp;
    }

    public Book getBook(int bookID) throws SQLException {
        for (Book temp : books.getBooks()){
            if (temp.getID()==bookID){
                return temp;
            }
        }
        return null;
    }

    public User getUser(int userID) throws SQLException {
        for (User temp : users.getUsers()){
            if (temp.getID()==userID){
                return temp;
            }
        }
        return null;
    }

}
