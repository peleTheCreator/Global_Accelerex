## Global_Accelerex
Global Accelerex Assessment Test

## Prerequirements
* Visual Studio 2017
* .NET Core SDK
* Command and Query Responsibility Segregation(CQRS)
* Mediator Pattern
* Fluent Validation
* C#
* Console App
* Asp.Net CoreWeb Api

##Scope
The repository contains two project 
#OpeningHours
*OpeningHours : The task is to write a program that takes JSON-formatted opening hours of a restaurant as an input and outputs hours in more human readable format.

#Inverse Permutation
*Inverse Permutation : Given an array A of size n of integers in the range from 1 to n, we need to find the inverse permutation of that array.Inverse Permutation is
a permutation which you will get by inserting positionof an element at the position specified by the element value in the array.


## How To Run
* Open solution in Visual Studio 2017
* select the Startup Project and build the project.
* Run the application.

#OpeningHour Example
*Openinghours web api has three endpoint which are CreateOpeningHours, GetOpeningHours, GetAllOpeningHours

*CreateOpeningHours
![image](https://user-images.githubusercontent.com/59338573/179526145-53693059-c132-43ca-858c-b622dca5ffe1.png)


Navigate to the header, get location header value to call the GetOpeningHours.
![image](https://user-images.githubusercontent.com/59338573/179526285-135d0931-8ad8-414a-a3a7-c7672da2d82b.png)


*GetOpeningHours
-Get openinghours being created passing the Id.
![image](https://user-images.githubusercontent.com/59338573/179526450-5700f2e8-a3ba-429a-ba17-7d2b6e661edd.png)

*GetAllOpeningHours
-An endpoint to get all the openinghours that has been created.
![image](https://user-images.githubusercontent.com/59338573/179526652-b9b3d055-2208-4fac-a6df-c36afc22cedb.png)



##Take on Opening Hour Application Json Format
The request json format will have been easier to work with if all the opening hour value data is represented in an array, 
example : 
{
  [
     monday : 
     {
        data : [
            {
               "type": "open",
               "value": 36000
            },
            {
               "type": "closed",
               "value": 36000
            }
        ]
     }
   
   ]
}


#Inverse Permutation Example
*The app aleady conatin a sample test data, to modify it before running the app, input the the value of N(size of the array) 
and Arr(the array to perform inverse permutation)

![image](https://user-images.githubusercontent.com/59338573/179530187-b9daec35-0154-4158-880a-326fee80fff2.png)
