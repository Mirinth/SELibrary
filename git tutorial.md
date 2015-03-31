# The Github native client for Windows

This is a short introduction to using the Github native client for
Windows (GNC for short). There's a Mac version too, but since Visual
Studio only runs on Windows, I'll just cover the Windows one (the
Mac one is probably very similar).

## Assumptions

I'm assuming you know how to use Visual Studio already, since you
*did* pick C# as your language of choice. My focus will be on
getting used to Github and the GNC.

## You will need

You'll need Visual Studio installed. I used the 2015 edition since
I had to install it for another class. 2015 is a beta version though,
so if you haven't already installed 2015, the earlier 2013 version
is probably better. I can change the project to work in 2013 if
that works better for anyone. 2015 should still work with 2013 files.

You'll also need the Github Native Client for Windows. You can get
the client from Github here: https://windows.github.com/
Just download, install, start it and you're ready.

Finally, you'll need an account on Github. Everyone in the project
has one of these already.

## A little about the GNC

The GNC is essentially a pretty interface around a console application
called Git. Git is what does all the hard work.

## Repositories

The GNC helps you manage *repositories*. Repositories are basically
just normal folders with some extra data stored in them. The GNC
uses this extra data to provide all its features. We'll see more
about the features soon. For now, we need to set up a repository
so we can get started.

## Setting up a repository

There are two ways to set up repository:
- Create a new, empty repository (good for new projects)
- Clone an existing repository (good for joining existing projects)

### Cloning a repository

We already have a repository, so we'll want to clone it. To clone
the repository, go into the GNC and...
- Click the `+V` (+ down arrow) button in the top left corner
- Click the `Clone` link at the top of the new window
- Select your Github username on the left of the new window
- - You'll see all the repositories your Github account
    can access.
- Select `Mirinth/SELibrary` on the right of the new window
- Click `Clone Repository` at the bottom of the new window
- The GNC will will ask you to pick a folder to clone into.
- Pick the folder where you want the project files.
- The GNC will then clone the repository onto your computer.

### Creating a repository

If you want to make your own repository in the future, it's
not hard to do that.
- Click the `+V` (+ down arrow) button in the top left corner
- Click the `Add` link at the top of the new window
- Choose a folder to place your repository
- The GNC will create a new repository in the folder

Once the repository is set up, you can start using it.

## Branches

The GNC (and Git) lets you make branches in your repository.
Branching is similar to copying the whole project and working
on the copy. This is useful because it lets you make changes
to the copy without worrying that you'll break the original.
We'll use a tutorial branch so we don't break everyone else's
work while we're learning.

To use the tutorial branch, click the `master V` (master, down
arrow) button at the top left of the middle panel of the GNC
and click on the `tutorial` branch. The GNC will switch to the
tutorial branch, which you can safely experiment with.

## Making and reviewing changes

Now it's time to make some changes to the project. Go to the
folder where it's stored at and you should see all the project
files. You can open the Visual Studio `.sln` file under
`/SELibrary/SELibrary/SELibrary.sln` and browse the code files
in the right panel in Visual Studio like any other project.

Open up any code file that looks interesting and type some
nonsense in it like `hjkloi` to make a compiler error. Now
save the changes and switch back to the GNC.

In the top of the center panel, click the down arrow next to
`Uncommitted changes` to see what was changed since your last
commit (more on commits later). In the right panel, you'll
see a list of changed files, the lines changed in each file,
and some surrounding lines for context. You can expand or
collapse each file by clicking the down arrow to the left
of the heading.

The new line you added should be highlighted in green and
start with a `+` sign. This is how the GNC tells you that the
line was added. Removed lines are highlighted in red and start
with a `-` sign.

You don't have to review every change in every file, but it's
a good idea to. I often notice mistakes or things I've forgotten
while I'm reviewing changes.

## Discarding changes

Let's imagine now that there's some mistake (like the compiler
error we just caused) and you want to undo it. The GNC lets you
send a file back to the way it was after the last commit (we're
still building up to commits). To do this, right click on the
file you just changed and click `Discard changes`.

If you switch back to Visual Studio now, it will tell you the
project was modified outside Visual Studio. Reload the file and
you'll see that it's back to how it was before, even though you
made changes and saved them to the disk.

This is a lot like using the `undo` feature, but the GNC makes
it even better by letting you do it even if you closed out
Visual Studio and the GNC and restarted your whole computer.
Not many programs will let you `undo` to a time when they
weren't running.

## Commits

Now we'll look at commits. Commits are a lot like checkpoints,
or save points in video games. When you make a commit, you can
go back in time to that commit, even if it's three years and a
thousand `Save File`s later. They're how you tell the GNC that
this is a place you want to be able to go back to with `undo`
later.

This makes it easy to see how things changed, why they changed,
and who changed them. It also makes it easy to undo changes that
you only realized were bad long after you made them.

When you make a commit, you'll need to add a summary to it. The
summary is just a short, one line explanation of what you did.
This lets people quickly figure out which commits changed things
they're interested in, and short summaries are best for that
purpose, so The GNC encourages short summaries by turning the
ends of long ones gray. You can have summaries with gray ends,
but it's better if they're short enough to be all black.

My strategy is that if my summaries are so long that the GNC
turns the ends gray, I try to go back and break it up into 
several small commits instead of one big one. The
`Discard changes` feature helps me a lot with this. The
checkboxes next to each file name also help -- they let me
exclude some files from the commit without actually discarding
their changes, which is good if the changes in two different
files aren't related. Then I can commit the other files in
a different, smaller commit.

Commits are just like objects: Their changes should have
high cohesion (be strongly related) and low coupling
(minimal unrelated changes). Short summaries help you know
when you're doing this well.

## Making commits

Let's make a commit now. Go back to Visual Studio and change
a file or two. Add some new lines and remove some old ones.
You can modify multiple files, too. Adding new files and
deleting something works as well.

Once you're done making changes, go back to the GNC, expand
the `Uncommitted changes` header, and review the changes.
You can use `Discard changes` on a file or two for practice
if you like. This works on new and deleted files too. You can
use `Discard changes` to delete a new file or bring back a
deleted one.

When you've reviewed things, type in a summary in the center
panel under the `Uncommitted changes` heading. Something like
`Experiment` will do (note: you can try typing in a very long
summary here if you want to see how the colors change when the
GNC thinks the summary is too long). You can add a longer, more
detailed explanation in the `Description` field if you like, but
it's optional. Only the summary is required.

Now click the `Commit to <repository>` button under the
`Description` field to make your first commit.

## Central repositories and syncing

You can see our project's repository online at
https://github.com/Mirinth/SELibrary/
If you look at the files you changed though, you'll see that
the ones on Github are still the old versions, even though
you committed your changes.

The reason why is that you're working on your local
repository on your computer, which is different from the
central repository on Github's computers. It's also different
from the local repositories on everyone else's computers.
My repository won't see your commits either, for example.

If you want everyone else to see your changes, you have to
sync your repository with the central one on Github.
syncing the repositories is similar to copying your
repository onto Github, but it's a little more complicated
because someone else may be changing it at the same time.
The GNC takes care of this automatically most of the time,
so you don't have to worry about it much.

To sync your repository with the one on Github, just click
the little `Sync` button next to the circle of arrows near
the top right of the GNC. The GNC will upload all of your
changes to Github, download any changes from Github to your
computer, and merge everything together so it all works.

Now if you look on Github, you'll see that the files there
match the ones on your computer. Nobody else will see the
changes right away though. They'll have to sync their own
repositories to get the changes you just uploaded. That goes
for everyone. If you want to see the changes made by someone
else, you both have to sync first.

## Good and bad syncing

It's tempting to sync every time you commit, but that's
not a good idea. If everyone syncs with every commit, then
anyone who accidentally breaks the code will affect everyone
and everybody will have to stop working until the problem
is fixed. They'll all be wasting their time waiting for
one person to fix their code.

A better strategy is to only sync when you're confident
all your commits add up to something that still works. At
the end of the day, for example. This makes it less likely
that you'll accidentally stop someone else. It also makes
it less likely that someone else will stop you since they
won't make as many breaking changes, and when they do, you
won't see them until you're already done.

My strategy is that I save my files frequently (each compile,
because Visual Studio saves them automatically), make commits
a little less frequently (about every 10 to 30 minutes), and
sync less frequently (usually when I'm done coding for a while).

## Switching back to the main branch

We're just about done now, so it's time to switch back to the
main branch. Click on the `tutorial V` button near the top left
(where `master V` was earlier) and choose `master`. The GNC will
switch all your files over to the `master` branch again, and
you can start working on the code there with everyone else.

## Conclusion

I think that covers the basics of using the GNC. There are
a lot of other features (many of them involving Git itself),
but this should be enough to finish the project.

If you run into any trouble using the GNC, let me know and
I can try to help you.
