using Day20_MSTest_MoodAnalyser_Assign;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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












        [TestMethod]
        public void GivenMoodAnalyseClassName_ShouldReturnMoodAnalyseObject()
        {
            string message = null;
            //follow AAA i.e Arrange Act Assert
            object expected = new MoodAnalyser1(message);
            object obj = MoodAnalyserFactory.CreateMoodAnalyser("MoodAnalyserAppWithCore.MoodAnalyser1", "MoodAnalyser1");
            //expected.Equals(obj);
            Assert.AreNotEqual(expected, obj);
        }
        [TestMethod]
        public void GivenMoodAnalyseClassName_ShouldReturnMoodAnalyseObject_UsingParameterizedConstructor()
        {
            object expected = new MoodAnalyser1("HAPPY");
            object obj = MoodAnalyserFactory.CreateMoodAnalyseUsingParameterizedConstructor("MoodAnalyserAppWithCore.MoodAnalyser1", "MoodAnalyser1", "SAD");
            //expected.Equals(obj);
            Assert.AreNotEqual(expected, obj);
        }

        [TestMethod]
        public void GivenMoodHappy_ShouldReturnHappy()
        {
            MoodAnalyser1 obj = new MoodAnalyser1("HAPPY");
            string result = obj.analyseMood();
            Assert.AreEqual("HAPPY", result);

        }
        [TestMethod]
        [ExpectedException(typeof(MoodAnalyserCustomException))]
        public void GivenMoodNull_ShouldThrowException()
        {
            MoodAnalyser1 obj = new MoodAnalyser1(null);
            string result = obj.analyseMood();
            //Assert.AreEqual("HAPPY", result);

        }
        [TestMethod]
        public void GivenMoodHappy_ShouldReturnNull()
        {
            MoodAnalyser1 obj = new MoodAnalyser1("null");
            string result = obj.analyseMood();
            Assert.AreEqual("HAPPY", result);
        }
    }

}

    