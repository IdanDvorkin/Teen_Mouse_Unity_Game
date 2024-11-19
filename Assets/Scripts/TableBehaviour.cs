using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableBehaviour : MonoBehaviour
{
    public static int numBooks = 0;
    public static TableBehaviour instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void addBook()
    {
        numBooks++;
    }
    public void removeBook()
    {
        numBooks--;
    }
}
