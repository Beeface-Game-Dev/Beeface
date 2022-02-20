# BeeFace
Unity project

# Setup
Install Visual Studio 2019
- maak seker dat VS saam unity kan werk koni onthou of jy die pakckage vir dit saam met VS of Unity download nie.
- install with game support checked


Unity 2019.4.23f1 of nuutste
{Kan alles kry wat dalk lyk of ons dit gaan gebruik}
-2D Sprite
-2D Tilemap Editor 
-Analytics Library
-Custom NUnit
-in App Purchasing
-Mono Cecil
-Multiplayer HLAPI
-Rider Editor
-Test Framework
-TextMesh Pro
-TimeLine
-Unity Collavorate
-Unity UI
-Vidual Studio Code Editor
-XR Legacy Input Helpers
-{Alles wat ons kan benodig vir andriod IOS en windows game maak}


# Build
Run this code to build project and check for errors
- build code

# Run
To run project locally:
- Make sure packages are installed
- Run command: run project

# Git Flow
* main branch should always work
* make a new branch to add a feature or fix a bug
* upload branch and make a PR to main so we can review the code before merging

To make a new branch:
git checkout main
git pull main
git checkout -b feature/whatever (or fix/whatever-bug for bug fixes) (or update/whatever-update for updates that are not new features)

To upload branch:
git add . (the . will add all changes)
git status (this is to check what files have been modified)
git commit (commit changes locally. When writing a commit you can tag it with [General] or [Feature] or [Fix] if you want. Ensure the commit message explains what happened in the commit)
git push (upload all the commits to github. When you first push a branch you will be promted to set a up-stream. Just copy and paste what it says)

To merge a branch:
Checkout to the branch you want to merge into
git merge main (This will merge the main branch into the current one. Fix all conflicts and commit branch. A commit message will be added so you just have to Crtl+X and then press Enter)

# Pull requests
If you want to merge you branch into main then you must first create a pull request. Use github in the browser to make this easier.

