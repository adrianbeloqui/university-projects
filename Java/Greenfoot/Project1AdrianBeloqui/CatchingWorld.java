import greenfoot.*;

/**
 * CatchingWorld is the World for CSC14400 project#1. It will have a Scoreboard, a CircleMeter,
 *    a RectangleMeter, and a Truck in it. As time goes by, Balls will be added (and removed) 
 *    to/from the world.
 * 
 * @author Stephen Blythe
 * @version September, 2015
 */
public class CatchingWorld extends World
{
    private ScoreBoard scoreBoard;
    private RectangleMeter rectangleMeter;
    private CircleMeter circleMeter;
    private Projectile projectile;
    private boolean projectileAlive;
    /**
     * Constructor for objects of class CatchingWorld.
     * 
     */
    public CatchingWorld()
    {    
        // Create a new world with 750x500 cells with a cell size of 1x1 pixels.
        super(750, 500, 1);
        
        // Creation of all the instances of the objects needed in the World
        addObject(new Truck(1.0), 300, 479);
        
        circleMeter = new CircleMeter(50);
        addObject(circleMeter, 25, 475);
        
        rectangleMeter = new RectangleMeter(100);
        addObject(rectangleMeter, 120, 490);
        
        scoreBoard = new ScoreBoard(10);
        addObject(scoreBoard, 375, 10);
        
        // No project is in the world at this momento so it is set to false
        projectileAlive = false;
    }
    
    public void act()
    {
        if (Greenfoot.isKeyDown("n"))
        {
                scoreBoard.setLeft(10); // Addition of 10 more shots
        }
        if (Greenfoot.isKeyDown("r"))
        {       
                // Scoreboard is reseted. 
                scoreBoard.setLeft(10);
                scoreBoard.setHits(0);
                scoreBoard.setMisses(0);
        }
        if (Greenfoot.isKeyDown("space"))
        {
                if(!projectileAlive && scoreBoard.getLeft()>0)
                {
                    // Math needed for the creation of the instance of the Projectile
                    double speed = 3 * rectangleMeter.getFilledRatio();
                    double vx = speed * Math.cos(circleMeter.getAngle());
                    double vy = -(speed * Math.sin(circleMeter.getAngle()));
                    // Projectile is created and added to the World
                    projectile = new Projectile(vx,vy);
                    addObject(projectile,circleMeter.getArcX(), circleMeter.getArcY());
                    // Now a projectile is in the World, so it is set to true.
                    projectileAlive = true;
                    
                }
        }
        
        if (projectileAlive)
        {
            if(projectile.isAtEdge()) // Check if the projectile is at edge (it misses the truck)
            {
                scoreBoard.incrementMisses(); // Add one more miss to the Scoreboard
                scoreBoard.decrementLeft(); // Reduce the projectiles left by 1
                removeObject(projectile); // Remove object from World
                projectileAlive= false; // Now no projectile is alive in the World
                
            }
            else
            {
                if (projectile.checkCollision())
                {
                    scoreBoard.incrementHits(); // Add one more hit to the Scoreboard
                    scoreBoard.decrementLeft(); // Reduce the projectiles left by 1
                    removeObject(projectile); // Remove object from World
                    projectileAlive= false; // Now no projectile is alive in the World
                }
            }
        }
        
    }

}
