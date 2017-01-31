/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package project3;

import java.io.File;
import java.net.URL;
import java.util.ArrayList;
import java.util.Iterator;
import java.util.LinkedList;
import java.util.List;
import java.util.ResourceBundle;
import java.util.Scanner;
import javafx.animation.PathTransition;
import javafx.event.ActionEvent;
import javafx.event.EventHandler;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.fxml.Initializable;
import javafx.geometry.Pos;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.scene.layout.AnchorPane;
import javafx.scene.layout.StackPane;
import javafx.scene.media.Media;
import javafx.scene.media.MediaPlayer;
import javafx.scene.media.MediaView;
import javafx.scene.shape.LineTo;
import javafx.scene.shape.MoveTo;
import javafx.scene.shape.Path;
import javafx.scene.shape.PathElement;
import javafx.scene.shape.Rectangle;
import javafx.stage.FileChooser;
import javafx.stage.Stage;
import javafx.util.Duration;

/**
 *
 * @author Adrian Beloqui
 */
public class FXMLDocumentController implements Initializable {
    
    // Set private instance variables
    private FXMLControlController tvControl;
    private int currentIndex;
    private ArrayList<String> mediaURLs;
    private Media media;
    private MediaPlayer player;
    private List<PathElement> movementPointsLeft;
    private PathTransition pathTransLeft;
    private List<PathElement> movementPointsRight;
    private PathTransition pathTransRight;
    private Boolean firstRun;
    
    // Set private instance variables coming from the FXML Document
    @FXML
    private Rectangle rightRectangle;

    @FXML
    private Rectangle leftRectangle;
    
    @FXML
    private AnchorPane anchorPane;
    
    @FXML
    private StackPane movieContainer;
    
    /**
     * Method that loads the next media file to be played and plays it in a new media viewer. The methods for the play, pause, rewind and
     * fast-forward buttons are also defined.
     */
    public void loadNext(){
        // Check if it is the first time that a movie is going to be played.
        if (firstRun){
            firstRun = false;
            // Create new media player with the first media file of the list of media urls
            media = new Media(mediaURLs.get(currentIndex));
            player = new MediaPlayer(media);            
        }
        else{
            // Stop current movie before change it to another one
            player.stop();  
            // Check if the current movie is the last one in the list
            if(currentIndex + 1 == mediaURLs.size()){
                // Create new media player with the first media file of the list of media urls
                currentIndex = 0;
                media = new Media(mediaURLs.get(currentIndex));
                player = new MediaPlayer(media);  
            }
            else{
                // Create new media player with the next media file of the list of media urls
                currentIndex++;
                media = new Media(mediaURLs.get(currentIndex));
                player = new MediaPlayer(media);  
            }
        }
        
        // Set function called when the Play button from the TV Control is pressed
        tvControl.getPlayBtn().setOnAction(
                new EventHandler<ActionEvent>()
                {
                    @Override
                    public void handle(ActionEvent e)
                    {
                        player.play();
                    }
                }
        );
        // Set function called when the Plause button from the TV Control is pressed
        tvControl.getPauseBtn().setOnAction(
                new EventHandler<ActionEvent>()
                {
                    @Override
                    public void handle(ActionEvent e)
                    {
                        player.pause();
                    }
                }
        );
        // Set function called when the Fast-Forward button from the TV Control is pressed
        tvControl.getFastforwardBtn().setOnAction(
                new EventHandler<ActionEvent>()
                {
                    @Override
                    public void handle(ActionEvent e)
                    {
                        // Add 5 seconds to the current time of the movie and play it.
                        player.seek(new Duration(player.getCurrentTime().toMillis() + 5000));
                    }
                }
        );
        // Set function called when the Rewind button from the TV Control is pressed
        tvControl.getRewindBtn().setOnAction(
                new EventHandler<ActionEvent>()
                {
                    @Override
                    public void handle(ActionEvent e)
                    {
                        // Substract 5 seconds to the current time of the movie and play it.
                        player.seek(new Duration(player.getCurrentTime().toMillis() - 5000));
                    }
                }
        );
        // Create new media view with the new media player
        MediaView mediaView = new MediaView(player);
        // Set height and width of the media view
        mediaView.setFitHeight(movieContainer.getHeight());
        mediaView.setFitWidth(movieContainer.getWidth());
        mediaView.maxHeight(350);
        mediaView.maxWidth(550);
        // Set height and width of the movie container
        movieContainer.maxHeight(550);
        movieContainer.maxWidth(550);
        // Delete all children from the movie container
        movieContainer.getChildren().clear();
        // Add new media view to the movie container
        movieContainer.getChildren().add(mediaView);
        // Center media view inside the movie contianer
        movieContainer.setAlignment(mediaView,Pos.CENTER);
        // Set movie container background to black
        movieContainer.setStyle("-fx-background-color: black;");
        
    }
    
    /**
     * Method that creates the transition path of the left curtain to move it
     * to the right and plays the transition.
     */
    public void moveLeftCourtainToRight(){
        // Create new Transition Path
        pathTransLeft = new PathTransition();
        // Create first point of the paths as the current location of the left curtain
        Path wayPointPath = new Path();
        wayPointPath.getElements().add(new MoveTo(-150.0,212));

        // Convert Linked List to Java FX anim Path,
        // one element (stop) at time.
        Iterator iter = movementPointsLeft.listIterator();
        while(iter.hasNext())
        {
            PathElement nextStop = (PathElement) iter.next();
            wayPointPath.getElements().add(nextStop);
        }
        // Assing path to the Transiton
        pathTransLeft.setPath(wayPointPath);
        // Set duration of the Transition
        pathTransLeft.setDuration(Duration.seconds(10));
        // Set object to move
        pathTransLeft.setNode(leftRectangle);
        // Run Transition
        pathTransLeft.play();
    }
    
    /**
     * Method that creates the transition path of the right curtain to move it
     * to the left and plays the transition.
     */
    public void moveRightCourtainToLeft(){
        // Create new Transition Path
        pathTransRight = new PathTransition();
        // Create first point of the paths as the current location of the right curtain
        Path wayPointPath = new Path();
        wayPointPath.getElements().add(new MoveTo(483,212));

        // Convert Linked List to Java FX anim Path,
        // one element (stop) at time.
        Iterator iter = movementPointsRight.listIterator();
        while(iter.hasNext())
        {
            PathElement nextStop = (PathElement) iter.next();
            wayPointPath.getElements().add(nextStop);
        }
        // Assing path to the Transiton
        pathTransRight.setPath(wayPointPath);
        // Set duration of the Transition
        pathTransRight.setDuration(Duration.seconds(10));
        // Set object to move
        pathTransRight.setNode(rightRectangle);
        // Run Transition
        pathTransRight.play();
        // Once finished execute action event
        pathTransRight.setOnFinished(new EventHandler<ActionEvent>() {
            @Override
            public void handle(ActionEvent event) {
                // Once finished the transition, set availability of change of state to true
                tvControl.curtainsAvailable(true);
            }
        });
    }
    
    /**
     * Method that creates the transition path of the left curtain to move it
     * to the left and plays the transition.
     */
    public void moveLeftCourtainToLeft(){
        // Create new Transition Path
        pathTransLeft = new PathTransition();
        // Create first point of the paths as the current location of the left curtain
        Path wayPointPath = new Path();
        wayPointPath.getElements().add(new MoveTo(160,212));

        // Convert Linked List to Java FX animation Path,
        // one element (stop) at time.
        Iterator iter = movementPointsLeft.listIterator();
        while(iter.hasNext())
        {
            PathElement nextStop = (PathElement) iter.next();
            wayPointPath.getElements().add(nextStop);
        }
        // Assing path to the Transiton
        pathTransLeft.setPath(wayPointPath);
        // Set duration of the Transition
        pathTransLeft.setDuration(Duration.seconds(10));
        // Set object to move
        pathTransLeft.setNode(leftRectangle);
        // Run Transition
        pathTransLeft.play();
    }
    
    /**
     * Method that creates the transition path of the right curtain to move it
     * to the right and plays the transition.
     */
    public void moveRightCourtainToRight(){
        // Create new Transition Path
        pathTransRight = new PathTransition();
        // Create first point of the paths as the current location of the right curtain
        Path wayPointPath = new Path();
        wayPointPath.getElements().add(new MoveTo(160, 212));

        // Convert Linked List to Java FX animation Path,
        // one element (stop) at time.
        Iterator iter = movementPointsRight.listIterator();
        while(iter.hasNext())
        {
            PathElement nextStop = (PathElement) iter.next();
            wayPointPath.getElements().add(nextStop);
        }
        // Assing path to the Transiton
        pathTransRight.setPath(wayPointPath);
        // Set duration of the Transition
        pathTransRight.setDuration(Duration.seconds(10));
        // Set object to move
        pathTransRight.setNode(rightRectangle);
        // Run Transition
        pathTransRight.play();
        // Once finished execute action event
        pathTransRight.setOnFinished(new EventHandler<ActionEvent>() {
            @Override
            public void handle(ActionEvent event) {
                // Once finished the transition, set availability of change of state to true
                tvControl.curtainsAvailable(true);
            }
        });
    }
    
    /**
     * Method that creates the points needed for the curtains to open.
     */
    public void setCloseCourtainsMovement(){
        // Create point to move right cutain to the left
        movementPointsRight = new LinkedList<PathElement>();
        PathElement peRight = new LineTo( 160.0, 212.0);
        movementPointsRight.add(peRight);
        
        // Create point to move left curtain to the right
        movementPointsLeft = new LinkedList<PathElement>();
        PathElement peLeft = new LineTo( 160.0, 212.0);
        movementPointsLeft.add(peLeft);
        
        // Set availability of the curtains to change to false until they finish moving.
        tvControl.curtainsAvailable(false);
    }
   
    /**
     * Method that creates the points needed for the curtains to open.
     */
    public void setOpenCourtainsMovement(){
        // Create point to move left cutain to the left
        movementPointsLeft = new LinkedList<PathElement>();
        PathElement peLeft = new LineTo( -150.0, 212.0);
        movementPointsLeft.add(peLeft);
        
        // Create point to move right curtain to the right
        movementPointsRight = new LinkedList<PathElement>();
        PathElement peRight = new LineTo( 483.0, 212.0);
        movementPointsRight.add(peRight);
        
        // Set availability of the curtains to change to false until they finish moving.
        tvControl.curtainsAvailable(false);
    }
    
    @Override
    public void initialize(URL url, ResourceBundle rb) {
        // Open File Chooser dialog and store media urls
        addMedia();
        
        Parent root = null;
        FXMLLoader loader = null;
        try{
            // Load loader for the TV Control
            loader = new FXMLLoader(getClass().getResource("FXMLControl.fxml"));
            root = (Parent) loader.load();
        }
        catch (Exception e){
            e.printStackTrace();
        }
        // Create Stage for the TV Control
        Stage tvControlStage = new Stage();
        tvControlStage.setResizable(false);
        // Create scene for the TV Control and assign the corresponding stage to it
        Scene scene = new Scene(root);
        
        // Set styling file for the TV Control Scene
        String cssURL = this.getClass().getResource("tvControlStyle.css").toExternalForm();
        scene.getStylesheets().add(cssURL);
        
        // Set values for the TV Control Stage to show it to the user in a better way
        tvControlStage.setScene(scene);
        tvControlStage.setX(400);
        tvControlStage.setY(400);
        tvControlStage.show();
        
        // Get controller from the FXML loader of the TV Control
        FXMLControlController myController = (FXMLControlController) loader.getController();
        // Link TV Control Controller with the TV Controller
        myController.linkScenes(this);
        // Move movie container in the X direction to make it look better
        movieContainer.setTranslateX(10);
    }
       
    /**
     * Method that prompts a file chooser in order to import a file that holds a list
     * of the media files that will be used as movies in the applications. Reads and stores
     * the list of file paths written in the file.
     */
    private void addMedia() {
        // Open File Chooser dialog
        FileChooser fc = new FileChooser();
        File chosen = fc.showOpenDialog(null);
        // Get path of the file being imported
        String fname = chosen.getPath();
        Scanner scan = null;
        try{
            // Try to read input file
            scan = new Scanner(new File(fname));
        }
        catch (Exception e){
            // Print stack trace in case of an exception
            e.printStackTrace();
        }
        // Initialize list of media file paths that will be used in the application. 
        mediaURLs = new ArrayList<>();
        // Check if there are file paths to read
        while(scan.hasNextLine()){
            // Read file path
            String line = scan.nextLine();
            // Format file path string to successfully read the file.
            line = line.replace("\\", "/");
            line = line.replace(" ", "%20");
            // Add file path to the list of media urls
            mediaURLs.add("file:///" + line);
        }
        // Set initial index of the movie to be played
        currentIndex = 0;
        // Set first run of the application since it was complied to true
        firstRun = true;
    }
    
    /**
     * Initializes FXMLDocumentController instance variable with the object of the TV Control Scene.
     * @param control
     */
    public void linkScenes(FXMLControlController control){
        tvControl = control;
    }
    
}
