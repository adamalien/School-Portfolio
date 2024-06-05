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
import javafx.scene.control.Button;
import javafx.scene.control.ComboBox;
import javafx.scene.control.Label;
import javafx.scene.control.ListView;

import java.sql.SQLException;
import java.util.ArrayList;
//controller for viewing user details
public class UserDetailsController {
    Library l;

    @FXML
    private ComboBox<User> cmbUsers;

    @FXML
    private Button btnCollect;

    @FXML
    private Label lblAddress;

    @FXML
    private Label lblBalance;

    @FXML
    private Label lblBirthday;

    @FXML
    private Label lblEmail;

    @FXML
    private Label lblName;

    @FXML
    private Label lblStudent;

    @FXML
    private ListView<Book> lstBooks;
    //onAction to collect a fine from a user if the user has a balance
    @FXML
    void collectFine(ActionEvent event) {
        //collects the fine from the currently selected user
        l.collectFine(cmbUsers.getSelectionModel().getSelectedItem());
        //sets the label text as green
        lblBalance.setStyle("-fx-text-fill:#68ff3a");
        //sets the text to contain the new balance (will be 0)
        lblBalance.setText("$"+cmbUsers.getSelectionModel().getSelectedItem().getBalance());
    }
    //method to pass in the library object as well as populate the combobox, and sets a listener for the combobox
    public void initData(Library lib) throws SQLException {
        //sets the library object to the passed object
        this.l = lib;
        //creates an observable list of the library's users
        ObservableList<User> obsUserList = FXCollections.observableArrayList(l.users.getUsers());
        //sets the cmbUsers combobox to contain the list of users
        cmbUsers.setItems(obsUserList);
        //listener that detects when a new value is chosen from the combobox
        cmbUsers.getSelectionModel().selectedItemProperty().addListener((observableValue, oldValue, newValue) -> {
            //since labels are initially invisible, sets them all to visible
            lblBalance.setVisible(true);
            lblAddress.setVisible(true);
            lblBirthday.setVisible(true);
            lblEmail.setVisible(true);
            lblName.setVisible(true);
            lblStudent.setVisible(true);
            //sets the appropriate fields from the currently selected user object
            lblBalance.setText("$"+ newValue.getBalance());
            lblAddress.setText(newValue.getAddress());
            lblBirthday.setText(newValue.getDateOfBirth().toString());
            lblEmail.setText(newValue.getEmail());
            lblName.setText(newValue.getName());
            //checks if the user is student or faculty
            if(newValue.getStudent()){
                lblStudent.setText("Student");
            }
            else{
                lblStudent.setText("Faculty");
            }
            //checks if the user has a balance, if they do, btnCollect becomes visible so that their fine can be collected
            if(newValue.getBalance()>0){
                btnCollect.setVisible(true);
                lblBalance.setStyle("-fx-text-fill:red");
            }
            //initialize an array of books for the specified user
            ArrayList<Book> books = new ArrayList<>();
            //populate the books that the user currently has checked out by looking through the transactions
            try {
                for(Transaction t: l.transactions.getTransactions()){
                    //if the userID from the transaction and the userID from the cmbUsers matches AND the status is true(meaning it is checked out), then the book is added to the arrayList
                    if(t.getUserID() == newValue.getID() && t.isStatus()){
                        try {
                            books.add(l.getBook(t.getBookID()));
                        } catch (SQLException throwables) {
                            throwables.printStackTrace();
                        }
                    }
                }
            } catch (SQLException throwables) {
                throwables.printStackTrace();
            }
            //populates the observable list with our arrayList
            ObservableList<Book> obsBookList = FXCollections.observableArrayList(books);
            //sets the listView to contain the user's issued books
            lstBooks.setItems(obsBookList);
        });
    }

}
