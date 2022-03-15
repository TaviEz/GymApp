# GymApp[Work In Progress]


**About**

This is a Web App made with ASP.NET(MVC) using the .NET 6 framework. I tried recreating my first [CRUD app](https://github.com/TaviEz/CRUD-Web-App), this time using the newest framework .NET 6.

**Running the program**

After launching the VISUAL Studio 2022 and installing all the packages needed for the asp.net core you can safely build the project(```CTRL + SHIFT + B```) and run it(```CTRL+F5```). In order to access the page with the database you need to add ```/gyms``` at the end of the starting page URL(```https://localhost:1234/Gyms```). 1234 is just an example of a local host.
![gym1](https://user-images.githubusercontent.com/100527261/158464694-086f8429-6ed8-43bd-b402-ea7790de0d79.png)

**Description**

I chose to use this app to keep track of the workouts including the name of the exercise, repetitions, sets and also weight. The exercises, reps and sets columns are added by me manually in VISUAL STUDIO, but if you want to add more you can add them by selecting the create new button in the ``/gyms`` tab. Besides the availabile commands  create/delete/edit/details you have on the top left some filter searches for the muscle groups and for exercises you're looking for.
in the database

**Issues to be fixed**

At the moment I'm having some trouble adding a new column inside the script, not by just clicking the *Create New* button. In this case *weight* was added later than the first columns and as you can see some values are 0.


