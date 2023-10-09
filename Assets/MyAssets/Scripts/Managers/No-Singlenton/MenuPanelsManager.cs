using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPanelsManager : MonoBehaviour
{
    // Start is called before the first frame update
  public void LoadScene(int n)
    {
        SceneManager.LoadScene(n);

    }
    public void ExitButton()
    {

        Application.Quit();
    }
}
