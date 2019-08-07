﻿using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public Animator animator;
    private Camera mainCamera;
    void Start()
    {
        GameObject.Find("First Canvas Group").transform.localScale = new Vector3(1, 1, 1);
        GameObject.Find("Second Canvas Group").transform.localScale = new Vector3(0, 0, 0);
        GameObject.Find("Third Canvas Group").transform.localScale = new Vector3(0, 0, 0);
        GameObject.Find("Fourth Canvas Group").transform.localScale = new Vector3(0, 0, 0);
        GameObject.Find("Fifth Canvas Group").transform.localScale = new Vector3(0, 0, 0);
        GameObject.Find("Adenine").transform.localScale = new Vector3(0, 0, 0);
        GameObject.Find("Sixth Canvas Group").transform.localScale = new Vector3(0, 0, 0);
        GameObject.Find("Guanine").transform.localScale = new Vector3(0, 0, 0);
        GameObject.Find("Cytosine").transform.localScale = new Vector3(0, 0, 0);
        GameObject.Find("Eighth Canvas Group").transform.localScale = new Vector3(0, 0, 0);
        GameObject.Find("Thymine").transform.localScale = new Vector3(0, 0, 0);
        mainCamera = Camera.main;
    }

    IEnumerator CameraZoom(int zoomValue)
    {
        GameObject user = GameObject.Find("User");
        float t = 0f;
        float duration = 1f;
        Vector3 startPosition = user.transform.localPosition;
        Vector3 endPosition = new Vector3(0, 0, transform.localPosition.z + zoomValue);

        while (t < duration)
        {
            t += Time.deltaTime;
            user.transform.localPosition = Vector3.Lerp(startPosition, endPosition, Mathf.SmoothStep(0, duration, t));
            yield return null;
        }
        mainCamera.transform.localPosition = endPosition;
    }

    public IEnumerator ChangeToScene(int sceneNo)
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneNo);
    }

    public void CellDivisionButton()
    {
        animator.Play("Fade_Out");
        StartCoroutine(ChangeToScene(1));
    }

    public void ZoomButton()
    {
        animator.Play("Fade_Out");
        StartCoroutine(ChangeToScene(2));
    }

    public void QuizButton()
    {
        animator.Play("Fade_Out");
        StartCoroutine(ChangeToScene(3));
    }

    public void MainMenuButton()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneShown = currentScene.name;
        if (sceneShown == "WelcomeScreen")
        {
            return;
        }
        else
        {
            animator.Play("Fade_Out");
            StartCoroutine(ChangeToScene(0));
        }
    }

    public IEnumerator WaitASecond(string canvasName)
    {
        yield return new WaitForSeconds(1);
        GameObject.Find(canvasName).transform.localScale = new Vector3(0, 0, 0);
    }

    //Zoom from Chromosome to DNA
    public void ChromosomeZoom()
    {
        GameObject.Find("Second Canvas Group").transform.localScale = new Vector3(1, 1, 1);
        StartCoroutine(CameraZoom(994));
        StartCoroutine(WaitASecond("First Canvas Group"));
    }

    //Zoom from DNA to Gene
    public void DNAZoom()
    {
        GameObject.Find("Third Canvas Group").transform.localScale = new Vector3(1, 1, 1);
        StartCoroutine(CameraZoom(2216));
        StartCoroutine(WaitASecond("Second Canvas Group"));
    }

    //Zoom from Gene to IntronsExons
    public void GeneZoom()
    {
        GameObject.Find("Fourth Canvas Group").transform.localScale = new Vector3(1, 1, 1);
        StartCoroutine(CameraZoom(3465));
        StartCoroutine(WaitASecond("Third Canvas Group"));
    }

    //Zoom from IntronsExons to Adenine
    public void IntronsExonsZoom()
    {
        GameObject.Find("Fifth Canvas Group").transform.localScale = new Vector3(1, 1, 1);
        GameObject.Find("Adenine").transform.localScale = new Vector3(3.2f, 3.2f, 3.2f);
        StartCoroutine(CameraZoom(1385));
        StartCoroutine(WaitASecond("Fourth Canvas Group"));
    }

    //Zoom from Adenine to Guanine
    public void AdenineZoom()
    {
        GameObject.Find("Sixth Canvas Group").transform.localScale = new Vector3(1, 1, 1);
        GameObject.Find("Guanine").transform.localScale = new Vector3(0.24658f, 0.24658f, 0.24658f);
        StartCoroutine(CameraZoom(792));
        StartCoroutine(WaitASecond("Fifth Canvas Group"));
    }

    //Zoom from Guanine to Cytosine
    public void GuanineZoom()
    {
        GameObject.Find("Seventh Canvas Group").transform.localScale = new Vector3(1, 1, 1);
        GameObject.Find("Cytosine").transform.localScale = new Vector3(0.116919f, 0.116919f, 0.116919f);
        StartCoroutine(CameraZoom(1390));
        StartCoroutine(WaitASecond("Sixth Canvas Group"));
    }

    //Zoom from Cytosine to Thymine
    public void CytosineZoom()
    {
        GameObject.Find("Eighth Canvas Group").transform.localScale = new Vector3(1, 1, 1);
        GameObject.Find("Thymine").transform.localScale = new Vector3(3.760284f, 3.760284f, 3.760284f);
        StartCoroutine(CameraZoom(1718));
        StartCoroutine(WaitASecond("Seventh Canvas Group"));
    }

    //Zoom out from Thymine to Chromosome back again
    public void ThymineZoom()
    {
        StartCoroutine(WaitASecond("Eighth Canvas Group"));
        StartCoroutine(CameraZoom(-8626));
        Start();
    }
}