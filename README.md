Prototype 1 Documentation: LAN Chat Application

Overview
This 1st prototype serves as the foundational build for the LAN Chat Application. The goal of this phase was to establish a functional, real-time desktop messaging system that operates entirely within a LAN. We successfully implemented a client-server architecture using the .NET Framework, specifically VB.NET. 
This prototype completes four major phases: building the UI, establishing network connections, broadcasting messages, and logging data locally.

Phase 1: Basic UI (Login Form and Chat Window)
The user interface for this application was developed using Windows Forms (WinForms). WinForms provides a graphical interface for users to interact with the underlying code.

The project was split into two separate applications to represent the two sides of the network:
-	The Server UI (LanChatServer): A simple control panel with a “Start Server” button and a RichTextBox to display live network activity logs.
-	The Client UI (LanChatClient): Comprises two screens:
o	Login Form: Where the user enters their username and the server’s IP address (using 127.0.0.1 for local testing) before clicking “Connect”.
o	Chat Form: The main interface containing a RichTextBox for viewing the broadcasted chat history, a TextBox for typing new messages, and a “Send” button.

Phase 2: Simple Connection (Sockets and OOP)
To allow devices to communicate over the LAN, we utilised VB.NET Socket Programming. Sockets act like a dedicated telephone line between two computers.

Key Concepts used:
-	TcpListener (Server): This acts as a receptionist. It sits on a specific network port (we used port 8888) and waits for incoming connection requests from clients.
-	TcpClient (Client): This is the caller. It dials the server’s IP address and port to establish the connection.
-	NetworkStream: Once a connection is made, this is the pipeline through which data (text converted into bytes) flows back and forth.



Object-Oriented Programming (OOP):
Instead of clustering our code inside the UI buttons, we used proper OOP principles by creating Classes (blueprints as objects). This keeps the code scalable and clean.
-	ServerManager.vb: A class that handles all server-side socket logic, accepting clients, and triggering events to update the UI.
-	ClientConnection.vb: A class that stores the individual user’s username and socket and contains the methods to connect and send messages.

Phase 3: Basic Broadcasting (Multithreading)
Broadcasting means taking one user’s message and instantly delivering it to all connected participants. To achieve this without the application crashing or freezing, we implemented Multithreading using the .NET Thread Class.
How it works in the application: By default, the application runs on a single “Main Thread” (which handles the UI). If the Main Thread waits for network messages, the entire app freezes.
1.	Server Acceptance Thread: The server uses a background thread to wait for new people to log in.
2.	Dedicated Client Threads: When a new user connects, the server creates a brand-new background thread exclusively dedicated to listening to that specific user. This means multiple users can send messages simultaneously without causing delays.
3.	Client Listening Thread: The client also has a background thread constantly listening to incoming broadcasts from the server.

The Broadcasting Loop:
When the server’s background thread receives a message from a client, it loops through a List(Of TcpClient) (a roster of all currently connected clients) and pushes that message down the pipeline to every client on the list.

Phase 4: Temporary Storage (Text File Logging)
To ensure conversations aren't lost when the app closes, we built a basic message history log. For this initial prototype, we used Text Files for local storage.

How it works:
-	System.IO Namespace: We utilised .NET’s built-in input/output tools to interact with the computer’s file system.
-	File.AppendAllText: This command is highly efficient. It opens the text file, adds the newest message to the very bottom, and closes the file. If the file (ChatHistoryLog.txt) does not exist yet, it automatically creates it.
-	Timestamps: Before saving, the code attaches a real timestamp using DateTime.Now.ToString(“yyyy-MM-dd HH:mm:ss”) so users can track exactly when a message is sent. Since storage is local, this currently carries a risk of data loss if the server machine fails, which is an accepted limitation of this prototype.

Summary for Presentation
We built the core engine of our LAN Chat App. We used WinForms for the interface, Socket Programming to connect computers over the network, and Multithreading to allow the server to handle multiple users talking at the same time without freezing. Finally, we set up an automated Text File Log on the server to save our chat history. 
