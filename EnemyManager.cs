using Invector.vCharacterController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour 
{
    #region Variables       
    [Header("- Enemy Status")]
    public int Hp;

    [Header("- Item")]
    public GameObject[] items;
    #endregion
    
    void Update()
    {
        if (Hp == 0)
        {
            GetComponent<Animator>().SetTrigger("IsDied"); 
            Invoke("SpawnItem", 5f);   
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "WeaponAxe" )
        {
            if (vThirdPersonController.instance.isAttack == true)
            {
                GetComponent<Animator>().SetTrigger("IsTakedamage");
                Hp -= 1;
            }
                
        }
    }
    void SpawnItem()
    {
        foreach (var item in items)
        {
            item.SetActive(true);
        }
        transform.Find("body").GetComponent<SkinnedMeshRenderer>().enabled = false;
        Destroy(gameObject);
    }
}
