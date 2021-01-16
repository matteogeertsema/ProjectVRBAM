using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHandler : MonoBehaviour {

    public UnityEngine.UI.Text titleText;
    public UnityEngine.UI.Text firstLineText;
    public UnityEngine.UI.Text secondLineText;
    public UnityEngine.UI.Text thirdLineText;
    public UnityEngine.UI.Text fourthLineText;
    public UnityEngine.UI.Image PCcontrolsImage;

    public UnityEngine.UI.Text stepObjectiveText;


    public GameObject introButton;
    public GameObject outroButton;

    public GameObject canvas;
    public GameObject objectiveCanvas;
    public GameObject temperatureCanvas;
 


    public void displayIntro(string title, Introduction intro) {
        setTextFieldsForIntro(title, intro.getFirstLine(), intro.getSecondLine());
        PCcontrolsImage.enabled = false;
        canvas.SetActive(true);
        StartCoroutine(startIntroTextFadeInAnimation());
    }

    public void displayOutro(Outro outro) {
        setTextFieldsForOutro(outro.getFirstLine(), outro.getSecondLine(), outro.getThirdLine());
        temperatureCanvas.SetActive(false);
        canvas.SetActive(true);
        StartCoroutine(startOutroTextFadeInAnimation());
    }

    private void setTextFieldsForIntro(string title, string firstLine, string secondLine) {
        setTitle(title);
        setFirstLine(firstLine);
        setSecondLine(secondLine);
    }

    private void setTextFieldsForOutro(string firstLine, string secondLine, string thirdLine) {
        setFirstLine(firstLine);
        setSecondLine(secondLine);
        setThirdLine(thirdLine);
    }

    private void setAllElementsTransparent() {
        titleText.color = new Color(255, 255, 255, 0);
        firstLineText.color = new Color(255, 255, 255, 0);
        secondLineText.color = new Color(255, 255, 255, 0);
        thirdLineText.color = new Color(255, 255, 255, 0);
        fourthLineText.color = new Color(255, 255, 255, 0);
        introButton.SetActive(false);
        outroButton.SetActive(false);
        PCcontrolsImage.enabled = false;
    }

    IEnumerator startIntroTextFadeInAnimation() {
        for (float i = 0; i <= 1; i += Time.deltaTime) {
            yield return null;
        }

        if (isNotEmpty(titleText)) {
            for (float i = 0; i <= 5; i += Time.deltaTime) {
                titleText.color = new Color(255, 255, 255, i);
                yield return null;
            }
        }

        if (isNotEmpty(firstLineText)) {
            for (float i = 0; i <= 5; i += Time.deltaTime) {
                firstLineText.color = new Color(255, 255, 255, i);
                yield return null;
            }
        }

        if (isNotEmpty(secondLineText)) {
            for (float i = 0; i <= 5; i += Time.deltaTime) {
                secondLineText.color = new Color(255, 255, 255, i);
                yield return null;
            }
        }

       
        for (float i = 0; i <= 2; i += Time.deltaTime)
        {
                
            yield return null;
        }
        PCcontrolsImage.enabled = true;
        
        for (float i = 0; i <= 2; i += Time.deltaTime)
        {

            yield return null;
        }

        introButton.SetActive(true);
    }

    IEnumerator startOutroTextFadeInAnimation() {
        for (float i = 0; i <= 2; i += Time.deltaTime) {
            yield return null;
        }

        if (isNotEmpty(firstLineText)) {
            for (float i = 0; i <= 5; i += Time.deltaTime) {
                firstLineText.color = new Color(255, 255, 255, i);
                yield return null;
            }
        }

        if (isNotEmpty(secondLineText)) {
            for (float i = 0; i <= 5; i += Time.deltaTime) {
                secondLineText.color = new Color(255, 255, 255, i);
                yield return null;
            }
        }

        if (isNotEmpty(thirdLineText)) {
            for (float i = 0; i <= 5; i += Time.deltaTime) {
                thirdLineText.color = new Color(255, 255, 255, i);
                yield return null;
            }
        }

        if (isNotEmpty(fourthLineText)) {
            for (float i = 0; i <= 5; i += Time.deltaTime) {
                fourthLineText.color = new Color(255, 255, 255, i);
                yield return null;
            }
        }

        outroButton.SetActive(true);
    }


    private void setTitle(string title) {
        this.titleText.text = title;
    }

    private void setFirstLine(string firstLine) {
        this.firstLineText.text = firstLine;
    }

    private void setSecondLine(string secondLine) {
        this.secondLineText.text = secondLine;
    }

    private void setThirdLine(string thirdLine) {
        this.thirdLineText.text = thirdLine;
    }

    private void setFourthLine(string fourthLine) {
        this.fourthLineText.text = fourthLine;
    }

    public void setNewObjective(string newObjective) {
        this.stepObjectiveText.text = newObjective;
    }

    private bool isNotEmpty(UnityEngine.UI.Text text) {
        return text.text != "" || text.text != null;
    }


    public void onIntroButtonClick() {
        onButtonClick();
        temperatureCanvas.SetActive(true);
    }

    public void onOutroButtonClick() {
        onButtonClick();
    }

    private void onButtonClick() {
        setAllElementsTransparent();
        canvas.SetActive(false);
    }
}