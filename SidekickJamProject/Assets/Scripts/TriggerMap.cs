using UnityEngine;

public class TriggerMap : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    
    void OnTriggerEnter2D(Collider2D col)
    {
        canvas.gameObject.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        canvas.gameObject.SetActive(false);
    }
}
