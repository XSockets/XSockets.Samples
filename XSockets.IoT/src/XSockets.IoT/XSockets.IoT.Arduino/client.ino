//Stupid Arduino sample that send a message to a webpage...
//TODO: Create a better client that can receive messages as well...
#include <SPI.h>
#include <Ethernet.h>

byte mac[] = { 0xDE, 0xAD, 0xBE, 0xEF, 0xFE, 0xED };
IPAddress server(192,168,1,2);
int port = 4502;
EthernetClient client;

 void setup() 
 { 
   // initialize the LED pin as an output:
   pinMode(ledPin, OUTPUT);      
   // initialize the pushbutton pin as an input:
   pinMode(buttonPin, INPUT);  

   Serial.begin(9600);
  
   Serial.println("Starting ethernet");
   
   if (Ethernet.begin(mac) == 0) {
    Serial.println("Failed to configure Ethernet using DHCP");
   }

   // give the Ethernet shield a second to initialize:
   delay(1000);
   Serial.println("connecting...");
   Serial.println(Ethernet.localIP());
   // if you get a connection, report back via serial:
   if (client.connect(server, port)) {
    delay(300);  
    Serial.println("connected, doing handshake");
    client.println("JsonProtocol");
    delay(500);  
    client.print("{\"C\": \"iot\", \"T\": \"set_clienttype\", \"D\": \"\\\"Arduino\\\"\"}");
   } 
   else {
    // if you didn't get a connection to the server:
    Serial.println("connection failed");
   } 
 }
 
 void loop() 
 { 
   delay(1000); 

   char outBuf[80];   
   sprintf(outBuf,"{\"C\": \"iot\", \"T\": \"chatmessage\", \"D\": \"{\\\"text\\\":\\\"%s\\\"}\"}","Hello from Arduino");
   Serial.println(outBuf);
   client.write(outBuf);               
   delay(500);
 } 
