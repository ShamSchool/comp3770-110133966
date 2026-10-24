using UnityEngine;

public class Lab04ChallengeController : MonoBehaviour
{
    public Lab04DataManager dataManager;
    public Lab04EntityManager entityManager;

    string firstFile = "Lab04/Lab04_Entities.json";
    string secondFile = "Lab04/Lab04_Entities2.json";

    string currentFile;
    float switchTime;

    void Start()
    {
        currentFile = firstFile;

        if (dataManager.Load(currentFile))
        {
            entityManager.Clear();
            entityManager.SpawnAll();
        }

        switchTime = Time.time + 5f;
    }

    void Update()
    {
        if (Time.time >= switchTime)
        {
            SwitchEntities();
            switchTime = Time.time + 5f;
        }
    }

    void SwitchEntities()
    {
        string nextFile;

        if (currentFile == firstFile)
        {
            nextFile = secondFile;
        }
        else
        {
            nextFile = firstFile;
        }

        if (dataManager.Load(nextFile))
        {
            entityManager.Clear();
            entityManager.SpawnAll();

            currentFile = nextFile;

            Debug.Log("[Lab04Challenge] Switched to " + currentFile);
        }
    }
}