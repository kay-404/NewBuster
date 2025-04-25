using System.Drawing;
using UnityEngine;
using Yarn.Unity;
using TMPro;

public class VhsData : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public int ratingValue = 0;
    public int correctRating;
    public bool isReviewed = false;
    public string descriptionDialogue;
    private string ratingDialogue;

    public TMP_Text reviewScoreText;
    public DialogueRunner vhsDescription;
    public DialogueRunner vhsRating;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RateMovie()
    {
        if (isReviewed == false)
        {
            vhsDescription.StartDialogue(descriptionDialogue);
        }
    }

    public void SubmitRating()
    {
        isReviewed = true;
        GradeRating();
        vhsRating.StartDialogue(ratingDialogue);
    }

    public void GradeRating()
    {
        if (ratingValue - correctRating == 0)
        {
            reviewScoreText.text = "Movie Review: A";
        }
        else if (ratingValue - correctRating == 1)
        {
            reviewScoreText.text = "Movie Review: B";
        }
        else if (ratingValue - correctRating == -1)
        {
            reviewScoreText.text = "Movie Review: B";
        }
        else if (ratingValue - correctRating == 2)
        {
            reviewScoreText.text = "Movie Review: C";
        }
        else if (ratingValue - correctRating == -2)
        {
            reviewScoreText.text = "Movie Review: C";
        }
        else if (ratingValue - correctRating == 3)
        {
            reviewScoreText.text = "Movie Review: D";
        }
        else if (ratingValue - correctRating == -3)
        {
            reviewScoreText.text = "Movie Review: D";
        }
        else if (ratingValue - correctRating == 4)
        {
            reviewScoreText.text = "Movie Review: F";
        }
        else if (ratingValue - correctRating == -4)
        {
            reviewScoreText.text = "Movie Review: F";
        }
        else
        {
            reviewScoreText.text = "N/A";
        }
    }

    public void OneStar()
    {
        ratingValue = 1;
        ratingDialogue = "OneStar";
    }
    public void TwoStars()
    {
        ratingValue = 2;
        ratingDialogue = "TwoStars";
    }

    public void ThreeStars()
    {
        ratingValue = 3;
        ratingDialogue = "ThreeStars";
    }
    public void FourStars()
    {
        ratingValue = 4;
        ratingDialogue = "FourStars";
    }

    public void FiveStars()
    {
        ratingValue = 5;
        ratingDialogue = "FiveStars";
    }
}

