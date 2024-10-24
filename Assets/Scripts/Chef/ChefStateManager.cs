using System.Diagnostics;
using UnityEngine;

public class ChefStateManager : MonoBehaviour
{
    ChefBaseState currentState;
    public ChefWaitingOrderState WaitingOrderState = new ChefWaitingOrderState();
    public ChefMovingState MovingState = new ChefMovingState();
    public ChefTakingOrderState TakingOrderState = new ChefTakingOrderState();
    public ChefFindCounterState FindCounterState = new ChefFindCounterState();
    public ChefPreparingState PreparingState = new ChefPreparingState();
    public ChefDeliveringState DeliveringState = new ChefDeliveringState();
    private ChefBaseState previousState;

    [SerializeField] private HoldingVisual holdingVisual;

    private void Start()
    {
        //Starting state for the state machine
        currentState = WaitingOrderState;

        currentState.EnterState(this);
    }

    private void Update()
    {
        currentState.UpdateState(this);
    }


    public void SwitchState(ChefBaseState state)
    {
        previousState = currentState;
        currentState = state;
        state.EnterState(this);
    }
    public ChefBaseState GetPreviousState(){
        return previousState;
    }
    public HoldingVisual GetHoldingVisual(){
        return holdingVisual;
    }

}
