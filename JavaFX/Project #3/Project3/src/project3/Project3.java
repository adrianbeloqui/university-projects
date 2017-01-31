/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package project3;

import javafx.application.Application;
import javafx.fxml.FXMLLoader;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.stage.Stage;

/**
 *
 * @author Adrian Beloqui
 */
public class Project3 extends Application {
    
    @Override
    public void start(Stage stage) throws Exception {
        // Load FMXL loader for the TV FXML document
        Parent root = FXMLLoader.load(getClass().getResource("FXMLDocument.fxml"));
        // Get path of the styling file for the TV FXML Document
        String cssURL = this.getClass().getResource("tvStyle.css").toExternalForm();
        
        
        Scene scene = new Scene(root);
        // Set styling file for the TV FXML Document
        scene.getStylesheets().add(cssURL);
        
        stage.setScene(scene);
        stage.setX(1050);
        stage.setY(400);
        stage.setResizable(false);
        stage.show();
        
    }

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        launch(args);
    }
    
}
