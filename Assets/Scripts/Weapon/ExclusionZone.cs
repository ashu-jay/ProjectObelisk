using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExclusionZone : MonoBehaviour
{
    public Weapon ExclusionWeapon;
    public float Radius;

    [SerializeField] private SphereCollider exclusionCollider;
    
    private void OnEnable() {
        // Sets the world scale of the exclusion zone
        var parent = transform.parent;
        transform.parent = null;
        transform.localScale = new Vector3(Radius, Radius, Radius);
        transform.parent = parent;
        // exclusionCollider.radius = Radius;
        
        // Ensures that this is on the correct layer
        gameObject.layer = LayerMask.NameToLayer("Default");
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.layer != LayerMask.NameToLayer("Weapon")) return;
        Weapon weapon = other.transform.root.GetComponent<Weapon>();
        if (weapon == ExclusionWeapon) return;
        weapon.CanPlace = false;
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.layer != LayerMask.NameToLayer("Weapon")) return;
        Weapon weapon = other.transform.root.GetComponent<Weapon>();
        weapon.CanPlace = true;
    }
}
