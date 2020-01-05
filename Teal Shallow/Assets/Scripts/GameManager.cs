using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public  class GameManager : MonoBehaviour

    {
    public Texture2D cursor;
    public PlayerController player;


    private void SetCursor()
    {
        Vector2 hotspot = new Vector2(cursor.width * 0.5f, cursor.height * 0.5f);
        Cursor.SetCursor(cursor, hotspot, CursorMode.Auto);
    }

    private void Start()
    {
        SetCursor();
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "Level_02")
        {
            player.inSafeZone = false;
        }
    }

    }
}
