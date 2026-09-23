using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float velocidade = 8f;
    public float tempoDeVida = 3f;

    void Start()
    {
        Destroy(gameObject, tempoDeVida);
    }

    void Update()
    {
        transform.Translate(Vector2.right * velocidade * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.CompareTag("Enemy"))
        {
            Destroy(outro.gameObject);
            Destroy(gameObject);
        }
    }
}