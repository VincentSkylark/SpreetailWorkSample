# SpreetailWorkSample

## Overview
This is an interactive console application written in C# as part of Spreetail's work sample interview. It is a command-line application designed to store a multi-value dictionary in memory. In this application, both keys and members are strings.

## Installation and Setup

To build and deploy the application, you need to have the .NET Core SDK installed on your machine. You can download the SDK from the official .NET website [here](https://dotnet.microsoft.com/download).


### Steps to Build and Run the Application:

build command:
```
dotnet build
```

run command:
```
dotnet run --project SpreetailWorkSample
```

**A prebuilt executable for x64 has been published and included in the `publish` directory.**

## Feature

| Command      | Description                                                            | Example              | Expected Output |
| ------------ | ---------------------------------------------------------------------- | -------------------- | --------------- |
| ADD          | Adds a member to a collection for a given key.                         | ADD foo bar          | Added           |
| ALLMEMBERS   | Returns the collection of strings for the given key.                   | ALLMEMBERS           | bar             |
| CLEAR        | Removes all keys and members from the dictionary.                      | CLEAR                | Cleared         |
| ITEMS        | Returns all keys in the dictionary and all of their members.           | ITEMS                | foo: bar        |
| KEYEXISTS    | Returns whether a key exists or not.                                   | KEYEXISTS foo        | true            |
| KEYS         | Returns all the keys in the dictionary.                                | KEYS                 | foo             |
| MEMBEREXISTS | Returns whether a member exists within a key.                          | MEMBEREXISTS foo bar | true            |
| MEMBERS      | Returns the collection of members in a key.                            | MEMBERS foo          | bar             |
| REMOVEALL    | Removes all members for a key and removes the key from the dictionary. | REMOVEALL foo        | Removed         |
| REMOVE       | Removes a member from a key.                                           | REMOVE foo bar       | Removed         |