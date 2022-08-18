using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    public  bool sol, sað, Isgame;
    public float hýz;
    public float Increase;
    public Rigidbody rb;
    public GameObject collectobject, oyunsonupanel;
    public  Animator anim;
    public int sahnelevel;
    public  Text levelcontext;
    public  GameObject nextbutton, prbutton;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

        
        
        Isgame =true;
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        
    }
    public void Movement()
    {
        if (Isgame)
        {
            transform.Translate(0, 0, hýz * Time.deltaTime);
            Vector3 sagit = new Vector3(1.50f, transform.position.y, transform.position.z);
            Vector3 solgit = new Vector3(-1.50f, transform.position.y, transform.position.z);
            if (Input.touchCount > 0)
            {
                Touch parmak = Input.GetTouch(0);
                if (parmak.deltaPosition.x > 50.0f)
                {
                    sað = true;
                    sol = false;
                }
                if (parmak.deltaPosition.x < -50.0f)
                {
                    sað = false;
                    sol = true;
                }
                if (sað == true)
                {
                    transform.position = Vector3.Lerp(transform.position, sagit, 5 * Time.deltaTime);
                }
                if (sol == true)
                {
                    transform.position = Vector3.Lerp(transform.position, solgit, 5 * Time.deltaTime);
                }
            }
        
        }
        else
        {

        }
    }
   
    private void OnTriggerEnter(Collider other)
    {
       
         if (other.gameObject.tag=="Collect")
        {
            other.gameObject.transform.position = transform.position + Vector3.forward;
            transform.localScale += new Vector3(0, Increase, 0);
            Destroy(gameObject.GetComponent<CollectManager>());
            other.gameObject.AddComponent<CollectManager>();
            other.gameObject.GetComponent<BoxCollider>().isTrigger = false;
            other.gameObject.AddComponent<MilkMovement>();
            other.gameObject.GetComponent<MilkMovement>().connectModle = transform;
            
            other.gameObject.tag = "Collected";
        }
        else if (other.gameObject.tag=="Harm")
        {
            collectobject.SetActive(false);
            anim.SetBool("Poison", true);
            levelcontext.text = "FAÝL";
            prbutton.SetActive(true);
            Isgame = false;
            oyunsonupanel.SetActive(true); 
        }
        else if (other.gameObject.tag=="RedLane")
        {

            
                collectobject.SetActive(false);
                Isgame = false;
                oyunsonupanel.SetActive(true);
                levelcontext.text = "LEVEL COMPLETED!";

            nextbutton.SetActive(true);
                anim.SetTrigger("Victory");
            


        }
        
    }
   
}
