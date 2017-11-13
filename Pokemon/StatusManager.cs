using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    class StatusManager
    {
        Random gen = new Random();
        private int accuracy = 0;
        private int evasion = 0;

        private int tempAtk = -0;
        private int tempDef = 0;
        private int tempSpecA = 0;
        private int tempSpecD = 0;
        private int tempSpd = 0;
        private int tempCrit = 0;

        private int tempType = -1;

        //Statuses
        private bool isFrozen = false;
        private bool isBurned = false;
        private bool isParalazed = false;
        private int sleepDur = 0;
        private int confuseDur = 0;
        private bool isPoisoned = false;
        private bool isTrapped = false;
        private bool isFlinch = false;
        private bool isSafe = false;
        private bool isSeeded = false;
        private bool isMinimized = false;
        private int mistVal = 0;
        private int lightScreenDur = 0;
        private int reflectDur = 0;

        private double subHP = 0;
        private bool hasSub = false;

        public StatusManager()
        {

        }

        public string getStatusText()
        {
            string outStr = "";
            if (isFrozen)
                outStr += "FRZ ";
            else if(isBurned)
                outStr += "BRN ";
            else if (isParalazed)
                outStr += "PAR ";
            else if (isPoisoned)
                outStr += "PZN ";
            else if (sleepDur > 0)
                outStr += "SLP ";
            else if (confuseDur > 0)
                outStr += "CFN ";

            return outStr;
        }

        public bool getIsMisted()
        {
            return mistVal > 0; ;
        }

        public void mist()
        {
            mistVal = 5;
        }

        public bool isSubAlive()
        {
            return hasSub;
        }

        public double hurtSub(double anAmount, Form1 aForm)
        {
            if (subHP < anAmount)
            {
                double remainingDamage = anAmount - subHP;
                subHP = 0;
                aForm.setTextMessage("The Substitute Faded Away!");
                return remainingDamage;
            }
            subHP -= anAmount;
            return 0;
        }

        public void setSubHP(double aHP)
        {
            subHP = aHP;
            hasSub = true;
        }

        public void killSub()
        {
            subHP = 0;
        }

        public double getAtkModifier()
        {
            return getModifer(tempAtk);
        }

        public double getDefModifier()
        {
            return getModifer(tempDef);
        }
        public double getSpecAModifier()
        {
            return getModifer(tempSpecA);
        }

        public double getSpecDModifier()
        {
            return getModifer(tempSpecD);
        }

        public double getSpeedModifier()
        {
            if(isParalazed)
                return 0.5 * getModifer(tempSpd);
            return getModifer(tempSpd);
        }

        public int getTempType()
        {
            return tempType;
        }

        public void setTempType(int aType)
        {
            tempType = aType;
        }

        /// <summary>
        /// Resets all Status to a Default State
        /// </summary>
        public void reset()
        {
            accuracy = 0;
            evasion = 0;

            tempAtk = 0;
            tempDef = 0;
            tempSpecA = 0;
            tempSpecD = 0;
            tempSpd = 0;

            tempType = -1;

            //Statuses
            isFrozen = false;
            isBurned = false;
            isParalazed = false;
            sleepDur = 0;
            confuseDur = 0;
            isPoisoned = false;
            isTrapped = false;
        }

        public double getAcc()
        {
            return getModiferAccEva(accuracy);
        }

        public double getEvasion()
        {
            return getModiferAccEva(evasion);
        }

        public double getCrit()
        {
            return getModiferAccEva(tempCrit);
        }

        public void pznHeal()
        {
            isPoisoned = false;
        }

        public bool getIsPoisoned()
        {
            return isPoisoned;
        }

        public void brnHeal()
        {
            isBurned = false;
        }

        public bool getIsBurned()
        {
            return isBurned;
        }

        public void fznHeal()
        {
            isFrozen = false;
        }

        public bool getIsParalyzed()
        {
            return isParalazed;
        }

        public void przHeal()
        {
            isParalazed = false;
        }

        public bool getIsFrozen()
        {
            return isFrozen;
        }

        public void setReflect()
        {
            reflectDur = 5;
        }

        public bool askReflect()
        {
            return reflectDur > 0;
        }

        public void setLightScreen()
        {
            lightScreenDur = 5;
        }

        public bool askLightScreen()
        {
            return lightScreenDur > 0;
        }

        public bool getIsMinimized()
        {
            return isMinimized;
        }

        public void minimize()
        {
            isMinimized = true;
        }

        public void trap()
        {
            isTrapped = true;
        }

        public void free()
        {
            isTrapped = false;
        }

        public void flinch()
        {
            isFlinch = true;
        }

        public void setSeeded(bool value)
        {
            isSeeded = value;
        }

        public void setSafety(bool value)
        {
            isSafe = value;
        }

        public bool isConfused()
        {
            return confuseDur > 0; 
        }

        public void cfzHeal()
        {
            confuseDur = 0;
        }

        public bool isAsleep()
        {
            return sleepDur > 0;
        }

        public void slpHeal()
        {
            sleepDur = 0;
        }

        public bool getIsSeeded()
        {
            return isSeeded;
        }

        public void seed(Form1 aForm, string myName)
        {
            if(isSeeded)
            {
                aForm.setTextMessage(myName + " is already seeded!");
            }
            else
            {
                isSeeded = true;
                aForm.setTextMessage(myName + " has been seeded!");
            }
        }

        public void lightScreen(Form1 aForm, string myName)
        {
            if (lightScreenDur <= 0)
            {
                setLightScreen();
                aForm.setTextMessage(myName + " Generated a Shield of Light!");
            }
            else
            {
                aForm.setTextMessage(myName + " already has a light screen!");
            }
        }

        public void reflect(Form1 aForm, string myName)
        {
            if (reflectDur <= 0)
            {
                setReflect();
                aForm.setTextMessage(myName + " Generated a Shield!");
            }
            else
            {
                aForm.setTextMessage(myName + " already has used reflect!");
            }
        }

        public void asleep(Form1 aForm, string myName)
        {
            if (sleepDur <= 0)
            {
                sleepDur = gen.Next(1, 4);
                aForm.setTextMessage(myName + " Fell Asleep!");
            }
            else
            {
                aForm.setTextMessage(myName + " is already Asleep!");
            }
        }

        public void burn(Form1 aForm, string myName)
        {
            if (isBurned)
            {
                aForm.setTextMessage(myName + " is already Burned!");
            }
            else
            {
                aForm.setTextMessage(myName + " is Burned!");
                isBurned = true;
            }
        }

        public void freeze(Form1 aForm, string myName)
        {
            if (isFrozen)
            {
                aForm.setTextMessage(myName + " is already Frozen!");
            }
            else
            {
                aForm.setTextMessage(myName + " is Frozen Solid!");
                isFrozen = true;
            }
        }

        public void paralyze(Form1 aForm, string myName)
        {
            if (isParalazed)
            {
                aForm.setTextMessage(myName + " is already paralyzed!");
            }
            else
            {
                aForm.setTextMessage(myName + " is Paralyzed!");
                isParalazed = true;
            }
        }

        public bool getSafety()
        {
            return isSafe;
        }

        public void postAttack(ref Pokemon self, Form1 aForm, string myName, ref Pokemon attacker)
        {
            if(confuseDur > 0)
            {
                confuseDur--;
                if(confuseDur == 0)
                    aForm.setTextMessage(myName + " is no longer Confused!");
            }

            if (lightScreenDur > 0)
            {
                lightScreenDur--;
                if (lightScreenDur == 0)
                    aForm.setTextMessage(myName + "'s light screen faded");
            }

            if (mistVal > 0)
            {
                mistVal--;
                if (mistVal == 0)
                    aForm.setTextMessage(myName + "'s mist faded");
            }

            if (reflectDur > 0)
            {
                reflectDur--;
                if (reflectDur == 0)
                    aForm.setTextMessage(myName + "'s reflection faded");
            }

            if (sleepDur > 0)
            {
                sleepDur--;
                if (sleepDur == 0)
                    aForm.setTextMessage(myName + " Woke Up!");
            }

            if (hasSub && subHP < 0)
                hasSub = false;

            if(isPoisoned)
            {
                self.damagePkm(self.getMaxHP()*1/16, null, aForm, ref self);
                aForm.setPoisionMessage(myName);
            }

            if (isBurned)
            {
                self.damagePkm(self.getMaxHP() * 1 / 16, null, aForm, ref self);
                aForm.setBurnedMessage(myName);
            }

            if (isFlinch)
            {
                isFlinch = false;
            }
            if(isSeeded)
            {
                double damageAmount = self.getMaxHP() * 1 / 16;
                self.damagePkm(damageAmount, null, aForm, ref self);
                aForm.setDamageMessage(self.getName(), "leeching", self.getTrainerSlot());
                attacker.heal(damageAmount);
                aForm.healMessage(attacker.getName(), "Leeching");
            }
        }

        /// <summary>
        /// Checks that statuses of various states for this pokemon if it is able to attack
        /// </summary>
        /// <param name="attacker">The Current Pokemon</param>
        /// <returns>Returns True if the pokemon can attack</returns>
        public bool canAttack(ref Pokemon attacker, Form1 aForm)
        {
            if(isFrozen)
            {
                aForm.setTextMessage(attacker.getName() + " is Frozen Solid!");
                return false;
            }

            if(isTrapped)
            {
                aForm.setTextMessage(attacker.getName() + " is Trapped!");
                return false;
            }

            if (sleepDur > 0)
            {
                aForm.setTextMessage(attacker.getName() + " is Asleep!");
                return false;
            }

            if (sleepDur > 0)
            {
                aForm.setTextMessage(attacker.getName() + " is Trapped!");
                return false;
            }

            if (isParalazed)
                if (gen.Next(1, 5) == 1)
                {
                    aForm.setTextMessage(attacker.getName() + " is unable to move!");
                    return false;
                }
                    

            if (confuseDur > 0)
                if (gen.Next(1, 3) == 1)
                {
                    attacker.damagePkm(calcConfusionDamage(ref attacker), null, aForm, ref attacker);
                    aForm.setConfusionMessage(attacker.getName());
                    return false;
                }

            if(isFlinch)
            {
                aForm.setTextMessage(attacker.getName() + " Flinched!");
                isFlinch = false;
                return false;
            }

            return true;
        }

        /// <summary>
        /// Attempts to confuse the current Pokemon
        /// </summary>
        /// <returns>True if the pokemon is successfully confused</returns>
        public bool confuse(Form1 aForm, string myName)
        {
            if (confuseDur > 0)
            {
                aForm.setTextMessage(myName + " is already Confused!");
                return false;
            }
            confuseDur = gen.Next(1, 5);
            aForm.setTextMessage(myName + " became Confused!");
            return true;
        }

        /// <summary>
        /// Attempts to poision the current Pokemon
        /// </summary>
        /// <returns>True if the pokemon is successfully poision</returns>
        public bool poison(Form1 aForm, string myName)
        {
            if (isPoisoned)
            {
                aForm.setTextMessage(myName + " is already Poisioned!");
                return false;
            }

            isPoisoned = true;
            aForm.setTextMessage(myName + " became Poisioned!");
            return true;
        }

        /// <summary>
        /// Utility Function that checks how much damage a hit of confusion will do
        /// </summary>
        /// <param name="aPoke">The Confused Pokemon</param>
        /// <returns>The amount of damage</returns>
        private double calcConfusionDamage(ref Pokemon aPoke)
        {
            int Power = 40;
            int multiplier = 1;
            return ((((aPoke.getLevel() * .4 ) + 2) * aPoke.getAtk() * Power / 50 / aPoke.getDef()) + 2) * multiplier * gen.Next(217, 255) / 255;
        }

        // True if Success
        public bool changeAtk(int stageNum)
        {
            int initTempAtk = tempAtk;
            tempAtk = stageLogic(tempAtk, stageNum);

            return tempAtk != initTempAtk;
        }

        // True if Success
        public bool changeDef(int stageNum)
        {
            int initTempDef = tempDef;
            tempDef = stageLogic(tempDef, stageNum);

            return tempDef != initTempDef;
        }

        // True if Success
        public bool changeSpecA(int stageNum)
        {
            int initTempSpecA = tempSpecA;
            tempSpecA = stageLogic(tempSpecA, stageNum);

            return tempSpecA != initTempSpecA;
        }

        // True if Success
        public bool changeSpecD(int stageNum)
        {
            int initTempSpecD = tempSpecD;
            tempSpecD = stageLogic(tempSpecD, stageNum);

            return tempSpecD != initTempSpecD;
        }

        // True if Success
        public bool changeSpd(int stageNum)
        {
            int initTempSpd = tempSpd;
            tempSpd = stageLogic(tempSpd, stageNum);

            return tempSpd != initTempSpd;
        }

        // True if Success
        public bool changeAcc(int stageNum)
        {
            int initAcc = accuracy;
            accuracy = stageLogic(accuracy, stageNum);

            return accuracy != initAcc;
        }

        // True if Success
        public bool changeEva(int stageNum)
        {
            int initEva = evasion;
            evasion = stageLogic(evasion, stageNum);

            return evasion != initEva;
        }

        // True if Success
        public bool changeCrit(int stageNum)
        {
            int initCrit = tempCrit;
            tempCrit = stageLogic(tempCrit, stageNum);

            return tempCrit != initCrit;
        }

        private int stageLogic(int aStageValue, int aStageChange)
        {
            if (aStageChange > 0)
            {
                if (aStageValue >= 6)
                    return aStageValue;

                if (aStageValue + aStageChange >= 6)
                    return 6;
                else
                    return aStageValue + aStageChange;

            }
            else if (aStageChange < 0)
            {
                if (aStageValue <= -6)
                    return aStageValue;

                if (aStageValue + aStageChange <= -6)
                    return -6;
                else
                    return aStageValue + aStageChange;

            }
            else
                return 0;
        }


        /// <summary>
        /// Gets the temporary state of stats that are Accuracy or Evasion
        /// </summary>
        /// <param name="stage">How high or low the modifier is </param>
        /// <returns>The amount that stat will change</returns>
        private double getModiferAccEva(int stage)
        {
            switch (stage)
            {
                case -6:
                        return .33;
                case -5:
                        return .38;
                case -4:
                        return .43;
                case -3:
                        return .50;
                case -2:
                        return .60;
                case -1:
                        return .75;
                case 1:
                        return 1.33;
                case 2:
                        return 1.67;
                case 3:
                        return 2.00;
                case 4:
                        return 2.33;
                case 5:
                        return 2.67;
                case 6:
                        return 3.00;
                default:
                    return 1;
            }
        }

        /// <summary>
        /// Gets the temporary state of stats that are Not Accuracy or Evasion
        /// </summary>
        /// <param name="stage">How high or low the modifier is </param>
        /// <returns>The amount that stat will change</returns>
        private double getModifer(int stage)
        {
            switch (stage)
            {
                case -6:
                    return .25;
                case -5:
                    return .29;
                case -4:
                    return .33;
                case -3:
                    return .40;
                case -2:
                    return .50;
                case -1:
                    return .67;
                case 1:
                    return 1.50;
                case 2:
                    return 2.00;
                case 3:
                    return 2.50;
                case 4:
                    return 3.00;
                case 5:
                    return 3.50;
                case 6:
                    return 4.00;
                default:
                    return 1;
                
            }
        }
    }
}
