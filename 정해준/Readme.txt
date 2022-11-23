시작하는 화면과 연결되는 로딩화면의 UI를 갱신하였습니다.

Play Scenes 폴더 안에 Menu 3D 씬의 UI를 변경했습니다.

Menu 3D는 scenes 폴더안의 playScenes 안에 저장이 되어있습니다.

변경된 부분은 일정 시간이 지나면 스폰되는 몬스터의 양이 상승하도록 스크립트를 수정했습니다.
해당 내용은 GamaManagerScript_pwj에 있습니다.
GameManager에 추가한 내용
// 모든 변수는 public이기 때문에 히에라르키 창에서 드래그 앤 드랍으로 연동가능
UI연동에 필요한 오브젝트, 텍스트 변수 선언

LateUpdate()메소드에 플레이어의 체력과 연동이 되도록 player_jhj 스크립트의 p_hp_jhj(현재체력)와 p_starting_hp_jhj(초기체력)
을 표시하도록 설정

stageUp(float 시간)함수 경과된 시간이 일정 시간보다 낮을 경우 실행하고 스테이지 레벨이 높아지고 몬스터의 개체수가 증가
하도록 설정
이때 spawningPool_jhj의 변수를 미리 선언을 해놓았기 때문에 keepmonstercnt_jhj의 수를 게임매니저에서 변경

현재 유지하고 있는 몬스터의 수가 보이도록 설정