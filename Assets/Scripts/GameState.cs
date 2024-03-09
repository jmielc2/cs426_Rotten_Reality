using UnityEngine;

public class GameState : MonoBehaviour
{
    public enum Perception { VISIBLE, INVISIBLE };
    public static Perception PerceptionState;

    // Class Methods
    private void Awake()
    {
        GameState.PerceptionState = Perception.INVISIBLE;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public static void TogglePerceptionState()
    {
        switch (GameState.PerceptionState)
        {
            case (Perception.INVISIBLE):
                GameState.PerceptionState = Perception.VISIBLE;
                break;
            case (Perception.VISIBLE):
                GameState.PerceptionState = Perception.INVISIBLE;
                break;
        }
    }

    public static void ToggleGravityState()
    {

    }

    public static void ToggleSizeState()
    {

    }
}
