using System.Collections;

namespace ConsoleApp2
{
    internal class Program
    {
        public int Length => _length;

        //public int Length
        //{
        //    get
        //    {
        //        return _length;
        //    }
        //}

        public int Capacity => _items.Length; // items의 전체길이


        private object[] _items; //넣을 아이템
        private int _length; //실제로 넣은 아이템의 개수
        

        //삽입
        public void Add(object item)
        {
            //전체 크기와 실제로 넣은 아이템의 개수가 같다면
            //공간이 모자라다면 더 큰배열을 만들고 아이템 복제
            if(_length == Capacity)
            {
                //임시 배열은 기존의 _length의 2배로 늘린다.
                object[] tempItems = new object[_length*2];
                //_items의 0번째 인덱스부터를 tempItems의 0번째 인덱스에 넣는다. _length만큼
                Array.Copy(_items, 0, tempItems, 0, _length);
            }

            //현재까지 있는것 뒤에 넣어줘야함
            _items[_length++] = item;
        }


        public int IndexOf(object item)
        {
             Comparer comparer = Comparer.Default;

            for (int i = 0; i < _length; i++)
            {
                //오브젝트 비교는 comaprer
                //a,b를 비교해서 같으면 0 반환
                if (comparer.Compare(_items[i], item) == 0)
                {
                    return i;
                }
            }
            //못찾으면 -1 반환
            return -1;
        }

        
        public bool Remove(object item)
        {
            
            //지우고싶은 인덱스를 찾아서, 그 뒤부터 끝까지를 1칸씩 앞으로 당김

            int index = IndexOf(item);

            if (index < 0)
                return false;

            for (int i = index; i < _length-1; i++)
            {
                _items[i] = _items[i + 1];
            }
            _length--;
            return true;
        }
    }
}