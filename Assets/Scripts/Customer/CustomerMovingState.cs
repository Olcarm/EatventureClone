using UnityEngine;

public class CustomerMovingState : CustomerBaseState
{
    private Table table;
    public override void EnterState(CustomerStateManager customer)
    {
        table = customer.WaitingTableState.GetTable();

    }

    public override void UpdateState(CustomerStateManager customer)
    {
        Vector3 targetPosition = table.GetCustomerPosition().position;
        Vector3 customerPosition = customer.transform.position;
        Vector3 moveDir = (targetPosition - customerPosition).normalized;
        float stopDistance = .1f;
        if (Vector3.Distance(customerPosition, targetPosition) > stopDistance)
        {
            float moveSpeed = 4f;
            customer.transform.position += moveDir * Time.deltaTime * moveSpeed;
        }
        else
        {
            customer.SwitchState(customer.WaitingState);
        }
    }

}
