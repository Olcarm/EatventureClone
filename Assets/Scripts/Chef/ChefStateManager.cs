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
    private Table table;
    private Counter counter;
    private MealSO mealSO;
    [SerializeField] private HoldingVisual holdingVisual;


    private void Start()
    {
        //Starting state for the state machine
        currentState = WaitingOrderState;

        currentState.EnterState(this);
        currentState.Setup(this);
    }

    private void Update()
    {
        currentState.UpdateState(this);
    }


    public void SwitchState(ChefBaseState state)
    {
        previousState = currentState;
        currentState = state;

        state.Setup(this);
        state.EnterState(this);

    }
    public ChefBaseState GetPreviousState()
    {
        return previousState;
    }
    public HoldingVisual GetHoldingVisual()
    {
        return holdingVisual;
    }
    public void SetMealSO(MealSO mealSO)
    {
        this.mealSO = mealSO;
    }
    public void SetCounter(Counter counter)
    {
        this.counter = counter;
    }
    public void SetTable(Table table)
    {
        this.table = table;
    }
    public MealSO GetMealSO()
    {
        return mealSO;
    }
    public Counter GetCounter()
    {
        return counter;
    }
    public Table GetTable()
    {
        return table;
    }


}
