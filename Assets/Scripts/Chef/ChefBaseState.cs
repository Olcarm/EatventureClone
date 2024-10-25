using UnityEngine;

public abstract class ChefBaseState
{
    protected Table table;
    protected Counter counter;
    protected MealSO order;

    public abstract void EnterState(ChefStateManager chef);

    public abstract void UpdateState(ChefStateManager chef);
    public abstract void Setup(ChefStateManager chef);

}
