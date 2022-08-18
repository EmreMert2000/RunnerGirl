using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectManager : MonoBehaviour
{
    public GameObject playercharacter;
    public float CollectBase;
    public Camera cm;
   
 
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collect"))
        {
            
            
            other.gameObject.transform.position = transform.position + Vector3.forward;
            playercharacter.transform.localScale += new Vector3(0, CollectBase, 0);
            cm.transform.position -= new Vector3(0, CollectBase, 0);
            Destroy(gameObject.GetComponent<CollectManager>());
            other.gameObject.AddComponent<CollectManager>();
            other.gameObject.GetComponent<BoxCollider>().isTrigger = false;
            other.gameObject.AddComponent<MilkMovement>();
            other.gameObject.GetComponent<MilkMovement>().connectModle = transform;
            other.gameObject.tag = "Collected";
            

        }
       
        
      

    }
}
