using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{

    public static UpgradeManager Instance { get; private set; }
    [SerializeField] private GameObject chefPrefab;
    private List<MealSO> mealSoList;
    private List<int> priceList = new List<int>();
    private List<Table> tableList;
    private List<Counter> counterList;
    [SerializeField] List<GameObject> unlockableCounters;
    [SerializeField] List<GameObject> unlockableTables;

    [SerializeField] private UIManager uiManager;

    private int cash;


    private void Start()
    {

        Instance = this;
        mealSoList = OrderManager.Instance.GetMealSOList();
        Debug.Log(mealSoList.Count);
        for (int i = 0; i < mealSoList.Count; i++)
        {
            priceList.Add(mealSoList[i].price);
        }
        tableList = OrderManager.Instance.GetTableList();
        counterList = OrderManager.Instance.GetCounterList();
        uiManager.UpdateCashText(cash);
    }
    public void IncreasePrice(MealSO mealSO)
    {
        for (int i = 0; i < mealSoList.Count; i++)
        {
            if (mealSO == mealSoList[i])
            {
                priceList[i] += 1;
            }
        }
    }

    public void AddChef()
    {
        Instantiate(chefPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    }

    public void AddCustomer(int amount)
    {
        CustomerSpawner.Instance.IncreaseCustomerCount(amount);
    }
    public void AddCash(int amount)
    {
        cash += amount;
        uiManager.UpdateCashText(cash);
    }
    public int GetCash()
    {
        return cash;
    }
    public void SpendCash(int amount)
    {
        cash -= amount;
        uiManager.UpdateCashText(cash);
    }
    public void AddCounterOfType(MealSO mealSO)
    {
        foreach (GameObject counter in unlockableCounters)
        {
            Counter tempCounter = counter.GetComponent<Counter>();
            if (tempCounter.GetCounterMeal() == mealSO)
            {
                counter.SetActive(true);
                unlockableCounters.Remove(counter);
                break;
            }
        }
    }
    public void AddTable()
    {
        unlockableTables[0].SetActive(true);
        unlockableTables.RemoveAt(0);
    }
    public void IncreaseMealPrice(MealSO mealSO)
    {
        foreach (Counter counter in counterList)
        {
            if (counter.GetCounterMeal() == mealSO)
            {
                counter.IncreaseMealPrice();
            }
        }
    }
    public void ReducePreparationSpeed(MealSO mealSO)
    {
        foreach (Counter counter in counterList)
        {
            if (counter.GetCounterMeal() == mealSO)
            {
                float currentTime = counter.GetPreparationTime();
                counter.SetPreparationTime(currentTime * 0.8f);
            }
        }
    }
}
