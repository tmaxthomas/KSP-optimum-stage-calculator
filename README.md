# KSP-optimum-stage-calculator

KSP Optimum Stage Calculator v.1.0 5/20/2017

This is a simple program, designed to calculate the optimum (maximum deltaV) staging setup given a payload mass, maximum vessel
mass, minimum vessel acceleration, and maximum number of stages.

General usage information:

The progress bar slows down exponentially as the program performs computations. This is because the bar is not measuring
raw computations completed. Rather, it is displaying (roughly) the program's progress through the one-stage configurations,
the two-stage configurations, etc, giving equal bar space to each. However, the later configurations take much more time to
check. Hence the slowing.

Since configurations with more stages take an exponentially greater amount of time to compute than configurations with fewer
stages, it is not recommended to plan vessels with more than 6 (7, if you're patient) stages. The program will work as intended;
it will just take a very long time to do so.

Prerequisites:
.NET framework v2.0 or later

Installation instructions:

1. Download the appropriate archive from the "Releases" page on GitHub. 
2. Unzip the archive anywhere on your hard drive.

And there, you're done. Just run the executable to run the program. You can read the license too, if you really want to.

Copyright (c) 2017, Theodore M. Thomas

This program is licensed under the MIT License
