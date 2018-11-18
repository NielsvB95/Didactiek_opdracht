using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {

    Transform player; //Object om de speler te volgen
    public GameObject Player; //public field om het player object in te stoppen
    float playerHeightY;//Hoogte die de camera aanpast

    public Transform regular; //Sla de Platform Prefabs op
    public Transform jump;
    public Transform leftRight;
    public Transform UpDown;
    public Transform Question;  // Einde van opslaan

    private int platNumber;

    private float platCheck;
    private float spawnPlatformsTo;


    // Use this for initialization
    void Start()
    {
        player = Player.transform;

        PlatformSpawner(10f, false);
    }

    // Update is called once per frame
    void Update()
    {
        //volgt de huidige speler Y waarde
        playerHeightY = player.position.y;

        if (playerHeightY > platCheck)
        {
            PlatformManager();
        }
        //volgt de huidige camera y waarde
        float currentCameraHeight = transform.position.y;
        // De manier hoe de hoogte van de camera aanpast
        float newHeightOfCamera = Mathf.Lerp(currentCameraHeight, playerHeightY, Time.deltaTime * 10);
        //verandert de hoogte van de camera als de hoogte van de speler hoger is dan de camera
        if (playerHeightY > currentCameraHeight)
        {
            //de nieuwe camera positie is de huidige X, de nieuwe hoogte van de camera, de huidige Z
            transform.position = new Vector3(transform.position.x, newHeightOfCamera, transform.position.z);

        } else if (playerHeightY < currentCameraHeight - 1)
        {
            transform.position = new Vector3(transform.position.x, newHeightOfCamera, transform.position.z);
        }

        OnGui2D.score = (int)Time.timeSinceLevelLoad;

    }

    void PlatformManager()
    {
        platCheck = player.position.y + 15;

        PlatformSpawner(platCheck + 15, false);
    }

    void PlatformSpawner(float floatValue, bool question)
    {
        float y = spawnPlatformsTo;

        while (y <= floatValue)
        {
            float x = Random.Range(-3.25f, 3.25f);

            platNumber = Random.Range(1, 5);

            Vector2 posXY = new Vector2(x, y);
            if (posXY.y % 10 == 0)
            {
                platNumber = 5;
            }
            switch (platNumber)
            {
                case 1:
                    Instantiate(regular, posXY, Quaternion.identity);
                    break;
                case 2:
                    Instantiate(jump, posXY, Quaternion.identity);
                    break;
                case 3:
                    Instantiate(leftRight, posXY, Quaternion.identity);
                    break;
                case 4:
                    Instantiate(UpDown, posXY, Quaternion.identity);
                    break;
                case 5:
                    Instantiate(Question, posXY, Quaternion.identity);
                    break;
            }
            y += 2f;
        }
        spawnPlatformsTo = floatValue;
    }
}
