# About
This sample demonstrates how to implement raw SQL Queries in ASP.NET Core. The main query is calculating the student grade. 

# Project Structure
This sample consists of 2 separate projects:
- SampleWithEFCore : ASP.NET Core 2.1 with Entity Framework Core
- SampleWithEF6 + EF6: ASP.NET Core 2.1 with data layer separate as library using Entity Framework 6 

# Disclaimer
I used Microsoft sample *Contoso University* and simply modified it.

# Get Started
1. Start with the first project (SampleWithEFCore). When you run it, it will create a local DB because it has a [DbInitialzer file](https://github.com/MohamedSahbi/RawQueryWithEFCore/blob/master/SampleWithEFCore/SampleWithEFCore/Data/DbInitializer.cs).
2. When you run the app, call https://localhost:44385/api/Students/GetScore?studentId=1 to get the grade of the student. 
</br>* There are different APIs, you can find all of them in the [StudentsController](https://github.com/MohamedSahbi/RawQueryWithEFCore/blob/master/SampleWithEFCore/SampleWithEFCore/Controllers/StudentsController.cs).
</br> The implementation of the raw query using Entity Framework Core and ADO.NET are in the [StudentRepository](https://github.com/MohamedSahbi/RawQueryWithEFCore/blob/master/SampleWithEFCore/SampleWithEFCore/Repository/StudentRepository.cs).
3. Now, you can set **SampleWithEF6** as StartUp Project.
4. Run the app, then click on students in the nav bar. After that, click in user details. You will find the score in the last raw.

![StudentDetails](https://github.com/MohamedSahbi/RawQueryWithEFCore/blob/master/StudentDetails.PNG)
