using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{

    PlayerBaseState currentState;
    PlayerNormalState normalState = new PlayerNormalState();
    PlayerJumpState jumpState = new PlayerJumpState();

    // Start is called before the first frame update
    void Start()
    {
        currentState = normalState;

        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }
}
