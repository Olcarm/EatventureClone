using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour
{
    [SerializeField] private int upgradeCost;
    [SerializeField] private Button upgradeButton;
    [SerializeField] private TextMeshProUGUI upgradeCostText;
    [SerializeField] private MealSO mealSO;

    [Header("Upgrade Type")]
    [SerializeField] private bool isChefUpgrade;
    [SerializeField] private bool isMealUpgrade;
    [SerializeField] private bool isCounterUpgrade;
    [SerializeField] private bool isTableUpgrade;
    [SerializeField] private bool isMealSpeedUpgrade;
    [SerializeField] private bool isCustomerUpgrade;

    void Start()
    {
        Setup();
    }
    private void Setup()
    {
        
        upgradeCostText.text = upgradeCost.ToString();
    }

    public bool UpgradeIsBuyable()
    {
        if (UpgradeManager.Instance.GetCash() >= upgradeCost)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void BuyUpgrade()
    {
        if (UpgradeIsBuyable())
        {
            UpgradeManager.Instance.SpendCash(upgradeCost);
            if (isChefUpgrade)
            {
                UpgradeManager.Instance.AddChef();

            }
            if (isMealUpgrade)
            {
                UpgradeManager.Instance.IncreasePrice(mealSO);

            }
            if (isCounterUpgrade)
            {
                UpgradeManager.Instance.AddCounterOfType(mealSO);

            }
            if (isTableUpgrade)
            {
                UpgradeManager.Instance.AddTable();

            }
            if (isMealSpeedUpgrade)
            {
                UpgradeManager.Instance.ReducePreparationSpeed(mealSO);

            }
            if (isCustomerUpgrade)
            {
                UpgradeManager.Instance.AddCustomer(1);

            }
            Destroy(gameObject);
        }
    }
}
