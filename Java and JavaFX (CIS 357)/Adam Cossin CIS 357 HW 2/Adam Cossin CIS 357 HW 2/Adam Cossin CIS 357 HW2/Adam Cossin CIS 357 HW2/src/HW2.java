//Author: Adam Cossin
//CIS 357 HW 2
//Date: Feb, 27 2022
//Description: A program that creates a GUI which allows a user to make a customizable pizza, and allows them to save it
import javafx.application.Application;
import javafx.embed.swing.SwingFXUtils;
import javafx.event.ActionEvent;
import javafx.event.EventHandler;
import javafx.geometry.Orientation;
import javafx.geometry.Pos;
import javafx.scene.Node;
import javafx.scene.Scene;
import javafx.scene.control.*;
import javafx.scene.image.Image;
import javafx.scene.image.ImageView;
import javafx.scene.image.WritableImage;
import javafx.scene.layout.*;
import javafx.stage.FileChooser;
import javafx.stage.Stage;

import javax.imageio.ImageIO;
import java.awt.image.RenderedImage;
import java.io.File;
import java.io.IOException;
import java.util.ArrayList;

public class HW2 extends Application {
    //instance variables
    Scene scene;
    HBox layout;
    VBox root;
    HBox buttons;
    GridPane grid;
    Button btnSubmit;
    Button btnReset;
    Label lblBuild;
    Label lblMessage;
    StackPane stack;

    ImageView ivSize;
    ImageView ivCrust;
    ImageView ivSauce;
    ImageView ivCheese;
    ImageView ivExtraCheese;
    ArrayList<ImageView> views;
    ArrayList<Image> tops;
    CheckBox cb;
    ImageView ivToppings;
    ImageView ivSeasoning;
    ImageView thisView;

    Label lblSize;
    RadioButton rdoS;
    RadioButton rdoM;
    RadioButton rdoL;
    ToggleGroup tglSize;

    Label lblCrust;
    RadioButton rdoC;
    RadioButton rdoN;
    ToggleGroup tglCrust;

    Label lblSauce;
    ToggleButton tbMarinara;
    ToggleButton tbBarbeque;
    ToggleButton tbAlfredo;
    ToggleButton tbChipotle;
    ToggleGroup tglSauce;

    Label lblCheese;
    ComboBox<String> cmbCheese;

    Label lblTop;
    GridPane temp;

    CheckBox chkSeasoning;

    Image crust;
    Image sauce;
    Image cheese;
    Image extraCheese;
    Image toppings;
    Image seasoning;

    int size;
    Separator sep;

    String IMG_DIR = ("file:src/assets/images/");

    public static void main(String[] args){
        launch(args);
    }
    @Override
    public void start(Stage stage) {
        //initialization of variables
        grid = new GridPane();
        root = new VBox();
        buttons = new HBox();
        stack = new StackPane();
        layout = new HBox(grid,stack);
        btnSubmit = new Button("Submit Order");
        btnReset = new Button("Reset Order");
        lblBuild = new Label("Build your own Pizza!");
        ivSize = new ImageView();
        ivCrust = new ImageView();
        ivSauce = new ImageView();
        ivCheese = new ImageView();
        ivSeasoning = new ImageView();
        //create an ID for lblBuild to manipulate in css
        lblBuild.setId("build");
        //set spacing and alignment for HBox
        layout.setSpacing(200);
        layout.setAlignment(Pos.CENTER);

        //add individual buttons to an HBox and set the alignment
        buttons.getChildren().addAll(btnSubmit,btnReset);
        buttons.setAlignment(Pos.BASELINE_CENTER);

        //align the entire contents of the VBox to the center
        root.setAlignment(Pos.CENTER);
        //add necessary elements to the VBox
        root.getChildren().addAll(lblBuild,layout,buttons);

        //set the title
        stage.setTitle("Procedural Object Oriented Programming (P00P) Pizza Store");

        //create a new scene and link the stylesheet
        scene = new Scene(root,1200,800);
        scene.getStylesheets().add("assets/css/styles.css");
        //set the scene on the stage
        stage.setScene(scene);
        //show the stage
        stage.show();

        //action for when btnSubmit is clicked -- the user is able to save an image of their pizza to their machine
        btnSubmit.setOnAction(e -> {
            lblMessage = new Label("Order Ready! Your pizza has been delivered to "+captureAndSaveDisplay(stack));
            //label is added showing where the image was saved
            root.getChildren().add(lblMessage);
        });
        //set ID for manipulation in css
        btnReset.setId("btnReset");

        //set gap between elements on the grid portion(controls) of the scene
        grid.setVgap(10);

        //initialize a new pizza object to load it and the controls to the scene
        Pizza pizza = new Pizza();

        //action for when btnReset is clicked -- the pizza is reset to the default pizza
        btnReset.setOnAction(e ->{
            //medium pizza size
            size = 400;
            //remove everything that is currently on the pizza stack
            stack.getChildren().remove(ivCrust);
            stack.getChildren().remove(ivSauce);
            stack.getChildren().remove(ivCheese);
            stack.getChildren().remove(ivSeasoning);
            stack.getChildren().removeAll(views);

            //reload everything to the pizza stack to the default values
            crust = new Image(IMG_DIR+"crust_chicago.png");
            ivCrust.setImage(crust);
            ivCrust.setFitWidth(size);
            stack.getChildren().add(ivCrust);
            sauce = new Image(IMG_DIR+"sauce_marinara.png");
            ivSauce.setImage(sauce);
            ivSauce.setFitWidth(size);
            stack.getChildren().add(ivSauce);
            ivCheese.setImage(cheese);
            ivCheese.setFitWidth(size);
            stack.getChildren().add(ivCheese);
            ivSeasoning.setImage(seasoning);
            ivSeasoning.setFitWidth(size);
            //for loop to loop through the 'views' arrayList which contains a list of imageviews for the toppings
            for(int i = 0; i<views.size();i++){
                String tempst =views.get(i).getImage().getUrl();
                CheckBox p = (CheckBox) temp.getChildren().get(i);
                //if the current views object's label is one of these, then they are added to the stack and their respective
                //checkboxes are checked
                if(tempst.contains("Mushroom")||tempst.contains("Pepper")||tempst.contains("Pepperoni")){
                    stack.getChildren().add(views.get(i));
                    p.setSelected(true);
                }
                //else the checkboxes are not checked
                else{
                    p.setSelected(false);
                }
            }
            //select the default values in the controls
            tglSize.selectToggle(rdoM);
            tglCrust.selectToggle(rdoC);
            tglSauce.selectToggle(tbMarinara);
            cmbCheese.getSelectionModel().select(1);
            //check if seasoning is checked or not in order to determine if the checkbox needs to be checked upon reset
            if(chkSeasoning.isSelected()){
                stack.getChildren().remove(ivSeasoning);
                stack.getChildren().add(ivSeasoning);
            }
            else{
                stack.getChildren().remove(ivSeasoning);
                chkSeasoning.setSelected(true);
            }

        });
    }

    //provided capture method
    public String captureAndSaveDisplay(StackPane pizzaLayers){
        // Adapted from: https://stackoverflow.com/questions/38028825/javafx-save-view-of-pane-to-image/38028893
        FileChooser fileChooser = new FileChooser();
        //Set extension filter
        fileChooser.getExtensionFilters().add(new
                FileChooser.ExtensionFilter("png files (*.png)", "*.png"));
        //Prompt user to select a file
        File file = fileChooser.showSaveDialog(null);
        if(file != null){
            try {
                //Set the capture area
                WritableImage writableImage = new
                        WritableImage((int)pizzaLayers.getWidth(),(int)pizzaLayers.getHeight());
                pizzaLayers.snapshot(null, writableImage);
                RenderedImage renderedImage =
                        SwingFXUtils.fromFXImage(writableImage, null);
                //Write the snapshot to the chosen file
                ImageIO.write(renderedImage, "png", file);
                return file.getAbsolutePath();
            } catch (IOException ex) { ex.printStackTrace(); }
        }
        return null;
    }

    //Pizza class with no-arg constructor and various utility methods
    class Pizza{
        //pizza's properties
        String strSize;
        String strCrust;
        String strSauce;
        String strCheese;
        Boolean isSeasoned;
        ArrayList<String> arrTop;

        //no-arg constructor for pizza which will set the initial pizza to default requested values
        Pizza() {
            //set default properties
            strSize = "Medium";
            size = 400;
            strCrust = "Chicago Style Deep Dish";
            strSauce = "Marinara";
            strCheese = "Normal";
            isSeasoned = true;
            //add the toppings for the default pizza to an arrayList
            arrTop = new ArrayList<>();
            arrTop.add("mushroom");
            arrTop.add("pepper");
            arrTop.add("pepperoni");
            //set default images for crust, sauce, cheese, and seasoning
            crust = new Image(IMG_DIR + "crust_chicago.png");
            sauce = new Image(IMG_DIR + "sauce_marinara.png");
            cheese = new Image(IMG_DIR + "cheese_normal.png");
            seasoning = new Image(IMG_DIR + "seasoning.png");
            //set default properties for each imageView (ie. making sure the size is consistent and so is the preserve ratio)
            ivCrust.setImage(sauce);
            ivCrust.setFitWidth(size);
            ivCrust.setPreserveRatio(true);
            ivSauce.setImage(sauce);
            ivSauce.setFitWidth(size);
            ivSauce.setPreserveRatio(true);
            ivCheese.setImage(cheese);
            ivCheese.setFitWidth(size);
            ivCheese.setPreserveRatio(true);
            ivSeasoning.setImage(seasoning);
            ivSeasoning.setFitWidth(size);
            ivSeasoning.setPreserveRatio(true);
            //add each imageView to the stack to create the default pizza
            stack.getChildren().add(ivCrust);
            stack.getChildren().add(ivSauce);
            stack.getChildren().add(ivCheese);
            stack.getChildren().add(ivSeasoning);

            //call each utility method in order to add controls to the scene and allow manipulation of each control
            //by the user (so that the stack properly updates upon any changes)
            configureSauce();
            configureCrust();
            configureCheese();
            configureSize();
            configureToppings();
            configureSeasoning();
            //loads the images in correct order
            loadImages();
        }

        //utility method which loads the controls for the sauce onto the scene & also listens for toggle changes within
        //the group of sauces & changes the imageView for sauce dynamically
        public void configureSauce(){
            //new separator to be loaded
            sep = new Separator(Orientation.HORIZONTAL);
            //label and toggle buttons for sauces
            lblSauce = new Label("Choose your Sauce");
            tbMarinara = new ToggleButton("Marinara");
            tbBarbeque = new ToggleButton("Barbeque");
            tbAlfredo = new ToggleButton("Alfredo");
            tbChipotle = new ToggleButton("Chipotle");
            //toggle group for sauce
            tglSauce = new ToggleGroup();

            //HBox to add in the toggle buttons
            HBox temp = new HBox();
            temp.getChildren().addAll(tbMarinara, tbBarbeque, tbAlfredo, tbChipotle);

            //add each element to the grid in the proper place
            grid.add(lblSauce, 1,6);
            grid.add(temp, 1,7);
            grid.add(sep,1,8);

            //adds each togglebutton to the toggle group
            for(Node n : temp.getChildren()){
                ToggleButton r = (ToggleButton) n;
                r.setToggleGroup(tglSauce);
            }
            //selects the default value as marinara and creates the sauce image with that path
            tglSauce.selectToggle(tbMarinara);
            sauce = new Image(IMG_DIR + "sauce_marinara.png");

            //listener for toggle changes in toggle sauce group, the sauce image is updated based on user selection
            tglSauce.selectedToggleProperty().addListener((observableValue, oldValue, newValue) -> {
                ToggleButton s = (ToggleButton) newValue;
                //if condition for if no sauces are selected
                if(!tbMarinara.isSelected()&&!tbAlfredo.isSelected()&&!tbBarbeque.isSelected()&&!tbChipotle.isSelected()){
                    stack.getChildren().remove(ivSauce);
                }
                //otherwise, the sauce is removed to prevent any duplicates, then the sauce image is created to point to the proper path
                //and the imageView is updated to contain this new image, and then the imageView is added onto the stack
                else{
                    stack.getChildren().remove(ivSauce);
                    sauce = new Image(IMG_DIR + "sauce_"+s.getText().toLowerCase()+".png");
                    ivSauce.setImage(sauce);
                    stack.getChildren().add(ivSauce);
                    //loadImages is called to make sure that the images are loaded in consistent order
                    loadImages();
                }
            });
        }

        //utility method which loads the controls for the crust onto the scene & also listens for changes within
        //the group of crusts & changes the imageView for crust dynamically
        public void configureCrust(){
            //separator, lbl, rdo buttons, and tglGroup initialized
            sep = new Separator(Orientation.HORIZONTAL);
            lblCrust = new Label("Choose your Crust");
            rdoC = new RadioButton("Chicago Style Deep Dish");
            rdoN = new RadioButton("New York Thin Crust");
            tglCrust = new ToggleGroup();

            //HBox created to store rdo buttons
            HBox temp = new HBox();
            temp.getChildren().addAll(rdoC,rdoN);
            temp.setSpacing(10);
            //default value of chicago style crust is selected
            rdoC.setSelected(true);

            //add each element to the grid
            grid.add(lblCrust, 1,3);
            grid.add(temp, 1,4);
            grid.add(sep,1,5);

            //adds all radio buttons to the same toggle group
            for(Node n : temp.getChildren()){
                RadioButton r = (RadioButton) n;
                r.setToggleGroup(tglCrust);
            }

            //default crust image is loaded
            crust = new Image(IMG_DIR + "crust_chicago.png");
            ivCrust.setImage(crust);
            //listener for the toggle group of crusts, so that if a change is made, the crust's image is updated
            tglCrust.selectedToggleProperty().addListener((observableValue, oldValue, newValue) -> {
                RadioButton r = (RadioButton) newValue;
                String cChoice = r.getText();
                //if else statements to see which crust is selected and update the crust image accordingly
                if(cChoice.equals("Chicago Style Deep Dish")) {
                    crust = new Image(IMG_DIR + "crust_chicago.png");
                }
                else {
                    crust = new Image(IMG_DIR + "crust_nyc.png");
                }
                //add the crust to the ivCrust imageview
                ivCrust.setImage(crust);
            });
        }

        //utility method which loads the controls for the cheese onto the scene & also listens for changes within
        //the cmbBox of cheeses & changes the imageView for cheese dynamically
        public void configureCheese(){
            //initialize properties
            sep = new Separator(Orientation.HORIZONTAL);
            lblCheese = new Label("Choose Cheese Level");
            cmbCheese = new ComboBox<>();

            //elements added to the grid
            grid.add(lblCheese,1,9);
            grid.add(cmbCheese,1,10);
            grid.add(sep,1,11);

            //new comboBox with appropriate options
            cmbCheese.getItems().addAll("None","Normal","Extra");
            //default of 'normal' will be selected
            cmbCheese.getSelectionModel().select(1);

            //listener to detect changes in cmbCheese selection and change the cheese image dynamically according to
            //what is selected
            cmbCheese.getSelectionModel().selectedItemProperty().addListener((observable, oldValue, newValue)->{
                //remove cheese to prevent any errors from duplicates added
                stack.getChildren().remove(ivCheese);
                //as long as the value selected isn't 'None', the cheese image is updated and added to the imageView
                if(!newValue.equals("None")){
                    if(newValue.equals("Normal")){
                        //remove extraCheese imageView in case it was added before 'normal' was selected
                        stack.getChildren().remove(ivExtraCheese);
                        ivCheese = new ImageView();
                        cheese = new Image(IMG_DIR + "cheese_normal.png");
                        ivCheese.setImage(cheese);
                        ivCheese.setFitWidth(size);
                        ivCheese.setPreserveRatio(true);
                        stack.getChildren().add(ivCheese);
                        //loadImages called to maintain stack order
                        loadImages();
                    }
                    //for 'extraCheese' option, two images have to be loaded to the stack
                    else{
                        ivCheese = new ImageView();
                        ivExtraCheese = new ImageView();
                        extraCheese = new Image(IMG_DIR + "cheese_extra.png");
                        ivExtraCheese.setImage(extraCheese);
                        ivExtraCheese.setFitWidth(size);
                        ivExtraCheese.setPreserveRatio(true);
                        ivCheese.setImage(cheese);
                        ivCheese.setFitWidth(size);
                        ivCheese.setPreserveRatio(true);
                        stack.getChildren().add(ivCheese);
                        stack.getChildren().add(ivExtraCheese);
                        //loadImages called to maintain stack order
                        loadImages();
                    }
                }
                //comes here if the cheese selection is 'None' and removes the imageViews for cheese from the stack
                else{
                    stack.getChildren().remove(ivCheese);
                    stack.getChildren().remove(ivExtraCheese);
                }
            });
        }

        //utility method which loads the controls for the size onto the scene & also listens for toggle changes within
        //the group of sizes & changes the size of the stack dynamically
        public void configureSize(){
            //initialize variables
            sep = new Separator(Orientation.HORIZONTAL);
            lblSize = new Label("Choose your size");
            rdoS = new RadioButton("Small");
            rdoM = new RadioButton("Medium");
            rdoL = new RadioButton("Large");
            tglSize = new ToggleGroup();

            //create a new HBox to store the radio buttons
            HBox temp = new HBox();
            temp.getChildren().addAll(rdoS,rdoM,rdoL);
            temp.setSpacing(10);
            //adds the elements to the grid
            grid.add(lblSize, 1,0);
            grid.add(temp, 1,1);
            grid.add(sep,1,2);
            //adds each radioButton to the same toggle group
            for(Node n: temp.getChildren()){
                RadioButton r = (RadioButton) n;
                r.setToggleGroup(tglSize);
            }
            //select default toggle for 'medium' option
            tglSize.selectToggle(rdoM);
            //listener to detect change in toggle group options -- will change the size of the stack by updating the 'size'
            //variable to its respective value and changing the size of all imageViews
            tglSize.selectedToggleProperty().addListener((observableValue, oldValue, newValue) -> {
                RadioButton selected = (RadioButton) newValue;
                if(selected.getText().equals("Small")){
                    size= 350;
                }
                else if(selected.getText().equals("Medium")){
                    size= 400;
                }
                else{
                    size= 450;
                }
                //changes the size of imageViews to the size that's selected
                ivCrust.setFitWidth(size);
                ivSauce.setFitWidth(size);
                ivCheese.setFitWidth(size);
                //checks if ivExtraCheese is null and if it ISN'T, updates the size
                if(ivExtraCheese!=null){
                    ivExtraCheese.setFitWidth(size);
                }
                //updates the size of all topping imageViews
                for (ImageView view : views) {
                    view.setFitWidth(size);
                    view.setPreserveRatio(true);
                }
                ivSeasoning.setFitWidth(size);
            });
        }

        //utility method which loads the controls for the toppings onto the scene & also listens for changes within
        //the toppings & changes the imageView for toppings dynamically
        public void configureToppings(){
            //initialize variables
            sep = new Separator(Orientation.HORIZONTAL);
            lblTop = new Label("Choose your Toppings");
            temp = new GridPane();

            //add label to the grid
            grid.add(lblTop,1,12);

            //create an array of strings which contains the values of the toppings
            arrTop = new ArrayList<>();
            arrTop.add("Mushroom");
            arrTop.add("Onion");
            arrTop.add("Olive");
            arrTop.add("Pepper");
            arrTop.add("Tomato");
            arrTop.add("Jalapeno");
            arrTop.add("Ham");
            arrTop.add("Chicken");
            arrTop.add("Pepperoni");

            //initialize arrayLists
            tops = new ArrayList<>();
            views = new ArrayList<>();

            //goes through the list of toppings in arrTop and adds a new topping image to the 'tops' arrayList according to the
            //string value from arrTop
            for (String s : arrTop) {
                toppings = new Image(IMG_DIR + "topping_" + s + ".png");
                tops.add(toppings);
            }
            //creates a new checkBox for each value in arrTop
            for(int j = 0; j<arrTop.size(); j++) {
                //gets the ith image from the tops arrayList and stores it in 'thisImage'
                Image thisImage = tops.get(j);
                cb = new CheckBox(arrTop.get(j));
                //initialize a new ImageView
                ivToppings = new ImageView();
                //set Image for ivToppings to be the current image
                ivToppings.setImage(thisImage);
                //update size & set preserve ratio
                ivToppings.setFitWidth(size);
                ivToppings.setPreserveRatio(true);
                //add ivToppings to list of imageViews
                views.add(ivToppings);
                //add checkboxes to temp grid
                temp.add(cb, 1,j);
                thisView = views.get(j);
                String tempst =views.get(j).getImage().getUrl();
                //sets the default values for toppings and sets the corresponding checkboxes to 'checked' initially
                if(tempst.contains("Mushroom")||tempst.contains("Pepper")||tempst.contains("Pepperoni")){
                    stack.getChildren().add(views.get(j));
                    cb.setSelected(true);
                }
                else{
                    cb.setSelected(false);
                }

                //listener for if a checkBox is selected
                EventHandler<ActionEvent> event = e -> {
                    if(cb.isSelected()){
                        //if it is selected, removes the current imageView from the stack to prevent duplicates
                        stack.getChildren().remove(thisView);
                        //adds back the current imageView corresponding to the checkbox
                        stack.getChildren().add(thisView);
                    }
                    else{
                        //removes the imageView
                        stack.getChildren().remove(thisView);
                    }
                    //loadImages is called to maintain order
                    loadImages();
                };
                //sets the action for these checkBoxes
                cb.setOnAction(event);
            }
            //adds elements to the grid
            grid.add(temp,1,13);
            grid.add(sep,1,14);
        }

        //utility method which loads the control for the seasoning onto the scene & also listens for checked/unchecked changes
        //for chkSeasoning & changes the imageView for seasoning dynamically
        public void configureSeasoning(){
            //variable initialization
            sep = new Separator(Orientation.HORIZONTAL);
            chkSeasoning = new CheckBox("Add Seasoning?");
            //adds checkbox and separator to the grid
            grid.add(chkSeasoning,1,15);
            grid.add(sep,1,16);
            //default is that chkSeasoning is selected
            chkSeasoning.setSelected(true);
            //listener for if chkSeasoning is checked/unchecked and changes the imageView for seasoning dynamically
            chkSeasoning.selectedProperty().addListener((observableValue, oldValue, newValue) -> {
                if(newValue.equals(true)){
                    //if it is checked, seasoning path is loaded to the seasoning image
                    seasoning = new Image(IMG_DIR + "seasoning.png");
                    //image is passed to the imageView
                    ivSeasoning.setImage(seasoning);
                    //imageView is loaded onto the stack
                    stack.getChildren().add(ivSeasoning);
                }
                else{
                    //otherwise the imageView is removed
                    stack.getChildren().remove(ivSeasoning);
                }
                ivSeasoning.setImage(seasoning);
            });
        }

        //utility method which maintains the order of layers
        public void loadImages(){
            //first, removes all layers from the stack so that it can re-order them
            stack.getChildren().remove(ivCrust);
            stack.getChildren().remove(ivSauce);
            stack.getChildren().remove(ivCheese);
            stack.getChildren().remove(ivExtraCheese);
            for(int i = 0; i<arrTop.size(); i++){
                stack.getChildren().remove(views.get(i));
            }
            stack.getChildren().remove(ivSeasoning);
            //then, adds back each element according to what is selected in the proper order (ie. crust, sauce, cheese, etc)
            stack.getChildren().add(ivCrust);
            //checks to see if any sauces are selected
            if(!tbMarinara.isSelected()&&!tbAlfredo.isSelected()&&!tbBarbeque.isSelected()&&!tbChipotle.isSelected()){
                //do nothing
            }
            //if a sauce is selected, adds it to the stack
            else {
                stack.getChildren().add(ivSauce);
            }
            //checks what the value of the selected item from cmbCheese is and adds images/imageViews to the stack accordingly
            if(cmbCheese.getSelectionModel().getSelectedItem().equals("Extra")){
                stack.getChildren().add(ivCheese);
                stack.getChildren().add(ivExtraCheese);
                ivExtraCheese.setFitWidth(size);
            }
            else if(cmbCheese.getSelectionModel().getSelectedItem().equals("Normal")){
                stack.getChildren().add(ivCheese);
            }
            //loops through the toppings, checks if the topping's chkBox is selected
            for(int i = 0; i<arrTop.size(); i++){
                CheckBox ck = (CheckBox) temp.getChildren().get(i);
                //if the topping is checked, adds the corresponding imageView to the stack
                if(ck.isSelected()){
                    stack.getChildren().add(views.get(i));
                }
                //otherwise, removes the imageView from the stack
                else{
                    stack.getChildren().remove(views.get(i));
                }
            }
            //check to see if chkSeasoning is selected, and if it is, adds the imageView to the stack
            if(chkSeasoning.isSelected()) {
                stack.getChildren().add(ivSeasoning);
            }
        }

    }

}