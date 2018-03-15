For Too Broke, we found that our project currently uses the Singleton design pattern.  It uses this by creating an instance of a calculator as a global access point and filling it with information for the specified user.

Other patterns that could fit:
-Factory Method
-Factory
-Abstract Factory
-Builder

For the rest of the application, we plan to continue using the Singleton design pattern.  We plan to create all of our models for the different calculators using this design pattern. It allows us to create different calculators with different attributes that can be changed based on which user is currently logged in. If we were to switch to another design pattern, we would use the Abstract factory so we could create a family of related objects, without explicitly specifying their classes.