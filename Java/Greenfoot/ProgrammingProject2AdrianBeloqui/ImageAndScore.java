import greenfoot.*;
import java.awt.*; // for Color
/**
 * Supports statistics about a single car in the Demolition Derby. 
 * 
 * You likely will NOT need to modify this class, although you are free to do so. 
 * 
 * @author Adrian Beloqui
 * @version December 4th, 2015
 */
public class ImageAndScore extends Actor
{
    private GreenfootImage icon;  // the "small" version of the image to use in the statistics
    private int score;            // the current number of hits this car has left
    private int carNum;           // the car number
    
    
    /**
     * ImageAndScore
     * 
     * @param icon - the image of the car in question
     * @param cnum - the car number of the car in question
     * @param score - the number of collisions the car could still survive (most likely 20)
     * 
     * builds an Actor that holds the data about a car. 
     */
    public ImageAndScore(GreenfootImage icon, int cnum, int score)
    {
        this.icon=new GreenfootImage(icon); // copy the image by duploicating it instead of sharing the reference
        this.score=score;                   // use provided score
        carNum = cnum;                      // use provided car number
        
        // scale the image to fit within this actor
        this.icon.scale(15,30);
        setImage(new GreenfootImage(this.icon.getWidth()+50, this.icon.getHeight()+4) );
        
        // redraw the actor (to include the new data)
        redraw();
    }
    
    /**
     * setScore
     * @param newScore - the value to set the new score to.
     * 
     * mutator that sets the score in the displayed statistics
     */
    public void setScore(int newScore)
    {
        score=newScore;
        
        // setting the score means we need to redraw the stats. 
        redraw();
    }
    
    /**
     * getScore
     * @return - the current score value
     * 
     * accessor that returns the current number of collisions that the car can still take
     */
    public int getScore()
    {
        return score;
    }
    
    /**
     * getNumber
     * @return - the car number
     * 
     * accessor that returns the car number
     */
    public int getNumber()
    {
        return carNum;
    }
    
    /**
     * decrementScore
     * 
     * mutator that essentially reords that there is one more hit .
     */
    public void decrementScore()
    {
        score--; // one more hit
        if (score<0) score=0; // safeguard - we should never get negative hits left
        
        // updating score means we should redraw this actor's image
        redraw();
    }
    
    /*
     * redraw   (private)
     * 
     *   regenerates the image for this actor
     */
    private void redraw()
    {
        GreenfootImage img = getImage(); // get the current image
        
        // blank out the current image
        img.setColor(Color.lightGray);
        img.fill();
        
        // draw the icon and the statistice back into image. 
        img.setColor(Color.black);
        img.drawImage(icon, 2, 2);
        img.drawString(" "+carNum + "    " + score,4+icon.getWidth(), 2*icon.getHeight()/3);
    }

    // no act method - this actor does not need to be "doing" anything. Feel free to add such
    // method if you see the need to do so. 
}
