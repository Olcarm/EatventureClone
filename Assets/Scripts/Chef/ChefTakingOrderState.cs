using UnityEngine;

public class ChefTakingOrderState : ChefBaseState
{
    private Table table;
    private MealSO order;
    private float timer = 0;
    private float timerMax = .5f;
    public override void EnterState(ChefStateManager chef)
    {
        table = chef.WaitingOrderState.GetTable();
        timer = 0;
    }

    public override void UpdateState(ChefStateManager chef)
    {
        Customer customer = table.GetCustomer();
        if (customer.IsCustomerOrdered())
        {
            order = table.GetTableOrder();
            if (timer < timerMax)
            {
                timer += Time.deltaTime;
            }
            else
            {
                chef.SwitchState(chef.FindCounterState);
            }
        }
    }
    public MealSO GetOrder(){
        return order;
    }

}
