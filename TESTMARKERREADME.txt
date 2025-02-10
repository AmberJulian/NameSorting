To run application, please copy the "Build" folder to a convenient location, open the folder in Bash (or a terminal of your choice) and execute with 
./name-sorter ./unsorted-names-list.txt

This will run a debug build, which should create a second file "sorted-names-list.txt" in the same location. 
There's also a .mp4 file in the build folder - If for whatever reason it isn't working, please refer to the video for what it should look like. 
I've also included some screenshots from AppVeyor to confirm testing/deployment  



Notes for test marker: 
I liked the test! I had to do a few things I'd never done before for it. :)
* Set up unit tests in VS as (NUnit comes built into a Unity project). 
* I'd never set up a build pipeline myself, even though I've worked with them a lot - never heard of Travis or Appveyor.  
* I'd never set up a C# .NET Visual Studio project with git. 

Feedback:
* It might be helpful to provide test takers a .txt with an example list of names - Just to be absolutely certain my .txt is set up correctly.  
* It might be good to switch the words "Travis" and "Appveyor" in the test pdf - When I tried to use Travis, it directed me to pick a plan. I couldn't find a free plan and my research implied it may have been deleted.  


Issues encountered: 
GitIgnore implemented too late - I'm used to Unity creating garbage files, I didn't expect so many from a C# project. 
I apologize profusely to the marker. My .gitignore should have been working from the start, and now I know to either chuck one in by googling the recommendation, or at least check out the garbage files early on when using a new technology.
I fixed this by implementing the git ignore and then deleting the files that git was still updating when I built with VS (as just adding the git ignore doesn't stop them tracking if they are already in repo).  

Couldn't find Travis free tier - went to Appveyor because of this. 

Appveyor needs a appveyor.yml to build. I accidentally named this incorrectly at first. "appveyor.yml" and nothing else in future :)

Wasn't quite sure which unit tests are appropriate - If it's okay, I'd love to get your thoughts and opinions during our chat if there is time for it to be a learning opportunity.  









