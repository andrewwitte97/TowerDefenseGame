using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	private Transform target;
	
	public float speed = 70f;
	public float explosionRadius = 0f;
	
	public GameObject impactEffect;
	
	public void Seek (Transform _target)
	{
		target = _target;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (target == null)
		{
			Destroy(gameObject);
			return;
		}
		
		Vector3 dir = target.position - transform.position;
		float distanceThisFrame = speed * Time.deltaTime;
		
		if (dir.magnitude <= distanceThisFrame)
		{
			HitTarget();
			return;
		}
		
		transform.Translate (dir.normalized * distanceThisFrame, Space.World);
		transform.LookAt(target);
	}
	
	void HitTarget()
	{
		GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
		Destroy(effectIns, 5f);
		
		if (explosionRadius > 0f)
		{
			Explode();
		}
		else
		{
			Damage(target);
		}
		
		Destroy(gameObject);
        AddMoney(100);
	}
	
	void Explode()
	{
		Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
		foreach(Collider collider in colliders)
		{
			if (collider.tag == "Enemy")
			{
				Damage(collider.transform);
			}
		}
	}

    //Adds $100 to the player's bank when they kill an enemy
    //TO-DO: Find a better home for this and make it accessible via the editor
    void AddMoney(int Money)
    {
        PlayerStats.Money = PlayerStats.Money + Money;
    }
	
	void Damage(Transform enemy)
	{
		Destroy(enemy.gameObject);
	}
	
	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, explosionRadius);
	}
}
