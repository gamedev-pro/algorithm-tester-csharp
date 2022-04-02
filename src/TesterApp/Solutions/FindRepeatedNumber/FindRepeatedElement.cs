namespace TesterApp
{	
    public static class FindRepeatedElement
    {
        /*
        Dado um array de tamanho n com elementos entre 1 e n-1, e um elemento repetido.
        Encontre o índice do número duplicado, sem usar nenhum espaço extra.
        Source: https://www.techiedelight.com/find-duplicate-element-limited-range-array/
        */
        public static int Solution(int[] arr)
        {	
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] == arr[j])
                    {
                        return i;
                    }
                }
            }
            return -1;
        }
    }
}