Title: Consult meal details in KitchenHeaven.

As an administrator or Manager,
I want to consult meals detail,
so that I can compose a menu.

Scenario 1: Restaurant's Menu details can be consult.
Given that I consult the page data of a restaurant
and that a menu is composed of meals 
when I ask to view details of a meal,
then I should see his name
and his category
and his area
and an illustration
and the instruction
and a the list of ingredients.

Scenario 2: .
Given that I searched meals 
and I want to consult details of found meals
when I ask to view details of a meal,
then I should see his name
and his category
and his area
and an illustration
and the instruction
and a the list of ingredients.

Scenario 3: unavailable Searched Meal's details should return an error.
and I want to consult details of found meals
and source API is not available
when I ask to view details of a meal,
then I should receive an error message
and I should be informed that the source API is not available

Scenario 4: Restaurant's Menu details should always be available.
Given that I consult the page data of a restaurant
and that a menu is composed of meals
and source API is not available
when I ask to view details of a meal,
then I should see his name
and his category
and his area
and the instruction
and a the list of ingredients.

Scenario 5: Restaurant's Menu details should return message.
Given that I consult the page data of a restaurant
and that a menu is composed of meals
and errors occur on other pages
and data cannot be retrieve from database
when I ask to view details of a meal,
then I should receive an error message
and I should be informed that the source API is not available

Scenario 6: Uncorrect meal's detail request should raise an error.
Given that meal's detail request can be invalid
when I ask to view details of a meal,
then I should receive an error message
and I should be informed why request is not correct