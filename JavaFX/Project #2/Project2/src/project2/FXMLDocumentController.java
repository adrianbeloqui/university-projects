/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package project2;

import java.net.URL;
import java.util.ArrayList;
import java.util.ResourceBundle;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.event.ActionEvent;
import javafx.event.EventHandler;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.Node;
import javafx.scene.Scene;
import javafx.scene.chart.BarChart;
import javafx.scene.chart.PieChart;
import javafx.scene.chart.XYChart;
import javafx.scene.control.Alert;
import javafx.scene.control.Alert.AlertType;
import javafx.scene.control.Button;
import javafx.scene.control.ComboBox;
import javafx.scene.control.TextField;
import javafx.scene.input.MouseEvent;
import javafx.stage.Stage;

/**
 *
 * @author Adrian Beloqui
 */
public class FXMLDocumentController implements Initializable {
    
    // Instance variables
    private XYChart.Series mySeries;
    private ArrayList<Candidate> candidates;
    
    @FXML
    private BarChart<?, ?> barChart;

    @FXML
    private ComboBox<String> candidateCmb;

    @FXML
    private Button closeButton;

    @FXML
    private PieChart pieChart;

    @FXML
    private TextField newCandidateTxt;

    /*
    * Method in charge of quitting the application. 
    */
    @FXML
    void quitApplication(ActionEvent event) {
        Node source = (Node) event.getSource();
        Scene s = (Scene) source.getScene();
        Stage stage = (Stage) s.getWindow();
        stage.close();
    }

    /**
     * Method that adds a candidate to the application. 
     */
    @FXML
    void addCandidate(ActionEvent event) {
        String labelText;
        
        // Get input text from the text field
        labelText = newCandidateTxt.getText();
        
        // Check if there are candidates with the same name already in the system.
        if(checkDuplicateCandidate(labelText)){
            
            // Alert the user that his input already exists in the application. 
            Alert alert = new Alert(AlertType.ERROR);
            alert.setTitle("Candidate Duplicate Error");
            alert.setHeaderText("Duplicated Candidate");
            alert.setContentText("The candidate that you just tried to add already exists.");
            alert.showAndWait();
            return;
        }
        // Create a new Candidate and add it to the list of active candidates. 
        Candidate candidate = new Candidate(labelText);
        candidates.add(candidate);
        
        // Update the list of candidates available to be deleted
        updateComboBox();
        
        // Add the new candidate to the Pie Chart
        addWedgeIfNotPresent(candidate);
        // Add the new candidate to the Bar Chart
        addBarIfNotPresent(candidate);
        
        // Clean the text field
        newCandidateTxt.setText("");
    }
    
    /**
     * Method responsible for deleting a candidate selected in the combo box
     */
    @FXML
    void deleteCandidate(ActionEvent event) {
        
        // Get the string of the item selected in the combo box
        String candidate = candidateCmb.getSelectionModel().getSelectedItem().toString();
        
        int indexToDelete = -1;
        
        // Loop through the Data of the Pie Charm and find the candidate with the name equal to
        // the name of the candidate to be deleted
        for (PieChart.Data slice : pieChart.getData()){
            if (slice.getName().equals(candidate)){
                indexToDelete = pieChart.getData().indexOf(slice);
            }
        }
        // If a candidate was found in the Chart, then delete it.
        if (indexToDelete != -1){
            pieChart.getData().remove(indexToDelete);
        }
        
        indexToDelete = -1;
        // Loop through the Data of the Bar Charm and find the candidate with the name equal to
        // the name of the candidate to be deleted
        ObservableList<XYChart.Data> list = (ObservableList<XYChart.Data>) mySeries.getData();
        for (XYChart.Data bar : list){
            if (bar.getXValue().equals(candidate)){
                indexToDelete = mySeries.getData().indexOf(bar);
            }
        }
        // If a candidate was found in the Chart, then delete it.
        if (indexToDelete != -1){
            mySeries.getData().remove(indexToDelete);
        }
        
        // Remove the candidate from the list of active candidates
        removeCandidate(candidate);
        // Update the list of candidates available to be deleted
        updateComboBox();
        
    }

    /**
     * Method responsible for deleting the data of the Charts, and clearing the list
     * of active candidates.
     */
    @FXML
    void resetCharts(ActionEvent event) {
        // Clear data of the Bar Chart
        barChart.getData().clear();
        mySeries=new XYChart.Series();
        barChart.getData().add(mySeries);
        // Clear data of the Pie Chart
        pieChart.getData().clear();
        // Clear list of active candidates
        candidates.clear();
        // Update the list of candidates available to be deleted
        updateComboBox();
    }
    
    /*
    * Method responsible for updating the list of candidates available to be deleted in the combo box
    */
    private void updateComboBox(){
        // Clear all the items in the combo box
        candidateCmb.getItems().clear();
        // Add each active candidate to the list of active candidates
        ObservableList<String> list = FXCollections.observableArrayList();
        for (Candidate c : candidates){
            list.add(c.getName());
        }
        // Set the new list of items of the combo box
        candidateCmb.getItems().addAll(list);
    }
    
    /*
    * Method responsible for removing a candidate from the list of active candidates
    */
    private void removeCandidate(String name){
        int indexToDelete = -1;
        // Search for a candidate with the name that came as an parameter in the
        // list of active candidates and get the index of this candidate in the list
        for (Candidate c : candidates){
            if (c.getName().equals(name)){
                indexToDelete = candidates.indexOf(c);
            }
        }
        // If a candidate was found, then delete it. 
        if (indexToDelete != -1){
            candidates.remove(indexToDelete);
        }
    }
    
    /**
     * Method responsible for checking if a candidate already exists in the application
     */
    private Boolean checkDuplicateCandidate(String name){
        // Search for a candidate with the name that came as an parameter in the
        // list of active candidates
        for (Candidate c : candidates){
            if (c.getName().equals(name)){
                return true;
            }
        }
        return false;
    }
    
    /**
     * Method responsible for adding a new slice to the Pie Chart
     */
    private void addWedgeIfNotPresent(Candidate can)
    {
        // Create the new slice for the Pie Chart and add it to the chart
        PieChart.Data newSlice = new PieChart.Data(can.getName(), 1);
        pieChart.getData().add(newSlice);
        
        // Add an click event on the slice
        newSlice.getNode().addEventHandler( MouseEvent.MOUSE_CLICKED,
                
                new EventHandler<MouseEvent>()
                {
                    @Override
                    public void handle(MouseEvent e)
                    {
                        // Add a vote for the candidate linked to the slice
                        can.Vote();
                        // Update the Bar Chart with the new vote
                        AddVoteBarChart(can);
                        // Update the Pie Chart with the new vote
                        newSlice.setPieValue((double) can.Votes());
                    }
                }
        );
    }
    
    /**
     * Method responsible for updating the value of the Bar Chart for a specific candidate 
     */
    private void AddVoteBarChart(Candidate can){
        // Search for the bar that is linked to the candidate and update its value
        ObservableList<XYChart.Data> list = (ObservableList<XYChart.Data>) mySeries.getData();
        for (XYChart.Data bar : list){
            if (bar.getXValue().equals(can.getName())){
                bar.setYValue((double)can.Votes());
            }
        }
    }
    
    /**
     * Method responsible for updating the value of the Pie Chart for a specific candidate 
     */
    private void AddVotePieChart(Candidate can){
        // Search for the slice that is linked to the candidate and update its value
        for (PieChart.Data slice : pieChart.getData()){
            if (slice.getName().equals(can.getName())){
                slice.setPieValue((double) can.Votes());
            }
        }
    }
    
    private void addBarIfNotPresent(Candidate can)
    {
        // Create the new bar for the Bar Chart and add it to the chart
        XYChart.Data newBar = new XYChart.Data<String, Integer>(can.getName(), 1);
        mySeries.getData().add(newBar);
        
        // Add an click event on the bar
        newBar.getNode().addEventHandler( MouseEvent.MOUSE_CLICKED,
                
                new EventHandler<MouseEvent>()
                {
                    @Override
                    public void handle(MouseEvent e)
                    {
                        // Add a vote for the candidate linked to the slice
                        can.Vote();
                        // Update the Pie Chart with the new vote
                        AddVotePieChart(can);
                        // Update the Bar Chart with the new vote
                        newBar.setYValue((double) can.Votes());
                    }
                }
        );
        
 
    }
    
    @Override
    public void initialize(URL url, ResourceBundle rb) {
        // TODO
        // Create a new series for the Bar Chart and asign it to the Bar Chart
        mySeries=new XYChart.Series();
        barChart.getData().add(mySeries);
        // Initialize the list of active candidates
        candidates = new ArrayList<Candidate>();
    }    
    
}
