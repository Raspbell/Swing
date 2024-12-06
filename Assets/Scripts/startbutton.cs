using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startbutton : MonoBehaviour
{

    public void startGame()
    {
        StartCoroutine("LoadGameScene");
    }

    public void quitGame()
    {
        StartCoroutine("QuitGameScene");
    }

    public void showRanking()
    {
        StartCoroutine("Ranking");
    }

    public void showRanking_start()
    {
        StartCoroutine("Ranking_start");
    }

    IEnumerator LoadGameScene()
    {
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene("Main");
    }

    IEnumerator QuitGameScene()
    {
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene("Title");
    }

    IEnumerator Ranking()
    {
        yield return new WaitForSeconds(0.2f);
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking((int)Display.dist);
    }

    IEnumerator Ranking_start()
    {
        yield return new WaitForSeconds(0.2f);
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking(0);
    }
}
