package Controllers;
//imports
import Models.Book;
import Models.Library;
import Models.Transaction;
import Models.User;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.scene.control.Label;
import javafx.scene.control.ListView;
import javafx.scene.control.TextField;

import java.sql.SQLException;

//class for the issueBook controller
public class IssueBookController {
    Library l;

    @FXML
    private ListView<Book> lstBooks;

    @FXML
    private ListView<User> lstUsers;

    @FXML
    private TextField txtBookID;

    @FXML
    private TextField txtBookSearch;

    @FXML
    private TextField txtUserID;

    @FXML
    private TextField txtUserSearch;

    @FXML
    private Label txtMsg;
    //onAction for the issueBook button which will issue a book to the user and display a message at the bottom of the window
    @FXML
    void btnIssueBook(ActionEvent event) throws SQLException {
        //get a handle on the book's ID and user's ID
        int bookToIssue = Integer.parseInt(txtBookID.getText());
        int userToIssue = Integer.parseInt(txtUserID.getText());
        //as long as both textFields are populated, it means a book and user have been selected, so an issue attempt can be made
        if(!txtBookID.getText().isEmpty() && !txtUserID.getText().isEmpty()){
            //if the book can in fact be issued, it will be issued, and a message will be populated at the bottom of the window displaying the due date
            if(l.issueBook(userToIssue, bookToIssue)){
                //goes through the transactions to match the currently issued book's transaction(need the transaction to find the due date)
                for(Transaction t: l.transactions.getTransactions()){
                    //if the transaction matches the issued book transaction, set the text at the bottom of the window
                    if(t.isStatus()&&t.getBookID()==bookToIssue&&t.getUserID()==userToIssue){
                        //set a color for the text & set it to visible
                        txtMsg.setStyle("-fx-text-fill:#68ff3a");
                        txtMsg.setVisible(true);
                        //sets the text at the bottom of the window to a successful issue message containing the book name, user name, and due date
                        txtMsg.setText(l.getBook(bookToIssue).getName()+" has been issued to "+ l.getUser(userToIssue).getName()+".\n"
                                +"The due date is "+l.getDueDate(t.getIssueDate()));
                        break;
                    }
                }
            }
            //if the book cannot be issued
            else{
                txtMsg.setStyle("-fx-text-fill:#ff0000");
                //if the book is not available, sends an unavailable message
                if(!l.isAvailable(bookToIssue)){
                    txtMsg.setVisible(true);
                    txtMsg.setText("Book currently unavailable");
                }
                //if the user has a current balance, sends a 'user has a balance' message
                else if(l.getUser(userToIssue).getBalance() > 0){
                    txtMsg.setVisible(true);
                    txtMsg.setText("User has an outstanding balance of $"+l.getUser(userToIssue).getBalance());
                }
                //otherwise, the only other reason that a book could not be issued is if their borrow count was too high, so sets that message
                else{
                    txtMsg.setVisible(true);
                    txtMsg.setText("User has reached the maximum limit of borrowed books!");
                }
            }
        }
    }
    //initData method to pass the library object from the mainMenuController
    public void initData(Library lib) throws SQLException {
        //sets the library to the library that was passed
        this.l = lib;
        //populate lstUsers with an observableList of library's users
        ObservableList<User> obsUserList = FXCollections.observableArrayList(l.users.getUsers());
        lstUsers.setItems(obsUserList);
        //populate lstBooks with an observableList of library's books
        ObservableList<Book> obsBookList = FXCollections.observableArrayList(l.books.getBooks());
        lstBooks.setItems(obsBookList);
        //sets a listener on the txtBookSearch field to detect changes in the inner text
        txtBookSearch.textProperty().addListener((observableValue, oldValue, newValue) -> {
            //dynamically searches through the library's books to match the passed text from the textField
            try {
                lstBooks.getItems().setAll(l.searchBook(newValue));
            } catch (SQLException throwables) {
                throwables.printStackTrace();
            }
        });
        //sets a listener on the txtUserSearch field to detect changes in the inner text
        txtUserSearch.textProperty().addListener((observableValue, oldValue, newValue) -> {
            //dynamically searches through the library's users to match the passed text from the textField
            try {
                lstUsers.getItems().setAll(l.searchUser(newValue));
            } catch (SQLException throwables) {
                throwables.printStackTrace();
            }
        });
        //sets a listener on the lstUsers listView to detect changes in the selected item
        lstUsers.getSelectionModel().selectedItemProperty().addListener((observableValue, oldValue, newValue) -> {
            //sets txtUserID's text to contain the ID of the currently selected user
            if(newValue!=null){
                txtUserID.setText("" + newValue.getID());
            }
        });
        //sets a listener on the lstBooks listView to detect changes in the selected item
        lstBooks.getSelectionModel().selectedItemProperty().addListener((observableValue, oldValue, newValue) -> {
            //sets txtBookID's text to contain the ID of the currently selected book
            if(newValue!=null) {
                txtBookID.setText("" + newValue.getID());
            }
        });
    }

}
