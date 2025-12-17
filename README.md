# ProductApp

In order to fullfil the app specifications I created the app using ASP .NET MVC.
I created a Model class with all the field that are going to be needed in the database table.

Then I created a Data for my database context so when I run migrations the Model will register into my database as a table along with its' fields. I created a connection string in the Json file and as well registered the connection string as DefaultConnection in my Program.cs file.
I created a Controller that connects with my Model class in order to do my CRUD functionality.

My Views are connected to my Controller functions based on what each function does.
So, so when you run the app, it first shows the a table with list of products that a user added into the database table, but if there are no records it is going to tell the user that there are no records. If there are records, each record has a delete and edit button for which you can edit or delete a record. Both these buttons are functioning well, but the delete button first confirms with a user if they really are sure of deleting a record.

At the top of the list of records, there is a button for creating a new product which redirects a user to form so they can add a record. The form is validated with JavaScript in order to prevent the user from submiting if the entry are fields are empty. There is no entry field for the data a product is created as this action is taken care of by the code inside the Controller for creating a new record, because the date has to be now, the user does cannot create a product for any other day besides now.
