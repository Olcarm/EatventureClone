using System.Threading;
using UnityEngine;

public class ChefPreparingState : ChefBaseState
{
    private float timer;
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
        float preparationTimeMax = counter.GetPreparationTime();
        if (timer < preparationTimeMax)
        {
            timer += Time.deltaTime;
        }
        else
        {
            counter.SetCounterOccupied();
            
            chef.SwitchState(chef.MovingState);
        }
    }


}
