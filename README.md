The idea behind this project is to create a fake app to organize appointments between owners of dogs at the dog-park or at the beach etc… 
This web application is a personal playground and
and not an example of code ready to go in production. 
For the back-end I have created web API with asp.net core using EF core code first,
Microsoft SQL server and AutoMapper for convert data model to view model.
For the front-end I have used Angular with NX and swagger to generate client library
to talk with the back-end so to have a separation of concern between the parts.
The UI and user experience is limited and the idea is to implement
in the future share components for a common user experience through the application
and reduce the duplicate code, another improvement will be thr use of tailwindcss...
In the application there is not login so you have to think to this application like
you are the administrator and you have full access to all the data and of course full-right.
You can add an owner, a dog and link him mandatorily to an owner, add a place and finally
create an appointment selecting a place a dog and setting a date.
Still to do add the functionality to add more dogs to the same appointment.
Also the testing part is done only like example and exercise not all the code is test,
there is unit test with xUnit, specflow test to test the web api on the real data
(need still to create a new database at every test), Jest for unit test in angular
and playwright for end-to-end test. This is not a TDD project but I could start
to code with this methodology in mind.
There is still a lot to be implemented or try to use…
Working in progress…
