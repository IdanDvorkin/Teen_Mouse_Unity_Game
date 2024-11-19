using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HallwayButtonBehaviour : MonoBehaviour
{
    public void LoadHallway()
    {
        SceneManager.LoadScene(2);
    }
}
