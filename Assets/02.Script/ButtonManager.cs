using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] GameObject customerBG;
    [SerializeField] GameObject shopBG;
    [SerializeField] GameObject cocktailBG;


    void Awake() => HideAll();

    public void ShowCustomer() { SwitchTo(customerBG); }
    public void ShowShop() { SwitchTo(shopBG); }
    public void ShowCocktailSelect() { SwitchTo(cocktailBG); }

    public void SwitchTo(GameObject target)
    {
        HideAll();
        target.SetActive(true);
    }
    public void HideAll()
    {
        customerBG.SetActive(false);
        shopBG.SetActive(false);
        cocktailBG.SetActive(false);
    }

    public void SelectCocktail()
    {
        HideAll();

        GameManager.Instance.CompleteCustomer();
    }

    public void TestMessage()
    {
        Debug.Log("ㅎㅇ");
    }

}
