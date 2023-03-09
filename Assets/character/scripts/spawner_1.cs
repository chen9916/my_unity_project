using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner_1 : MonoBehaviour
{

    //public GameObject player
    public GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        //spawn player at the spawner
        Instantiate(player, transform.position, transform.rotation);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
