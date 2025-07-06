using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LobbyManager : MonoBehaviour
{
    public NPC_Base targetNpc;
    public CanvasGroup uiGroup;
    public float fadeDuration = 2.0f;

    bool hasShownUI = false;
    void Start()
    {
        uiGroup.gameObject.SetActive(false);
        uiGroup.alpha = 0f;
    }

    void Update()
    {
        if (!hasShownUI && targetNpc.state == NPC_Base.NPCState.Order)
        {
            hasShownUI = true;
            uiGroup.gameObject.SetActive(true);
            StartCoroutine(FadeInUI());
        }
    }
    IEnumerator FadeInUI()
    {
        float elapsed = 0f;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            uiGroup.alpha = Mathf.Clamp01(elapsed / fadeDuration);
            yield return null;
        }
        uiGroup.alpha = 1f;
    }
    public void SceneChange()
    {
        SceneManager.LoadScene("MainScene");
    }
}
