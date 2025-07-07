using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int favor = 0;
    public int gold = 0;
    public int people = 1;


    public TMP_Text favorText;
    public TMP_Text goldText;
    public TMP_Text peopleText;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    void Start()
    {
        RefreshUI(); 
    }
    void RefreshUI()
        {
            RefreshFavor();
            RefreshGold();
            RefreshPeople();
        }

        void RefreshFavor()  { if (favorText  != null) favorText.text  = favor .ToString("N0"); }
        void RefreshGold()   { if (goldText   != null) goldText .text  = gold  .ToString("N0"); }
        void RefreshPeople() { if (peopleText != null) peopleText.text = people.ToString("N0"); }

    void Update()
    {
        
    }
}
