using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Books : MonoBehaviour
{
    public GameObject book1;
    public GameObject book2;
    public GameObject book3;
    public GameObject book4;
    public AudioClip clickSound;  // Sound to play when a book is clicked
    public AudioClip allBooksDestroyedSound;  // Sound to play when all books are destroyed
    private AudioSource audioSource;
    private List<GameObject> books = new List<GameObject>();

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();

        // Create and setup book objects
        CreateBook(book1, new Vector3(-9.7f, -0.7f, 10.7f), new Vector3(2, 2, 2), Quaternion.identity);
        CreateBook(book2, new Vector3(-6.468f, -0.429f, 16.981f), new Vector3(2, 2, 2), Quaternion.Euler(270, 0, 0));
        CreateBook(book3, new Vector3(8.01f, -1.39f, 20.39f), Vector3.one, Quaternion.Euler(0, 90, 0));
        CreateBook(book4, new Vector3(9.736f, -0.811f, 1.339f), new Vector3(1.5f, 1.5f, 1.5f), Quaternion.Euler(0, 180, 0));
    }

    private void CreateBook(GameObject bookPrefab, Vector3 position, Vector3 scale, Quaternion rotation)
    {
        GameObject book = Instantiate(bookPrefab, position, rotation);
        book.transform.localScale = scale;
        book.AddComponent<BoxCollider>().isTrigger = true;
        AudioSource audioSource = book.AddComponent<AudioSource>();
        audioSource.clip = clickSound;  // Add AudioSource with click sound
        audioSource.playOnAwake = false;

        // Add BookClickHandler and set its booksManager reference
        BookClickHandler clickHandler = book.AddComponent<BookClickHandler>();
        clickHandler.booksManager = this;

        books.Add(book);
    }

    public void BookClicked(GameObject book)
    {
        AudioSource bookAudioSource = book.GetComponent<AudioSource>();
        if (bookAudioSource != null)
        {
            bookAudioSource.enabled = true;  // Enable the AudioSource if it was disabled
            bookAudioSource.Play();
            StartCoroutine(PlaySoundAndDestroyBook(book, bookAudioSource.clip.length));  // Pass the clip length for delay
        }
    }

    private IEnumerator PlaySoundAndDestroyBook(GameObject book, float delay)
    {
        yield return new WaitForSeconds(delay);  // Wait for the sound to finish playing
        Destroy(book);
        books.Remove(book);  // Remove destroyed book from the list

        if (books.Count == 0)  // Check if all books are destroyed
        {
            audioSource.PlayOneShot(allBooksDestroyedSound);
        }
    }
}
