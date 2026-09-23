using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 8f;

    private Vector2 direction;

    public void Start() {
        this.alvo = GameObject.FindWithTags("En");
    }

    public void SetDirection(Vector2 novaDirecao)
    {
        direction = novaDirecao.normalized;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, alvo.transform.position, speed * Time.deltaTime);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}