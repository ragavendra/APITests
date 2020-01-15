# Introduction 
 API automated tests framework for a sample app with say micro services. This repo can be used as a startup for writing C# api tests. 
 
 1. The **TestCases** folder have samples for integration api tests. The **Services** folder consists one service file for each microservice.
 2. A new **Microservice** file can be added for a new microservice with various http calls like per say GET, POST, PUT, DELETE, etc,. calls for it. 
 3. **Data** file can host the data needed for the tests using nunit data driven framework.
 4. **Constants** file consists of the constants like the server name, protocol, api keys and other constants.
 5. Parallel/ multi thread test execution possible using nunit for faster test runs. Set *LevelOfParallelism* to say ideally 4 and play with parallel scope in **NUnitSettings** file.

# Getting Started
 Git clone the repo and open the solution file on your VS. I am not sure about other IDEs. 
1.	Installation process - NA
2.	Software dependencies - almost 0 (none) but **NUnit** **NewtonSoft-JSON**
3.	Latest releases - master branch
4.	API references - NA

# Build and Test
Unit test explorer shows the tests and can used to run the tests.

#### Donations
Please feel free to donate as this work is made possible with donations like yours. It involves years of efforts with money spent to obtain the college degree and experience gained to write quality software. PM for customizations and implementations 

[![paypal](https://www.paypalobjects.com/en_US/i/btn/btn_donateCC_LG.gif)](https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=ZKRHDCLG22EJA)

Most of all. Enjoy Coding :+1:
