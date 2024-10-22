using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{

    [SerializeField] private PlayerMovement playerMovement;
    public float shootFrequency { get { return _attackRate; } set { _attackRate.Value = value; } } // The frequency of arrows to be shot

    [SerializeField] private Float _attackRate;
    [SerializeField] private float _defaultAttackRate = 0.3f;

    public ObjectPool pool; // Arrow Pool
    public int arrowCount = 3; // Number of arrows to shoot
    public float spreadAngle = 10.0f; // Spreading angle between arrows

    [SerializeField] private bool is180 = false;
    [SerializeField] private bool is90 = false;
    [SerializeField] private bool is270 = false;

    private void Awake() {
        _attackRate.Value = _defaultAttackRate;
        if (is180)
        {
            transform.eulerAngles += new Vector3(0, 0, 180);
        }
        if(is90){
           transform.eulerAngles += new Vector3(0, 0, 90);
        }
        if(is270){
            transform.eulerAngles += new Vector3(0, 0, 270);
        }
    }

    private void Start()
    {
        StartCoroutine(ShootArrow());
    }


    private IEnumerator ShootArrow()
    {
        while (true)
        {

            // Wait until player moves
           /*yield return new WaitUntil(predicate: () =>
            {
                //return playerMovement.IsPlayerMoving();
            });*/

            yield return new WaitForSeconds(shootFrequency);

            MultipleShootSystem(arrowCount);


        }
    }

    private void MultipleShootSystem(int count)
    {
        SoundManager.Instance.PlayArrowWhoosh();
        float startAngle = -spreadAngle * (count - 1) / 2; // starting angle
        print(startAngle);

        for (int i = 0; i < count; i++)
        {
            float currentAngle = startAngle + spreadAngle * i;
            Quaternion rot = Quaternion.Euler(transform.eulerAngles + new Vector3(0, 0, currentAngle));

            var arrow = pool.obj; // Get an arrow from the object pool
            arrow.transform.position = this.transform.position;
            arrow.GetComponent<Arrow>().firstTransform = this.transform.position;
            arrow.transform.rotation =  rot;
        }
    }
}
