using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Ability { GRAVITY, SPACE, PERCEPTION, NONE };

public class GameState : MonoBehaviour
{
    public static Perception.States perceptionState;
    private static List<bool> abilityStates;

    // Class Methods
    private void Awake()
    {
        GameState.perceptionState = Perception.States.INVISIBLE;
        GameState.abilityStates = new List<bool> { false, false, false };
    }

    public static void TogglePerceptionState()
    {
        switch (GameState.perceptionState)
        {
            case (Perception.States.INVISIBLE):
                GameState.perceptionState = Perception.States.VISIBLE;
                break;
            case (Perception.States.VISIBLE):
                GameState.perceptionState = Perception.States.INVISIBLE;
                break;
        }
    }

    public static void ToggleGravityState()
    {

    }

    public static void ToggleSizeState()
    {

    }


    public static bool IsAbilityMended(Ability ability)
    {
        if (ability == Ability.NONE)
        {
            return false;
        }
        return (GameState.abilityStates[(int) ability]);
    }

    public static Ability GetNextAbility(Ability ability)
    {
        return (Ability)(((int)ability + 1) % GameState.abilityStates.Count);
    }

    public static void UnmendAbility(Ability ability)
    {
        if (ability == Ability.NONE)
        {
            return;
        }
        GameState.abilityStates[(int)ability] = false;
    }

    public static void MendAbility(Ability ability)
    {
        if (ability == Ability.NONE)
        {
            return;
        }
        GameState.abilityStates[(int)ability] = true;
    }

    public static void ToggleAbility(Ability ability)
    {
        if (GameState.IsAbilityMended(ability))
        {
            return;
        }
        switch (ability)
        {
            case Ability.GRAVITY:
                break;
            case Ability.SPACE:
                break;
            case Ability.PERCEPTION:
                GameState.TogglePerceptionState();
                break;
        }
    }

    public static bool IsGameWon()
    {
        foreach (bool state in GameState.abilityStates)
        {
            if (!state)
            {
                return false;
            }
        }
        return true;
    }
}
