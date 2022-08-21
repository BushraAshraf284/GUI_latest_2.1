using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
using System.Text;

public class OpenGame : MonoBehaviour
{
    /* public int range;
     public int[] MyNum;
     public int[] KnownNumbers;
     public int UniqueNumbers;*/
    List<int> listNumbers = new List<int>();
    int number;
    public string[] GamesName;
    public static int count;
    public System.Random rnd;
    int i;
    // Start is called before the first frame update
    void Start()
    {
        rnd = new System.Random();
        //range = GamesName.Length;
        //UniqueNumbers = 8;
        count = 0;
        //MyNumbers();
        RandomDiffNumber();
        Debug.Log(listNumbers[count]);
        i = listNumbers[count];
        Debug.Log(GamesName[i]);
       
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void openGame()
    {
        
       
        SceneManager.LoadScene(GamesName[listNumbers[count]]);
        count++;



    }

   /* private void MyNumbers()
    {
        MyNum = new int[range];
        for (int i = 0; i < range; i++)
        {
            MyNum[i] = i;
        }
    }*/

    private void RandomDiffNumber()
    {
        /*KnownNumbers = new int[UniqueNumbers];
        int Cmax = MyNum.Length;
        for (int i = 0; i < UniqueNumbers; i++)
        {
            Cmax = MyNum.Length;
            int rand = Random.Range(0, Cmax);
            KnownNumbers[i] = MyNum[rand];
            MyNum = MyNum.Where((source, index) => index != rand).ToArray();
        }*/
        // Now KnownNumbers contain unique Random Numbers

        
        for (int i = 0; i < 8; i++)
        {
             number = rnd.Next(0, 2);
            Debug.Log(number);
            listNumbers.Add(number);

        }
    }
}



