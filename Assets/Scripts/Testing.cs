using UnityEngine;

public class Testing : MonoBehaviour
{
    [SerializeField] private MealSO mealSO;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T)){
            UpgradeManager.Instance.AddTable();
        }
        if(Input.GetKeyDown(KeyCode.C)){
            UpgradeManager.Instance.AddCustomer(2);
        }
    }
}
