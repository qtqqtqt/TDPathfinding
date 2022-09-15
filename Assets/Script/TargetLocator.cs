using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] ParticleSystem projectileParticles;
    [SerializeField] float towerRange = 15f;
    Transform target;

    private void Update()
    {
        FindClosestTarget();
        AimWeapon();
    }

    private void FindClosestTarget()
    {
        Enemy[] enemies = GameObject.FindObjectsOfType<Enemy>();
        Transform closestTarget = null;
        float maxDistance = Mathf.Infinity;

        foreach (Enemy enemy in enemies)
        {
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);

            if (targetDistance < maxDistance)
            {
                closestTarget = enemy.transform;
                maxDistance = targetDistance;
            }
        }

        target = closestTarget;
    }

    private void AimWeapon()
    {
        if (target != null)
        {
            float targetDistance = Vector3.Distance(transform.position, target.position);
            weapon.LookAt(target);

            if (targetDistance < towerRange)
            {
                Attack(true);
            }
            else
            {
                Attack(false);
            }
        }
        
    }

    private void Attack(bool isActive)
    {
        var emissionModule = projectileParticles.emission;

        emissionModule.enabled = isActive;
    }
}
