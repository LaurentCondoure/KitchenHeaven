INSERT INTO Restaurant
                ([name], [businessIdentifier], [Address], [AddressComplement], [cityCode], [cityName], [manager])
              Values
                ("Restaurant Test 1", "2", NULL, NULL, NULL, NULL, "USER1");

INSERT INTO Restaurant
                ([name], [businessIdentifier], [Address], [AddressComplement], [cityCode], [cityName], [manager])
              Values
                ("Restaurant Test 2", "22", NULL, NULL, NULL, NULL, "USER2");

INSERT INTO Restaurant
                ([name], [businessIdentifier], [Address], [AddressComplement], [cityCode], [cityName], [manager])
              Values
                ("Restaurant Test 2", "222", NULL, NULL, NULL, NULL, "USER2");

INSERT INTO Meal
                ([externalId], [name], [Category], [Area], [instructions], [image])
              VALUES
                ("36", "Meal Test 1", "Beef", "French", NULL, NULL);

INSERT INTO Meal
                ([externalId], [name], [Category], [Area], [instructions], [image])
              VALUES
                ("37", "Meal Test 2", "Vegan", "American", NULL, NULL);

INSERT INTO Menu
                ([restaurantId], [mealId])
              VALUES
                (1, 1);
INSERT INTO Menu
                ([restaurantId], [mealId])
              VALUES
                (1, 2);

INSERT INTO Menu
                ([restaurantId], [mealId])
              VALUES
                (2, 2);

INSERT INTO Ingredient
                ([externalId], [name], [description])
              VALUES
                ("5", "Ingredient 1", '');
INSERT INTO Ingredient
                ([externalId], [name], [description])
              VALUES
                ("50", "Ingredient 2",'');
INSERT INTO Ingredient
                ([externalId], [name], [description])
              VALUES
                ("51", "Ingredient 4",'');
INSERT INTO Ingredient
                ([externalId], [name], [description])
              VALUES
                ("510", "Ingredient 5",'');
