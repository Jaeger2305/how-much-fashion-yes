using UnityEngine;

public class GameEnd : MonoBehaviour
{
    private GameObject gfx;
    void Start()
    {
        gfx = transform.Find("GFX").gameObject;
    }

    public void gameOver()
    {
        gfx.SetActive(true);
        // go back to main scene
    }
}
