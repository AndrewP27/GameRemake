using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PokemonRemake
{
    public class StatsManager
    {
        Random gen = new Random();

        private string name = "";
        private int typeNum1 = -1;
        private int typeNum2 = -1;

        //private bool isTraded = false;
        //private bool hasLucky = false;

        private int hp = 0;
        private double remaindingHP = 0;
        private int idNum = 0;
        private int lv = 0;
        private int speed = 0;
        private int attack = 0;
        private int defense = 0;
        private int specialAttack = 0;
        private int specialDefense = 0;

        private int atkIV = 0;
        private int defIV = 0;
        private int spdIV = 0;
        private int specAIV = 0;
        private int specDIV = 0;
        private int hpIV = 0;

        private int atkEV = 0;
        private int defEV = 0;
        private int spdEV = 0;
        private int specAEV = 0;
        private int specDEV = 0;
        private int hpEV = 0;

        private int baseHp = 0;
        private int baseAtk = 0;
        private int baseDef = 0;
        private int baseSpecA = 0;
        private int baseSpecD = 0;
        private int baseSpd = 0;

        private double weight = 0;

        //private double totalEXP = 0;
        private double expNeeded = 0;
        private int expType = 0;
        private int baseExp = 0;
        //1 == Fast
        //2 == Medium Fast
        //3 == Medium Slow
        //4 == Slow

        //Exp End Game Variables
        //private double a = 0;
        //private double e = 0;
        //private double t = 0;
        //private double s = 0;

        public StatsManager(int aIDNum, int startLv)
        {
            idNum = aIDNum;
            lv = startLv;
            generateIVs();
            setBaseStats();
            refreshStats();
            heal(double.MaxValue);
        }

        public void LevelUp()
        {
            lv++;
            refreshStats();
        }

        public int getID()
        {
            return idNum;
        }

        public double getRemainingHP()
        {
            return remaindingHP;
        }

        public string getName()
        {
            return name;
        }

        public void refreshStats()
        {
            hp = (int)(hpIV + baseHp + Math.Sqrt(hpEV) / 8 + 50) * lv / 50 + 10;
            attack = (int)(atkIV + baseAtk + Math.Sqrt(atkEV) / 8) * lv / 50 + 5;
            defense = (int)(defIV + baseDef + Math.Sqrt(defEV) / 8) * lv / 50 + 5;
            specialAttack = (int)(specAIV + baseSpecA + Math.Sqrt(specAEV) / 8) * lv / 50 + 5;
            specialDefense = (int)(specDIV + baseSpecD + Math.Sqrt(specDEV) / 8) * lv / 50 + 5;
            speed = (int)(spdIV + baseSpd + Math.Sqrt(spdEV) / 8) * lv / 50 + 5;
            switch (expType)
            {
                case 1:
                    expNeeded = 4 * lv ^ 3 / 5;
                    break;
                case 2:
                    expNeeded = lv ^ 3;
                    break;
                case 3:
                    expNeeded = 6 * lv ^ 3 / 5 - 15 * lv ^ 2 + 100 * lv - 140;
                    break;
                case 4:
                    expNeeded = 5 * lv ^ 3 / 4;
                    break;
                default:
                    break;
            }
        }

        private void generateIVs()
        {
            hpIV = gen.Next(0, 15);
            atkIV = gen.Next(0, 15);
            defIV = gen.Next(0, 15);
            spdIV = gen.Next(0, 15);
            specAIV = gen.Next(0, 15);
            specDIV = gen.Next(0, 15);
        }

        private void setBaseStats()
        {
            name = UtilitiesPkmTable.getPkmName(idNum);
            double[] stats = UtilitiesPkmTable.getPkmStats(idNum);

            typeNum1 = (int)stats[0];
            typeNum2 = (int)stats[1];
            baseHp = (int)stats[2];
            baseAtk = (int)stats[3];
            baseDef = (int)stats[4];
            baseSpecA = (int)stats[5];
            baseSpecD = (int)stats[6];
            baseSpd = (int)stats[7];
            baseExp = (int)stats[8];
            expType = (int)stats[9];
            weight = stats[10];
        }
        public void heal(double amount)
        {
            if (amount + remaindingHP > hp)
                remaindingHP = hp;
            else
                remaindingHP += amount;
        }

        public double getWeight()
        {
            return weight;
        }

        public int getLevel()
        {
            return lv;
        }

        public int getAtk()
        {
            return attack;
        }

        public int getDef()
        {
            return defense;
        }

        public int getSpecA()
        {
            return specialAttack;
        }

        public int getSpecD()
        {
            return specialDefense;
        }

        public int getSpeed()
        {
            return speed;
        }

        public int getPkmType1()
        {
            return typeNum1;
        }

        public int getPkmType2()
        {
            return typeNum2;
        }

        public int getMaxHP()
        {
            return hp;
        }

        public void kill()
        {
            remaindingHP = 0;
        }

        // Returns False if Dead
        public bool damagePkm(double amount)
        {
            if (remaindingHP - amount <= 0)
            {
                remaindingHP = 0;
                return false;
            }

            remaindingHP -= amount;
            return true;
        }

        public bool isAlive()
        {
            return remaindingHP > 0;
        }
    }
}
