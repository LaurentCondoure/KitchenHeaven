Title: Add new restaurant in KitchenHeaven.

As an administrator,
I want to add restaurants to KitchenHeaven,
so that I can find it in the restaurant list.

Scenario 1: New restaurant should be added to restaurant list.
Given that a restaurant is fully filled 
when I had restaurant to KitchenHeaven,
then I should found it in the restaurant list.

Scenario 2: New restaurant should have a name and a businessidentifier.
Given that a manager start a new restaurant 
and provide me only the definitive adress
when I had restaurant to KitchenHeaven,
then I should receive an error message
and I'm informed name and businessIdentifier are mandatory.

Scenario 3: Add restaurant request should be fill correctly.
Given that a request content is not respected
when I had restaurant to KitchenHeaven,
then I should receive an error message
and I'm informed of the bad request.

Scenario 4: Online Restaurant should be added to restaurant list.
Given that a restaurant is online seller
and it doesn't have all informations
when I had restaurant to KitchenHeaven,
then the request is valid 
and I should found it in the restaurant list.

Scenario 5: Restaurant should be added to restaurant list once.
Given that a restaurant is fully filled 
and it already had been added to KitchenHeaven
when I had restaurant to KitchenHeaven,
then I should receive an error message
and I'm informed the restaurant already have been added.

Scenario 6: Error should be returned to user.
Given that a restaurant is fully and correctly filled 
and I had restaurant to KitchenHeaven
when an error occured,
then I should receive an error message
and add process can be correclty perform later.

