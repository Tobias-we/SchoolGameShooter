using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Fire : MonoBehaviour
{
    [SerializeField] Transform firePos;
    [SerializeField] GameObject bulletPre;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateShoot(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        Instantiate(bulletPre, firePos.position, transform.rotation);
    }
}
