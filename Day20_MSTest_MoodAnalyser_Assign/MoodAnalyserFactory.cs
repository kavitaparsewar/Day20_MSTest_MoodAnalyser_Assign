using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace Day20_MSTest_MoodAnalyser_Assign
{
    public class MoodAnalyserFactory
    {
        private string message;
        public MoodAnalyserFactory(string message)
        {
            this.message = message;
        }

        // UC 4
        public static object CreateMoodAnalyser(string className, string constructorName)
        {
            string pattern = @"." + constructorName + "$";
            Match result = Regex.Match(className, pattern);
            if (result.Success)
            {
                try
                {

                    Assembly executing = Assembly.GetExecutingAssembly();
                    Type moodAnalyseType = executing.GetType(className);
                    return Activator.CreateInstance(moodAnalyseType);
                }
                catch (ArgumentNullException)
                {
                    throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_CLASS, "Class not found");

                }


            }
            else
            {
                throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_METHOD, "Constructor is not found");
            }
        }

        //below code is UC-5
        public static object CreateMoodAnalyseUsingParameterizedConstructor(string className, string constructorName, string message)
        {
            Type type = typeof(MoodAnalyser1);
            if (type.Name.Equals(className) || type.FullName.Equals(className))
            {
                if (type.Name.Equals(constructorName))
                {
                    ConstructorInfo ctor = type.GetConstructor(new[] { typeof(string) });
                    object instance = ctor.Invoke(new object[] { message });
                    return instance;
                }
                else
                {
                    throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_METHOD, "Constructor is not found");
                }
            }
            else
            {
                throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_CLASS, "Class not found");

            }
        }


        //below code is UC6


        public static string InvokeAnalyserMood(string message, string methodName)
        {
            try
            {
                Type type = Type.GetType("Day20_MoodAnalyser_Test_Assignment.MoodAnalyser");
                object moodAnalyserObject = MoodAnalyserFactory.CreateMoodAnalyseUsingParameterizedConstructor("Day20_MoodAnalyser_Test_Assignment.MoodAnalyser", "MoodAnalyser", message);
                MethodInfo analyseMoodInfo = type.GetMethod(methodName);
                object mood = analyseMoodInfo.Invoke(moodAnalyserObject, null);
                return mood.ToString();
            }
            catch (NullReferenceException)
            {
                throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_METHOD, "Method is Not Found");
            }
        }


        //below code is UC7


        public static string SetField(string message, string fieldName)
        {
            try
            {
                MoodAnalyser1 moodAnalyser = new MoodAnalyser1();
                Type type = typeof(MoodAnalyser1);
                FieldInfo field = type.GetField(fieldName, BindingFlags.Public | BindingFlags.Instance);
                if (message == null)
                {
                    throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_FIELD, "Message should not be null");
                }
                field.SetValue(moodAnalyser, message);
                return moodAnalyser.Message;
            }
            catch (NullReferenceException)
            {
                throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_FIELD, "Field is not Found");
            }
        }
    }


}
