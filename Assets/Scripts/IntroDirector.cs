using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Unity.Mathematics;

public class IntroDirector : MonoBehaviour
{
    public TMP_Text m_text1, m_text2, m_text3;
    public Button m_begin;
    
    public float m_initialPause;
    public float m_textPause;
    public float m_textRevealDuration;
    
    private Image m_btnImage;
    private TMP_Text m_btnText;

    public void OnBeginPressed()
    {
        SceneManager.LoadScene(1);
    }

    void Start()
    {
        m_btnImage = m_begin.GetComponent<Image>();
        m_btnText = m_begin.transform.GetChild(0).GetComponent<TMP_Text>();
        
        StartCoroutine(IntroSequence());
    }

    IEnumerator IntroSequence()
    {
        yield return new WaitForSeconds(m_initialPause);
        
        Color text1Start = m_text1.color;
        Color text2Start = m_text2.color;
        Color text3Start = m_text3.color;
        Color btnTextStart = m_btnText.color;
        Color btnImageStart = m_btnImage.color;

        Color text1End = m_text1.color + Color.black;
        Color text2End = m_text2.color + Color.black;
        Color text3End = m_text3.color + Color.black;
        Color btnTextEnd = m_btnText.color + Color.black;
        Color btnImageEnd = m_btnImage.color + Color.black;
        
        float timer = 0f;
        while (timer < m_textRevealDuration)
        {
            float t = math.clamp(timer / m_textRevealDuration, 0f, 1f);
            
            t = EaseUtilityFunctions.easeInQuart(t);
            m_text1.color = Color.Lerp(text1Start, text1End, t);
            
            yield return null;
            
            timer += Time.deltaTime;
        }

        yield return new WaitForSeconds(m_textPause);
        
        timer = 0f;
        while (timer < m_textRevealDuration)
        {
            float t = math.clamp(timer / m_textRevealDuration, 0f, 1f);
            
            t = EaseUtilityFunctions.easeInQuart(t);
            m_text2.color = Color.Lerp(text2Start, text2End, t);
            
            yield return null;
            
            timer += Time.deltaTime;
        }
        
        yield return new WaitForSeconds(m_textPause);
        
        timer = 0f;
        while (timer < m_textRevealDuration)
        {
            float t = math.clamp(timer / m_textRevealDuration, 0f, 1f);
            
            t = EaseUtilityFunctions.easeInQuart(t);
            m_text3.color = Color.Lerp(text3Start, text3End, t);
            
            yield return null;
            
            timer += Time.deltaTime;
        }
        
        yield return new WaitForSeconds(m_textPause);
        
        timer = 0f;
        while (timer < m_textRevealDuration)
        {
            float t = math.clamp(timer / m_textRevealDuration, 0f, 1f);
            
            t = EaseUtilityFunctions.easeInQuart(t);
            
            m_btnImage.color = Color.Lerp(btnTextStart, btnTextEnd, t);
            m_btnText.color = Color.Lerp(btnImageStart, btnImageEnd, t);
            
            yield return null;
            
            timer += Time.deltaTime;
        }

        m_begin.interactable = true;
    }
}
