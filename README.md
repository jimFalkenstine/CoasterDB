<h1>CoasterDB - The Roller Coaster Database</h1>
<p>A C# Console Application that tracks Roller Coaster stats</p>

<h2>Introduction</h2>
<p>This is my Final Project for Code Louisville's May 2021 C# class.  For my project, I chose to create a database of Roller Coasters that I have ridden.  When the app loads, the user is greeted with a Main Menu with 4 options.  These options are Coaster Index, Top Ten Coaster Lists, Coaster Counts, and Exit.  The user chooses an option by typing the number of the option.</p>

<h3>Coaster Index</h3>
<p>If the user chooses Option 1 from the Main Menu, they are taken to the Coaster Index Submenu.  Here the user can see information about each roller coaster in the database.  The roller coasters are listed alphabetically by name and are partitioned into 6 groups of 20.  For example, if a user chooses Option 1 from the Coaster Index Menu, the app will display information on the first 20 coasters starting with Adventure Express and ending with Blue Streak.  The user can then press Enter to return to the Coaster Index Submenu.  From there, the user can then choose to see more coasters or return to the Main Menu.</p>

<h3>Top Ten Coaster Lists</h3>
<p>When choosing Option 2 from the Main Menu, the user is taken to the Top Ten Coaster List Submenu.  From here the user can choose to see a list of the Top Ten Tallest, Longest, Fastest Coasters as well as the Coasters with the Most Inversions.  For example, if a user chooses Option 1, a list of the Top Ten Tallest Coasters is displayed.  The user can then press Enter to return to the Top Ten Coaster List Submenu.  Once back in the Top Ten Coaster List Submenu, the user can choose to see the other Top Ten Lists or return to the Main Menu.</p>

<h3>Coaster Counts</h3>
<p>When choosing Option 3 from the Main Menu, the user is taken to the Coaster Counts Submenu.  From here the user can see the total coaster count for the database is 116.  The user can also see 6 other coaster counts.  For example, if the user chooses Option 1, they will see the name of each Amusement Park in the database listed alongside the number of coasters at that park.  The user can press Enter to return to the Coaster Count Submenu.  Once back in the Coaster Counts Submenu, the user can choose to see the other Coaster Counts or return to the Main Menu.</p>

<h3>Exit</h3>
<p>Choosing Option 4 exits the app.</p>

<h2>C# Features</h2>
<h3>Feature #1 - Master Loop Console Application</h3>
<p>I created a Master Loop Console Application.  When the app loads the user is greeted with a Main Menu.  From the Main Menu the user can choose from 4 options including exiting the app.  When the user chooses an option other than Exit, a submenu is displayed with additional options.  The user can choose from these additional options or return to the Main Menu.  The Main Menu and Submenus were created using Switch Statements.</p>

<h3>Feature #2 - Read Data from JSON File</h3>
<p>At the heart of CoasterDB is a JSON file called coaster.json.  The JSON file contains an array of roller coaster objects.  Each coaster object includes 13 Key:Value pairs.  I created the JSON file manually because I could not find an existing JSON file or API that fulfilled my needs.  The roller coasters listed in the JSON file are ones that I have personally ridden.  Using Newtonsoft.Json, I created a method to initiate a data stream and deserialize the JSON file into a List of C# objects of the Coaster Class.</p>

<h3>Feature #3 - Create a List</h3>
<p>In addition to creating a List of Coster objects from the deserialized coasters.json file, I also created other Lists for my Top Ten Coaster Lists.  For example my GetTopTenTallestCoasters method returns a List of Coaster objects sorted by a custom CoasterHeightComparer.</p>

<h3>Feature #4 - LINQ Queries</h3>
<p>All of the Coaster Counts were done using LINQ queries.  For example, in the Coaster Count by Park, I used the LINQ GroupBy method to group the Coasters by their Park property.  I also used the LINQ Take and Skip methods to partition the coasters in the Coaster Index into sets of 20.</p>