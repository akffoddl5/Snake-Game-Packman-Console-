# Snake-Game-Packman-Console-

![image](https://github.com/akffoddl5/Snake-Game-Packman-Console-/assets/44525847/7a31866c-f465-4e55-b0ee-072dfc903ba7)


## **프로젝트 소개**

- 콘솔에 BaseMap을 출력하고 배열로서 직접 관리
- 빨간색 아이템은 먹을 시 몸의 길이가 늘어나고 맵 랜덤에서 재생성
- 방향키로 조작
- 머리가 자기 몸에 닿거나 벽에 닿으면 실패
- 몸을 늘려 맵 전체를 채우면 승리

## 시연영상

https://youtu.be/FRPQpHmr8_8

## **목차**

1. **맵**
    
    **1-1. BaseMap 생성**
    
    **1-2. 오브젝트 그리기와 초기화**
    
2. **캐릭터 이동**
    
    **2-1. 입력값 받기**
    
    **2-2. 이동**
    
3. **클리어**
    
    **3-1. 클리어 조건 설정**
    
    **3-2 클리어**
    

### **1. 맵**

**1-1. BaseMap 생성**

```csharp
public void BaseMap()
{
    Console.WriteLine("▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣");
    Console.WriteLine("▣     ｜    ｜    ｜    ｜    ｜    ｜    ｜    ｜    ｜     ▣");
    Console.WriteLine("▣     ｜    ｜    ｜    ｜    ｜    ｜    ｜    ｜    ｜     ▣");
    Console.WriteLine("▣_____｜____｜____｜____｜____｜____｜____｜____｜____｜____ ▣");
    Console.WriteLine("▣     ｜    ｜    ｜    ｜    ｜    ｜    ｜    ｜    ｜     ▣");
    Console.WriteLine("▣     ｜    ｜    ｜    ｜    ｜    ｜    ｜    ｜    ｜     ▣");
    Console.WriteLine("▣_____｜____｜____｜____｜____｜____｜____｜____｜____｜____ ▣");
    Console.WriteLine("▣     ｜    ｜    ｜    ｜    ｜    ｜    ｜    ｜    ｜     ▣");
    Console.WriteLine("▣     ｜    ｜    ｜    ｜    ｜    ｜    ｜    ｜    ｜     ▣");
    Console.WriteLine("▣_____｜____｜____｜____｜____｜____｜____｜____｜____｜____ ▣");
    Console.WriteLine("▣     ｜    ｜    ｜    ｜    ｜    ｜    ｜    ｜    ｜     ▣");
    Console.WriteLine("▣     ｜    ｜    ｜    ｜    ｜    ｜    ｜    ｜    ｜     ▣");
    Console.WriteLine("▣_____｜____｜____｜____｜____｜____｜____｜____｜____｜____ ▣");
    Console.WriteLine("▣     ｜    ｜    ｜    ｜    ｜    ｜    ｜    ｜    ｜     ▣");
    Console.WriteLine("▣     ｜    ｜    ｜    ｜    ｜    ｜    ｜    ｜    ｜     ▣");
    Console.WriteLine("▣_____｜____｜____｜____｜____｜____｜____｜____｜____｜____ ▣");
    Console.WriteLine("▣     ｜    ｜    ｜    ｜    ｜    ｜    ｜    ｜    ｜     ▣");
    Console.WriteLine("▣     ｜    ｜    ｜    ｜    ｜    ｜    ｜    ｜    ｜     ▣");
    Console.WriteLine("▣_____｜____｜____｜____｜____｜____｜____｜____｜____｜____ ▣");
    Console.WriteLine("▣     ｜    ｜    ｜    ｜    ｜    ｜    ｜    ｜    ｜     ▣");
    Console.WriteLine("▣     ｜    ｜    ｜    ｜    ｜    ｜    ｜    ｜    ｜     ▣");
    Console.WriteLine("▣_____｜____｜____｜____｜____｜____｜____｜____｜____｜____ ▣");
    Console.WriteLine("▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣ ");

    //3,2 오른쪽 머리
    PrintIndexHead(3, 2);

}
```

**1-2. 오브젝트 그리기와 초기화**

- **해당 좌표에 오브젝트를 그리는 함수 작성**
- **스테이크의 머리에 해당하는 부분은 보라색으로 출력**
    - **Console.ForegroundColor = ConsoleColor.Magenta;**

```csharp
public void PrintIndexHead(int i, int j)
{
    int x = 6 * i + 3;
    int y = 3 * j + 1;

    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.SetCursorPosition(x, y);
    Console.Write("▲▲");//≥ ≤
    Console.SetCursorPosition(x - 1, y + 1);
    Console.Write(".>ω<");
    Console.ResetColor();
    Console.SetCursorPosition(40, 25);
}

public void PrintIndexHead(Cord cord)
{
    int x = 6 * cord.x + 3;
    int y = 3 * cord.y + 1;

    Console.SetCursorPosition(x, y);
    Console.Write("▲▲");//≥ ≤
    Console.SetCursorPosition(x - 1, y + 1);
    Console.Write(".>ω<");
    Console.SetCursorPosition(40, 25);
}
//
public void PrintIndexHeadTurn(int i, int j, Dir dir)
{
    int x = 6 * i + 3;
    int y = 3 * j + 1;

    //머리에 회전주려 했으나 안이뻐서 패스
    //Console.SetCursorPosition(x, y);
    //Console.Write(p1[(int)dir]);//≥ ≤
    //Console.SetCursorPosition(x, y+1);
    //Console.Write(p2[(int)dir]);
    //Console.SetCursorPosition(40, 25);

}

public void PrintIndexBody(int i, int j)
{
    int x = 6 * i + 3;
    int y = 3 * j + 1;

    Console.SetCursorPosition(x, y);
    Console.Write("▲▲");//≥ ≤
    Console.SetCursorPosition(x - 1, y + 1);
    Console.Write(".=ω=");
    Console.SetCursorPosition(40, 25);
}

public void PrintIndexBody(Cord cord)
{
    int x = 6 * cord.x + 3;
    int y = 3 * cord.y + 1;

    Console.SetCursorPosition(x, y);
    Console.Write("▲▲");//≥ ≤
    Console.SetCursorPosition(x - 1, y + 1);
    Console.Write(".=ω=");
    Console.SetCursorPosition(40, 25);
}

public void PrintIndexEmpty(int i, int j)
{
    int x = 6 * i + 3;
    int y = 3 * j + 1;

    Console.SetCursorPosition(x, y);
    Console.Write("    ");//≥ ≤
    Console.SetCursorPosition(x, y + 1);
    Console.Write("    ");
    Console.SetCursorPosition(40, 25);
}

public void PrintIndexEmpty(Cord cord)
{
    int x = 6 * cord.x + 3;
    int y = 3 * cord.y + 1;

    Console.SetCursorPosition(x, y);
    Console.Write("    ");//≥ ≤
    Console.SetCursorPosition(x, y + 1);
    Console.Write("    ");
    Console.SetCursorPosition(40, 25);
}

public void PrintItem(Cord cord)
{
    int x = 6 * cord.x + 3;
    int y = 3 * cord.y + 1;

    Console.SetCursorPosition(x, y);
    Console.Write("  ");//≥ ≤
    Console.SetCursorPosition(x, y + 1);
    Console.Write(" ♣");
    Console.SetCursorPosition(40, 25);
}

public void PrintItem(int i, int j )
{
    int x = 6 * i + 3;
    int y = 3 * j + 1;

    Console.SetCursorPosition(x, y);
    Console.Write("  ");//≥ ≤
    Console.SetCursorPosition(x, y + 1);
    Console.Write(" ♣");
    Console.SetCursorPosition(40, 25);
}
```

### 2**. 캐릭터 이동**

2-1. 입력값 받기

- Environment.TickCount 로 프레임처럼 구분
- 입력 없을 시 current_dir 로 이동

```csharp
public int Progress()
{
    int cur_timer = Environment.TickCount;
    
    while (true)
    {
        int game_state = IsGameClear();
        if (game_state == 1)
        {
            return 1;
        } else if (game_state == 2) {
            return 2;
        }
        

        if (cur_timer + 200 > Environment.TickCount)
        {
            continue;
        }
        else
        {
            cur_timer = Environment.TickCount;
        }
        int input;
        if (_kbhit() != 0)
        {
            input = _getch();
            if (input == 224)
            {
                input = _getch();
            }

            switch (input)
            {
                case 72:
                    Move_player(Dir.UP);
                    break;
                case 80:
                    Move_player(Dir.DOWN);
                    break;
                case 75:
                    Move_player(Dir.LEFT);
                    break;
                case 77:
                    Move_player(Dir.RIGHT);
                    break;

            }

        }
        else
        {
            Move_player(current_dir);
        }

        

    }

}
```

2-2. 이동

```csharp
public void Move_player(Dir dir)
{
    current_dir = dir;
    int next_X = player_list[0].x + p1[(int)dir];
    int next_Y = player_list[0].x + p2[(int)dir];

    //바운드, 몸닿기 검사
    if (!Bound_check(dir))
    {
        Fail();
        return;
    }

    //아이템 판별 and 먹기 and 리스트 추가
    CheckItem(dir);

    //사과 싹다 그리기 리셋
    PrintItemAll();

    //마지막 그림 없애고 이동하는 머리 그림 없애고 추가하고     (중간에 인덱스 1번짜리 머리-> 몸으로 바꿔야될듯 한다면 꼬리 없애기 전 첫번쨰로 해야함)
    mp.PrintIndexEmpty(player_list[player_list.Count - 1]);
    mp.PrintIndexEmpty(player_list[0]);
    mp.PrintIndexBody(player_list[0]);

    mp.PrintIndexHead(player_list[0].x + p1[(int)dir], player_list[0].y + p2[(int)dir]);
    //이동하고
    Pull_player(dir);
    //아이템 판별 한번더
    CheckItem(dir);
    //꼬리그리고
    mp.PrintIndexBody(player_list[player_list.Count - 1]);

}
```

### 3**. 클리어**

- 맵에 플레이어가 꽉 찰 경우 승리
- 플레이어 좌표를 담고 있는 리스트가 맵의 갯수와 일치하게 됐을때 클리어 처리

![image](https://github.com/akffoddl5/Snake-Game-Packman-Console-/assets/44525847/67fa7410-08d1-4c59-8a61-b9c036dab835)
