using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    private bool isOrderDelivered;
    private bool isCustomerOrdered;

    public void OrderDelivered()
    {
        isOrderDelivered = true;
    }
    public bool GetOrderDelivered(){
        return isOrderDelivered;
    }
    public void SetCustomerOrdered(){
        isCustomerOrdered = true;
    }
    public bool IsCustomerOrdered(){
        return isCustomerOrdered;
    }
}
