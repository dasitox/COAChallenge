
API REST / COACHALLENGE
App Net Core Api, ABM of Users with local database.

PRE-REQUIREMENTS
Microsoft SQL Server Management Studio 18
Visual Studio 2019 .Net Core 3.1
APIs Summary
Methods used to invoke APIs

GET

to search for resources / details 
POST

to create new resource
PUT

to change details of that resource 
DELETE

to delete resource 

How to make use of the API?
The API can be invoked through HTTP GET, POST and PUT requests. All parameters in the request must be encoded by form. 
supports the JSON format and the URL structure for it is given below:


URL

https://<Host-Name OR IP address>:<Port>/Home/usuarios/<Resource ID>


Important
You must generate new resources through httpPost, since it will generate a new database to be able to manipulate them.

##GET LIST OF RESOURCES

Description

To get the list of resources which are owned by or shared to an API user. 
URL

https://<Host-Name OR IP address>:<Port>/Home/usuarios

HTTP Method

GET

Input Data

None

Sample Output

In the output (as shown in the sample below), you will get all the resources owned

example
     

 	[
 	    {
 	       "id":1,
 	
 	      "name":"Donald",

	      "email":"a@a.com",

	      "telephone":"4223-2233",

	      "isActive":true
        },
        {
	        "id":1,
	
	        "name":"Donald",

	        "email":"a@a.com",

	        "telephone":"4223-2233",

	        "isActive":true
	    }
	]
  
...

GET THE DETAIL OF A PARTICULAR RESAOURCE

Description

To obtain the detail of a resource, in an http request platform, it is necessary to have its id (obtained in the GET method of the resource list) 

Sample Request 

URL

https://<Host-Name OR IP address>:<Port>/Home/usuarios/<Resource ID>
HTTP Method

GET

Input Data

Resource ID

Sample Output 
example recourseId : 1

 	{
 	    "id":1,
 	
 	    "name":"Donald",

	    "email":"a@a.com",

	    "telephone":"4223-2233",

	    "isActive":true
 	}
  

ADD A RESOURCE

Description

To add a resource, you must enter the resource form in an http request platform in json format 

Sample Request 

URL

https://<Host-Name OR IP address>:<Port>/Home/usuarios
HTTP Method

POST

Input Data

in json format, you must enter the resource form(the properties of the resource)
* Important, you should not add the id since a new one will be generated automatically per record, as well as isActive.



 	

	{
	    "name": "value1 ",
	
	    "email": "value2",

	    "telephone": "value3"
	    
	}
  

Sample Output 

	
    {
        "id": "new Id",
        
        "name": "value1 ",

	    "email": "value2",

	    "telephone": "value3",

	    "isActive": "true"
    }


MODIFY RESOURCE

Description

To modify a complete resource, on an http request platform, you must enter the resource id in the url and the resource form in json format in the body of the request 

Sample Request 

URL

https://<Host-Name OR IP address>:<Port>/Home/usuarios/<Resource ID>
HTTP Method

PUT

Input Data

get the resource using the id and then modify it with the new data in json format, you need to enter the resource form (the resource properties)

example:

 	{
 	    "id":1,
 	    
 	    "name":"Donald",

	    "email":"a@a.com",

	    "telephone":"4223-2233",

	    "isActive":true  
 	}


modified with new data


	{
	    "name": "value1 ",

	    "email": "value2",

	    "telephone": "value3"
	}
	
	"Id" and "IsActive" no modification necessary


Sample Output 


 	{
  	    "id":1,
  	    
 	    "name": "value1",

	    "email": "value2",

	    "telephone": "value3",

	    "isActive":true
 	}

DELETE RESOURCE

Description

To delete a resource, on an http request platform, you must search for the resource using the id and then delete them with that request. 

Sample Request 
URL
https://<Host-Name OR IP address>:<Port>/Home/usuarios/<Resource ID>

HTTP Method

DELETE

Input Data

Resource ID

Sample Output 