using System;
using UnityEngine;

public class CustomerOrderDeliveredState : CustomerBaseState
{
    private Vector3 targetPosition;
    public override void EnterState(CustomerStateManager customer)
    {
        targetPosition = new Vector3(13, 0, 10);
    }

    public override void UpdateState(CustomerStateManager customer)
    {

        Vector3 moveDir = (targetPosition - customer.transform.position).normalized;
        float stopDistance = .1f;
        if (Vector3.Distance(customer.transform.position, targetPosition) > stopDistance)
        {
            float moveSpeed = 4f;
            customer.transform.position += moveDir * Time.deltaTime * moveSpeed;
        }
        if (Vector3.Distance(customer.transform.position, targetPosition) <= stopDistance)
        {
            Table table = customer.WaitingTableState.GetTable();
            table.SetIsOccupied();
            CustomerSpawner.Instance.CustomerLeft();
            customer.DestroyCustomer();
            
        }
    }

}
