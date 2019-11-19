/*using AppodealAds.Unity.Api;
using AppodealAds.Unity.Common;*/
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{

    public static bool hit;
    public GameObject[] forms; // Массив фигур
                               //public Color[] color; // Массив цветов

    //public static bool GameIsPaused = false;



    // Лимит по осям Х и Y позиции для фигуры
    public float limitX = 7f;
    public float limitY = 3f;

    // Текстовые элементы UI
    public Text _infoTextStart;
    public Text _infoTextScore;
    public Text _infoTextTime;


    public float timeOut = 2.5f; // Лимит времени на клик
    public float limit; //Лимит очков для следующего уровня


    //public GameObject pauseMenuUI;

    private float curTimeOut;
    private int gameStart;
    private bool isStart;
    private int score;
    private AudioSource sound;
    private int settingsPopup;
    private object ScoreStart;
    private int Achiv;

   // public int Achiv { get => achiv; set => achiv = value; }
   

    void Start()
    {
       /* string appKey = " ";
        Appodeal.initialize(appKey, Appodeal.INTERSTITIAL);
        Appodeal.show(Appodeal.INTERSTITIAL);*/
        sound = GetComponent<AudioSource>();
        curTimeOut = timeOut;
        limitX = Mathf.Abs(limitX);
        limitY = Mathf.Abs(limitY);
        isStart = false;
        gameStart = 3;
        hit = false;
        _infoTextTime.text = "";
        _infoTextStart.text = "";
        _infoTextScore.text = "";
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
        gameStart--;
        if (gameStart < 0)
        {
            AddForm();
            //	gameStart = 0;
            isStart = true;
            _infoTextStart.text = "";
        }
        else
        {
            StartCoroutine(Wait());
        }
    }

    void OnGUI()
    {
        if (isStart)
        {
            _infoTextScore.text = "Score: " + score.ToString();

            if (((int)(curTimeOut * 10f)) / 10f == (int)curTimeOut)
            {
                _infoTextTime.text = (((int)(curTimeOut * 10f)) / 10f).ToString() + ".0";
            }
            else
            {
                _infoTextTime.text = (((int)(curTimeOut * 10f)) / 10f).ToString();
            }
        }
        /*else
		{
			_infoTextStart.text = gameStart.ToString();
		}*/
        else
        {
            if (gameStart > 0)
            {
                _infoTextStart.text = gameStart.ToString();
            }
        }

    }

    void AddForm()
    {
        if (transform.childCount == 0)
        {
            int randomForm = Random.Range(0, forms.Length);
            //int randomColor = Random.Range(0, color.Length);
            Vector3 randomPos = new Vector3(Random.Range(-limitX, limitX), Random.Range(-limitY, limitY), 0);
            Vector3 randomRotZ = new Vector3(0, 0, Random.Range(0, 20f));
            GameObject clone = Instantiate(forms[randomForm], randomPos, Quaternion.Euler(randomRotZ)) as GameObject;
            //	clone.GetComponent<SpriteRenderer>().color = color[randomColor];
            clone.transform.parent = transform;
        }
    }

 /* public  void FunkAchiv()
    {
        
    }*/


    void Update()
    {
        if (isStart)
        {
            //функция вызова ачивок 

            if (score > 4){
                switch (score)
                {
                    case 15:
                        gameObject.GetComponent<UIController>().OnOpenBrave();
                        Debug.Log("open 1");
                        break;
                    case 35:
                        Debug.Log("open 20");
                        gameObject.GetComponent<UIController>().OnOpenNi();
                        break;
                    case 65:
                        Debug.Log("open 30");
                        gameObject.GetComponent<UIController>().OnOpenExcel();
                        break;
                    case 85:
                        Debug.Log("open 50");
                        gameObject.GetComponent<UIController>().OnOpenKing();
                        break;
                    case 90:
                        Debug.Log("open 90");
                        gameObject.GetComponent<UIController>().OnOpenBrave();
                        break;
                    case 100:
                        gameObject.GetComponent<UIController>().OnOpenNi();
                        Debug.Log("open 120");
                        break;
                    default:
                        Debug.Log("пропуск ");
                        break;
                }
            }
                
                    if (score == limit) //значения изменение кнопки следующий уровень
                            {
                                gameObject.GetComponent<UIController>().OnOpenSettings();
                
                            }
        }
                      
               
                //функции вызова ачивок
           

        curTimeOut -= Time.deltaTime;
        if (curTimeOut <= 0)
        {
         //   sound.Play();
            curTimeOut = timeOut;
            //score--;

            for (int i = 0; i < transform.childCount; i++)
            {
                GameObject obj = transform.GetChild(i).gameObject;
                obj.transform.parent = null;
                Destroy(obj);

            }

            //AddForm();
            _infoTextStart.text = score.ToString();
            //gameObject.GetComponent<UIController>().OnOpenSettings();
            isStart = false;

        }
        else if (hit)
        {
            hit = false;
            curTimeOut = timeOut;
            score++;
            if (timeOut > 1) timeOut -= 0.005f;
            AddForm();

        }
    

        if (score >= 9999 )score = 0; //limit
        //{ gameObject.GetComponent<PauseMenu>().Pause(); }
       
    }
   
}
