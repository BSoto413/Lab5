using UnityEngine;
using System.Collections.Generic;

public class Lab5Assignment : MonoBehaviour
{
    // Variables editable in the Unity Inspector
    public string characterName = "Sir John";
    public int characterLevel = 3;
    public int constitutionScore = 21;
    public bool isHillDwarf = true;
    public bool hasToughFeat = true;
    public bool useAverageHP = true;

    public Dictionary<string, int> classHitDice = new Dictionary<string, int>()
    {
        {"Artificer", 8},
        {"Barbarian", 12},
        {"Bard", 8},
        {"Cleric", 8},
        {"Druid", 8},
        {"Fighter", 10},
        {"Monk", 8},
        {"Ranger", 10},
        {"Rogue", 8},
        {"Paladin", 10},
        {"Sorcerer", 6},
        {"Warlock", 8},
        {"Wizard", 6}
    };

    void Start()
    {
        CalculateHP();
    }

    void CalculateHP()
    {
        int hitPoints = 0;

        // Base hit points based on character class and level
        if (classHitDice.ContainsKey(characterClass))
        {
            hitPoints = classHitDice[characterClass] + RollOrAverageHP();
        }
        else
        {
            Debug.LogError($"Class '{characterClass}' not found in the dictionary.");
            return;
        }

        // Apply Constitution modifier
        int constitutionModifier = (constitutionScore - 10) / 2;
        hitPoints += constitutionModifier * characterLevel;

        if (isHillDwarf)
        {
            hitPoints += characterLevel;
        }

        if (hasToughFeat)
        {
            hitPoints += 2 * characterLevel;
        }

        Debug.Log($"{characterName}'s HP: {hitPoints}");
    }

    int RollOrAverageHP()
    {
        if (useAverageHP)
        {
            return classHitDice[characterClass] / 2 + 1;
        }
        else
        {
            return Random.Range(1, classHitDice[characterClass] + 1);
        }
    }

    string characterClass
    {
        get
        {
            return characterName.Split(' ')[2];
        }
    }
}
