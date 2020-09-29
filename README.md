# Equi
C# extended solution to Codility's Equi problem (rated medium difficulty): Find the indicies in an array such that its prefix sum equals its suffix sum, at
https://app.codility.com/public-report-detail/#task-2

# My Solution
My solution code and interactive demo can be found [here](https://repl.it/@DaveWork26/Equi#main.cs).
Additionally, I've printed all the equilibrium solutions along with actual, expected and a pass/fail test results (the official problem only asked for one equilibrium result).

## Algorithm
Move equilibrium from lower to upper by one position, adding previous equilibrium value to lower total (as this was excluded from totals but is now available to lower total), and subtracting new equilibrium value from upper total (as this was previously included in upper total but is now unavailable).

Note: we are testing the current equilibrium position's totals but calculating totals for the next position, because we can pre-calculate the first equilibrium's lower and higher totals before the start of the main loop.

## Screenshots

#### All Products
![Equi](./../Screenshots/Equi.JPG?raw=true "Equi")

