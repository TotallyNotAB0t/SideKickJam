using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 0.1f;
    [SerializeField] private GameObject infoBubble;

    private bool facesRight;
    
    void Update()
    {
        float velocity = Input.GetAxis("Horizontal");
        if (velocity > 0 && !facesRight)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            infoBubble.transform.localScale = new Vector3(-2f, 2f, 2f);
            facesRight = !facesRight;
        }
        else if (velocity < 0 && facesRight)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            infoBubble.transform.localScale = new Vector3(2f, 2f, 2f);
            facesRight = !facesRight;
        }
        transform.Translate(speed * velocity * 0.2f, 0f, 0f);
    }
}
