using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class Chef : MonoBehaviour
{
    private enum State
    {
        WaitingForOrder,
        MovingToTable,
        TakingOrder,
        SearchingForEmptyCounter,
        MovingToCounter,
        Preparing,
        MovingToDeliver,
        Delivering,
    }
    [SerializeField] private HoldingVisual holdingVisual;

    private State state;
    private MealSO order;
    private Vector3 targetPosition;
    private float timerMax = .5f;
    private float timer = 0f;
    private Counter currentCounter;
    private Table table;

    private void Start()
    {
        state = State.WaitingForOrder;
    }

    private void Update()
    {
        switch (state)
        {
            case State.WaitingForOrder:

                List<Table> tableList = OrderManager.Instance.GetTableList();
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
                        Debug.Log(this.gameObject + "Picked the order at " + table.gameObject);
                        state = State.MovingToTable;
                        break;
                    }
                }
                break;
            case State.MovingToTable:
                targetPosition = table.GetChefPosition().position;
                MoveToTargetPosition(State.TakingOrder);
                break;
            case State.TakingOrder:
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
                        state = State.SearchingForEmptyCounter;
                        timer = 0f;
                    }
                }


                break;
            case State.SearchingForEmptyCounter:
                currentCounter = OrderManager.Instance.GetCounterPosition(order);
                if (currentCounter != null && currentCounter.gameObject.activeSelf)
                {
                    state = State.MovingToCounter;
                }
                break;
            case State.MovingToCounter:
                if (currentCounter == null)
                {
                    Debug.LogError("No counter with that mealSO");
                    break;
                }
                targetPosition = currentCounter.GetPreparationPosition().position;
                MoveToTargetPosition(State.Preparing);
                break;
            case State.Preparing:
                PrepareMeal();
                break;
            case State.MovingToDeliver:
                //Counter set to not occupied
                holdingVisual.UpdateHoldingObject(order);
                targetPosition = table.GetChefPosition().position;
                MoveToTargetPosition(State.Delivering);
                break;
            case State.Delivering:
                holdingVisual.ClearHoldingObject();
                table.OrderCompleted();
                UpgradeManager.Instance.AddCash(order.price);
                state = State.WaitingForOrder;
                break;
        }
    }

    private void MoveToTargetPosition(State nextState)
    {
        Vector3 moveDir = (targetPosition - transform.position).normalized;
        float stopDistance = .1f;
        float rotateSpeed = 10f;
        transform.forward = Vector3.Lerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);
        if (Vector3.Distance(transform.position, targetPosition) > stopDistance)
        {
            float moveSpeed = 4f;
            transform.position += moveDir * Time.deltaTime * moveSpeed;

        }
        else
        {
            state = nextState;
        }
    }
    private void PrepareMeal()
    {
        float preparationTimeMax = currentCounter.GetPreparationTime();
        if (timer < preparationTimeMax)
        {
            timer += Time.deltaTime;
        }
        else
        {
            currentCounter.SetCounterOccupied();
            currentCounter = null;
            state = State.MovingToDeliver;
        }
    }

}
