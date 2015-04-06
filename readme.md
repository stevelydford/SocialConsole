# Social Console #

A simple twitter-like social networking console application.

## Running the application ##
To run the application build and run the solution in Visual Studio (Ctrl + F5). You may need to download the NuGet package for NUnit.

##Using the application ##
Users submit commands to the application at the prompt. There are four commands, which always start with the user’s name. New users are created as they post their first message.

###Example commands###
Posting: `<user name> -> <message>` (e.g. Alice -> I love the weather today)

Reading: `<user name>` (e.g. Alice)

Following: `<user name> follows <another user>` (e.g. Alice follows Bob)

Wall: `<user name> wall` (e.g. Alice wall)

To quit the application enter `exit` at the prompt.