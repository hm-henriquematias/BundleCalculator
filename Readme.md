# Bundle calculator


[![en](https://img.shields.io/badge/lang-en-red.svg)](https://github.com/hm-henriquematias/BundleCalculator/blob/main/Readme.md)
[![pt-br](https://img.shields.io/badge/lang-pt--br-green.svg)](https://github.com/hm-henriquematias/BundleCalculator/blob/main/README.pt-br.md)
[![pt-pt](https://img.shields.io/badge/lang-pt-red.svg)](https://github.com/hm-henriquematias/BundleCalculator/blob/main/README.pt.md)
[![es](https://img.shields.io/badge/lang-es-yellow.svg)](https://github.com/hm-henriquematias/BundleCalculator/blob/main/README.es.md)
[![fr](https://img.shields.io/badge/lang-fr-blue.svg)](https://github.com/hm-henriquematias/BundleCalculator/blob/main/README.fr.md)


` You can check tests in Github actions tab :) `


### What is a bundle?
Before starting to describe the application, it is necessary to define what a bundle is. 
A bundle is an item made up of one or more items. For example, a bicycle is made up of 
wheels, pedals, among other items.

### Description
This application aims to calculate the number of possible bundles from a stock of available 
items

### Data
Data.json is a file that informs the rules for bundles, items and their respective quantities

### Division of the solution

The solution is divided into two projects, a main project, which is a console application, 
and a testing project that contains unit tests and integration tests.

### Why just one project? (besides testing)
It is common to see dotnet solutions with multiple projects so that each layer of the application 
is well isolated, avoiding coupling between layers, and maintaining good practices.

But let's be honest, for the purposes of this application, anything other than the division into 
folders that we have here is just **overengineering**.

### About the main algorithm
1. Receives the name of a bundle
2. Validates whether the informed bundle exists
    a. If not, just ignore it and return zero
    b. If there is, continue with and scroll through the required items (see step 3)
3. Checks if the requested item is a bundle composed of other items
    a. If so, call this same validation returning to step 1
    b. If not, check if the item is in stock, and calculate how many can be used and proceed to step 4
4. Stores how many of those bundles are possible to make with each item category, and returns the smallest, so that an incomplete bundle is not created

# About
### Author
Henrique Matias

### Used technologies
- Language: C#
- Framework: .NET Core 7
- Application Type: Console
