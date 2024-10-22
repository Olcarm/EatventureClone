using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class Table : MonoBehaviour
{


    [SerializeField] private Transform customerPosition;
    [SerializeField] private Transform chefPosition;
    private MealSO order;
    private Customer customer;
    private bool isServingExist = false;
    private bool isOccupied = false;

    public void OrderCompleted()
    {
        customer.OrderDelivered();
        isServingExist = false;
        customer = null;
        SetTableOrderToNull();
    }
    public void SetCustomer(Customer customer)
    {
        this.customer = customer;
    }
    public Customer GetCustomer()
    {
        return customer;
    }
    public void CreateTableOrder()
    {
        List<MealSO> mealSOList = OrderManager.Instance.GetMealSOList();
        order = mealSOList[UnityEngine.Random.Range(0, mealSOList.Count)];
        customer.SetCustomerOrdered();
    }
    public MealSO GetTableOrder()
    {
        return order;
    }
    public void SetTableOrderToNull(){
        order = null;
    }
    public Transform GetCustomerPosition()
    {
        return customerPosition;
    }
    public Transform GetChefPosition()
    {
        return chefPosition;
    }
    public void SetIsOccupied()
    {
        isOccupied = !isOccupied;
    }
    public bool GetIsOccupied()
    {
        return isOccupied;
    }
    public bool GetIsServingExist(){
        return isServingExist;
    }
    public void SetIsServingExist(){
        isServingExist = true;
    }
}
