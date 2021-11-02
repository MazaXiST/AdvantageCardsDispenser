using System;

namespace Assets.Scripts
{
    public class AdvantageCardModel
    {
        private UInt16 _power = 0;
        private AdvantageBonus _bonus = AdvantageBonus.NONE;
        public UInt16 Power
        {
            get => _power;
        }

        public AdvantageBonus Bonus
        {
            get => _bonus;
        }

        public AdvantageCardModel(AdvantagePowerAndBonus advantage)
        {
            switch (advantage)
            {
                case AdvantagePowerAndBonus.ZERO:

                    _power = 0;
                    _bonus = AdvantageBonus.NONE;
                    break;

                case AdvantagePowerAndBonus.ZERO_WITH_SCULL:

                    _power = 0;
                    _bonus = AdvantageBonus.SCULL;
                    break;

                case AdvantagePowerAndBonus.ONE_WITH_SWORD:

                    _power = 1;
                    _bonus = AdvantageBonus.SWORD;
                    break;

                case AdvantagePowerAndBonus.ONE_WITH_TOWER:

                    _power = 1;
                    _bonus = AdvantageBonus.TOWER;
                    break;

                case AdvantagePowerAndBonus.TWO:

                    _power = 2;
                    _bonus = AdvantageBonus.NONE;
                    break;

                case AdvantagePowerAndBonus.THREE:

                    _power = 3;
                    _bonus = AdvantageBonus.NONE;
                    break;
            }
        }
    }

}