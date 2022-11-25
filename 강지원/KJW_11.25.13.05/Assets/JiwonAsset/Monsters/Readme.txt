

Enemy.cs
- 어택 애니메이션 삭제
- 사망시 애니메이션 추가
    public void DieAnim()
    {
        anim.SetTrigger("Die");
    }


GunController.cs
그냥 그대로 사용하면 됨
이거 일단 편법으로 현재 소지한 총알 99999개로 해놨는데 그거 없애고 제한없이 발사 할 수 있게 할 예정

Mob.cs
- 애니메이션 재생단 추가
116줄 enemy.DieAnim();


HUD.cs
총알만 연동시킨 UI

Monsters
몬스터 프리팹 사용법
Monsters/ Gamesoftware / Prefabs 사용
수정된 Mob.cs와 Enemy.cs 붙어있음!

——

소총붙여서 테스트해보고 알려드림