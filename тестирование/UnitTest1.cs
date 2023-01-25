using NUnit.Framework;
using КурсоваяОП;

namespace тестирование
{
    public class Tests
    {
        
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void Test1()
        {
            string s1 = "ежик";
            string s2 = "котик";
            var dist = new LevenshteinDistance(s1, s2);
            var actual = dist.Levenshtein();
            int expected = 3;
            Assert.AreEqual(expected, actual);
           
        }
        [Test]
        public void Test2()
        {
            string s1 = "бронетранспортер";
            string s2 = "трактор";
            var dist = new LevenshteinDistance(s1, s2);
            var actual = dist.Levenshtein();
            int expected = 11;
            Assert.AreEqual(expected, actual);

        }
        [Test]
        public void Test3()
        {
            string s1 = "тридцать три корабля";
            string s2 = "эскалатор";
            var dist = new LevenshteinDistance(s1, s2);
            var actual = dist.Levenshtein();
            int expected = 16;
            Assert.AreEqual(expected, actual);

        }
        [Test]
        public void Test4()
        {
            string s1 = "cat";
            string s2 = "dog";
            var dist = new LevenshteinDistance(s1, s2);
            var actual = dist.Levenshtein();
            int expected = 3;
            Assert.AreEqual(expected, actual);

        }
    }
}