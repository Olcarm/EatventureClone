using System.Collections.Generic;
using UnityEngine;

public class ChefWaitingOrderState : ChefBaseState
{
    private List<Table> tableList;

    public override void EnterState(ChefStateManager chef)
    {
        tableList = OrderManager.Instance.GetTableList();
    }

    public override void Setup(ChefStateManager chef)
    {
        table = chef.GetTable();
        counter = chef.GetCounter();
        order = chef.GetMealSO();
    }

    public override void UpdateState(ChefStateManager chef)
    {
        for (int i = 0; i < tableList.Count; i++)
                {
                    Table tempTable = tableList[i];
                    if (tempTable.GetTableOrder() == null)
                    {
                        continue;
                    }
                    if (tempTable.GetIsOccupied() && !tempTable.GetIsServingExist())
                    {
                        tempTable.SetIsServingExist();
                        table = tableList[i];
                        chef.SetTable(tempTable);
                        chef.SwitchState(chef.MovingState);
                        break;
                    }
                }
    }


}
