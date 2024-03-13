using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Ability { GRAVITY, SPACE, PERCEPTION, NONE };

public class GameState : MonoBehaviour
{
    public static Perception.States perceptionState;
    public static Size.States sizeState;
    private static List<bool> abilityStates;

    // Class Methods
    private void Awake()
    {
        GameState.perceptionState = Perception.States.INVISIBLE;
        GameState.sizeState = Size.States.SMALL;
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
        switch (GameState.sizeState)
        {
            case (Size.States.SMALL):
                GameState.sizeState = Size.States.BIG;
                break;
            case (Size.States.BIG):
                GameState.sizeState = Size.States.SMALL;
                break;
        }

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
                GameState.ToggleSizeState();
                Debug.Log("Size Toggled");
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
