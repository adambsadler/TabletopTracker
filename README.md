# Tabletop Tracker

**By Adam Sadler**

As my final project for my Software Development Red Badge at Eleven Fifty Academy, I had to develop an ASP.NET MVC web application. I decided to create an application that allows users to manage their collection of board games. As part of the assignment, we were expected to create at least 3 data tables, with corresponding models, service, controller, and views. At least one of these tables must include a foriegn key relationship. Here are the data tables in my application:

- `Game` This class allows a user to add a game to their collection with the following information; title, category, publisher, player count, and rating. There is also a bool that allows the user to indicate whether or not they have played this game. The publisher and category properties are foriegn keys associated with the classes below. The user may still create a new game, even if they have yet to create the associated category or publisher; they can simply leave those dropdowns blank during creation.

- `Publisher` This class allows the user to add a publisher to their collection, including a link to the publisher's website. In the Publisher Index View, there is a "Games in Collection" field that displays how many games the user has in their collection associated with the publisher.

- `Category` This class allows the user to add a category to their collection, including a description of that category. In the Category Index View, there is a "Games in Collection" field that displays how many games the user has in their collection associated with the category.

- `Session` This class allows the user to document a play session of a game in their collection. The play session includes the date of the session, who played the game, and any notes the user would like to include. 

Before a user logs in, all they will have access to is the home page and the About page. After registering an account and logging in, the other options become available.

In addition, we were expected to deploy this application to Azure, which can be found here: [Azure Deployment](https://tabletoptracker.azurewebsites.net/)
