using UnityEngine;

public class ChefFindCounterState : ChefBaseState
{
    private Counter counter;
    public override void EnterState(ChefStateManager chef)
    {
        counter = null;
    }

    public override void UpdateState(ChefStateManager chef)
    {
        counter = OrderManager.Instance.GetCounterPosition(chef.TakingOrderState.GetOrder());
        if (counter != null && counter.gameObject.activeSelf)
        {
            chef.SwitchState(chef.MovingState);
        }
    }
    public Counter GetCounter(){
        return counter;
    }
}
