# Roller-Coaster
This project handles the queue in roller coaster ride and efficiently fills seats to maximize efficiency. 

# Setup: 
The Roller Coaster has capacity of 20. 
There are 10 carts and each cart has two seats 

# Rules:
A child must always be accompnied by an adult from the same group when on the Roller Coaster.  
There can't be more children then adults in a group when entering the queue.  
You can not bribe if you are first in the line.  
The group can not be no more than 20 people.  
This Roller Coaster will try to get as many people on board as possible.  
An adult from one group may be sitting with an adult from another group to maximize efficiency.  

# Commands:
Enter h or help to display commands and rules  
Enter e or exit to exit the program  
Enter d or display to display the queue  
Enter b <groupname> to bribe and move in front of the group ahead of you  
Enter r <groupname> to remove the group from queue  
Enter m <groupname> <adults> <Children> to make group  
Enter ride to fill Roller Coaster with riders  

# Sample Input Command --> Description
m group1 19 4 --> Make a group with name 'group1' consisting of 19 adults and 4 children, but this command will fail as the group can only have 20 people max  
m group2 10 9 --> Make a group with name 'group2' consisting of 10 adults and 9 children  
m group3 10 11 --> Make a group with name 'group3' consisting of 10 adults and 11 children, but this command will fail as you can not have more children than adults  
m group4 1 0 --> Make a group with name 'group4' consisting of one adult  
m group5 2 0 --> Make a group with name 'group5' consisting of 2 adults  
d --> display all the groups in the queue  
b group5 --> moves 'group5' up the queue to second place from third place  
m group6 5 2 --> Make a group with name 'group6' consisting of 5 adults and 2 children   
r group6 --> remove 'group6' from the queue  
d --> display all the groups in the queue  
ride --> trys to fill as many people as possible on the Roller Coaster.   

# Note: 'group2' with 19 people and 'group4' will with one person will go on the Roller Coaster. It skips 'group3' as there is only one seat remaining while, they have two people in their group.  
