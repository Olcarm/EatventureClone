using UnityEngine;

public class CustomerStateManager : MonoBehaviour
{
    CustomerBaseState currentState;
    public CustomerWaitingTableState WaitingTableState = new CustomerWaitingTableState();
    public CustomerMovingState MovingState = new CustomerMovingState();
    public CustomerWaitingState WaitingState = new CustomerWaitingState();
    public CustomerOrderDeliveredState OrderDeliveredState = new CustomerOrderDeliveredState();
    private Customer customer;

    private void Start()
    {
        customer = gameObject.GetComponent<Customer>();
        currentState = WaitingTableState;

        currentState.EnterState(this);
    }

    private void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(CustomerBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }
    public Customer GetCustomer(){
        return customer;
    }
    public void DestroyCustomer(){
        Destroy(gameObject);
    }
}
