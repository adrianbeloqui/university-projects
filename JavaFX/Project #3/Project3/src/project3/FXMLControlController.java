 /*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package project3;

import java.net.URL;
import java.util.ResourceBundle;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.Button;

/**
 *
 * @author Adrian Beloqui
 */
public class FXMLControlController implements Initializable {
    
    // Private instance variables
    private FXMLDocumentController mainTV;
    private Boolean available;
    private Boolean curtainState;
    
    // Private instance variables comming from the FXML file
    @FXML
    private Button fastforwardBtn;

    @FXML
    private Button playBtn;

    @FXML
    private Button pauseBtn;

    @FXML
    private Button rewindBtn;
    
    /**
     * Method that sets a boolean value to the availability state to change of the curtains.
     * 
     * @param bo
     */
    public void curtainsAvailable(Boolean bo){
        available = bo;
    }
    
    /**
     * Public GET method for the Play button.
     * 
     * @return Button type
     */
    public Button getPlayBtn(){
        return playBtn;
    }
    
    /**
     * Public GET method for the Pause button.
     * 
     * @return Button type
     */
    public Button getPauseBtn(){
        return pauseBtn;
    }
    
    /**
     * Public GET method for the Rewind button.
     * 
     * @return Button type
     */
    public Button getRewindBtn(){
        return rewindBtn;
    }
    
    /**
     * Public GET method for the Fast-Forward button.
     * 
     * @return Button type
     */
    public Button getFastforwardBtn(){
        return fastforwardBtn;
    }
    
    @FXML
    void loadNext(ActionEvent event) {
        // Load next movie
        mainTV.loadNext();
    }
    
    @FXML
    void openCurtains(ActionEvent event) {
        // Open  curtains if they are closed and if they are available to a change of state.
        if (available && !curtainState){
            // Set movement of the curtains
            mainTV.setOpenCourtainsMovement();
            // Open left curtain
            mainTV.moveLeftCourtainToLeft();
            // Open right curtain
            mainTV.moveRightCourtainToRight();
            // Set curtains state to open
            curtainState = true;
        }
    }

    @FXML
    void closeCurtains(ActionEvent event) {
        // Close curtains if they are open and if they are available to a change of state.
        if (available && curtainState){
            // Set movement of the curtains
            mainTV.setCloseCourtainsMovement();
            // Close left curtain
            mainTV.moveLeftCourtainToRight();
            // Close right curtain
            mainTV.moveRightCourtainToLeft();
            // Set curtains state to closed
            curtainState = false;
        }
    }
    
    @FXML
    void exitApplication(ActionEvent event) {
        // Exit application
        System.exit(0);
    }
    
    @Override
    public void initialize(URL url, ResourceBundle rb) {
        // Initialize instance variables
        available = true;
        curtainState = false;
    }
    
    /**
     * Initializes FXMLDocumentController instance variable with the object of the TV Scene.
     * 
     * @param tv
     */
    public void linkScenes(FXMLDocumentController tv){
        mainTV = tv;
        // Link this FMXL Controller to the TV FXML Controller
        mainTV.linkScenes(this);
    }
    
}
