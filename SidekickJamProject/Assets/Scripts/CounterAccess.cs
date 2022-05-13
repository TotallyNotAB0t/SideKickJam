using UnityEngine;

public class CounterAccess : MonoBehaviour
{
    [SerializeField] private Camera mainCam;
    [SerializeField] private GameObject counterCamera;
    private bool onCounter;

    private void OnTriggerExit2D(Collider2D other)
    {
        onCounter = false;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        onCounter = true;
    }

    private void Update()
    {
        if (!onCounter) return;
        if (Input.GetKeyDown(KeyCode.E))
        {
            mainCam.gameObject.SetActive(false);
            counterCamera.SetActive(true);
        }
    }
}
