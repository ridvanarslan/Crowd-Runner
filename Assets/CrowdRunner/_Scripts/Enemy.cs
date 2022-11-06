using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UI;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header(" SETTINGS ")] 
    [SerializeField] [Range(0, 5f)] private float searchRadius;
    [SerializeField] [Range(0, 20f)] private float moveSpeed;

    [Header(" EVENTS")] public static Action onRunnerDie;
    
    private EnemyState _state;
    private Transform target;
    private Animator _animator;

    private void Awake() => _animator = this.GetComponent<Animator>();

    private void Update() => ManageState();

    private void ManageState()
    {
        switch (_state)
        {
            case EnemyState.Idle:
                print("enemy idle");
                SearchForTarget();
                break;
            case EnemyState.Running:
                print("enemy run");
                RunTowardsTarget();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void SearchForTarget()
    {
        Collider[] detectedColliders = Physics.OverlapSphere(transform.position, searchRadius);

        for (int i = 0; i < detectedColliders.Length; i++)
        {
            if (detectedColliders[i].TryGetComponent(out Runner runner))
            {
                print("target");
                if (runner.IsTargeted)
                    continue;
                runner.IsTargeted = true;
                target = runner.transform;
                StartRunnigTowardTarget();
            }
        }
    }

    private void StartRunnigTowardTarget()
    {
        _state = EnemyState.Running;
        _animator.Play("Run");
    }

    private void RunTowardsTarget()
    {
        if (target == null)
        {
            return;
        }

        transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * moveSpeed);
        if (Vector3.Distance(transform.position, target.position) < .2f)
        {
            onRunnerDie?.Invoke();
            Destroy(target.gameObject); 
            Destroy(this.gameObject);
        }
    }

    private void OnDrawGizmos() => Gizmos.DrawSphere(transform.position, searchRadius);
}

public enum EnemyState
{
    Idle,
    Running
}