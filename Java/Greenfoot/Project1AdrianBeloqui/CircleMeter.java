import greenfoot.*;      // get all Greenfoot package class info.
import java.awt.*;       // We're goig to want to color to get this done ...
import java.awt.geom.*;  // getdome geometric shape classes

/**
 * CircleleMeter is a class that gives the user the ability to increase or decrease a percent 
 *   filled inside of a semi-circle. This accomplished by pressing the left arrow (to decrease) 
 *   or a roght arrow (to increase). 
 *   
 *   Although you are welcome to modify this code, doing so is HIGHLY inadvisable. If you 
 *   feel the need to do so, you are likely making this MUCH harder than it should be. 
 * 
 * @author Stephen Blythe
 * @version July, 2015
 */
public class CircleMeter extends Actor
{
    private int degFull;  // how many (circular) degrees full is this semicircle
    private int radius;   // how big is the radius of the underlying circle?
    private int maxDegree;// how big is the semicircle? 
    
    /**
     * CircleMeter constructs a CircleMeter, oriented from 0 to 90 degrees (first quadrant) of
     * specified radius.
     * 
     * @param radius the radius of the underlying circle
     * 
     */
    public CircleMeter(int radius)
    {   
        degFull=0;          // by default, meter is "empty"
        this.radius=radius; // rmemeber the size of this thing!
        maxDegree=90;       // by default, we a re a 1/4 circle. 
        redraw();           // draw the 1/4 circle
    }
    
    
    /*
     * redraw:
     * 
     *   based on how full the meter is suposed to be, redraw it
     */
    private void redraw()
    {
        // this time, its easiest to just regenerate the underlying image. 
        GreenfootImage img = new GreenfootImage(radius,radius); 

        // the "background" (unfilled part) should be a blue semi-circle
        img.setColor(Color.blue);
        Shape arc = new Arc2D.Float(-radius+1, 0, 2*radius-2, 2*radius-2, 0, maxDegree, Arc2D.PIE);
        img.fillShape(arc);
        
        // the "filled" part should be an orange semi-circle
        img.setColor(Color.orange);
        arc = new Arc2D.Float(-radius+1, 0, 2*radius-2, 2*radius-2, 0, degFull, Arc2D.PIE);
        img.fillShape(arc);      
                
        // add a red border around the meter
        img.setColor(Color.red);
        Shape arcBorder = new Arc2D.Float(-radius+1, 0, 2*radius-2, 2*radius-2, 0, maxDegree, Arc2D.PIE);
        img.drawShape(arcBorder);
        
        setImage(img); // store this as our Object's image. 

    }
    
    /**
     * getAngle returns the internally user selected angle in degrees
     * 
     * @return the value in degrees of the curren fill point
     */
    public double getAngle() {return Math.toRadians(degFull);}
    
    
    /**
     * getArcX returns the selected x location on ege of Actor
     * 
     * @return the x point on the edge of the arc exactly where the filled portion ends.
     */
    public int getArcX()
    {
        return (int) (getX()-getImage().getWidth()/2+Math.cos(Math.toRadians(degFull))*radius);
    }
    
    /**
     * getArcY returns the selected y location on ege of Actor
     * 
     * @return the y point on the edge of the arc exactly where the filled portion ends.
     */
    public int getArcY()
    {
        return (int) (getY()+getImage().getHeight()/2-Math.sin(Math.toRadians(degFull))*radius);
    }
    
    /**
     * act increases or decreases internal angle based on user interaction   
     */
    public void act() 
    {

        // If user pressed up arrow and there's enough room to grow
        if (Greenfoot.isKeyDown("Up") && degFull<maxDegree)
        {
            degFull++; // incremenet how full we are 
            redraw();  // redraw to reflect this change
        }
        // if the user pressed down and we still have room to go down
        else if (Greenfoot.isKeyDown("Down") && degFull>0)
        {
            degFull--;  // decrement how full we are
            redraw();   // redraw to reflect this change
        }
        
    }    
}
