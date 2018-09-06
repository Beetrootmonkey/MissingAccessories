using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace missingaccessories
{
    static class Utils
    {
        public static int GetIndexInArray(object[] arr, object obj)
        {
            if (arr == null)
            {
                return -1;
            }

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].Equals(obj))
                {
                    return i;
                }
            }

            return -1;
        }

        public static int GetIndexInArray(int[] arr, int obj)
        {
            if (arr == null)
            {
                return -1;
            }

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == obj)
                {
                    return i;
                }
            }

            return -1;
        }

        public static bool IsInArray(object[] arr, object obj)
        {
            return GetIndexInArray(arr, obj) != -1;
        }

        public static bool IsInArray(int[] arr, int obj)
        {
            return GetIndexInArray(arr, obj) != -1;
        }

        public static bool HasAccessory(Item[] arr, int type, int indexToIgnore = -1)
        {
            return HasAccessory(arr, type, new int[] { indexToIgnore });
        }

        public static bool HasAccessory(Item[] arr, int type, int[] indicesToIgnore)
        {
            for (int i = 3; i < 10; i++)
            {
                if (arr[i].type == type)
                {
                    if (!IsInArray(indicesToIgnore, i))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
