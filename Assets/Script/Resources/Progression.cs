﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Progression",menuName ="Stats/New Progression",order =0)]
public class Progression : ScriptableObject
{
    [SerializeField] ProgressionCharacterClass[] characterClasses = null;

    [System.Serializable]
    class ProgressionCharacterClass {

        public CharacterClass characterClass;
        public float[] health;
    }

    public float GetHealth(CharacterClass characterClass, int level) {

        foreach (ProgressionCharacterClass progressionClass in characterClasses) {
            if (progressionClass.characterClass == characterClass) {

                return progressionClass.health[level - 1];
            }
        }
        return 0;
    }
}
