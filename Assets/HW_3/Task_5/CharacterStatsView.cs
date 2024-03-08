using UnityEngine;

namespace HW_3.Task_5
{
    public class CharacterStatsView
    {
        public CharacterStatsView(IStats stats)
        {
            Debug.Log($"{nameof(stats.Strength)} - {stats.Strength}");
            Debug.Log($"{nameof(stats.Intellect)} - {stats.Intellect}");
            Debug.Log($"{nameof(stats.Dexterity)} - {stats.Dexterity}");
        }
    }
}