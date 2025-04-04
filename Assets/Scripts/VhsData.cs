using System.Drawing;
using UnityEngine;
using Yarn.Unity;

public class VhsData : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public int ratingValue = 0;
    public bool isReviewed = false;
    public string descriptionDialogue;
    private string ratingDialogue;

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
        vhsRating.StartDialogue(ratingDialogue);
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

