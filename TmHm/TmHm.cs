using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    public abstract class TmHm
    {
        Random gen = new Random(Utilities.chooseNumber(1,1000000));
        int myPP;
        int myRemaindingPP;
        string myName;
        string myDescription;
        int myType;
        int myCategory;
        int myPower;
        double myAccuracy;
        int myidNum;
        int myPriority;

        public void SetUpInit(int idNum)
        {
            myName = UtilitiesTmTable.getTmName(idNum);
            myDescription = UtilitiesTmTable.getTmDescription(idNum);
            double[] myStats = UtilitiesTmTable.getTmStats(idNum);

            myType = (int)myStats[0];
            myCategory = (int)myStats[1];
            myPower = (int)myStats[2];
            myAccuracy = myStats[3];
            myPP = (int)myStats[4];
            myPriority = (int)myStats[5];
            myidNum = idNum;
            resetPP();
        }

        /// <summary>
        /// Entry Point into the Specific TmHm Class
        /// </summary>
        /// <param name="attacker">Reference to the Attacking Pokemon</param>
        /// <param name="defender">Reference to the Defending Pokemon</param>
        /// <returns>Whether the defender is still alive</returns>
        protected abstract void useMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm);

        public virtual void onDamage(double damage, TmHm hittingMove, Form1 aForm, ref Pokemon self)
        {

        }

        public bool checkRemainingPP()
        {
            return myRemaindingPP > 0; 
        }

        public int getInitPower()
        {
            return myPower;
        }

        public double getMyAcc()
        {
            return myAccuracy;
        }

        public virtual void preMove(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            if (attacker.isConfused())
                aForm.setTextMessage(attacker.getName() + " is Confused!");

            if (!attacker.canAttack(ref attacker, aForm))
            {
                return;
            }

            aForm.setTextMessage(attacker.getName() + " used " + getName());

            if (!(myAccuracy == -1 || checkHit(ref attacker, ref defender)))
            {
                aForm.setTextMessage(attacker.getName() + " has missed!");
                return;
            }

            if (Utilities.Effectiveness(defender.getPkmType1(), myType) == 0)
            {
                aForm.setTextMessage(defender.getName() + " is not effected!");
                return;
            }

            if (defender.isAlive() && (myRemaindingPP > 0 || myPP == -1))
            {
                myRemaindingPP--;
                useMove(ref attacker, ref defender, aForm);
            }
            
        }

        public void preMoveRecharge(ref Pokemon attacker, ref Pokemon defender, Form1 aForm, ref int turnNum)
        {
            if (turnNum == 0)
            {
                if (attacker.isConfused())
                    aForm.setTextMessage(attacker.getName() + " is Confused!");

                if (!attacker.canAttack(ref attacker, aForm))
                {
                    return;
                }

                aForm.setTextMessage(attacker.getName() + " used " + getName());

                if (!checkHit(ref attacker, ref defender))
                {
                    aForm.setTextMessage(attacker.getName() + " has missed!");
                    return;
                }

                if (Utilities.Effectiveness(defender.getPkmType1(), getType()) == 0)
                {
                    aForm.setTextMessage(defender.getName() + " is not effected!");
                    return;
                }

                if (defender.isAlive() && getRemainingPP() > 0 && attacker.canAttack(ref attacker, aForm))
                {
                    turnNum = 1;
                    attacker.setPersistantMove(this);
                    useMove(ref attacker, ref defender, aForm);
                    return;
                }
            }

            if (turnNum == 1)
            {
                attacker.setPersistantMove(null);
                turnNum = 0;
                aForm.setTextMessage(attacker.getName() + " Recovers Their Energy.");
            }
            
        }

        public void preMoveCrash(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            if (attacker.isConfused())
                aForm.setTextMessage(attacker.getName() + " is Confused!");

            if (!attacker.canAttack(ref attacker, aForm))
            {
                return;
            }

            aForm.setTextMessage(attacker.getName() + " used " + getName());

            if (!(myAccuracy == -1 || checkHit(ref attacker, ref defender)))
            {
                aForm.setTextMessage(attacker.getName() + " has missed!");
                
                defender.damagePkm(defender.getMaxHP() * .5, this, aForm, ref defender);
                aForm.setDamageMessage(attacker.getName() + " keeps going and crashes!", myName, attacker.getTrainerSlot());
                return;
            }

            if (Utilities.Effectiveness(defender.getPkmType1(), myType) == 0)
            {
                aForm.setTextMessage(defender.getName() + " is not effected!");
                return;
            }

            if (defender.isAlive() && (myRemaindingPP > 0 || myPP == -1))
            {
                myRemaindingPP--;
                useMove(ref attacker, ref defender, aForm);
            }

        }

        protected void preMoveMultiHit(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            if (attacker.isConfused())
                aForm.setTextMessage(attacker.getName() + " is Confused!");

            if (!attacker.canAttack(ref attacker, aForm))
            {
                return;
            }

            aForm.setTextMessage(attacker.getName() + " used " + getName());

            if (defender.isAlive() && getRemainingPP() > 0)
            {
                decrementPP();
                useMove(ref attacker, ref defender, aForm);
            }
            
        }

        protected void preMoveLock(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            if(attacker.isConfused())
                aForm.setTextMessage(attacker.getName() + " is Confused!");

            if (!attacker.canAttack(ref attacker, aForm))
            {
                return;
            }

            aForm.setTextMessage(attacker.getName() + " used " + getName());

            // BUG NEEDED TO BE FIXED (Last PP)
            if (defender.isAlive() && getRemainingPP() > 0)
                useMove(ref attacker, ref defender, aForm);
        }

        public void useMoveMultiHit(ref Pokemon attacker, ref Pokemon defender, double aAcc, Form1 aForm)
        {
            int aNum = chooseNumber(1, 8);

            int hitNum;

            if (aNum <= 3)
                hitNum = 2;
            else if (aNum <= 6)
                hitNum = 3;
            else if (aNum <= 7)
                hitNum = 4;
            else
                hitNum = 5;

            for (int i = 0; i < hitNum; i++)
            {
                if (checkHit(ref attacker, ref defender, aAcc))
                {
                    applyDamage(ref attacker, ref defender, aForm);
                }
                else
                    aForm.setTextMessage(attacker.getName() + " has missed!");

                if (!defender.isAlive())
                    break;
            }
            aForm.setTextMessage(attacker.getName() + " hit " + hitNum.ToString() + " times!");
        }

        public void useMoveAbsorb(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            double defenderHPLeft = defender.getHP();

            double damageHit = applyDamage(ref attacker, ref defender, aForm);

            if (defenderHPLeft < damageHit)
                heal(ref attacker, defenderHPLeft * .5, aForm);
            else
                heal(ref attacker, damageHit * .5, aForm);
        }

        public void useMoveFatal(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            if(defender.hasSub())
            {
                defender.killSub();
                return;
            }

            if (chooseNumber(0, 99) < attacker.getLevel() - defender.getLevel() + 30)
            {
                aForm.setTextMessage(defender.getName() + " is hit with fatal damage");
                defender.kill();
                aForm.updateHPDamage();
            }
            else
            {
                aForm.setTextMessage(attacker.getName() + " missed");
            }
        }

        public void useMoveDoubleHit(ref Pokemon attacker, ref Pokemon defender, double aAcc, Form1 aForm)
        {
            int hitNum = 2;

            for (int i = 0; i < hitNum; i++)
            {
                if (checkHit(ref attacker, ref defender, aAcc))
                {
                    applyDamage(ref attacker, ref defender, aForm);
                }
                else
                    aForm.setTextMessage(attacker.getName() + " has missed!");

                if (!defender.isAlive())
                    break;
            }
            aForm.setTextMessage(attacker.getName() + " hit " + hitNum.ToString() + " times!");
        }

        protected void useMoveMultiTurnHit(ref Pokemon attacker, ref Pokemon defender, ref int turnNum, ref int totalTurns, Form1 aForm)
        {
            if (turnNum == 0)
            {
                decrementPP();
                if (checkHit(ref attacker, ref defender))
                {
                    attacker.setPersistantMove(this);
                    aForm.blockChoice = true;
                    applyDamage(ref attacker, ref defender, aForm);
                    totalTurns = chooseNumber(2, 3);
                }
                else
                {
                    aForm.setTextMessage(attacker.getName() + " has missed!");
                    return;
                }

            }
            else
            {
                applyDamage(ref attacker, ref defender, aForm);
            }

            turnNum++;

            if (turnNum >= totalTurns)
            {
                attacker.setPersistantMove(null);
                attacker.confuse(aForm);
                aForm.blockChoice = false;
                turnNum = 0;
            }
        }

        protected void useMoveLock(ref Pokemon attacker, ref Pokemon defender, ref int turnNum, ref int totalTurns, double percentHPDamage, Form1 aForm)
        {
            if (turnNum == 0)
            {
                decrementPP();
                if (checkHit(ref attacker, ref defender))
                {
                    attacker.setPersistantMove(this);
                    defender.trap();
                    applyDamage(ref attacker, ref defender, aForm);
                    totalTurns = chooseNumber(2, 5);
                }
                else
                {
                    aForm.setTextMessage(attacker.getName() + " has missed!");
                    return;
                }

            }
            else
            {
                defender.damagePkm(percentHPDamage * (double)defender.getMaxHP(), this, aForm, ref defender);
                aForm.setDamageMessage(attacker.getName(), myName, defender.getTrainerSlot());
            }

            turnNum++;

            if (turnNum >= totalTurns)
            {
                attacker.setPersistantMove(null);
                defender.free();
                turnNum = 0;
            }
        }

        public string getName()
        {
            return myName;
        }

        public string getDescString()
        {
            return myDescription + "\nType: " + Utilities.getTypeName(myType) +  "\nPP: " +  myRemaindingPP.ToString() + " \\ " + myPP.ToString();
        }

        public virtual bool resetPersistant()
        {
            return false;
        }

        protected virtual int getPower()
        {
            return myPower;
        }

        public int getPriority()
        {
            return myPriority;
        }

        public void resetPP()
        {
            myRemaindingPP = myPP;
        }

        public int getRemainingPP()
        {
            return myRemaindingPP;
        }
        public void decrementPP()
        {
            myRemaindingPP--;
        }

        public int getType()
        {
            return myType;
        }

        public int getCat()
        {
            return myCategory;
        }
        ///////////////////////////////////////////////////////////////////////////////////////
        //  Entry Points for TmHm Sub Classes

        /// <summary>
        /// Method that gets a random number to see if the move hits this turn
        /// </summary>
        /// <param name="attacker">Reference to the Attacking Pokemon</param>
        /// <param name="defender">Reference to the Defending Pokemon</param>
        /// <returns>True if it is a hit</returns>
        protected bool checkHit(ref Pokemon attacker, ref Pokemon defender)
        {
            double probability = myAccuracy * attacker.getAcc() / defender.getEvasion();

            int ranNum = gen.Next(0, 10000);

            if (probability * 10000 >= ranNum)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Method that gets a random number to see if the move hits this turn
        /// </summary>
        /// <param name="attacker">Reference to the Attacking Pokemon</param>
        /// <param name="defender">Reference to the Defending Pokemon</param>
        /// <param name="aAccuracy">A new provided Accuracy</param>
        /// <returns>True if it is a hit</returns>
        protected bool checkHit(ref Pokemon attacker, ref Pokemon defender, double aAccuracy)
        {
            double probability = aAccuracy * attacker.getAcc() / defender.getEvasion();

            int ranNum = gen.Next(0, 10000);

            if (probability * 10000 >= ranNum)
                return true;
            else
                return false;
        }

        /// <summary>
        /// A Method to roll a random chance for utility
        /// </summary>
        /// <param name="chance">Probability of true</param>
        /// <returns>True if Successful</returns>
        protected bool checkProb(double chance)
        {
            if (chance * 10000 >= gen.Next(0, 10000))
                return true;
            else return false;
        }

        /// <summary>
        ///  Function that reduces the defenders health for a successful hit
        /// </summary>
        /// <param name="attacker">Reference to the Attacking Pokemon</param>
        /// <param name="defender">Reference to the Defending Pokemon</param>
        /// <returns>Returns the amount of damage</returns>
        protected virtual double applyDamage(ref Pokemon attacker, ref Pokemon defender, Form1 aForm, double aDamageAmount)
        {
            if (defender.getSafety())
            {
                aForm.setTextMessage(defender.getName() + " is not able to be hit!");
                return 0;
            }

            double multiplier = Utilities.Effectiveness(defender.getPkmType1(), myType);

            if (defender.getPkmType2() > 0)
                multiplier *= Utilities.Effectiveness(defender.getPkmType2(), myType);

            double preOtherMulti = multiplier;

            if (attacker.getPkmType1() == myType || attacker.getPkmType2() == myType)
                multiplier *= 1.5;

            if (myCategory == 2)
                if (defender.askLightScreen())
                    aDamageAmount *= 0.5;

            if (myCategory == 1)
                if (defender.askReflect())
                    aDamageAmount *= 0.5;

            defender.damagePkmIncludingSub(aDamageAmount, this, aForm, ref defender);

            aForm.setDamageMessage(attacker.getName(), getName(), defender.getTrainerSlot());

            if (preOtherMulti > 1)
                aForm.setTextMessage("It is Super Effective!");
            else if (preOtherMulti < 1)
                aForm.setTextMessage("It is not very effective.");

            return aDamageAmount;
        }

        /// <summary>
        ///  Function that reduces the defenders health for a successful hit
        /// </summary>
        /// <param name="attacker">Reference to the Attacking Pokemon</param>
        /// <param name="defender">Reference to the Defending Pokemon</param>
        /// <returns>Returns the amount of damage</returns>
        protected virtual double applyDamageExact(ref Pokemon attacker, ref Pokemon defender, Form1 aForm, double aDamageAmount)
        {
            if (defender.getSafety())
            {
                aForm.setTextMessage(defender.getName() + " is not able to be hit!");
                return 0;
            }

            double multiplier = Utilities.Effectiveness(defender.getPkmType1(), myType);

            if (defender.getPkmType2() > 0)
                multiplier *= Utilities.Effectiveness(defender.getPkmType2(), myType);

            if (multiplier != 0)
                multiplier = 1;

            if (myCategory == 2)
                if (defender.askLightScreen())
                    aDamageAmount *= 0.5;

            if (myCategory == 1)
                if (defender.askReflect())
                    aDamageAmount *= 0.5;

            defender.damagePkmIncludingSub(aDamageAmount, this, aForm, ref defender);

            aForm.setDamageMessage(attacker.getName(), getName(), defender.getTrainerSlot());

            return aDamageAmount;
        }

        /// <summary>
        ///  Function that reduces the defenders health for a successful hit
        /// </summary>
        /// <param name="attacker">Reference to the Attacking Pokemon</param>
        /// <param name="defender">Reference to the Defending Pokemon</param>
        /// <returns>Returns the amount of damage</returns>
        protected virtual double applyDamage(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            if (defender.getSafety())
            {
                aForm.setTextMessage(defender.getName() + " is not able to be hit!");
                return 0;
            }

            if (!(myCategory == 1 || myCategory == 2))
                return 0;

            double atkStat = getAtkStat(attacker);
            double defStat = getDefStat(defender); ;

            int critValue = 1;

            if (checkCrit(ref attacker))
                critValue = 2;

            double multiplier = Utilities.Effectiveness(defender.getPkmType1(), myType);

            if (defender.getPkmType2() > 0)
                multiplier *= Utilities.Effectiveness(defender.getPkmType2(), myType);

            double damage = ((((attacker.getLevel() * .4 * critValue) + 2) * atkStat * getPower() / 50 / defStat) + 2) * multiplier * gen.Next(217, 255) / 255;

            if (myCategory == 2)
                if (defender.askLightScreen())
                    damage *= 0.5;

            if (myCategory == 1)
                if (defender.askReflect())
                    damage *= 0.5;

            if (attacker.getPkmType1() == myType || attacker.getPkmType2() == myType)
                damage *= 1.5;

            defender.damagePkmIncludingSub(damage, this, aForm, ref defender);

            aForm.setDamageMessage(attacker.getName(), getName(), defender.getTrainerSlot());

            if (multiplier > 1)
                aForm.setTextMessage("It is Super Effective!");
            else if (multiplier < 1)
                aForm.setTextMessage("It is not very effective.");

            return damage;
        }

        protected void heal(ref Pokemon aPokemon, double anAmount, Form1 aForm)
        {
            aPokemon.heal(anAmount);
            aForm.healMessage(aPokemon.getName(), myName);
        }

        /// <summary>
        /// Chooses a number from min to max including them
        /// </summary>
        /// <param name="min">Min Value</param>
        /// <param name="max">Max Value</param>
        /// <returns>A number from min to max including them</returns>
        protected int chooseNumber(int min, int max)
        {
            return gen.Next(min, max + 1);
        }

        ///////////////////////////////////////////////////////////////////////////////////////
        // Utility Functions for THIS Class

        /// <summary>
        ///  Utility Funciton that sees if the move should be critical hit
        /// </summary>
        /// <returns>Return True if the hit is crictial</returns>
        protected virtual bool checkCrit(ref Pokemon attacker)
        {
            if (gen.Next(0, 1600) < 100 * attacker.getCrit())
                return true;

            return false;
        }

        protected double getAtkStat(Pokemon attacker)
        {
            switch (myCategory)
            {
                case 1:
                    return attacker.getAtk();
                case 2:
                    return attacker.getSpecA();
                default:
                    return 0;
            }
        }

        protected double getDefStat(Pokemon defender)
        {
            switch (myCategory)
            {
                case 1:
                    return defender.getDef();
                case 2:
                    return  defender.getSpecD();
                default:
                    return 0;
            }
        }

        protected void attemptPoison(ref Pokemon defender, Form1 aForm)
        {
            if(!defender.hasSub())
            {
                defender.poison(aForm);
            }
        }

        protected void attemptFreeze(ref Pokemon defender, Form1 aForm)
        {
            if (!defender.hasSub())
            {
                defender.freeze(aForm);
            }
        }

        protected void attemptBurn(ref Pokemon defender, Form1 aForm)
        {
            if (!defender.hasSub())
            {
                defender.burn(aForm);
            }
        }

        protected void attemptFlinch(ref Pokemon defender, Form1 aForm)
        {
            if (!defender.hasSub())
            {
                defender.flinch();
            }
        }

        protected void attemptParalyze(ref Pokemon defender, Form1 aForm)
        {
            if (!defender.hasSub() || myCategory != 3)
            {
                defender.paralyze(aForm);
            }
        }

        protected void attemptSleep(ref Pokemon defender, Form1 aForm)
        {
            if (!defender.hasSub() || myCategory != 3)
            {
                defender.sleep(aForm);
            }
        }

        protected void attemptConfuse(ref Pokemon defender, Form1 aForm)
        {
            if (!defender.hasSub() || myCategory == 3)
            {
                defender.sleep(aForm);
            }
        }

        protected void changeAtk(int amount, ref Pokemon aPok, Form1 aForm, bool hitByOp)
        {
            if (hitByOp && aPok.hasSub())
                return;

            if (hitByOp && aPok.isMisted())
                return;

            if (amount > 0)
            {
                aForm.setTextMessage(aPok.getName() + "'s Attack Rose!");
                aForm.powerUp(aPok.getTrainerSlot());
                aPok.changeAtk(amount);
            }
            else
            {
                aForm.setTextMessage(aPok.getName() + "'s Attack Lowered!");
                aPok.changeAtk(amount);
            }
        }

        protected void changeDef(int amount, ref Pokemon aPok, Form1 aForm, bool hitByOp)
        {
            if (hitByOp && aPok.hasSub())
                return;

            if (hitByOp && aPok.isMisted())
                return;

            if (amount > 0)
            {
                aForm.powerUp(aPok.getTrainerSlot());
                aForm.setTextMessage(aPok.getName() + "'s Defense Rose!");
                aPok.changeDef(amount);
            }
            else
            {
                aForm.setTextMessage(aPok.getName() + "'s Defense Lowered!");
                aPok.changeDef(amount);
            }
        }

        protected void changeSpecAtk(int amount, ref Pokemon aPok, Form1 aForm, bool hitByOp)
        {
            if (hitByOp && aPok.hasSub())
                return;

            if (hitByOp && aPok.isMisted())
                return;

            if (amount > 0)
            {
                aForm.powerUp(aPok.getTrainerSlot());
                aForm.setTextMessage(aPok.getName() + "'s Special Attack Rose!");
                aPok.changeSpecA(amount);
            }
            else
            {
                aForm.setTextMessage(aPok.getName() + "'s Special Attack Lowered!");
                aPok.changeSpecA(amount);
            }
        }

        protected void changeSpecDef(int amount, ref Pokemon aPok, Form1 aForm, bool hitByOp)
        {
            if (hitByOp && aPok.hasSub())
                return;

            if (hitByOp && aPok.isMisted())
                return;

            if (amount > 0)
            {
                aForm.powerUp(aPok.getTrainerSlot());
                aForm.setTextMessage(aPok.getName() + "'s Special Defense Rose!");
                aPok.changeSpecD(amount);
            }
            else
            {
                aForm.setTextMessage(aPok.getName() + "'s Special Defense Lowered!");
                aPok.changeSpecD(amount);
            }
        }

        protected void changeSpeed(int amount, ref Pokemon aPok, Form1 aForm, bool hitByOp)
        {
            if (hitByOp && aPok.hasSub())
                return;

            if (hitByOp && aPok.isMisted())
                return;

            if (amount > 0)
            {
                aForm.powerUp(aPok.getTrainerSlot());
                aForm.setTextMessage(aPok.getName() + "'s Speed Rose!");
                aPok.changeSpd(amount);
            }
            else
            {
                aForm.setTextMessage(aPok.getName() + "'s Speed Lowered!");
                aPok.changeSpd(amount);
            }
        }

        protected void changeAcc(int amount, ref Pokemon aPok, Form1 aForm, bool hitByOp)
        {
            if (hitByOp && aPok.hasSub())
                return;

            if (hitByOp && aPok.isMisted())
                return;

            if (amount > 0)
            {
                aForm.powerUp(aPok.getTrainerSlot());
                aForm.setTextMessage(aPok.getName() + "'s Accuracy Rose!");
                aPok.changeAcc(amount);
            }
            else
            {
                aForm.setTextMessage(aPok.getName() + "'s Accuracy Lowered!");
                aPok.changeAcc(amount);
            }
        }

        protected void changeEva(int amount, ref Pokemon aPok, Form1 aForm, bool hitByOp)
        {
            if (hitByOp && aPok.hasSub())
                return;

            if (hitByOp && aPok.isMisted())
                return;

            if (amount > 0)
            {
                aForm.powerUp(aPok.getTrainerSlot());
                aForm.setTextMessage(aPok.getName() + "'s Evasion Rose!");
                aPok.changeEva(amount);
            }
            else
            {
                aForm.setTextMessage(aPok.getName() + "'s Evasion Lowered!");
                aPok.changeEva(amount);
            }
        }

        protected void changeCrit(int amount, ref Pokemon aPok, Form1 aForm, bool hitByOp)
        {
            if (hitByOp && aPok.hasSub())
                return;

            if (hitByOp && aPok.isMisted())
                return;

            if (amount > 0)
            {
                aForm.powerUp(aPok.getTrainerSlot());
                aForm.setTextMessage(aPok.getName() + " Focused Their Energy");
                aPok.changeCrit(amount);
            }
            else
            {
                aForm.setTextMessage(aPok.getName() + " Focused Their Energy!");
                aPok.changeCrit(amount);
            }
        }

        // DEFAULT CONDITION TO CHECK SUB

        protected void changeAtk(int amount, ref Pokemon aPok, Form1 aForm)
        {
            if (aPok.hasSub())
                return;

            if (aPok.isMisted())
                return;

            if (amount > 0)
            {
                aForm.setTextMessage(aPok.getName() + "'s Attack Rose!");
                aForm.powerUp(aPok.getTrainerSlot());
                aPok.changeAtk(amount);
            }
            else
            {
                aForm.setTextMessage(aPok.getName() + "'s Attack Lowered!");
                aPok.changeAtk(amount);
            }
        }

        protected void changeDef(int amount, ref Pokemon aPok, Form1 aForm)
        {
            if (aPok.hasSub())
                return;

            if (aPok.isMisted())
                return;

            if (amount > 0)
            {
                aForm.powerUp(aPok.getTrainerSlot());
                aForm.setTextMessage(aPok.getName() + "'s Defense Rose!");
                aPok.changeDef(amount);
            }
            else
            {
                aForm.setTextMessage(aPok.getName() + "'s Defense Lowered!");
                aPok.changeDef(amount);
            }
        }

        protected void changeSpecAtk(int amount, ref Pokemon aPok, Form1 aForm)
        {
            if (aPok.hasSub())
                return;

            if (aPok.isMisted())
                return;

            if (amount > 0)
            {
                aForm.powerUp(aPok.getTrainerSlot());
                aForm.setTextMessage(aPok.getName() + "'s Special Attack Rose!");
                aPok.changeSpecA(amount);
            }
            else
            {
                aForm.setTextMessage(aPok.getName() + "'s Special Attack Lowered!");
                aPok.changeSpecA(amount);
            }
        }

        protected void changeSpecDef(int amount, ref Pokemon aPok, Form1 aForm)
        {
            if (aPok.hasSub())
                return;

            if (aPok.isMisted())
                return;

            if (amount > 0)
            {
                aForm.powerUp(aPok.getTrainerSlot());
                aForm.setTextMessage(aPok.getName() + "'s Special Defense Rose!");
                aPok.changeSpecD(amount);
            }
            else
            {
                aForm.setTextMessage(aPok.getName() + "'s Special Defense Lowered!");
                aPok.changeSpecD(amount);
            }
        }

        protected void changeSpeed(int amount, ref Pokemon aPok, Form1 aForm)
        {
            if (aPok.hasSub())
                return;

            if (aPok.isMisted())
                return;

            if (amount > 0)
            {
                aForm.powerUp(aPok.getTrainerSlot());
                aForm.setTextMessage(aPok.getName() + "'s Speed Rose!");
                aPok.changeSpd(amount);
            }
            else
            {
                aForm.setTextMessage(aPok.getName() + "'s Speed Lowered!");
                aPok.changeSpd(amount);
            }
        }

        protected void changeAcc(int amount, ref Pokemon aPok, Form1 aForm)
        {
            if ( aPok.hasSub())
                return;

            if (aPok.isMisted())
                return;

            if (amount > 0)
            {
                aForm.powerUp(aPok.getTrainerSlot());
                aForm.setTextMessage(aPok.getName() + "'s Accuracy Rose!");
                aPok.changeAcc(amount);
            }
            else
            {
                aForm.setTextMessage(aPok.getName() + "'s Accuracy Lowered!");
                aPok.changeAcc(amount);
            }
        }

        protected void changeEva(int amount, ref Pokemon aPok, Form1 aForm)
        {
            if ( aPok.hasSub())
                return;

            if (aPok.isMisted())
                return;

            if (amount > 0)
            {
                aForm.powerUp(aPok.getTrainerSlot());
                aForm.setTextMessage(aPok.getName() + "'s Evasion Rose!");
                aPok.changeEva(amount);
            }
            else
            {
                aForm.setTextMessage(aPok.getName() + "'s Evasion Lowered!");
                aPok.changeEva(amount);
            }
        }

        protected void changeCrit(int amount, ref Pokemon aPok, Form1 aForm)
        {
            if (aPok.hasSub())
                return;

            if (aPok.isMisted())
                return;

            if (amount > 0)
            {
                aForm.powerUp(aPok.getTrainerSlot());
                aForm.setTextMessage(aPok.getName() + " Focused Their Energy");
                aPok.changeCrit(amount);
            }
            else
            {
                aForm.setTextMessage(aPok.getName() + " Focused Their Energy!");
                aPok.changeCrit(amount);
            }
        }
    }
}
