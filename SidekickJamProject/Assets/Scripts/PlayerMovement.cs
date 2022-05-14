using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 0.1f;

    private bool facesRight;
    
    void Update()
    {
        float velocity = Input.GetAxis("Horizontal");
        transform.Translate(speed * velocity * 0.2f, 0f, 0f);
    }
}
