using System;
using System.Collections.Generic;
using System.Text;

namespace KitchenHeaven.FrameWork.DataAccess.Script
{
    public class KitchenHeavenSqlCreation
    {
        public const string SqlInitialization =
			@"
                CREATE TABLE IF NOT EXISTS
Ingredient (
	id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	externalId varchar(10),
	name varchar(50) NOT NULL,
	description text
);

CREATE TABLE IF NOT EXISTS
Meal (
	id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	externalId varchar(10),
	name varchar(50) NOT NULL,
	category varchar(15),
	area varchar(10),
	instructions text,
	image varchar(255),
	miniature varchar(255)
);

CREATE TABLE IF NOT EXISTS
MealIngredients (
	mealId INTEGER NOT NULL,
	ingredientId INTEGER NOT NULL,
	measure varchar(15),
	FOREIGN KEY (mealId) REFERENCES Meal(id),
	FOREIGN KEY (ingredientId) REFERENCES Ingredient(id)
);

CREATE TABLE IF NOT EXISTS
Restaurant (
	id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	name varchar(30) NOT NULL,
	businessIdentifier varchar(20) NOT NULL,
	address varchar(76),
	addressComplement varchar(76),
	cityCode varchar(10),
	cityName varchar(50),
	manager varchar(10)
);

CREATE TABLE IF NOT EXISTS
Menu (
	restaurantId INTEGER NOT NULL,
	mealId INTEGER NOT NULL,
	FOREIGN KEY (mealId) REFERENCES Meal(id),
	FOREIGN KEY (restaurantId) REFERENCES Restaurant(id)

);
";
    }
}
