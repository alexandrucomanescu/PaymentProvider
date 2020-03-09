
# Payment Provider
A Payment WebApi that processes the Payments requests



Write a Payment domain/entity with the same properties as the request and a second entity to store the payment state (pending, processed, failed). Use Entity framework code first approach, write entity configurations and generate the migrations.


## Process Request
**Request details** 
- CreditCardNumber (mandatory, string, it should be a valid CCN) 
- CardHolder: (mandatory, string) 
- ExpirationDate (mandatory, DateTime, it cannot be in the past) 
- SecurityCode (optional, string, 3 digits) 
-  Amount (mandatoy decimal, positive amount)

The response of this method should be one of the followings:
- Payment is processed: 200 OK 
- The request is invalid: 400 bad request 
- Any error: 500 internal server error
- The request should be validated before processed. 

The payment could be processed using different payment providers (external services) called: 
- IExpensivePaymentGatewa or 
- ICheapPaymentGateway. 

The payment gateway that should be used to process each payment follows the next set of business rules: 
a) If the amount to be paid is less than £20, use ICheapPaymentGateway. 
b) If the amount to be paid is £21-500, use IExpensivePaymentGateway if available. Otherwise, retry only once with ICheapPaymentGateway. 
c) If the amount is > £500, try only PremiumPaymentService and retry up to 3 times in case payment does not get processed 
d) Store/update the payment and payment state entities c

# Implementation Details

Project is developed with 
- .Net core 3.1
- .Net Standard 2.1
- AutoMapper
- FluentValidation
- MediatR
- Entity Framework Core
- NSwag

The solution has a DDD architecture.

***Domain***  contains Entities, ValueObjects, Enums. Domain project is independent, it doesn't have any dependency. 

***Application***  - here we can find the Commands and Actions that can be done on the objects from the Domain Layer. 

***Infrastructure*** - ApplicationDbContext [we can add here the extra layer of Repository if we need it]. Since the application is developed with .Net Core & EF Core, the repository is not necessary because EF Core insulates your code from database changes, DbContext acts as a unit of work, DbSet acts as a repository, EF Core has features for unit testing without repositories. We can add Unit of Work & Repository patterns if we would need to have an abstraction from EF Core layer.

***WebUI*** - here we have the Request that is called to process a payment.



