/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package project2;

import javafx.scene.chart.XYChart;

/**
 *
 * @author Adrian Beloqui
 */
public class Candidate {
    
    // Private properties
    private int votes;
    private String name;
    
    // Get method for the name of the candidate
    public String getName(){
        return name;
    }
    
    // Get method for the number of votes
    public int Votes(){
        return votes;
    }
    
    // Method that adds one vote to the candidate's vote count
    public void Vote(){
        votes += 1;
    }
    
    
    // Contructor
    public Candidate(String xName){
        votes = 1;
        name = xName;
    }
    
}
