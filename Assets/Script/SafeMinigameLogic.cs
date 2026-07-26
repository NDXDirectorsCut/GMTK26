using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using TMPro;
using Unity.Mathematics;

public class SafeMinigameLogic : MonoBehaviour
{
  public string code = "";
  public TMP_Text codeText;
  public List<SpriteButton> buttons = new();
  public string last6Nums = "%";
  public GameObject safeOpen;
  void Start()
  {
    gameObject.GetComponent<MinigameLogic>().successed = false;
    safeOpen.SetActive(false);
    //generate random 6-digit code
    for (int i = 0; i < 6; i++)
    {
      int newNum = UnityEngine.Random.Range(0,9);
      code += newNum.ToString();
    }
    codeText.text = code;
  }
  void Update()
  {
    //check last 6 pressed keys
    for (int i = 0; i <= 9; ++i)
    {
      if (buttons[i].clickDown == true)
      {
        last6Nums += i.ToString();
        if (last6Nums.Length > 6)
        {
          last6Nums = last6Nums.Substring(1);
        }
      }
      if (last6Nums == code)
      {
        gameObject.GetComponent<MinigameLogic>().successed = true;
        gameObject.GetComponent<MinigameLogic>().failed = false;
        safeOpen.SetActive(true);
      }
    }

  }
}