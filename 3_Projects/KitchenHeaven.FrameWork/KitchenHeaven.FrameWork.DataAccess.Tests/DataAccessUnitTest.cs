using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using Microsoft.Data.Sqlite;
using NUnit.Framework;
using Dapper;

using KitchenHeaven.FrameWork.DataAccess.Script;
using KitchenHeaven.FrameWork.DataAccess.Tests.scripts;
using KitchenHeaven.FrameWork.DataAccess.UOW;
using KitchenHeaven.FrameWork.DataObject.Entities;

namespace KitchenHeaven.FrameWork.DataAccess.Tests
{
    public class Tests
    {
        private string _dataBaseSource = @".\KitchenHeaven.sqlite";

        private SqliteConnectionStringBuilder _builder;

        [SetUp]
        public void Setup()
        {
            //SQLitePCL.raw.SetProvider(new SQLitePCL.SQLite3Provider_e_sqlite3());

            _builder = new SqliteConnectionStringBuilder();
            _builder.Mode = SqliteOpenMode.ReadWrite;
            _builder.Pooling = false;
            _builder.DataSource = _dataBaseSource;


            SqliteConnectionStringBuilder builder = new SqliteConnectionStringBuilder();
            builder.Mode = SqliteOpenMode.ReadWriteCreate;
            builder.Pooling = false;
            builder.DataSource = _dataBaseSource;
            using (SqliteConnection sqlite2 = new SqliteConnection(builder.ToString()))
            {
                sqlite2.Open();

                sqlite2.Execute(KitchenHeavenSqlCreation.SqlInitialization);
                sqlite2.Execute(InitData.initData);
                sqlite2.Close();
            }
        }

        [TearDown]
        public void Dispose()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            File.Delete(_dataBaseSource);
        }



        [Test]
        public void GetAllRestaurant()
        {
            using (IUnitOfWork iu = new UnitOfWork())
            {
                iu.Begin(_builder.ToString(), false);
                IEnumerable<Restaurant> restaurants = iu.GetRestaurantDataAccess().GetAll();
                iu.Commit();
                Assert.AreEqual(restaurants.ToList().Count, 3);
            }
        }

        [Test]
        public void AddRestaurantOK()
        {
            using (IUnitOfWork iu = new UnitOfWork())
            {
                iu.Begin(_builder.ToString(), false);
                int restaurantid = iu.GetRestaurantDataAccess().Add(
                    new Restaurant()
                    {
                        Name = "test unit restaurant",
                        BusinessIdentifier = "GDFUKD",
                        Address = "no address ",
                        AddressComplement = "no address ",
                        CityCode = "94100",
                        CityName = "my city"
                    });
                iu.Commit();
                Assert.Greater(restaurantid, 0);
            }
        }

        [Test]
        public void AddRestaurantKONameNull()
        {
            using (IUnitOfWork iu = new UnitOfWork())
            {
                iu.Begin(_builder.ToString(), false);
                Assert.Throws<SqliteException>(() =>
                {
                    iu.GetRestaurantDataAccess().Add(
                                                new Restaurant()
                                                {
                                                    Name = null,
                                                    BusinessIdentifier = "GDFUKD",
                                                    Address = "no address ",
                                                    AddressComplement = "no address ",
                                                    CityCode = "94100",
                                                    CityName = "my city"
                                                });
                });
                iu.Commit();

            }
        }

        [Test]
        public void AddRestaurantKOBusinessIdentifierEmpty()
        {
            using (IUnitOfWork iu = new UnitOfWork())
            {
                iu.Begin(_builder.ToString(), false);
                Assert.Throws<SqliteException>(() =>
                {
                    iu.GetRestaurantDataAccess().Add(
                                                new Restaurant()
                                                {
                                                    Name = "not null",
                                                    BusinessIdentifier = null,
                                                    Address = "no address ",
                                                    AddressComplement = "no address ",
                                                    CityCode = "94100",
                                                    CityName = "my city"
                                                });
                });
                iu.Commit();

            }
        }

        [Test]
        public void SearchrestaurantBusinessIdentifierManager()
        {
            using (IUnitOfWork iu = new UnitOfWork())
            {
                iu.Begin(_builder.ToString(), false);

                IEnumerable<Restaurant> lstRestaurants = iu.GetRestaurantDataAccess().GetAllByCriteria(new RestaurantSearchCriteria() { 
                    Name= String.Empty,
                    BusinessIdentifier = "2",
                    Address = String.Empty,
                    AddressComplement= String.Empty,
                    CityCode = String.Empty,
                    CityName= String.Empty,
                    Manager = "USER2"
                });
                iu.Commit();

                Assert.AreEqual(lstRestaurants.Count(), 2);
            }
        }

        [Test]
        public void GetRestaurantMenu()
        {
            using (IUnitOfWork iu = new UnitOfWork())
            {
                iu.Begin(_builder.ToString(), false);

                IEnumerable<Meal> lstMeal = iu.GetMealDataAccess().GetByRestaurantId(1);

                iu.Commit();
                Assert.AreEqual(2, lstMeal.Count());
            }
        }

        [Test]
        public void GetMealByExternalIdAndRestaurantId()
        {
            using (IUnitOfWork iu = new UnitOfWork())
            {
                iu.Begin(_builder.ToString(), false);

                Meal meal = iu.GetMealDataAccess().GetByExternalIdAndRestaurantId("37", 2);

                iu.Commit();
                Assert.AreEqual("Meal Test 2", meal.Name);
                Assert.AreEqual("Vegan", meal.Category);
                Assert.AreEqual("American", meal.Area);
                Assert.AreEqual(null, meal.Instructions);
                Assert.AreEqual(null, meal.Image);
            }
        }

    }
}