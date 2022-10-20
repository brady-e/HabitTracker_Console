HabitLogger Application
-------------------------
This is one of my first C# applications made in Visual Studios as a part of the C# Academy tutorial system I am doing.

This is a console-based CRUD application to track a specific habit over time. Develped using C# and SQLite.

Given requirements: 
-This is an application where you’ll register one habit.
-This habit can't be tracked by time (ex. hours of sleep), only by quantity (ex. number of water glasses a day)
-The application should store and retrieve data from a real database.
-When the application starts, it should create a sqlite database, if one isn’t present.
-It should also create a table in the database, where the habit will be logged.
-The app should show the user a menu of options.
-The users should be able to insert, delete, update and view their logged habit.
-You should handle all possible errors so that the application never crashes.
-The application should only be terminated when the user inserts 0.
-You can only interact with the database using raw SQL. You can’t use mappers such as Entity Framework.
-Your project needs to contain a Read Me file where you'll explain how your app works.

Features:
-The program uses a SQLite db connection to store and read information. If no db is present, it will create one.
-A console based UI system where the user can navigate by key presses.

CRUD DB functions:
-From the menu the user can create new habit logs by entering the date and the quantity of the habit, read all existing entries 
in the db table, delete specific entries,or delete the entire table.
-Time and date inputs are checked to make sure they are in the correct format.

Challenges:
-This is my first time using SQLite. I had to learn how the Microsoft package works as well as how to format commands to communicate with the database.
-Organization has been an issue. I had a hard time finding the best way to break out the methods of the program and organize them into files/classes.

Areas to Improve:
-Learn the tricks and tips within the text editor of Visual Studios to speed up coding.
-Planning. Create a map of the needed methods/classes and where they are going to be stored. This time I kept working on methods thinking I would break them
out of Program.cs later, but later never arrived and now it would be hard to break it out cleanly.
-What is method overloading and out arguments? I had to use out for TryParExact to verify the date format, but I'm not sure what it does or if that was
the best way to verify the date given it needed to write to a variable. 

