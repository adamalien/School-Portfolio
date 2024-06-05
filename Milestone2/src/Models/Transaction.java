package Models;//Author: Adam Cossin
//CIS 357, Milestone1
//Date: 3/25/22
//imports
import java.time.LocalDate;
//'Transaction' class representing a transaction object
public class Transaction {
    //declare necessary fields
    private int bookID;
    private int userID;
    private LocalDate issueDate;
    private boolean status;

    //transaction's constructor takes in necessary fields to create a transaction object
    public Transaction(int userID, int bookID) {
        super();
        this.userID = userID;
        this.bookID = bookID;
        this.status = true;
        this.issueDate = LocalDate.now();
    }
    //second user constructor to be used when 'getTransactions()' is called from the 'TransactionDAO'
    public Transaction(int bookID, int userID, LocalDate date, boolean status) {
        super();
        this.userID = userID;
        this.bookID = bookID;
        this.issueDate = date;
        this.status = status;
    }

    //auto-generated getters/setters for each relevant field so that the values can be set/read
    public int getBookID() {
        return bookID;
    }

    public void setBookID(int bookID) {
        this.bookID = bookID;
    }

    public int getUserID() {
        return userID;
    }

    public void setUserID(int userID) {
        this.userID = userID;
    }

    public LocalDate getIssueDate() {
        return issueDate;
    }

    public void setIssueDate(LocalDate issueDate) {
        this.issueDate = issueDate;
    }

    public boolean isStatus() {
        return status;
    }

    public void setStatus(boolean status) {
        this.status = status;
    }

    @Override
    //toString to display a transaction in this way when it is printed
    public String toString() {
        return "Transaction{bookID=" + bookID + ", userID=" + userID + ", issueDate=" + issueDate + ", status="
                + status + "}";
    }

}
