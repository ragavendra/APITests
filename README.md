# Introduction 
 API automated tests framework for a sample app with say micro services with least overhead. This repo can be used as a startup for writing api tests in C#. Please refer to [SampleTodoAppTests](Tests/SampleTodoAppTests.cs) for the working sample test.
 
 1. The **[Tests](Tests)** folder have samples for integration api tests. The **[Apps](Apps)** folder consists one service file for each of the app service(s).
 2. A new **App** service file can be added for a new service with atleast one method for each end point and one method for each of the type of the calls supported by the app like say GET, POST, PUT, DELETE, etc,. For GET calls only the `URLi` gets updated, for POST, PUT, UPDATE and similar messages needing message body, the string body `sMessage` need to be passed as well.
 3. **[Data](Data.cs)** file can host the data needed for the tests using nunit data driven framework.
 4. **[Constants](Constants.cs)** file consists of the constants like the server name, protocol, api keys and other constants.
 5. **[Models](Models)** folder consists of models for responses which can be generated on jsontocsharp
 5. Parallel/ multi thread test execution possible using nunit for faster test runs. Set *LevelOfParallelism* to say ideally 4 and play with parallel scope in **[NUnitSettings](NUnitSettings.cs)** file.

# Getting Started
 Git clone the repo and open the solution file on your VS. I am not sure about other IDEs. 
1.	Installation process - Click on `Use this template` on top to directlly use it or fork this repo and clone it to local. 
2.	Package dependencies - almost 0 (none) but **NUnit** only.
3.	Latest releases - master branch
4.	API references - NA

# Build and Test
Unit test explorer shows the tests and can used to run or debug the test(s).

#### Donations
Please feel free to donate as this work is made possible with donations like yours. It involves years of efforts with money spent to obtain the college degree and experience gained to write quality software. PM for customizations and implementations . Not to worry if the business says FashionJewelry as it is a common business.

[![paypal](https://www.paypalobjects.com/en_US/i/btn/btn_donateCC_LG.gif)](https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=ZKRHDCLG22EJA)

Most of all. Enjoy Coding :+1:
