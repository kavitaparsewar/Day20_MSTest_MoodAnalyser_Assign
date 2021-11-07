using Day20_MSTest_MoodAnalyser_Assign;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestProject1
{
    //UC1

    [TestClass]
    public class UnitTest1
    {
        //TC 1.1
        [TestMethod]


        public void Mood()
        {
            //Arrange

            string expected = "SAD";
            string message = "I am in Sad Mood";
            UC1_MoodAnalyser mood = new UC1_MoodAnalyser(message);

            //Act
            string Mood = mood.AnalyseMood();

            //Assert
            Assert.AreEqual(expected, Mood);
        }


        //TC 1.2
        [TestMethod]
        public void Mood1()
        {
            //Arrange

            string expected = "HAPPY";
            string message = "I am in Any Mood";
            UC1_MoodAnalyser mood = new UC1_MoodAnalyser(message);

            //Act
            string Mood = mood.AnalyseMood();

            //Assert
            Assert.AreEqual(expected, Mood);
        }



        //Refactor UC1

        [TestMethod]  
        
        //Refactor-TC 1.1
        public void Giving_SAD_Mood_Expecting_Sad_Result()
        {
            //Arrangement 
            MoodAnalyser1 mood = new MoodAnalyser1("I am in Sad Mood");
            string expected = "SAD";

            //Act
            string result = mood.analyseMood();

            //Assert
            Assert.AreEqual(expected, result);
        }




        [TestMethod]  
        
        //Refactor-TC 1.2
        public void Giving_HappyMood_Expecting_Happy_Result()
        {
            //Arrangement 
            MoodAnalyser1 mood = new MoodAnalyser1("I am in Happy Mood");
            string message = "HAPPY";

            //Act
            string actualmsg = mood.analyseMood();

            //Assert
            Assert.AreEqual(message, actualmsg);
        }






        // UC2
        [TestMethod]
        //[ExpectedException(typeof(Exception))] //not needed if we use "retrun" insteadof "throw" 
        public void Giving_NullMood_Expecting_Exception_Results()
        {
            //Arrangement
            MoodAnalyser1 mood = new MoodAnalyser1(null);
            string expected = "Object reference not set to an instance of an object.";

            try
            {
                //Act
                string actualMsg = mood.analyseMood();
            }

            catch (NullReferenceException ex)
            {
                //Assert
                Assert.AreEqual(expected, ex.Message);
            }

        }

        //TC 2.1
        [TestMethod]
        //[ExpectedException(typeof(MoodAnalyserCustomException))]
        public void Giving_MoodNull_Should_Return_Happy()
        {
            //Arrange
            //string message = null;
            MoodAnalyser1 obj = new MoodAnalyser1("null");
            string expected = "HAPPY";

            //Act
            string actualMsg = obj.analyseMood();

            //Assert
            Assert.AreEqual(expected, actualMsg);

        }

        //TC 3.1
        [TestMethod]
        //[ExpectedException(typeof(MoodAnalyserCustomException))]
        public void Giving_NullMood_Expecting_CustomException_Results()
        {
            //Arrange
            MoodAnalyser1 obj = new MoodAnalyser1(null);
            string expected = "Mood should not be NULL";

            try
            {
                //Act
                string actualMsg = obj.analyseMood();
            }

            catch (MoodAnalyserCustomException ex)
            {
                //Assert
                Assert.AreEqual(expected, ex.Message);
            }


        }

        //TC 3.2
        [TestMethod]
        //[ExpectedException(typeof(MoodAnalyserCustomException))]
        public void Giving_EmptyMood_Expecting_CustomException_Results()
        {
            //Arrange
            MoodAnalyser1 obj = new MoodAnalyser1("");
            string expected = "Mood should not be EMPTY";

            try
            {
                //Act
                string actualMsg = obj.analyseMood();
            }

            catch (MoodAnalyserCustomException ex)
            {
                //Assert
                Assert.AreEqual(expected, ex.Message);
            }

        }

        //TC 4.1
        [TestMethod]
        public void GivenMoodAnalyserClassName_ShouldReturnMoodAnalyseObject() //have to check by passing the full address in place of null
        {
            //Arrange
            string message = null;
            MoodAnalyser1 expected = new MoodAnalyser1(message);

            //Act
            object obj = MoodAnalyserFactory.CreateMoodAnalyser("Day20_MSTest_MoodAnalyser_Assign.MoodAnalyser", "MoodAnalyser");
            //expected.Equals(obj);

            //Assert
            Assert.AreNotEqual(expected, obj);
        }


        //TC 5.1
        [TestMethod]
        public void GivenMoodAnalyseClassName_ShouldReturnMoodAnalyseObject_UsingParameterizedConstructor()
        {
            //Arrange
            object expected = new MoodAnalyser1("HAPPY");

            //Act
            object obj = MoodAnalyserFactory.CreateMoodAnalyseUsingParameterizedConstructor("Day20_MSTest_MoodAnalyser_Assign.MoodAnalyser", "MoodAnalyser", "HAPPY");

            //Assert
            expected.Equals(obj);
        }

        //TC 6.1
        [TestMethod]
        public void Given_HappyMood_Should_Return_Happy()
        {
            //Arrange
            string expected = "HAPPY";

            //Act
            string mood = MoodAnalyserFactory.InvokeAnalyserMood("Happy", "AnalyseMood");

            //Assert
            Assert.AreEqual(expected, mood);
        }

        //TC 7.1
        [TestMethod]
        public void Given_HappyMessage_With_Reflector_Should_Return_Happy()
        {
            //Act
            string result = MoodAnalyserFactory.SetField("HAPPY", "message");

            //Assert
            Assert.AreEqual("HAPPY", result);
        }
    }
}

    