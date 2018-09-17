using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Drawing;
using System.IO;
using UnityEngine.UI;

public class ShowText : MonoBehaviour {

    // Use this for initialization
    public UnityEngine.UI.Image _img;
    private string[] lines;
    private string[] bmp;
    private int _len , i = -1;
    public TextMesh _text;
    float lastStep=0.0f, timeBetweenSteps = 0.13f;
    string path_text = @"C:\Users\sanch\Documents\Open instructions\Assets\Instructions\Test.txt";
    string path_images = @"C:\Users\sanch\Documents\Open instructions\Assets\Instructions\";
    void Start () {
        lines = System.IO.File.ReadAllLines(path_text);  //Read text files
        bmp = Directory.GetFiles(path_images, "*.jpg"); ; //read images
        _len = lines.Length;
        Debug.Log(bmp.Length);
    }
   
    // Update is called once per frame
    void Update () {
        _showtext();
        _showImages();
    }

    private void _showtext()
    {

        if (i >= _len)
        {
            _text.text = "End of Instructions";

        }
        else if (i < 0)
        {
            _text.text = " Begining of Instructions";

        }
        else
        {
            _text.text = lines[i];
        }

        if (Time.time - lastStep > timeBetweenSteps )
        {
            lastStep = Time.time;
            Debug.Log(i);
            _ChangeValue();
        }

    }

    public void _ChangeValue()
    {
        if (Input.GetKey(KeyCode.UpArrow) && i<_len)
        {
            i++;
        }
        if (Input.GetKey(KeyCode.DownArrow) && i >=0)
        {
            i--;
        }
    }

    //public void _showImages()
    //{
    //    _img.sprite = bmp[i];
    //}


}

