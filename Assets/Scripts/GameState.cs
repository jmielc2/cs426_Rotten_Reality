using UnityEngine;

public class GameState : MonoBehaviour
{
    // Class Member Variables
    private static GameState _instance;
    public static GameState State
    {
        get => _instance;
    }

    // Class Methods
    private void Awake()
    {
        GameState._instance = this;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
