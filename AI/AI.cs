using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    public abstract class AI
    {
        // BASE LOTTERY VALUES
        int Base_Attack_Lottery = 100;
        int Base_Buff_Lottery = 25;
        int Base_Debuff_Lottery = 25;
        int Base_Inflict_Lottery = 25;
        int Base_Swap_Lottery = 5;
        int Base_Heal_Lottery = 10;
        int Base_Heal_Infliction_Lottery = 0;

        public abstract int choseNewPkm(ref Trainer trainer1, ref Trainer trainer2);

        public abstract int choseNewPkmBanned(ref Trainer trainer1, ref Trainer trainer2, int bannedNum);

        public virtual void choseNextAction(ref Trainer trainer1, ref Trainer trainer2)
        {

            
        }

        public virtual int getAttackLottery()
        {
            return Base_Attack_Lottery;
        }

        public virtual int getBuffLottery()
        {
            return Base_Attack_Lottery;
        }

        public virtual int getDebuffLottery()
        {
            return Base_Attack_Lottery;
        }

        public virtual int getInflictLottery()
        {
            return Base_Attack_Lottery;
        }

        public virtual int getSwapLottery()
        {
            return Base_Attack_Lottery;
        }

        public virtual int getHealLottery()
        {
            return Base_Attack_Lottery;
        }

        public virtual int getHealInflictionLottery()
        {
            return Base_Attack_Lottery;
        }

        protected void choseLottery(ref Trainer trainer1, ref Trainer trainer2)
        {
            int attack_Lottery = getAttackLottery();
            int buff_Lottery = getAttackLottery();
            int debuff_Lottery = getAttackLottery();
            int inflict_Lottery = getAttackLottery();
            int swap_Lottery = getAttackLottery();
            int heal_Lottery = getAttackLottery();
            int heal_infliction_Lottery = getAttackLottery();

            int total_Entries = attack_Lottery + Base_Buff_Lottery + Base_Debuff_Lottery + Base_Inflict_Lottery + Base_Swap_Lottery + Base_Heal_Lottery + Base_Heal_Infliction_Lottery;

            int randomnNum = Utilities.chooseNumber(1, total_Entries);

            if(total_Entries <= attack_Lottery)
            {
                chooseAttack(ref trainer1, ref trainer2);
            }
            else if(total_Entries <= attack_Lottery + buff_Lottery)
            {

            }
            else if (total_Entries <= attack_Lottery + buff_Lottery + debuff_Lottery)
            {

            }
            else if (total_Entries <= attack_Lottery + buff_Lottery + debuff_Lottery + inflict_Lottery)
            {

            }
            else if (total_Entries <= attack_Lottery + buff_Lottery + debuff_Lottery + inflict_Lottery + swap_Lottery)
            {

            }
            else if (total_Entries <= attack_Lottery + buff_Lottery + debuff_Lottery + inflict_Lottery + swap_Lottery + heal_Lottery)
            {

            }
            else if (total_Entries <= attack_Lottery + buff_Lottery + debuff_Lottery + inflict_Lottery + swap_Lottery + heal_Lottery + heal_infliction_Lottery)
            {

            }
        }

        protected void chooseAttack(ref Trainer trainer1, ref Trainer trainer2)
        {

            List<int> validMoves = trainer2.activePokemon.askValidTmHmNum();

            if (! (validMoves.Count > 0))
                trainer2.setAction(Trainer.Action.Struggle, -1, -1);
            else
            {
                int[] TmHmWeights = { 0, 0, 0, 0 }; 

                foreach (int i in validMoves)
                {
                    TmHm examinedMove = trainer2.activePokemon.getMove(i);
                    if (examinedMove.getInitPower() > 0)
                        TmHmWeights[i] = examinedMove.getInitPower();
                }
            }

        }
    }
}
