using UnityEngine;

public class CounterAccess : MonoBehaviour
{
    [SerializeField] private Camera mainCam;
    [SerializeField] private GameObject counterCamera;
    private bool onCounter;

    private void OnTriggerExit2D(Collider2D other)
    {
        onCounter = false;
        TriggerInteractions.RemoveBubble();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        onCounter = true;
        TriggerInteractions.bubbleParent.transform.localPosition = new Vector3(1.70f, -1.22f, 0f);
        TriggerInteractions.ShowBubble("Open Shop");
    }

    private void Update()
    {
        if (GeneratorHero.IsDayOver()) return;
        if (!onCounter) return;
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!GeneratorHero.isCounterOpen)
            {
                GeneratorHero.isCounterOpen = true;
            }
            else if(!QuestHover.questSent)
            {
                mainCam.gameObject.SetActive(false);
                counterCamera.SetActive(true);
            }
        }
    }
}
