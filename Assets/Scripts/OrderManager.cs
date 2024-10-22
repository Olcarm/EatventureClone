using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    public static OrderManager Instance { get; private set; }
    [SerializeField] private List<MealSO> mealsList;
    [SerializeField] private List<Counter> countersList;
    [SerializeField] private List<Table> tableList;
    private void Awake()
    {
        Instance = this;

    }
    public Counter GetCounterPosition(MealSO mealSO)
    {
        foreach (Counter counter in countersList)
        {
            if (counter.GetCounterMeal() == mealSO)
            {
                if (!counter.GetCounterIsOccupied())
                {
                    counter.SetCounterOccupied();
                    return counter;
                }
            }
        }
        return null;
    }
    public List<Counter> GetCounterList(){
        return countersList;
    }
    public List<Table> GetTableList(){
        return tableList;
    }
    public List<MealSO> GetMealSOList()
    {
        return mealsList;
    }
    public int GetTableCount()
    {
        return tableList.Count;
    }
}
