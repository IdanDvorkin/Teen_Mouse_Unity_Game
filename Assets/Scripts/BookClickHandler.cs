using UnityEngine;

public class BookClickHandler : MonoBehaviour
{
    public Books booksManager;  // Reference to the Books script

    void Start()
    {
        // Ensure booksManager is set before any operations
        if (booksManager == null)
        {
            booksManager = FindObjectOfType<Books>();
            if (booksManager == null)
            {
                Debug.LogError("BooksManager not found in the scene.");
            }
        }
    }

    // This method is called when the mouse is clicked over the GameObject's collider
    void OnMouseDown()
    {
        if (booksManager == null)
        {
            Debug.LogError("booksManager is not set for " + gameObject.name);
            return;
        }

        booksManager.BookClicked(gameObject);  // Notify the Books script that this book was clicked
    }
}
