using UnityEngine;

public class CustomerWaitingState : CustomerBaseState
{
    private Table table;
    public override void EnterState(CustomerStateManager customer)
    {
        table = customer.WaitingTableState.GetTable();
        table.CreateTableOrder();
    }

    public override void UpdateState(CustomerStateManager customer)
    {
        if(customer.GetCustomer().GetOrderDelivered()){
            customer.SwitchState(customer.OrderDeliveredState);
        }
    }

}
