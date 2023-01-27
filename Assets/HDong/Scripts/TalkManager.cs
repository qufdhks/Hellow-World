using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;

    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        GenerateData();
    }

    void GenerateData()
    {
        //퀘스트 대화 아님
        talkData.Add(1000, new string[] { "안녕?", "우리 섬에 온걸 환영해" });
        talkData.Add(2000, new string[] { "어서와.", "뭔가 필요한 게 있어?" });
        talkData.Add(4000, new string[] { "안녕! OO아, 마음껏 마을을 둘러봐" });
        talkData.Add(5000, new string[] { " 무슨 일 있어?" });
        // 조합 NPC
        talkData.Add(8000, new string[] { "조합할래?" });

        //Quest Talk
        //talkData.Add(10 + 1000, new string[] { "드디어 일어났구나", "여기는 OO마을이야\n해변가에 쓰러져 있길래 데려왔어.", 
        //                                        "일단 정신을 차리면 밖에 나가서 OO이를 찾아봐\n도움을 줄거야." });
        //talkData.Add(20 + 1000, new string[] { "아직 OO이를 못찾은거야?\n밖으로 나가서 오른쪽이야." });
        //talkData.Add(20 + 2000, new string[] { "너가 OO이가 말한 애구나?", "일단 이 마을에서 적응하려면 도구가 필요하겠지?", 
        //                                        "주변에서 돌 3개와 나뭇가지 3개를 주워오면\n내가 도끼를 만들어 줄게." });


        //talkData.Add(21 + 2000, new string[] { "나뭇가지랑 돌맹이는 나무 사이사이에 보면 떨어져 있을거야." });
        //talkData.Add(20 + 1000, new string[] { "내가 돌맹이를 줄게(테스트용)" });
        //talkData.Add(21 + 2000, new string[] { "모두 찾아왔구나.", "주워온 나뭇가지와 돌맹이로 내가 도끼를 만들어줄게.", "자.\n도끼로 이제 나무를 베어서 통나무를 얻을 수 있을거야.",
        //                                       "다리를 건너면 찾을 수 있는 밍고를 찾아가봐.\n다른 일을 줄거야."});

        //talkData.Add(30 + 4000, new string[] { "안녕!! 로키한테 얘기 들었어.\n", "OO마을에선 다양한 동물들과 친해질 수가 있고 \n인테리어 소품을 제작할 수도 있어.", 
        //                                       "내가 더 설명해 줄테니 마을에서 목재 20개를 구해와." });
        //talkData.Add(31 + 4000, new string[] { "잘했어!*^^*\n인테리어 소품을 만들 수 있는 부드러운 목재 5개를 선물로 줄게.",
        //                                       "(제작에 대해 설명)", "마을에 다양한 동물들이 있는 건 알고있지?", 
        //                                       "강아지에게 먹이를 주고 친해져봐!\n 널 따라다니면서 도움을 줄거야.", "강아지와 함께 로아를 찾아가봐"});
        //talkData.Add(40 + 5000, new string[] { "반가워! OO아, 강아지랑 친해졌구나.", "물고기는 잡아봤어?\n낚시대가 없다면 부엉이한테 조합을 맡길 수 있어.", "바다나 강가에서 물고기 5마리를 잡아봐" });
        //talkData.Add(41 + 5000, new string[] { "고생했어~! 이제 말이랑 친해져봐" });


        //사물
        //talkData.Add(100, new string[] { "지금은 들어갈 수 없다" });


        talkData.Add(10 + 1000, new string[] { "반가워, 너가 후계자 시험에 도전한다던 Nomi 구나 ? 기다리고있었어!",
                                                "후계자 시험을 치르려면 필요한게 많을텐데 우리가 도와줄게!\n우선은 마을회관으로 가봐, 마을회관은 바로 뒷편의 축사가 있는 큰 건물이야." });
        talkData.Add(20 + 1000, new string[] { "마을회관으로 가봐, 마을회관은 바로 뒷편의 축사가 있는 큰 건물이야." });
        talkData.Add(20 + 2000, new string[] { "반가워 노미!\n우선은 너도 이런저런 도구들이 필요할 것 같은데 아마 왕빼미 친구가 도와줄 수 있을거야",
                                                "강건너 꽃밭 근처에 이름값 하는 친구를 한번 찾아보렴\n걸어다니긴 힘들테니 포니를 빌려줄게 포니를 타고가렴. 포니는 바로옆 울타리 안에 있어!" });
        talkData.Add(21 + 2000, new string[] { "왕빼미는 강건너 꽃밭 근처에 있어.\n울타리 안에 있는 포니를 타고 가봐!" });

        talkData.Add(21 + 8000, new string[] { "너가 그 후계자 수업을 한다는 녀석인가?", "흠… 쥐방울 만해서 영 신뢰가 가지 않는데..\n시험을 줄테니 이 시험들을 통과한다면 너에게 도움이 되는 도구들을 만들어 주겠어, 이 재료들을 구해와봐" });

        talkData.Add(30 + 8000, new string[] { "아직 못구해왔어? 빨리가" });

        talkData.Add(40 + 8000, new string[] { "좋아 조그마한 주제에 씩씩하게 해냈구나\n생각보다 마음에 드는 구석이 있어… 널 조금더 특별하게 해줄 친구들이 있는곳을 알려주지",
                                                "마을 중앙에 마법의 차원문이 있을거야\n각각의 차원문을 지나면 너가 경험하지 못한 또다른 세상이 있을거야…", "그곳들을 방문해봐 어쩌면 너에게 또다른 인연이 있을지도 모르니…."});
    }

    public string GetTalk(int id, int talkIndex)
    {
        if (!talkData.ContainsKey(id))
        {
            if (!talkData.ContainsKey(id - id % 10))
                return GetTalk(id - id % 100, talkIndex);
            else
                return GetTalk(id - id % 10, talkIndex);
        }

        if (talkIndex == talkData[id].Length)
            return null;
        else
            return talkData[id][talkIndex];
    }
}