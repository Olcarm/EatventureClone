using UnityEngine;

public class ChefMovingState : ChefBaseState
{
    private Table table;
    private Counter counter;
    private Vector3 targetPosition;


    public override void EnterState(ChefStateManager chef)
    {
        if (chef.GetPreviousState() == chef.WaitingOrderState)
        {
            table = chef.WaitingOrderState.GetTable();
            targetPosition = table.GetChefPosition().position;
        }
        if(chef.GetPreviousState() == chef.FindCounterState){
            counter = chef.FindCounterState.GetCounter();
            targetPosition = counter.GetPreparationPosition().position;
        }
        if(chef.GetPreviousState() == chef.PreparingState){
            targetPosition = table.GetChefPosition().position;
            chef.GetHoldingVisual().UpdateHoldingObject(chef.TakingOrderState.GetOrder());
        }

    }

    public override void UpdateState(ChefStateManager chef)
    {
        Vector3 moveDir = (targetPosition - chef.transform.position).normalized;
        float stopDistance = .1f;
        float rotateSpeed = 10f;
        chef.transform.forward = Vector3.Lerp(chef.transform.forward, moveDir, Time.deltaTime * rotateSpeed);
        if (Vector3.Distance(chef.transform.position, targetPosition) > stopDistance)
        {
            float moveSpeed = 4f;
            chef.transform.position += moveDir * Time.deltaTime * moveSpeed;

        }
        else
        {
            if(chef.GetPreviousState() == chef.WaitingOrderState){
                chef.SwitchState(chef.TakingOrderState);
            }
            if(chef.GetPreviousState() == chef.FindCounterState){
                chef.SwitchState(chef.PreparingState);
            }
            if(chef.GetPreviousState() == chef.PreparingState){
                chef.SwitchState(chef.DeliveringState);
            }
        }
    }


}