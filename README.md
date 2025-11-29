# Big-Numbers-Formatter-in-Unity
---
This is a script you can bring into your unity project to format big numbers into strings to make it more readable for your players!

#How To Use
---
After importing the folder or script into your assets directory follow these steps into your script!

1. insert this at the top of your script
```
using BrokenFlameGames;
```
2. When you want to use the function you can type something like this...
```
  double damageDone = 923812391238312; //Example Damage Input
  print(BFG_BigNumbers.FormatBigNumber(damageDone)); //Prints a formated Damage
```
3. Enjoy the Results! Using the above example will give this in the console.
```
923.8T
```
#Some Notes to Give You on This
---
This script best works with doubles, but you techincally can use other number based values as well.

Also feel free of course to edit the script to your liking for your specific project!
