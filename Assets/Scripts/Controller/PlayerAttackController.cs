using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
    public float Damage = 2;
    public float AtackSpeed = 1;
    public float SupperAttackSpeed = 2;
    public float AttackRange = 2;

    private float lastAttackTime = 0;
    private float lastSupperAttackTime = 0;
    private bool isDead = false;
    public Animator AnimatorController;
    public Animator SupperAnimatorController;


    public void PlayerAttack()
    {
        Enemie closestEnemie = FindClosestEnemy();

        if (closestEnemie != null)
        {
            var distance = Vector3.Distance(transform.position, closestEnemie.transform.position);
            if (distance <= AttackRange)
            {
                if (Time.time - lastAttackTime > AtackSpeed)
                {
                    //transform.LookAt(closestEnemie.transform);
                    transform.transform.rotation = Quaternion.LookRotation(closestEnemie.transform.position - transform.position);

                    lastAttackTime = Time.time;
                    closestEnemie.Hp -= Damage;
                    AnimatorController.SetTrigger("Attack");

                }
            }
            else
            {
                if (Time.time - lastAttackTime > AtackSpeed)
                {
                    AnimatorController.SetTrigger("Attack");
                }
            }
        }
        
    }
    public void PlayerSupperAttack()
    {
        Enemie closestEnemie = FindClosestEnemy();

        if (closestEnemie != null)
        {
            var distance = Vector3.Distance(transform.position, closestEnemie.transform.position);
            if (distance <= AttackRange)
            {
                if (Time.time - lastSupperAttackTime > SupperAttackSpeed)
                {
                    //transform.LookAt(closestEnemie.transform);
                    transform.transform.rotation = Quaternion.LookRotation(closestEnemie.transform.position - transform.position);

                    lastSupperAttackTime = Time.time;
                    closestEnemie.Hp -= Damage * 2;
                    AnimatorController.SetTrigger("DoubleAttack");

                }
            }
            else
            {
                if (Time.time - lastSupperAttackTime > SupperAttackSpeed)
                {
                    AnimatorController.SetTrigger("DoubleAttack");
                }
            }
        }
    }
    private Enemie FindClosestEnemy()
    {
        var enemies = SceneManager.Instance.Enemies;
        Enemie closestEnemie = null;

        for (int i = 0; i < enemies.Count; i++)
        {
            var enemie = enemies[i];
            if (enemie == null)
            {
                continue;
            }

            if (closestEnemie == null)
            {
                closestEnemie = enemie;
                continue;
            }

            var distance = Vector3.Distance(transform.position, enemie.transform.position);
            var closestDistance = Vector3.Distance(transform.position, closestEnemie.transform.position);

            if (distance < closestDistance)
            {
                closestEnemie = enemie;
            }

        }
        return closestEnemie;
    }

}
