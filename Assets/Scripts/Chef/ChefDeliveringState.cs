using UnityEngine;

public class ChefDeliveringState : ChefBaseState
{
    private MealSO order;
    private Table table;
    public override void EnterState(ChefStateManager chef)
    {
        HoldingVisual holdingVisual = chef.GetHoldingVisual();
        holdingVisual.ClearHoldingObject();
        order = chef.TakingOrderState.GetOrder();
        table = chef.WaitingOrderState.GetTable();
    }

    public override void UpdateState(ChefStateManager chef)
    {
        table.OrderCompleted();
        UpgradeManager.Instance.AddCash(order.price);
        chef.SwitchState(chef.WaitingOrderState);
    }

}
