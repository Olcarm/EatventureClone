using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    private bool isOrderDelivered;
    private bool isCustomerOrdered;

    private void Start() {
        isOrderDelivered = false;
        isCustomerOrdered = false;
    }
    public void OrderDelivered()
    {
        isOrderDelivered = !isOrderDelivered;
    }
    public bool GetOrderDelivered(){
        return isOrderDelivered;
    }
    public void SetCustomerOrdered(){
        isCustomerOrdered = !isCustomerOrdered;
    }
    public bool IsCustomerOrdered(){
        return isCustomerOrdered;
    }
}
