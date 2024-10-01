using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnBtn : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnReturnButton()
    {
        SceneManager.LoadScene(0);
    }
}
