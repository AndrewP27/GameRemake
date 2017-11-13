using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRemake
{
    public static class UtilitiesPkmTable
    {
        private static List<string[]> PkmTable = new List<string[]>();
        private static char DELIMITER = ',';
        private static char LINE_DELIMITER = '\n';
        private static int MAXLINENUMPOKEMON = -1;
        public static void initTable()
        {
            string table = PokemonRemake.Properties.Resources.PkmTable;
            string[] lines = table.Split(LINE_DELIMITER);
            for (int i = 1; i < lines.Length; i++)
            {
                string thisLine = lines[i];
                thisLine = thisLine.Replace("\r", "");
                string[] data = thisLine.Split(DELIMITER);
                PkmTable.Add(data);
            }
            MAXLINENUMPOKEMON = PkmTable.Count-1;
        }
        public static string[] getPkmTableLine(int lineNum)
        {
            return PkmTable.ElementAt(lineNum);
        }

        public static int getMaxLineNum()
        {
            return MAXLINENUMPOKEMON;
        }

        public static string getPkmName(int idNum)
        {
            if (idNum > -1)
                return PkmTable.ElementAt(idNum)[1];
            else
                return "ERROR";
        }

        public static double[] getPkmStats(int idNum)
        {
            string[] line = PkmTable.ElementAt(idNum);

            double[] output = new double[line.Length - 2];

            for (int i = 2; i < line.Length; i++)
            {
                output[i - 2] = Convert.ToDouble(line[i]);
            }

            return output;
        }
    }

    public static class UtilitiesTmTable
    {
        private static List<string[]> TmTable = new List<string[]>();
        private static char DELIMITER = ',';
        private static char LINE_DELIMITER = '\n';
        private static int MAXLINENUMTMHM = -1;
        public static void initTable()
        {
            string table = PokemonRemake.Properties.Resources.TmTable;
            string[] lines = table.Split(LINE_DELIMITER);
            for (int i = 1; i < lines.Length; i++)
            {
                string thisLine = lines[i];
                thisLine = thisLine.Replace("\r", "");
                string[] data = thisLine.Split(DELIMITER);
                TmTable.Add(data);
            }

            MAXLINENUMTMHM = TmTable.Count;
        }
        public static string[] getTmTableLine(int idNum)
        {
            return TmTable.ElementAt(idNum - 1);
        }

        public static string getTmName(int idNum)
        {
            if (idNum > -1)
                return TmTable.ElementAt(idNum-1)[1];
            else
                return "ERROR";
        }
        public static int getMaxLineNum()
        {
            return MAXLINENUMTMHM;
        }

        public static string getTmDescription(int idNum)
        {
            if (idNum > -1)
                return TmTable.ElementAt(idNum - 1)[2];
            else
                return "ERROR";
        }

        public static double[] getTmStats(int idNum)
        {
            string[] line = TmTable.ElementAt(idNum - 1);

            double[] output = new double[line.Length - 3];

            for (int i = 3; i < line.Length; i++)
            {
                output[i - 3] = Convert.ToDouble(line[i]);
            }

            return output;
        }

    }

    public static class UtilitiesItemTable
    {
        private static List<string[]> ItemTable = new List<string[]>();
        private static char DELIMITER = ',';
        private static char LINE_DELIMITER = '\n';
        private static int MAXLINENUMTMHM = -1;
        public static void initTable()
        {
            string table = PokemonRemake.Properties.Resources.ItemTable;
            string[] lines = table.Split(LINE_DELIMITER);
            for (int i = 1; i < lines.Length; i++)
            {
                string thisLine = lines[i];
                thisLine = thisLine.Replace("\r", "");
                string[] data = thisLine.Split(DELIMITER);
                ItemTable.Add(data);
            }

            MAXLINENUMTMHM = ItemTable.Count;
        }
        public static string[] getItemTableLine(int idNum)
        {
            return ItemTable.ElementAt(idNum - 1);
        }

        public static string getItemName(int idNum)
        {
            if (idNum > -1)
                return ItemTable.ElementAt(idNum - 1)[1];
            else
                return "ERROR";
        }
        public static int getMaxLineNum()
        {
            return MAXLINENUMTMHM;
        }

        public static string getItemDescription(int idNum)
        {
            if (idNum > -1)
                return ItemTable.ElementAt(idNum - 1)[2];
            else
                return "ERROR";
        }

        public static double[] getItemStats(int idNum)
        {
            string[] line = ItemTable.ElementAt(idNum - 1);

            double[] output = new double[line.Length - 3];

            for (int i = 3; i < line.Length; i++)
            {
                output[i - 3] = Convert.ToDouble(line[i]);
            }

            return output;
        }

    }

    public static class Utilities
    {

        private static Random gen = new Random();
        public static TmHm struggle = new TmHmStruggle();
        private static string basePath = "";

        public static string getBasePath()
        {
            if(basePath == "")
            {
                string RunningPath = AppDomain.CurrentDomain.BaseDirectory;

                basePath = string.Format("{0}Resources\\", Path.GetFullPath(Path.Combine(RunningPath, @"..\..\")));
            }

            return basePath;
        }

        public static string getCategoryName(int CatNum)
        {
            //cat key
            //1 == Physical
            //2 == Special
            //3 == Status
            switch (CatNum)
            {
                case 1:
                    return "Physical";
                case 2:
                    return "Special";
                case 3:
                    return "Status";
                default:
                    return "ERROR";
            }
        }
        public static string getTypeName(int typeNum)
        {
            switch (typeNum)
            {
                case 1:
                    return "Normal";
                case 2:
                    return "Fire";
                case 3:
                    return "Water";
                case 4:
                    return "Electric";
                case 5:
                    return "Grass";
                case 6:
                    return "Ice";
                case 7:
                    return "Fighting";
                case 8:
                    return "Poison";
                case 9:
                    return "Ground";
                case 10:
                    return "Flying";
                case 11:
                    return "Psychic";
                case 12:
                    return "Bug";
                case 13:
                    return "Rock";
                case 14:
                    return "Ghost";
                case 15:
                    return "Dragon";
                case 16:
                    return "Dark";
                case 17:
                    return "Steel";
                default:
                    return "ERROR";
            }

        }
        public static double[,] typeChart = new double[,]
        {
            {1, 1, 1, 1, 1, 1, 2, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1},
            {1, .5, 2, 1, .5, .5, 1, 1, 2, 1, 1, .5, 2, 1, 1, 1, .5},
            {1, .5, .5, 2, 2, .5, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, .5},
            {1, 1, 1, .5, 1, 1, 1, 1, 2, .5, 1, 1, 1, 1, 1, 1, .5},
            {1, 2, .5, .5, .5, 2, 1, 2, .5, 2, 1, 2, 1, 1, 1, 1, 1},
            {1, 2, 1, 1, 1, .5, 2, 1, 1, 1, 1, 1, 2, 1, 1, 1, 2},
            {1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, .5, .5, 1, 1, 1, 2},
            {1, 1, 1, 1, .5, 1, .5, .5, 2, 1, 2, .5, 1, 1, 1, 1, 1},
            {1, 1, 2, 0, 2, 2, 1, .5, 1, 1, 1, 1, .5, 1, 1, 1, 1},
            {1, 1, 1, 2, .5, 2, .5, 1, 0, 1, 1, .5, 2, 1, 1, 1, 1},
            {1, 1, 1, 1, 1, 1, .5, 1, 1, 1, .5, 2, 1, 2, 1, 2, 1},
            {1, 2, 1, 1, .5, 1, .5, 1, .5, 2, 1, 1, 2, 1, 1, 1, 1},
            {.5, .5, 2, 1, 2, 1, 2, .5, 2, .5, 1, 1, 1, 1, 1, 1, 2},
            {0, 1, 1, 1, 1, 1, 0, .5, 1, 1, 1, .5, 1, 2, 1, 2, 1},
            {1, .5, .5, .5, .5, 2, 1, 1, 1, 1, 1, 1, 1, 1, 2, 1, 1},
            {1, 1, 1, 1, 1, 1, 2, 1, 1, 1, 0, 2, 1, .5, 1, .5, 1},
            {.5, 2, 1, 1, .5, .5, 2, 0, 2, .5, .5, .5, .5, .5, .5, .5, .5}
        };

        public static string toBinary(int num)
        {
            bool notDone = true;
            int maxPow2 = 0;
            int rem = num;
            string val = "";

            while (notDone)
            {
                if ((2 ^ maxPow2) < num)
                    maxPow2++;
                else
                    notDone = true;
            }

            for (int i = maxPow2; i >= 0; i--)
            {
                if ((2 ^ i) > rem)
                    val += "0";
                else
                {
                    rem -= 2 ^ i;
                    val += "1";
                }
            }
            return val;
        }

        public static double Effectiveness(int defType, int atkType)
        {
            //Normal = 1
            //Fire = 2
            //Water = 3
            //Electric = 4
            //Grass = 5
            //Ice = 6
            //Fighting = 7
            //Poision = 8
            //Ground = 9
            //Flying = 10
            //Psychic = 11
            //Bug = 12
            //Rock = 13
            //Ghost = 14
            //Dragon = 15
            //Dark = 16
            //Steel = 17
            return typeChart[defType - 1, atkType - 1];
        }

        public static int chooseNumber(int min, int max)
        {
            return gen.Next(min, max + 1);
        }

        public static int getXLocation(int idNum)
        {
            return (idNum - 1) % 25;
        }

        public static int getYLocation(int idNum)
        {
            return (idNum - 1) / 25;
        }

        public static int getNumTmHm()
        {
            return 84;
        }

        public static Item getItemObj(int idNum)
        {
            switch (idNum)
            {
                case 1:
                    return new ItemPotion();
                case 2:
                    return new ItemSuper_Potion();
                case 3:
                    return new ItemHyper_Potion();
                case 4:
                    return new ItemMax_Potion();
                case 5:
                    return new ItemAntidote();
                case 6:
                    return new ItemBurn_Heal();
                case 7:
                    return new ItemIce_Heal();
                case 8:
                    return new ItemAwakening();
                case 9:
                    return new ItemParalyz_Heal();
                case 10:
                    return new ItemFull_Heal();
                case 11:
                    return new ItemFull_Restore();
                case 12:
                    return new ItemX_Accuracy();
                case 13:
                    return new ItemX_Attack();
                case 14:
                    return new ItemX_Defend();
                case 15:
                    return new ItemX_Speed();
                case 16:
                    return new ItemX_Special();
                case 17:
                    return new ItemX_Special_Defense();
                default:
                    return null;
            }
        }
        public static TmHm getMoveObj(int idNum)
        {
            switch (idNum)
            {
                case 1:
                    return new TmHmAbsorb();
                case 2:
                    return new TmHmAcid();
                case 3:
                    return new TmHmAcid_Armor();
                case 4:
                    return new TmHmAgility();
                case 5:
                    return new TmHmAmnesia();
                case 6:
                    return new TmHmAurora_Beam();
                case 7:
                    return new TmHmBarrage();
                case 8:
                    return new TmHmBarrier();
                case 9:
                    return new TmHmBide();
                case 10:
                    return new TmHmBind();
                case 11:
                    return new TmHmBite();
                case 12:
                    return new TmHmBlizzard();
                case 13:
                    return new TmHmBody_Slam();
                case 14:
                    return new TmHmBonemerang();
                case 15:
                    return new TmHmBone_Club();
                case 16:
                    return new TmHmBubble();
                case 17:
                    return new TmHmBubble_Beam();
                case 18:
                    return new TmHmClamp();
                case 19:
                    return new TmHmComet_Punch();
                case 20:
                    return new TmHmConfuse_Ray();
                case 21:
                    return new TmHmConfusion();
                case 22:
                    return new TmHmConstrict();
                case 23:
                    return new TmHmConversion();
                case 24:
                    return new TmHmCounter();
                case 25:
                    return new TmHmCrabhammer();
                case 26:
                    return new TmHmCut();
                case 27:
                    return new TmHmDefense_Curl();
                case 28:
                    return new TmHmDig();
                case 29:
                    return new TmHmDisable();
                case 30:
                    return new TmHmDizzy_Punch();
                case 31:
                    return new TmHmDouble_Kick();
                case 32:
                    return new TmHmDouble_Slap();
                case 33:
                    return new TmHmDouble_Team();
                case 34:
                    return new TmHmDoubleEdge();
                case 35:
                    return new TmHmDragon_Rage();
                case 36:
                    return new TmHmDream_Eater();
                case 37:
                    return new TmHmDrill_Peck();
                case 38:
                    return new TmHmEarthquake();
                case 39:
                    return new TmHmEgg_bomb();
                case 40:
                    return new TmHmEmber();
                case 41:
                    return new TmHmExplosion();
                case 42:
                    return new TmHmFire_Blast();
                case 43:
                    return new TmHmFire_Punch();
                case 44:
                    return new TmHmFire_Spin();
                case 45:
                    return new TmHmFissure();
                case 46:
                    return new TmHmFlamethrower();
                case 47:
                    return new TmHmFlash();
                case 48:
                    return new TmHmFly();
                case 49:
                    return new TmHmFocus_Energy();
                case 50:
                    return new TmHmFury_Attack();
                case 51:
                    return new TmHmFury_Swipes();
                case 52:
                    return new TmHmGlare();
                case 53:
                    return new TmHmGrowl();
                case 54:
                    return new TmHmGrowth();
                case 55:
                    return new TmHmGuillotine();
                case 56:
                    return new TmHmGust();
                case 57:
                    return new TmHmHarden();
                case 58:
                    return new TmHmHaze();
                case 59:
                    return new TmHmHeadbutt();
                case 60:
                    return new TmHmHigh_Jump_Kick();
                case 61:
                    return new TmHmHorn_Attack();
                case 62:
                    return new TmHmHorn_Drill();
                case 63:
                    return new TmHmHydro_Pump();
                case 64:
                    return new TmHmHyper_Beam();
                case 65:
                    return new TmHmHyper_Fang();
                case 66:
                    return new TmHmHypnosis();
                case 67:
                    return new TmHmIce_Beam();
                case 68:
                    return new TmHmIce_Punch();
                case 69:
                    return new TmHmJump_Kick();
                case 70:
                    return new TmHmKarate_Chop();
                case 71:
                    return new TmHmKinesis();
                case 72:
                    return new TmHmLeech_Life();
                case 73:
                    return new TmHmLeech_Seed();
                case 74:
                    return new TmHmLeer();
                case 75:
                    return new TmHmLick();
                case 76:
                    return new TmHmLight_Screen();
                case 77:
                    return new TmHmLovely_Kiss();
                case 78:
                    return new TmHmLow_Kick();
                case 79:
                    return new TmHmMeditate();
                case 80:
                    return new TmHmMega_Drain();
                case 81:
                    return new TmHmMega_Kick();
                case 82:
                    return new TmHmMega_Punch();
                case 83:
                    return new TmHmMetronome();
                case 84:
                    return new TmHmMimic();
                case 85:
                    return new TmHmMinimize();
                case 86:
                    return new TmHmMirror_Move();
                case 87:
                    return new TmHmMist();
                case 88:
                    return new TmHmNight_Shade();
                case 89:
                    return new TmHmPay_day();
                case 90:
                    return new TmHmPeck();
                case 91:
                    return new TmHmPetal_Dance();
                case 92:
                    return new TmHmPin_Missile();
                case 93:
                    return new TmHmPoison_Gas();
                case 94:
                    return new TmHmPoison_Powder();
                case 95:
                    return new TmHmPoison_Sting();
                case 96:
                    return new TmHmPound();
                case 97:
                    return new TmHmPsybeam();
                case 98:
                    return new TmHmPsychic();
                case 99:
                    return new TmHmPsywave();
                case 100:
                    return new TmHmQuick_Attack();
                case 101:
                    return new TmHmRage();
                case 102:
                    return new TmHmRazor_Leaf();
                case 103:
                    return new TmHmRazor_Wind();
                case 104:
                    return new TmHmRecover();
                case 105:
                    return new TmHmReflect();
                case 106:
                    return new TmHmRest();
                case 107:
                    return new TmHmRoar();
                case 108:
                    return new TmHmRock_Slide();
                case 109:
                    return new TmHmRock_Throw();
                case 110:
                    return new TmHmRolling_Kick();
                case 111:
                    return new TmHmSand_Attack();
                case 112:
                    return new TmHmScratch();
                case 113:
                    return new TmHmScreech();
                case 114:
                    return new TmHmSeismic_Toss();
                case 115:
                    return new TmHmSelf_Destruct();
                case 116:
                    return new TmHmSharpen();
                case 117:
                    return new TmHmSing();
                case 118:
                    return new TmHmSkull_Bash();
                case 119:
                    return new TmHmSky_Attack();
                case 120:
                    return new TmHmSlam();
                case 121:
                    return new TmHmSlash();
                case 122:
                    return new TmHmSleep_Powder();
                case 123:
                    return new TmHmSludge();
                case 124:
                    return new TmHmSmog();
                case 125:
                    return new TmHmSmokescreen();
                case 126:
                    return new TmHmSoft_Boiled();
                case 127:
                    return new TmHmSolar_Beam();
                case 128:
                    return new TmHmSonic_Boom();
                case 129:
                    return new TmHmSpike_Cannon();
                case 130:
                    return new TmHmSplash();
                case 131:
                    return new TmHmSpore();
                case 132:
                    return new TmHmStomp();
                case 133:
                    return new TmHmStrength();
                case 134:
                    return new TmHmString_Shot();
                case 135:
                    return new TmHmStruggle();
                case 136:
                    return new TmHmStun_Spore();
                case 137:
                    return new TmHmSubmission();
                case 138:
                    return new TmHmSubstitute();
                case 139:
                    return new TmHmSupersonic();
                case 140:
                    return new TmHmSuper_Fang();
                case 141:
                    return new TmHmSurf();
                case 142:
                    return new TmHmSwift();
                case 143:
                    return new TmHmSwords_Dance();
                case 144:
                    return new TmHmTackle();
                case 145:
                    return new TmHmTail_Whip();
                case 146:
                    return new TmHmTake_Down();
                case 147:
                    return new TmHmTeleport();
                case 148:
                    return new TmHmThrash();
                case 149:
                    return new TmHmThuder_Wave();
                case 150:
                    return new TmHmThunder();
                case 151:
                    return new TmHmThunderbolt();
                case 152:
                    return new TmHmThunder_Punch();
                case 153:
                    return new TmHmThunder_Shock();
                case 154:
                    return new TmHmToxic();
                case 155:
                    return new TmHmTransform();
                case 156:
                    return new TmHmTri_Attack();
                case 157:
                    return new TmHmTwineedle();
                case 158:
                    return new TmHmVice_Grip();
                case 159:
                    return new TmHmVine_Whip();
                case 160:
                    return new TmHmWaterfall();
                case 161:
                    return new TmHmWater_Gun();
                case 162:
                    return new TmHmWhirlwind();
                case 163:
                    return new TmHmWing_Attack();
                case 164:
                    return new TmHmWithdraw();
                case 165:
                    return new TmHmWrap();
                default:
                    return null;
            }
        }
    }
}
