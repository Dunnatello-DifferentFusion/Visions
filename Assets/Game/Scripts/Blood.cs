using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blood : MonoBehaviour
{
    public Sprite[] bloodSplatter;

    public Image imagePrefab;

    public RectTransform canvasRect;
    void Start()
    {
        canvasRect = GetComponent<RectTransform>();
    }

    public void damageTaken()
    {
        
        Image image = Instantiate(imagePrefab);
        image.sprite = bloodSplatter[Random.Range(0, bloodSplatter.Length)];

        image.transform.SetParent(canvasRect);

        float canvasWidth = canvasRect.rect.width;
        float canvasHeight = canvasRect.rect.height;
        float imageWidth = image.rectTransform.rect.width;
        float imageHeight = image.rectTransform.rect.height;

        // Calculate the bounds of the screen based on the image size
        float xMin = -canvasWidth / 2f + imageWidth / 4f;
        float xMax = canvasWidth / 2f - imageWidth / 4f;
        float yMin = -canvasHeight / 2f + imageHeight / 4f;
        float yMax = canvasHeight / 2f - imageHeight / 4f;

        // Randomly choose a side of the screen to spawn the image on
        int side = Random.Range(0, 4); // 0 = top, 1 = right, 2 = bottom, 3 = left

        // Set the position of the image based on the chosen side
        switch (side)
        {
            case 0: // top
                image.rectTransform.anchoredPosition = new Vector2(Random.Range(xMin, xMax), yMax);
                break;
            case 1: // right
                image.rectTransform.anchoredPosition = new Vector2(xMax, Random.Range(yMin, yMax));
                break;
            case 2: // bottom
                image.rectTransform.anchoredPosition = new Vector2(Random.Range(xMin, xMax), yMin);
                break;
            case 3: // left
                image.rectTransform.anchoredPosition = new Vector2(xMin, Random.Range(yMin, yMax));
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
