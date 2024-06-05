package Controllers;
//imports
import Models.Book;
import Models.Library;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.scene.control.*;
import javafx.scene.layout.AnchorPane;
import javafx.stage.Stage;

import java.sql.SQLException;

//class for newBook controller
public class NewBookController {
    Library l;
    Stage stage;
    String msg;
    //gets the library object from the mainMenuController and sets it to the current library
    public void initData(Library lib) {
        this.l = lib;
    }

    @FXML
    private ComboBox<String> cmbGenre;

    @FXML
    private ListView<String> lstPublisher;

    @FXML
    private TextField txtAuthor;

    @FXML
    private TextField txtISBN;

    @FXML
    private TextField txtName;

    @FXML
    private TextField txtYear;

    @FXML
    private AnchorPane window;
    //onAction for the registerBook button, this will add a new book to the library
    @FXML
    void registerBook(ActionEvent event) {
        //checks to make sure that all fields contain a value, meaning that the book CAN be added
        if(!txtName.getText().isEmpty() && !txtAuthor.getText().isEmpty() && !txtISBN.getText().isEmpty() && !txtYear.getText().isEmpty() &&
                !cmbGenre.getSelectionModel().isEmpty() && !lstPublisher.getSelectionModel().isEmpty()){
            int x = 0;
            long y = 0;
            //try catch to make sure that the user is entering numbers in for 'year' and 'ISBN' fields
            try{
                x = Integer.parseInt(txtYear.getText());
                y = Long.parseLong(txtISBN.getText());
                //creates a new book based on fields from the form
                Book b = new Book(txtName.getText(), txtAuthor.getText(), lstPublisher.getSelectionModel().getSelectedItem(),
                        cmbGenre.getSelectionModel().getSelectedItem(), txtISBN.getText(), Long.parseLong(txtYear.getText()));
                //adds the book to the library
                l.addBook(b);
                //msg to be passed to the alert
                msg = "Registered "+b.getName();
                //get the stage of the current window
                stage = (Stage) window.getScene().getWindow();
                //create a new alert
                Alert a = new Alert(Alert.AlertType.INFORMATION);
                //set the success text inside the alert
                a.setTitle("Registration Successful");
                a.setContentText(msg);
                a.setHeaderText("Success!");
                //sets the owner of the alert to the current window
                a.initOwner(stage);
                //closes the current window
                stage.close();
                //keeps the alert open until closed
                a.showAndWait();
            }catch (NumberFormatException | SQLException e){
                //create a new alert for the error message
                Alert a = new Alert(Alert.AlertType.ERROR);
                //set the title and the inside texts
                a.setTitle("Registration Unsuccessful");
                a.setHeaderText("Invalid book entry!");
                //sets the owner of the alertBox to the current window
                a.initOwner(stage);
                //keeps the alert open until closed
                a.showAndWait();
            }
        }
        else{
            //create a new alert for the error message
            Alert a = new Alert(Alert.AlertType.ERROR);
            //set the title and the inside texts
            a.setTitle("Registration Unsuccessful");
            a.setContentText(msg);
            a.setHeaderText("Invalid book entry!");
            //sets the owner of the alertBox to the current window
            a.initOwner(stage);
            //keeps the alert open until closed
            a.showAndWait();
        }

    }
    //initializes data for the publisher listView and the genre comboBox
    public void initialize(){
        ObservableList<String> publishers = FXCollections.observableArrayList("Hachette","Harper Collins","Macmillan","Penguin Random House", "Simon & Schuster");
        lstPublisher.setItems(publishers);

        ObservableList<String> genres = FXCollections.observableArrayList("Fiction", "Non-Fiction", "Mystery", "Fantasy", "Sci-Fi");
        cmbGenre.setItems(genres);
    }

}
