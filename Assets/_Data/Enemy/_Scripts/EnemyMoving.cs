using System;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoving : LocMonoBehaviour
{
   public GameObject target;
   [SerializeField] protected EnemyController enemyController;
   

   void FixedUpdate()
   {
      this.Moving();
   }
   
   protected override void LoadComponents()
   {
      base.LoadComponents();
      this.LoadEnemyController();
      this.LoadTargetMoving();
   }
   
   protected virtual void LoadEnemyController()
   {
      if (this.enemyController != null) return;
      this.enemyController = transform.parent.GetComponent<EnemyController>();
      Debug.Log(transform.name + " is loading EnemyController",gameObject);
   }
   
   protected virtual void LoadTargetMoving()
   {
      if (this.target != null) return;
      this.target = GameObject.Find("TargetMoving");
      Debug.Log(transform.name + " is loading Target",gameObject);
   }
   
   protected virtual void Moving()
   {
      this.enemyController.Agent.SetDestination(target.transform.position);
   }
}
