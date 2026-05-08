Prototype 2 documentation: LAN Chat Application

Prototype 1 vs. Prototype 2
To achieve the features of Prototype 2, several core mechanics from Prototype 1 had to be rewritten or entirely replaced. Imma do a breakdown of the architecture:

1.	Data Storage: Text Files -> SQL Server
•	The Problem in P1: We were storing the messages locally in the file (ChatHistoryLog.text). This is fine for temporary storage, but it is impossible to easily search, filter, or tie messages to specific user accounts.
•	The Upgrade we made in P2: Introduced a relational database using Microsoft SQL Server.
•	How we changed it: We created a dedicated DatabaseManager.vb class.
 o	By deleting the System.io text file logic and the server allowed us to replace it with parameterised SQL INSERT commands (SaveMessageToDatabase) that safely store data in a Message table.

2.	Client Management: The “Anonymous List” -> The “Smart Dictionary”
•	The problem in P1: The server kept track of users using a basic List (Of TcpClient). It just knew how many computers were connected, but it didn’t know who they were. This made private messaging impossible.
•	The upgrade in P2: Upgrading the storage collection to a Dictionary (Of String, TcpClient).
•	How we changed it: The dictionary acts as a look-up table. The String Key is the user’s authenticated Username, and the TcpClient Value is their live network socket.
 o	When I send a private message to “Kagiso”, the server looks up “Kagiso” in the Dictionary and sends the data exclusively down his specific socket line.

3.	Connection Logic: “Open Door” -> The “Security Bouncer”
•	The problem in P1: As soon as TcpClient connected to the server port, they were immediately added to the chat list and could start receiving broadcasts.
•	The upgrade in P2: Added a mandatory Authentication Handshake.
•	How we changed it: Added a “waiting room” phase to the Server’s background thread. When a client connects, they are not added to the Dictionary.
 o	The server waits for a secret text string (e.g., LOGIN|Username|Password). It queries the Users table in the database to verify the credentials. Only if the database returns True does the server reply with AUTH_SUCCESS and formally add them to the chat room.

4.	Message Format: Raw Text -> “Shipping Labels”
•	The problem in P1: The client just sent the raw text (e.g., Hello). The server assumed every message was public and blindly pushed it to everyone.
•	The upgrade in P2: We instituted a strict Message Protocol so the server knows exactly how to handle incoming data.
•	How we changed it: We added a “To:” dropdown Menu (ComboBox)
 o	The Client can now prepend every message with a target (e.g., ALL|Hello or Kagiso|Hello).
 o	The server uses the .Split() function to read the first part of the string. If it says ALL, it triggers the broadcast loop. If it says a specific name, it triggers the private routing method. If it says SERVER|GET_HISTORY, it pulls the database log and sends it directly back.

