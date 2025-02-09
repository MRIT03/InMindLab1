# Hello Elie !

So in this Lab I implemented An exception handler, A logging middleware, 2 logging filters, and Implemented an object mapper that uses Generics and reflection to map between a Person class and the Student class.

All the tests were ran using postman.

# Exception Handler

As per your suggestion, I implemented the exception handler using the built in IExceptionHandler interface. However, as you also mentioned the Result design pattern in class, I tried to implement it.

## Global Exception Handler

### /Middleware/GlobalExceptionHandler.cs

This class implements the exceptioin handler interface. The code works by taking the HTTP context of the request, setting the status code and response type, then write a JSON body asynchronously while adding a cancellation token to propagate the need of cancelling the request.

### /Controllers/StudentController.cs

This was tested on the route /Student/exception, and the exception message was found in the response body and the command line


## Error Handling with Result Design Pattern

### /Common/Result.cs

This file is self documented. It is an implementation of the Result<T> Container, which allows sending the expected result or a string error message

### Testing

This was tested by moddifying the student service. The method GetStudentById(int id) was changed to return a Result<Student> instead of a Student.
In the student controller, the cases where the result is successful returns the student directly, and the case where it isn't, it returns an error message.

# Middleware

## Logging Middleware

### /Middleware/RequestLoggingMiddleware.cs

This class works by taking the needed information out of the HTTP context and writing them on the command line. 
A stopwatch is initiatied and ran while sending the request to the request delegate. After the request delegate ends, the stopwatch ends, and the elapsed time of the request is measured and outputted on the command line.

The middleware was registered in the program.cs

# Filters

## Command Line based Logging Filter 

### /Filters/LoggingActionFilter.cs

This filter is very similar to the request logging middelware. Insted of the HTTP context, it uses the Action executing/executed contexts to determine the needed information and logging them in the command line.

This Filter was registered in program.cs and was implemented on all routes. Logging was successful on all actions. 

## ILogger based Filter

### /Filter/ILoggerActionFilter.cs

After some research it was found that logging could be done through a different implementation that uses the ILogger interface. The logger was created and injected using dependency injection.
In this implementation the logger would write to the command line instead of directly writing to it.

This logger was only implemented on the "Student/ILoggerTest" route and executed successfully.

# Reflection and Generics

## Person and Student class mapper

To test out the concept of reflection and generics, the Person and Student classes were created with the goal of creating a generic mapper between them. The student class inherits the person class and has all its properties in addition to an "Email" property.

### /Services/ObjectMapperService.cs

This file is self documented. It's a basic mapper between two random classes, where the common properties of one object are set to a second, newly created object of a different type.
This mapper relies on the properties having similar names, which is the case between our Student and person classes.

The mapper was tested on the "/Student/MapStudentToPerson" route, where a student object was sent in the body of the request and a person object was received in the body of the response
