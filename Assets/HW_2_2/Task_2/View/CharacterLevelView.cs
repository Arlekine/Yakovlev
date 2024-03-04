using System;
using TMPro;
using UnityEngine;

namespace HW_2_2.Task_2
{
    public class CharacterLevelView : MonoBehaviour
    {
        private const string LevelFormat = "Level {0}";

        [SerializeField] private TMP_Text _levelText;

        public void SetLevel(int level)
        {
            _levelText.text = String.Format(LevelFormat, level.ToString());
        }
    }
}