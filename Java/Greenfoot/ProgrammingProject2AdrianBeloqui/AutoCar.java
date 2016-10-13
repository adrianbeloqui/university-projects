import greenfoot.*;  // (World, Actor, GreenfootImage, Greenfoot and MouseInfo)
import java.util.Scanner;
import java.util.List;

/**
 * AutoCar class is the responsible for the functionality ando movility of the cars in the world. 
 * 
 * @author Adrian Beloqui
 * @version December 4th, 2015
 */
public class AutoCar extends Actor
{
    //Instance variables that control the graphic charactersitics of the cars
    //and those related to the movement (speed and location).
    private GreenfootImage icon; 
    private double xVel;
    private double yVel;
    private double xCurr;
    private double yCurr;
    private int number;
    
    /**
     * Constructor of the AutoCar class. It matches parameters with instance variables and redraws the image of the car just to be sure is draw 
     * as it is suppose to be.
     * 
     * @param initImage - GreenfootImage of the car
     * @param currX - current X position in the World
     * @param currY - current Y position in the World
     * @param velX - velocity in the X vector of the World
     * @param velY - velocity in the Y vector of the World
     * @param cnum - number of the car
     */
    public AutoCar(GreenfootImage initImage, double currX, double currY, double velX, double velY, int cnum)
    {
        icon = initImage;
        xCurr = currX;
        yCurr = currY;
        xVel = velX;
        yVel = velY;
        number = cnum;
        redraw(initImage);
    }
    
    /**
     * Act - do whatever the AutoCar wants to do. This method is called whenever
     * the 'Act' or 'Run' button gets pressed in the environment.
     */
    public void act() 
    {   
        boolean collitionated = false;
        List<AutoCar> listOfIntersectingObjects = getIntersectingObjects(AutoCar.class); //List of all the intersecting objects to the current object
        for(AutoCar car : listOfIntersectingObjects) //Loop through each intersecting AutoCar
        {
            double xdist = car.getX() - this.getX(); //Math required
            double ydist = car.getY() - this.getY(); //Math required
            double dotProd = xdist * this.xVel + ydist * this.yVel; //Math required
            if(dotProd >0) //If objects are not going in opposit directions
            {
                collitionated = true; //It is true that there was a collition
                double projPerc = dotProd / (xdist*xdist + ydist*ydist); //Math required
                double projx = projPerc*xdist; //Math required
                double projy = projPerc*ydist; //Math required
                double n = listOfIntersectingObjects.size(); //Math required
                car.setXVel( car.getXVel() + (projx/n)); //Math required. Collisionated car's setting of new X velocity
                car.setYVel( car.getYVel() + (projx/n)); //Math required. Collisionated car's setting of new Y velocity
                
               //Update of the current car, "this"car, X and Y velocity with the math required
                this.xVel = this.xVel - (projx/n);
                this.yVel = this.yVel - (projy/n);
            }
        }
        
        //Get the staticts that is being hold by the DerbyWorld class
        ImageAndScore[] stats = ((DerbyWorld)getWorld()).getStatistics();
        if(collitionated) //if there was a collition, scores need to be updated
        {
            for(ImageAndScore stat : stats)
            {
                if(number == stat.getNumber()){ //if it is this car's number is equal to the one looping decrement the score by the amount of intersecting objects
                    for(int i=0; i<listOfIntersectingObjects.size();i++){
                        stat.decrementScore();
                    }
                    if(stat.getScore() == 0) //if the score of the car is 0, remove the object from the world but not the stats.
                    getWorld().removeObject(this);
                }
            }
        }
        
        
        
       
        //If this car is touching the borders set for the game, then change the direction of either X velocity or Y velocity and increase both velocities.
        //Specific numbers were used to control the borders just with the objective of making more "real" the fact of touching the border of the game.
        if(xCurr >= 620 || xCurr <= 35)
        {
            xVel = -xVel;
            xVel = xVel*1.0001;
            yVel = yVel*1.0001;
        }
        
        if(yCurr >= 575 || yCurr <= 35)
        {
            yVel = -yVel;
            xVel = xVel*1.0001;
            yVel = yVel*1.0001;
        }
        
        //Update calculated velocities in the method to the instance variables
        xCurr += xVel;
        yCurr += yVel;
        
        //Move the car to the new calculated location
        setLocation((int)xCurr, (int)yCurr);
        //Rotate the image with the new directional information
        Rotate();
    }
    
    
    /**
     * Set method for the instance variable xVel.
     * 
     * @param v - new X velocity for the car
     */
    public void setXVel(double v)
    {
        xVel = v;
    }
    
    /**
     * Get method for the instance variable xVel.
     * 
     * @return double - X velocity of the car
     */
    public double getXVel()
    {
        return xVel;
    }
    
    /**
     * Set method for the instance variable yVel.
     * 
     * @param v - new Y velocity for the car
     */
    public void setYVel(double v)
    {
        yVel = v;
    }
    
    /**
     * Get method for the instance variable yVel.
     * 
     * @return double - Y velocity of the car
     */
    public double getYVel()
    {
        return yVel;
    }
    
    /**
     * Get method for the instance variable number.
     * 
     * @return int - number of the car
     */
    public int getNumber()
    {
        return number;
    }
    
    /**
     * This method is called by the Greenfoot system when this actor has been inserted into the world.
     * It sets the instance variable to the values of the current X and Y of the object that was added to the world. 
     * 
     * @param w - The world
     */
    protected void addedToWorld(World w)
    {
        xCurr = getX(); // Set the current x location
        yCurr = getY(); // Set the current y location
    }
    
    /**
     * Get method for the instance variable icon.
     * 
     * @return GreenfootImage - image of the car
     */
    public GreenfootImage getIcon()
    {
        return icon;
    }
    
    /*
     * redraw   (private)
     * 
     *   regenerates the image for this actor
     */
    private void redraw(GreenfootImage img)
    {
        setImage(img);
    }
    
    /**
     * Method that is responsible for rotating the image in the direction that is requested.
     */
    public void Rotate()
    {
        double tanTheta = this.yVel/this.xVel;
        double radians = Math.atan(tanTheta);
        if(this.xVel <0)
            radians = radians - Math.PI;
        double degree = Math.toDegrees(radians);
        degree += 90;
        this.setRotation((int)degree);
    }
}
