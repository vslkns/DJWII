using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float velocidade = 5f;

    void Update()
    {
        float horizontal = 0f;
        float vertical = 0f;

        if (Input.GetKey(KeyCode.D))
        {
            horizontal = 1f;
        }

        if (Input.GetKey(KeyCode.A))
        {
            horizontal = -1f;
        }

        if (Input.GetKey(KeyCode.W))
        {
            vertical = 1f;
        }

        if (Input.GetKey(KeyCode.S))
        {
            vertical = -1f;
        }

        Vector3 movimento = new Vector3(horizontal, vertical, 0f);

        transform.position += movimento * velocidade * Time.deltaTime;
    }
}