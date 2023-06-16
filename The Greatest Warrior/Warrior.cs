using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Greatest_Warrior
{
    using System;
    using System.Threading;

    public class Warrior
    {
        //
        public int level { get; set; }
        public int experience { get; set; }
        public string rank { get; set; }

        public int expLevelRequis = 100;
        public Warrior()
        {
            level = 1;
            experience = 100;
            rank = "Pushover";
        }
        public string Battle(Warrior warrior, int enemyLevel)
        {
            if (enemyLevel < 1 || enemyLevel > 100)
            {
                return "Invalid level";
            }

            int levelDifference = CalculateLevelDifference(warrior, enemyLevel);
            int experienceGained = CalculateExperienceGained(levelDifference, warrior.rank);

            warrior.experience += experienceGained;
            warrior.calculatorExpLevel();
            warrior.updaterank();

            return DetermineBattleResult(warrior.level, enemyLevel);
        }

        private int CalculateLevelDifference(Warrior warrior, int enemyLevel)
        {
            return enemyLevel - warrior.level;
        }

        private int CalculateExperienceGained(int levelDifference, string warriorRank)
        {
            int experienceGained;

            if (levelDifference == 0)
            {
                experienceGained = 10;
            }
            else if (levelDifference == -1)
            {
                experienceGained = 5;
            }
            else if (levelDifference <= -2)
            {
                experienceGained = 0;
            }
            else if (levelDifference >= 1 && levelDifference < 5 && warriorRank != "Greatest")
            {
                experienceGained = 20 * levelDifference * levelDifference;
            }
            else
            {
                experienceGained = 0;
            }

            return experienceGained;
        }
        private string DetermineBattleResult(int warriorLevel, int enemyLevel)
        {
            int levelDifference = warriorLevel - enemyLevel;

            if (levelDifference >= 2)
            {
                return "Easy fight";
            }
            else if (levelDifference == 1 || warriorLevel == enemyLevel)
            {
                return "A good fight";
            }
            else
            {
                return "An intense fight";
            }
        }

            public void calculatorExpLevel()
        {
            if (level < 100)
            {
                if (experience > 10000)
                {
                    level = 100;
                }
                else
                {
                    level = experience / expLevelRequis;
                }
            }

        }
       

        public void updaterank()
        {

            int rankenum =(int) Decimal.Truncate(level / 10) + 1;
            var actualenum = (Rank)rankenum;
            rank=Enum.GetName(typeof(Rank), actualenum);
        

        }
      
    }
}
