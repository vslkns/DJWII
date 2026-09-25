using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float attackInterval = 1f;
    public float projectileSpeed = 8f;

    private float attackTimer;

    void Update()
    {
        attackTimer += Time.deltaTime;

        if (attackTimer >= attackInterval)
        {
            Atacar();
            attackTimer = 0f;
        }
    }

    void Atacar()
    {
        GameObject inimigoMaisProximo = EncontrarInimigoMaisProximo();

        if (inimigoMaisProximo == null)
            return;

        GameObject tiro = Instantiate(
            projectilePrefab,
            transform.position,
            Quaternion.identity
        );

        Projectile projectile = tiro.GetComponent<Projectile>();

        Vector2 direcao = (
            inimigoMaisProximo.transform.position - transform.position
        ).normalized;

        projectile.SetDirection(direcao);
        projectile.speed = projectileSpeed;
    }

    GameObject EncontrarInimigoMaisProximo()
    {
        GameObject[] inimigos = GameObject.FindGameObjectsWithTag("Enemy");

        GameObject maisProximo = null;
        float menorDistancia = Mathf.Infinity;

        foreach (GameObject inimigo in inimigos)
        {
            float distancia = Vector2.Distance(
                transform.position,
                inimigo.transform.position
            );

            if (distancia < menorDistancia)
            {
                menorDistancia = distancia;
                maisProximo = inimigo;
            }
        }

        return maisProximo;
    }
}