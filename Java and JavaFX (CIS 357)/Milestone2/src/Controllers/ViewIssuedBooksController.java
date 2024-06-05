package Controllers;
//imports
import Models.Library;
import Models.Transaction;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.fxml.FXML;
import javafx.scene.control.TableColumn;
import javafx.scene.control.TableView;
import javafx.scene.control.cell.PropertyValueFactory;

import java.sql.SQLException;
import java.time.LocalDate;
import java.util.ArrayList;
//class for the viewIssuedBooks controller
public class ViewIssuedBooksController {
    Library l;

    @FXML
    private TableColumn<Transaction, Integer> colBookID;

    @FXML
    private TableColumn<Transaction, LocalDate> colDate;

    @FXML
    private TableColumn<Transaction, Integer> colUserID;

    @FXML
    private TableView<Transaction> tblIssued;
    //obtains the library object that was passed form the mainMenuController and populates the data to the listView
    public void initData(Library lib) throws SQLException {
        //sets this library as the library that was passed
        this.l = lib;
        //create an arrayList of validTransactions to see which books are currently issued
        ArrayList<Transaction> validTransactions = new ArrayList<>();
        //populates the arrayList
        for(Transaction t: l.transactions.getTransactions()){
            if(t.isStatus()){
                //adds a transaction to the list if the status is true, meaning it is issued
                validTransactions.add(t);
            }
        }
        //passes the arrayList into the observable list
        ObservableList<Transaction> obsTransList = FXCollections.observableArrayList(validTransactions);
        //set the items to the table
        tblIssued.setItems(obsTransList);
        //set the appropriate fields to their columns
        colBookID.setCellValueFactory(new PropertyValueFactory<>("bookID"));
        colUserID.setCellValueFactory(new PropertyValueFactory<>("userID"));
        colDate.setCellValueFactory(new PropertyValueFactory<>("issueDate"));
    }

}
