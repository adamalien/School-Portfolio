package Controllers;
//imports
import Models.Book;
import Models.Library;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.scene.control.Label;
import javafx.scene.control.ListView;
import javafx.scene.control.TextField;

import java.sql.SQLException;

//class for the returnBook controller
public class ReturnBookController {
    Library l;
    String bookName;
    int bookID;

    @FXML
    private ListView<Book> lstBooks;

    @FXML
    private TextField txtBookID;

    @FXML
    private TextField txtSearch;

    @FXML
    private Label lblMsg;
    //onAction for clicking on the return button, this will return the selected book
    @FXML
    void returnBook(ActionEvent event) throws SQLException {
        //get the bookName and bookID from currently selected item on the listView
        bookName = lstBooks.getFocusModel().getFocusedItem().getName();
        bookID = lstBooks.getFocusModel().getFocusedItem().getID();
        //if the book isn't available(meaning it is currently issued), allows the book to be returned
        if(!l.isAvailable(bookID)){
            l.returnBook(bookID);
            //sets the lblMsg to visible, sets the color, and sets the successful return message
            lblMsg.setVisible(true);
            lblMsg.setStyle("-fx-text-fill:#68ff3a");
            if(l.msgLog.size() == 2){
                lblMsg.setText(l.msgLog.get(0) +"\n"+l.msgLog.get(1));
            }
            else{
                lblMsg.setText("You returned "+l.getBook(bookID).getName());
            }
        }
        //if the book IS available(meaning it is NOT checked out), then lblMsg is set to visible, sets the color, and sets the 'not borrowed' message
        else{
            lblMsg.setVisible(true);
            lblMsg.setStyle("-fx-text-fill:red");
            lblMsg.setText("Book not currently borrowed");
        }
    }
    //initData method to get the library object passed by the mainMenuController and initialize some data/listeners
    public void initData(Library lib) throws SQLException {
        //sets library to passed library
        this.l = lib;
        //sets an observableList of the library's books
        ObservableList<Book> obsBookList = FXCollections.observableArrayList(l.books.getBooks());
        //sets the library's books to the listView
        lstBooks.setItems(obsBookList);
        //listens for changes on the listView
        lstBooks.getSelectionModel().selectedItemProperty().addListener((observableValue, oldValue, newValue) -> {
            //sets the value of the 'txtBookID' field to the currently selected book's ID
            if(newValue!=null){
                txtBookID.setText(""+newValue.getID());
            }
        });
        //listens for changes in the 'txtSearch' bar
        txtSearch.textProperty().addListener((observableValue, oldValue, newValue) -> {
            //sets the lstBooks view to contain only books that contain the letters/word that is being searched
            try {
                lstBooks.getItems().setAll(l.searchBook(newValue));
            } catch (SQLException throwables) {
                throwables.printStackTrace();
            }
        });
    }

}
