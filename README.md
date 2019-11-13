# RandomShopGen

## Introduction

The goal of this project to create an application that can injest formatted data that contains specific items and create a randomized inventory for a shop keeper NPC. This will allow a user to be able to create town shops quickly so the DM will have more time to work on other aspects of their game. This shop genorator will also be able to start with a specific set of items so that if a shop needs a certain set of items, then they can be gaurenteed to be picked first before the filler is selected.

## Usage

- random list: ./shop-genorator.exe -r "C:\RandomItems.csv" 1000g (randomly selects items from the provided csv while using 1000 gold as it starting amount.)
- specific list: ./shop-genorator.exe -s "C:\SpecificItems.csv" 100s (picks the specific items from the provided csv until it runs out of money.)
- combined list: ./shop-genorator.exe -c "C:\SpecificItems.csv" "C:\RandomItems.csv" 1000g (performs both previous functions using the first file as the specific list and the second as the filler list.)
