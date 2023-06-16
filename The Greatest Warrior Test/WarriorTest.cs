using System.Reflection.Emit;
using System.Threading;
using The_Greatest_Warrior;

namespace The_Greatest_Warrior_Test
{
    [TestClass]
    public class WarriorTest
    {

        [TestMethod]
        public void Warrior_ShouldHaveCorrectInitialValues()
        {

            Warrior warrior = new Warrior();

            Assert.AreEqual(1, warrior.level);
            Assert.AreEqual(100, warrior.experience);
            Assert.AreEqual("Pushover", warrior.rank);

        }

        [TestMethod]
        [DataRow(100, 1)]
        [DataRow(200, 2)]
        [DataRow(225, 2)]
        [DataRow(2000, 20)]
        [DataRow(9900, 99)]
        [DataRow(10000, 100)]
        [DataRow(15000, 100)]
        public void TestCalculatorExpLevels(int experience, int levelResult)
        {
            Warrior warrior = new Warrior();
            warrior.experience= experience;
            warrior.calculatorExpLevel(); 
   

            Assert.AreEqual(levelResult, warrior.level);
        }


        [TestMethod]

        [DataRow(1, "Pushover")]
        [DataRow(10, "Novice")]
        [DataRow(25, "Fighter")]
        [DataRow(50, "Sage")]
        [DataRow(100, "Greatest")]
        public void updaterank(int level, string expectedRankName)
        {

            Warrior warrior = new Warrior();
            warrior.level = level;

            warrior.updaterank();
            Assert.AreEqual(expectedRankName, warrior.rank);


        }

    }
}