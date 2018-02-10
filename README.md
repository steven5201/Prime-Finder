# Prime Finder
This program finds prime numbers for the given input values and outputs to the designated file.

## Using the program
Enter in the information as follows on the on screen prompts.
```
The number of tasks to run.
The number of values per task you would like to run.
Finally the final name you would like to output all of the primes found to.
```

## Notes
```
It is recommended that the number of tasks be high and the number of values per task be low.
This will allow the program to run faster.
```
```
It will use another thread on the CPU for each task using the built in Task class in C#
It trys to prevent incorrect user input for all the inputs except for the file name.
This could cause potential crashes if the user trys to name the file something disallowed by windows.
```
