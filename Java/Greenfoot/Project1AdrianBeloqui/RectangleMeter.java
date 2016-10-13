import greenfoot.*;   // get all Greenfoot package class info.
import java.awt.Color;// We're goig to want to color to get this done ...

/**
 * RectangleMeter is a class that gives the user the ability to increase or decrease a percent 
 *   filled inside of a Rectangle. This accomplished by pressing the left arrow (to decrease) 
 *   or a right arrow (to increase). 
 *  
 *   Although you are welcome to modify this code, doing so is HIGHLY inadvisable. If you 
 *   feel the need to do so, you are likely making this MUCH harder than it should be. 
 * 
 * @author Stephen Blythe
 * @version July, 2015
 */
public class RectangleMeter extends Actor
{
    private int currVal; // how many pixels full the rectangle is right now
    private int length;  // how many pixels wide the entire rectangle is right now. 
    
    /**
     * RectangleMeter constructs a (horizontal) RectangleMeter that is the specified width and 
     * 20 pixels high
     * 
     * @param length the width of the rectangle meter
     * 
     * 
     */
    public RectangleMeter(int length)
    {   
        currVal=0;            // by default, we have not yet "upped" the meter
        this.length=length;   // remember the meter's max heigth. 
        
        // create and fill this meter's representative image. 
        setImage(new GreenfootImage(length,20));
        redraw();
    }
    
    /*
     * redraw:
     * 
     *   based on how full the meter is suposed to be, redraw it
     */
    private void redraw()
    {
        GreenfootImage img = getImage(); // get the image to redraw

        // draw "background" (neutral) by filling with blue.  
        img.setColor(Color.blue);
        img.fill();
        
        // draw red outline around meter
        img.setColor(Color.red);
        img.drawRect(0,0,length-1,19);
        
        // finally, add in the part that as been "upped" 
        img.setColor(Color.orange);
        img.fillRect(1,1,currVal-2,18);      
    }
    
    /**
     * getFilledRatio returns the percent fullness of the meter
     * 
     * @return the percentage filled (as a ratio, always positive and no more than 1)
     */
    public double getFilledRatio() {return currVal/(double)length;}

    
    /**
     * act increases or decreases based on user interaction
     */
    public void act() 
    {
        // If user pressed right arrow and there's enough room to grow
        if (Greenfoot.isKeyDown("Right") && currVal<length)
        {
            currVal++; // incremenet how full we are 
            redraw();  // redraw to reflect this change
        }
        // if the user pressed left and we still have room to go down
        else if (Greenfoot.isKeyDown("Left") && currVal>0)
        {
            currVal--; // decrement how full we are
            redraw();  // redraw to reflect this change
        }
    } 
    
    
 
}
