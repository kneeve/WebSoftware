Author:    Kaelin Hoang
Partner:   None
Date:      9/27/2019
Course:    CS 4540, Web Software Architecture
Copyright: CS 4540 and Kaelin Hoang - This work may not be copied for use in Academic Coursework.


Comment to Evaluators:

Observation on Authorization and Authentication:
	I thought it was very interesting how Visual Studio handled Authorization and Authentication for us. It is nice how things like passwords are already encrypted 
so that we don't have to worry about salting our own passwords. I also thought it was very useful to establish your own roles by seeding a Roles database and using those roles
to authorize various levels of access. Also C# has a lot of helpful tools to make integration of Authorization very simple to use. I found it useful that by adding
a simple [Authorize(Roles = "SomeRole")] can allow certain cshtml files to be visible to the user or not. The authorization can be used on entire classes as well.
What's more is that this authorization auto-generates the form to tell the user to log in if they haven't already. This was extremely helpful as a programmer
to not have to make another cshtml view and hook that up only when there is no user that has logged in. Then when a user is logged in, they are assigned a role
and that role is verified to make sure they can see certain pages. This is all handled behind the scenes. On this assignment specifically I specifically authorized the 
Admin to be able to create learning outcomes and view the role change page. Then I made sure the chair was authorized to see the courses and learning outcomes. The
instructor role was only authorized to be able to see their own courses and learning outcomes.

Above and Beyond: 
	I primarily followed the tutorials in class (which do not require citation). But I believe that my site goes above and beyond because
I used an online tutorial from W3 schools (cited in my previous submission) in order to overhaul the look of my website. I have some "dummy" links primarily on the side
bar menu which show some nice, animated progress bars. These progress bars (cited in previous submission) can also be seen on the home page to also fill some space. 
Not only that, I made sure to change my Courses database to also include an InstructorEmail. This is because we needed a way to keep track of which professor taught 
which class. In my Courses Controller, this is where I created a new method to get the logged in user's email address and use that to query the Courses database.
Then within a new View that I created, I displayed the courses in a dynamic table depending on which user is logged in.
Additionally, the roles change page was added with a nice interface. At the moment, the plus and minus signs are not clickable but that can easily be changed later.
For now, the view uses dependency injection of a userManager to get all users registered and their associated roles. It performs checks on which role the user is 
and fills in the corresponding cells as necessary.

Improvements:
	I made major improvements to the home page by adding quick links to the home page. These required utilizing authorization to allow/disallow certain users.
Then I also improved the look of my website a bit more as well. I liked the clean look of the default Windows authorization/log in pages so those were left in place just
the stylesheet that I have been using.



Consulted Piazza (classmates) and teaching assistants for additional questions.


Code Citations:
1. https://stackoverflow.com/questions/35539491/list-of-user-roles-in-view-using-asp-net-mvc-6 : Get list of users and their associated roles.