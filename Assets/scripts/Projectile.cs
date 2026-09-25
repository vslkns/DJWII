using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 8f;
    public float lifeTime = 5f;
    private Vector2 direction;


    public void SetDirection(Vector2 newDirection)
    {
        direction = newDirection.normalized;
    }

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

private void
OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            VidaDoInimigo vidaInimigo = collision.gameObject.GetComponent<VidaDoInimigo>();

            if (vidaInimigo != null)
            {
                vidaInimigo.ReceberDano(10);
            }

            Destroy(gameObject);
        }
    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}