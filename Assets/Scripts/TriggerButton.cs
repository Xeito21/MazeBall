using UnityEngine;
using DG.Tweening;
using TMPro;

public class TriggerButton : MonoBehaviour
{
    [SerializeField] GameObject wall;
    [SerializeField] int requiredKeys = 3;
    [SerializeField] TextMeshProUGUI labelWarn;

    private bool isOpened = false;
    private ItemCollector itemCollector;

    private void Start()
    {
        itemCollector = FindObjectOfType<ItemCollector>();
        labelWarn.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isOpened && itemCollector.GetKeyCount() >= requiredKeys)
        {
            FindObjectOfType<AudioManager>().PlaySound("WallSliding");
            isOpened = true;
            wall.transform.DOMoveX(wall.transform.position.x + 4.5f, 1f).SetEase(Ease.OutBounce);
        }
        else
        {
            FindObjectOfType<AudioManager>().PlaySound("BtnSound");
            StartCoroutine(ShowWarningText());
        }
    }

    private System.Collections.IEnumerator ShowWarningText()
    {
        labelWarn.gameObject.SetActive(true);
        labelWarn.canvasRenderer.SetAlpha(0f);
        labelWarn.CrossFadeAlpha(1f, 1f, false);
        yield return new WaitForSeconds(3f);
        labelWarn.CrossFadeAlpha(0f, 1f, false);
        yield return new WaitForSeconds(1f);
        labelWarn.gameObject.SetActive(false);
    }
}
