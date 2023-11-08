// See https://aka.ms/new-console-template for more information

using TheMealDb_API;

Parameters parameters = new Parameters();
parameters.Init();

TheMealDb_Service theMealDb_Service = new TheMealDb_Service(parameters);

theMealDb_Service.ListMealsByFirstLetter("f");
theMealDb_Service.ListMealsByFirstLetter("fish");

theMealDb_Service.GetRandomMeal();

theMealDb_Service.SearchMealByName("");
theMealDb_Service.SearchMealByName("chocolate");
theMealDb_Service.SearchMealByName("ocola");

theMealDb_Service.SearchMealByName("Moussaka");
theMealDb_Service.SearchMealByName("ussakk");

theMealDb_Service.GetMealsDetailById("52772");
theMealDb_Service.GetMealsDetailById("527720098");

theMealDb_Service.GetAreasList();

theMealDb_Service.GetCategoriesList();
theMealDb_Service.ListAllMealsCategories();

theMealDb_Service.GetIngredientsList();

theMealDb_Service.GetMealsListByIngredient("Beef");
theMealDb_Service.GetMealsListByIngredient("eef");
theMealDb_Service.GetMealsListByIngredient("");

theMealDb_Service.GetMealsListByCategory("Vegan");
theMealDb_Service.GetMealsListByCategory("ega");
theMealDb_Service.GetMealsListByCategory("");

theMealDb_Service.GetMealsListByArea("French");
theMealDb_Service.GetMealsListByArea("rench");
theMealDb_Service.GetMealsListByArea("");








