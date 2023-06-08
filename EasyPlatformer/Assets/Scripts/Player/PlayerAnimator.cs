using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    private int Jump = Animator.StringToHash("JumpTransition");
    private int Run = Animator.StringToHash("RunTransition");

    private Animator _animator;

    private void Start() =>
        _animator = GetComponent<Animator>();

    public void JumpEnable() =>
        _animator.SetBool(Jump, true);

    public void JumpDisable() =>
        _animator.SetBool(Jump, false);
    
    public void RunEnable() =>
        _animator.SetBool(Run, true);

    public void RunDisable() =>
        _animator.SetBool(Run, false);
}

