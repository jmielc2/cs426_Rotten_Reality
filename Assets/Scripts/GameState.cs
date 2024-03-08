using UnityEngine;

public class GameState : MonoBehaviour
{
    public static PerceptionManip.State PerceptionState;

    // Class Methods
    private void Awake()
    {
        GameState.PerceptionState = PerceptionManip.State.INVISIBLE;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
