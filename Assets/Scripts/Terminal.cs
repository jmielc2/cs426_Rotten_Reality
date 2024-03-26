using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terminal : MonoBehaviour
{
    [SerializeField] private Ability abilityToMend;

    public void TriggerTerminal() {
        Debug.LogFormat("{0} Terminal Triggered", this.abilityToMend);
        if (GameState.IsAbilityMended(this.abilityToMend)) {
            GameState.UnmendAbility(this.abilityToMend);
        } else {
            GameState.MendAbility(this.abilityToMend);
        }
    }
}
