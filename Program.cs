using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FirebaseAdmin.Messaging;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;


FirebaseApp.Create(new AppOptions()
{
    Credential = GoogleCredential.FromFile(@""),
});

// This registration token comes from the client FCM SDKs.
var registrationToken = "";

// See documentation on defining a message payload.
var message = new Message()
{
    Data = new Dictionary<string, string>()
    {
        { "score", "850" },
        { "time", "2:45" },
    },
    Token = registrationToken,
    Notification = new Notification(){
        Title = "Nuevo titulo",
        Body = "El Pepe",
        ImageUrl = "http://images3.memedroid.com/images/UPLOADED101/5f71f5cf73c53.jpeg"
    }
};

// Send a message to the device corresponding to the provided
// registration token.
string response = await FirebaseMessaging.DefaultInstance.SendAsync(message);
// Response is a message ID string.
Console.WriteLine("Successfully sent message: " + response);