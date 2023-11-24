using System.Collections.Generic;
using System.Linq;

using Microsoft.Extensions.Configuration;
using Ninject;
using NUnit.Framework;


using KitchenHeaven.FrameWork.DataAccess.Factories;
using KitchenHeaven.FrameWork.DataAccess.Interfaces;
using KitchenHeaven.FrameWork.DataObject.Configuration;
using KitchenHeaven.FrameWork.DataObject.Entities;
using KitchenHeaven.FrameWork.DataObject.Enums;
using Ninject.Parameters;

namespace KitchenHeaven.FrameWork.DataAccess.Tests
{
    internal class ApiAccessUnitTest
    {
        private IKernel _kernel;

        private IAPIAccessFactory _apiAccessFactory;

        [SetUp]
        public void Setup()
        {
            _kernel = new StandardKernel();
            _kernel.Bind<IAPIConfiguration>().ToMethod(ctx =>
            {
                IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("ApiConfig.json", false, true);
                IConfiguration config = builder.Build();
                return config.GetSection("APIConfiguration").Get<APIConfiguration>();
            });
            _kernel.Load("KitchenHeaven.FrameWork.DataAccess.dll");

            IAPIConfiguration apiConfig = _kernel.Get<IAPIConfiguration>();

            _apiAccessFactory = _kernel.Get<IAPIAccessFactory>(new ConstructorArgument("options", apiConfig));

        }

        [TearDown]
        public void Dispose()
        {
        }

        [Test]
        public void GetAreaFilterOK()
        {
            IMealAPIAccess mealAreaAPI = _apiAccessFactory.CreateAPIAccess(FilterType.Area);
            IEnumerable<MealFilterValue> result = mealAreaAPI.GetFilters();
            Assert.IsNotNull(result);
            Assert.Greater(result.ToList().Count, 0);
        }

        [Test]
        public void GetAreaMealOK()
        {
            IMealAPIAccess mealAreaAPI = _apiAccessFactory.CreateAPIAccess(FilterType.Area);
            IEnumerable<Meal> result = mealAreaAPI.SearchMeals(new MealFilterValue() { Name = "French" });
            Assert.IsNotNull(result);
            
            Assert.Greater(result.ToList().Count, 0);
        }

        [Test]
        public void GetAreaMealZeroResult()
        {
            IMealAPIAccess mealAreaAPI = _apiAccessFactory.CreateAPIAccess(FilterType.Area);
            List<Meal> result = mealAreaAPI.SearchMeals(new MealFilterValue() { Name = "chick" }).ToList();

            Assert.AreEqual(result.Count, 0);
        }

        [Test]
        public void GetCategoryFilterOK()
        {
            IMealAPIAccess mealAPI = _apiAccessFactory.CreateAPIAccess(FilterType.Category);
            List<MealFilterValue> result = mealAPI.GetFilters().ToList();

            Assert.Greater(result.Count, 0);
        }

        [Test]
        public void GetCategoryMealOK()
        {
            IMealAPIAccess mealAPI = _apiAccessFactory.CreateAPIAccess(FilterType.Category);
            List<Meal> result = mealAPI.SearchMeals(new MealFilterValue() { Name = "beef" }).ToList();

            Assert.Greater(result.Count, 0);
        }

        [Test]
        public void GetCategoryMealZeroResult()
        {
            IMealAPIAccess mealAPI = _apiAccessFactory.CreateAPIAccess(FilterType.Area);
            List<Meal> result = mealAPI.SearchMeals(new MealFilterValue() { Name = "Vegetalien" }).ToList();

            Assert.AreEqual(result.Count, 0);
        }

        [Test]
        public void SearchMealOK()
        {
            IMealAPIAccess mealAPI = _apiAccessFactory.CreateAPIAccess(FilterType.Meal);
            IEnumerable<Meal> result = mealAPI.SearchMeals(new MealFilterValue() { Name = "beef" });
            Assert.IsNotNull(result);
            Assert.Greater(result.ToList().Count, 0);
        }

        [Test]
        public void SearchMealZeroResult()
        {
            IMealAPIAccess mealAPI = _apiAccessFactory.CreateAPIAccess(FilterType.Meal);
            IEnumerable<Meal> result = mealAPI.SearchMeals(new MealFilterValue() { Name = ";nfjklgeMHQFH" });
            Assert.IsNotNull(result);
            Assert.AreEqual(result.ToList().Count, 0);
        }

        [Test]
        public void GetByIdOK()
        {
            IMealAPIAccess mealAPI = _apiAccessFactory.CreateAPIAccess(FilterType.Meal);
            Meal result = mealAPI.GetMeal("52772");
            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result.Name);
        }

        public void GetByIdKO()
        {
            IMealAPIAccess mealAPI = _apiAccessFactory.CreateAPIAccess(FilterType.Meal);
            Meal result = mealAPI.GetMeal("-1");
            Assert.IsNotNull(result);
            Assert.IsEmpty(result.Name);
        }

    }
}
