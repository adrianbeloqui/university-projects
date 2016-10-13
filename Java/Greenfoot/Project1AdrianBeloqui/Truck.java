import greenfoot.*;
import java.awt.Color; // for the colors used in drawing the truck. 
/**
 * Truck
 *   should move back and forth along the bottom of the screen, from the right side to the middle
 *   and back to the right, and then back to the middle, and so on. 
 *
 *    you **WILL** need to add code to this class. That could be filling in more code in existing
 *    methods, adding new methods, and/or adding instance variables. It is 100% up to you!
 *    
 * @author Stephen Blythe
 * @version September, 2015
 */
public class Truck extends Actor
{
    private double xVel; // Velocity at which the truck moves
    private double currX; // X location of the truck
    /** 
     * Truck
     * 
     *     constructs a truck (but does not add it to the wrold). Currently, this does nothing more
     *     than build the image for the truck. 
     */
    public Truck(double initXVel)
    {
        GreenfootImage img = new GreenfootImage(75,45); // an image big enough for ur truck
        
        // set truck background to "clear"
        Color bg = new Color(0,0,0,0); // extra 0 will make transparent ...        
        img.setColor(bg);
        img.fill();
        
        // draw red parts of truck.
        img.setColor(Color.RED);
        img.fillRect(5,25,65,10);        // draw flatbed
        img.fillRect(45,5,25,20);        // draw cab
        
        // draw gray parts of truck
        img.setColor(Color.GRAY);        
        img.fillRect(47,0, 3,30);        //draw exhaust stack
        
        // draw blue parts of truck
        img.setColor(Color.BLUE);
        img.fillRect(55,10, 15,15);      // draw window
        
        // raw black parts of truck
        img.setColor(Color.BLACK);       
        // draw wheels     
        img.fillOval(15,28, 15,15);      
        img.fillOval(50,28, 15,15);
                
        setImage(img);  //have Actor use the image we just created.
        
        xVel = initXVel; // Set velocity to the one passes as an argument
        
    }
    
    protected void addedToWorld(World w)
    {
        currX = getX(); // Set the current x location
    }
    
    /**
     * Act - do whatever the Truck wants to do. This method is called whenever
     * the 'Act' or 'Run' button gets pressed in the environment.
     */
    public void act() 
    {
        currX += xVel; // Increase the X location of the truck 
        
        setLocation((int)currX, getY()); // Set the new location of the truck
        
        if(currX >= getWorld().getWidth()-1) //Check if the truck is in the right edge
        {
            xVel = -xVel; //Change direction of the truck
        }
        if(currX <= getWorld().getWidth()-479) //Check if the truck is in the middle of the world
        {
            xVel = -xVel; //Change direction of the truck
        }
    }    
}
