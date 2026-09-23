using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform jogador;

    void LateUpdate()
    {
        if (jogador != null)
        {
            transform.position = new Vector3(
                jogador.position.x,
                jogador.position.y,
                transform.position.z
            );
        }
    }
}