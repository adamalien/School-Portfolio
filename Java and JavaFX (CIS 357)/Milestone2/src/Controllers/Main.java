//Author: Adam Cossin
//CIS 357 Milestone 2
//Date:4/13/22
//Description: Incorporate our models into a gui application for a library
package Controllers;
//imports
import Models.Library;
import javafx.application.Application;
import javafx.fxml.FXMLLoader;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.stage.Stage;

import java.sql.SQLException;

//main
public class Main extends Application {
    //create a new library
    Library l = new Library();

    public Main() throws SQLException {
    }

    @Override
    public void start(Stage primaryStage) throws Exception{
        //when main is run, it will first launch the main menu fxml
        FXMLLoader loader = new FXMLLoader(getClass().getResource("/views/mainmenu.fxml"));
        Parent root = loader.load();
        //gets a handle on the controller for the main menu
        MainMenuController controller = loader.getController();
        //passes the library object to the main menu controller
        controller.initData(l);
        //sets title, the scene for the stage, and the size of the scene
        primaryStage.setTitle("Main Menu");
        primaryStage.setScene(new Scene(root, 600, 500));
        //shows the stage
        primaryStage.show();
    }

    public static void main(String[] args) {
        launch(args);
    }
}
