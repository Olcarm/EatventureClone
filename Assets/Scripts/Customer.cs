using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    private enum State
    {
        WaitingForTable,
        MovingToTable,
        Ordering,
        WaitingForOrder,
        OrderDelivered,
    }
    private State state;
    private Table table;
    private Vector3 targetPosition;
    private bool isOrderDelivered;
    private bool isCustomerOrdered;

    void Start()
    {
        state = State.WaitingForTable;
        isCustomerOrdered = false;
    }

    void Update()
    {
        switch (state)
        {
            case State.WaitingForTable:
                List<Table> tableList = OrderManager.Instance.GetTableList();
                for (int i = 0; i < tableList.Count; i++)
                {
                    if (!tableList[i].GetIsOccupied() && tableList[i].GetCustomer() == null)
                    {
                        table = tableList[i];
                        table.SetIsOccupied();
                        table.SetCustomer(this);
                        state = State.MovingToTable;
                        break;
                    }
                }
                
                break;
            case State.MovingToTable:
                targetPosition = table.GetCustomerPosition().position;
                MoveToTargetPosition();
                break;
            case State.Ordering:
                table.CreateTableOrder();
                state = State.WaitingForOrder;
                break;
            case State.WaitingForOrder:
                if (isOrderDelivered)
                {
                    table.SetIsOccupied();
                    state = State.OrderDelivered;
                    
                }
                break;
            case State.OrderDelivered:
                targetPosition = new Vector3(13, 0, 10);
                MoveToTargetPosition();
                float stopDistance = .1f;
                if (Vector3.Distance(transform.position, targetPosition) <= stopDistance)
                {
                    CustomerSpawner.Instance.CustomerLeft();
                    Destroy(gameObject);
                }
                break;

        }
    }
    private void MoveToTargetPosition()
    {
        Vector3 moveDir = (targetPosition - transform.position).normalized;
        float stopDistance = .1f;
        if (Vector3.Distance(transform.position, targetPosition) > stopDistance)
        {
            float moveSpeed = 4f;
            transform.position += moveDir * Time.deltaTime * moveSpeed;
        }
        else
        {
            state = State.Ordering;
        }
    }
    public void OrderDelivered()
    {
        isOrderDelivered = true;
    }
    public void SetCustomerOrdered(){
        isCustomerOrdered = true;
    }
    public bool IsCustomerOrdered(){
        return isCustomerOrdered;
    }
}
