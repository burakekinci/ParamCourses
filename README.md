# ParamCourses
ASP.NET Core WebApi Course during the Patika - Param Bootcamp

+ *Pattern* : UnitOfWork and Generic Repository pattern
+ *DB Options* : EntitiyFrameCore and Generic Database
+ AutoMapper Configuration

## Pattern Hierarchy
Pattern hierarchy from bottom to top
- DBSet&emsp;&emsp;&emsp;&emsp;(Example : Person DbSet)
- Repository&emsp;&emsp;(Example : PersonRepository, controls the Person DbSet)
- UnitOfWork&ensp;&emsp;(Example : PersonRepository, AccountRepository; controls the repositories from unit of work)
