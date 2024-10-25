using UnityEngine;

public class ChefFindCounterState : ChefBaseState
{
    public override void EnterState(ChefStateManager chef)
    {
        counter = null;
    }

    public override void Setup(ChefStateManager chef)
    {
        table = chef.GetTable();
        counter = chef.GetCounter();
        order = chef.GetMealSO();
    }

    public override void UpdateState(ChefStateManager chef)
    {
        counter = OrderManager.Instance.GetCounterPosition(order);
        chef.SetCounter(counter);
        if (counter != null && counter.gameObject.activeSelf)
        {
            chef.SwitchState(chef.MovingState);
        }
    }
}
