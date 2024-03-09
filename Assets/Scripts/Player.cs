using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    protected Ability selectedAbility;

    // Start is called before the first frame update
    public void Start()
    {
        this.selectedAbility = Ability.GRAVITY;
    }

    // Update is called once per frame
    public void Update()
    {       
        if (Input.GetKeyDown(KeyCode.R))
        {
            this.selectedAbility = GameState.GetNextAbility(this.selectedAbility);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            GameState.ToggleAbility(this.selectedAbility);
        }
    }
}
