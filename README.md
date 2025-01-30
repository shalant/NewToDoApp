# Demo ToDo App

## Introduction
This is a demo ToDo app for an interview. It is composed in Blazor, has a client and server project, and uses MudBlazor for a CSS library. There were 9 requirements and they all work!
1. The user must be able to enter a new, active task.
2. Tasks entered must be displayed to the user in an acceptable format (for example: a list or a
table).
3. The user must be able to mark an active task as ‘Complete’.
4. The user must be able to change a completed task back to ‘Active’.
5. The user must be able to delete an individual task.
6. The user must be able to delete all completed tasks in a single action.
7. The user must be able to toggle between showing all, only active, or only completed tasks.
8. Completed tasks should be shown differently than active ones.
9. The total number of active tasks should be displayed to the user.

Additionally, I added some toasts for successful create/update via Bootstrap and dialogs to slow down the deletion process.

Here's a walkthrough of the app! - Watch video: https://www.loom.com/share/4e2853927f79452f8026abe30cdce8bf?sid=37135894-af77-4633-a397-2fddd878c69b

### How to run
Run this from your terminal: "git clone https://github.com/shalant/NewToDoApp.git", open the folder in file explorer, and click on the NewToDoApp.sln. It should open Visual Studio. In appsettings.json, you will need to add a correct connection string that works with your own DB. In top navigation, click tools => Nuget Package Manager => Package Manager Console. This will open a terminal where you need to run 2 commands: "add-migration Initial" and then "update-database". Then just click play...

### Bugs
#### For some reason, the first paint is messed up. I have to refresh to see data. WEIRD!

### Future development
1. Flesh out identity and add a column to each task for UserId 
2. Add unit testing with a GH workflow 
3. Cheap deployment via Docker Compose and Digital Ocean.

### Contact

- Douglas Rosenberg 
    - Focus: fullstack .NET
    - Email: doug.rosenberg@gmail.com
    - Linkedin: https://www.linkedin.com/in/douglasrosenberg/