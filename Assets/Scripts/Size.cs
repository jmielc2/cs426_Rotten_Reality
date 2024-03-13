using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Size : MonoBehaviour
{
    //[SerializeField] protected bool isbig = false;

    public enum States { BIG, SMALL };
    protected Size.States state;
    protected Vector3 largeScale;
    protected Vector3 smallScale;

    public void Start()
    {
        largeScale = new Vector3(1,1,1);
        smallScale = new Vector3(3,3,3);

        this.UpdateSize();

    }

    // Update is called once per frame
    void Update()
    {
        if (this.state != GameState.sizeState)
        {
            this.UpdateSize();
        }
    }


    /*private void TripleSize()
    {
        transform.localScale *= 3; // Triple the size of the player
        Player playerScript = GetComponent<Player>();
        if (playerScript != null)
        {
            playerScript.SetJumpForce(playerScript.GetAdjustedJumpForce() * 3); // Triple the jump force
        }
        isTripled = true;
    }


    private void SetSize()
    {
        transform.localScale /= 3; // 1/3 the size of the player
        Player playerScript = GetComponent<Player>();
        if (playerScript != null)
        {
            playerScript.SetJumpForce(playerScript.GetAdjustedJumpForce() / 3); // 1/3 the jump force
        }
        isTripled = false;
    }
    */

    protected void UpdateSize()
    {
        this.state = GameState.sizeState;
        switch (this.state)
        {
            case Size.States.SMALL:
                Debug.Log("Toggle to Big");
                transform.localScale = smallScale; // Triple the size of the player
                break;
            case Size.States.BIG:
                transform.localScale = largeScale; // 1/3 the size of the player
                Debug.Log("Toggle to Small");
                break;
        }
    }
}
