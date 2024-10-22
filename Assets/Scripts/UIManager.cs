using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject view;
    [SerializeField] private GameObject upgradesMenu;
    [SerializeField] private TextMeshProUGUI cashText;

    
    public void Show(GameObject gameObject){
        gameObject.SetActive(true);
    }
    public void Hide(GameObject gameObject){
        gameObject.SetActive(false);
    }
    public void ChangeShowHide(GameObject gameObject){
        gameObject.SetActive(!gameObject.activeSelf);
    }
    public void UpdateCashText(int amount){
        cashText.text = amount.ToString();
    }
}
