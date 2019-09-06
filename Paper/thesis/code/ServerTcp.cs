using System;
using System.Text;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using System.Net;

/* Websites referenced:
 -https://www.tutorialspoint.com/windows10_development/windows10_development_networking.htm
 -https://foxypanda.me/tcp-client-in-a-uwp-unity-app-on-hololens/
 -https://stackoverflow.com/questions/34428173/unable-to-access-tcp-server-inside-a-windows-universal-application
 -http://www.mikeadev.net/2012/07/multi-threaded-tcp-server-in-csharp/
 -https://csharp.hotexamples.com/examples/Windows.Networking.Sockets/StreamSocketListenerConnectionReceivedEventArgs/-/php-streamsocketlistenerconnectionreceivedeventargs-class-examples.html
 -https://stackoverflow.com/questions/10341779/how-to-get-the-stream-from-streamsocket

 Note: this improvement has a full separation of UWP and Unity libraries
 
 */

#if UNITY_EDITOR
using UnityEditor;
using System.Net.Sockets;
using System.IO;

//Make the server work
public class ServerTcp : MonoBehaviour
{

    private String currentInstruction = "N";

    public Text NotificationsText;
    public String notification = "Standby..";

    /* Is the server (TCP listener) currently running? */
    public Boolean is_running = false;

    /* Following list keeps track of all connected clients.
     * Used for client management such as individual communicati
     * on, termination etc. */
    List<TcpClient> connectedClients = new List<TcpClient>();

    /* Our counter in the list of TCP clients. 
     * Handy for when we would like to change clients. */
    int clientCounter = 0;

    /* This boolean specifies whether we're sending the same instruction to all clients. */
    Boolean toAllClients = true;

    /* The 3D object's mesh reference to which the script is attached. */
    TextMesh textMesh;



    private System.Net.Sockets.TcpClient connectedTcpClient;

    /* The stream of the client: the server's input and its output channel. */
    System.Net.Sockets.NetworkStream stream;

    /* TCPListener to listen for incomming TCP connection & requests */
    private System.Net.Sockets.TcpListener tcpListener;

    /* Addresses we're using (desktop & HoloLens respectively) 
       I believe "any" just takes the IP address of the current device the code is running on.
       This is much more flexible than hardcoding a specific IP address. */
    private static System.Net.IPAddress IP_Address_Desktop = System.Net.IPAddress.Any; //YOU ARE SETTING ADDRESS FOR HOLOLENS IN UNITY EDITOR
    private static System.Net.IPAddress IP_Address_HoloLens = System.Net.IPAddress.Any;
    /* Current address we're using: probably redundant for the HoloLens. */
    private System.Net.IPAddress current_IP = IP_Address_Desktop;

    /* Boolean to indicate whether we're using the Universal Windows Platform. */
    private bool _useUWP = false;
    private Thread tcpListenerThread;


    /* This procedure gets called for initialisation. */
    void Start()
    {
        /* Setup the desktop computer's connection. */
        setupConnectionDesktop();
        /* Get the reference of the 3D object */
        textMesh = GetComponent<TextMesh>();  
        /* To show that changing notifications works */
        printNotification("server started!");
        /* We're using the desktop server so make the manual for the HoloLens server disappear. */
        GameObject.Find("HoloLensManual").SetActive(false);
    }

    /* This function will get started by a new client-specific thread to handle its communication */
    public void handleClient(object obj)
    {
        // retrieve client from parameter passed to thread
        TcpClient client = (TcpClient)obj;
        System.Net.Sockets.NetworkStream currentStream = client.GetStream();

        /* If we have to send the same instruction to all clients, we order all client handlers to do so. */

        while (true)
        {
            if (toAllClients)
            {
                byte[] bytesToSend = Encoding.UTF8.GetBytes(currentInstruction);
                currentInstruction = "N";
                currentStream.Write(bytesToSend, 0, bytesToSend.Length);
                /* Since we're writing something, flush() must be used. */
                currentStream.Flush();
                Debug.Log("answer was sent: " + currentInstruction);  
            }
            System.Threading.Thread.Sleep(1000);
        }   

    }

    /* This function prints a new message on the three-dimensional
     * text mesh that the server manages. */
    void printNotification(string msg)
    {
        string newNotification = "Notification: " + msg;
        textMesh.text = newNotification;
    }


    /* Start the exchange of data for the desktop */
    void setupConnectionDesktop()
    {
        /* Start a new thread for the server. 
         * Every new client shall receive*/
        tcpListenerThread = new Thread(new ThreadStart(ListenClients));
        /* Put the thread in background. */
        tcpListenerThread.IsBackground = true;
        /* Start the listener thread */
        tcpListenerThread.Start();
    }

    /* Start the exchange of data with the HoloLens */

    void setupConnectionUWP()
    {
        Debug.LogError("Tried to execute the Unity editor code with UWP.");
    }

    /* Update is called once per frame
     * This procedure will read the input of the keyboard to see what the client must do. */
    void Update()
    {

        /* Depending on whether we're using the desktop or the HoloLens, 
         * we must look for different types of input (keyboard or gaze). */
        readKeyboardInput();

        /* If it was selected by the user to send instructions to one specific client, 
         * Then this ought to be done. */
        sendToCurrentClient();



    }


    /* Following procedures changes the current instruction for the client to a new instruction. */
    public void goForward()
    {
        Debug.Log("Up arrow. Mindstorms will go forward. ");
        currentInstruction = "1";
        textMesh.text = "Client goes forward";
        return;
    }

    public void goBackward()
    {
        currentInstruction = "2";
        textMesh.text = "Client goes backward";
        return;
    }

    public void goLeft()
    {
        currentInstruction = "3";
        textMesh.text = "Client goes left";
        return;
    }

    public void goRight()
    {
        currentInstruction = "4";
        textMesh.text = "Client goes right";
        return;
    }

    public void clientStop()
    {
        currentInstruction = "N";
        textMesh.text = "Client stop";
        return;
    }

    public void sendToCurrentClient()
    {
        int noClients = connectedClients.Count();

        /* Send out the current instruction only to the selected current client. */
        if (!toAllClients && noClients > 0)
        {
            connectedTcpClient = connectedClients[clientCounter];
            byte[] bytesToSend = Encoding.UTF8.GetBytes(currentInstruction);
            currentInstruction = "N";

            connectedTcpClient.GetStream().Write(bytesToSend, 0, bytesToSend.Length);
            /* Since we're writing something, flush() must be used. */
            connectedTcpClient.GetStream().Flush();
            Debug.Log("answer was sent: " + currentInstruction);
            System.Threading.Thread.Sleep(1000);
        }
    }

    /* Change current client */
    public void changeCurrentClient()
    {
        /* Number of connected TCP clients to the server. */
        int noClients = connectedClients.Count();

        /* Cannot change current client if you have NO clients. */
        if(noClients == 0)
        {
            Debug.Log("Pressed C: No clients connected.");
            return;

        }
        /* You cannot change the current client if you only have one client. */
        else if(noClients == 1)
        {
            Debug.Log("Pressed C: Only one client connected: cannot change current client.");
        }
        /* If we're at the end of our connected clients list, start over at the beginning. */
        //else if(clientCounter == noClients - 1)
        //{
        //    clientCounter = 0;
        //    connectedTcpClient = connectedClients[0];
        //    Debug.Log("Pressed C: client changed.");

        //}
        /* Change the client and raise the counter. */
        //else
        //{
            
            Debug.Log("Pressed C: client changed.");
            clientCounter += 1;
            clientCounter = clientCounter % connectedClients.Count();
            connectedTcpClient = connectedClients[clientCounter];
     
        //}
    }

    /* Change the current instruction for the current client. */    
    public void changeInstruction(string newInstruction)
    {
        currentInstruction = newInstruction;
        return;
    }



    /* For when the desktop acts as server, we must scan/read the keyboard to give directions to the robot. 
     * Only relevant when using the UNITY editor so it gets ignored when not using it (HoloLens). */
    private void readKeyboardInput()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Debug.Log("Up arrow. Mindstorms will go forward. ");
            currentInstruction = "1";
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            Debug.Log("Up arrow. Mindstorms will go backward. ");
            currentInstruction = "2";
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            Debug.Log("Up arrow. Mindstorms will go left. ");
            currentInstruction = "3";
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            Debug.Log("Up arrow. Mindstorms will go right. ");
            currentInstruction = "4";
        }
        else if (Input.GetKey(KeyCode.C))
        {
            Debug.Log("C button: change current client. ");
            changeCurrentClient();
        }
        /* By pressing A, you enable the sending of the current instruction to all clients. */
        else if (Input.GetKey(KeyCode.A))
        {
             toAllClients = true;
             Debug.Log("A button: will send instructions to all. ");
        }
        /* By pressing Z, you disable the sending of the current instruction to all clients. */
        else if (Input.GetKey(KeyCode.Z))
        {
            toAllClients = false;
            Debug.Log("Z button: will send instructions to one client. ");
         }
        /* Elstak: no keys pressed: send the client that he may stay idle. */
        else
        {
          
        }
    }

    /* This procedure puts a message on the current client stream. */
    private void sendClient(String message)
    {

        byte[] bytesToSend = Encoding.UTF8.GetBytes(message);
        stream.Write(bytesToSend, 0, bytesToSend.Length);
        /* Since we're writing something, flush() must be used. */
        stream.Flush();
        Debug.Log("answer was sent: " + message);
    }

    /* This procedure puts a message on the current client stream. */
    private void sendClientStream(NetworkStream clientStream, String message)
    {

        byte[] bytesToSend = Encoding.UTF8.GetBytes(message);
        clientStream.Write(bytesToSend, 0, bytesToSend.Length);
        /* Since we're writing something, flush() must be used. */
        clientStream.Flush();
        Debug.Log("answer was sent: " + message);
    }


    private void ListenRequests()
    {
        // Create listener on localhost port 4002, the server will listen on that port.
        Int32 port = 4002;
        //Ignore IP Address 
        System.Net.IPAddress localAddr = current_IP;

        try
        {

            tcpListener = new System.Net.Sockets.TcpListener(localAddr, port);
            tcpListener.Start();
            Debug.Log("Server is listening");
            Byte[] bytes = new Byte[1024];

            /* REFORMAT THIS */
            while (true)
            {
                using (connectedTcpClient = tcpListener.AcceptTcpClient())
                {
                    // Get a stream object for reading 					
                    using (stream = connectedTcpClient.GetStream())
                    {
                        int length;
                        // Read incoming stream of data, if there is data.					
                        while ((length = stream.Read(bytes, 0, bytes.Length)) != 0)
                        {
                            //Debugger
                            Debug.Log("Listening for incoming requests");

                            //Read the data that was sent.
                            var data = new byte[length];
                            Array.Copy(bytes, 0, data, 0, length);
                            // Convert byte array to string message. 							
                            string clientMessage = Encoding.ASCII.GetString(data);
                            Debug.Log("clientMessage: " + clientMessage);

                            //Write an answer to the client: it's the current instruction.
                            string response = currentInstruction;
                            sendClient(response);
                            //var e = "hllo";
                            //e.ToString;

                        }

                    }

                }
            }

        }


        catch (System.Net.Sockets.SocketException socketException)
        {
            Debug.Log("SocketException " + socketException.ToString());
        }
    }

    /* This function listens in a loop on port no*/
    private void ListenClients()
    {
        // Create listener on localhost port 4002, the server will listen on that port.
        Int32 port = 4002;
        //Ignore IP Address 
        System.Net.IPAddress localAddr = current_IP;

        try
        {

            tcpListener = new System.Net.Sockets.TcpListener(localAddr, port);
            tcpListener.Start();
            Debug.Log("Server is listening");
            Byte[] bytes = new Byte[1024];
            is_running = true;

            /* While running, wait for incoming clients. */
            while (is_running)
            {
                /* Wait for a client to connect. */
                TcpClient newClient = tcpListener.AcceptTcpClient();

                Debug.Log("New Tcp client connected.");
                // client found.
                // create a thread to handle communication
                Thread t = new Thread(new ParameterizedThreadStart(handleClient));
                t.Start(newClient);

                //Add the new client to our list to keep track of it.
                connectedClients.Add(newClient);
            }

        }


        catch (System.Net.Sockets.SocketException socketException)
        {
            Debug.Log("SocketException " + socketException.ToString());
        }
    }

    /* Is the client not connected? */
    private void clientConnected()
    {
        if (connectedTcpClient == null)
        {
            Debug.Log("Tcp client not connected.");
            notification = "Tcp client not connected.";

        }
        else
        {
            notification = "Tcp client connected.";
        }
        return;


    }

}
#endif

/* The HoloLens uses tasks and no threads. */
#if !UNITY_EDITOR
using System.Threading.Tasks;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Security.Cryptography;
using System.IO;
using Windows.Networking;


public class ServerTcp : MonoBehaviour
{

    /* For this version of the UWP server, it just has to send one continuous byte stream 
     * to the socket of the client with only one instruction. */
    private String currentInstruction = "1";

    public Text NotificationsText;
    public String notification = "Standby..";

    /* Field for the stream socket to be used by the server for client communication. */
    private Windows.Networking.Sockets.StreamSocket socket;

    /* A listener for inbound client connection requests. */
    private System.Threading.Tasks.Task tcpListenerTask;

    //Get a reference to our 3D text object.
    TextMesh textMesh;

    public void restartExchange(){
        Task.Run(() => ListenClients());
    }


    public async Task MyCallingMethod()
    {    

       /* Create a StreamSocketListener to start listening for TCP connections. */
       Windows.Networking.Sockets.StreamSocketListener socketListener = new Windows.Networking.Sockets.StreamSocketListener();
            
       /*Start listening for incoming TCP connections on the specified port. You can specify any port that' s not currently in use. */
       await socketListener.BindServiceNameAsync("80");
       
       /* Hook up an event handler to call when connections are received. */
       socketListener.ConnectionReceived += OnConnectionReceived;
    }

    /* This procedure gets called for initialisation. */
    void Start()
    {
        /* Setup the connection with the HoloLens server. */
        setupConnectionUWP(); 
        MyCallingMethod();
        textMesh = GetComponent<TextMesh>();

        /* Test */
        ListenClients();

        /* Print a notification that the server initialized. */
        printNotification("Server started!");
        
        /* We're using the desktop server so make the manual for the HoloLens server disappear. */
        GameObject.Find("HoloLensDesktop").SetActive(false);

    }




    /* Start the exchange of data for the desktop */
    void setupConnectionDesktop()
    {
        return;
    }


    async void setupConnectionUWP()
    {
        tcpListenerTask = Task.Run(() => ListenClients());

    }


    /* Procedure to connect to a socket. */
    //  private void ConnectTo(string ipAdd)
    //{
    //    Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    //   SocketAsyncEventArgs e = new SocketAsyncEventArgs();
    //    e.RemoteEndPoint = new IPEndPoint(IPAddress.Parse(ipAdd), 9990);
    //    e.UserToken = s;
    //    e.Completed += new EventHandler<SocketAsyncEventArgs>(e_Completed);
    //    list.Add(e);      // Add to a list so we dispose all the sockets when the timer ticks.
    //    s.ConnectAsync(e);
    //}


    /* 
     * Update is called once per frame
     * This procedure will read the input of the keyboard to see what the client must do. 
     */
    void Update()
    {

    }

    /* Following procedures are used to change the notifications 3D text */
    void clientConnection(){

        textMesh.text = "New client connection established.";
    }
    void printNotification(string msg)
    {
        string newNotification = "Notification: " + msg;
        textMesh.text = newNotification;
    }


    /* Change current client */
    public void changeCurrentClient()
    {
       textMesh.text = "No next client";
    }


    /* Following procedures changes the current instruction for the client to a new instruction. */
    public void goForward()
    {
        Debug.Log("Up arrow. Mindstorms will go forward. ");
        currentInstruction = "1";
        textMesh.text = "Client goes forward";
        return;
    }

    public void goBackward()
    {
        currentInstruction = "2";
         textMesh.text = "Client goes backward";
        return;
    }

    public void goLeft()
    {
        currentInstruction = "3";
        textMesh.text = "Client goes left";
        return;
    }

    public void goRight()
    {
        currentInstruction = "4";
        textMesh.text = "Client goes right";
        return;
    }

    public void clientStop()
    {
        currentInstruction = "N";
        textMesh.text = "Client stop";
        return;
    }



    /* This procedure puts a message on the current client stream. */
    private void sendClient(String message)
    {
        return;
    }

    /* 
     * Hook up an event handler for when connections are received. 
     * We can use it to change the notifications panel to indicate that the client was connected. 
    
     * This procedure gets called for every new client connection with the TCP listener. */
       
    public async void OnConnectionReceived(Windows.Networking.Sockets.StreamSocketListener s, Windows.Networking.Sockets.StreamSocketListenerConnectionReceivedEventArgs args){

        /* Show that we have a new client. */
        printNotification("New client Connection");

         while (true)
           {
                 Windows.Networking.Sockets.StreamSocket sender = args.Socket;
                 sender.Control.KeepAlive = false;
                 HostName host = new HostName("localhost");

                 try
                 {
                   await sender.ConnectAsync(host, "80");
                   /* We don't care what the client writes to us. */
                   //System.IO.Stream streamOut = sender.OutputStream.AsStreamForWrite();

                   /* Let's use an Ibuffer */
                   Windows.Storage.Streams.IBuffer buffer = CryptographicBuffer.ConvertStringToBinary("1", BinaryStringEncoding.Utf8);
                   sender.OutputStream.WriteAsync(buffer);
                   sender.OutputStream.FlushAsync();
                    
                  /* Send the line back to the remote client. */
                  Stream outStream = args.Socket.OutputStream.AsStreamForWrite();
                  StreamWriter writer = new StreamWriter(outStream);
                  await writer.WriteLineAsync("1"); //Just send something
                  await writer.FlushAsync();
                  printNotification("send out message.");

                 }
                 catch (Exception)
                 {
                     // Quietly consume the exception
                 }
                /* Close the client socket a.k.a the sender of potential packets. */
                 sender.Dispose();
                 
             };
        
 

        }



    /* Runs in background TcpServerThread; Handles incomming TcpClient requests */

    private async void ListenClients()
    {
        String port = "80"; //We cannot connect to IP address 4002, let's just try 80

        try
        {
            /* Create a StreamSocketListener to start listening for TCP connections. */
            Windows.Networking.Sockets.StreamSocketListener socketListener = new Windows.Networking.Sockets.StreamSocketListener();
            
            /*Start listening for incoming TCP connections on the specified port. You can specify any port that' s not currently in use. */
            await socketListener.BindServiceNameAsync("80");
            
       
            /* Hook up an event handler to call when connections are received. */
            socketListener.ConnectionReceived += OnConnectionReceived;
            printNotification("Server is listening...");
    
    
       }
        catch (Exception err)
        {        }
    
    }

    /* Is the client not connected? */
    private void clientConnected()
    {

    }

}
#endif
