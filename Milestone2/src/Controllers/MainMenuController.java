package Controllers;
//imports
import Models.Library;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.scene.Node;
import javafx.scene.Scene;
import javafx.stage.Modality;
import javafx.stage.Stage;

import java.io.IOException;
import java.sql.SQLException;

//class for the main menu's controller
public class MainMenuController {
    Library l;
    public void initData(Library lib){
        //gets the library object from main
        this.l = lib;
    }
    //clicking on the addBook button will launch the 'newbook.fxml' in a new window
    @FXML
    void addBook(ActionEvent event) throws IOException {
        //create a stage
        Stage primaryStage = new Stage();
        //loads the fxml for newbook
        FXMLLoader loader = new FXMLLoader(getClass().getResource("/views/newbook.fxml"));
        //loads the fxml to the scene
        Scene scene = new Scene(loader.load());
        //gets a handle on the controller for the new window that will open
        NewBookController controller = loader.getController();
        //sends the library object to the controller
        controller.initData(l);
        //sets the title for the stage
        primaryStage.setTitle("Add New Book");
        //sets the scene for the stage
        primaryStage.setScene(scene);
        //gets a handle on the currrent stage
        Stage thisStage = (Stage) ((Node) event.getSource()).getScene().getWindow();
        //sets the owner of the 'primaryStage' to the current stage
        primaryStage.initOwner(thisStage);
        //sets the modality so that the stage for the newbook window is the only window allowed to be accessed
        primaryStage.initModality(Modality.WINDOW_MODAL);
        //shows the stage until it is closed
        primaryStage.showAndWait();
    }
    //clicking on the addUser button will launch the 'newuser.fxml' in a new window
    @FXML
    void addUser(ActionEvent event) throws IOException {
        //exact same logic as addBook, but for addUser
        Stage primaryStage = new Stage();
        FXMLLoader loader = new FXMLLoader(getClass().getResource("/views/newuser.fxml"));
        Scene scene = new Scene(loader.load());

        NewUserController controller = loader.getController();
        controller.initData(l);
        primaryStage.setTitle("Add New User");

        primaryStage.setScene(scene);
        Stage thisStage = (Stage) ((Node) event.getSource()).getScene().getWindow();

        primaryStage.initOwner(thisStage);
        primaryStage.initModality(Modality.WINDOW_MODAL);
        primaryStage.showAndWait();
    }
    //clicking on the issueBook button will launch the 'issuebook.fxml' in a new window
    @FXML
    void issueBook(ActionEvent event) throws IOException, SQLException {
        //exact same logic as addBook, but for issueBook
        Stage primaryStage = new Stage();
        FXMLLoader loader = new FXMLLoader(getClass().getResource("/views/issuebook.fxml"));
        Scene scene = new Scene(loader.load());

        IssueBookController controller = loader.getController();
        controller.initData(l);
        primaryStage.setTitle("Issue Book to User");

        primaryStage.setScene(scene);
        Stage thisStage = (Stage) ((Node) event.getSource()).getScene().getWindow();

        primaryStage.initOwner(thisStage);
        primaryStage.initModality(Modality.WINDOW_MODAL);
        primaryStage.showAndWait();
    }
    //clicking on the returnBook button will launch the 'returnbook.fxml' in a new window
    @FXML
    void returnBook(ActionEvent event) throws IOException, SQLException {
        //exact same logic as addBook, but for returnBook
        Stage primaryStage = new Stage();
        FXMLLoader loader = new FXMLLoader(getClass().getResource("/views/returnbook.fxml"));
        Scene scene = new Scene(loader.load());

        ReturnBookController controller = loader.getController();
        controller.initData(l);
        primaryStage.setTitle("Return Book");

        primaryStage.setScene(scene);
        Stage thisStage = (Stage) ((Node) event.getSource()).getScene().getWindow();

        primaryStage.initOwner(thisStage);
        primaryStage.initModality(Modality.WINDOW_MODAL);
        primaryStage.showAndWait();
    }
    //clicking on the viewIssuedBooks button will launch the 'viewissuedbooks.fxml' in a new window
    @FXML
    void viewIssuedBooks(ActionEvent event) throws IOException, SQLException {
        //exact same logic as addBook, but for viewIssuedBooks
        Stage primaryStage = new Stage();
        FXMLLoader loader = new FXMLLoader(getClass().getResource("/views/viewissuedbooks.fxml"));
        Scene scene = new Scene(loader.load());

        ViewIssuedBooksController controller = loader.getController();
        controller.initData(l);
        primaryStage.setTitle("View Issued Books");

        primaryStage.setScene(scene);
        Stage thisStage = (Stage) ((Node) event.getSource()).getScene().getWindow();

        primaryStage.initOwner(thisStage);
        primaryStage.initModality(Modality.WINDOW_MODAL);
        primaryStage.showAndWait();
    }
    //clicking on the viewUser button will launch the 'userdetails.fxml' in a new window
    @FXML
    void viewUser(ActionEvent event) throws IOException, SQLException {
        //exact same logic as addBook, but for viewUser
        Stage primaryStage = new Stage();
        FXMLLoader loader = new FXMLLoader(getClass().getResource("/views/userdetails.fxml"));
        Scene scene = new Scene(loader.load());

        UserDetailsController controller = loader.getController();
        controller.initData(l);
        primaryStage.setTitle("User Details");

        primaryStage.setScene(scene);
        Stage thisStage = (Stage) ((Node) event.getSource()).getScene().getWindow();

        primaryStage.initOwner(thisStage);
        primaryStage.initModality(Modality.WINDOW_MODAL);
        primaryStage.showAndWait();
    }

}
