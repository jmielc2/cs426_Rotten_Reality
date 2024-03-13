using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Ability { GRAVITY, SPACE, PERCEPTION };

public class GameState : MonoBehaviour
{
    // Global Game State Values (determine behaviour of the game and player progress)
    public static Ability activeAbility;
    public static Perception.States perceptionState;
    public static Size.States sizeState;
    public static Gravity.States gravityState;
    private static List<bool> abilityStates;

    // Default Values
    protected static Perception.States DEFAULT_PERCEPTION = Perception.States.VISIBLE;
    protected static Size.States DEFAULT_SIZE = Size.States.BIG;
    protected static Gravity.States DEFAULT_GRAVITY = Gravity.States.DOWN;

    // Class Methods
    private void Awake()
    {
        GameState.activeAbility = Ability.GRAVITY;
        GameState.perceptionState = GameState.DEFAULT_PERCEPTION;
        GameState.sizeState = GameState.DEFAULT_SIZE;
        GameState.gravityState = GameState.DEFAULT_GRAVITY;
        GameState.abilityStates = new List<bool> { false, false, false };
    }

    protected static void TogglePerceptionState()
    {
        switch (GameState.perceptionState)
        {
            case Perception.States.INVISIBLE:
                GameState.perceptionState = Perception.States.VISIBLE;
                break;
            case Perception.States.VISIBLE:
                GameState.perceptionState = Perception.States.INVISIBLE;
                break;
        }
    }

    protected static void ToggleGravityState()
    {
        switch (GameState.gravityState)
        {
            case Gravity.States.UP:
                GameState.gravityState = Gravity.States.DOWN;
                break;
            case Gravity.States.DOWN:
                GameState.gravityState = Gravity.States.UP;
                break;
        }
    }

    protected static void ToggleSizeState()
    {
        switch (GameState.sizeState)
        {
            case Size.States.SMALL:
                GameState.sizeState = Size.States.BIG;
                break;
            case Size.States.BIG:
                GameState.sizeState = Size.States.SMALL;
                break;
        }
    }

    public static bool IsAbilityMended(Ability ability)
    {
        return GameState.abilityStates[(int) ability];
    }

    public static void SwitchAbility()
    {
        GameState.activeAbility = (Ability)((((int)GameState.activeAbility) + 1) % GameState.abilityStates.Count);
    }

    public static void UnmendAbility(Ability ability)
    {
        GameState.abilityStates[(int)ability] = false;
    }

    public static void MendAbility(Ability ability)
    {
        switch (ability)
        {
            case Ability.GRAVITY:
                if (GameState.gravityState != GameState.DEFAULT_GRAVITY)
                {
                    GameState.ToggleGravityState();
                }
                break;
            case Ability.PERCEPTION:
                if (GameState.perceptionState != GameState.DEFAULT_PERCEPTION)
                {
                    GameState.TogglePerceptionState();
                }
                break;
            case Ability.SPACE:
                if (GameState.sizeState != GameState.DEFAULT_SIZE)
                {
                    GameState.ToggleSizeState();
                }
                break;
        }
        GameState.abilityStates[(int)ability] = true;
    }

    public static void ToggleAbility()
    {
        if (GameState.IsAbilityMended(GameState.activeAbility))
        {
            return;
        }
        switch (GameState.activeAbility)
        {
            case Ability.GRAVITY:
                GameState.ToggleGravityState();
                break;
            case Ability.SPACE:
                GameState.ToggleSizeState();
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
