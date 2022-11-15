using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] List<Seller> _sellers = new List<Seller>();
    [SerializeField] List<Buyer> _buyers = new List<Buyer>();
    [SerializeField] Transform _startTransform;
    [SerializeField] Transform _endTransform;
    public Transform StartTransform => _startTransform;
    public Transform EndTransform => _endTransform;
    public void Initialize()
    {
       
    }
   
    public void StartLevel()
    {
        foreach (Seller seller in _sellers)
        {
            seller.Initialize();
        }
        foreach (Buyer buyer in _buyers)
        {
            buyer.Initialize();
        }
    }

    public void EndLevel()
    {
        foreach (Seller seller in _sellers)
        {
            seller.End();
        }
        foreach (Buyer buyer in _buyers)
        {
            buyer.End();
        }
    }
}
