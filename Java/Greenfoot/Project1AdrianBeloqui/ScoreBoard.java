import greenfoot.*;
import java.awt.Color;

/**
 * ScoreBoard 
 *   a "nice" representation of the game's current status, including projectiles left, projectiles
 *   that have hit the truck, and the number that have missed. 
 * 
 *   Although you are welcome to modify this code, doing so is HIGHLY inadvisable. If you 
 *   feel the need to do so, you are likely making this MUCH harder than it should be. 
 * 
 * @author Stephen Blythe
 * @version September 2015
 */
public class ScoreBoard extends Actor
{
    private int numHits;         // keeps track of how many hits scoreboard has been told about
    private int numMisses;       // keeps track of how many misses scoreboard has been told about
    private int projectilesLeft; // keeps track of how many balls scoreboard has been told are left
    
    /**
     * ScoreBoard
     *   contructs a ScoreBoard object with hits and misses set to 0 by default.
     *   Note that this effectively makes the scoreboard the width of the world and 20 pixels high. 
     *   
     *   @param projectile gives the initial number of projectiles left 
     */
    public ScoreBoard(int projectileCount)
    {
        numHits=numMisses=0;
        projectilesLeft=projectileCount;
    }
    
    // addedToWorld 
    //    simply redraws the scoreboard after it is placed. This is where it is resized to
    // the width of the world
    protected void addedToWorld(World w)
    {
        redraw();
    }
    
    /**
     * redraw
     * 
     *   just redraws the scoreboard to update it with the number 
     */
    public void redraw()
    {
        // redrawing is easiest if we just start from scratch. 
        GreenfootImage img = new GreenfootImage(getWorld().getWidth(),20);
        
        // default background should be light gray
        img.setColor(Color.lightGray);
        img.fill();
        
        // draw dark gray border around ScoreBoard
        img.setColor(Color.darkGray);
        img.drawRect(0,0,img.getWidth()-1,img.getHeight()-1);
        
        // draw how many projectiles are left in black
        img.setColor(Color.black);
        img.drawString("Left:"+projectilesLeft, img.getWidth()/5, 15);
        
        // draw how many hits there are in green 
        img.setColor(new Color(0,155,0));
        img.drawString("Hits:"+numHits, 25*img.getWidth()/50, 15);
        
        // draw how many misses there are in red
        img.setColor(Color.red);
        img.drawString("Misses:"+numMisses, 3*img.getWidth()/4, 15);
        
        setImage(img); // tell our object to use this new image 
    }
   
    /**
     * getHits
     *    is an accessor for number of hits
     *    @return the number of hits since the last reset
     */
    public int getHits() {return numHits;}
    
    /**
     * getMisses
     *    is an accessor for number of misses
     *    @return the number of misses since the last reset
     */
    public int getMIsses() {return numMisses;}
    
    /**
     * getLeft
     *    is an accessor for number of projectiles left
     *    @return the number of projectiles left since the last reset
     */
    public int getLeft() {return projectilesLeft;}
    
    /**
     * setHits
     *   is a mutator that sets the number of hits since last reset
     *   @param the new number of hits`
     */
    public void setHits(int numHits)
    {
        this.numHits=numHits;
        redraw();
    }
    
    /**
     * setMisses
     *   is a mutator that sets the number of misses since last reset
     *   @param the new number of misses`
     */
    public void setMisses(int nMisses)
    {
        numMisses=nMisses;
        redraw();
    }
    
    /**
     * setLeft
     *   is a mutator that sets the number of projectile left since last reset
     *   @param the new number of projectiles left`
     */
    public void setLeft(int numProjectiles)
    {
        projectilesLeft = numProjectiles;
        redraw();
    }
    
    /**
     * incrementHits
     *   is a mutator that adds one to the number of hits since last reset
     */
    public void incrementHits()
    {
        numHits++;
        redraw();
    }
    
   /**
     * incrementMIsses
     *   is a mutator that adds one to the number of misses since last reset
     */
    public void incrementMisses()
    {
        numMisses++;
        redraw();
    }
    
    
    /**
     *decrementLeft
     *   is a mutator that subtracts one from the number of projectiles left since last reset
     */
    public void decrementLeft()
    {
        projectilesLeft--;
        redraw();
    }
    
    
    // note that a ScoreBoard has no act, since it does't directly react to user input, doesn't
    // need to interact with other Actors, and doesn't do anything to automatically update
}
