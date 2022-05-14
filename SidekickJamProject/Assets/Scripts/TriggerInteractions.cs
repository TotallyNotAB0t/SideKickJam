using TMPro;
using UnityEngine;

public class TriggerInteractions : MonoBehaviour
{
    public static GameObject bubbleParent;
    private static TextMeshPro textBubble;

    private void Awake()
    {
        bubbleParent = GameObject.FindWithTag("BubbleParent");
        textBubble = GameObject.FindWithTag("BubbleText").GetComponent<TextMeshPro>();
        RemoveBubble();
    }

    public static void ShowBubble(string text)
    {
        bubbleParent.SetActive(true);
        Setup(text);
    }

    public static void RemoveBubble()
    {
        bubbleParent.transform.localPosition = new Vector3(0f, -.85f, 0f);
        bubbleParent.SetActive(false);
    }

    private static void Setup(string text)
    {
        textBubble.SetText(text);
    }
}
