using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm
{
    class MyList<T>
    {
        const int DEFAULT_SIZE = 1;
        T[] _data = new T[DEFAULT_SIZE];

        public int Count = 0;       // 실제로 사용 중인 데이터 개수
        public int Capacity { get { return _data.Length; } }    // 예약된 데이터 개수

        // O(1) 예외 케이스 : 이사 비용은 무시한다.
        public void Add(T item)
        {
            // 1. 공간이 충분히 남아 있는지 확인한다.
            if (Count >= Capacity)
            {
                // 공간을 다시 늘려서 확보한다.
                T[] newArray = new T[Count * 2];
                for (int i = 0; i < Count; i++)
                    newArray[i] = _data[i];
                _data = newArray;
            }

            // 2. 공간에다가 데이터를 넣어준다.
            _data[Count] = item;
            Count++;
        }

        // O(1)
        public T this[int index]
        {
            get { return _data[index]; }
            set { _data[index] = value; }
        }

        // O(N)
        public void RemoveAt(int index)
        {
            for (int i = index; i < Count - 1; i++)
                _data[i] = _data[i + 1];
            _data[Count - 1] = default(T);
            Count--;
        }
    }

    class MyLinkedListNode<T>
    {
        public T Data;
        public MyLinkedListNode<T> Next;
        public MyLinkedListNode<T> Prev;
    }

    
    class MyLinkedList<T>
    {
        public MyLinkedListNode<T> Head = null;        // 첫번째
        public MyLinkedListNode<T> Tail = null;        // 마지막
        public int Count = 0;

        // O(1)
        public MyLinkedListNode<T> AddLast(T data)
        {
            MyLinkedListNode<T> newRoom = new MyLinkedListNode<T>();
            newRoom.Data = data;

            // 만약에 아직 방에 없었다면, 새로 추가한 첫번째 방이 곧 Head이다.
            if (Head == null)
                Head = newRoom;

            // 기존의 [마지막 방]과 [새로 추가된 방]을 연결해준다.
            if (Tail != null)
            {
                Tail.Next = newRoom;
                newRoom.Prev = Tail;
            }

            // [새로 추가된 방]을 [마지막 방]으로 인정한다.
            Tail = newRoom;
            Count++;
            return newRoom;
        }

        // O(1)
        public void Remove(MyLinkedListNode<T> room)
        {
            // [기존의 첫번째 방의 다음 방]을 [첫번째의 방]로 인정한다.
            if (Head == room)
                Head = Head.Next;

            // [기존의 마지막 방의 이전 방]을 [마지막 방]으로 인정한다.
            if (Tail == room)
                Tail = Tail.Prev;

            if (room.Prev != null)
                room.Prev.Next = room.Next;

            if (room.Next != null)
                room.Next.Prev = room.Prev;

            Count--;
        }
    }

    class Board
    {
        public int[] _data = new int[25];                       // 배열
        //public List<int> _data2 = new List<int>();              // 동적 배열, C++에서 vector
        public MyList<int> _data2 = new MyList<int>();          
        //public LinkedList<int> _data3 = new LinkedList<int>();  // 연결 리스트
        public MyLinkedList<int> _data3 = new MyLinkedList<int>();  // 연결 리스트

        public void Initialize()
        {
            _data3.AddLast(101);
            _data3.AddLast(102);
            MyLinkedListNode<int> node = _data3.AddLast(103);
            _data3.AddLast(104);
            _data3.AddLast(105);

            _data3.Remove(node);
        }
    }
}
