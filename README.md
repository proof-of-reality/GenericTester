# GenericTester
Generic Tester C#

This project is an example of a xUnit test that takes the results of all declared methods of all Controllers of a MVC project and executes them against "random" data.

The benefits of this approach is that you can have a "snapshot" of the project, and can detect breaking changes into your code by comparing the results of the current 'snapshot' and the last one.

This is an approach for projects that are already (or almost) done and doesn't have unit tests as well.

