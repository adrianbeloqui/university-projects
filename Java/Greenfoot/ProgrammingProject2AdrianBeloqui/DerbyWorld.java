import greenfoot.*;  // (World, Actor, GreenfootImage, Greenfoot and MouseInfo)
import java.awt.*;
import java.io.File;
import java.io.IOException;
import java.util.*;

/**
 * Write a description of class DerbyWorld here.
 * 
 * @author Adrian Beloqui
 * @version December 4th, 2015
 */
public class DerbyWorld extends World
{
    private ImageAndScore[] statistics; //Array hold the statistics of the game.
    private boolean initiated; //Boolean variable to control whether there is need for stats or not
    /**
     * Constructor for objects of class DerbyWorld.
     * 
     */
    public DerbyWorld()
    {    
        // Create a new world with 600x400 cells with a cell size of 1x1 pixels.
        super(800, 600, 1);
        addObject(new ControlArea(),725,300);
        initiated = false;
    }
    
    /**
     * Get method of the instance variable 'statistics'
     * 
     * @return statistics - array holding the statistics of the game
     */
    public ImageAndScore[] getStatistics()
    {
        return statistics;
    }
    
    /**
     * Method that selects the correct image accordingly to the 
     * name of the file, and also edits the image drawing the number
     * of the car.
     * 
     * @param imageName - string holding color of the car desired
     * @param number - int number of the car
     * 
     * @return GreenfootImage - returns an object of type GreenfootImage 
     */
    public GreenfootImage selectIcon(String imageName, int number)
    {
        String fileName = "";
        switch (imageName)
        {
            case "blue":
                fileName = "car01-n.png";
                break;
            case "red":
                fileName = "car02-n.png";
                break;
            case "green":
                fileName = "car03-n.png";
                break;
        }
        GreenfootImage myImg = new GreenfootImage(fileName);
        myImg.setColor(Color.white);
        myImg.drawString(""+number,2*myImg.getWidth()/5, 20);
        return myImg;
    }
    
    /**
     * Method that sorts the statistics of the game applying the Bubble sorting algorithm
     */
    public void sort()
    {
        boolean swapped = true;
        ImageAndScore temp;
        while (swapped) {
            swapped = false;
            for (int i = 0; i < statistics.length-1; i++) {
                if(statistics[i+1] != null){
                    if (statistics[i+1].getScore() > statistics[i].getScore()) {
                        temp = statistics[i+1];
                        statistics[i+1] = statistics[i];
                        statistics[i] = temp;
                        swapped = true;
                    }
                }
            }
        }
    }
    
    /**
     * Method that removes and adds the statistics of the game to update the values
     */
    public void printStatistics()
    {
        removeObjects(getObjects(ImageAndScore.class));
        int height = 70;
        for (ImageAndScore stat : statistics)
        {
            addObject(stat, 710, height);
            height += 45;
        }
    }
    
    
    /**
     * Act - do whatever the DerbyWorld wants to do. This method is called whenever
     * the 'Act' or 'Run' button gets pressed in the environment.
     */
    public void act()
    {
        if(Greenfoot.isKeyDown("l") || Greenfoot.isKeyDown("L"))
        {
            int carNum = 1;
            removeObjects(getObjects(AutoCar.class)); //Remove all AutoCar objects
            removeObjects(getObjects(ImageAndScore.class)); //Remove all ImageAndScore objects
            FileDialog fd = new FileDialog(new Frame(),"File Picker"); //Creates FileDialog object
            fd.setVisible(true); //Set it visible for the user to be able to use it. 
            
            // if user did select a file, read it into a car
            if (fd.getFile()!=null)
            {
                String fullName = fd.getDirectory() + fd.getFile();
                try
                {
                    Scanner in = new Scanner(new File(fullName)); // could give an I/O Exception
                    double xVel = 0.0;
                    double yVel = 0.0;
                    // as long as there are terms to process, process them!
                    while(in.hasNext())
                    {
                        //Store every value of a line in a variable
                        String icon = in.next();
                        double xCurr = in.nextInt();
                        double yCurr = in.nextInt();
                        xVel = Double.parseDouble(in.next());
                        yVel = Double.parseDouble(in.next());
                        GreenfootImage myIcon = selectIcon(icon, carNum); //Get the actual image of the required color for that car
                        AutoCar car = new AutoCar(myIcon, xCurr, yCurr, xVel, yVel, carNum); //Create AutoCar object
                        car.Rotate(); //Puts the car's image in the right direction
                        addObject(car, (int)xCurr, (int)yCurr); //adds the car to the world
                        carNum++; //increases the number of the car                       
                    }
                }
                catch (IOException exception)
                {
                 // do something about a file problem
                }
                
               //First create an array accurrate for the amount of car that are in the world at this point. 
               statistics = new ImageAndScore[carNum-1];
               //Loop through the statistics array, and for each slot, loop through all the cars in the world at this point.
               //If the car number is the same as the index of the slot, then create a statistic for that car, in that slot of the array
               for(int i=0; i<carNum; i++)
               {
                   for(AutoCar car : this.getObjects(AutoCar.class))
                   {
                       if(car.getNumber() == (i+1))
                       {
                            statistics[i] = new ImageAndScore(car.getIcon(), car.getNumber(), 20);
                       }
                   }   
               }
               //Game was initiated, so sort the statistics and show them in the world.
               initiated = true;
               sort();
               printStatistics();
            }
        }
        else //While the l or L keys are not pressed, check if the game is being played, if it is, keep updating the order
        //of the statistics and update them in the world.
        {
           if(initiated)
           {
                sort();
                printStatistics();
           }
        }
    }
}
