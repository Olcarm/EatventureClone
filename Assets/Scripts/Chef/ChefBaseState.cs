using UnityEngine;

public abstract class ChefBaseState
{
    public abstract void EnterState(ChefStateManager chef);

    public abstract void UpdateState(ChefStateManager chef);

}
