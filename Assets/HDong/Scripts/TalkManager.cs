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
        talkData.Add(1000, new string[] { "안녕?", "우리 섬에 온걸 환영해" });
        talkData.Add(2000, new string[] { "어서와.", "뭔가 필요한 게 있어?" });
        talkData.Add(4000, new string[] { "안녕! OO아, 마을 좀 둘러봤어?" });
        // 조합 NPC
        talkData.Add(8000, new string[] { "조합할래?" });

        //Quest Talk
        talkData.Add(10 + 1000, new string[] { "드디어 일어났구나", "여기는 OO마을이야\n해변가에 쓰러져 있길래 데려왔어.", 
                                                "일단 정신을 차리면 밖에 나가서 OO이를 찾아봐\n도움을 줄거야." });
        talkData.Add(11 + 1000, new string[] { "아직 OO이를 못찾은거야?\n밖으로 나가서 오른쪽이야." });
        talkData.Add(11 + 2000, new string[] { "너가 OO이가 말한 애구나?", "일단 이 마을에서 적응하려면 도구가 필요하겠지?", 
                                                "주변에서 돌 3개와 나뭇가지 3개를 주워오면\n내가 도끼를 만들어 줄게." });


        talkData.Add(20 + 2000, new string[] { "나뭇가지랑 돌맹이는 나무 사이사이에 보면 떨어져 있을거야." });
        talkData.Add(20 + 1000, new string[] { "내가 돌맹이를 줄게(테스트용)" });
        talkData.Add(21 + 2000, new string[] { "모두 찾아왔구나.", "주워온 나뭇가지와 돌맹이로 내가 도끼를 만들어줄게.", "자.\n도끼로 이제 나무를 베어서 통나무를 얻을 수 있을거야.",
                                               "다리를 건너면 찾을 수 있는 OO이를 찾아가봐.\n다른 일을 줄거야."});
        
        talkData.Add(30 + 4000, new string[] { "OO마을에선 다양한 동물들과 친해질 수가 있고 \n인테리어 소품을 제작할 수도 있어.", "내가 더 설명해 줄테니 마을에서 목재 20개를 구해와줘." });

        //사물
        //talkData.Add(100, new string[] { "지금은 들어갈 수 없다" });
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