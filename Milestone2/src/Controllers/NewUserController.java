package Controllers;
//imports
import Models.Library;
import Models.User;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.scene.control.*;
import javafx.scene.layout.AnchorPane;
import javafx.stage.Stage;

import java.sql.SQLException;

//class for the newUser controller
public class NewUserController {
    Library l;
    Stage stage;
    String msg;
    //method to accept in the library object passed by the mainMenuController and set it to the current library
    public void initData(Library lib) {
        this.l = lib;
    }
    @FXML
    private DatePicker dateDOB;

    @FXML
    private RadioButton rdoFaculty;

    @FXML
    private RadioButton rdoStudent;

    @FXML
    private TextArea txtAddress;

    @FXML
    private TextField txtEmail;

    @FXML
    private TextField txtName;

    @FXML
    private AnchorPane window;
    //onAction for the register user button which will add a new user to the library given the appropriate fields
    @FXML
    void registerUser(ActionEvent event) throws SQLException {
        //checks that the fields on the form are properly filled out so that a user can be created
        if(!txtName.getText().isEmpty() && !txtAddress.getText().isEmpty() && !txtEmail.getText().isEmpty() && dateDOB.getValue()!=null) {
            //creates a new user given the fields entered from the window
            User u = new User(txtName.getText(),txtEmail.getText(),txtAddress.getText(),dateDOB.getValue(),rdoStudent.isSelected());
            //adds the user to the library
            l.addUser(u);
            //create a msg to be used in the alert
            msg = "Registered "+u.getName();
            //get a handle on the current stage
            stage = (Stage) window.getScene().getWindow();
            //create a new alert
            Alert a = new Alert(Alert.AlertType.INFORMATION);
            //sets the success text for the alert
            a.setTitle("Registration Successful");
            a.setContentText(msg);
            a.setHeaderText("Success!");
            //initializes the owner of the alert to the current stage
            a.initOwner(stage);
            //closes the current stage
            stage.close();
            //shows the alert and waits until it is closed
            a.showAndWait();
        }
        else{
            //create a new alert for the error message
            Alert a = new Alert(Alert.AlertType.ERROR);
            //set the title and the inside texts
            a.setTitle("Registration Unsuccessful");
            a.setContentText(msg);
            a.setHeaderText("Invalid user entry!");
            //sets the owner of the alertBox to the current window
            a.initOwner(stage);
            //keeps the alert open until closed
            a.showAndWait();
        }

    }
    //initialize method to set the toggleGroup for the radioButtons
    public void initialize(){
        ToggleGroup t = new ToggleGroup();
        rdoStudent.setToggleGroup(t);
        rdoFaculty.setToggleGroup(t);
    }

}
