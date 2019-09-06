import lejos.hardware.BrickFinder;

/** To access the Ev3 Block's screen. */
import lejos.hardware.lcd.GraphicsLCD;
import lejos.utility.Delay;
import lejos.robotics.RegulatedMotor;
import lejos.hardware.Device;
import lejos.hardware.motor.BaseRegulatedMotor;
import lejos.hardware.motor.EV3LargeRegulatedMotor;
import lejos.hardware.port.MotorPort;

/** This class provides us control over the motors of the EV3 Mindstorms robot. */
public class MotorOps {
	
	/** Get the EV3 brick's screen. */
	static GraphicsLCD g = BrickFinder.getDefault().getGraphicsLCD();
	
	/** 
	 * Concreticize the motors A, B, C and D of the Lego robot.
	 * We built a Lego robot with two claws and 2 tires on its feet.
	 * On the brick, following ports have following motors:
	 * 	A = Right-arm	B = Left-tire	C = Right-tire	D = Left-arm  */
	static BaseRegulatedMotor motorA = new EV3LargeRegulatedMotor(MotorPort.A);
	static BaseRegulatedMotor motorB = new EV3LargeRegulatedMotor(MotorPort.B);
	static BaseRegulatedMotor motorC = new EV3LargeRegulatedMotor(MotorPort.C);
	static BaseRegulatedMotor motorD = new EV3LargeRegulatedMotor(MotorPort.D);
	
	/** Draw a message on the EV3 brick's screen. */
	public static void screenMessage(String msg){
		/** Clear the screen then write the message */
		g.clear();
		g.drawString(msg, 0, 0, GraphicsLCD.VCENTER | GraphicsLCD.LEFT);
	}
	
	
	/** Predefined trajectories (tricks) for the robot to follow. */
	/** Pivot 180 degrees */
	
	public static void pivot180(){
		motorC.forward();
		Delay.msDelay(6000);
	}
	
	/** Pivot 360 degrees */
	public static void pivot360(){
		motorC.forward();
		Delay.msDelay(12000);
		motorC.stop();
	}
	
	
	/** These are the primary methods used to move the robot by the client. */
	public static void continueForward(){
		motorB.forward();
		motorC.forward();
	}
	
	public static void continueBackward(){
		motorB.backward();
		motorC.backward();
	}
	
	public static void continueLeft(){
		motorC.forward();
		/** Stop motor B: it could still be active. */
		motorB.stop();
	}
	
	public static void continueRight(){
		motorB.forward();
		/** Stop motor C: it could still be active. */
		motorC.stop();	
	}
	
	/** Stop all the motors: arms & legs. */
	public static void stopAll(){
		motorA.stop();
		motorB.stop();
		motorC.stop();
		motorD.stop();
	}
	
}