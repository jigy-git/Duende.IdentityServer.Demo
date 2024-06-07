
About
-------
This is small app to emo Duende Identity Server. 

An Identity Server is wrapper around OKTA/AUTH2 with a benefit that you can manage your own client database. 

It has 2 databases : 
1. Configurational Data store - that rarely changes and as the name suggests has static configuration data including Client details - Ids, Scopes etc. 
2. Operational Data Store - this has transient data. Data related to Grants, Sessions Tokens and their validity.   

It connects to these datastore using EntityFramework. So any database - SQL, NoSQL - that can be "handled" via Entity Framework can be used with this.
Even better is you can have different types of data bases for Configuration and Operational. 



Using this
-----------

This is .NET 8 tool. Simple. Use F5 to run it. 

It uses in memory database and test users - so is up & ready for demo
