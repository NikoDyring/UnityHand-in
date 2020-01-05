using UnityEngine;

namespace Assets.Scripts
{
    public class GameManager : MonoBehaviour
    {
        public Texture2D cursor;

        public PlayerController player;

        public GameObject tutorialText;
        // Start is called before the first frame update
        void Start()
        {
            Vector2 hotspot = new Vector2(cursor.width / 2, cursor.height / 2);
            Cursor.SetCursor(cursor, hotspot, CursorMode.Auto);
        }

    }
}
