To run application, please copy the "Build" folder to a convenient location, open the folder in Bash (or a terminal of your choice) and execute with 
./name-sorter ./unsorted-names-list.txt

This will run a debug build, which should create a second file "sorted-names-list.txt" in the same location. 




Notes for test marker: 
I liked the test - it required me to do many things I haven't done before.

Feedback:
* It might be helpful to provide test takers a .txt with an example list of names - Just to make sure I'm breaking my lines the same way you are.  

* It might be good to switch the words "Travis" and "Appveyor" if Travis doesn't have a free tier (I hope I'm wrong and it does still exist!).  

Things that I'd never done before: 
I've never set up unit tests in VS as NUnit comes with a Unity project. 
I've never set up a build pipeline myself, even though I've worked with them a lot - never heard of Travis or Appveyor.  
I've never set up a C# .NET Visual Studio project with git. 

Issues encountered: 
GitIgnore implemented too late - I'm used to Unity creating garbage files, I didn't expect so many from a C# project. I apologize profusely to the marker. My .gitignore should have been working from the start, and now I know to either chuck one in by googling the recommendation, or at least check out the garbage files early on when using a new technology.
I COULD probably fix my git history with some cherry picks and forced pushes, and would be happy to give it a try if requested.  

Couldn't find Travis free tier - went to Appveyor because of this. 

Appveyor needs a appveyor.yml to build. I accidentally named this wrong at first. "appveyor.yml" and nothing else in future :)


Wasn't quite sure which unit tests are appropriate for this project - Would love to chat more about this to check if I missed any if there is time. :) 










