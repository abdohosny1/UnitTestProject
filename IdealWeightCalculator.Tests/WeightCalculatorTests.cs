using FakeItEasy;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace IdealWeightCalculator.Tests
{
    [TestClass]
    public class WeightCalculatorTests
    {

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            Console.WriteLine("in class Initialze");
        }

        [ClassCleanup]
        public static void ClassCleanup() 
        { 
        }
        [TestMethod]
        [Description("This is the test about checking if the idel body weight  +" +
            " of a man with 180 cm in hieght is equal to 72.5  ")]
        [Owner("Abdelaliem Hosny")]
        [Priority(1)]
        [TestCategory("weightCategory")]
        public void GetIdealBodyWeight_With_Sex_M_And_Height_180_Return_72_5()
        {
            //Arrange
            WeightCalculator sut=new WeightCalculator(new FakeDataRepository())
            {
                Sex='m',
                Height=180
            };
            //Act
            double actual = sut.GetIdealBodyWeight();
            double expected = 72.5;

            //Assert
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        [Description("This is the test about checking if the idel body weight  +" +
            " of a woman with 180 cm in hieght is equal to 65  ")]
        [Owner("Abdelaliem Hosny")]
        [Priority(1)]
        [TestCategory("weightCategory")]
        [Ignore]
        public void GetIdealBodyWeight_With_Sex_W_And_Height_180_Return_65()
        {
            //Arrange
            WeightCalculator sut = new WeightCalculator(new FakeDataRepository())
            {
                Sex = 'w',
                Height = 180
            };
            //Act
            double actual = sut.GetIdealBodyWeight();
            double expected = 65;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetIdealBodyWeight_With_BadSex_And_Height_180_Throw_Expection()
        {
            //Arrange
            WeightCalculator sut = new WeightCalculator(new FakeDataRepository())
            {
                Sex = 'r',
                Height = 180
            };
            //Act
            double actual = sut.GetIdealBodyWeight();
            double expected = 0;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Assert_Tests()
        {
            //   Assert.AreEqual(100, 90 + 10);
            // Assert.AreNotEqual(100, 90 );

            WeightCalculator ca1 = new WeightCalculator(new FakeDataRepository());
            WeightCalculator ca2 = ca1; // new WeightCalculator();

            // Assert.AreSame(ca1, ca2);
            // Assert.AreNotSame(ca1, ca2);

            Assert.IsInstanceOfType(ca1, typeof(WeightCalculator));
            ca1 = null;
            Assert.IsNull(ca1);
            Assert.IsTrue(100 == 90 + 10);
        }

        [TestMethod]
        public void String_Assert_Tests()
        {
            string name = "Abdo";

            StringAssert.Contains(name,"b");
            StringAssert.EndsWith(name,"do");

            //use fluentAssertion
            name.Should().Contain("b");

        }

        [TestMethod]
        public void Collection_Assert_Tests()
        {
           List<string> list = new List<string>() { "abdo","maedo","ali"};

            CollectionAssert.AllItemsAreNotNull(list);
            CollectionAssert.Contains(list,"abdo");
        }

        [TestMethod]
        public void FluentAssertion_Tests()
        {
            string name = "Abdo";
            name.Should().StartWith("A");

            int num = 10;
            num.Should().BeGreaterThan(8);
            num.Should().BeLessThanOrEqualTo(10);

            List<string> list = new List<string>() { "abdo", "maedo", "ali" };
            list.Should().HaveCount(3);
        }

        [TestMethod]
        public void GetIdelBodyWithFromDateSource_WithGoodInput_Return_Correct_Result()
        {
            //Arrange
            WeightCalculator sut = new WeightCalculator(new FakeDataRepository());

            //Act
            List<double> actual = sut.GetIdelBodyWithFromDateSource();
            double[] expected = { 62.5 , 62.75, 74 };
            //Assert
          //  CollectionAssert.AreEqual(expected, actual);
            actual.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void GetIdelBodyWithFromDateSource_Using_Moq()
        {
            //Arrange 
            List<WeightCalculator>  Weight = new List<WeightCalculator>()
            {
            new WeightCalculator() { Height = 175, Sex = 'w' },
            new WeightCalculator() { Height = 167, Sex = 'm' },
            };

            Mock<IDataRepository> mock= new Mock<IDataRepository>();
            mock.Setup(repo => repo.GetWeightCalculator()).Returns(Weight);


            WeightCalculator weight = new WeightCalculator(mock.Object);

            var actual = weight.GetIdelBodyWithFromDateSource();

            double[] expected = { 62.5,62.75};

            actual.Should().BeEquivalentTo(expected);
        }


        [TestMethod]
        public void GetIdelBodyWithFromDateSource_Using_FakeItEasy()
        {
            //Arrange 
            List<WeightCalculator> Weight = new List<WeightCalculator>()
            {
            new WeightCalculator() { Height = 175, Sex = 'w' },
            new WeightCalculator() { Height = 167, Sex = 'm' },
            };

            IDataRepository mock =A.Fake<IDataRepository>();
            A.CallTo(() => mock.GetWeightCalculator()).Returns(Weight);


            WeightCalculator weight = new WeightCalculator(mock);

            var actual = weight.GetIdelBodyWithFromDateSource();

            double[] expected = { 62.5, 62.75 };

            actual.Should().BeEquivalentTo(expected);
        }

        //Data Driven Test
        [DataTestMethod]
        [DataRow(175,'w', 62.5) ]
        [DataRow(167,'m', 62.75) ]
        [DataRow(182,'m', 74) ]
        public void Working_With_Data_Driven_Test(double height,char sex,double expected)
        {
            WeightCalculator weightCalculator = new WeightCalculator 
            { 
                Height=height,
                Sex=sex
            };
             var actual= weightCalculator.GetIdealBodyWeight();
           // actual.Should().Be(expected);
            Assert.AreEqual(expected, actual);

        }
        //Dynamic Data Driven Test
        [DataTestMethod]
        [DynamicData(nameof(TestCase),DynamicDataSourceType.Method)]
        public void Working_With_Dynamic_Driven_Test(double height, char sex, double expected)
        {
            WeightCalculator weightCalculator = new WeightCalculator
            {
                Height = height,
                Sex = sex
            };
            var actual = weightCalculator.GetIdealBodyWeight();
            // actual.Should().Be(expected);
            Assert.AreEqual(expected, actual);

        }
        public static List<object[]> TestCase()
        {
            return new List<object[]>()
            {
                new object[] {175,'w',62.5},
                new object[] {167,'m',62.75},
                new object[] {182,'m',74},
            };
        }

        //TDD  ==>Test Driven Development 

        [TestMethod]
        public void Validate_With_BadSex_Return_False()
        {
            WeightCalculator weightCalculator = new WeightCalculator();
            weightCalculator.Sex = 'r';

            bool actual = weightCalculator.Validate();  

            actual.Should().BeFalse();


        }
    }
}
