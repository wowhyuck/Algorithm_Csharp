using System;
using System.Collections.Generic;

namespace Exercise
{
    class Graph
    {
        int[,] adj = new int[6, 6]
        {
            { 0, 1, 0, 1, 0, 0 },
            { 1, 0, 1, 1, 0, 0 },
            { 0, 1, 0, 0, 0, 0 },
            { 1, 1, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 1 },
            { 0, 0, 0, 0, 1, 0 }
        };

        List<int>[] adj2 = new List<int>[]
        {
            new List<int>() { 1, 3 },
            new List<int>() { 0, 2, 3 },
            new List<int>() { 1 },
            new List<int>() { 0, 1 },
            new List<int>() { 5 },
            new List<int>() { 4 },
        };

        bool[] visited = new bool[6];
        // 1) 우선 now부터 방문하고,
        // 2) now와 연결된 정점들을 하나씩 확인해서, 아직 미발견(미방문) 상태라면 방문한다.
        public void DFS(int now)
        {
            Console.WriteLine(now);
            visited[now] = true;        // 1) 우선 now부터 방문하고,

            for (int next = 0; next < 6; next++)
            {
                if (adj[now, next] == 0)        // 연결되어 있지 않으면 스킵
                    continue;
                if (visited[next])              // 이미 방문했으면 스킵
                    continue;
                DFS(next);
            }
        }

        public void DFS2(int now)
        {
            Console.WriteLine(now);
            visited[now] = true;        // 1) 우선 now부터 방문하고,

            foreach (int next in adj2[now])
            {
                if (visited[next])              // 이미 방문했으면 스킵
                    continue;
                DFS2(next);
            }
        }

        public void SearchAll()
        {
            visited = new bool[6];
            for (int now = 0; now < 6; now++)
            {
                if (visited[now] == false)
                    DFS(now);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // DFS (Depth First Search : 깊이 우선 탐색)
            // BFS (Breadth First Search : 너비 우선 탐색)

            Graph graph = new Graph();
            //graph.DFS(3);
            //graph.DFS2(3);
            graph.SearchAll();
        }
    }
}
