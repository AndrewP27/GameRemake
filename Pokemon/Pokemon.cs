using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PokemonRemake
{
    public class Pokemon
    {
        private List<int> validTmHmNums = new List<int>();
        private StatsManager myStats;
        private StatusManager myStatus;
        private TmHm[] myMoveSet;
        private TmHm persistantMove;
        private int[] myTmHmDisabled;
        int TrainerSlot;
        int lastUsedTmHmSlot = -1;

        private Pokemon transformCopy = null;

        public Pokemon(int idNum, int aLevel, int aTrainerSlot)
        {
            myStats = new StatsManager(idNum, aLevel);
            myStatus = new StatusManager();
            //refreshStatus();
            myMoveSet = new TmHm[4];
            myTmHmDisabled = new int[] { 0, 0, 0, 0 };
            persistantMove = null;
            TrainerSlot = aTrainerSlot;
        }

        public int getID()
        {
            return myStats.getID();
        }

        public double getHP()
        {
            return myStats.getRemainingHP();
        }

        public void resetStatus()
        {
            myStatus.reset();
        }

        public double getWeight()
        {
            return myStats.getWeight();
        }

        
        public string getTmHmString(int aMoveSlot)
        {
            if (transformCopy == null)
            {
                if (aMoveSlot < myMoveSet.Length && myMoveSet[aMoveSlot] != null)
                    return myMoveSet[aMoveSlot].getDescString();
                else
                    return "";
            }
            else
                return transformCopy.getTmHmString(aMoveSlot);
        }

        
        public List<int> askValidTmHmNum()
        {
            if (transformCopy == null)
            {
                List<int> output = new List<int>();
                for (int i = 0; i < myMoveSet.Length; i++)
                {
                    if (myMoveSet[i] != null && myMoveSet[i].checkRemainingPP() && myTmHmDisabled[i] <= 0)
                        output.Add(i);
                }

                return output;
            }
            else
                return transformCopy.askValidTmHmNum();
        }

        public string getName()
        {
            return myStats.getName();
        }

        public int getTrainerSlot()
        {
            return TrainerSlot;
        }

        
        public void setPersistantMove(TmHm aPersistantMove)
        {
            if (transformCopy == null)
                persistantMove = aPersistantMove;
            else
                transformCopy.setPersistantMove(aPersistantMove);
        }


        public TmHm getPersistantMove()
        {
            if (transformCopy == null)
                return persistantMove;
            else
                return transformCopy.getPersistantMove();
        }

        public bool askPersistant()
        {
            return persistantMove != null;
        }

        public bool askLightScreen()
        {
            return myStatus.askLightScreen();
        }

        public bool askReflect()
        {
            return myStatus.askReflect();
        }

        public void mist()
        {
            myStatus.mist();
        }

        public bool isMisted()
        {
            return myStatus.getIsMisted();
        }

        public bool isPoisoned()
        {
            return myStatus.getIsPoisoned();
        }

        public void pznHeal()
        {
            myStatus.pznHeal();
        }

        public bool isBurned()
        {
            return myStatus.getIsBurned();
        }

        public void brnHeal()
        {
            myStatus.brnHeal();
        }

        public bool isFrozen()
        {
            return myStatus.getIsFrozen();
        }

        public void fznHeal()
        {
            myStatus.fznHeal();
        }

        public bool hasSub()
        {
            return myStatus.isSubAlive();
        }

        public void killSub()
        {
            myStatus.killSub();
        }

        public void kill()
        {
            myStats.kill();
        }

        
        /// <summary>
        /// Attempts to run the persistant moves logic for multiturn moves
        /// </summary>
        /// <returns>True means that there was a persistnat move</returns>
        public bool tryPersistant(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            if (transformCopy == null)
            {
                if (persistantMove == null)
                    return false;
                persistantMove.preMove(ref attacker, ref defender, aForm);
                return true;
            }
            else
                return transformCopy.tryPersistant(ref attacker, ref defender, aForm);
        }

        public int getLastMoveSlot()
        {
            return lastUsedTmHmSlot;
        }


        public void useMove(ref Pokemon attacker, ref Pokemon defender, int slotNum, Form1 aForm)
        {
            if (transformCopy == null)
            {
                if (myMoveSet[slotNum] != null)
                {
                    lastUsedTmHmSlot = slotNum;
                    myMoveSet[slotNum].preMove(ref attacker, ref defender, aForm);
                }
                else
                    throw (new System.Exception("Move Does Not Exist"));
            }
            else
                transformCopy.useMove(ref attacker, ref defender, slotNum, aForm);
        }

        public void useStruggle(ref Pokemon attacker, ref Pokemon defender, Form1 aForm)
        {
            Utilities.struggle.preMove(ref attacker, ref defender, aForm);
        }


        public void setDisabled(int aSlotNum)
        {
            if (transformCopy == null)
            {
                if (aSlotNum < myTmHmDisabled.Length)
                {
                    myTmHmDisabled[aSlotNum] = Utilities.chooseNumber(2, 7);
                }
            }
            else
                transformCopy.setDisabled(aSlotNum);
        }
        
        public bool askDisabled(int aSlotNum)
        {
            if (transformCopy == null)
            {
                if (aSlotNum < myTmHmDisabled.Length)
                {
                    return myTmHmDisabled[aSlotNum] > 0;
                }
                return false;
            }
            else
                return transformCopy.askDisabled(aSlotNum);
        }


        public bool checkRemainingPP(int aSlotNum)
        {
            if (transformCopy == null)
                return myMoveSet[aSlotNum].checkRemainingPP();
            else
                return transformCopy.checkRemainingPP(aSlotNum);
        }


        public string getMoveName(int slotNum)
        {
            if (transformCopy == null)
            {
                if (myMoveSet[slotNum] != null)
                    return myMoveSet[slotNum].getName();
                else
                    return "-----";
            }
            else
                return transformCopy.getMoveName(slotNum);
        }

        public void setNewMove(int idNum, int slotNum)
        {
            if (slotNum >= 0 && slotNum <= 4)
                myMoveSet[slotNum] = Utilities.getMoveObj(idNum);
            else
                throw (new System.Exception("Slot Number not in Range"));
        }


        public TmHm getMove(int slotNum)
        {
            if (transformCopy == null)
                return myMoveSet[slotNum];
            else
                return transformCopy.getMove(slotNum);
        }

        private void refreshStatus()
        {
            myStatus.reset();
        }

        public void setSafety(bool isSafeVal)
        {
            myStatus.setSafety(isSafeVal);
        }

        public bool getSafety()
        {
            return myStatus.getSafety();
        }

        public int getLevel()
        {
            return myStats.getLevel();
        }

        public double getAtk()
        {
            return myStats.getAtk() * myStatus.getAtkModifier();
        }

        public double getDef()
        {
            return myStats.getDef() * myStatus.getDefModifier();
        }

        public double getSpecA()
        {
            return myStats.getSpecA() * myStatus.getSpecAModifier();
        }

        public double getSpecD()
        {
            return myStats.getSpecD() * myStatus.getSpecDModifier();
        }

        public double getSpeed()
        {
            return myStats.getSpeed() * myStatus.getSpeedModifier();
        }

        public int getPkmType1()
        {
            if (myStatus.getTempType() == -1)
                return myStats.getPkmType1();
            else
                return myStatus.getTempType();
        }

        public int getPkmType2()
        {
            if (myStatus.getTempType() == -1)
                return myStats.getPkmType2();
            else
                return myStatus.getTempType();
        }

        public void setTempType(int aType)
        {
            myStatus.setTempType(aType);
        }

        public double getAcc()
        {
            return myStatus.getAcc();
        }

        public double getEvasion()
        {
            return myStatus.getEvasion();
        }

        public double getCrit()
        {
            return myStatus.getCrit();
        }

        public int getMaxHP()
        {
            return myStats.getMaxHP();
        }

        public bool getIsMinimized()
        {
            return myStatus.getIsMinimized();
        }

        public void seed(Form1 aForm)
        {
            myStatus.seed(aForm, myStats.getName());
        }

        public void minimize()
        {
            myStatus.minimize();
        }

        public void trap()
        {
            myStatus.trap();
        }

        public void free()
        {
            myStatus.free();
        }

        public void substitute(ref Pokemon attacker, TmHm hittingMove, Form1 aForm)
        {
            double amountOfHPDamage = Math.Floor(getMaxHP() * 0.25);
            if (getHP() > amountOfHPDamage && !myStatus.isSubAlive())
            {
                damagePkm(amountOfHPDamage, hittingMove, aForm, ref attacker);
                onDamage(amountOfHPDamage, hittingMove, aForm, ref attacker);
                myStatus.setSubHP(amountOfHPDamage + 1);
            }
            else
                aForm.setTextMessage("Substitute has Failed!");
        }

        public void burn(Form1 aForm)
        {
            if (getPkmType1() == 2 || getPkmType2() == 2)
                return;

            myStatus.burn(aForm, myStats.getName());
        }

        public void flinch()
        {
            myStatus.flinch();
        }

        public void lightScreen(Form1 aForm)
        {
            myStatus.lightScreen(aForm, getName());
        }

        public void reflect(Form1 aForm)
        {
            myStatus.reflect(aForm, getName());
        }

        public void sleep(Form1 aForm)
        {
            myStatus.asleep(aForm, myStats.getName());
        }

        public void paralyze(Form1 aForm)
        {
            if (getPkmType1() == 4 || getPkmType2() == 4)
                return;

            myStatus.paralyze(aForm, myStats.getName());
        }

        public void freeze(Form1 aForm)
        {
            if (getPkmType1() == 6 || getPkmType2() == 6)
                return;

            myStatus.freeze(aForm, myStats.getName());
        }

        public bool isConfused()
        {
            return myStatus.isConfused();
        }

        public void cfzHeal()
        {
            myStatus.cfzHeal();
        }

        public bool isParalyzed()
        {
            return myStatus.getIsParalyzed();
        }

        public void przHeal()
        {
            myStatus.przHeal();
        }

        public bool isAsleep()
        {
            return myStatus.isAsleep();
        }

        public void slpHeal()
        {
            myStatus.slpHeal();
        }

        // Returns False if Dead
        public bool damagePkm(double value, TmHm hittingMove, Form1 aForm, ref Pokemon self)
        {
            bool returnVal = myStats.damagePkm(value);
            onDamage(value, hittingMove, aForm, ref self);
            return returnVal;
        }

        // Returns False if Dead
        public bool damagePkmIncludingSub(double value, TmHm hittingMove, Form1 aForm, ref Pokemon self)
        {
            if (myStatus.isSubAlive())
            {
                myStatus.hurtSub(value, aForm);
                return isAlive();
            }
            else
            {
                bool returnVal = myStats.damagePkm(value);
                onDamage(value, hittingMove, aForm, ref self);
                return returnVal;
            }
            
        }

        public bool isAlive()
        {
            return myStats.isAlive();
        }

        public bool canAttack(ref Pokemon attacker, Form1 aForm)
        {
            return myStatus.canAttack(ref attacker, aForm);
        }
        //Return true if success, else return false
        public void confuse(Form1 aForm)
        {
            myStatus.confuse(aForm, myStats.getName());
        }

        public void poison(Form1 aForm)
        {
            if (getPkmType1() == 17 || getPkmType2() == 17)
                return;
            if (getPkmType1() == 8 || getPkmType2() == 8)
                return;

            myStatus.poison(aForm, myStats.getName());
        }

        public void heal(double amount)
        {
            myStats.heal(amount);
        }

        // True if Success
        public bool changeAtk(int stageNum)
        {
            return myStatus.changeAtk(stageNum);
        }

        // True if Success
        public bool changeDef(int stageNum)
        {
            return myStatus.changeDef(stageNum);
        }

        // True if Success
        public bool changeSpecA(int stageNum)
        {
            return myStatus.changeSpecA(stageNum);
        }

        // True if Success
        public bool changeSpecD(int stageNum)
        {
            return myStatus.changeSpecD(stageNum);
        }

        // True if Success
        public bool changeSpd(int stageNum)
        {
            return myStatus.changeSpd(stageNum);
        }

        // True if Success
        public bool changeAcc(int stageNum)
        {
            return myStatus.changeAcc(stageNum);
        }

        // True if Success
        public bool changeEva(int stageNum)
        {
            return myStatus.changeEva(stageNum);
        }

        // True if Success
        public bool changeCrit(int stageNum)
        {
            return myStatus.changeCrit(stageNum);
        }

        public void onDamage(double damage, TmHm hittingMove, Form1 aForm, ref Pokemon self)
        {
            foreach (TmHm i in myMoveSet)
            {
                if(i!=null)
                    i.onDamage(damage, hittingMove, aForm, ref self);
            }
        }

        public void postAttack(ref Pokemon self, Form1 aForm, ref Pokemon attacker)
        {
            myStatus.postAttack(ref self, aForm, myStats.getName(), ref attacker);
            for (int i = 0; i < myTmHmDisabled.Length; i++)
            {
                if(myTmHmDisabled[i] > 0)
                {
                    myTmHmDisabled[i]--;
                    if (myTmHmDisabled[i] == 0)
                        aForm.setTextMessage(getMoveName(i) + " is no longer Disabled");
                }
            }

            if (transformCopy != null)
                transformCopy.postAttackCopy(aForm);
        }

        public void postAttackCopy(Form1 aForm)
        {
            for (int i = 0; i < myTmHmDisabled.Length; i++)
            {
                if (myTmHmDisabled[i] > 0)
                {
                    myTmHmDisabled[i]--;
                    if (myTmHmDisabled[i] == 0)
                        aForm.setTextMessage(getMoveName(i) + " is no longer Disabled");
                }
            }
        }


            public string getStatusText()
        {
            return myStatus.getStatusText();
        }

        public void transform(Pokemon defender)
        {
            transformCopy = defender;
        }
    }
}
