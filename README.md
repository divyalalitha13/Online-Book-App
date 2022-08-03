<h1 align="center">Online Book Application </h1>


Online Book Application is an end-to-end Enterprise application where you can order books online. It has many functionalities like Register, Login, View Books, View Wishlist, View Cart, View Orders, Add Reviews, View Reviews. 
Apart from this, it has basic Home page, default Customer Care page.

## Technology Used:

- SQL Server: Database for storing all tables, stored procedures and functions
- EF Core: For creating DAL Layer
- ASP.Net Web API: For creating Service Layer
- Angular 8: For creating front-end application which acts as UI for the user

## Registration Page

Registration Page allows users to register for the application by filling all required details.

![Registration Page](/screenshots/Registration.png)

## Login Page

Login Page allows to authenticate the identity of the user.

![Login Page](/screenshots/Login.png)

## Books Page

Books Page has all the list of books available online. It also has Search by Book name functionality and Search by Genre functionality. Apart from this each book has options to Wishlist and Add to Cart.

![Books Page](/screenshots/Books.png)

## Wishlist Page

Books which are added to your wishlist is displayed here. You also have option to Remove from Wishlist.

![Wishlist Page](/screenshots/Wishlist.png)

## Cart Page

Books which are added to your cart are displayed here. It also has Remove from Cart functionality. You can also update your book quantity here. Total amount in cart is calculated dynamically and you can proceed to payment here

![Books Page](/screenshots/Cart.png)

## Payment Page

Here you have a list of dummy card numbers and balance amounts you can select from. On payment the balance gets updated, ordered books are removed from Cart and added to Your Orders.

![Books Page](/screenshots/Payment.png)

## Orders Page

You can find the list of books you ordered here with Order date and Estimated Delivery(5 days from Order date). On delivery date,status will change to Delivered and Review button will be enabled.

![Books Page](/screenshots/Orders.png)

## Add Review Page

On clicking Add Review button, you can add rating and comments for it.

![Books Page](/screenshots/AddReview.png)

## Reviews Page

You can view your reviews here.

![Books Page](/screenshots/Reviews.png)
