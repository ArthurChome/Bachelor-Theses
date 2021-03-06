import java.io.BufferedReader;

import java.util.Timer;
import java.util.TimerTask;
import java.io.DataInputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.OutputStream;
import java.io.Reader;
import java.net.Socket;
import java.net.UnknownHostException;
import java.nio.charset.Charset;

import javax.sound.sampled.AudioFormat.Encoding;

/** This class represents the TCP client who will communicate with the server (Unity & HoloLens) */
public class Client {
	
	/** Portnumber the client will be polling (listening) */
	private static int desktop_port = 4002;
	private static int hololens_port = 80;
	/** IP addresses that we will be using: one for the Desktop and the HoloLens */
	private static String IP_Address_Desktop = "192.168.0.101";
	private static String IP_Address_HoloLens = "192.168.0.100";
	
	/** IP address & Port number in use. */
	private static int port = desktop_port; 
	private static String current_IP = IP_Address_Desktop;
	
	/** Socket for sending information to the server. */
	private static Socket socket;
	
	/** Streams that we can use to send & receive data from the server. */
	static InputStream inputServer;
	static DataInputStream in;
	
	/** Instantiate the Mindstorms motor management class. */
	static MotorOps motors = new MotorOps();
	
	/** Setup a timer to implement the death clock. */
	static Timer timer = new Timer();
	
	/** Variables that indicate if the client's still trying to connect with the server
	 *  and whether we already placed the notification that the client is connected. */
	public static boolean tryConnection = true;
	public static boolean connectNotificationSend = false;
	
	/** Number of attempts to connect with the server. */
	public static int noOfTries = 10;
	
	/** Deathclock: will stop the client program after given number of seconds. */
	public static void deathClock(int seconds){
		/** Schedule to end the program in given amount of seconds.
		 *  We will exit the program execution after given time. */
		timer.schedule(new TimerTask() {
			  public void run() { 
				  System.exit(0);
				  } 
			  }, seconds*1000);}
	
	public static void readBytes(){

	    try {
	        inputServer = socket.getInputStream();
	        in = new DataInputStream(inputServer);
	        byte[] buffer = new byte[4];
	        int read = 0;
	        
	        /** If something is received, read it and interpret it. */
	        while ((read = in.read(buffer, 0, buffer.length)) != -1) {
	            /** What message did we receive from the server? */
	        	String message = new String(buffer, "UTF-8");
	            motors.screenMessage("Server says: " + message);
	            /** Interpret the number message. */
	            interpretMessage(message);
	        }	        
	        
	    } catch (IOException ex) {
	        ex.printStackTrace();
	    }
	}
	
	/** This function will interpretate the response of the server */
	public static void interpretMessage(String response){
		/** The messages are one character long, are received in a stream and have different meanings: 
		 *  - 1: continue forward.
		 *  - 2: continue backward.
		 *  - 3: continue to the left.
		 *  - 4: continue to the right.
		 *  - N: N(o instructions).
		 * */
		if (response.startsWith("1")){
			motors.continueForward();
		}
		else if (response.startsWith("2")){
			motors.continueBackward();
		}
		else if(response.startsWith("3")){
			motors.continueLeft();
		}
		else if(response.startsWith("4")){
			motors.continueRight();
		}
		else if(response.startsWith("N")){
			motors.screenMessage("No instructions. Stand-by.");
			motors.stopAll();
			
		}
		else {
			motors.screenMessage("Not recognized: " + response);
			System.out.println("not recognized: " + response);
		}
	}


	public static void main(String[] args)
	{
		/** Notification that the client was started */
		motors.screenMessage("Client started. ");

		/** Set a death clock for the client: he will die in 60 seconds. */
		deathClock(600);
		
		/** Try connecting a couple of times with the server. */
		while (tryConnection){
			try
			{	/** Insert the public IP address of the server and the port he is listening to. */
				socket = new Socket(current_IP, port);
				
				/** Send a notification that the socket is connected. */
				if (socket.isConnected()){
					motors.screenMessage("Client connected. ");
					connectNotificationSend = true;
				}
				
				/** Read the bytes the server put on the stream. */
				readBytes();
			}
			catch(Exception e){
				noOfTries = noOfTries - 1;
				if (noOfTries == 0){
					tryConnection = false;
					/** After a number of tries, print that the client just could not connect. */
					motors.screenMessage("could not: " + e.toString());
					/** Stop everything in 5 seconds */
					deathClock(5);
				}
			}
		}
	}
}
