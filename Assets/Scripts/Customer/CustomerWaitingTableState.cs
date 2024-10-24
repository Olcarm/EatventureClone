using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class CustomerWaitingTableState : CustomerBaseState
{
    private List<Table> tableList;
    private Table table;
    public override void EnterState(CustomerStateManager customer)
    {
        tableList = OrderManager.Instance.GetTableList();
    }

    public override void UpdateState(CustomerStateManager customer)
    {
        for (int i = 0; i < tableList.Count; i++)
        {
            if (!tableList[i].GetIsOccupied() && tableList[i].GetCustomer() == null)
            {
                table = tableList[i];
                table.SetIsOccupied();
                table.SetCustomer(customer.GetCustomer());
                customer.SwitchState(customer.MovingState);
                break;
            }
        }
    }
    public Table GetTable(){
        return table;
    }
}
