using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
      
       /*transform.position=TableBehaviour.instance.transform.position;
       transform.Translate(new Vector3(0,0.12f*TableBehaviour.numBooks,0)); 
       transform.Rotate(0, 0, 90);
       TableBehaviour.numBooks++;*/
       Destroy(gameObject);
    }
}
