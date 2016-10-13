import greenfoot.*;

/**
 *  Projectile
 *     class which shows a single ball projectile, and describes its movement.
 * 
 *    you **WILL** need to add code to this class. That could be filling in more code in existing
 *    methods, adding new methods, and/or adding instance variables. It is 100% up to you!
 * 
 * @author Stephen Bythe
 * @version October 2015
 */
public class Projectile extends Actor
{
    private double vY; // Velocity at which the projectile moves in the Y vector
    private double vX; // Velocity at which the projectile moves in the X vector
    private double currY; // Y location of the truck
    private double currX; // X location of the truck
    /**
     * Projectile
     * 
     *   constructs a Projectile object
     * 
     *   @param xVel the initial projectule speed in the x direction
     *   @param yVel the initial projectile speed in the y direction
     */   
    public Projectile(double xVel, double yVel)
    {
        vY = yVel; // Set x velocity to the one passes as an argument (xVel)
        vX = xVel; // Set y velocity to the one passes as an argument (yVel)

    }
    
    protected void addedToWorld(World w)
    {
        currX = getX(); // Set the current x location
        currY = getY(); // Set the current y location
    }

    
    /**
     * Act - do whatever the Projectile wants to do. This method is called whenever
     * the 'Act' or 'Run' button gets pressed in the environment.
     */
    public void act() 
    {
        vY += 0.01; // Increase of the projectile y speed by 0.01
        
        currX += vX; // Increase the X location of the projectile by the x velocity 
        currY += vY; // Increase the Y location of the projectile by the y velocity 
        
        setLocation((int)currX, (int)currY); // Set the new location of the projectile
    }
    
     /**
     * checkCollision - Checks if the projectile collisionated with a Truck object.
     * 
     *  @return Boolean value depending on the condition
     */
    public boolean checkCollision()
    {
         if (this.getOneIntersectingObject(Truck.class) !=null)
         {
                return true;
            }
         else
         {
             return false;
            }
    }
}
