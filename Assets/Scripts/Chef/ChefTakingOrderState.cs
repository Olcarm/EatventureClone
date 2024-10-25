using UnityEngine;

public class ChefTakingOrderState : ChefBaseState
{
    private float timer = 0;
    private float timerMax = .5f;
    public override void EnterState(ChefStateManager chef)
    {
        timer = 0;
    }

    public override void Setup(ChefStateManager chef)
    {
        table = chef.GetTable();
        counter = chef.GetCounter();
        order = chef.GetMealSO();
    }

    public override void UpdateState(ChefStateManager chef)
    {
        Customer customer = table.GetCustomer();
        if (customer.IsCustomerOrdered())
        {
            order = table.GetTableOrder();
            chef.SetMealSO(order);
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

}
