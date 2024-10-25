using UnityEngine;

public class ChefDeliveringState : ChefBaseState
{
    public override void EnterState(ChefStateManager chef)
    {
        HoldingVisual holdingVisual = chef.GetHoldingVisual();
        holdingVisual.ClearHoldingObject();
    }

    public override void Setup(ChefStateManager chef)
    {
        table = chef.GetTable();
        counter = chef.GetCounter();
        order = chef.GetMealSO();
    }

    public override void UpdateState(ChefStateManager chef)
    {
        table.OrderCompleted();
        UpgradeManager.Instance.AddCash(order.price);
        chef.SwitchState(chef.WaitingOrderState);
    }

}
