using UnityEngine;

public class Player : MonoBehaviour
{
    public Sprite playerUp, playerDown, playerRight, playerLeft;

    public int health = 3;

    private Vector2 originalPosition;

    private HUD hud;
    public CollidableObject collidableobject;

    public float gameTime = 30;

    public float gameTimeWarning = 5;

    public float gameTimer;

    private Vector3 startingTimeBandScale;
    private readonly object collidableObject;

    void Start()
    {
        originalPosition = transform.localPosition;

        hud = GameObject.Find("CanvasHUD").GetComponent<HUD>();
        startingTimeBandScale = hud.timeband.GetComponent<RectTransform>().localScale;
    }

    void Update()
    {
        UpdatePosition();
        Checkcollisions();
        CheckGameTimer();

    }

    private void CheckGameTimer()
    {
        gameTimer += Time.deltaTime;

        Vector3 scale = new Vector3(startingTimeBandScale.x - gameTimer, startingTimeBandScale.y, startingTimeBandScale.z);

        scale.x -= gameTimer;

        hud.timeband.GetComponent<RectTransform>().localScale = scale;

        if (gameTimer >= gameTime)
        {
            PlayerDied();
        }

    }

    private void UpdatePosition()
    {
        Vector2 pos = transform.localPosition;

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            GetComponent<SpriteRenderer>().sprite = playerUp;
            pos += Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            GetComponent<SpriteRenderer>().sprite = playerDown;
            if (pos.y > -6.5)
            {
                pos += Vector2.down;
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            GetComponent<SpriteRenderer>().sprite = playerRight;
            if (pos.x < 7)
            {
                pos += Vector2.right;
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            GetComponent<SpriteRenderer>().sprite = playerLeft;
            if (pos.x > -7)
            {
                pos += Vector2.left;
            }
        }
        transform.localPosition = pos;
    }

    private void Checkcollisions()
    {
        bool isSafe = true;

        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("CollidableObject");
        foreach (GameObject go in gameObjects)
        {
            CollidableObject collidableObject = go.GetComponent<CollidableObject>();
            if (collidableObject.IsColliding(this.gameObject))
            {
                if (collidableObject.isSafe)
                {
                    isSafe = true;
                    if (collidableObject.isLog)
                    {
                        Vector2 pos = transform.localPosition;
                        if (collidableObject.GetComponent<Log>().moveRight)
                        {
                            pos.x += collidableObject.GetComponent<Log>().moveSpeed * Time.deltaTime;

                            if (transform.localPosition.x >= 10f)
                            {
                                pos.x = transform.localPosition.x - 12f;
                            }
                        }
                        else
                        {
                            pos.x -= collidableObject.GetComponent<Log>().moveSpeed * Time.deltaTime;
                            if (transform.position.x <= -10f)
                            {
                                pos.x = transform.localPosition.x + 12f;
                            }
                        }
                        transform.localPosition = pos;
                    }
                    if (collidableObject.isTurtle)
                    {
                        Vector2 pos = transform.localPosition;
                        if (collidableObject.GetComponent<Turtle>().moveRight)
                        {
                            pos.x += collidableObject.GetComponent<Turtle>().moveSpeed * Time.deltaTime;

                            if (transform.localPosition.x > 10f)
                            {
                                pos.x = transform.localPosition.x - 12f;
                            }
                        }
                        else
                        {
                            pos.x -= collidableObject.GetComponent<Turtle>().moveSpeed * Time.deltaTime;
                            if (transform.localPosition.x <= -10f)
                            {
                                pos.x = transform.localPosition.x + 12f;
                            }
                        }
                        transform.localPosition = pos;
                    }

                    if (collidableObject.isHomeBay)
                    {
                        if (!collidableObject.isOccupied)
                        {

                            GameObject trophy = (GameObject)Instantiate(Resources.Load("Prefabs/trophy", typeof(GameObject)), collidableObject.transform.localPosition, Quaternion.identity);
                            collidableObject.isOccupied = true;

                            ResetTimer();

                            hud.AddPionts();
                        }
                        ResetPosition();
                    }
                    if (isSafe)
                    {
                        if (collidableObject.isSafeSpot)
                        {
                            hud.AddPionts();
                            collidableObject.isSafeSpot = false;
                        }
                    } 
                    break;
                }
                else
                {
                    isSafe = false;
                }
            }
        }
        if (!isSafe)
        {

            if (health == 0)
            {
                GameOver();
            }
            else
            {
                PlayerDied();
                
            }
        }
    }
    void DecreaseHealth()
    {
        health -= 1;
    }

     void ResetTimer()
    {
        gameTimer = 0;

    }
    void ResetPosition()
    {
        hud.UpdatePlayerLivesHUD(health);
        transform.localPosition = originalPosition;
        transform.GetComponent<SpriteRenderer>().sprite = playerUp;
    }
    void PlayerDied()
    {
        ResetTimer();
        DecreaseHealth();
        ResetPosition();
        
    }
    void GameOver()
    {
        hud.ResetPoints();
    }
}
