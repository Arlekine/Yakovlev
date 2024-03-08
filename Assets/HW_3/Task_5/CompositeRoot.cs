using System;
using UnityEngine;

namespace HW_3.Task_5
{
    public class CompositeRoot : MonoBehaviour
    {
        [SerializeField] private RaceType _raceType;
        [SerializeField] private SpecializationType _specializationType;
        [SerializeField] private PassiveAbilityType _passiveAbilityType;

        private void Start()
        {
            var basicStats = new BasicStats(0, 0, 0);

            RaceStats raceStats;
            switch (_raceType)
            {
                case RaceType.Orc:
                    raceStats = new RaceStats(basicStats, new Orc());
                    break;

                case RaceType.Elf:
                    raceStats = new RaceStats(basicStats, new Elf());
                    break;

                case RaceType.Human:
                    raceStats = new RaceStats(basicStats, new Human());
                    break;

                default:
                    throw new Exception("Unexpected race");
            }

            SpecializationStats specialization;
            switch (_specializationType)
            {
                case SpecializationType.Barbarian:
                    specialization = new SpecializationStats(raceStats, new Barbarian());
                    break;

                case SpecializationType.Wizard:
                    specialization = new SpecializationStats(raceStats, new Wizard());
                    break;

                case SpecializationType.Thief:
                    specialization = new SpecializationStats(raceStats, new Thief());
                    break;

                default:
                    throw new Exception("Unexpected specialization");
            }

            PassiveAbilityStats passiveAbility;
            switch (_specializationType)
            {
                case SpecializationType.Barbarian:
                    passiveAbility = new PassiveAbilityStats(specialization, new GreatStrength());
                    break;

                case SpecializationType.Wizard:
                    passiveAbility = new PassiveAbilityStats(specialization, new LowIntelligence());
                    break;

                case SpecializationType.Thief:
                    passiveAbility = new PassiveAbilityStats(specialization, new UnlimitedDexterity());
                    break;

                default:
                    throw new Exception("Unexpected passive ability");
            }

            var character = new Character(passiveAbility);
            var statsView = new CharacterStatsView(character.Stats);
        }
    }
}