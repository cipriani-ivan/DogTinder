The idea behind this project is to create a fake app for organize appointment between owner of dogs at the dog-park or at the beach etc…
This web application is a personal playground and not an example of code ready to go in production.
For the back-end I have created web API with asp.net core using EF code first and Microsoft SQL server and mapping for convert data model to view model.
For the front-end I have used Angular with NX and swagger to generate client library to talk with the back-end.
The UI and user experience is limited, the idea is to implement in the future share component for a common user experience and reduce the duplicate code and tailwindcss.
In the application there is not login so you have to think this application like you are the administrator and you have full access to all the data e full-right.
You can add an owner of a dog, a dog and link mandatorily to an owner, add a place and finally create an appointment selecting a place a dog and setting a date.
Still to do add the functionality to add more dogs to the same appointment.
Also the testing part is done only like example and exercise not all the code is test, there is unit test with xunit, specflow test to test the web api on the real data (need still to create a new database at every test), Jest for unit test in angular and playwright for end-to -end test. This is not a TDD project but l could start to implemented with this methodology.
There is still a lot to be implemented or try to use…
Working in progress…
