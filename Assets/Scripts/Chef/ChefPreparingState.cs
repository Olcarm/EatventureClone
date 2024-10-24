using System.Threading;
using UnityEngine;

public class ChefPreparingState : ChefBaseState
{
    private Counter counter;
    private float timer;
    public override void EnterState(ChefStateManager chef)
    {
        counter = chef.FindCounterState.GetCounter();
        timer = 0;
    }

    public override void UpdateState(ChefStateManager chef)
    {
        float preparationTimeMax = counter.GetPreparationTime();
        if (timer < preparationTimeMax)
        {
            timer += Time.deltaTime;
        }
        else
        {
            counter.SetCounterOccupied();
            counter = null;
            chef.SwitchState(chef.MovingState);
        }
    }


}
